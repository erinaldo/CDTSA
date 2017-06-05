using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{


    public static class AsientoDetalleDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT Asiento,Linea,A.IDCentro,C.Descr DescrCentro,A.IDCuenta,CC.Descr DescrCuenta,Referencia,Debito,Credito,Documento,daterecord  " +
                               "FROM dbo.cntAsientoDetalle a " +
                               "INNER JOIN dbo.cntCentroCosto C ON A.IDCentro=C.IDCentro " +
                                "INNER JOIN dbo.cntCuenta CC ON A.IDCuenta = CC.IDCuenta " +
                                "WHERE(Asiento = @Asiento  OR  @Asiento = '*')  AND(A.IDCuenta = @IDCuenta OR @IDCuenta = -1)  AND(A.IDCentro = @IDCentro OR @IDCentro = -1)"; 
            
            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection())
                    
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@Asiento", SqlDbType.NVarChar).SourceColumn = "Asiento";
                oAdaptador.SelectCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.SelectCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";




                return oAdaptador;
            }
            catch (Exception )
            {
                throw ;
            }
        }



        
        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData(String Asiento,int IDCentro,int IDCuenta)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@Asiento"].Value = Asiento;
            oAdaptador.SelectCommand.Parameters["@IDCentro"].Value = IDCentro;
            oAdaptador.SelectCommand.Parameters["@IDCuenta"].Value = IDCuenta;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


        

        public static DataSet GetDataEmpty()
        {
            String strSQL = "SELECT Asiento,Linea,IDCentro,IDCuenta,Referencia,Debito,Credito,Documento,daterecord  FROM dbo.cntAsientoDetalle WHERE 1=2";

            SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
            SqlDataAdapter oAdaptador = new SqlDataAdapter(oCmd);
            DataSet DS = CreateDataSet();

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        
    }
}
