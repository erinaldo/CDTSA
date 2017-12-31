using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Security;


namespace CI.DAC
{
    public static class clsProductoDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "dbo.invGetProducto";
            String InsertSQL = "[dbo].[cntUpdateProducto]";
            String UpdateSQL = "[dbo].[cntUpdateProducto]";
            String DeleteSQL = "[dbo].[cntUpdateProducto]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.SelectCommand.Parameters.Add("@Alias", SqlDbType.NChar).SourceColumn = "Alias";
                oAdaptador.SelectCommand.Parameters.Add("@Clasif1", SqlDbType.Int).SourceColumn = "Clasif1";
                oAdaptador.SelectCommand.Parameters.Add("@Clasif2", SqlDbType.Int).SourceColumn = "Clasif2";
                oAdaptador.SelectCommand.Parameters.Add("@Clasif3", SqlDbType.Int).SourceColumn = "Clasif3";
                oAdaptador.SelectCommand.Parameters.Add("@Clasif4", SqlDbType.Int).SourceColumn = "Clasif4";
                oAdaptador.SelectCommand.Parameters.Add("@Clasif5", SqlDbType.Int).SourceColumn = "Clasif5";
                oAdaptador.SelectCommand.Parameters.Add("@Clasif6", SqlDbType.Int).SourceColumn = "Clasif6";
                oAdaptador.SelectCommand.Parameters.Add("@CodigoBarra", SqlDbType.NChar).SourceColumn = "CodigoBarra";
                oAdaptador.SelectCommand.Parameters.Add("@EsMuesta", SqlDbType.Int).SourceColumn = "EsMuesta";
                oAdaptador.SelectCommand.Parameters.Add("@EsControlado", SqlDbType.Int).SourceColumn = "EsControlado";
                oAdaptador.SelectCommand.Parameters.Add("@EsEtico", SqlDbType.Int).SourceColumn = "EsEtico";




                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDProducto", SqlDbType.Int).SourceColumn = "IDProducto";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@Alias", SqlDbType.NChar).SourceColumn = "Alias";
                oAdaptador.InsertCommand.Parameters.Add("@Clasif1", SqlDbType.Int).SourceColumn = "Clasif1";
                oAdaptador.InsertCommand.Parameters.Add("@Clasif2", SqlDbType.Int).SourceColumn = "Clasif2";
                oAdaptador.InsertCommand.Parameters.Add("@Clasif3", SqlDbType.Int).SourceColumn = "Clasif3";
                oAdaptador.InsertCommand.Parameters.Add("@Clasif4", SqlDbType.Int).SourceColumn = "Clasif4";
                oAdaptador.InsertCommand.Parameters.Add("@Clasif5", SqlDbType.Int).SourceColumn = "Clasif5";
                oAdaptador.InsertCommand.Parameters.Add("@Clasif6", SqlDbType.Int).SourceColumn = "Clasif6";
                oAdaptador.InsertCommand.Parameters.Add("@CodigoBarra", SqlDbType.NChar).SourceColumn = "CodigoBarra";
                oAdaptador.InsertCommand.Parameters.Add("@IDUnidad", SqlDbType.Int).SourceColumn = "IDUnidad";
                oAdaptador.InsertCommand.Parameters.Add("@FactorEmpaque", SqlDbType.Decimal).SourceColumn = "FactorEmpaque";
                oAdaptador.InsertCommand.Parameters.Add("@TipoImpuesto", SqlDbType.Int).SourceColumn = "TipoImpuesto";
                oAdaptador.InsertCommand.Parameters.Add("@EsMuestra", SqlDbType.Bit).SourceColumn = "EsMuestra";
                oAdaptador.InsertCommand.Parameters.Add("@EsControlado", SqlDbType.Bit).SourceColumn = "EsControlado";
                oAdaptador.InsertCommand.Parameters.Add("@EsEstico", SqlDbType.Bit).SourceColumn = "EsEstico";
                oAdaptador.InsertCommand.Parameters.Add("@BajaPrecioDistribuidor", SqlDbType.Bit).SourceColumn = "BajaPrecioDistribuidor";
                oAdaptador.InsertCommand.Parameters.Add("@BajaPrecioProveedor", SqlDbType.Bit).SourceColumn = "BajaPrecioProveedor";
                oAdaptador.InsertCommand.Parameters.Add("@PorcDescuentoAlzaProveedor", SqlDbType.Decimal).SourceColumn = "PorcDescuentoAlzaProveedor";
                oAdaptador.InsertCommand.Parameters.Add("@BonificaFA", SqlDbType.Bit).SourceColumn = "BonificaFA";
                oAdaptador.InsertCommand.Parameters.Add("@BonificaCOPorCada", SqlDbType.Decimal).SourceColumn = "BonificaCOPorCada";
                oAdaptador.InsertCommand.Parameters.Add("@BonificaCOCantidad", SqlDbType.Decimal).SourceColumn = "BonificaCOCantidad";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.InsertCommand.Parameters.Add("@UserInsert", SqlDbType.NChar).SourceColumn = "UserInsert";
                oAdaptador.InsertCommand.Parameters.Add("@UserUpdate", SqlDbType.NChar).SourceColumn = "UserUpdate";
                oAdaptador.InsertCommand.Parameters.Add("@UpdateDate", SqlDbType.Date).SourceColumn = "UpdateDate";

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@Alias", SqlDbType.NChar).SourceColumn = "Alias";
                oAdaptador.UpdateCommand.Parameters.Add("@Clasif1", SqlDbType.Int).SourceColumn = "Clasif1";
                oAdaptador.UpdateCommand.Parameters.Add("@Clasif2", SqlDbType.Int).SourceColumn = "Clasif2";
                oAdaptador.UpdateCommand.Parameters.Add("@Clasif3", SqlDbType.Int).SourceColumn = "Clasif3";
                oAdaptador.UpdateCommand.Parameters.Add("@Clasif4", SqlDbType.Int).SourceColumn = "Clasif4";
                oAdaptador.UpdateCommand.Parameters.Add("@Clasif5", SqlDbType.Int).SourceColumn = "Clasif5";
                oAdaptador.UpdateCommand.Parameters.Add("@Clasif6", SqlDbType.Int).SourceColumn = "Clasif6";
                oAdaptador.UpdateCommand.Parameters.Add("@CodigoBarra", SqlDbType.NChar).SourceColumn = "CodigoBarra";
                oAdaptador.UpdateCommand.Parameters.Add("@IDUnidad", SqlDbType.Int).SourceColumn = "IDUnidad";
                oAdaptador.UpdateCommand.Parameters.Add("@FactorEmpaque", SqlDbType.Decimal).SourceColumn = "FactorEmpaque";
                oAdaptador.UpdateCommand.Parameters.Add("@TipoImpuesto", SqlDbType.Int).SourceColumn = "TipoImpuesto";
                oAdaptador.UpdateCommand.Parameters.Add("@EsMuestra", SqlDbType.Bit).SourceColumn = "EsMuestra";
                oAdaptador.UpdateCommand.Parameters.Add("@EsControlado", SqlDbType.Bit).SourceColumn = "EsControlado";
                oAdaptador.UpdateCommand.Parameters.Add("@EsEstico", SqlDbType.Bit).SourceColumn = "EsEstico";
                oAdaptador.UpdateCommand.Parameters.Add("@BajaPrecioDistribuidor", SqlDbType.Bit).SourceColumn = "BajaPrecioDistribuidor";
                oAdaptador.UpdateCommand.Parameters.Add("@BajaPrecioProveedor", SqlDbType.Bit).SourceColumn = "BajaPrecioProveedor";
                oAdaptador.UpdateCommand.Parameters.Add("@PorcDescuentoAlzaProveedor", SqlDbType.Decimal).SourceColumn = "PorcDescuentoAlzaProveedor";
                oAdaptador.UpdateCommand.Parameters.Add("@BonificaFA", SqlDbType.Bit).SourceColumn = "BonificaFA";
                oAdaptador.UpdateCommand.Parameters.Add("@BonificaCOPorCada", SqlDbType.Decimal).SourceColumn = "BonificaCOPorCada";
                oAdaptador.UpdateCommand.Parameters.Add("@BonificaCOCantidad", SqlDbType.Decimal).SourceColumn = "BonificaCOCantidad";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.UpdateCommand.Parameters.Add("@UserInsert", SqlDbType.NChar).SourceColumn = "UserInsert";
                oAdaptador.UpdateCommand.Parameters.Add("@UserUpdate", SqlDbType.NChar).SourceColumn = "UserUpdate";
                oAdaptador.UpdateCommand.Parameters.Add("@UpdateDate", SqlDbType.Date).SourceColumn = "UpdateDate";



                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@Alias", SqlDbType.NChar).SourceColumn = "Alias";
                oAdaptador.DeleteCommand.Parameters.Add("@Clasif1", SqlDbType.Int).SourceColumn = "Clasif1";
                oAdaptador.DeleteCommand.Parameters.Add("@Clasif2", SqlDbType.Int).SourceColumn = "Clasif2";
                oAdaptador.DeleteCommand.Parameters.Add("@Clasif3", SqlDbType.Int).SourceColumn = "Clasif3";
                oAdaptador.DeleteCommand.Parameters.Add("@Clasif4", SqlDbType.Int).SourceColumn = "Clasif4";
                oAdaptador.DeleteCommand.Parameters.Add("@Clasif5", SqlDbType.Int).SourceColumn = "Clasif5";
                oAdaptador.DeleteCommand.Parameters.Add("@Clasif6", SqlDbType.Int).SourceColumn = "Clasif6";
                oAdaptador.DeleteCommand.Parameters.Add("@CodigoBarra", SqlDbType.NChar).SourceColumn = "CodigoBarra";
                oAdaptador.DeleteCommand.Parameters.Add("@IDUnidad", SqlDbType.Int).SourceColumn = "IDUnidad";
                oAdaptador.DeleteCommand.Parameters.Add("@FactorEmpaque", SqlDbType.Decimal).SourceColumn = "FactorEmpaque";
                oAdaptador.DeleteCommand.Parameters.Add("@TipoImpuesto", SqlDbType.Int).SourceColumn = "TipoImpuesto";
                oAdaptador.DeleteCommand.Parameters.Add("@EsMuestra", SqlDbType.Bit).SourceColumn = "EsMuestra";
                oAdaptador.DeleteCommand.Parameters.Add("@EsControlado", SqlDbType.Bit).SourceColumn = "EsControlado";
                oAdaptador.DeleteCommand.Parameters.Add("@EsEstico", SqlDbType.Bit).SourceColumn = "EsEstico";
                oAdaptador.DeleteCommand.Parameters.Add("@BajaPrecioDistribuidor", SqlDbType.Bit).SourceColumn = "BajaPrecioDistribuidor";
                oAdaptador.DeleteCommand.Parameters.Add("@BajaPrecioProveedor", SqlDbType.Bit).SourceColumn = "BajaPrecioProveedor";
                oAdaptador.DeleteCommand.Parameters.Add("@PorcDescuentoAlzaProveedor", SqlDbType.Decimal).SourceColumn = "PorcDescuentoAlzaProveedor";
                oAdaptador.DeleteCommand.Parameters.Add("@BonificaFA", SqlDbType.Bit).SourceColumn = "BonificaFA";
                oAdaptador.DeleteCommand.Parameters.Add("@BonificaCOPorCada", SqlDbType.Decimal).SourceColumn = "BonificaCOPorCada";
                oAdaptador.DeleteCommand.Parameters.Add("@BonificaCOCantidad", SqlDbType.Decimal).SourceColumn = "BonificaCOCantidad";
                oAdaptador.DeleteCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.DeleteCommand.Parameters.Add("@UserInsert", SqlDbType.NChar).SourceColumn = "UserInsert";
                oAdaptador.DeleteCommand.Parameters.Add("@UserUpdate", SqlDbType.NChar).SourceColumn = "UserUpdate";
                oAdaptador.DeleteCommand.Parameters.Add("@UpdateDate", SqlDbType.Date).SourceColumn = "UpdateDate";

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

        public static DataSet GetData(int IDProducto, String Descr, String Alias, int Clasif1, 
                                      int Clasif2,int Clasif3,int Clasif4, int Clasif5, int Clasif6,
                                      String CodigoBarra, int EsMuesta, int EsControlado, int EsEtico)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDProducto"].Value = IDProducto;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            oAdaptador.SelectCommand.Parameters["@Alias"].Value = Alias;
            oAdaptador.SelectCommand.Parameters["@Clasif1"].Value = Clasif1;
            oAdaptador.SelectCommand.Parameters["@Clasif2"].Value = Clasif2;
            oAdaptador.SelectCommand.Parameters["@Clasif3"].Value = Clasif3;
            oAdaptador.SelectCommand.Parameters["@Clasif4"].Value = Clasif4;
            oAdaptador.SelectCommand.Parameters["@Clasif5"].Value = Clasif5;
            oAdaptador.SelectCommand.Parameters["@Clasif6"].Value = Clasif6;
            oAdaptador.SelectCommand.Parameters["@CodigoBarra"].Value = CodigoBarra;
            oAdaptador.SelectCommand.Parameters["@EsMuestra"].Value = EsMuesta;
            oAdaptador.SelectCommand.Parameters["@EsControlado"].Value = EsControlado;
            oAdaptador.SelectCommand.Parameters["@EsEtico"].Value = EsEtico;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }



    }
}
