using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CG
{
    public static class ParametrosContabilidadDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT TOP 1 ID,UsaSeparadorCta,SeparadorCta,UsaPredecesor,charPredecesor,CantCharNivel1,CantCharNivel2,CantCharNivel3, " +
                            "CantCharNivel4,CantCharNivel5,CantCharNivel6,IDCtaUtilidadPeriodo,IDCtaUtilidadAcumulada,MesInicioPeriodoFiscal, " +
			                "MesFinalPeriodoFiscal,UsaSeparadorCentro,SeparadorCentro,UsaPredecesorCentro,charPredecesorCentro,LongAsiento " +
                            "FROM dbo.cntParametros";
            String InsertSQL = "[dbo].[cntUpdateParametrosContabilidad]";
            String UpdateSQL = "[dbo].[cntUpdateParametrosContabilidad]";


            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    InsertCommand = new SqlCommand(InsertSQL, ConnectionManager.GetConnection()),
                    UpdateCommand = new SqlCommand(UpdateSQL, ConnectionManager.GetConnection())
                };

          
                
                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@ID", SqlDbType.Int).SourceColumn = "ID";
                oAdaptador.InsertCommand.Parameters.Add("@UsaSeparadorCuenta", SqlDbType.Int).SourceColumn = "UsaSeparadorCta";
                oAdaptador.InsertCommand.Parameters.Add("@SeparadorCta", SqlDbType.NVarChar).SourceColumn = "SeparadorCta";
                oAdaptador.InsertCommand.Parameters.Add("@UsaPredecesor", SqlDbType.Int).SourceColumn = "UsaPredecesor";
                oAdaptador.InsertCommand.Parameters.Add("@charPredecesor", SqlDbType.NVarChar).SourceColumn = "charPredecesor";
                oAdaptador.InsertCommand.Parameters.Add("@CantCharNivel1", SqlDbType.NVarChar).SourceColumn = "CantCharNivel1";
                oAdaptador.InsertCommand.Parameters.Add("@CantCharNivel2", SqlDbType.NVarChar).SourceColumn = "CantCharNivel2";
                oAdaptador.InsertCommand.Parameters.Add("@CantCharNivel3", SqlDbType.NVarChar).SourceColumn = "CantCharNivel3";
                oAdaptador.InsertCommand.Parameters.Add("@CantCharNivel4", SqlDbType.NVarChar).SourceColumn = "CantCharNivel4";
                oAdaptador.InsertCommand.Parameters.Add("@CantCharNivel5", SqlDbType.NVarChar).SourceColumn = "CantCharNivel5";
                oAdaptador.InsertCommand.Parameters.Add("@CantCharNivel6", SqlDbType.NVarChar).SourceColumn = "CantCharNivel6";
                oAdaptador.InsertCommand.Parameters.Add("@IDCtaUtilidadAcumulada", SqlDbType.BigInt).SourceColumn = "IDCtaUtilidadAcumulada";
                oAdaptador.InsertCommand.Parameters.Add("@IDCtaUtilidadPeriodo", SqlDbType.BigInt).SourceColumn = "IDCtaUtilidadPeriodo";
                oAdaptador.InsertCommand.Parameters.Add("@MesInicioPeriodoFiscal", SqlDbType.Int).SourceColumn = "MesInicioPeriodoFiscal";
                oAdaptador.InsertCommand.Parameters.Add("@MesFinalPeriodoFiscal", SqlDbType.Int).SourceColumn = "MesFinalPeriodoFiscal";
                oAdaptador.InsertCommand.Parameters.Add("@UsaSeparadorCentro", SqlDbType.Int).SourceColumn = "UsaSeparadorCentro";
                oAdaptador.InsertCommand.Parameters.Add("@SeparadorCentro", SqlDbType.NVarChar).SourceColumn = "SeparadorCentro";
                oAdaptador.InsertCommand.Parameters.Add("@UsaPredecesorCentro", SqlDbType.Int).SourceColumn = "UsaPredecesorCentro";
                oAdaptador.InsertCommand.Parameters.Add("@charPredecesorCentro", SqlDbType.NVarChar).SourceColumn = "charPredecesorCentro";
                oAdaptador.InsertCommand.Parameters.Add("@LongAsiento", SqlDbType.Int).SourceColumn = "LongAsiento";
     

                //Paremetros Delete 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@ID", SqlDbType.Int).SourceColumn = "ID";
                oAdaptador.UpdateCommand.Parameters.Add("@UsaSeparadorCuenta", SqlDbType.Int).SourceColumn = "UsaSeparadorCta";
                oAdaptador.UpdateCommand.Parameters.Add("@SeparadorCta", SqlDbType.NVarChar).SourceColumn = "SeparadorCta";
                oAdaptador.UpdateCommand.Parameters.Add("@UsaPredecesor", SqlDbType.Int).SourceColumn = "UsaPredecesor";
                oAdaptador.UpdateCommand.Parameters.Add("@charPredecesor", SqlDbType.NVarChar).SourceColumn = "charPredecesor";
                oAdaptador.UpdateCommand.Parameters.Add("@CantCharNivel1", SqlDbType.NVarChar).SourceColumn = "CantCharNivel1";
                oAdaptador.UpdateCommand.Parameters.Add("@CantCharNivel2", SqlDbType.NVarChar).SourceColumn = "CantCharNivel2";
                oAdaptador.UpdateCommand.Parameters.Add("@CantCharNivel3", SqlDbType.NVarChar).SourceColumn = "CantCharNivel3";
                oAdaptador.UpdateCommand.Parameters.Add("@CantCharNivel4", SqlDbType.NVarChar).SourceColumn = "CantCharNivel4";
                oAdaptador.UpdateCommand.Parameters.Add("@CantCharNivel5", SqlDbType.NVarChar).SourceColumn = "CantCharNivel5";
                oAdaptador.UpdateCommand.Parameters.Add("@CantCharNivel6", SqlDbType.NVarChar).SourceColumn = "CantCharNivel6";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCtaUtilidadAcumulada", SqlDbType.BigInt).SourceColumn = "IDCtaUtilidadAcumulada";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCtaUtilidadPeriodo", SqlDbType.BigInt).SourceColumn = "IDCtaUtilidadPeriodo";
                oAdaptador.UpdateCommand.Parameters.Add("@MesInicioPeriodoFiscal", SqlDbType.Int).SourceColumn = "MesInicioPeriodoFiscal";
                oAdaptador.UpdateCommand.Parameters.Add("@MesFinalPeriodoFiscal", SqlDbType.Int).SourceColumn = "MesFinalPeriodoFiscal";
                oAdaptador.UpdateCommand.Parameters.Add("@UsaSeparadorCentro", SqlDbType.Int).SourceColumn = "UsaSeparadorCentro";
                oAdaptador.UpdateCommand.Parameters.Add("@SeparadorCentro", SqlDbType.NVarChar).SourceColumn = "SeparadorCentro";
                oAdaptador.UpdateCommand.Parameters.Add("@UsaPredecesorCentro", SqlDbType.Int).SourceColumn = "UsaPredecesorCentro";
                oAdaptador.UpdateCommand.Parameters.Add("@charPredecesorCentro", SqlDbType.NVarChar).SourceColumn = "charPredecesorCentro";
                oAdaptador.UpdateCommand.Parameters.Add("@LongAsiento", SqlDbType.Int).SourceColumn = "LongAsiento";


                return oAdaptador;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static void SetTransactionToAdaptador(bool Activo)
        {
            oAdaptador.UpdateCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.InsertCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
        }

        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData()
        {
            DataSet DS = CreateDataSet();
           
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        

        public static DataSet GetMonedasFuncionales()
        {
            DataSet ds = CreateDataSet();
            String GetDatosGeneralesSQL = "SELECT SimboloMonedaFuncional,SimboloMonedaExtrangera,CantDigitosDecimales  FROM dbo.globalCompania";

            SqlCommand ocmd = new SqlCommand(GetDatosGeneralesSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdap = new SqlDataAdapter(ocmd);
            oAdap.Fill(ds, "Data");
            return ds;

        }


        public static String GetTipoCambioModulo()
        {
            DataSet ds = CreateDataSet();
            String GetDatosGeneralesSQL = "SELECT TipoCambio  FROM dbo.globalCompania";

            SqlCommand ocmd = new SqlCommand(GetDatosGeneralesSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdap = new SqlDataAdapter(ocmd);
            oAdap.Fill(ds, "Data");
            return ds.Tables[0].Rows[0]["TipoCambio"].ToString();

        }


    }
}
