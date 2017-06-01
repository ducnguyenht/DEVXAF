using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Data.SqlClient;
using NASDMS.RDS;
using System.Collections.Generic;
using System.Linq;
public class People {

    private static String _connectionString;
    private static Boolean _initialized;

    //public static void Initialize() {
    //    // Initialize data source. Use "Northwind" connection string from configuration.

    //    if (ConfigurationManager.ConnectionStrings["AdventureWorksConnectionString"] == null ||
    //        ConfigurationManager.ConnectionStrings["AdventureWorksConnectionString"].ConnectionString.Trim() == "") {
    //        throw new Exception("A connection string named 'AdventureWorksConnectionString' with a valid connection string " +
    //                            "must exist in the <connectionStrings> configuration section for the application.");
    //    }

    //    _connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksConnectionString"].ConnectionString;

    //    _initialized = true;
    //}
    public static int TotalRows { get; set; }
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static List<AuditTrail> GetPeople(Int32 startRecord, Int32 maxRecords, String sortColumns)
    {
        VerifySortColumns(sortColumns);
       int TotalRow = 0;

        var db = NASDMSContext.AuditTrails.All(); ;
        //var data =  db.AuditTrails.All();//.Paged(out TotalRow, null, null, startRecord, maxRecords, null);
     
        var data = NASDMSContext.AuditTrails.Paged(out TotalRow, null, "ChangedOn DESC", startRecord, maxRecords, null).ToList();
        TotalRows = TotalRow;
        var sadfwe = 34534;
        //String sqlColumns = "[ContactID], [FirstName], [LastName], [EmailAddress], [Phone]";
        //String sqlTable = "[Person].[Contact]";
        //String sqlSortColumn = "[ContactID]";

        //if (!String.IsNullOrEmpty(sortColumns))         
        //    sqlSortColumn = sortColumns;

        //String sqlCommand = String.Format(
        //   "SELECT * FROM (" +
        //   "    SELECT ROW_NUMBER() OVER (ORDER BY {0}) AS rownumber," +
        //   "        {1}" +
        //   "    FROM {2}" +
        //   ") AS foo " +
        //   "WHERE rownumber >= {3} AND rownumber <= {4}",
        //   sqlSortColumn,
        //   sqlColumns,
        //   sqlTable,
        //   startRecord + 1, startRecord + maxRecords
        //);

        //SqlConnection conn = new SqlConnection(_connectionString);
        //SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);

        //DataSet ds = new DataSet();

        //try {
        //    conn.Open();
        //    da.Fill(ds, "People");
        //}
        //catch (SqlException e) {
        //    // Handle exception.
        //}
        //finally {
        //    conn.Close();
        //}

        //if (ds.Tables["People"] != null)
        //    return ds.Tables["People"];

        return data;
    }


    // columns are specified in the sort expression to avoid a SQL Injection attack.

    private static void VerifySortColumns(string sortColumns) {
        sortColumns = sortColumns.ToLowerInvariant().Replace(" asc", String.Empty).Replace(" desc", String.Empty);
        String[] columnNames = sortColumns.Split(',');

        foreach (String columnName in columnNames) {

            switch (columnName.Trim().ToLowerInvariant()) {
                case "contactid":
                case "firstname":
                case "lastname":
                case "emailaddress":
                case "phone":
                case "":
                    break;
                default:
                    throw new ArgumentException("SortColumns contains an invalid column name.");
            }
        }
    }

    public static Int32 GetPeopleCount() {

        //string sqlCommand = "SELECT COUNT ([ContactID]) FROM [Person].[Contact]";

        //SqlConnection conn = new SqlConnection(_connectionString);
        //SqlCommand command = new SqlCommand(sqlCommand, conn);
        //SqlDataAdapter da = new SqlDataAdapter(sqlCommand, conn);

        //Int32 result = 0;

        //try {
        //    conn.Open();
        //    result = (Int32)command.ExecuteScalar();
        //}
        //catch (SqlException e) {
        //    // Handle exception.
        //}
        //finally {
        //    conn.Close();
        //}

        return TotalRows;
    }
}
