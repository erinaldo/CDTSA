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
                             "Concepto, Mayorizado, Anulado, TipoCambio, ModuloFuente, CuadreTemporal  FROM dbo.cntAsiento WHERE (Asiento = @Asiento or @Asiento='*'" ;
            String InsertSQL = "[dbo].[cntUpdateAsientoWithXML]";
            String UpdateSQL = "[dbo].[cntUpdateAsientoWithXML]";
            String DeleteSQL = "[dbo].[cntUpdateAsientoWithXML]";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    InsertCommand = new SqlCommand(InsertSQL, ConnectionManager.GetConnection()),
                    UpdateCommand = new SqlCommand(UpdateSQL, ConnectionManager.GetConnection()),
                    DeleteCommand = new SqlCommand(DeleteSQL, ConnectionManager.GetConnection())
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@Asiento", SqlDbType.NVarChar).SourceColumn = "Asiento";
                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@XML", SqlDbType.Xml);
                oAdaptador.InsertCommand.Parameters.Add("@Asiento", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.InsertCommand.Parameters.Add("@Tipo", SqlDbType.NChar).SourceColumn = "Nivel2";
                

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@XML", SqlDbType.Xml);
                oAdaptador.UpdateCommand.Parameters.Add("@Asiento", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.NChar).SourceColumn = "Nivel2";



                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.UpdateCommand.Parameters.Add("@XML", SqlDbType.Xml);
                oAdaptador.UpdateCommand.Parameters.Add("@Asiento", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.NChar).SourceColumn = "Nivel2";

                return oAdaptador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void SetTransactionToAdaptador(bool Activo)
        {
            oAdaptador.UpdateCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.DeleteCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.InsertCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
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


        public static DataSet GetDataByCriterio(DateTime FechaInicial,DateTime FechaFinal,String Tipo,int Mayorizado,int Anulado,String ModuloFuente, int CuadreTemporal)
        {
            String strSQL = "SELECT IDEjercicio, Periodo, Asiento, Tipo, Fecha, FechaHora, Createdby, CreateDate, Mayorizadoby, MayorizadoDate, " +
                            "Concepto, Mayorizado, Anulado, TipoCambio, ModuloFuente, CuadreTemporal " +
                            "  FROM dbo.cntAsiento WHERE Fecha BETWEEN @FechaInicial AND @FechaFinal  AND (Tipo = @Tipo OR @Tipo	='*') " +
                            "AND(Mayorizado = @Mayorizado OR @Mayorizado = -1) AND(Anulado = @Anulado OR @Anulado = -1) AND(ModuloFuente = @ModuloFuente OR @ModuloFuente = '*') " +
                            "AND(CuadreTemporal = @CuadreTemporal OR @CuadreTemporal = -1)";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            oCmd.Parameters.Add(new SqlParameter("@FechaInicial", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            oCmd.Parameters.Add(new SqlParameter("@Tipo", Tipo));
            oCmd.Parameters.Add(new SqlParameter("@Mayorizado", Mayorizado));
            oCmd.Parameters.Add(new SqlParameter("@Anulado", Anulado));
            oCmd.Parameters.Add(new SqlParameter("@CuadreTemporal", CuadreTemporal));

            SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdaptador.Fill(DS.Tables["Data"]);
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
