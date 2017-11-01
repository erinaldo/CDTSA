using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace ControlBancario.DAC
{
    public static class CuentaBancariaDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();
        
        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT  A.IDCuentaBanco ,A.Codigo ,A.Descr ,A.IDBanco ,B.Descr DescrBanco,A.IDMoneda ,M.Descr DescrMoneda,A.SaldoInicial ,A.FechaCreacion ,A.IDTipo,C.Descr DescrTipo ,A.SaldoLibro ,A.SaldoBanco ,A.UltDeposito ,A.UltCheque , "  +
                            "A.UltTransferencia ,A.Limite ,A.Sobregiro ,A.IDCuenta ,A.Activa " +
                            "FROM dbo.cbCuentaBancaria A " +
                            "INNER JOIN dbo.cbBanco B ON a.IDBanco=B.IDBanco " +
                            "INNER JOIN dbo.cbTipoCuenta C ON A.IDTipo=C.IDTipo " +
                            "INNER JOIN dbo.globalMoneda M ON A.IDMoneda=M.IDMoneda " +
                            "WHERE (IDCuenta=@IDCuenta or @IDCuenta=-1) AND (IDBanco=@IDBanco or @IDBanco=-1)";
            String InsertSQL = "[dbo].[cbUpdateCuentaBancaria]";
            String UpdateSQL = "[dbo].[cbUpdateCuentaBancaria]";
            String DeleteSQL = "[dbo].[cbUpdateCuentaBancaria]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.SelectCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";
                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.InsertCommand.Parameters.Add("@Codigo", SqlDbType.NChar).SourceColumn = "Codigo";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";
                oAdaptador.InsertCommand.Parameters.Add("@IDMoneda", SqlDbType.Int).SourceColumn = "IDMoneda";
                oAdaptador.InsertCommand.Parameters.Add("@SaldoInicial", SqlDbType.Decimal).SourceColumn = "SaldoInicial";
                oAdaptador.InsertCommand.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).SourceColumn = "FechaCreacion";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.InsertCommand.Parameters.Add("@Limite", SqlDbType.Decimal).SourceColumn = "Limite";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuenta", SqlDbType.Int ).SourceColumn = "IDCuenta";
                oAdaptador.InsertCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.UpdateCommand.Parameters.Add("@Codigo", SqlDbType.NChar).SourceColumn = "Codigo";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";
                oAdaptador.UpdateCommand.Parameters.Add("@IDMoneda", SqlDbType.Int).SourceColumn = "IDMoneda";
                oAdaptador.UpdateCommand.Parameters.Add("@SaldoInicial", SqlDbType.Decimal).SourceColumn = "SaldoInicial";
                oAdaptador.UpdateCommand.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).SourceColumn = "FechaCreacion";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@Limite", SqlDbType.Decimal).SourceColumn = "Limite";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuenta", SqlDbType.Int ).SourceColumn = "IDCuenta";
                oAdaptador.UpdateCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";
 


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.DeleteCommand.Parameters.Add("@Codigo", SqlDbType.NChar).SourceColumn = "Codigo";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";
                oAdaptador.DeleteCommand.Parameters.Add("@IDMoneda", SqlDbType.Int).SourceColumn = "IDMoneda";
                oAdaptador.DeleteCommand.Parameters.Add("@SaldoInicial", SqlDbType.Decimal).SourceColumn = "SaldoInicial";
                oAdaptador.DeleteCommand.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).SourceColumn = "FechaCreacion";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@Limite", SqlDbType.Decimal).SourceColumn = "Limite";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuenta", SqlDbType.Int ).SourceColumn = "IDCuenta";
                oAdaptador.DeleteCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";

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

        public static DataSet GetData(int IDCuenta, int IDBanco)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDCuenta"].Value = IDCuenta;
            oAdaptador.SelectCommand.Parameters["@IDBanco"].Value = IDBanco;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }



       
    }
}
