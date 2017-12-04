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
    public static class Cuenta_GrupoEstadosFinancierosDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT A.IDCuenta,Cuenta,C.Descr,A.IDGrupo,Grupo,C.Descr  FROM dbo.cntCuentaGrupoEstadosFinancieros A INNER JOIN dbo.cntCuenta C ON A.IDCuenta=C.IDCuenta INNER JOIN dbo.cntGrupoEstadosFinancieros D ON A.IDGrupo=D.IDGrupo WHERE D.Tipo=@Tipo";
            String InsertSQL = "[dbo].[cntUpdateCuentaGrupoEstadosFinancieros]";
            String DeleteSQL = "[dbo].[cntUpdateCuentaGrupoEstadosFinancieros]";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    InsertCommand = new SqlCommand(InsertSQL, ConnectionManager.GetConnection()),
                    DeleteCommand = new SqlCommand(DeleteSQL, ConnectionManager.GetConnection())
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@Tipo", SqlDbType.NVarChar).SourceColumn = "Tipo";



                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.InsertCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";




                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.DeleteCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";


                return oAdaptador;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetDataEmpty()
        {
            String strSQL = "SELECT  IDCuenta ,IDGrupo  FROM dbo.cntCuentaGrupoEstadosFinancieros WHERE 1=2";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static void SetTransactionToAdaptador(bool Activo)
        {
            oAdaptador.DeleteCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.InsertCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
        }

        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }


        public static bool Insert(int IDCuenta, int IDGrupo)
        {
            bool bResult = false;
            String strSQL = "INSERT INTO dbo.cntCuentaGrupoEstadosFinancieros        ( IDCuenta, IDGrupo )VALUES  ( @IDCuenta,@IDGrupo )";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            try
            {
                oCmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = IDGrupo;
                oCmd.Parameters.Add("@IDCuenta", SqlDbType.Int).Value = IDCuenta;
                oCmd.CommandType = CommandType.Text;


                if (oCmd.Connection.State == ConnectionState.Closed)
                    oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();
                bResult = true;


            }
            catch (Exception)
            {
                throw;


            }
            finally
            {
                if (oCmd.Connection.State == ConnectionState.Open)
                    oCmd.Connection.Close();

            }

            return bResult;
        }

        public static bool Delete(int IDCuenta, int IDGrupo)
        {
            bool bResult = false;
            String strSQL = "delete from dbo.cntCuentaGrupoEstadosFinancieros where IDCuenta = @IDCuenta and IDGrupo =@IDGrupo ";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            try
            {
                oCmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = IDGrupo;
                oCmd.Parameters.Add("@IDCuenta", SqlDbType.Int).Value = IDCuenta;
                oCmd.CommandType = CommandType.Text;


                if (oCmd.Connection.State == ConnectionState.Closed)
                    oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();
                bResult = true;


            }
            catch (Exception)
            {
                throw;


            }
            finally
            {
                if (oCmd.Connection.State == ConnectionState.Open)
                    oCmd.Connection.Close();

            }

            return bResult;
        }



        public static bool DeleteALL()
        {
            bool bResult = false;
            
            String strSQL = "DELETE from dbo.cntCuentaGrupoEstadosFinancieros ";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            try
            {
             
                oCmd.CommandType = CommandType.Text;
                //oCmd.Parameters.Add("@IDGrupo", SqlDbType.Int).Value = IDGrupo;
                if (oCmd.Connection.State == ConnectionState.Closed)
                    oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();
                bResult = true;


            }
            catch (Exception)
            {
                throw;


            }
            finally
            {
                if (oCmd.Connection.State == ConnectionState.Open)
                    oCmd.Connection.Close();

            }

            return bResult;
        }



        public static DataTable GetCuentasGrupoEstadosFinancieros(String sTipo)
        {
            int ID = 0;
            DataSet DS = new DataSet();
            //String sSQL = "SELECT  IDCuenta , Cuenta , DescrCuenta ,Tag , IDCuentaMayor FROM (SELECT A.IDCuenta,C.Cuenta,C.Descr DescrCuenta,'' Tag ,A.IDGrupo  IDCuentaMayor,G.Tipo FROM dbo.cntCuentaGrupoEstadosFinancieros A LEft JOIN dbo.cntCuenta C ON A.IDCuenta=C.IDCuenta  left JOIN dbo.cntGrupoEstadosFinancieros G ON A.IDGrupo=G.IDGrupo  UNION ALL  SELECT IDGrupo IDCuenta,'' Cuenta,Descr ,'Root' Tag,0 IDGrupo,Tipo  FROM dbo.cntGrupoEstadosFinancieros ) J WHERE J.Tipo = @Tipo ORDER BY Cuenta";
            String sSQL = "SELECT A.IDGrupo,a.IDCuenta,B.Cuenta,B.Descr  FROM dbo.cntCuentaGrupoEstadosFinancieros A INNER JOIN dbo.cntCuenta B ON A.IDCuenta = B.IDCuenta INNER JOIN dbo.cntGrupoEstadosFinancieros C ON A.IDGrupo = C.IDGrupo WHERE C.Tipo=@Tipo";
            SqlCommand oCmd = new SqlCommand(sSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            oCmd.CommandType = CommandType.Text;
            SqlConnection oConn = oCmd.Connection;
            try
            {
                oCmd.Parameters.Add(new SqlParameter("Tipo", sTipo));
                oAdap.Fill(DS, "CuentasEstadosFinancieros");

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
            return DS.Tables[0];

        }

        public static DataTable GetCuentasDisponiblesGrupo(String sTipo)
        {
            int ID = 0;
            DataSet DS = new DataSet();
            String sTipoCuenta ="";

            switch (sTipo) { 
                case "ER":
                    sTipoCuenta="R";
                    break;
                case "BG":
                    sTipoCuenta = "B";
                    break;
            }

             
            String sSQL = "SELECT IDCuenta,Cuenta,A.Descr Descripcion,CASE WHEN AceptaDatos=0 THEN 'Root' ELSE  '' END Tag ,IDCuentaMayor  FROM dbo.cntCuenta A INNER JOIN dbo.cntTipoCuenta T ON A.IDTipo = T.IDTipo  WHERE (T.Tipo=@TipoCuenta OR @TipoCuenta='*') and  IDCuenta NOT IN (SELECT IDCuenta FROM dbo.cntCuentaGrupoEstadosFinancieros A INNER JOIN dbo.cntGrupoEstadosFinancieros B ON	A.IDGrupo = B.IDGrupo WHERE B.Tipo=@Tipo) ORDER BY Cuenta";

            SqlCommand oCmd = new SqlCommand(sSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            oCmd.CommandType = CommandType.Text;
            SqlConnection oConn = oCmd.Connection;
            try
            {
                oCmd.Parameters.Add(new SqlParameter("@Tipo", sTipo));
                oCmd.Parameters.Add(new SqlParameter("@TipoCuenta", sTipoCuenta));
                oAdap.Fill(DS, "Cuentas");

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
            return DS.Tables[0];

        }

        public static DataSet GetData(String Tipo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@Tipo"].Value = Tipo;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }




    }
}
