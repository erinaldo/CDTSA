<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidoinicial
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidoinicial))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnProd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCant = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrecio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSubTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.SearchLookUpEditProducto = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAddLinea = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPrecio = New DevExpress.XtraEditors.TextEdit()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.txtExistencia = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.txtSubTotal = New DevExpress.XtraEditors.TextEdit()
        Me.txtIGV = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SearchLookUpEditVendedor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MemoEditNota = New DevExpress.XtraEditors.MemoEdit()
        Me.CheckEditTeleventa = New DevExpress.XtraEditors.CheckEdit()
        Me.DateEditRequerida = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFecha = New DevExpress.XtraEditors.DateEdit()
        Me.gridLookUpSucursal = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtPedido = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl4 = New DevExpress.XtraLayout.LayoutControl()
        Me.MemoEditNotas = New DevExpress.XtraEditors.MemoEdit()
        Me.DateEditFechaRequerida = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFechaPedido = New DevExpress.XtraEditors.DateEdit()
        Me.chkTeleventa = New DevExpress.XtraEditors.CheckEdit()
        Me.txtPedidoNo = New DevExpress.XtraEditors.TextEdit()
        Me.SearchLookUpEditVendedores = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SearchLookUpEditSucursales = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup7 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Vendedor = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SearchLookUpCliente = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.Cliente = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.SearchLookUpEditProducto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExistencia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSubTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIGV.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SearchLookUpEditVendedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEditNota.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditTeleventa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditRequerida.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditRequerida.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridLookUpSucursal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPedido.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl4.SuspendLayout()
        CType(Me.MemoEditNotas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFechaRequerida.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFechaRequerida.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFechaPedido.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFechaPedido.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTeleventa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPedidoNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditVendedores.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEditSucursales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Vendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(13, 178)
        Me.GridControl1.MainView = Me.GridViewDetalle
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(849, 174)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetalle})
        '
        'GridViewDetalle
        '
        Me.GridViewDetalle.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnProd, Me.GridColumnDescr, Me.GridColumnCant, Me.GridColumnPrecio, Me.GridColumnSubTotal})
        Me.GridViewDetalle.GridControl = Me.GridControl1
        Me.GridViewDetalle.Name = "GridViewDetalle"
        Me.GridViewDetalle.OptionsView.ShowGroupPanel = False
        '
        'GridColumnProd
        '
        Me.GridColumnProd.Caption = "Producto"
        Me.GridColumnProd.Name = "GridColumnProd"
        Me.GridColumnProd.Visible = True
        Me.GridColumnProd.VisibleIndex = 0
        Me.GridColumnProd.Width = 59
        '
        'GridColumnDescr
        '
        Me.GridColumnDescr.Caption = "Descripcion"
        Me.GridColumnDescr.Name = "GridColumnDescr"
        Me.GridColumnDescr.Visible = True
        Me.GridColumnDescr.VisibleIndex = 1
        Me.GridColumnDescr.Width = 283
        '
        'GridColumnCant
        '
        Me.GridColumnCant.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCant.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCant.Caption = "Cantidad"
        Me.GridColumnCant.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCant.Name = "GridColumnCant"
        Me.GridColumnCant.Visible = True
        Me.GridColumnCant.VisibleIndex = 2
        Me.GridColumnCant.Width = 69
        '
        'GridColumnPrecio
        '
        Me.GridColumnPrecio.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrecio.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrecio.Caption = "Precio"
        Me.GridColumnPrecio.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrecio.Name = "GridColumnPrecio"
        Me.GridColumnPrecio.Visible = True
        Me.GridColumnPrecio.VisibleIndex = 3
        Me.GridColumnPrecio.Width = 107
        '
        'GridColumnSubTotal
        '
        Me.GridColumnSubTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSubTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSubTotal.Caption = "SubTotal"
        Me.GridColumnSubTotal.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSubTotal.Name = "GridColumnSubTotal"
        Me.GridColumnSubTotal.Visible = True
        Me.GridColumnSubTotal.VisibleIndex = 4
        Me.GridColumnSubTotal.Width = 120
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.btnSave)
        Me.LayoutControl2.Controls.Add(Me.btnEditar)
        Me.LayoutControl2.Controls.Add(Me.btnDelete)
        Me.LayoutControl2.Controls.Add(Me.SearchLookUpEditProducto)
        Me.LayoutControl2.Controls.Add(Me.btnAddLinea)
        Me.LayoutControl2.Controls.Add(Me.txtPrecio)
        Me.LayoutControl2.Controls.Add(Me.txtCantidad)
        Me.LayoutControl2.Controls.Add(Me.txtExistencia)
        Me.LayoutControl2.Location = New System.Drawing.Point(22, 358)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(718, 178, 250, 350)
        Me.LayoutControl2.Root = Me.LayoutControlGroup2
        Me.LayoutControl2.Size = New System.Drawing.Size(509, 161)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(357, 115)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(128, 22)
        Me.btnSave.StyleController = Me.LayoutControl2
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Guardar PedidoF10"
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(211, 115)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(108, 22)
        Me.btnEditar.StyleController = Me.LayoutControl2
        Me.btnEditar.TabIndex = 11
        Me.btnEditar.Text = "Editar F5"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(113, 115)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(94, 22)
        Me.btnDelete.StyleController = Me.LayoutControl2
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Borrar F4"
        '
        'SearchLookUpEditProducto
        '
        Me.SearchLookUpEditProducto.Location = New System.Drawing.Point(75, 48)
        Me.SearchLookUpEditProducto.Name = "SearchLookUpEditProducto"
        Me.SearchLookUpEditProducto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditProducto.Properties.View = Me.GridView4
        Me.SearchLookUpEditProducto.Size = New System.Drawing.Size(410, 20)
        Me.SearchLookUpEditProducto.StyleController = Me.LayoutControl2
        Me.SearchLookUpEditProducto.TabIndex = 9
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'btnAddLinea
        '
        Me.btnAddLinea.Image = CType(resources.GetObject("btnAddLinea.Image"), System.Drawing.Image)
        Me.btnAddLinea.Location = New System.Drawing.Point(24, 115)
        Me.btnAddLinea.Name = "btnAddLinea"
        Me.btnAddLinea.Size = New System.Drawing.Size(85, 22)
        Me.btnAddLinea.StyleController = Me.LayoutControl2
        Me.btnAddLinea.TabIndex = 8
        Me.btnAddLinea.Text = "Agregar F2"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(196, 72)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPrecio.Size = New System.Drawing.Size(160, 20)
        Me.txtPrecio.StyleController = Me.LayoutControl2
        Me.txtPrecio.TabIndex = 7
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(75, 72)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtCantidad.Size = New System.Drawing.Size(66, 20)
        Me.txtCantidad.StyleController = Me.LayoutControl2
        Me.txtCantidad.TabIndex = 5
        '
        'txtExistencia
        '
        Me.txtExistencia.Location = New System.Drawing.Point(411, 72)
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtExistencia.Size = New System.Drawing.Size(74, 20)
        Me.txtExistencia.StyleController = Me.LayoutControl2
        Me.txtExistencia.TabIndex = 6
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(509, 161)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CaptionImage = CType(resources.GetObject("LayoutControlGroup4.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup4.CustomizationFormText = "Datos Producto"
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem10, Me.LayoutControlItem9, Me.LayoutControlItem8, Me.LayoutControlItem15, Me.LayoutControlItem6, Me.LayoutControlItem18, Me.EmptySpaceItem3, Me.LayoutControlItem19, Me.EmptySpaceItem1})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(489, 141)
        Me.LayoutControlGroup4.Text = "Producto en Proceso"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtCantidad
        Me.LayoutControlItem7.CustomizationFormText = "Cantidad"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(121, 24)
        Me.LayoutControlItem7.Text = "Cantidad"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SearchLookUpEditProducto
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(465, 24)
        Me.LayoutControlItem10.Text = "Producto"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtPrecio
        Me.LayoutControlItem9.Location = New System.Drawing.Point(121, 24)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(215, 24)
        Me.LayoutControlItem9.Text = "Precio"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtExistencia
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(336, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(129, 24)
        Me.LayoutControlItem8.Text = "Existencia"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(48, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.btnAddLinea
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 67)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(89, 26)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnDelete
        Me.LayoutControlItem6.Location = New System.Drawing.Point(89, 67)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(98, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.btnEditar
        Me.LayoutControlItem18.Location = New System.Drawing.Point(187, 67)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(112, 26)
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 48)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(465, 19)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.btnSave
        Me.LayoutControlItem19.Location = New System.Drawing.Point(333, 67)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(132, 26)
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem19.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(299, 67)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(34, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.txtTotal)
        Me.LayoutControl3.Controls.Add(Me.txtSubTotal)
        Me.LayoutControl3.Controls.Add(Me.txtIGV)
        Me.LayoutControl3.Location = New System.Drawing.Point(649, 355)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(915, 254, 250, 350)
        Me.LayoutControl3.Root = Me.LayoutControlGroup3
        Me.LayoutControl3.Size = New System.Drawing.Size(213, 164)
        Me.LayoutControl3.TabIndex = 3
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(69, 96)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Properties.Mask.EditMask = "n2"
        Me.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotal.Size = New System.Drawing.Size(120, 20)
        Me.txtTotal.StyleController = Me.LayoutControl3
        Me.txtTotal.TabIndex = 6
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Location = New System.Drawing.Point(69, 48)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Properties.Mask.EditMask = "n2"
        Me.txtSubTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSubTotal.Size = New System.Drawing.Size(120, 20)
        Me.txtSubTotal.StyleController = Me.LayoutControl3
        Me.txtSubTotal.TabIndex = 5
        '
        'txtIGV
        '
        Me.txtIGV.Location = New System.Drawing.Point(69, 72)
        Me.txtIGV.Name = "txtIGV"
        Me.txtIGV.Properties.Mask.EditMask = "n2"
        Me.txtIGV.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtIGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtIGV.Size = New System.Drawing.Size(120, 20)
        Me.txtIGV.StyleController = Me.LayoutControl3
        Me.txtIGV.TabIndex = 4
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "Root"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(213, 164)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CaptionImage = CType(resources.GetObject("LayoutControlGroup5.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem13, Me.LayoutControlItem12, Me.LayoutControlItem14})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(193, 144)
        Me.LayoutControlGroup5.Text = "Totales del Pedido"
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.txtSubTotal
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(169, 24)
        Me.LayoutControlItem13.Text = "SubTotal"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(42, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.txtIGV
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(169, 24)
        Me.LayoutControlItem12.Text = "IGV"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(42, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.txtTotal
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(169, 48)
        Me.LayoutControlItem14.Text = "Total"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(42, 13)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SearchLookUpEditVendedor)
        Me.LayoutControl1.Controls.Add(Me.MemoEditNota)
        Me.LayoutControl1.Controls.Add(Me.CheckEditTeleventa)
        Me.LayoutControl1.Controls.Add(Me.DateEditRequerida)
        Me.LayoutControl1.Controls.Add(Me.DateEditFecha)
        Me.LayoutControl1.Controls.Add(Me.gridLookUpSucursal)
        Me.LayoutControl1.Controls.Add(Me.txtPedido)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(384, 273, 660, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(873, 120)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SearchLookUpEditVendedor
        '
        Me.SearchLookUpEditVendedor.Location = New System.Drawing.Point(117, 12)
        Me.SearchLookUpEditVendedor.Name = "SearchLookUpEditVendedor"
        Me.SearchLookUpEditVendedor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditVendedor.Properties.View = Me.GridView1
        Me.SearchLookUpEditVendedor.Size = New System.Drawing.Size(133, 20)
        Me.SearchLookUpEditVendedor.StyleController = Me.LayoutControl1
        Me.SearchLookUpEditVendedor.TabIndex = 13
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'MemoEditNota
        '
        Me.MemoEditNota.Location = New System.Drawing.Point(359, 60)
        Me.MemoEditNota.Name = "MemoEditNota"
        Me.MemoEditNota.Size = New System.Drawing.Size(502, 48)
        Me.MemoEditNota.StyleController = Me.LayoutControl1
        Me.MemoEditNota.TabIndex = 11
        '
        'CheckEditTeleventa
        '
        Me.CheckEditTeleventa.Location = New System.Drawing.Point(547, 12)
        Me.CheckEditTeleventa.Name = "CheckEditTeleventa"
        Me.CheckEditTeleventa.Properties.Caption = "Televenta"
        Me.CheckEditTeleventa.Size = New System.Drawing.Size(155, 19)
        Me.CheckEditTeleventa.StyleController = Me.LayoutControl1
        Me.CheckEditTeleventa.TabIndex = 9
        '
        'DateEditRequerida
        '
        Me.DateEditRequerida.EditValue = Nothing
        Me.DateEditRequerida.Location = New System.Drawing.Point(652, 36)
        Me.DateEditRequerida.Name = "DateEditRequerida"
        Me.DateEditRequerida.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditRequerida.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditRequerida.Size = New System.Drawing.Size(50, 20)
        Me.DateEditRequerida.StyleController = Me.LayoutControl1
        Me.DateEditRequerida.TabIndex = 8
        '
        'DateEditFecha
        '
        Me.DateEditFecha.EditValue = Nothing
        Me.DateEditFecha.Location = New System.Drawing.Point(811, 36)
        Me.DateEditFecha.Name = "DateEditFecha"
        Me.DateEditFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFecha.Size = New System.Drawing.Size(50, 20)
        Me.DateEditFecha.StyleController = Me.LayoutControl1
        Me.DateEditFecha.TabIndex = 7
        '
        'gridLookUpSucursal
        '
        Me.gridLookUpSucursal.Location = New System.Drawing.Point(359, 36)
        Me.gridLookUpSucursal.Name = "gridLookUpSucursal"
        Me.gridLookUpSucursal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.gridLookUpSucursal.Properties.View = Me.GridLookUpEdit1View
        Me.gridLookUpSucursal.Size = New System.Drawing.Size(184, 20)
        Me.gridLookUpSucursal.StyleController = Me.LayoutControl1
        Me.gridLookUpSucursal.TabIndex = 5
        '
        'GridLookUpEdit1View
        '
        Me.GridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridLookUpEdit1View.Name = "GridLookUpEdit1View"
        Me.GridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(811, 12)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(50, 20)
        Me.txtPedido.StyleController = Me.LayoutControl1
        Me.txtPedido.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem11, Me.LayoutControlItem16, Me.LayoutControlItem17})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(873, 120)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.gridLookUpSucursal
        Me.LayoutControlItem2.Location = New System.Drawing.Point(242, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(293, 24)
        Me.LayoutControlItem2.Text = "Sucursal"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtPedido
        Me.LayoutControlItem1.Location = New System.Drawing.Point(694, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem1.Text = "Pedido #"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DateEditFecha
        Me.LayoutControlItem3.Location = New System.Drawing.Point(694, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem3.Text = "Fecha"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DateEditRequerida
        Me.LayoutControlItem4.Location = New System.Drawing.Point(535, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem4.Text = "Requerido "
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.CheckEditTeleventa
        Me.LayoutControlItem5.Location = New System.Drawing.Point(535, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(159, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.MemoEditNota
        Me.LayoutControlItem11.Location = New System.Drawing.Point(242, 48)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(611, 52)
        Me.LayoutControlItem11.Text = "Nota"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Location = New System.Drawing.Point(242, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(293, 24)
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.SearchLookUpEditVendedor
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(242, 100)
        Me.LayoutControlItem17.Text = "Vendedor"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControl4
        '
        Me.LayoutControl4.Controls.Add(Me.SearchLookUpCliente)
        Me.LayoutControl4.Controls.Add(Me.MemoEditNotas)
        Me.LayoutControl4.Controls.Add(Me.DateEditFechaRequerida)
        Me.LayoutControl4.Controls.Add(Me.DateEditFechaPedido)
        Me.LayoutControl4.Controls.Add(Me.chkTeleventa)
        Me.LayoutControl4.Controls.Add(Me.txtPedidoNo)
        Me.LayoutControl4.Controls.Add(Me.SearchLookUpEditVendedores)
        Me.LayoutControl4.Controls.Add(Me.SearchLookUpEditSucursales)
        Me.LayoutControl4.Location = New System.Drawing.Point(-5, -5)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(436, 139, 250, 350)
        Me.LayoutControl4.Root = Me.LayoutControlGroup6
        Me.LayoutControl4.Size = New System.Drawing.Size(885, 182)
        Me.LayoutControl4.TabIndex = 4
        Me.LayoutControl4.Text = "LayoutControl4"
        '
        'MemoEditNotas
        '
        Me.MemoEditNotas.EditValue = ""
        Me.MemoEditNotas.Location = New System.Drawing.Point(76, 120)
        Me.MemoEditNotas.Name = "MemoEditNotas"
        Me.MemoEditNotas.Size = New System.Drawing.Size(785, 38)
        Me.MemoEditNotas.StyleController = Me.LayoutControl4
        Me.MemoEditNotas.TabIndex = 11
        '
        'DateEditFechaRequerida
        '
        Me.DateEditFechaRequerida.EditValue = Nothing
        Me.DateEditFechaRequerida.Location = New System.Drawing.Point(557, 72)
        Me.DateEditFechaRequerida.Name = "DateEditFechaRequerida"
        Me.DateEditFechaRequerida.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFechaRequerida.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFechaRequerida.Size = New System.Drawing.Size(139, 20)
        Me.DateEditFechaRequerida.StyleController = Me.LayoutControl4
        Me.DateEditFechaRequerida.TabIndex = 10
        '
        'DateEditFechaPedido
        '
        Me.DateEditFechaPedido.EditValue = Nothing
        Me.DateEditFechaPedido.Location = New System.Drawing.Point(752, 72)
        Me.DateEditFechaPedido.Name = "DateEditFechaPedido"
        Me.DateEditFechaPedido.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFechaPedido.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFechaPedido.Size = New System.Drawing.Size(109, 20)
        Me.DateEditFechaPedido.StyleController = Me.LayoutControl4
        Me.DateEditFechaPedido.TabIndex = 9
        '
        'chkTeleventa
        '
        Me.chkTeleventa.Location = New System.Drawing.Point(505, 48)
        Me.chkTeleventa.Name = "chkTeleventa"
        Me.chkTeleventa.Properties.Caption = "Televenta"
        Me.chkTeleventa.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.chkTeleventa.Size = New System.Drawing.Size(166, 19)
        Me.chkTeleventa.StyleController = Me.LayoutControl4
        Me.chkTeleventa.TabIndex = 8
        '
        'txtPedidoNo
        '
        Me.txtPedidoNo.Location = New System.Drawing.Point(727, 48)
        Me.txtPedidoNo.Name = "txtPedidoNo"
        Me.txtPedidoNo.Size = New System.Drawing.Size(134, 20)
        Me.txtPedidoNo.StyleController = Me.LayoutControl4
        Me.txtPedidoNo.TabIndex = 7
        '
        'SearchLookUpEditVendedores
        '
        Me.SearchLookUpEditVendedores.Location = New System.Drawing.Point(76, 96)
        Me.SearchLookUpEditVendedores.Name = "SearchLookUpEditVendedores"
        Me.SearchLookUpEditVendedores.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditVendedores.Properties.View = Me.GridView5
        Me.SearchLookUpEditVendedores.Size = New System.Drawing.Size(785, 20)
        Me.SearchLookUpEditVendedores.StyleController = Me.LayoutControl4
        Me.SearchLookUpEditVendedores.TabIndex = 6
        '
        'GridView5
        '
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'SearchLookUpEditSucursales
        '
        Me.SearchLookUpEditSucursales.Location = New System.Drawing.Point(76, 48)
        Me.SearchLookUpEditSucursales.Name = "SearchLookUpEditSucursales"
        Me.SearchLookUpEditSucursales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEditSucursales.Properties.View = Me.GridView3
        Me.SearchLookUpEditSucursales.Size = New System.Drawing.Size(425, 20)
        Me.SearchLookUpEditSucursales.StyleController = Me.LayoutControl4
        Me.SearchLookUpEditSucursales.TabIndex = 5
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup6.GroupBordersVisible = False
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup7})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "Root"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(885, 182)
        Me.LayoutControlGroup6.TextVisible = False
        '
        'LayoutControlGroup7
        '
        Me.LayoutControlGroup7.CaptionImage = CType(resources.GetObject("LayoutControlGroup7.CaptionImage"), System.Drawing.Image)
        Me.LayoutControlGroup7.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem21, Me.LayoutControlItem22, Me.LayoutControlItem23, Me.LayoutControlItem24, Me.LayoutControlItem25, Me.LayoutControlItem26, Me.Cliente, Me.Vendedor})
        Me.LayoutControlGroup7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup7.Name = "LayoutControlGroup7"
        Me.LayoutControlGroup7.Size = New System.Drawing.Size(865, 162)
        Me.LayoutControlGroup7.Text = "Datos del Pedido"
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.SearchLookUpEditSucursales
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(481, 24)
        Me.LayoutControlItem21.Text = "Sucursal"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(49, 13)
        '
        'Vendedor
        '
        Me.Vendedor.Control = Me.SearchLookUpEditVendedores
        Me.Vendedor.Location = New System.Drawing.Point(0, 48)
        Me.Vendedor.Name = "Vendedor"
        Me.Vendedor.Size = New System.Drawing.Size(841, 24)
        Me.Vendedor.TextSize = New System.Drawing.Size(49, 13)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.txtPedidoNo
        Me.LayoutControlItem22.Location = New System.Drawing.Point(651, 0)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(190, 24)
        Me.LayoutControlItem22.Text = "Pedido"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(49, 13)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.chkTeleventa
        Me.LayoutControlItem23.Location = New System.Drawing.Point(481, 0)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(170, 24)
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem23.TextVisible = False
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.DateEditFechaPedido
        Me.LayoutControlItem24.Location = New System.Drawing.Point(676, 24)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(165, 24)
        Me.LayoutControlItem24.Text = "Fecha"
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(49, 13)
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.DateEditFechaRequerida
        Me.LayoutControlItem25.Location = New System.Drawing.Point(481, 24)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(195, 24)
        Me.LayoutControlItem25.Text = "Requerido"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(49, 13)
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.MemoEditNotas
        Me.LayoutControlItem26.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(841, 42)
        Me.LayoutControlItem26.Text = "Notas"
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(49, 13)
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'SearchLookUpCliente
        '
        Me.SearchLookUpCliente.Location = New System.Drawing.Point(76, 72)
        Me.SearchLookUpCliente.Name = "SearchLookUpCliente"
        Me.SearchLookUpCliente.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpCliente.Properties.View = Me.GridView6
        Me.SearchLookUpCliente.Size = New System.Drawing.Size(425, 20)
        Me.SearchLookUpCliente.StyleController = Me.LayoutControl4
        Me.SearchLookUpCliente.TabIndex = 12
        '
        'Cliente
        '
        Me.Cliente.Control = Me.SearchLookUpCliente
        Me.Cliente.Location = New System.Drawing.Point(0, 24)
        Me.Cliente.Name = "Cliente"
        Me.Cliente.Size = New System.Drawing.Size(481, 24)
        Me.Cliente.TextSize = New System.Drawing.Size(49, 13)
        '
        'GridView6
        '
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'frmPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 533)
        Me.Controls.Add(Me.LayoutControl4)
        Me.Controls.Add(Me.LayoutControl3)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "frmPedido"
        Me.ShowIcon = False
        Me.Text = "Pedido para Factura"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.SearchLookUpEditProducto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExistencia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.txtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSubTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIGV.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SearchLookUpEditVendedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEditNota.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditTeleventa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditRequerida.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditRequerida.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridLookUpSucursal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPedido.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl4.ResumeLayout(False)
        CType(Me.MemoEditNotas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFechaRequerida.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFechaRequerida.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFechaPedido.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFechaPedido.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTeleventa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPedidoNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditVendedores.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEditSucursales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Vendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnProd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCant As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrecio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSubTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtExistencia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPrecio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSubTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtIGV As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnAddLinea As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SearchLookUpEditProducto As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnEditar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SearchLookUpEditVendedor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SearchLookUpEditCliente As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MemoEditNota As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents CheckEditTeleventa As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DateEditRequerida As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents gridLookUpSucursal As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtPedido As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SearchLookUpEditClienteView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControl4 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SearchLookUpEditVendedores As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SearchLookUpEditSucursales As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SearchLookUpEditClientes As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Vendedor As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup7 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MemoEditNotas As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents DateEditFechaRequerida As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFechaPedido As DevExpress.XtraEditors.DateEdit
    Friend WithEvents chkTeleventa As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtPedidoNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SearchLookUpCliente As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Cliente As DevExpress.XtraLayout.LayoutControlItem
End Class
