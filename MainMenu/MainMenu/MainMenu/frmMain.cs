using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using CG;
using Security;

namespace MainMenu
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            //CreateNodes(treeListInventario);
            CreateNodes(treeListContabilidad);
            CreateNodes(treeListAdministracion);
            this.Load += frmMain_Load;
            ShowPagesRibbonMan(false);
        }

        private void enlazarEventos()
        {
            this.treeListContabilidad.DoubleClick -= treeListContabilidad_DoubleClick;
            this.treeListContabilidad.DoubleClick += treeListContabilidad_DoubleClick;

            this.treeListAdministracion.DoubleClick -= treeListAdministracion_DoubleClick;
            this.treeListAdministracion.DoubleClick += treeListAdministracion_DoubleClick;
        }

        void frmMain_Load(object sender, EventArgs e)
        {

            enlazarEventos();
            CargarPrivilegios();
            CargarParametrosSistema();
            CargarConfiguracionRegional();
        }

        private void CargarConfiguracionRegional() {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        private void ObtenerTipoCambio(String TipoCambio) {
            DataSet DS =  CDTSA.DAC.ParametrosGeneralesDAC.GetTipoCambio(TipoCambio, DateTime.Now);
            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                this.lblFecha.Caption = "Fecha: " + Convert.ToDateTime(DS.Tables[0].Rows[0]["Fecha"]).ToShortDateString();
                this.lblTipoCambio.Caption = "TC: " + Convert.ToDecimal(DS.Tables[0].Rows[0]["Monto"]).ToString("N4");

                enlazarEventos();
            }
            else {
                this.lblFecha.Caption = "Fecha: --" ;
                this.lblTipoCambio.Caption = "TC: --" ;
                MessageBox.Show("El tipo de cambio para el dia no esta registrado, por favor contacte el administrador del sistema : \n\r " );
                this.treeListContabilidad.DoubleClick -= treeListContabilidad_DoubleClick;
            }
        }

        private void CargarParametrosSistema() {

            try
            {
                DataSet DS = CDTSA.DAC.ParametrosGeneralesDAC.GetData();
                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                {
                    String sMensaje = "";
                    //Validar los datos de configuracion
                    if (DS.Tables[0].Rows[0]["Compania"].ToString() == "")
                    {
                        sMensaje = sMensaje + " • El nombre de la compania no se ha establecido \n\r";
                        this.lblCompania.Caption = "Compañia: ";
                    }
                    if (DS.Tables[0].Rows[0]["CantDigitosDecimales"].ToString() == "") {
                        sMensaje = sMensaje + " • La cantidad de Digitos de decimales que se visualizan en sistema \n\r";
                    }
                    if (DS.Tables[0].Rows[0]["SimboloMonedaFuncional"].ToString() == "")
                        sMensaje = sMensaje + " • El simbolo de la moneda funcional no se ha establecido \n\r";
                    if (DS.Tables[0].Rows[0]["SimboloMonedaExtrangera"].ToString() == "")
                        sMensaje = sMensaje + " • El simbolo de la moneda extrangera no se ha establecido \n\r";
                    if (DS.Tables[0].Rows[0]["TipoCambio"].ToString() == "")
                        sMensaje = sMensaje + " • El tipo de Cambio con el trabajara el sistema no se ha establecido \n\r";

                    if (sMensaje != "")
                    {
                        
                        this.lblFecha.Caption = "Fecha: --";
                        this.lblTipoCambio.Caption = "TC: --";
                        this.lblCompania.Caption = "Compañia: ";
                        MessageBox.Show("Por favor notifique a su administrador del sistema la validaciion de los siguientes campos: \n\r " + sMensaje);
                        this.treeListContabilidad.DoubleClick -= treeListContabilidad_DoubleClick;
                    }
                    else
                    {
                        String sTipoCambio = "";
                        Util.Util.DecimalLenght = Convert.ToInt32(DS.Tables[0].Rows[0]["CantDigitosDecimales"]);
                        Util.Util.LocalSimbolCurrency = DS.Tables[0].Rows[0]["SimboloMonedaFuncional"].ToString();
                        Util.Util.ForeingSimbolCurrency = DS.Tables[0].Rows[0]["SimboloMonedaExtrangera"].ToString();
                        sTipoCambio = DS.Tables[0].Rows[0]["TipoCambio"].ToString();
                        ObtenerTipoCambio(sTipoCambio);
                        this.lblCompania.Caption = "Compañia: " + DS.Tables[0].Rows[0]["Compania"].ToString();
                        
                    }
                }
                else {
                    MessageBox.Show("Los parametros generales de la aplicacion estan incompletos, por favor contacte al administrador del sistema");
                    //Quitar  todas las acciones a los menus.
                    this.treeListContabilidad.DoubleClick -= treeListContabilidad_DoubleClick;
                }
                this.lblUsuario.Caption = "Usuario: " + ((UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    

        void treeListAdministracion_DoubleClick(object sender, EventArgs e)
        {
             DevExpress.XtraTreeList.Nodes.TreeListNode node = default(DevExpress.XtraTreeList.Nodes.TreeListNode);
            node = ((TreeList)sender).FocusedNode;
            switch (node.Tag.ToString())
            {
                case "optParametrosGenerales":
                    CDTSA.frmParametrosGenerales ofrmParametrosGenerales = new CDTSA.frmParametrosGenerales();
                    ofrmParametrosGenerales.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmParametrosGenerales.FormClosed+=ofrmParametrosGenerales_FormClosed;
                    ofrmParametrosGenerales.Show();
                    break;

            }
        }

        
        private void SetNodeDisable(String Tag){
            try
            {
                foreach (TreeListNode node in treeListContabilidad.Nodes)
                    if (node.Tag.ToString() == Tag)
                        node.Visible = false;
        //                node.TreeList.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarPrivilegios()
        {
            DataSet DS = new DataSet();
            DataTable DT = new DataTable();
            DS = UsuarioDAC.GetAccionModuloFromRole(0, UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString());
            DT = DS.Tables[0];
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosType.CatalogoCuentaContable, DT))
                SetNodeDisable("optCuenta");
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosType.CatalogoCentroCosto, DT))
                SetNodeDisable("optCentroCosto");  
            if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosType.AsientodeDiario, DT))
                SetNodeDisable("optTransaccionesDiario");  
            
          
        }

        void treeListContabilidad_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node = default(DevExpress.XtraTreeList.Nodes.TreeListNode);
            node = ((TreeList)sender).FocusedNode;
            switch (node.Tag.ToString())
            {
                case "optCuenta":
                    frmListadoCuentaContable ofrmCuenta = new frmListadoCuentaContable();
                    ofrmCuenta.MdiParent = this;
                    ofrmCuenta.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmCuenta.Show();
                    break;
                 case "optCentroCosto":
                    frmListadoCentroCosto ofrmCentro = new frmListadoCentroCosto();
                    ofrmCentro.MdiParent = this;
                    ofrmCentro.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmCentro.Show();
                    break;
                 case "optTransaccionesDiario":
                    frmListadoAsientoDiario ofrmListadoAsientoDiario = new frmListadoAsientoDiario();
                    ofrmListadoAsientoDiario.MdiParent = this;
                    ofrmListadoAsientoDiario.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmListadoAsientoDiario.Show();
                    break;
                case "optParametrosModuloContable":
                    frmParametrosContables ofrmParametrosContabilidad = new frmParametrosContables();
                    ofrmParametrosContabilidad.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmParametrosContabilidad.Show();
                    break;
                case "optAbrirPeriodosCerrados":
                    frmListadoPeriodos ofrmListadoPeriodos = new frmListadoPeriodos();
                    ofrmListadoPeriodos.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmListadoPeriodos.Show();
                    break;
                
            }

        }

        void ofrmParametrosGenerales_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Recargar los parametros del sistema
            CargarParametrosSistema();
        }



        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a child node for the node1
            switch (tl.Name)
            {
                case "treeListInventario":
                    TreeListNode nodeArticulo = tl.AppendNode(new object[] { "Articulo" }, -1, 11, 11, 11);
                    nodeArticulo.Tag = "optArticulo";
                    
                    TreeListNode nodeLotes = tl.AppendNode(new object[] { "Lotes" }, -1, 11, 11, 11);
                    nodeLotes.Tag = "optLote";
                    TreeListNode nodeTransacciones = tl.AppendNode(new object[] { "Transacciones" }, -1, 9, 10, 9);
                    TreeListNode nodeEjemplo = tl.AppendNode(new object[] { "Ejemplo" }, nodeTransacciones.Id, 11, 11, 11);
                    nodeEjemplo.Tag = "optEjemplo";
                    TreeListNode nodeConsultas = tl.AppendNode(new object[] { "Consultas" }, -1, 9, 10, 9);
                    TreeListNode nodeConsultaArticulos = tl.AppendNode(new object[] { "Articulos" }, nodeConsultas.Id, 11, 11, 11);
                    nodeConsultaArticulos.Tag = "optConsultaArticulo";
                    TreeListNode nodeConsultaExistencias = tl.AppendNode(new object[] { "Existencias" }, nodeConsultas.Id, 9, 10, 9);
                    TreeListNode nodeConsultaExistenciasBodega = tl.AppendNode(new object[] { "Bodega" }, nodeConsultaExistencias.Id, 11, 11, 11);
                    nodeConsultaExistenciasBodega.Tag = "optConsultaExistenciaBodega";
                    TreeListNode nodeConsultaExistenciasLote = tl.AppendNode(new object[] { "Lote" }, nodeConsultaExistencias.Id, 11, 11, 11);
                    nodeConsultaExistenciasLote.Tag = "optConsultaExistenciaLote";
                    TreeListNode nodeConsultaTransacciones = tl.AppendNode(new object[] { "Articulos" }, nodeConsultas.Id, 11, 11, 11);
                    nodeConsultaArticulos.Tag = "optConsultaTransacciones";
                    TreeListNode nodeReportes = tl.AppendNode(new object[] { "Reportes" }, -1, 9, 10, 9);
                    TreeListNode nodeProcesos = tl.AppendNode(new object[] { "Processos" }, -1, 9, 10, 9);
                    TreeListNode nodeAdministracion = tl.AppendNode(new object[] { "Administración" }, -1, 9, 10, 9);
                    break;
                case "treeListAdministracion":
                    TreeListNode nodeParametros = tl.AppendNode(new object[] { "Parametros Generales" }, -1, 11, 11, 11);
                    nodeParametros.Tag = "optParametrosGenerales";
                    break;
                case "treeListContabilidad":
                    TreeListNode nodeCuentas = tl.AppendNode(new object[] { "Cuentas" }, -1, 11, 11, 11);
                    nodeCuentas.Tag = "optCuenta";
                    TreeListNode nodeCentroCosto = tl.AppendNode(new object[] { "CentroCosto" }, -1, 11, 11, 11);
                    nodeCentroCosto.Tag = "optCentroCosto";
                    //Carpeta
                    TreeListNode nodeTransaccionesContabilidad = tl.AppendNode(new object[] { "Transacciones" }, -1, 9, 10, 9);
                    //Items
                    TreeListNode nodeTransaccionesDiario = tl.AppendNode(new object[] { "Diario" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    nodeTransaccionesDiario.Tag = "optTransaccionesDiario";
                    //TreeListNode nodeTransaccionesRecurrente = tl.AppendNode(new object[] { "Recurrente" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    //nodeTransaccionesRecurrente.Tag = "optTransaccionesRecurrente";
                    //TreeListNode nodeTransaccionesAnulacion = tl.AppendNode(new object[] { "Anulación" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    //nodeTransaccionesAnulacion.Tag = "optTransaccionesAnulacion";
                    //TreeListNode nodeTransaccionesReversion = tl.AppendNode(new object[] { "Reversión" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    //nodeTransaccionesReversion.Tag = "optTransaccionesReversion";
                    //TreeListNode nodeTransaccionesDistribuidas = tl.AppendNode(new object[] { "Distribuidas" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    //nodeTransaccionesDistribuidas.Tag = "optTransaccionesDistribuidas";
                    //TreeListNode nodeTransaccionesReferido = tl.AppendNode(new object[] { "Referido" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    //nodeTransaccionesReferido.Tag = "optTransaccionesReferido";
                    //Carpeta
                    TreeListNode nodeConsultasContabilidad = tl.AppendNode(new object[] { "Consultas" }, -1, 9, 10, 9);
                    //Items
                    TreeListNode nodeConsultasDeCuentasContables = tl.AppendNode(new object[] { "De Cuentas Contables" }, nodeConsultasContabilidad.Id, 11, 11, 11);
                    nodeConsultasDeCuentasContables.Tag = "optConsultasDeCuentasContables";
                    TreeListNode nodeConsultasDeCentrosDeCostos = tl.AppendNode(new object[] { "De Centros de Costos" }, nodeConsultasContabilidad.Id, 11, 11, 11);
                    nodeConsultasDeCentrosDeCostos.Tag = "optConsultasDeCentrosDeCostos";
                    TreeListNode nodeConsultasPorPeriodoContable = tl.AppendNode(new object[] { "Por Periodo Contable" }, nodeConsultasContabilidad.Id, 11, 11, 11);
                    nodeConsultasPorPeriodoContable.Tag = "optConsultasPorPeriodoContable";
                    TreeListNode nodeConsultasLibroMayor = tl.AppendNode(new object[] { "Libro Mayor" }, nodeConsultasContabilidad.Id, 11, 11, 11);
                    nodeConsultasLibroMayor.Tag = "optConsultasLibroMayor";
                    //Carpeta
                    TreeListNode nodeConsultasDelMayor = tl.AppendNode(new object[] { "Del Mayor" }, nodeConsultasContabilidad.Id, 9, 10, 9);
                    //Items
                    TreeListNode nodeConsultasDelMayorAsientos = tl.AppendNode(new object[] { "Asientos" }, nodeConsultasDelMayor.Id, 11, 11, 11);
                    nodeConsultasDelMayorAsientos.Tag = "optConsultasDelMayorAsientos";
                    TreeListNode nodeConsultasDelMayorTransacciones = tl.AppendNode(new object[] { "Transacciones" }, nodeConsultasDelMayor.Id, 11, 11, 11);
                    nodeConsultasDelMayorTransacciones.Tag = "optConsultasDelMayorTransacciones";
                    //Carpeta
                    TreeListNode nodeConsultasDelDiario = tl.AppendNode(new object[] { "Del Diario" }, nodeConsultasContabilidad.Id, 9, 10, 9);
                    //Items
                    TreeListNode nodeConsultasDelDiarioAsientos = tl.AppendNode(new object[] { "Asientos" }, nodeConsultasDelDiario.Id, 11, 11, 11);
                    nodeConsultasDelDiarioAsientos.Tag = "optConsultasDelDiarioAsientos";
                    TreeListNode nodeConsultasDelDiarioTransacciones = tl.AppendNode(new object[] { "Transacciones" }, nodeConsultasDelDiario.Id, 11, 11, 11);
                    nodeConsultasDelDiarioTransacciones.Tag = "optConsultasDelDiarioTransacciones";

                    //Carpeta
                    TreeListNode nodeReportesContabilidad = tl.AppendNode(new object[] { "Reportes" }, -1, 9, 10, 9);
                    //Carpeta
                    TreeListNode nodeReportesBalanceDeComprobacion = tl.AppendNode(new object[] { "Balance de Comprobacion" }, nodeReportesContabilidad.Id, 9, 10, 9);
                    //Items
                    TreeListNode nodeReportesBalanceDeComprobacionPorCuentaContable = tl.AppendNode(new object[] { "Por Cuenta Contable" }, nodeReportesBalanceDeComprobacion.Id, 11, 11, 11);
                    nodeReportesBalanceDeComprobacionPorCuentaContable.Tag = "optReportesBalanceDeComprobacionPorCuentaContable";
                    TreeListNode nodeReportesBalanceDeComprobacionPorCentroCosto = tl.AppendNode(new object[] { "Por Centro de Costo" }, nodeReportesBalanceDeComprobacion.Id, 11, 11, 11);
                    nodeReportesBalanceDeComprobacionPorCentroCosto.Tag = "optReportesBalanceDeComprobacionPorCentroCosto";
                    TreeListNode nodeReportesBalanceGeneral = tl.AppendNode(new object[] { "Balance General" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    nodeReportesBalanceGeneral.Tag = "optReportesBalanceGeneral";
                    TreeListNode nodeReportesEstadodeResultado = tl.AppendNode(new object[] { "Estado de Resultado" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    nodeReportesEstadodeResultado.Tag = "optReportesEstadodeResultado";
                    TreeListNode nodeReportesReporteDeAsiento = tl.AppendNode(new object[] { "Reporte de Asiento" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    nodeReportesReporteDeAsiento.Tag = "optReportesReporteDeAsiento";
                    TreeListNode nodeReportesReporteDeMayor = tl.AppendNode(new object[] { "Reporte de Mayor" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    nodeReportesReporteDeMayor.Tag = "optReportesReporteDeMayor";
                    TreeListNode nodeReportesReporteDeDiferencias = tl.AppendNode(new object[] { "Reporte de Diferencias" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    nodeReportesReporteDeDiferencias.Tag = "optReportesDeDiferencias";
                    //Carpeta
                    TreeListNode nodeAdministracionContabilidad = tl.AppendNode(new object[] { "Administracion" }, -1, 9, 10, 9);
                    TreeListNode nodeParametrosModulo = tl.AppendNode(new object[] { "Parametros del Módulo" }, nodeAdministracionContabilidad.Id, 11, 11, 11);
                    nodeParametrosModulo.Tag = "optParametrosModuloContable";
                    TreeListNode nodeAbrirPeriodoCerrado = tl.AppendNode(new object[] { "Abrir Periodos Cerrados" }, nodeAdministracionContabilidad.Id, 11, 11, 11);
                    nodeAbrirPeriodoCerrado.Tag = "optAbrirPeriodosCerrados";
                    break;
            }

            tl.EndUnboundLoad();
        }


        private void ShowPagesRibbonMan(bool valor)
        {
            this.ribbonHelp.Visible = valor;
        }

        private void treeListInventario_DoubleClick(object sender, EventArgs e)
        {

            DevExpress.XtraTreeList.Nodes.TreeListNode node = default(DevExpress.XtraTreeList.Nodes.TreeListNode);
            node = ((TreeList) sender).FocusedNode;
            switch (node.Tag.ToString())
            {
                case "optCuenta":
                    frmListadoCuentaContable ofrmCuenta = new frmListadoCuentaContable();
                    ofrmCuenta.MdiParent = this;
                    ofrmCuenta.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmCuenta.Show();
                    break;
                case "optArticulo":
                    break;
                //Dim ofrm As New UI.Inventario.Form1()
                //ofrm.MdiParent = Me
                //ofrm.WindowState = FormWindowState.Maximized
                //ofrm.Show()
                //ribbonControl.SelectedPage = ofrm.Ribbon.Pages(0) ' ofrm.DefaultPage
                //ShowPagesRibbonMan(False)
                //AddHandler ofrm.FormClosed, AddressOf FomulariosClosed

                //ribbonControl.SelectedPage = ribbonControl.Pages(1)
                case "optLote":
                    //frmListadoCentroCosto ofrm = new frmListadoCentroCosto();
                    //ofrm.FormClosed += ofrm_FormClosed;
                    //ofrm.MdiParent = this;
                    //ofrm.WindowState = FormWindowState.Maximized;
                    //ShowPagesRibbonMan(false);
                    //ofrm.Show();
                    break;
                case "optEjemplo":
                    break;
                case "optConsultaArticulo":
                    break;
                case "optConsultaExistenciaBodega":
                    break;
                case "optConsultaExistenciaLote":
                    break;
                case "optConsultaTransacciones":
                    break;
            }

        }

        void ofrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ShowPagesRibbonMan(true);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

     
    }
}