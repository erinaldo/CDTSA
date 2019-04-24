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

namespace CO
{
    public partial class frmParametros : Form
    {
        public frmParametros()
        {
            InitializeComponent();
        }


        private void CargarParametros() {
            try
            {
                DataTable dt = DAC.clsParametrosDAC.Get().Tables[0];
                this.slkupSolicitud.EditValue = dt.Rows[0]["IDConsecSolicitud"] == DBNull.Value ? null : dt.Rows[0]["IDConsecSolicitud"] ;
                this.slkupOrdenCompra.EditValue = dt.Rows[0]["IDConsecOrdenCompra"] == DBNull.Value ? null : dt.Rows[0]["IDConsecOrdenCompra"];
                this.slkupEmbarque.EditValue = dt.Rows[0]["IDConsecEmbarque"] == DBNull.Value ? null : dt.Rows[0]["IDConsecEmbarque"];
                this.slkupDevolucion.EditValue = dt.Rows[0]["IDConsecDevolucion"] == DBNull.Value ? null : dt.Rows[0]["IDConsecDevolucion"];
                this.txtCantDecimalesCantidad.EditValue = Convert.ToInt32(dt.Rows[0]["CantLineasOrdenCompra"]);
                this.slkupBodegaDefault.EditValue = dt.Rows[0]["IDBodegaDefault"] == DBNull.Value ?  null : dt.Rows[0]["IDBodegaDefault"];
                this.slkupTipoCambio.EditValue = dt.Rows[0]["IDTipoCambio"] == DBNull.Value ? null : dt.Rows[0]["IDTipoCambio"];
                this.slkupTipoAsientoContable.EditValue = dt.Rows[0]["IDTipoAsientoContable"] == DBNull.Value ? null : dt.Rows[0]["IDTipoAsientoContable"];
                this.slkupPaquete.EditValue = dt.Rows[0]["IDPaquete"] == DBNull.Value ? null : dt.Rows[0]["IDPaquete"];
                this.slkupCuentaTransLoc.EditValue = dt.Rows[0]["CtaTransitoLocal"] == DBNull.Value ? null : dt.Rows[0]["CtaTransitoLocal"];
                this.slkupCentroTransitoLoc.EditValue = dt.Rows[0]["CtrTransitoLocal"] == DBNull.Value ? null : dt.Rows[0]["CtrTransitoLocal"];
                this.slkupCuentaTransExt.EditValue = dt.Rows[0]["CtaTransitoExterior"] == DBNull.Value ? null : dt.Rows[0]["CtaTransitoExterior"];
                this.slkupCentroTransitoExt.EditValue = dt.Rows[0]["CtrTransitoExterior"] == DBNull.Value ? null : dt.Rows[0]["CtrTransitoExterior"];
                this.chkAplicaAutomatico.EditValue = Convert.ToBoolean(dt.Rows[0]["AplicaAutomaticamenteAsiento"]);
                this.chkModificar.EditValue = Convert.ToBoolean(dt.Rows[0]["CanEditAsiento"]);
                this.chkVisualizar.EditValue = Convert.ToBoolean(dt.Rows[0]["CanViewAsiento"]);
                this.txtCantDecimalesCantidad.EditValue = Convert.ToInt32(dt.Rows[0]["CantDecimalesCantidad"]);
                this.txtCantDecimalesPrecio.EditValue = Convert.ToInt32(dt.Rows[0]["CantDecimalesPrecio"]);
                this.txtNumMaxLineasOrden.EditValue = Convert.ToInt32(dt.Rows[0]["CantLineasOrdenCompra"]);
            }
            catch (Exception ex) {
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }
        }
        private void frmParametros_Load(object sender, EventArgs e)
        {
            //Cargar los valores de las listas
            Util.Util.ConfigLookupEdit(this.slkupSolicitud, DAC.clsGlobalConsecutivosDAC.Get(-1, "*").Tables[0], "Descr", "IDConsecutivo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupSolicitud, "[{'ColumnCaption':'IDConsecutivo','ColumnField':'IDConsecutivo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupEmbarque, DAC.clsGlobalConsecutivosDAC.Get(-1, "*").Tables[0], "Descr", "IDConsecutivo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupEmbarque, "[{'ColumnCaption':'IDConsecutivo','ColumnField':'IDConsecutivo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupOrdenCompra, DAC.clsGlobalConsecutivosDAC.Get(-1, "*").Tables[0], "Descr", "IDConsecutivo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupOrdenCompra, "[{'ColumnCaption':'IDConsecutivo','ColumnField':'IDConsecutivo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupDevolucion, DAC.clsGlobalConsecutivosDAC.Get(-1, "*").Tables[0], "Descr", "IDConsecutivo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupDevolucion, "[{'ColumnCaption':'IDConsecutivo','ColumnField':'IDConsecutivo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupBodegaDefault, CI.DAC.clsBodegaDAC.GetData(-1,"*",-1).Tables[0], "Descr", "IDBodega", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodegaDefault, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupTipoCambio, CG.TipoCambioDAC.GetData("*").Tables[0], "Descr", "IDTipoCambio", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoCambio, "[{'ColumnCaption':'IDTipoCambio','ColumnField':'IDTipoCambio','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupTipoAsientoContable, CG.TipoAsientoDAC.GetData().Tables[0], "Descr", "Tipo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoAsientoContable, "[{'ColumnCaption':'Tipo','ColumnField':'Tipo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupPaquete, CI.DAC.clsPaqueteDAC.GetData(-1,"*","*",-1,"*",1).Tables[0], "Descr", "PAQUETE", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupPaquete, "[{'ColumnCaption':'Paquete','ColumnField':'PAQUETE','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupCuentaTransExt, CG.CuentaContableDAC.GetData(-1,-1,-1,"*","*","*","*","*","*","*",-1,-1,-1,1,-1,1).Tables[0], "Descr", "Cuenta", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaTransExt, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupCuentaTransLoc, CG.CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", "*", -1, -1, -1, 1, -1, 1).Tables[0], "Descr", "Cuenta", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaTransLoc, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupCentroTransitoExt, CG.CentroCostoDAC.GetData(-1,"*","*","*","*",0).Tables[0], "Descr", "IDCuenta", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroTransitoExt, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupCentroTransitoLoc, CG.CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0], "Descr", "IDCentro", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroTransitoLoc, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            CargarParametros();
        }


        

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int? IDSolicitud, IdOrdenCompra, IDEmbarque, IDDevolucion, IDBodegaDefault, IDTipoCambio, IDTipoAsientoContable, IDPaquete;
            int CantLineasOrdenCompra,CantDecimalesPrecio, CantDecimalesCantidad;
            long? CtaTransitoLocal, CtaTransitoDol, CtrTransitoLocal, CtrTransitoDol;
            bool AplicaAutomaticamenteAsiento, CanEditAsiento, CanViewAsiento;

            try
            {
                IDSolicitud = (int?)this.slkupSolicitud.EditValue;
                IdOrdenCompra = (int?)this.slkupOrdenCompra.EditValue;
                IDDevolucion = (int?) this.slkupDevolucion.EditValue;
                IDEmbarque = (int?)this.slkupEmbarque.EditValue;
                CantLineasOrdenCompra = Convert.ToInt32(this.txtNumMaxLineasOrden.EditValue);
                IDBodegaDefault = (int?)this.slkupBodegaDefault.EditValue;
                IDTipoCambio = (int?)this.slkupTipoCambio.EditValue;
                CantDecimalesPrecio = Convert.ToInt32(this.txtCantDecimalesPrecio.EditValue);
                CantDecimalesCantidad = Convert.ToInt32(this.txtCantDecimalesCantidad.EditValue);
                IDTipoAsientoContable = (int?)this.slkupTipoAsientoContable.EditValue;
                IDPaquete = (int?)this.slkupPaquete.EditValue;
                CtaTransitoLocal = (long?)this.slkupCuentaTransLoc.EditValue;
                CtrTransitoLocal = (long?)this.slkupCentroTransitoLoc.EditValue;
                CtaTransitoDol = (long?)this.slkupCuentaTransExt.EditValue;
                CtrTransitoDol = (long?)this.slkupCentroTransitoExt.EditValue;
                AplicaAutomaticamenteAsiento = Convert.ToBoolean(this.chkAplicaAutomatico.EditValue);
                CanEditAsiento = Convert.ToBoolean(this.chkModificar.EditValue);
                CanViewAsiento = Convert.ToBoolean(this.chkVisualizar.EditValue);
                ConnectionManager.BeginTran();
                DAC.clsParametrosDAC.InsertUpdate(IDSolicitud, IdOrdenCompra, IDEmbarque, IDDevolucion, CantLineasOrdenCompra, IDBodegaDefault, IDTipoCambio, CantDecimalesPrecio, CantDecimalesCantidad, IDTipoAsientoContable, IDPaquete, CtaTransitoLocal, CtrTransitoLocal, CtaTransitoDol, CtrTransitoDol, AplicaAutomaticamenteAsiento, CanEditAsiento, CanViewAsiento, ConnectionManager.Tran);
                ConnectionManager.CommitTran();
            }
            catch (Exception ex) {
                ConnectionManager.RollBackTran();
                MessageBox.Show("Han ocurrido los siguientes errores, por favor revisar: "+ ex.Message);
            }
        }
    }
}
