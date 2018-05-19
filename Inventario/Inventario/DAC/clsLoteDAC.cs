using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Security;

namespace CI.DAC
{
    public class clsLoteDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.invGetLote";
            String InsertSQL = "[dbo].[invUpdateLote]";
            String UpdateSQL = "[dbo].[invUpdateLote]";
            String DeleteSQL = "[dbo].[invUpdateLote]";

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
                oAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.SelectCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.SelectCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.SelectCommand.Parameters.Add("@LoteInterno", SqlDbType.NVarChar).SourceColumn = "LoteInterno";
                oAdaptador.SelectCommand.Parameters.Add("@LoteProveedor", SqlDbType.NVarChar).SourceColumn = "LoteProveedor";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.InsertCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.InsertCommand.Parameters.Add("@LoteInterno", SqlDbType.NVarChar).SourceColumn = "LoteInterno";
                oAdaptador.InsertCommand.Parameters.Add("@LoteProveedor", SqlDbType.NVarChar).SourceColumn = "LoteProveedor";
                oAdaptador.InsertCommand.Parameters.Add("@FechaVencimiento", SqlDbType.Date).SourceColumn = "FechaVencimiento";
                oAdaptador.InsertCommand.Parameters.Add("@FechaFabricacion", SqlDbType.Date).SourceColumn = "FechaFabricacion";
                oAdaptador.InsertCommand.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).SourceColumn = "FechaIngreso";

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.UpdateCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.UpdateCommand.Parameters.Add("@LoteInterno", SqlDbType.NVarChar).SourceColumn = "LoteInterno";
                oAdaptador.UpdateCommand.Parameters.Add("@LoteProveedor", SqlDbType.NVarChar).SourceColumn = "LoteProveedor";
                oAdaptador.UpdateCommand.Parameters.Add("@FechaVencimiento", SqlDbType.Date).SourceColumn = "FechaVencimiento";
                oAdaptador.UpdateCommand.Parameters.Add("@FechaFabricacion", SqlDbType.Date).SourceColumn = "FechaFabricacion";
                oAdaptador.UpdateCommand.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).SourceColumn = "FechaIngreso";

                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDLote", SqlDbType.Int).SourceColumn = "IDLote";
                oAdaptador.DeleteCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.DeleteCommand.Parameters.Add("@LoteInterno", SqlDbType.NVarChar).SourceColumn = "LoteInterno";
                oAdaptador.DeleteCommand.Parameters.Add("@LoteProveedor", SqlDbType.NVarChar).SourceColumn = "LoteProveedor";
                oAdaptador.DeleteCommand.Parameters.Add("@FechaVencimiento", SqlDbType.Date).SourceColumn = "FechaVencimiento";
                oAdaptador.DeleteCommand.Parameters.Add("@FechaFabricacion", SqlDbType.Date).SourceColumn = "FechaFabricacion";
                oAdaptador.DeleteCommand.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).SourceColumn = "FechaIngreso";
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

        public static DataSet GetData(int IDLote, int  IDProducto, String LoteInterno,String LoteProveedor)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDLote"].Value = IDLote;
            oAdaptador.SelectCommand.Parameters["@IDProducto"].Value = IDProducto;
            oAdaptador.SelectCommand.Parameters["@LoteInterno"].Value = LoteInterno;
            oAdaptador.SelectCommand.Parameters["@LoteProveedor"].Value = LoteProveedor;
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }
    }
}
