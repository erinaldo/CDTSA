<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopupProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPopupProducto))
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridViewProducto = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.IDProducto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Descr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Alia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Clasif1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Clasif2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Clasif3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Clasif4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Clasif5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Clasif6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Activo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnBonif = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btn_ShowBonif = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.btnVerBonif = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_ShowBonif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(13, 13)
        Me.GridControl1.MainView = Me.GridViewProducto
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.btn_ShowBonif})
        Me.GridControl1.Size = New System.Drawing.Size(1022, 375)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProducto})
        '
        'GridViewProducto
        '
        Me.GridViewProducto.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.IDProducto, Me.Descr, Me.Alia, Me.Clasif1, Me.Clasif2, Me.Clasif3, Me.Clasif4, Me.Clasif5, Me.Clasif6, Me.Activo, Me.btnBonif})
        Me.GridViewProducto.GridControl = Me.GridControl1
        Me.GridViewProducto.Name = "GridViewProducto"
        Me.GridViewProducto.OptionsBehavior.Editable = False
        Me.GridViewProducto.OptionsFind.AlwaysVisible = True
        Me.GridViewProducto.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewProducto.OptionsView.ShowAutoFilterRow = True
        '
        'IDProducto
        '
        Me.IDProducto.Caption = "Código"
        Me.IDProducto.FieldName = "IDProducto"
        Me.IDProducto.Name = "IDProducto"
        Me.IDProducto.Visible = True
        Me.IDProducto.VisibleIndex = 0
        Me.IDProducto.Width = 51
        '
        'Descr
        '
        Me.Descr.Caption = "Descr"
        Me.Descr.FieldName = "Descr"
        Me.Descr.Name = "Descr"
        Me.Descr.Visible = True
        Me.Descr.VisibleIndex = 1
        Me.Descr.Width = 213
        '
        'Alia
        '
        Me.Alia.Caption = "Alias"
        Me.Alia.FieldName = "Alias"
        Me.Alia.Name = "Alia"
        Me.Alia.Visible = True
        Me.Alia.VisibleIndex = 2
        Me.Alia.Width = 162
        '
        'Clasif1
        '
        Me.Clasif1.Caption = "Clasif1"
        Me.Clasif1.FieldName = "Clasif1"
        Me.Clasif1.Name = "Clasif1"
        Me.Clasif1.Visible = True
        Me.Clasif1.VisibleIndex = 3
        Me.Clasif1.Width = 82
        '
        'Clasif2
        '
        Me.Clasif2.Caption = "Clasif2"
        Me.Clasif2.FieldName = "Clasif2"
        Me.Clasif2.Name = "Clasif2"
        Me.Clasif2.Visible = True
        Me.Clasif2.VisibleIndex = 4
        Me.Clasif2.Width = 72
        '
        'Clasif3
        '
        Me.Clasif3.Caption = "Clasif3"
        Me.Clasif3.FieldName = "Clasif3"
        Me.Clasif3.Name = "Clasif3"
        Me.Clasif3.Visible = True
        Me.Clasif3.VisibleIndex = 5
        Me.Clasif3.Width = 92
        '
        'Clasif4
        '
        Me.Clasif4.Caption = "Clasif4"
        Me.Clasif4.FieldName = "Clasif4"
        Me.Clasif4.Name = "Clasif4"
        Me.Clasif4.Visible = True
        Me.Clasif4.VisibleIndex = 6
        Me.Clasif4.Width = 80
        '
        'Clasif5
        '
        Me.Clasif5.Caption = "Clasif5"
        Me.Clasif5.FieldName = "Clasif5"
        Me.Clasif5.Name = "Clasif5"
        Me.Clasif5.Visible = True
        Me.Clasif5.VisibleIndex = 7
        Me.Clasif5.Width = 65
        '
        'Clasif6
        '
        Me.Clasif6.Caption = "Clasif6"
        Me.Clasif6.FieldName = "Clasif6"
        Me.Clasif6.Name = "Clasif6"
        Me.Clasif6.Visible = True
        Me.Clasif6.VisibleIndex = 8
        Me.Clasif6.Width = 68
        '
        'Activo
        '
        Me.Activo.Caption = "Activo"
        Me.Activo.FieldName = "Activo"
        Me.Activo.Name = "Activo"
        Me.Activo.Visible = True
        Me.Activo.VisibleIndex = 9
        Me.Activo.Width = 48
        '
        'btnBonif
        '
        Me.btnBonif.Caption = "Bonifica"
        Me.btnBonif.ColumnEdit = Me.btn_ShowBonif
        Me.btnBonif.Name = "btnBonif"
        Me.btnBonif.Visible = True
        Me.btnBonif.VisibleIndex = 10
        Me.btnBonif.Width = 71
        '
        'btn_ShowBonif
        '
        Me.btn_ShowBonif.AutoHeight = False
        Me.btn_ShowBonif.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("btn_ShowBonif.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.btn_ShowBonif.ContextImage = CType(resources.GetObject("btn_ShowBonif.ContextImage"), System.Drawing.Image)
        Me.btn_ShowBonif.Name = "btn_ShowBonif"
        '
        'btnVerBonif
        '
        Me.btnVerBonif.Location = New System.Drawing.Point(817, 30)
        Me.btnVerBonif.Name = "btnVerBonif"
        Me.btnVerBonif.Size = New System.Drawing.Size(86, 23)
        Me.btnVerBonif.TabIndex = 1
        Me.btnVerBonif.Text = "F1 Bonificación"
        '
        'frmPopupProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1047, 391)
        Me.Controls.Add(Me.btnVerBonif)
        Me.Controls.Add(Me.GridControl1)
        Me.KeyPreview = True
        Me.Name = "frmPopupProducto"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Productos"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_ShowBonif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProducto As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents IDProducto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Descr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Alia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Clasif1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Clasif2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Clasif3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Clasif4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Clasif5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Clasif6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Activo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnBonif As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btn_ShowBonif As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents btnVerBonif As DevExpress.XtraEditors.SimpleButton
End Class
