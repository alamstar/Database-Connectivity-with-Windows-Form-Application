﻿using System;
using System.Data.SqlClient;

namespace DbConnection
{
    class Connect
    {
        SqlConnection conn;

        public Connect()
        {
            conn = new SqlConnection("Data Source=ALAMSTAR-PC; Initial Catalog=DbConnection_1; Integrated Security=True");
        }

        public SqlConnection OpenConn()
        {
            try
            {
                conn.Open();
            }
            catch(Exception)
            {

            }
            return conn;
        }

        public void CloseConn()
        {
            try
            {
                conn.Close();
            }
            catch(Exception)
            {

            }
        }
    }
}
