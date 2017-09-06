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
    public static class CuentaContableDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT A.IDCuenta,A.IDGrupo,G.Descr DescrGrupo,A.IDTipo,T.Descr DescrTipo,A.IDSubTipo,ST.Descr DescrSubTipo,A.Tipo,A.SubTipo,A.Nivel1,A.Nivel2,A.Nivel3,A.Nivel4,A.Nivel5,A.Cuenta,A.Descr,A.Complementaria," +
                             "A.EsMayor,A.AceptaDatos,A.Activa,A.IDCuentaAnterior,A.IDCuentaMayor,B.Descr DescrCuentaMayor, A.UsaCentroCosto,A.IDSeccion " +
                            "FROM dbo.cntCuenta A" +
                            " LEFT JOIN dbo.cntCuenta B ON A.IDCuentaMayor = B.IDCuenta " +
                            "INNER JOIN dbo.cntTipoCuenta T ON A.IDTipo=T.IDTipo " +
                            "INNER JOIN dbo.cntSubTipoCuenta ST ON A.IDSubTipo = ST.IDSubTipo AND A.IDTipo = ST.IDTipo " +
                            "INNER JOIN dbo.cntGrupoCuenta G ON A.IDTipo = G.IDTipo AND A.IDSubTipo = G.IDSubTipo AND A.IDGrupo = G.IDGrupo " +
                            "WHERE(A.IDCuenta = @IDCuenta OR @IDCuenta = -1) AND(A.IDGrupo = @IDGrupo OR  @IDGrupo = -1) " +
                            "AND(A.IDSubTipo = @IDSubTipo OR @IDSubTipo = -1) AND(A.Nivel1 = @Nivel1 OR @Nivel1 = '*') " +
                            "AND(A.Nivel2 = @Nivel2 OR @Nivel2 = '*')  AND(A.Nivel3 = @Nivel3 OR @Nivel3 = '*') " +
                            "AND(A.Nivel4 = @Nivel4 OR @Nivel4 = '*') AND(A.Nivel5 = @Nivel5 OR @Nivel5 = '*') " +
                            "AND(A.Cuenta = @Cuenta OR @Cuenta = '*') AND(A.Complementaria = @Complementaria OR  @Complementaria = -1) " +
                            "AND(A.EsMayor = @EsMayor OR @EsMayor = -1) AND(A.AceptaDatos = @AceptaDatos  OR @AceptaDatos = -1) " +
                            "AND(A.Activa = @Activa OR @Activa = -1) AND(A.IDCuentaMayor = @IDCuentaMayor OR @IDCuentaMayor = -1) " +
                            "AND(A.UsaCentroCosto = @UsaCentroCosto OR @UsaCentroCosto = -1) order by A.Cuenta";
            String InsertSQL = "[dbo].[cntUpdateCuenta]";
            String UpdateSQL = "[dbo].[cntUpdateCuenta]";
            String DeleteSQL = "[dbo].[cntUpdateCuenta]";

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
                oAdaptador.SelectCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCentro";
                oAdaptador.SelectCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "Nivel1";
                oAdaptador.SelectCommand.Parameters.Add("@IDSubTipo", SqlDbType.NVarChar).SourceColumn = "Nivel2";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel1", SqlDbType.NVarChar).SourceColumn = "Nivel3";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel2", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel3", SqlDbType.NVarChar).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel4", SqlDbType.NVarChar).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@Nivel5", SqlDbType.NVarChar).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@Cuenta", SqlDbType.NVarChar).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@Complementaria", SqlDbType.Int).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@EsMayor", SqlDbType.Int).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@AceptaDatos", SqlDbType.Int).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@Activa", SqlDbType.Int).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@IDCuentaMayor", SqlDbType.Int).SourceColumn = "Acumulador";
                oAdaptador.SelectCommand.Parameters.Add("@UsaCentroCosto", SqlDbType.Int).SourceColumn = "Acumulador";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.InsertCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.InsertCommand.Parameters.Add("@IDSubTipo", SqlDbType.NVarChar).SourceColumn = "IDSubTipo";
                oAdaptador.InsertCommand.Parameters.Add("@Complementaria", SqlDbType.Bit).SourceColumn = "Complementaria";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel1", SqlDbType.NVarChar).SourceColumn = "Nivel1";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel2", SqlDbType.NVarChar).SourceColumn = "Nivel2";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel3", SqlDbType.NVarChar).SourceColumn = "Nivel3";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel4", SqlDbType.NVarChar).SourceColumn = "Nivel4";
                oAdaptador.InsertCommand.Parameters.Add("@Nivel5", SqlDbType.NVarChar).SourceColumn = "Nivel5";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@EsMayor", SqlDbType.Bit).SourceColumn = "EsMayor";
                oAdaptador.InsertCommand.Parameters.Add("@AceptaDatos", SqlDbType.Bit).SourceColumn = "AceptaDatos";
                oAdaptador.InsertCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuentaAnterior", SqlDbType.Int).SourceColumn = "IDCuentaAnterior";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuentaMayor", SqlDbType.Int).SourceColumn = "IDCuentaMayor";
                oAdaptador.InsertCommand.Parameters.Add("@UsaCentroCosto", SqlDbType.Bit).SourceColumn = "UsaCentroCosto";
                oAdaptador.InsertCommand.Parameters.Add("@IDSeccion", SqlDbType.Int).Value = null;


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.UpdateCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@IDSubTipo", SqlDbType.NVarChar).SourceColumn = "IDSubTipo";
                oAdaptador.UpdateCommand.Parameters.Add("@Complementaria", SqlDbType.Bit).SourceColumn = "Complementaria";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel1", SqlDbType.NVarChar).SourceColumn = "Nivel1";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel2", SqlDbType.NVarChar).SourceColumn = "Nivel2";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel3", SqlDbType.NVarChar).SourceColumn = "Nivel3";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel4", SqlDbType.NVarChar).SourceColumn = "Nivel4";
                oAdaptador.UpdateCommand.Parameters.Add("@Nivel5", SqlDbType.NVarChar).SourceColumn = "Nivel5";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@EsMayor", SqlDbType.Bit).SourceColumn = "EsMayor";
                oAdaptador.UpdateCommand.Parameters.Add("@AceptaDatos", SqlDbType.Bit).SourceColumn = "AceptaDatos";
                oAdaptador.UpdateCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuentaAnterior", SqlDbType.Int).SourceColumn = "IDCuentaAnterior";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuentaMayor", SqlDbType.Int).SourceColumn = "IDCuentaMayor";
                oAdaptador.UpdateCommand.Parameters.Add("@UsaCentroCosto", SqlDbType.Bit).SourceColumn = "UsaCentroCosto";
                oAdaptador.UpdateCommand.Parameters.Add("@IDSeccion", SqlDbType.Int).Value = null;




                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.DeleteCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@IDSubTipo", SqlDbType.NVarChar).SourceColumn = "IDSubTipo";
                oAdaptador.DeleteCommand.Parameters.Add("@Complementaria", SqlDbType.Bit).SourceColumn = "Complementaria";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel1", SqlDbType.NVarChar).SourceColumn = "Nivel1";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel2", SqlDbType.NVarChar).SourceColumn = "Nivel2";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel3", SqlDbType.NVarChar).SourceColumn = "Nivel3";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel4", SqlDbType.NVarChar).SourceColumn = "Nivel4";
                oAdaptador.DeleteCommand.Parameters.Add("@Nivel5", SqlDbType.NVarChar).SourceColumn = "Nivel5";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NVarChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@EsMayor", SqlDbType.Bit).SourceColumn = "EsMayor";
                oAdaptador.DeleteCommand.Parameters.Add("@AceptaDatos", SqlDbType.Bit).SourceColumn = "AceptaDatos";
                oAdaptador.DeleteCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuentaAnterior", SqlDbType.Int).SourceColumn = "IDCuentaAnterior";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuentaMayor", SqlDbType.Int).SourceColumn = "IDCuentaMayor";
                oAdaptador.DeleteCommand.Parameters.Add("@UsaCentroCosto", SqlDbType.Bit).SourceColumn = "UsaCentroCosto";
                oAdaptador.DeleteCommand.Parameters.Add("@IDSeccion", SqlDbType.Int).Value = null;
                
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

        public static DataSet GetData(int IDCuenta,int IDGrupo,int IDSubGrupo,String Nivel1, String Nivel2, String Nivel3,
                                       String Nivel4, String Nivel5, String Cuenta,int Complementaria,int EsMayor,int AceptaDatos,
                                       int Activa,int IDCuentaMayor,int UsaCentroCosto )
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDCuenta"].Value = IDCuenta;
            oAdaptador.SelectCommand.Parameters["@IDGrupo"].Value = IDGrupo;
            oAdaptador.SelectCommand.Parameters["@IDSubTipo"].Value = IDSubGrupo;
            oAdaptador.SelectCommand.Parameters["@Nivel1"].Value = Nivel1;
            oAdaptador.SelectCommand.Parameters["@Nivel2"].Value = Nivel2;
            oAdaptador.SelectCommand.Parameters["@Nivel3"].Value = Nivel3;
            oAdaptador.SelectCommand.Parameters["@Nivel4"].Value = Nivel4;
            oAdaptador.SelectCommand.Parameters["@Nivel5"].Value = Nivel5;
            oAdaptador.SelectCommand.Parameters["@Cuenta"].Value = Cuenta;
            oAdaptador.SelectCommand.Parameters["@Complementaria"].Value = Complementaria;
            oAdaptador.SelectCommand.Parameters["@EsMayor"].Value = EsMayor;
            oAdaptador.SelectCommand.Parameters["@AceptaDatos"].Value = AceptaDatos;
            oAdaptador.SelectCommand.Parameters["@Activa"].Value = Activa;
            oAdaptador.SelectCommand.Parameters["@IDCuentaMayor"].Value = IDCuentaMayor;
            oAdaptador.SelectCommand.Parameters["@UsaCentroCosto"].Value = UsaCentroCosto;

            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }



    
        public static int GetNextConsecutivo(int Nivel1,int Nivel2, int Nivel3, int Nivel4, int Nivel5)
        {
        int ID = 0;
            DataSet DS = new DataSet();
    
            SqlCommand oCmd = new SqlCommand("dbo.cntGetNextConsecutivoCuenta", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {

               
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@Nivel1", SqlDbType.Int).Value = Nivel1;
                oCmd.Parameters.Add("@Nivel2", SqlDbType.Int).Value = Nivel2;
                oCmd.Parameters.Add("@Nivel3", SqlDbType.Int).Value = Nivel3;
                oCmd.Parameters.Add("@Nivel4", SqlDbType.Int).Value = Nivel4;
                oCmd.Parameters.Add("@Nivel5", SqlDbType.Int).Value = Nivel5;
                oCmd.Parameters.Add("@Resultado", SqlDbType.BigInt).Direction = ParameterDirection.ReturnValue;

            
                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@Resultado"].Value != DBNull.Value)
                    ID = (int)oCmd.Parameters["@Resultado"].Value;
     
            }catch (Exception)
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


        public static int GetNextConsecutivoFinal(int Nivel1, int Nivel2, int Nivel3, int Nivel4, int Nivel5)
        {
            int ID = 0;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntGetProximaCuenta", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@iNivel1", SqlDbType.Int).Value = Nivel1;
                oCmd.Parameters.Add("@iNivel2", SqlDbType.Int).Value = Nivel2;
                oCmd.Parameters.Add("@iNivel3", SqlDbType.Int).Value = Nivel3;
                oCmd.Parameters.Add("@iNivel4", SqlDbType.Int).Value = Nivel4;
                oCmd.Parameters.Add("@iNivel5", SqlDbType.Int).Value = Nivel5;
                oCmd.Parameters.Add("@NextCuenta", SqlDbType.Int).Value = 0;
                oCmd.Parameters["@NextCuenta"].Direction = ParameterDirection.Output;


                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@NextCuenta"].Value != DBNull.Value)
                    ID = (int)oCmd.Parameters["@NextCuenta"].Value;

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

        public static bool ExisteCuentaPrimerNivel(int Nivel1)
        {
            bool result = false;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntExisteCuentaPrimerNivel", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@Nivel", SqlDbType.Int).Value = Nivel1;
                oCmd.Parameters.Add("@Result", SqlDbType.Bit).Direction = ParameterDirection.ReturnValue;

                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@Result"].Value != DBNull.Value)
                    result = (bool)oCmd.Parameters["@Result"].Value;

           
                

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
            return result;

        }



        public static String GetMascaraByNivel(String Nivel1, String Nivel2, String Nivel3, String Nivel4, String Nivel5)
        {
            String ID = "";
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntGetMascaraCuentaByNivel", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@Nivel1", SqlDbType.NVarChar,50).Value = Nivel1;
                oCmd.Parameters.Add("@Nivel2", SqlDbType.NVarChar, 50).Value = Nivel2;
                oCmd.Parameters.Add("@Nivel3", SqlDbType.NVarChar, 50).Value = Nivel3;
                oCmd.Parameters.Add("@Nivel4", SqlDbType.NVarChar, 50).Value = Nivel4;
                oCmd.Parameters.Add("@Nivel5", SqlDbType.NVarChar, 50).Value = Nivel5;
                oCmd.Parameters.Add("@Resultado", SqlDbType.NVarChar, 50).Direction = ParameterDirection.ReturnValue;


                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@Resultado"].Value != DBNull.Value)
                    ID = oCmd.Parameters["@Resultado"].Value.ToString();

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


        public static int GetCountCuentaByNivel(String Nivel1, String Nivel2, String Nivel3, String Nivel4, String Nivel5)
        {
            int ID = 0;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cntGetCountCuentaByNivel", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@Nivel1", SqlDbType.NVarChar, 50).Value = Nivel1;
                oCmd.Parameters.Add("@Nivel2", SqlDbType.NVarChar, 50).Value = Nivel2;
                oCmd.Parameters.Add("@Nivel3", SqlDbType.NVarChar, 50).Value = Nivel3;
                oCmd.Parameters.Add("@Nivel4", SqlDbType.NVarChar, 50).Value = Nivel4;
                oCmd.Parameters.Add("@Nivel5", SqlDbType.NVarChar, 50).Value = Nivel5;
                oCmd.Parameters.Add("@Resultado", SqlDbType.NVarChar, 50).Direction = ParameterDirection.ReturnValue;

             
                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@Resultado"].Value != DBNull.Value)
                    ID = Convert.ToInt32( oCmd.Parameters["@Resultado"].Value);

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



        public static Task<DataSet> GetDataAsync(String CodSucursal, String NumSolicitud)
        {
            return Task.Factory.StartNew<DataSet>(() => {
                DataSet DS = CreateDataSet();
                oAdaptador.SelectCommand.Parameters["@CodSucursal"].Value = CodSucursal;
                oAdaptador.SelectCommand.Parameters["@NumSolicitud"].Value = NumSolicitud;
                oAdaptador.Fill(DS.Tables["Data"]);
                return DS;
            });


        }
    }
}
