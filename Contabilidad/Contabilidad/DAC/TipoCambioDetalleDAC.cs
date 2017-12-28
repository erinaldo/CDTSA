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
    public static class TipoCambioDetalleDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDTipoCambio,Fecha,Monto FROM dbo.globalTipoCambioDetalle WHERE (IDTipoCambio=@IDTipoCambio OR @IDTipoCambio='*') AND (Fecha = @Fecha OR @Fecha IS NULL)";
            String InsertSQL = "[dbo].[globalUpdateTipoCambioDetalle]";
            String UpdateSQL = "[dbo].[globalUpdateTipoCambioDetalle]";
            String DeleteSQL = "[dbo].[globalUpdateTipoCambioDetalle]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.SelectCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.InsertCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.InsertCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.UpdateCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.UpdateCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipoCambio", SqlDbType.NVarChar).SourceColumn = "IDTipoCambio";
                oAdaptador.DeleteCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.DeleteCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";
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
            oAdaptador.DeleteCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.InsertCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
        }

        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData(String IDTipoCambio,DateTime Fecha)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTipoCambio"].Value = IDTipoCambio;
            oAdaptador.SelectCommand.Parameters["@Fecha"].Value = Fecha;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static DataSet GetDetalleTipoCambioByID(String TipoCambio,DateTime FechaInicial,DateTime FechaFinal)
        {
            String strSQL = "SELECT *  FROM dbo.globalTipoCambioDetalle WHERE (IDTipoCambio=@IDTipoCambio or @IDTipoCambio='*') and Fecha  between @FechaInicial and @FechaFinal";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDTipoCambio", TipoCambio));
            oCmd.Parameters.Add(new SqlParameter("@FechaInicial", FechaInicial));
            oCmd.Parameters.Add(new SqlParameter("@FechaFinal", FechaFinal));
            

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdap.Fill(DS.Tables["Data"]);

            
            return DS;
        }


        public static DateTime GetNetFechaByIDTipoCambio(String TipoCambio)
        {
            DateTime Fecha = DateTime.Now;
            String strSQL = "SELECT DATEADD(DAY,1, MAX(Fecha)) NextFecha FROM dbo.globalTipoCambioDetalle WHERE IDTipoCambio=@IDTipoCambio";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@IDTipoCambio", TipoCambio));
            

            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdap.Fill(DS.Tables["Data"]);

            if (DS.Tables.Count > 0) {
                if (DS.Tables[0].Rows.Count > 0)
                    if (DS.Tables[0].Rows[0]["NextFecha"].ToString() != "")
                        Fecha = Convert.ToDateTime(DS.Tables[0].Rows[0]["NextFecha"]);
                    else
                        Fecha = DateTime.Now;
            }

            return Fecha;
        }


        public static Double GetLastTipoCambioFecha(DateTime Fecha)
        {
            double TC = 0;
            String strSQL = " select isnull([dbo].[globalGetTipoCambio](@Fecha),0) Monto"; 
                
                //"DECLARE @FechaMax AS DATE " +
                //            "SET @FechaMax = (SELECT MAX(Fecha)  FROM dbo.cntSaldo) " +
                //            "IF (@Fecha>@FechaMax) " +
                //            "    SET @Fecha = @FechaMax " +
                //            "SELECT Monto  FROM dbo.globalTipoCambioDetalle WHERE Fecha=DATEADD(D,-1,DATEADD(mm, DATEDIFF(m,0,@Fecha)+1,0)) AND IDTipoCambio='TVEN'";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());

            oCmd.Parameters.Add(new SqlParameter("@Fecha", Fecha));


            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdap.Fill(DS.Tables["Data"]);

            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                    TC = Convert.ToDouble(DS.Tables[0].Rows[0]["Monto"]);
            }

            return TC;
        }

        

    }

}
