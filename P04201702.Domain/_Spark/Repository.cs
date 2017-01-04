	
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;

namespace P04201702.Domain
{
    // ############################################################################
    // #
    // #        ---==>  T H I S  F I L E  W A S  G E N E R A T E D  <==---
    // #
    // # This file was generated by the CodeGen Prototype
    // # Generated on 1/4/2017 9:54:21 AM
    // #
    // # Edits to this file may cause incorrect behavior and will be lost
    // # if the code is regenerated.
    // #
    // ############################################################################
	
	// P04201702 Context. hosts all repositories

	public static class P04201702Context
	{
		static Db db = new P04201702Db();
		
		// entity specific repositories

        public static Documentations Documentations { get { return new Documentations(); } }

		// general purpose operations

		public static void Execute(string sql, params object[] parms) { db.Execute( sql, parms ); }
		public static IEnumerable<dynamic> Query(string sql, params object[] parms) { return db.Query( sql, parms ); }
		public static object Scalar(string sql, params object[] parms) { return db.Scalar( sql, parms ); }

		public static DataSet GetDataSet(string sql, params object[] parms) { return db.GetDataSet( sql, parms ); }
		public static DataTable GetDataTable(string sql, params object[] parms) { return db.GetDataTable( sql, parms ); }
		public static DataRow GetDataRow(string sql, params object[] parms) { return db.GetDataRow( sql, parms ); }
	}
}