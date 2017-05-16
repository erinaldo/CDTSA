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
namespace MainMenu
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            CreateNodes(treeListInventario);
            CreateNodes(treeListContabilidad);
        }


        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();

            TreeListNode parentForRootNodes = null;
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
                case "treeListContabilidad":
                    TreeListNode nodeCuentas = tl.AppendNode(new object[] { "Cuentas" }, -1, 11, 11, 11);
                    nodeCuentas.Tag = "optCuenta";
                    //Carpeta
                    TreeListNode nodeTransaccionesContabilidad = tl.AppendNode(new object[] { "Transacciones" }, -1, 9, 10, 9);
                    //Items
                    TreeListNode nodeTransaccionesDiario = tl.AppendNode(new object[] { "Diario" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    nodeTransaccionesDiario.Tag = "optTransaccionesDiario";
                    TreeListNode nodeTransaccionesRecurrente = tl.AppendNode(new object[] { "Recurrente" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    nodeTransaccionesRecurrente.Tag = "optTransaccionesRecurrente";
                    TreeListNode nodeTransaccionesAnulacion = tl.AppendNode(new object[] { "Anulación" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    nodeTransaccionesAnulacion.Tag = "optTransaccionesAnulacion";
                    TreeListNode nodeTransaccionesReversion = tl.AppendNode(new object[] { "Reversión" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    nodeTransaccionesReversion.Tag = "optTransaccionesReversion";
                    TreeListNode nodeTransaccionesDistribuidas = tl.AppendNode(new object[] { "Distribuidas" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    nodeTransaccionesDistribuidas.Tag = "optTransaccionesDistribuidas";
                    TreeListNode nodeTransaccionesReferido = tl.AppendNode(new object[] { "Referido" }, nodeTransaccionesContabilidad.Id, 11, 11, 11);
                    nodeTransaccionesReferido.Tag = "optTransaccionesReferido";
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
                    frmListadoCentroCosto ofrm = new frmListadoCentroCosto();
                    ofrm.FormClosed += ofrm_FormClosed;
                    ofrm.MdiParent = this;
                    ofrm.WindowState = FormWindowState.Maximized;
                    ShowPagesRibbonMan(false);
                    ofrm.Show();
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

  

    }
}