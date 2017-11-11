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
    public static class MovimientosDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT  M.IDCuentaBanco ,M.Fecha ,M.IDTipo ,M.IDSubTipo ,M.Numero ,M.Pagadero_a ,M.Monto ,M.Asiento ,M.Anulado ,M.AsientoAnulacion ,M.Usuario ,M.UsuarioAnulacion ,M.FechaAnulacion ,M.Referencia ,M.ConceptoContable  " +
                            "FROM dbo.cbMovimientos M " +
                            "INNER JOIN dbo.cbCuentaBancaria CB ON M.IDCuentaBanco = CB.IDCuentaBanco " +
                            "INNER JOIN dbo.cbTipoCuenta T ON CB.IDTipo = T.IDTipo " +
                            "INNER JOIN dbo.cbSubTipoDocumento ST ON M.IDTipo=ST.IDTipo AND M.IDSubTipo=ST.IDSubtipo " +
                            "WHERE (CB.IDCuentaBanco=@IDCuentaBanco OR @IDCuentaBanco=-1)  AND (CB.IDTipo=@IDTipo OR @IDTipo=-1) " +
                            "AND (IDSubTipo=@IDSubTipo OR @IDSubTipo=-1) AND (Numero = @Numero OR @Numero='*')";
            String InsertSQL = "[dbo].[cbUpdateMovimientos]";
            String UpdateSQL = "[dbo].[cbUpdateMovimientos]";
            String DeleteSQL = "[dbo].[cbUpdateMovimientos]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.SelectCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubTipo";
                oAdaptador.SelectCommand.Parameters.Add("@Numero", SqlDbType.NChar).SourceColumn = "Numero";

                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.InsertCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.InsertCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubTipo";
                oAdaptador.InsertCommand.Parameters.Add("@Numero", SqlDbType.NChar).SourceColumn = "Numero";
                oAdaptador.InsertCommand.Parameters.Add("@Pagaderoa", SqlDbType.NChar).SourceColumn = "Pagadero_a";
                oAdaptador.InsertCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";
                oAdaptador.InsertCommand.Parameters.Add("@Usuario", SqlDbType.NChar).SourceColumn = "Usuario";
                oAdaptador.InsertCommand.Parameters.Add("@Referencia", SqlDbType.NChar).SourceColumn = "Referencia";
                oAdaptador.InsertCommand.Parameters.Add("@ConceptoContable", SqlDbType.NChar).SourceColumn = "ConceptoContable";

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.UpdateCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@Numero", SqlDbType.NChar).SourceColumn = "Numero";
                oAdaptador.UpdateCommand.Parameters.Add("@Pagaderoa", SqlDbType.NChar).SourceColumn = "Pagadero_a";
                oAdaptador.UpdateCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";
                oAdaptador.UpdateCommand.Parameters.Add("@Usuario", SqlDbType.NChar).SourceColumn = "Usuario";
                oAdaptador.UpdateCommand.Parameters.Add("@Referencia", SqlDbType.NChar).SourceColumn = "Referencia";
                oAdaptador.UpdateCommand.Parameters.Add("@ConceptoContable", SqlDbType.NChar).SourceColumn = "ConceptoContable";



                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.DeleteCommand.Parameters.Add("@Fecha", SqlDbType.Date).SourceColumn = "Fecha";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@Numero", SqlDbType.NChar).SourceColumn = "Numero";
                oAdaptador.DeleteCommand.Parameters.Add("@Pagaderoa", SqlDbType.NChar).SourceColumn = "Pagadero_a";
                oAdaptador.DeleteCommand.Parameters.Add("@Monto", SqlDbType.Decimal).SourceColumn = "Monto";
                oAdaptador.DeleteCommand.Parameters.Add("@Usuario", SqlDbType.NChar).SourceColumn = "Usuario";
                oAdaptador.DeleteCommand.Parameters.Add("@Referencia", SqlDbType.NChar).SourceColumn = "Referencia";
                oAdaptador.DeleteCommand.Parameters.Add("@ConceptoContable", SqlDbType.NChar).SourceColumn = "ConceptoContable";

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


        public static DataSet GetDataEmpty()
        {
            String strSQL = "SELECT  IDCuentaBanco ,Fecha ,IDTipo ,IDSubTipo ,Numero ,Pagadero_a ,Monto ,Asiento ,Anulado ,AsientoAnulacion ,Usuario ,UsuarioAnulacion ,FechaAnulacion ,Referencia ,ConceptoContable  FROM dbo.cbMovimientos WHERE 1=2";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static DataSet GetData(int IDCuentaBanco,int IDTipo,int IDSubTipo,String Numero)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDCuentaBanco"].Value = IDCuentaBanco;
            oAdaptador.SelectCommand.Parameters["@IDTipo"].Value = IDTipo;
            oAdaptador.SelectCommand.Parameters["@IDSubTipo"].Value = IDSubTipo;
            oAdaptador.SelectCommand.Parameters["@Numero"].Value = Numero;



            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

    }
}
