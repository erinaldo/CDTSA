using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{

    public static class GrupoDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDGrupo,Nivel1,Descr,UsaComplementaria,IDTipo,IDSubTipo,Activo  FROM dbo.cntGrupoCuenta WHERE (IDTipo=@IDTipo OR @IDTipo=-1) AND (IDSubTipo=@IDSubTipo OR @IDSubTipo=-1) AND (IDGrupo=@IDGrupo OR @IDGrupo=-1)";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),

                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
                oAdaptador.SelectCommand.Parameters.Add("@IDSubTipo", SqlDbType.Int).SourceColumn = "IDSubTipo";
                oAdaptador.SelectCommand.Parameters.Add("@IDGrupo", SqlDbType.Int).SourceColumn = "IDGrupo";
                
                return oAdaptador;
            }
            catch (Exception)
            {
                throw;
            }
        }




        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData(int IDTipo,int IDSubTipo,int IDGrupo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDTipo"].Value = IDTipo;
            oAdaptador.SelectCommand.Parameters["@IDSubTipo"].Value = IDSubTipo;
            oAdaptador.SelectCommand.Parameters["@IDGrupo"].Value = IDGrupo;
            
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
