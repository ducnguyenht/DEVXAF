using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestEntityWithMysql;

namespace TestEntityWithMysql.Controllers
{
    public class ApiHistoryController : ApiController
    {
        private DucTestMySqlEntities db = new DucTestMySqlEntities();

        // GET: api/ApiHistory
        public IQueryable<tb_History> Gettb_History()
        {
            return db.tb_History;
        }

        // GET: api/ApiHistory/5
        [ResponseType(typeof(tb_History))]
        public IHttpActionResult Gettb_History(int id)
        {
            tb_History tb_History = db.tb_History.Find(id);
            if (tb_History == null)
            {
                return NotFound();
            }

            return Ok(tb_History);
        }

        // PUT: api/ApiHistory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_History(int id, tb_History tb_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_History.Id)
            {
                return BadRequest();
            }

            db.Entry(tb_History).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_HistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiHistory
        [ResponseType(typeof(tb_History))]
        public IHttpActionResult Posttb_History(tb_History tb_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tb_History.Add(tb_History);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_History.Id }, tb_History);
        }

        // DELETE: api/ApiHistory/5
        [ResponseType(typeof(tb_History))]
        public IHttpActionResult Deletetb_History(int id)
        {
            tb_History tb_History = db.tb_History.Find(id);
            if (tb_History == null)
            {
                return NotFound();
            }

            db.tb_History.Remove(tb_History);
            db.SaveChanges();

            return Ok(tb_History);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_HistoryExists(int id)
        {
            return db.tb_History.Count(e => e.Id == id) > 0;
        }
    }
}