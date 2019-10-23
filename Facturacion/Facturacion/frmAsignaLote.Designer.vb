<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignaLote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignaLote))
        Me.datagridLotes = New DevExpress.XtraGrid.GridControl()
        Me.GridViewProducto = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.txtProducto = New DevExpress.XtraEditors.TextEdit()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalAsignado = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalExistencia = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalBO = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAplicar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.chkBonifProd = New System.Windows.Forms.CheckBox()
        Me.chkBonifica = New System.Windows.Forms.CheckBox()
        Me.txtRequerido = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtBono = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnBonif = New DevExpress.XtraEditors.SimpleButton()
        Me.lblBonifPedido = New System.Windows.Forms.Label()
        Me.txtBonifPedido = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.datagridLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProducto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAsignado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalExistencia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRequerido.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBono.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBonifPedido.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'datagridLotes
        '
        Me.datagridLotes.Location = New System.Drawing.Point(12, 73)
        Me.datagridLotes.MainView = Me.GridViewProducto
        Me.datagridLotes.Name = "datagridLotes"
        Me.datagridLotes.Size = New System.Drawing.Size(831, 273)
        Me.datagridLotes.TabIndex = 0
        Me.datagridLotes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProducto})
        '
        'GridViewProducto
        '
        Me.GridViewProducto.GridControl = Me.datagridLotes
        Me.GridViewProducto.Name = "GridViewProducto"
        Me.GridViewProducto.OptionsView.ShowGroupPanel = False
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(23, 12)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtProducto.Properties.Appearance.Options.UseFont = True
        Me.txtProducto.Properties.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(475, 22)
        Me.txtProducto.TabIndex = 1
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(24, 41)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(141, 17)
        Me.lblCantidad.TabIndex = 2
        Me.lblCantidad.Text = "Cantidad a Facturar :"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(189, 38)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtCantidad.Properties.DisplayFormat.FormatString = "n2"
        Me.txtCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCantidad.Properties.EditFormat.FormatString = "n2"
        Me.txtCantidad.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtCantidad.Properties.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(87, 22)
        Me.txtCantidad.TabIndex = 3
        '
        'txtTotalAsignado
        '
        Me.txtTotalAsignado.Location = New System.Drawing.Point(682, 370)
        Me.txtTotalAsignado.Name = "txtTotalAsignado"
        Me.txtTotalAsignado.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTotalAsignado.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalAsignado.Size = New System.Drawing.Size(77, 20)
        Me.txtTotalAsignado.TabIndex = 4
        '
        'txtTotalExistencia
        '
        Me.txtTotalExistencia.Location = New System.Drawing.Point(596, 370)
        Me.txtTotalExistencia.Name = "txtTotalExistencia"
        Me.txtTotalExistencia.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTotalExistencia.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalExistencia.Size = New System.Drawing.Size(80, 20)
        Me.txtTotalExistencia.TabIndex = 5
        '
        'txtTotalBO
        '
        Me.txtTotalBO.Location = New System.Drawing.Point(765, 370)
        Me.txtTotalBO.Name = "txtTotalBO"
        Me.txtTotalBO.Properties.Appearance.Options.UseTextOptions = True
        Me.txtTotalBO.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalBO.Size = New System.Drawing.Size(78, 20)
        Me.txtTotalBO.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(550, 372)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Totales :"
        '
        'btnAplicar
        '
        Me.btnAplicar.Image = CType(resources.GetObject("btnAplicar.Image"), System.Drawing.Image)
        Me.btnAplicar.Location = New System.Drawing.Point(198, 367)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(98, 22)
        Me.btnAplicar.TabIndex = 9
        Me.btnAplicar.Text = "Aplicar Lotes"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(323, 368)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(98, 22)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Salir"
        '
        'chkBonifProd
        '
        Me.chkBonifProd.AutoSize = True
        Me.chkBonifProd.Location = New System.Drawing.Point(667, 42)
        Me.chkBonifProd.Name = "chkBonifProd"
        Me.chkBonifProd.Size = New System.Drawing.Size(176, 17)
        Me.chkBonifProd.TabIndex = 11
        Me.chkBonifProd.Text = "La Bonificacion  usa producto ?"
        Me.chkBonifProd.UseVisualStyleBackColor = True
        '
        'chkBonifica
        '
        Me.chkBonifica.AutoSize = True
        Me.chkBonifica.Location = New System.Drawing.Point(530, 41)
        Me.chkBonifica.Name = "chkBonifica"
        Me.chkBonifica.Size = New System.Drawing.Size(131, 17)
        Me.chkBonifica.TabIndex = 13
        Me.chkBonifica.Text = "El Producto Bonifica ?"
        Me.chkBonifica.UseVisualStyleBackColor = True
        '
        'txtRequerido
        '
        Me.txtRequerido.Location = New System.Drawing.Point(705, 12)
        Me.txtRequerido.Name = "txtRequerido"
        Me.txtRequerido.Size = New System.Drawing.Size(54, 20)
        Me.txtRequerido.TabIndex = 14
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(650, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "Requerido"
        '
        'txtBono
        '
        Me.txtBono.Location = New System.Drawing.Point(796, 12)
        Me.txtBono.Name = "txtBono"
        Me.txtBono.Size = New System.Drawing.Size(55, 20)
        Me.txtBono.TabIndex = 16
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(766, 13)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 17
        Me.LabelControl2.Text = "Bono"
        '
        'btnBonif
        '
        Me.btnBonif.Image = CType(resources.GetObject("btnBonif.Image"), System.Drawing.Image)
        Me.btnBonif.Location = New System.Drawing.Point(504, 10)
        Me.btnBonif.Name = "btnBonif"
        Me.btnBonif.Size = New System.Drawing.Size(140, 22)
        Me.btnBonif.TabIndex = 18
        Me.btnBonif.Text = "Tabla Bonificaciones"
        '
        'lblBonifPedido
        '
        Me.lblBonifPedido.AutoSize = True
        Me.lblBonifPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBonifPedido.Location = New System.Drawing.Point(282, 40)
        Me.lblBonifPedido.Name = "lblBonifPedido"
        Me.lblBonifPedido.Size = New System.Drawing.Size(139, 17)
        Me.lblBonifPedido.TabIndex = 19
        Me.lblBonifPedido.Text = "Bonificar en Pedido :"
        '
        'txtBonifPedido
        '
        Me.txtBonifPedido.Location = New System.Drawing.Point(420, 38)
        Me.txtBonifPedido.Name = "txtBonifPedido"
        Me.txtBonifPedido.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.txtBonifPedido.Properties.Appearance.Options.UseFont = True
        Me.txtBonifPedido.Properties.DisplayFormat.FormatString = "n2"
        Me.txtBonifPedido.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBonifPedido.Properties.EditFormat.FormatString = "n2"
        Me.txtBonifPedido.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBonifPedido.Properties.ReadOnly = True
        Me.txtBonifPedido.Size = New System.Drawing.Size(87, 22)
        Me.txtBonifPedido.TabIndex = 20
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(718, 352)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl3.TabIndex = 22
        Me.LabelControl3.Text = "Facturar"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(628, 351)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl4.TabIndex = 23
        Me.LabelControl4.Text = "Existencia"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(796, 351)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl5.TabIndex = 24
        Me.LabelControl5.Text = "Bonificar"
        '
        'frmAsignaLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 400)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtBonifPedido)
        Me.Controls.Add(Me.lblBonifPedido)
        Me.Controls.Add(Me.btnBonif)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtBono)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtRequerido)
        Me.Controls.Add(Me.chkBonifica)
        Me.Controls.Add(Me.chkBonifProd)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAplicar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTotalBO)
        Me.Controls.Add(Me.txtTotalExistencia)
        Me.Controls.Add(Me.txtTotalAsignado)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.datagridLotes)
        Me.Name = "frmAsignaLote"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "-"
        CType(Me.datagridLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProducto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAsignado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalExistencia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRequerido.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBono.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBonifPedido.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents datagridLotes As DevExpress.XtraGrid.GridControl
    Friend WithEvents txtProducto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTotalAsignado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTotalExistencia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridViewProducto As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtTotalBO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAplicar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkBonifProd As System.Windows.Forms.CheckBox
    Friend WithEvents chkBonifica As System.Windows.Forms.CheckBox
    Friend WithEvents txtRequerido As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtBono As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnBonif As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblBonifPedido As System.Windows.Forms.Label
    Friend WithEvents txtBonifPedido As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class
