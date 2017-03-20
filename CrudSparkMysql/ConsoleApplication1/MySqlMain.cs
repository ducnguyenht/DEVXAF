using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MySqlMain
    {
        public static MySqlConnection OpenConnection()
        {
            string server = "50.62.209.77";
            string database = "DucTestMySql";
            string user = "DucTestMySql";
            string pass = "123456";
            //     50.62.209.77;User Id=DucTestMySql;
            //password=123456;database=DucTestMySq
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" +
                                       user + ";" + "PASSWORD=" + pass + ";";
            string strConnString = ConfigurationManager.ConnectionStrings["AuditTrailRDS"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(strConnString);

            return connection;
        }
    }
}
