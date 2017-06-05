using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace CG
{
    public static class AsientoDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDEjercicio, Periodo, Asiento, Tipo, Fecha, FechaHora, Createdby, CreateDate, Mayorizadoby, MayorizadoDate, " +
                             "Concepto, Mayorizado, Anulado, TipoCambio, ModuloFuente, CuadreTemporal  FROM dbo.cntAsiento WHERE (Asiento = @Asiento or @Asiento='*')" ;
            
            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@Asiento", SqlDbType.NVarChar).SourceColumn = "Asiento";
                
                
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

        public static DataSet GetDataByAsiento(String Aseinto)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@Asiento"].Value = Aseinto;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static String InsertUpdateAsiento(String Operacion,String XML,String Asiento,String Tipo)
        {
            String sResult = "OK";
            String strSQL = "dbo.cntUpdateAsientoWithXML";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            try
            {
                oCmd.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oCmd.Parameters.Add("@XML", SqlDbType.Xml).Value = XML;
                oCmd.Parameters.Add("@Asiento", SqlDbType.NVarChar,20).Value = Asiento;
                oCmd.Parameters["@Asiento"].Direction = ParameterDirection.InputOutput;
                oCmd.Parameters.Add("@Tipo", SqlDbType.NChar).Value = Tipo;
                oCmd.CommandType = CommandType.StoredProcedure;

                
                 if (oCmd.Connection.State== ConnectionState.Closed)
                    oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();
                sResult = oCmd.Parameters["@Asiento"].Value.ToString();
                return sResult;

            } catch (Exception ex)
            {
                throw ex;
                
            }
            finally
            {
                if (oCmd.Connection.State == ConnectionState.Open)
                    oCmd.Connection.Close();
            }
    }



        public static DataSet GetDataByCriterio(DateTime FechaInicial,DateTime FechaFinal,String Tipo,int Mayorizado,int Anulado,String ModuloFuente, int CuadreTemporal)
        {
            String strSQL = "dbo.cntGetAsientoByCriterio";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            
            oCmd.Parameters.Add(new SqlParameter("@FechaInicial", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            oCmd.Parameters.Add(new SqlParameter("@Tipo", Tipo));
            oCmd.Parameters.Add(new SqlParameter("@Mayorizado", Mayorizado));
            oCmd.Parameters.Add(new SqlParameter("@ModuloFuente", ModuloFuente));
            oCmd.Parameters.Add(new SqlParameter("@Anulado", Anulado));
            oCmd.Parameters.Add(new SqlParameter("@CuadreTemporal", CuadreTemporal));
            oCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdap.Fill(DS.Tables["Data"]);
            return DS;
        }


        public static DataSet GetDataEmpty()
        {
            String strSQL = "SELECT IDEjercicio, Periodo, Asiento, Tipo, Fecha, FechaHora, Createdby, CreateDate, Mayorizadoby, MayorizadoDate, " +
                            "Concepto, Mayorizado, Anulado, TipoCambio, ModuloFuente, CuadreTemporal " +
                            "  FROM dbo.cntAsiento where 1=3";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static DataSet GetData(int IDCentro, String Nivel1, String Nivel2, String Nivel3, String Descr, int Acumulador)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDCentro"].Value = IDCentro;
            oAdaptador.SelectCommand.Parameters["@Nivel1"].Value = Nivel1;
            oAdaptador.SelectCommand.Parameters["@Nivel2"].Value = Nivel2;
            oAdaptador.SelectCommand.Parameters["@Nivel3"].Value = Nivel3;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            oAdaptador.SelectCommand.Parameters["@Acumulador"].Value = Acumulador;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }



    }
}
