using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace CG.DAC
{
    public static class GrupoEstadosFinancierosDAC
    {


        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT A.IDGrupo,A.Nivel1,A.Nivel2,A.Nivel3,A.Grupo,A.Descr,A.Activo,A.Acumulador,A.IDGrupoAcumulador ,B.Descr DescrGrupoAcumulador,A.Tipo  FROM dbo.cntGrupoEstadosFinancieros A LEFT  JOIN dbo.cntGrupoEstadosFinancieros B ON		A.IDGrupoAcumulador = B.IDGrupo WHERE (A.IDGrupo=@IDGrupo OR @IDGrupo=-1) AND (A.Nivel1=@Nivel1 OR @Nivel1='*') AND (A.Nivel2=@Nivel2 OR @Nivel2='*') AND (A.Nivel3=@Nivel3 OR @Nivel3='*') AND (A.Descr = @Descr OR @Descr='*') AND (A.Tipo = @Tipo or @Tipo='*') and (A.Acumulador = @Acumulador or @Acumulador=-1) and (A.Activo=@Activo or @Activo=-1)  order by Cast(A.Nivel1 as int), Cast(A.Nivel2 as int), cast(A.Nivel3 as int)";
            String InsertSQL = "[dbo].[cntUpdateGrupoEstadoFinanciero]";
            String UpdateSQL = "[dbo].[cntUpdateGrupoEstadoFinanciero]";
            String DeleteSQL = "[dbo].[cntUpdateGrupoEstadoFinanciero]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                oAdaptador.SelectCommand.Parameters.Add("@Tipo", SqlDbType.NVarChar).SourceColumn = "Tipo";
                oAdaptador.SelectCommand.Parameters.Add("@Acumulador", SqlDbType.Int).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@Activo", SqlDbType.Int).SourceColumn = "Activo";
                oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@IDGrupoAcumulador", SqlDbType.Int).SourceColumn = "IDGrupoAcumulador";
                oAdaptador.InsertCommand.Parameters.Add("@Acumulador", SqlDbType.Bit).SourceColumn = "Acumulador";
                oAdaptador.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.InsertCommand.Parameters.Add("@Tipo", SqlDbType.NVarChar).SourceColumn = "Tipo";
                

                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@IDGrupoAcumulador", SqlDbType.Int).SourceColumn = "IDGrupoAcumulador";
                oAdaptador.UpdateCommand.Parameters.Add("@Acumulador", SqlDbType.Bit).SourceColumn = "Acumulador";
                oAdaptador.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.NVarChar).SourceColumn = "Tipo";


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@IDGrupoAcumulador", SqlDbType.Int).SourceColumn = "IDGrupoAcumulador";
                oAdaptador.DeleteCommand.Parameters.Add("@Acumulador", SqlDbType.Bit).SourceColumn = "Acumulador";
                oAdaptador.DeleteCommand.Parameters.Add("@Activo", SqlDbType.Bit).SourceColumn = "Activo";
                oAdaptador.DeleteCommand.Parameters.Add("@Tipo", SqlDbType.NVarChar).SourceColumn = "Tipo";

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

        public static DataSet GetData(int IDGrupo, String Nivel1, String Nivel2, String Nivel3, String Descr, int Acumulador,int Activo,String Tipo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDGrupo"].Value = IDGrupo;
            oAdaptador.SelectCommand.Parameters["@Nivel1"].Value = Nivel1;
            oAdaptador.SelectCommand.Parameters["@Nivel2"].Value = Nivel2;
            oAdaptador.SelectCommand.Parameters["@Nivel3"].Value = Nivel3;
            oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            oAdaptador.SelectCommand.Parameters["@Acumulador"].Value = Acumulador;
            oAdaptador.SelectCommand.Parameters["@Activo"].Value = Activo;
            oAdaptador.SelectCommand.Parameters["@Tipo"].Value = Tipo;
            

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


     

     

        public static int GetNextConsecutivo(int Nivel1, int Nivel2, int Nivel3,String Tipo)
        {
            int ID = 0;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntGetNextConsecutivoGrupoEstadoFinancieros", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@iNivel1", SqlDbType.Int).Value = Nivel1;
                oCmd.Parameters.Add("@iNivel2", SqlDbType.Int).Value = Nivel2;
                oCmd.Parameters.Add("@iNivel3", SqlDbType.Int).Value = Nivel3;
                oCmd.Parameters.Add("@Tipo", SqlDbType.NVarChar).Value = Tipo;
                oCmd.Parameters.Add("@NextGrupo", SqlDbType.Int).Value = 0;
                oCmd.Parameters["@NextGrupo"].Direction = ParameterDirection.Output;


                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@NextGrupo"].Value != DBNull.Value)
                    ID = (int)oCmd.Parameters["@NextGrupo"].Value;

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
            return ID;

        }


        public static bool   GrupoTieneHijos(int IDGrupo, String Tipo)
        {
            bool TieneHijos = false;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.[cntTieneHijosGrupoEstadosFinancieros]", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = IDGrupo;
                oCmd.Parameters.Add("@Tipo", SqlDbType.NVarChar).Value = Tipo;
                

                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                TieneHijos = Convert.ToBoolean( oCmd.ExecuteScalar());

                //if (oCmd.Parameters["@Result"].Value != DBNull.Value)
                //    TieneHijos = (bool)oCmd.Parameters["@Result"].Value;

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
            return TieneHijos;

        }
    
    }
}
