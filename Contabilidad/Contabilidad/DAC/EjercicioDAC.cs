using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{

    public static class EjercicioDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDEjercicio,Descr,FechaInicio,FechaFin,Activo,InicioOperaciones,MesInicioOperaciones,Cerrado FROM dbo.cntEjercicio WHERE (IDEjercicio=@IDEjercicio OR @IDEjercicio=-1)";
                            
            
            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),

                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@IDEjercicio", SqlDbType.Int).SourceColumn = "IDEjercicio";
                
                return oAdaptador;
            }
            catch (Exception ex)
            {
                throw ex;
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

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }



        public static bool CreaEjercicio(DateTime FechaInicio, bool InicioOperaciones , int MesInicioOperaciones)
        {
            bool result  = false;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntCreaEjercicio", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {
     
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@FechaInicio", SqlDbType.DateTime, 50).Value = FechaInicio;
                oCmd.Parameters.Add("@InicioOperaciones", SqlDbType.Bit, 50).Value = InicioOperaciones;
                oCmd.Parameters.Add("@MesInicioOperaciones", SqlDbType.Int, 50).Value = MesInicioOperaciones;
                
                SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);

                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                 oCmd.ExecuteNonQuery();
                result = true;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return result;

        }


        public static int GetNextConsecutivo()
        {
            int result = -1;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("SELECT isnull(MAX(IDEjercicio),-1) ID FROM dbo.cntEjercicio", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {

                oCmd.CommandType = CommandType.StoredProcedure;
                
                SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);

                oAdaptador.Fill(DS, "Data");
                result = Convert.ToInt32(DS.Tables["Data"].Rows[0]["ID"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return result;

        }


        public static DataSet GetEjercicioActivo()
        {
            DataSet DS = new DataSet();
            SqlCommand oCmd = new SqlCommand("SELECT A.IDEjercicio,A.Descr DescrEjercicio,Periodo,b.Descr DescrPeriodo   FROM dbo.cntEjercicio A "+
                                                "INNER JOIN dbo.cntPeriodoContable B ON A.IDEjercicio = B.IDEjercicio " +
                                                "WHERE A.Activo = 1 AND B.Activo = 1 AND B.PeriodoTrabajo = 1 AND B.Cerrado = 0 ", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {
                
                SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);
                oAdaptador.Fill(DS, "Data");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return DS;

        }




    }
}
