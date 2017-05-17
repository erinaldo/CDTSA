using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{

    public static class TipoCuentaDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDTipo,Descr,Tipo,Activo  FROM dbo.cntTipoCuenta";
            
            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    
                };

                //Paremetros Select 
                //oAdaptador.SelectCommand.Parameters.Add("@IDCentro", SqlDbType.Int).SourceColumn = "IDCentro";
                //oAdaptador.SelectCommand.Parameters.Add("@Nivel1", SqlDbType.NChar).SourceColumn = "Nivel1";
                //oAdaptador.SelectCommand.Parameters.Add("@Nivel2", SqlDbType.NChar).SourceColumn = "Nivel2";
                //oAdaptador.SelectCommand.Parameters.Add("@Nivel3", SqlDbType.NChar).SourceColumn = "Nivel3";
                //oAdaptador.SelectCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                //oAdaptador.SelectCommand.Parameters.Add("@Acumulador", SqlDbType.Int).SourceColumn = "Acumulador";



               
                return oAdaptador;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        
        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData()
        {
            DataSet DS = CreateDataSet();
            //oAdaptador.SelectCommand.Parameters["@IDCentro"].Value = IDCentro;
            //oAdaptador.SelectCommand.Parameters["@Nivel1"].Value = Nivel1;
            //oAdaptador.SelectCommand.Parameters["@Nivel2"].Value = Nivel2;
            //oAdaptador.SelectCommand.Parameters["@Nivel3"].Value = Nivel3;
            //oAdaptador.SelectCommand.Parameters["@Descr"].Value = Descr;
            //oAdaptador.SelectCommand.Parameters["@Acumulador"].Value = Acumulador;

            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
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
