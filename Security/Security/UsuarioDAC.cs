using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using System.Data;
using System.Data.SqlClient;

namespace Security
{

    public static class UsuarioDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();
        public static DataSet _DS = new DataSet();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT USUARIO,DESCR  FROM secUSUARIO " +
                              "WHERE USUARIO = @Usuario AND[PASSWORD] = @Contrasena   AND ACTIVO = 1";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar).SourceColumn = "Usuario";
                oAdaptador.SelectCommand.Parameters.Add("@Contrasena", SqlDbType.NVarChar).SourceColumn = "PASSWORD";


                return oAdaptador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void SetDataSetUsuario(DataSet pDS)
        {
            _DS = pDS;
        }



        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet ValidaUsuario(String Usuario,String Contrasena)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@Usuario"].Value = Usuario;
            oAdaptador.SelectCommand.Parameters["@Contrasena"].Value = Contrasena;
        
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static DataSet GetAccionModuloFromRole(int IDModulo, string Usuario)
        {
            
            String strSQL = "dbo.secGetAccionesFromModuloUsuario";
            DataSet DS = new DataSet();
            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            try
            {
                SqlDataAdapter oAdapter = new SqlDataAdapter(oCmd);

                oCmd.Parameters.Add("@IDModulo", SqlDbType.Int).Value = IDModulo;
                oCmd.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = Usuario;
                oCmd.CommandType = CommandType.StoredProcedure;

                oAdapter.Fill(DS, "Data");
               
                return DS;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }

        public static void ResetConnecion(){
            oAdaptador = InicializarAdaptador();
        }

        public static bool PermiteAccion(int IDAccion, DataTable DT)
        {
            DataView dv = new DataView();
            dv.Table = DT;
            dv.RowFilter = "IDAccion=" + IDAccion.ToString();
            return (dv.ToTable().Rows.Count > 0);
        }
    }
}
