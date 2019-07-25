using Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CP.DAC;
using CG;
using System.Security.Util;

namespace CP
{
    public partial class frmDocumento : DevExpress.XtraBars.Ribbon.RibbonForm
    {


        private DataTable _dtClaseDocumentoCredito;
        private DataTable _dtClaseDocumentoDebito;
        private DataTable _dtSubTipoDocumentoCredito;
        private DataTable _dtSubTipoDocumentoDebito;
        private DataTable _dtSecurity;

        private DataRow _currentRow;
        private String Accion = "NEW";
        private bool _ShowLessColumns = false;
        private bool _DonCloseCuadre = false;
        private String _Estado = "";

        String sUsuario = (UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "azepeda";
        String _Asiento = "";
        String _ModuloFuente = "";
        String _tituloVentana = "Asiento";
        double _TipoCambio = 0;

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, sUsuario);
            _dtSecurity = DS.Tables[0];

        }

        private void AplicarPrivilegios()
        {

            //if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EditarAsientodeDiario, _dtSecurity))
            //{
            //    if (_dsAsiento.Tables[0].Rows.Count > 0 && Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
            //        this.btnEditar.Enabled = false;
            //    else
            //        this.btnEditar.Enabled = true;
            //}
            //else
            //    this.btnEditar.Enabled = false;

            //if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.EliminarAsientodeDiario, _dtSecurity))
            //{
            //    if (_dsAsiento.Tables[0].Rows.Count > 0 && Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
            //        this.btnEliminar.Enabled = false;
            //    else
            //        this.btnEliminar.Enabled = true;
            //}
            //else
            //    this.btnEliminar.Enabled = false;



            //if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.MayorizarAsientodeDiario, _dtSecurity))
            //{
            //    if (_dsAsiento.Tables[0].Rows.Count > 0 && Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
            //        this.btnMayorizar.Enabled = false;
            //    else
            //        this.btnMayorizar.Enabled = true;
            //}
            //else
            //    this.btnMayorizar.Enabled = false;

            //if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AnularAsientoMayorizado, _dtSecurity))
            //{
            //    if (_dsAsiento.Tables[0].Rows.Count > 0 && Convert.ToBoolean(_dsAsiento.Tables[0].Rows[0]["Mayorizado"]) == true)
            //        this.btnAnular.Enabled = true;
            //    else
            //        this.btnAnular.Enabled = false;
            //}
            //else
            //    this.btnAnular.Enabled = false;

        }

           
        public frmDocumento()
        {
            InitializeComponent();
            
            Accion = "New";
            //Obtener el Siguiente consecutivo de la solicitud"

            _dtClaseDocumentoCredito = clsClaseDocumentoDAC.Get("C", "*", "*").Tables[0];
            _dtClaseDocumentoDebito = clsClaseDocumentoDAC.Get("D", "*", "*").Tables[0];




            //_dtCentrosConstante = _dtCentros.Clone();
            Util.Util.ConfigLookupEdit(this.slkupSubTipoClaseDebito, _dtClaseDocumentoDebito, "Descr", "IDClase", 300, 300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupSubTipoClaseDebito, "[{'ColumnCaption':'IDClase','ColumnField':'IDClase','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");

            Util.Util.ConfigLookupEdit(this.slkupClaseCredito, _dtClaseDocumentoDebito, "Descr", "IDClase", 300, 300);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupClaseCredito, "[{'ColumnCaption':'IDClase','ColumnField':'IDClase','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");
            

             this.StartPosition = FormStartPosition.CenterScreen;
           
        }


        public frmDocumento(int IDDocumentoCP, int IDProveedor, string TipoDocumento,string IDClase, int IDSubTipo)
        {
            InitializeComponent();
            
           // CargarDocumento(IDDocumentoCP, IDProveedor,TipoDocumento,IDClase,IDSubTipo);
        }


        private void InicializarNuevoElemento()
        {
            
            DataSet DS = new DataSet();
            //Cargar el tipo de cambio por defecto
            String sTipoCambio = ParametrosContabilidadDAC.GetTipoCambioModulo();
            DS = TipoCambioDetalleDAC.GetData(sTipoCambio, DateTime.Now);

           

        }

        private void slkupClaseCredito_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupClaseCredito.EditValue != null)
            {

                _dtSubTipoDocumentoCredito = clsSubTipoDocumentoDAC.Get(-1,"C",this.slkupClaseCredito.EditValue.ToString(), "*").Tables[0];

                ////_dtCentrosConstante = _dtCentros.Clone();
                Util.Util.ConfigLookupEdit(this.slkupSubTipoDocumentoCredito, _dtSubTipoDocumentoCredito, "Descr", "IDSubTipo", 300, 300);
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupSubTipoDocumentoCredito, "[{'ColumnCaption':'IDSubTipo','ColumnField':'IDSubTipo','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");
            }
        }

        private void slkupSubTipoClaseDebito_EditValueChanged(object sender, EventArgs e)
        {
            if (this.slkupSubTipoClaseDebito.EditValue != null)
            {

                _dtSubTipoDocumentoDebito = clsSubTipoDocumentoDAC.Get(-1,"D", this.slkupSubTipoClaseDebito.EditValue.ToString(), "*").Tables[0];

                ////_dtCentrosConstante = _dtCentros.Clone();
                Util.Util.ConfigLookupEdit(this.slkupSubTipoDocumentoDebito, _dtSubTipoDocumentoDebito, "Descr", "IDSubTipo", 300, 300);
                Util.Util.ConfigLookupEditSetViewColumns(this.slkupSubTipoDocumentoDebito, "[{'ColumnCaption':'IDSubTipo','ColumnField':'IDSubTipo','width':30},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':70}]");
            }
        }

    }
}
