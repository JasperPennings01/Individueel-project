using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DataAccesLayer
{
    public class DatabaseConnect
    {
        private static string Server { get; } = "mssqlstud.fhict.local";
        private static string DatabaseconnectName { get; } = "dbi509678_i509678db";
        private static string Username { get; } = "dbi509678_i509678db";
        private static string Password { get; } = "Guusje_01!";

        public static SqlConnection conn = new SqlConnection("Server=" + Server + ";Database=" + DatabaseconnectName + ";User Id=" + Username + ";Password=" + Password);

        public static void Open()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public static void Close()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
}
