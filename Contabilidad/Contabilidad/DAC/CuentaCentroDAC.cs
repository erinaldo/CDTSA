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
    public static class CuentaCentroDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT A.IDCentro,A.IDCuenta,C.Centro,C.Descr DescrCentro  FROM dbo.cntCuentaCentro A " +
                                "INNER JOIN dbo.cntCentroCosto C ON A.IDCentro = C.IDCentro " +
                                "INNER JOIN dbo.cntCuenta CC ON A.IDCuenta = CC.IDCuenta " +
                                "WHERE(A.IDCentro = @IDCentro OR @IDCentro = -1)  AND(A.IDCuenta = @IDCuenta OR @IDCuenta = -1)";
            String InsertSQL = "[dbo].[cntUpdateCuentaCentroCosto]";
            String DeleteSQL = "[dbo].[cntUpdateCuentaCentroCosto]";
            
            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    InsertCommand = new SqlCommand(InsertSQL, ConnectionManager.GetConnection()),
                    DeleteCommand = new SqlCommand(DeleteSQL, ConnectionManager.GetConnection())
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";
                oAdaptador.SelectCommand.Parameters.Add("@IDCuenta", SqlDbType.NChar).SourceColumn = "IDCuenta";
                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuenta", SqlDbType.NChar).SourceColumn = "IDCuenta";


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

        public static DataSet GetData(int IDCentro, int  IDCuenta)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDCentro"].Value = IDCentro;
            oAdaptador.SelectCommand.Parameters["@IDCuenta"].Value = IDCuenta;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static DataSet GetEmptyData()
        {
            DataSet DS = new DataSet();
            SqlCommand oCmd = new SqlCommand("SELECT IDCuenta,IDCentro  FROM dbo.cntCuentaCentro where 1=2 " , ConnectionManager.GetConnection());
            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            oAdap.Fill(DS, "Data");
            return DS;
        }


        public static DataSet GetCentroNotInCentroCuenta( int IDCuenta)
        {
            DataSet DS = new DataSet();
            SqlCommand oCmd = new SqlCommand("SELECT IDCentro,Centro, Descr  FROM dbo.cntCentroCosto " +
                                              "WHERE IDCentro NOT IN(SELECT IDCentro  FROM dbo.cntCuentaCentro WHERE IDCuenta = @IDCuenta) AND Acumulador = 0", ConnectionManager.GetConnection());
            oCmd.Parameters.Add("@IDCuenta" , SqlDbType.Int).Value = IDCuenta;
            SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
            oAdap.Fill(DS,"Data");
            return DS;
        }


    }
}
