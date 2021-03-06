﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CG
{
    public static class PeriodoContableDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDEjercicio, Periodo, FechaFinal, Descr, FinPeriodoFiscal, Cerrado, AjustesCierreFiscal, Activo, PeriodoTrabajo " +
                            "FROM dbo.cntPeriodoContable WHERE (IDEjercicio = @IDEjercicio OR @IDEjercicio = -1) AND(Periodo = @Periodo OR @Periodo = '*')";
            

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@IDEjercicio", SqlDbType.Int).SourceColumn = "IDEjercicio";
                oAdaptador.SelectCommand.Parameters.Add("@Periodo", SqlDbType.NChar).SourceColumn = "Periodo";
                


                
                return oAdaptador;
            }
            catch (Exception)
            {
                throw;
            }
        }



        
        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData(int IDEjercicio, String Periodo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDEjercicio"].Value = IDEjercicio;
            oAdaptador.SelectCommand.Parameters["@Periodo"].Value = Periodo;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


        public static bool SetPeriodoTrabajoActivo(int IdEjercicio, String Periodo)
        {
            String strSQL = "UPDATE dbo.cntPeriodoContable SET PeriodoTrabajo=~PeriodoTrabajo WHERE Periodo=@Periodo AND IDEjercicio=@IdEjercicio";
            
            bool Exito = false;
            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            try
            {


                oCmd.Parameters.Add(new SqlParameter("@IDEjercicio", IdEjercicio));
                oCmd.Parameters.Add(new SqlParameter("@Periodo", Periodo));
                
                oCmd.CommandType = CommandType.Text;
                oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();

                Exito = true;
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                if (oCmd.Connection.State == ConnectionState.Open)
                    oCmd.Connection.Close();
            }
            return Exito;
        }


        public static bool CierraPeriodoContable(int IDEjercicio,String Periodo)
        {
            bool bResult = false;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntCierraPeriodoContable", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@IDEjercicio", SqlDbType.Int).Value = IDEjercicio;
                oCmd.Parameters.Add("@Periodo", SqlDbType.NVarChar).Value = Periodo;
                oCmd.Parameters.Add("@Error", SqlDbType.Bit).Value = Periodo;
                oCmd.Parameters["@Error"].Direction = ParameterDirection.Output;


                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();
                bResult = true;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return bResult;

        }

        public static DataTable GetPeriodoContableACerrar()
        {

            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntGetPeriodoContableACerrar", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter oAdapatadorTmp = new SqlDataAdapter(oCmd);
                oAdapatadorTmp.Fill(DS, "Data");


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return DS.Tables[0];

        }


        public static DataSet GetPeriodoContableByFecha(DateTime Fecha)
        {
            
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntGetPeriodoContableByFecha", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@Fecha", SqlDbType.Date, 50).Value = Fecha;
                SqlDataAdapter oAdapatadorTmp = new SqlDataAdapter(oCmd);
                oAdapatadorTmp.Fill(DS,"Data");


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return DS;

        }


         public static bool ValidaFechaInPeriodoContable(DateTime Fecha)
        {
            bool bResult  = false;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntValidaFechaInPeriodoContables", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@Fecha", SqlDbType.Date, 50).Value = Fecha;
                
             
                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();
                bResult = true;
              
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return bResult;

        }

        

    }
}
