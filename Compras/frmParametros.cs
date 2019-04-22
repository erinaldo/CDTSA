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
            DataTable dt = DAC.clsParametrosDAC.Get().Tables[0];
            this.slkupSolicitud.EditValue = Convert.ToInt32(dt.Rows[0]["IDConsecSolicitud"]);
            this.slkupOrdenCompra.EditValue = Convert.ToInt32(dt.Rows[0]["IDConsecOrdenCompra"]);
            this.slkupEmbarque.EditValue = Convert.ToInt32(dt.Rows[0]["IDConsecEmbarque"]);
            this.slkupDevolucion.EditValue = Convert.ToInt32(dt.Rows[0]["IDConsecDevolucion"]);
            this.txtCantDecimalesCantidad.EditValue = Convert.ToInt32(dt.Rows[0]["CantLineasOrdenCompra"]);
            this.slkupBodegaDefault.EditValue = Convert.ToInt32(dt.Rows[0]["IDBodegaDefault"]);
            this.slkupTipoCambio.EditValue = Convert.ToInt32(dt.Rows[0]["IDTipoCambio"]);
            this.slkupTipoAsientoContable.EditValue = Convert.ToInt32(dt.Rows[0]["IDTipoAsientoContable"]);
            this.slkupPaquete.EditValue = Convert.ToInt32(dt.Rows[0]["IDPaquete"]);
            this.slkupCuentaTransLoc.EditValue = Convert.ToInt64(dt.Rows[0]["CtaTransitoLocal"]);
            this.slkupCentroTransitoLoc.EditValue = Convert.ToInt64(dt.Rows[0]["CtroTransitoLocal"]);
            this.slkupCuentaTransExt.EditValue = Convert.ToInt64(dt.Rows[0]["CtaTransitoExterior"]);
            this.slkupCentroTransitoExt.EditValue = Convert.ToInt64(dt.Rows[0]["CtroTransitoExterior"]);
            this.chkAplicaAutomatico.EditValue = Convert.ToBoolean(dt.Rows[0]["AplicaAutomaticamenteAsiento"]);
            this.chkModificar.EditValue = Convert.ToBoolean(dt.Rows[0]["CanEditAsiento"]);
            this.chkVisualizar.EditValue = Convert.ToBoolean(dt.Rows[0]["CanViewAsiento"]);
            this.txtCantDecimalesCantidad.EditValue = Convert.ToInt32(dt.Rows[0]["CantDecimalesCantidad"]);
            this.txtCantDecimalesPrecio.EditValue = Convert.ToInt32(dt.Rows[0]["CantDecimalesPrecio"]);
            this.txtNumMaxLineasOrden.EditValue = Convert.ToInt32(dt.Rows[0]["CantLineasOrdenCompra"]);

        }
        private void frmParametros_Load(object sender, EventArgs e)
        {
            CargarParametros();
        }


        

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int IDSolicitud, IdOrdenCompra, IDEmbarque, IDDevolucion, CantLineasOrdenCompra, IDBodegaDefault, 
                IDTipoCambio, CantDecimalesPrecio, CantDecimalesCantidad, IDTipoAsientoContable, IDPaquete;
            long CtaTransitoLocal, CtaTransitoDol, CtrTransitoLocal, CtrTransitoDol;
            bool AplicaAutomaticamenteAsiento, CanEditAsiento, CanViewAsiento;

            try
            {
                IDSolicitud = Convert.ToInt32(this.slkupSolicitud.EditValue);
                IdOrdenCompra = Convert.ToInt32(this.slkupOrdenCompra.EditValue);
                IDDevolucion = Convert.ToInt32(this.slkupDevolucion.EditValue);
                IDEmbarque = Convert.ToInt32(this.slkupEmbarque.EditValue);
                CantLineasOrdenCompra = Convert.ToInt32(this.txtNumMaxLineasOrden.EditValue);
                IDBodegaDefault = Convert.ToInt32(this.slkupBodegaDefault.EditValue);
                IDTipoCambio = Convert.ToInt32(this.slkupTipoCambio.EditValue);
                CantDecimalesPrecio = Convert.ToInt32(this.txtCantDecimalesPrecio.EditValue);
                CantDecimalesCantidad = Convert.ToInt32(this.txtCantDecimalesCantidad.EditValue);
                IDTipoAsientoContable = Convert.ToInt32(this.slkupTipoAsientoContable.EditValue);
                IDPaquete = Convert.ToInt32(this.slkupPaquete.EditValue);
                CtaTransitoLocal = Convert.ToInt64(this.slkupCuentaTransLoc.EditValue);
                CtrTransitoLocal = Convert.ToInt64(this.slkupCentroTransitoLoc.EditValue);
                CtaTransitoDol = Convert.ToInt64(this.slkupCuentaTransExt.EditValue);
                CtrTransitoDol = Convert.ToInt64(this.slkupCentroTransitoExt.EditValue);
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
