using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CG
{
    public static class PeriodoContableDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();

        private static SqlDataAdapter InicializarAdaptador()
        {
            String getSQL = "SELECT IDEjercicio, Periodo, FechaFinal, Descr, FinPeriodoFiscal, Cerrado, AjustesCierreFiscal, Activo, PeriodoTrabajo " +
                            "FROM dbo.cntPeriodoContable WHERE (IDEjercicio = @IDEjercicio OR @IDEjercicio = -1) AND(Periodo = @Periodo OR @Periodo = '*')";
            
            //String InsertSQL = "[dbo].[cntUpdateCentroCosto]";
            //String UpdateSQL = "[dbo].[cntUpdateCentroCosto]";
            //String DeleteSQL = "[dbo].[cntUpdateCentroCosto]";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    
                };

                //Paremetros Select 
                oAdaptador.SelectCommand.Parameters.Add("@IDEjercicio", SqlDbType.Int).SourceColumn = "IDEjercicio";
                oAdaptador.SelectCommand.Parameters.Add("@Periodo", SqlDbType.NChar).SourceColumn = "Periodo";
                


                
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

        public static DataSet GetData(int IDEjercicio, String Periodo)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDEjercicio"].Value = IDEjercicio;
            oAdaptador.SelectCommand.Parameters["@Periodo"].Value = Periodo;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }


    }
}
