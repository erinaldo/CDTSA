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
            this.slkupSolicitud.EditValueChanged += slkupSolicitud_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupEmbarque, DAC.clsGlobalConsecutivosDAC.Get(-1, "*").Tables[0], "Descr", "IDConsecutivo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupEmbarque, "[{'ColumnCaption':'IDConsecutivo','ColumnField':'IDConsecutivo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupEmbarque.EditValueChanged += slkupEmbarque_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupOrdenCompra, DAC.clsGlobalConsecutivosDAC.Get(-1, "*").Tables[0], "Descr", "IDConsecutivo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupOrdenCompra, "[{'ColumnCaption':'IDConsecutivo','ColumnField':'IDConsecutivo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupOrdenCompra.EditValueChanged += slkupOrdenCompra_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupDevolucion, DAC.clsGlobalConsecutivosDAC.Get(-1, "*").Tables[0], "Descr", "IDConsecutivo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupDevolucion, "[{'ColumnCaption':'IDConsecutivo','ColumnField':'IDConsecutivo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupDevolucion.EditValueChanged += slkupDevolucion_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupBodegaDefault, CI.DAC.clsBodegaDAC.GetData(-1,"*",-1).Tables[0], "Descr", "IDBodega", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupBodegaDefault, "[{'ColumnCaption':'IDBodega','ColumnField':'IDBodega','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupBodegaDefault.EditValueChanged += slkupBodegaDefault_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupTipoCambio, CG.TipoCambioDAC.GetData("*").Tables[0], "Descr", "IDTipoCambio", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoCambio, "[{'ColumnCaption':'IDTipoCambio','ColumnField':'IDTipoCambio','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");

            Util.Util.ConfigLookupEdit(this.slkupTipoAsientoContable, CG.TipoAsientoDAC.GetData().Tables[0], "Descr", "Tipo", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupTipoAsientoContable, "[{'ColumnCaption':'Tipo','ColumnField':'Tipo','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupTipoAsientoContable.EditValueChanged += slkupTipoAsientoContable_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupPaquete, CI.DAC.clsPaqueteDAC.GetData(-1,"*","*",-1,"*",1).Tables[0], "Descr", "IDPaquete", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupPaquete, "[{'ColumnCaption':'Paquete','ColumnField':'PAQUETE','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupPaquete.EditValueChanged += slkupPaquete_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupCuentaTransExt, CG.CuentaContableDAC.GetData(-1,-1,-1,"*","*","*","*","*","*","*",-1,-1,-1,1,-1,1).Tables[0], "Cuenta", "IDCuenta", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaTransExt, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupCuentaTransExt.EditValueChanged += slkupCuentaTransExt_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupCuentaTransLoc, CG.CuentaContableDAC.GetData(-1, -1, -1, "*", "*", "*", "*", "*", "*", "*", -1, -1, -1, 1, -1, 1).Tables[0], "Cuenta", "IDCuenta", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCuentaTransLoc, "[{'ColumnCaption':'Cuenta','ColumnField':'Cuenta','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupCuentaTransLoc.EditValueChanged += slkupCuentaTransLoc_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupCentroTransitoExt, CG.CentroCostoDAC.GetData(-1,"*","*","*","*",0).Tables[0], "Centro", "IDCentro", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroTransitoExt, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupCentroTransitoExt.EditValueChanged += slkupCentroTransitoExt_EditValueChanged;

            Util.Util.ConfigLookupEdit(this.slkupCentroTransitoLoc, CG.CentroCostoDAC.GetData(-1, "*", "*", "*", "*", 0).Tables[0], "Centro", "IDCentro", 350);
            Util.Util.ConfigLookupEditSetViewColumns(this.slkupCentroTransitoLoc, "[{'ColumnCaption':'Centro','ColumnField':'Centro','width':20},{'ColumnCaption':'Descripción','ColumnField':'Descr','width':90}]");
            this.slkupCentroTransitoLoc.EditValueChanged += slkupCentroTransitoLoc_EditValueChanged;

            CargarParametros();
        }

        void slkupCentroTransitoLoc_EditValueChanged(object sender, EventArgs e)
        {
             DataTable dt = (DataTable)this.slkupCentroTransitoLoc.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDCentro='" + this.slkupCentroTransitoLoc.EditValue + "'";
            this.txtDescrCentroTranLoc.Text = dv.ToTable().Rows[0]["Descr"].ToString();
        }

        void slkupCentroTransitoExt_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupCentroTransitoExt.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDCentro='" + this.slkupCentroTransitoExt.EditValue + "'";
            this.txtDescrCentroTranExt.Text = dv.ToTable().Rows[0]["Descr"].ToString();
        }

        void slkupCuentaTransLoc_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupCuentaTransLoc.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDCuenta='" + this.slkupCuentaTransLoc.EditValue + "'";
            this.txtDescrCuentaTransLoc.Text = dv.ToTable().Rows[0]["Descr"].ToString();
        }

        void slkupCuentaTransExt_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupCuentaTransExt.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDCuenta='" + this.slkupCuentaTransExt.EditValue + "'";
            this.txtDescrCuentaTransExt.Text = dv.ToTable().Rows[0]["Descr"].ToString();
        }

        void slkupDevolucion_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupDevolucion.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDConsecutivo='" + this.slkupDevolucion.EditValue + "'";
            this.txtConsecutivoDev.Text = dv.ToTable().Rows[0]["Consecutivo"].ToString();
        }

        void slkupOrdenCompra_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupOrdenCompra.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDConsecutivo='" + this.slkupOrdenCompra.EditValue + "'";
            this.txtConsecutivoOC.Text = dv.ToTable().Rows[0]["Consecutivo"].ToString();
        }

        void slkupEmbarque_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupEmbarque.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDConsecutivo='" + this.slkupEmbarque.EditValue + "'";
            this.txtConsecutivoEmbarque.Text = dv.ToTable().Rows[0]["Consecutivo"].ToString();
        }

        void slkupPaquete_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupPaquete.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDPaquete='" + this.slkupPaquete.EditValue + "'";
            this.txtDescrPaquete.Text = dv.ToTable().Rows[0]["Descr"].ToString();
        }

        void slkupTipoAsientoContable_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupTipoAsientoContable.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "Tipo='" + this.slkupTipoAsientoContable.EditValue + "'";
            this.txtDescrTipoAsientoContable.Text = dv.ToTable().Rows[0]["Descr"].ToString();
        }

        void slkupBodegaDefault_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupBodegaDefault.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDBodega='" + this.slkupBodegaDefault.EditValue + "'";
            this.txtDescrBodegaDefault.Text = dv.ToTable().Rows[0]["Descr"].ToString();
        }

        void slkupSolicitud_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.slkupSolicitud.Properties.DataSource;
            DataView dv = new DataView(dt);
            dv.RowFilter = "IDConsecutivo='" + this.slkupSolicitud.EditValue + "'";
            this.txtConsecutivoSol.Text = dv.ToTable().Rows[0]["Consecutivo"].ToString();
        }


        

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int? IDSolicitud, IdOrdenCompra, IDEmbarque, IDDevolucion, IDBodegaDefault,IDPaquete;
            int CantLineasOrdenCompra,CantDecimalesPrecio, CantDecimalesCantidad;
            long? CtaTransitoLocal, CtaTransitoDol, CtrTransitoLocal, CtrTransitoDol;
            String IDTipoCambio, IDTipoAsientoContable;
            bool AplicaAutomaticamenteAsiento, CanEditAsiento, CanViewAsiento;

            try
            {
                IDSolicitud = (int?)this.slkupSolicitud.EditValue;
                IdOrdenCompra = (int?)this.slkupOrdenCompra.EditValue;
                IDDevolucion = (int?) this.slkupDevolucion.EditValue;
                IDEmbarque = (int?)this.slkupEmbarque.EditValue;
                CantLineasOrdenCompra = Convert.ToInt32(this.txtNumMaxLineasOrden.EditValue);
                IDBodegaDefault = (int?)this.slkupBodegaDefault.EditValue;
                IDTipoCambio = this.slkupTipoCambio.EditValue.ToString();
                CantDecimalesPrecio = Convert.ToInt32(this.txtCantDecimalesPrecio.EditValue);
                CantDecimalesCantidad = Convert.ToInt32(this.txtCantDecimalesCantidad.EditValue);
                IDTipoAsientoContable = this.slkupTipoAsientoContable.EditValue.ToString();
                IDPaquete = (int?)this.slkupPaquete.EditValue;
                CtaTransitoLocal = (this.slkupCuentaTransLoc.EditValue == null ? -1 : Convert.ToInt64(this.slkupCuentaTransLoc.EditValue));
                CtrTransitoLocal = (this.slkupCentroTransitoLoc.EditValue == null ? -1 : Convert.ToInt64(this.slkupCentroTransitoLoc.EditValue));
                CtaTransitoDol = (this.slkupCuentaTransExt.EditValue == null ? -1 : Convert.ToInt64(this.slkupCuentaTransExt.EditValue));
                CtrTransitoDol = (this.slkupCentroTransitoExt.EditValue == null ? -1 : Convert.ToInt64( this.slkupCentroTransitoExt.EditValue));
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
