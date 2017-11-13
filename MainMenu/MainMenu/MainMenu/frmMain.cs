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
using CDTSA.Properties;
using ControlBancario;

namespace MainMenu
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private String CodTipoCambio;


        public frmMain()
        {
            InitializeComponent();
            //CreateNodes(treeListInventario);
            CreateNodes(treeListContabilidad);
            CreateNodes(treeListAdministracion);
            CreateNodes(treeListControlBancario);
            this.Load += frmMain_Load;
            ShowPagesRibbonMan(false);
        }

        private void enlazarEventos()
        {
            this.treeListContabilidad.DoubleClick -= treeListContabilidad_DoubleClick;
            this.treeListContabilidad.DoubleClick += treeListContabilidad_DoubleClick;

            this.treeListAdministracion.DoubleClick -= treeListAdministracion_DoubleClick;
            this.treeListAdministracion.DoubleClick += treeListAdministracion_DoubleClick;

            this.treeListControlBancario.DoubleClick -= treeListControlBancario_DoubleClick;
            this.treeListControlBancario.DoubleClick += treeListControlBancario_DoubleClick;
            
        }

        

        private void CargarImagenFondo()
        {
            this.BackgroundImage = (Security.Esquema.Compania == "CEDETSA") ? Resources.CEDETSA : Resources.DASA;
            this.BackgroundImageLayout = ImageLayout.Center;
        }

        void frmMain_Load(object sender, EventArgs e)
        {
            CargarImagenFondo();
            enlazarEventos();
            CargarPrivilegios();
            CargarParametrosSistema();
            CargarConfiguracionRegional();
        }

        private void CargarConfiguracionRegional()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        private void ObtenerTipoCambio(String TipoCambio)
        {
            DataSet DS = CDTSA.DAC.ParametrosGeneralesDAC.GetTipoCambio(TipoCambio, DateTime.Now);
            if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                this.lblFecha.Caption = "Fecha: " + Convert.ToDateTime(DS.Tables[0].Rows[0]["Fecha"]).ToShortDateString();
                this.lblTipoCambio.Caption = "TC: " + Convert.ToDecimal(DS.Tables[0].Rows[0]["Monto"]).ToString("N4");

                enlazarEventos();
            }
            else
            {
                this.lblFecha.Caption = "Fecha: --";
                this.lblTipoCambio.Caption = "TC: --";
                //validar si tiene privilegios para modificar el tipo de cambio.
                DataSet DSS = new DataSet();
                DataTable DT = new DataTable();
                DSS = UsuarioDAC.GetAccionModuloFromRole(0, UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString());
                DT = DSS.Tables[0];
                if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.RegistrarTipoCambio, DT))
                {
                    MessageBox.Show("El tipo de cambio para el día no esta registrado, por favor ingrese el detalle del tipo de cambios \n\r ");
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.GetType() == typeof(CG.frmTipoCambioDetalle))
                        {
                            // MessageBox.Show("El formulario 2 esta abierto");
                            break;
                        }
                    }
                    CG.frmTipoCambioDetalle ofrmTipoCambio = new frmTipoCambioDetalle(CodTipoCambio, "");
                    ofrmTipoCambio.FormClosed += ofrmTipoCambio_FormClosed;
                    ofrmTipoCambio.MdiParent = this;
                    ofrmTipoCambio.StartPosition = FormStartPosition.CenterScreen;
                    ofrmTipoCambio.Show();
                }
                else
                    MessageBox.Show("El tipo de cambio para el día no esta registrado, por favor contacte el administrador del sistema. \n\r ");
                this.treeListContabilidad.DoubleClick -= treeListContabilidad_DoubleClick;
            }
        }

        void ofrmTipoCambio_FormClosed(object sender, FormClosedEventArgs e)
        {

            CargarParametrosSistema();
        }

        private void CargarParametrosSistema()
        {

            try
            {
                DataSet DS = CDTSA.DAC.ParametrosGeneralesDAC.GetData();
                if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
                {
                    String sMensaje = "";
                    //Validar los datos de configuracion
                    if (DS.Tables[0].Rows[0]["Nombre"].ToString() == "")
                    {
                        sMensaje = sMensaje + " • El nombre de la compañía no se ha establecido \n\r";
                        this.lblCompania.Caption = "Compañia: ";
                    }
                    if (DS.Tables[0].Rows[0]["CantDigitosDecimales"].ToString() == "")
                    {
                        sMensaje = sMensaje + " • La cantidad de Dígitos de decimales que se visualizan en sistema \n\r";
                    }
                    if (DS.Tables[0].Rows[0]["SimboloMonedaFuncional"].ToString() == "")
                        sMensaje = sMensaje + " • El símbolo de la moneda funcional no se ha establecido \n\r";
                    if (DS.Tables[0].Rows[0]["SimboloMonedaExtrangera"].ToString() == "")
                        sMensaje = sMensaje + " • El símbolo de la moneda extrangera no se ha establecido \n\r";
                    if (DS.Tables[0].Rows[0]["TipoCambio"].ToString() == "")
                        sMensaje = sMensaje + " • El tipo de Cambio con el trabajara el sistema no se ha establecido \n\r";

                    if (sMensaje != "")
                    {

                        this.lblFecha.Caption = "Fecha: --";
                        this.lblTipoCambio.Caption = "TC: --";
                        this.lblCompania.Caption = "Compañia: ";
                        MessageBox.Show("Por favor notifique a su administrador del sistema la validación de los siguientes campos: \n\r " + sMensaje);
                        this.treeListContabilidad.DoubleClick -= treeListContabilidad_DoubleClick;
                    }
                    else
                    {
                        String sTipoCambio = "";
                        Util.Util.DecimalLenght = Convert.ToInt32(DS.Tables[0].Rows[0]["CantDigitosDecimales"]);
                        Util.Util.LocalSimbolCurrency = DS.Tables[0].Rows[0]["SimboloMonedaFuncional"].ToString();
                        Util.Util.ForeingSimbolCurrency = DS.Tables[0].Rows[0]["SimboloMonedaExtrangera"].ToString();
                        sTipoCambio = DS.Tables[0].Rows[0]["TipoCambio"].ToString();
                        CodTipoCambio = sTipoCambio;
                        ObtenerTipoCambio(sTipoCambio);
                        this.lblCompania.Caption = "Compañia: " + DS.Tables[0].Rows[0]["Nombre"].ToString();

                    }
                }
                else
                {
                    MessageBox.Show("Los parámetros generales de la aplicacion estan incompletos, por favor contacte al administrador del sistema");
                    //Quitar  todas las acciones a los menus.
                    this.treeListContabilidad.DoubleClick -= treeListContabilidad_DoubleClick;
                }
                this.lblUsuario.Caption = "Usuario: " + ((UsuarioDAC._DS.Tables.Count > 0) ? UsuarioDAC._DS.Tables[0].Rows[0]["Usuario"].ToString() : "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void treeListControlBancario_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node = default(DevExpress.XtraTreeList.Nodes.TreeListNode);
            node = ((TreeList)sender).FocusedNode;
            if (Application.OpenForms[node.Tag.ToString()] != null)
            {
                Application.OpenForms[node.Tag.ToString()].Activate();
                return;
            }
            switch (node.Tag.ToString())
            {
                case "frmListadoBanco":

                    ControlBancario.frmListadoBanco ofrmListadoBanco = new ControlBancario.frmListadoBanco();
                    ofrmListadoBanco.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmListadoBanco.Show();
                    break;
                case "frmTipoCuenta":
                    ControlBancario.frmTipoCuenta ofrmListadoTipoCuenta = new frmTipoCuenta();
                    ofrmListadoTipoCuenta.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmListadoTipoCuenta.Show();
                    break;
                case "frmTipoDocumento":
                    ControlBancario.frmTipoDocumento ofrmTipoDocu = new frmTipoDocumento();
                    ofrmTipoDocu.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmTipoDocu.Show();
                    break;
                case "frmListadoCuentaBancaria":
                    ControlBancario.frmListadoCuentaBancaria ofrmListadoCuentaBancaria = new frmListadoCuentaBancaria();
                    ofrmListadoCuentaBancaria.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmListadoCuentaBancaria.Show();
                    break;
                case "frmListadoSubTipoDocumento":
                    ControlBancario.frmListadoSubTipoDocumento ofrmListadoSubTipoDocumento = new frmListadoSubTipoDocumento();
                    ofrmListadoSubTipoDocumento.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmListadoSubTipoDocumento.Show();
                    break;
                case "frmCheque":
                    ControlBancario.frmCheque ofrmCheque = new frmCheque();
                    ofrmCheque.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmCheque.Show();
                    break;
                case "frmNIT":
                    ControlBancario.frmRUC ofrmRUC = new ControlBancario.frmRUC();
                    ofrmRUC.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmRUC.Show();
                    break;
            }
        }



        void treeListAdministracion_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node = default(DevExpress.XtraTreeList.Nodes.TreeListNode);
            node = ((TreeList)sender).FocusedNode;
            if (Application.OpenForms[node.Tag.ToString()] != null)
            {
                Application.OpenForms[node.Tag.ToString()].Activate();
                return;
            }
            switch (node.Tag.ToString())
            {
                case "frmParametrosGenerales":

                    CDTSA.frmParametrosGenerales ofrmParametrosGenerales = new CDTSA.frmParametrosGenerales();
                    ofrmParametrosGenerales.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmParametrosGenerales.FormClosed += ofrmParametrosGenerales_FormClosed;
                    ofrmParametrosGenerales.Show();
                    break;

                case "frmListadoTipoCambio":

                    CG.frmListadoTipoCambio ofrmlstTipoCambio = new frmListadoTipoCambio();
                    ofrmlstTipoCambio.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmlstTipoCambio.Show();
                    break;
                case "frmSubirTipoCambio":
                    frmSubirTipoCambio ofrmSubirTipoCambio = new frmSubirTipoCambio();
                    ofrmSubirTipoCambio.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmSubirTipoCambio.Show();
                    break;

                case "frmDesigner":

                    CDTSA.frmDesigner ofrmReportDesigner = new CDTSA.frmDesigner();
                    ShowPagesRibbonMan(false);
                    ofrmReportDesigner.Show();
                    break;

                  
            }
        }


        private void SetNodeDisable(String Tag, DevExpress.XtraTreeList.TreeList tree)
        {
            try
            {
                foreach (TreeListNode node in tree.Nodes)
                    if (node.Tag != null && node.Tag.ToString() == Tag)
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
            //Modulos principales
            if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosGeneralesType.Contabilidad, DT))
            {
                navGroupContabilidad.Visible = true;
                //activar las opciones de la contabilidad
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.CatalogoCuentaContable, DT))
                    SetNodeDisable("frmListadoCuentaContable", treeListContabilidad);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.CatalogoCentroCosto, DT))
                    SetNodeDisable("frmListadoCentroCosto", treeListContabilidad);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.AsientodeDiario, DT))
                    SetNodeDisable("frmListadoAsientoDiario", treeListContabilidad);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.ParemtrosModuloContable, DT))
                    SetNodeDisable("frmParametrosContables", treeListContabilidad);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.PeriodosContables, DT))
                    SetNodeDisable("frmListadoPeriodos", treeListContabilidad);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.CrearEjerciciosContables, DT))
                    SetNodeDisable("frmCreaEjercicio", treeListContabilidad);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.GrupoEstadosFinancieros, DT))
                    SetNodeDisable("frmGrupoEstadosFinancieros", treeListContabilidad);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.CuentaGrupoEstadosFinancieros, DT))
                    SetNodeDisable("frmRelacionCuentaGrupoEstadosFinancieros", treeListContabilidad);
            }
            else
                navGroupContabilidad.Visible = false;

            //Validar el Resto de modulos
            if (UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosGeneralesType.AdministracionSistema, DT))
            {
                this.navGroupAdministracion.Visible = true;
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosContableType.RegistrarTipoCambio, DT))
                    SetNodeDisable("frmListadoTipoCambio", treeListAdministracion);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosGeneralesType.ParametrosGenerales, DT))
                    SetNodeDisable("frmParametrosGenerales", treeListAdministracion);
                if (!UsuarioDAC.PermiteAccion((int)Acciones.PrivilegiosGeneralesType.ModificacionReportes, DT))
                    SetNodeDisable("frmDesigner", treeListAdministracion);
            }
            else
                this.navGroupAdministracion.Visible = false;

            //Desactivar Factura
            this.navGroupFacturación.Visible = false;
        }

        void treeListContabilidad_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node = default(DevExpress.XtraTreeList.Nodes.TreeListNode);
            node = ((TreeList)sender).FocusedNode;
            if (node.Tag == null)
                return;
            if (Application.OpenForms[node.Tag.ToString()] != null)
            {
                Application.OpenForms[node.Tag.ToString()].Activate();
                return;
            }
            switch (node.Tag.ToString())
            {
                case "frmListadoCuentaContable":
                    frmListadoCuentaContable ofrmCuenta = new frmListadoCuentaContable();
                    ofrmCuenta.MdiParent = this;
                    ofrmCuenta.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmCuenta.Show();
                    break;
                case "frmListadoCentroCosto":
                    frmListadoCentroCosto ofrmCentro = new frmListadoCentroCosto();
                    ofrmCentro.MdiParent = this;
                    ofrmCentro.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmCentro.Show();
                    break;
                case "frmListadoAsientoDiario":
                    frmListadoAsientoDiario ofrmListadoAsientoDiario = new frmListadoAsientoDiario();
                    ofrmListadoAsientoDiario.MdiParent = this;
                    ofrmListadoAsientoDiario.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmListadoAsientoDiario.Show();
                    break;
                case "frmConsultaSaldoCuenta":
                    frmConsultaSaldoCuenta ofrmConsultaSaldoCuenta = new frmConsultaSaldoCuenta();
                    ofrmConsultaSaldoCuenta.MdiParent = this;
                    ofrmConsultaSaldoCuenta.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmConsultaSaldoCuenta.Show();
                    break;
                case "frmConsultaSaldoCentro":
                    frmConsultaSaldoCentro ofrmConsultaSaldoCentro = new frmConsultaSaldoCentro();
                    ofrmConsultaSaldoCentro.MdiParent = this;
                    ofrmConsultaSaldoCentro.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmConsultaSaldoCentro.Show();
                    break;
                case "frmConsultaLibroMayor":
                    frmConsultaLibroMayor ofrmLibroMayor = new frmConsultaLibroMayor();
                    ofrmLibroMayor.MdiParent = this;
                    ofrmLibroMayor.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrmLibroMayor.Show();
                    break;
                case "frmParametrosContables":
                    frmParametrosContables ofrmParametrosContabilidad = new frmParametrosContables();
                    ofrmParametrosContabilidad.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmParametrosContabilidad.Show();
                    break;
                case "frmListadoPeriodos":
                    frmListadoPeriodos ofrmListadoPeriodos = new frmListadoPeriodos();
                    ofrmListadoPeriodos.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmListadoPeriodos.Show();
                    break;
                case "frmGrupoEstadosFinancieros":
                    frmGrupoEstadosFinancieros ofrmGrupoEstadosFinancieros = new frmGrupoEstadosFinancieros();
                    ofrmGrupoEstadosFinancieros.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmGrupoEstadosFinancieros.Show();
                    break;

                case "frmRelacionCuentaGrupoEstadosFinancieros":
                    frmRelacionCuentaGrupoEstadosFinancieros ofrmRelacionGrupoEstadosF = new frmRelacionCuentaGrupoEstadosFinancieros();
                    ofrmRelacionGrupoEstadosF.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmRelacionGrupoEstadosF.Show();
                    break;
                case "frmCreaEjercicio":
                    CG.frmCreaEjercicio ofrmCrearEjercicio = new CG.frmCreaEjercicio();
                    ofrmCrearEjercicio.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmCrearEjercicio.Show();
                    break;

                case "optConsultasDeCentrosDeCostos":
                    break;
                case "frmBalanceGeneral":
                    frmBalanceGeneral ofrmBalance = new frmBalanceGeneral();
                    ofrmBalance.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmBalance.Show();
                    break;
                case "frmBalanceComprobacion":
                    frmBalanceComprobacion ofrmBalanceComprobacion = new frmBalanceComprobacion();
                    ofrmBalanceComprobacion.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmBalanceComprobacion.Show();
                    break;
                case "frmEstadoResultado":
                    frmEstadoResultado ofrmEstado = new frmEstadoResultado();
                    ofrmEstado.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmEstado.Show();
                    break;
                case "frmCerrarPeriodo":
                    frmCerrarPeriodo ofrmCierre = new frmCerrarPeriodo();
                    ofrmCierre.MdiParent = this;
                    ShowPagesRibbonMan(false);
                    ofrmCierre.Show();
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
                    TreeListNode nodeArticulo = tl.AppendNode(new object[] { "Artículo" }, -1, 11, 11, 11);
                    nodeArticulo.Tag = "optArticulo";

                    TreeListNode nodeLotes = tl.AppendNode(new object[] { "Lotes" }, -1, 11, 11, 11);
                    nodeLotes.Tag = "optLote";
                    TreeListNode nodeTransacciones = tl.AppendNode(new object[] { "Transacciones" }, -1, 9, 10, 9);
                    TreeListNode nodeEjemplo = tl.AppendNode(new object[] { "Ejemplo" }, nodeTransacciones.Id, 11, 11, 11);
                    nodeEjemplo.Tag = "optEjemplo";
                    TreeListNode nodeConsultas = tl.AppendNode(new object[] { "Consultas" }, -1, 9, 10, 9);
                    TreeListNode nodeConsultaArticulos = tl.AppendNode(new object[] { "Artículos" }, nodeConsultas.Id, 11, 11, 11);
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
                    TreeListNode nodeTipos = tl.AppendNode(new object[] { "Catálogos" }, -1, 9, 10, 9);
                    TreeListNode nodeTiposCambio = tl.AppendNode(new object[] { "Tipos de Cambio" }, nodeTipos.Id, 11, 11, 11);
                    nodeTiposCambio.Tag = "frmListadoTipoCambio";
                    TreeListNode nodeSubirTiposCambio = tl.AppendNode(new object[] { "Subir Tipos de Cambio" }, nodeTipos.Id, 11, 11, 11);
                    nodeSubirTiposCambio.Tag = "frmSubirTipoCambio";
                    TreeListNode nodeParametros = tl.AppendNode(new object[] { "Parametros Generales" }, -1, 11, 11, 11);
                    nodeParametros.Tag = "frmParametrosGenerales";
                    TreeListNode nodeReportDesigner = tl.AppendNode(new object[] { "Diseñador de Reportes" }, -1, 11, 11, 11);
                    nodeReportDesigner.Tag = "frmDesigner";

                    break;
                case "treeListControlBancario":
                    TreeListNode nodeCatalogoBanco = tl.AppendNode(new object[] { "Catálogos" }, -1, 9, 10, 9);
                    TreeListNode nodeTipoCuenta = tl.AppendNode(new object[] { "Tipo Cuenta" }, nodeCatalogoBanco.Id, 11, 11, 11);
                    nodeTipoCuenta.Tag = "frmTipoCuenta";
                    TreeListNode nodeTipoDocumento = tl.AppendNode(new object[] { "Tipo Documento" }, nodeCatalogoBanco.Id, 11, 11, 11);
                    nodeTipoDocumento.Tag = "frmTipoDocumento";
                    TreeListNode nodeListadoBanco= tl.AppendNode(new object[] { "Bancos" }, nodeCatalogoBanco.Id, 11, 11, 11);
                    nodeListadoBanco.Tag = "frmListadoBanco";
                    TreeListNode nodeListadoSubTipoDocumento = tl.AppendNode(new object[] { "Sub Tipo Documento" }, nodeCatalogoBanco.Id, 11, 11, 11);
                    nodeListadoSubTipoDocumento.Tag = "frmListadoSubTipoDocumento";
                    TreeListNode nodeListadoCuentaBancaria = tl.AppendNode(new object[] { "Cuentas Bancarias" }, nodeCatalogoBanco.Id, 11, 11, 11);
                    nodeListadoCuentaBancaria.Tag = "frmListadoCuentaBancaria";
                    TreeListNode nodeDocumentos = tl.AppendNode(new object[] { "Documentos" }, -1, 9, 10, 9);
                    TreeListNode nodeCheques = tl.AppendNode(new object[] { "Cheques" }, nodeDocumentos.Id, 11, 11, 11);
                    nodeCheques.Tag = "frmCheque";
                    TreeListNode nodeNit = tl.AppendNode(new object[] { "Nit" }, nodeDocumentos.Id, 11, 11, 11);
                    nodeNit.Tag = "frmNIT";

                    

                    break;
                case "treeListContabilidad":
                    TreeListNode nodeCuentas = tl.AppendNode(new object[] { "Cuentas Contables" }, -1, 11, 11, 11);
                    nodeCuentas.Tag = "frmListadoCuentaContable";
                    TreeListNode nodeCentroCosto = tl.AppendNode(new object[] { "Centro de Costos" }, -1, 11, 11, 11);
                    nodeCentroCosto.Tag = "frmListadoCentroCosto";
                    //Carpeta
                    TreeListNode nodeTransaccionesContabilidad = tl.AppendNode(new object[] { "Transacciones" }, -1, 9, 10, 9);
                    //Items
                    TreeListNode nodeTransaccionesDiario = tl.AppendNode(new object[] { "Diario" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    nodeTransaccionesDiario.Tag = "frmListadoAsientoDiario";
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
                    nodeConsultasDeCuentasContables.Tag = "frmConsultaSaldoCuenta";
                    TreeListNode nodeConsultasDeCentrosDeCostos = tl.AppendNode(new object[] { "De Centros de Costos" }, nodeConsultasContabilidad.Id, 11, 11, 11);
                    nodeConsultasDeCentrosDeCostos.Tag = "frmConsultaSaldoCentro";
                    //TreeListNode nodeConsultasPorPeriodoContable = tl.AppendNode(new object[] { "Por Periodo Contable" }, nodeConsultasContabilidad.Id, 11, 11, 11);
                    //nodeConsultasPorPeriodoContable.Tag = "optConsultasPorPeriodoContable";
                    TreeListNode nodeConsultasLibroMayor = tl.AppendNode(new object[] { "Libro Mayor" }, nodeConsultasContabilidad.Id, 11, 11, 11);
                    nodeConsultasLibroMayor.Tag = "frmConsultaLibroMayor";
                    //Carpeta
                    //TreeListNode nodeConsultasDelMayor = tl.AppendNode(new object[] { "Del Mayor" }, nodeConsultasContabilidad.Id, 9, 10, 9);
                    ////Items
                    //TreeListNode nodeConsultasDelMayorAsientos = tl.AppendNode(new object[] { "Asientos" }, nodeConsultasDelMayor.Id, 11, 11, 11);
                    //nodeConsultasDelMayorAsientos.Tag = "optConsultasDelMayorAsientos";
                    //TreeListNode nodeConsultasDelMayorTransacciones = tl.AppendNode(new object[] { "Transacciones" }, nodeConsultasDelMayor.Id, 11, 11, 11);
                    //nodeConsultasDelMayorTransacciones.Tag = "optConsultasDelMayorTransacciones";
                    ////Carpeta
                    //TreeListNode nodeConsultasDelDiario = tl.AppendNode(new object[] { "Del Diario" }, nodeConsultasContabilidad.Id, 9, 10, 9);
                    ////Items
                    //TreeListNode nodeConsultasDelDiarioAsientos = tl.AppendNode(new object[] { "Asientos" }, nodeConsultasDelDiario.Id, 11, 11, 11);
                    //nodeConsultasDelDiarioAsientos.Tag = "optConsultasDelDiarioAsientos";
                    //TreeListNode nodeConsultasDelDiarioTransacciones = tl.AppendNode(new object[] { "Transacciones" }, nodeConsultasDelDiario.Id, 11, 11, 11);
                    //nodeConsultasDelDiarioTransacciones.Tag = "optConsultasDelDiarioTransacciones";

                    //Carpeta
                    TreeListNode nodeReportesContabilidad = tl.AppendNode(new object[] { "Reportes" }, -1, 9, 10, 9);
                    //Carpeta
                    //TreeListNode nodeReportesBalanceDeComprobacion = tl.AppendNode(new object[] { "Balance de Comprobación" }, nodeReportesContabilidad.Id, 9, 10, 9);
                    ////Items
                    //TreeListNode nodeReportesBalanceDeComprobacionPorCuentaContable = tl.AppendNode(new object[] { "Por Cuenta Contable" }, nodeReportesBalanceDeComprobacion.Id, 11, 11, 11);
                    //nodeReportesBalanceDeComprobacionPorCuentaContable.Tag = "optReportesBalanceDeComprobacionPorCuentaContable";
                    //TreeListNode nodeReportesBalanceDeComprobacionPorCentroCosto = tl.AppendNode(new object[] { "Por Centro de Costo" }, nodeReportesBalanceDeComprobacion.Id, 11, 11, 11);
                    //nodeReportesBalanceDeComprobacionPorCentroCosto.Tag = "optReportesBalanceDeComprobacionPorCentroCosto";
                    TreeListNode nodeReportesBalanceGeneral = tl.AppendNode(new object[] { "Balance General" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    nodeReportesBalanceGeneral.Tag = "frmBalanceGeneral";
                    TreeListNode nodeReportesBalanceComprobacion = tl.AppendNode(new object[] { "Balance Comprobación" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    nodeReportesBalanceComprobacion.Tag = "frmBalanceComprobacion";
                    TreeListNode nodeReportesEstadodeResultado = tl.AppendNode(new object[] { "Estado de Resultado" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    nodeReportesEstadodeResultado.Tag = "frmEstadoResultado";
                    //TreeListNode nodeReportesReporteDeAsiento = tl.AppendNode(new object[] { "Reporte de Asiento" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    //nodeReportesReporteDeAsiento.Tag = "optReportesReporteDeAsiento";
                    //TreeListNode nodeReportesReporteDeMayor = tl.AppendNode(new object[] { "Reporte de Mayor" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    //nodeReportesReporteDeMayor.Tag = "optReportesReporteDeMayor";
                    //TreeListNode nodeReportesReporteDeDiferencias = tl.AppendNode(new object[] { "Reporte de Diferencias" }, nodeReportesContabilidad.Id, 11, 11, 11);
                    //nodeReportesReporteDeDiferencias.Tag = "optReportesDeDiferencias";

                    //Carpeta
                    TreeListNode nodeAdministracionContabilidad = tl.AppendNode(new object[] { "Administración" }, -1, 9, 10, 9);
                    TreeListNode nodeParametrosModulo = tl.AppendNode(new object[] { "Parámetros del Módulo" }, nodeAdministracionContabilidad.Id, 11, 11, 11);
                    nodeParametrosModulo.Tag = "frmParametrosContables";
                    TreeListNode nodeAbrirPeriodoCerrado = tl.AppendNode(new object[] { "Periodos Contables" }, nodeAdministracionContabilidad.Id, 11, 11, 11);
                    nodeAbrirPeriodoCerrado.Tag = "frmListadoPeriodos";
                    TreeListNode nodeGruposEstadosFinancieros = tl.AppendNode(new object[] { "Grupos Estados Financieros" }, nodeAdministracionContabilidad.Id, 11, 11, 11);
                    nodeGruposEstadosFinancieros.Tag = "frmGrupoEstadosFinancieros";

                    TreeListNode nodeCuentaGruposEstadosFinancieros = tl.AppendNode(new object[] { "Asociar Cuenta Grupos Estados Financieros" }, nodeAdministracionContabilidad.Id, 11, 11, 11);
                    nodeCuentaGruposEstadosFinancieros.Tag = "frmRelacionCuentaGrupoEstadosFinancieros";

                    TreeListNode nodeCrearEjercicio = tl.AppendNode(new object[] { "Crear Ejercicios" }, nodeAdministracionContabilidad.Id, 11, 11, 11);
                    nodeCrearEjercicio.Tag = "frmCreaEjercicio";

                    TreeListNode nodeCierreMes = tl.AppendNode(new object[] { "Cerrar Periodo" }, nodeAdministracionContabilidad.Id, 11, 11, 11);
                    nodeCierreMes.Tag = "frmCerrarPeriodo";
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