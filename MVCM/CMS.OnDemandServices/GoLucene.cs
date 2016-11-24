using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;
using CMS.BusinessObjects;

namespace CMS.OnDemandServices
{
	public static class GoLucene {
		// properties
		public static string _luceneDir =
            Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "lucene_index");
        public static string _lucaenDirFontEnd = @"C:\Hosting\naansolution.com\admin\lucene_index";
        //public static string _lucaenDirFontEnd = @"D:\Son.Ho\NAANSolution_ReactJS\NAANSolution_BackEnd\lucene_index";
		private static FSDirectory _directoryTemp;
		private static FSDirectory _directory {
			get {
				if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new DirectoryInfo(_luceneDir));
				if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
				var lockFilePath = Path.Combine(_luceneDir, "write.lock");
				if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
				return _directoryTemp;
			}
		}

		// search methods
		public static IEnumerable<LuceneData_BO> GetAllIndexRecords() {
			// validate search index
           if (!System.IO.Directory.EnumerateFiles(_luceneDir).Any()) return new List<LuceneData_BO>();

			// set up lucene searcher
			var searcher = new IndexSearcher(_directory, false);
			var reader = IndexReader.Open(_directory, false);
			var docs = new List<Document>();
			var term = reader.TermDocs();
      // v 2.9.4: use 'hit.Doc()'
      // v 3.0.3: use 'hit.Doc'
			while (term.Next()) docs.Add(searcher.Doc(term.Doc));
			reader.Dispose();
			searcher.Dispose();
			return _mapLuceneToDataList(docs);
		}
        /// <summary>
        /// Search cho FrontEnd
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        private static FSDirectory _directoryFrontEnd
        {
            get
            {
                if (_directoryTemp == null) _directoryTemp = FSDirectory.Open(new DirectoryInfo(_lucaenDirFontEnd));
                if (IndexWriter.IsLocked(_directoryTemp)) IndexWriter.Unlock(_directoryTemp);
                var lockFilePath = Path.Combine(_lucaenDirFontEnd, "write.lock");
                if (File.Exists(lockFilePath)) File.Delete(lockFilePath);
                return _directoryTemp;
            }
        }

        // search methods
        public static IEnumerable<LuceneData_BO> GetAllIndexRecordsFrontEnd()
        {
            // validate search index
            if (!System.IO.Directory.EnumerateFiles(_lucaenDirFontEnd).Any()) return new List<LuceneData_BO>();

            // set up lucene searcher
            var searcher = new IndexSearcher(_directoryFrontEnd, false);
            var reader = IndexReader.Open(_directoryFrontEnd, false);
            var docs = new List<Document>();
            var term = reader.TermDocs();
            // v 2.9.4: use 'hit.Doc()'
            // v 3.0.3: use 'hit.Doc'
            while (term.Next()) docs.Add(searcher.Doc(term.Doc));
            reader.Dispose();
            searcher.Dispose();
            return _mapLuceneToDataList(docs);
        }
        public static IEnumerable<LuceneData_BO> SearchFrontEnd(string input, string fieldName = "")
        {
            if (string.IsNullOrEmpty(input)) return new List<LuceneData_BO>();

            var terms = input.Trim().Replace("-", " ").Split(' ')
                .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
            input = string.Join(" ", terms);

            return _searchFrontEnd(input, fieldName);
        }
        public static IEnumerable<LuceneData_BO> SearchDefaultFrontEnd(string input, string fieldName = "")
        {
            return string.IsNullOrEmpty(input) ? new List<LuceneData_BO>() : _searchFrontEnd(input, fieldName);
        }
        private static IEnumerable<LuceneData_BO> _searchFrontEnd(string searchQuery, string searchField = "")
        {
            // validation
            if (string.IsNullOrEmpty(searchQuery.Replace("*", "").Replace("?", ""))) return new List<LuceneData_BO>();

            // set up lucene searcher
            using (var searcher = new IndexSearcher(_directoryFrontEnd, false))
            {
                var hits_limit = 1000;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);

                // search by single field
                if (!string.IsNullOrEmpty(searchField))
                {
                    var parser = new QueryParser(Version.LUCENE_30, searchField, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    var hits = searcher.Search(query, hits_limit).ScoreDocs;
                    var results = _mapLuceneToDataList(hits, searcher);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
                // search by multiple fields (ordered by RELEVANCE)
                else
                {
                    var parser = new MultiFieldQueryParser
                        (Version.LUCENE_30, new[] { "Title", "Url", "Description" }, analyzer);
                    var query = parseQuery(searchQuery, parser);
                    searcher.SetDefaultFieldSortScoring(true, true);
                    var hits = searcher.Search(query, null, hits_limit, Sort.RELEVANCE).ScoreDocs;
                    var results = _mapLuceneToDataList(hits, searcher);
                    analyzer.Close();
                    searcher.Dispose();
                    return results;
                }
            }
        }
        /// <summary>
        /// Kết thúc phần cho FrontEnd
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static IEnumerable<LuceneData_BO> Search(string input, string fieldName = "")
        {
            if (string.IsNullOrEmpty(input)) return new List<LuceneData_BO>();
			
			var terms = input.Trim().Replace("-", " ").Split(' ')
				.Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
			input = string.Join(" ", terms);

			return _search(input, fieldName);
		}
        public static IEnumerable<LuceneData_BO> SearchDefault(string input, string fieldName = "")
        {
            return string.IsNullOrEmpty(input) ? new List<LuceneData_BO>() : _search(input, fieldName);
		}

		// main search method
        private static IEnumerable<LuceneData_BO> _search(string searchQuery, string searchField = "")
        {
			// validation
            if (string.IsNullOrEmpty(searchQuery.Replace("*", "").Replace("?", ""))) return new List<LuceneData_BO>();

			// set up lucene searcher
			using (var searcher = new IndexSearcher(_directory, false)) {
				var hits_limit = 1000;
				var analyzer = new StandardAnalyzer(Version.LUCENE_30);

				// search by single field
				if (!string.IsNullOrEmpty(searchField)) {
					var parser = new QueryParser(Version.LUCENE_30, searchField, analyzer);
					var query = parseQuery(searchQuery, parser);
					var hits = searcher.Search(query, hits_limit).ScoreDocs;
					var results = _mapLuceneToDataList(hits, searcher);
					analyzer.Close();
					searcher.Dispose();
					return results;
				}
				// search by multiple fields (ordered by RELEVANCE)
				else {
					var parser = new MultiFieldQueryParser
                        (Version.LUCENE_30, new[] {"Title", "Url", "Description" }, analyzer);
					var query = parseQuery(searchQuery, parser);
                    searcher.SetDefaultFieldSortScoring(true, true);
					var hits = searcher.Search(query, null, hits_limit, Sort.RELEVANCE).ScoreDocs;
					var results = _mapLuceneToDataList(hits, searcher);
					analyzer.Close();
					searcher.Dispose();
					return results;
				}
			}
		}
		private static Query parseQuery(string searchQuery, QueryParser parser) {
			Query query;
			try {
				query = parser.Parse(searchQuery.Trim());
			}
			catch (ParseException) {
				query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
			}
			return query;
		}

		// map Lucene search index to data
        private static IEnumerable<LuceneData_BO> _mapLuceneToDataList(IEnumerable<Document> hits)
        {
			return hits.Select(_mapLuceneDocumentToData).ToList();
		}
        private static IEnumerable<LuceneData_BO> _mapLuceneToDataList(IEnumerable<ScoreDoc> hits, IndexSearcher searcher)
        {
      // v 2.9.4: use 'hit.doc'
      // v 3.0.3: use 'hit.Doc'
			return hits.Select(hit => _mapLuceneDocumentToData(searcher.Doc(hit.Doc))).ToList();
		}
        private static LuceneData_BO _mapLuceneDocumentToData(Document doc)
        {
            return new LuceneData_BO
            {
                Id = Convert.ToInt32(doc.Get("Id")),
                Title = doc.Get("Title"),
                Url = doc.Get("Url"),
			    Description = doc.Get("Description"),
                AvatarUrl = doc.Get("AvatarUrl")
			};
		}

		// add/update/clear search index data 
        public static void AddUpdateLuceneIndex(LuceneData_BO luceneData)
        {
            AddUpdateLuceneIndex(new List<LuceneData_BO> { luceneData });
		}
        public static void AddUpdateLuceneIndex(IEnumerable<LuceneData_BO> luceneDatas)
        {
			// init lucene
			var analyzer = new StandardAnalyzer(Version.LUCENE_30);
			using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED)) {
				// add data to lucene search index (replaces older entries if any)
				foreach (var luceneData in luceneDatas) _addToLuceneIndex(luceneData, writer);

				// close handles
				analyzer.Close();
				writer.Dispose();
			}
		}
		public static void ClearLuceneIndexRecord(int record_id) {
			// init lucene
			var analyzer = new StandardAnalyzer(Version.LUCENE_30);
			using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED)) {
				// remove older index entry
				var searchQuery = new TermQuery(new Term("Id", record_id.ToString()));
				writer.DeleteDocuments(searchQuery);

				// close handles
				analyzer.Close();
				writer.Dispose();
			}
		}
		public static bool ClearLuceneIndex() {
			try {
				var analyzer = new StandardAnalyzer(Version.LUCENE_30);
				using (var writer = new IndexWriter(_directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED)) {
					// remove older index entries
					writer.DeleteAll();

					// close handles
					analyzer.Close();
					writer.Dispose();
				}
			}
			catch (Exception) {
				return false;
			}
			return true;
		}
		public static void Optimize() {
			var analyzer = new StandardAnalyzer(Version.LUCENE_30);
			using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED)) {
				analyzer.Close();
				writer.Optimize();
				writer.Dispose();
			}
		}
        private static void _addToLuceneIndex(LuceneData_BO luceneData, IndexWriter writer)
        {
			// remove older index entry
			var searchQuery = new TermQuery(new Term("Id", luceneData.Id.ToString()));
			writer.DeleteDocuments(searchQuery);

			// add new index entry
			var doc = new Document();

			// add lucene fields mapped to db fields
			doc.Add(new Field("Id", luceneData.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
			doc.Add(new Field("Title", luceneData.Title, Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("Url", luceneData.Url, Field.Store.YES, Field.Index.ANALYZED));
			doc.Add(new Field("Description", luceneData.Description, Field.Store.YES, Field.Index.ANALYZED));
            doc.Add(new Field("AvatarUrl", luceneData.AvatarUrl, Field.Store.YES, Field.Index.ANALYZED));

			// add entry to index
			writer.AddDocument(doc);
		}

       
	}
}