using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace DataAccessObjects
{
    public class DBHelper : IDisposable
    {
        private static SqlConnection _SQLConnection;
        public static string appp = Directory.GetCurrentDirectory();
        public static SqlConnection SQLConnection
        {
            get
            {
                return _SQLConnection ?? InitializeConnectionString();
            }
            set
            {
                _SQLConnection = value;
            }
        }

        public void Dispose()
        {
            if (SQLConnection != null && SQLConnection.State == System.Data.ConnectionState.Open)
            {
                SQLConnection.Close();
                SQLConnection = null;
            }
        }

        public static SqlConnection InitializeConnectionString()
        {
            //   return new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BackEnd;Integrated Security=False; User ID = leo; Password=pass");
            return new SqlConnection(@"Data Source=.\LAWSONINSTANCE; Initial Catalog=Voting; Integrated Security=True");
            //   return new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename =" + AppDomain.CurrentDomain.BaseDirectory + "BackEnd.mdf; Integrated Security = True;Connection Timeout=30; User Instance=True");
        }
    }
}