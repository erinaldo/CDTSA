﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CDTSA
{
    internal sealed class ConnectionManager
    {
        public static SqlTransaction Tran;
        private static SqlConnection oConn;

        public static SqlConnection GetConnection()
        {
            if (oConn == null)
            {
                String ConnectionString = ConfigurationManager.ConnectionStrings["StringConexion"].ConnectionString;
                oConn = new SqlConnection(ConnectionString);
            }
            //connection.Open();
            return oConn;
        }

        public static void BeginTran()
        {

            if (oConn.State == System.Data.ConnectionState.Closed)
                oConn.Open();
            Tran = oConn.BeginTransaction();
        }

        public static void CommitTran()
        {
            Tran.Commit();
            Tran = null;
        }

        public static void RollBackTran()
        {
            if (Tran != null)
                Tran.Rollback();
            if (oConn.State == System.Data.ConnectionState.Open)
                oConn.Close();
            Tran = null;
        }
    }
}
