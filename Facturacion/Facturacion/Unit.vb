Imports System.Data.Sql
Imports System.IO
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports Clases

Module Unit
    Public dtFacturaLinea As New DataTable
    Public dtFacturaLineaLote As New DataTable
    Public gsSucursal As String = "1"
    Public gsUsuario As String = "azepeda"
    Public gParametros As TParametros
    Dim cManager As New ClassManager
    Dim tableData As New DataTable()

    Structure TParametros
        Public IDNivelPrecioPub As Integer
        Public IDPlazoCont As Integer
        Public TipoCambioFact As String
        Public TipoCambioCont As String
        Public IntegracionCont As Boolean
        Public NumeroLineasFact As Integer
        Public IDPaquete As Integer
        Public CtrImpuesto As Integer
        Public ctaimpuesto As Integer
        Public AutorizaPrecioPorFactura As Boolean
        Public FacturaPersonalizada As Boolean
        Public paginaFacturaAltura As Decimal
        Public paginaFacturaAncho As Decimal
        Public DefaultTipoFact As Boolean
        Public TipoFactDefault As Integer
        Public DefaultTipoEntrega As Boolean
        Public TipoEntregaDefault As Integer
        Public EditaPrecioPedidoenFactura As Boolean
        Public EditaCantidadPedidoenFactura As Boolean
    End Structure

    Sub CargagridSearchLookUp(ByVal g As SearchLookUpEdit, sTableName As String, sFieldsName As String, sWhere As String, sOrderBy As String, sDisplayMember As String, sValueMember As String)
        g.Properties.DataSource = cManager.GetDataTable(sTableName, sFieldsName, sWhere, sOrderBy)
        g.Properties.DisplayMember = sDisplayMember
        g.Properties.ValueMember = sValueMember
        g.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit 'DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        g.Properties.PopupFormSize = New Size(250, 250)
        g.Properties.NullText = ""
    End Sub
    Public Function DatoCorrecto(sValor As String, bIsNumeric As Boolean) As String
        Dim sResult As String
        sResult = "OK"
        Try
            If bIsNumeric = False And String.IsNullOrWhiteSpace(sValor) Then
                sResult = "Debe existir un valor válido, no se aceptan vacios"
            End If
            If bIsNumeric Then
                If Not IsNumeric(sValor) Then
                    sResult = "Existe un valor que debe ser numérico, revise por favor "
                    Return sResult
                End If
                If Val(sValor) < 0 Then
                    sResult = "El Valor debe ser Mayor o igual que Cero"
                    Return sResult
                End If
            End If
        Catch ex As Exception
            sResult = "Hubo un error al Validar el Dato " & ex.Message
            Return sResult
        End Try
        Return sResult

    End Function

    Public Function UnicodeBytesToString(
        ByVal bytes() As Byte) As String
        Return System.Text.Encoding.Unicode.GetString(bytes)
    End Function

    Public Sub SaveImage(sTableName As String, MyImage As Image, Id As Integer)

        Dim ImageBytes(0) As Byte
        Using mStream As New MemoryStream()
            MyImage.Save(mStream, MyImage.RawFormat)
            ImageBytes = mStream.ToArray()
        End Using

        Dim adoConnect = New SqlClient.SqlConnection("Server=. ; database = Ced ; integrated security = true")
        Dim adoCommand = New SqlClient.SqlCommand("UPDATE " & sTableName & " SET [Foto]=@MyNewImage WHERE [IDCliente]=@id", adoConnect)

        With adoCommand.Parameters.Add("@MyNewImage", SqlDbType.Image)
            .Value = ImageBytes
            .Size = ImageBytes.Length
        End With
        With adoCommand.Parameters.Add("@id", SqlDbType.BigInt)
            .Value = Id
        End With

        adoConnect.Open()
        adoCommand.ExecuteNonQuery()
        adoConnect.Close()

    End Sub

    Public Function getWordsBeforeOneWord(SearchString As String, my_string As String) As String
        Dim StartP As Integer = 1
        ' to account for the space
        Dim EndP As Integer = InStr(StartP, my_string, " ")
        Return Mid(my_string, StartP, EndP - StartP)

    End Function

    Public Function Solo_Letras(ByVal Teclas As Integer) As Integer
        Dim Resultado As Integer
        Select Case Teclas
            Case 65 To 90, 97 To 122, 165, 13, 8, 32, 44
                Resultado = Teclas
            Case Else
                Resultado = 0
                'Case Else
                '    MessageBox.Show("Solo Letras son Admitidas", "Ayuda", MessageBoxButton.Ok, MessageBoxIcon.Information)
        End Select
        Return Resultado
    End Function

    Public Function Solo_AN(ByVal Teclas As Integer) As Integer
        Dim Resultado As Integer
        Select Case Teclas
            Case 65, 97, 78, 110
                Resultado = Teclas
            Case Else
                Resultado = 0
                'Case Else
                '    MessageBox.Show("Solo Letras son Admitidas", "Ayuda", MessageBoxButton.Ok, MessageBoxIcon.Information)
        End Select
        Return Resultado
    End Function

    Public Function Solo_Numeros(ByVal Teclas As Integer) As Integer
        Dim Resultado As Integer
        Select Case Teclas
            Case 48 To 57, 13, 8, 46
                Resultado = Teclas
            Case Else
                Resultado = 0
                'Case Else
                '    MessageBox.Show("Solo Letras son Admitidas", "Ayuda", MessageBoxButton.Ok, MessageBoxIcon.Information)
        End Select
        Return Resultado
    End Function

    Public Function IsAlphaNumeric(ByVal strInputText As String) As Boolean
        Dim IsAlpha As Boolean = False
        If System.Text.RegularExpressions.Regex.IsMatch(strInputText, "^[a-zA-Z0-9]+$") _
            Or CharAllowed(strInputText) Then
            IsAlpha = True
        Else
            IsAlpha = False
        End If
        Return IsAlpha
    End Function

    Private Function CharAllowed(sChar As String) As Boolean
        Dim wordCharsAllowed() As Char = "-/$%#<>{}".ToCharArray()

        Dim lbOk As Boolean = False

        Dim i As Integer = 0
        While i < wordCharsAllowed.Length And Not lbOk

            If sChar = wordCharsAllowed(i) Then
                lbOk = True
            Else
                lbOk = False
            End If
            i = i + 1
        End While

        Return lbOk
    End Function
   
    Public Function CargaParametros() As Boolean
        Dim lbok As Boolean = False
        Try
            Dim tableParametros As New DataTable()
            Dim iIDParametros As Integer
            Dim t As DataTable
            t = cManager.GetDataTable("fafParametros", "IDParametros", "IDParametros >0", "IDParametros")
            If t.Rows.Count > 0 Then
                iIDParametros = t.Rows(0).Item(0)
            Else
                lbok = False
            End If
            tableParametros = cManager.ExecSPgetData("fafgetParametros", iIDParametros.ToString)
            If tableParametros.Rows.Count > 0 Then
                gParametros.IDNivelPrecioPub = CInt(tableParametros.Rows(0).Item("IDNivelPrecioPub"))
                gParametros.IDPlazoCont = CInt(tableParametros.Rows(0).Item("IDPlazoCont"))
                gParametros.TipoCambioFact = tableParametros.Rows(0).Item("TipoCambioFact").ToString()
                gParametros.TipoCambioCont = tableParametros.Rows(0).Item("TipoCambioCont").ToString
                gParametros.IntegracionCont = Convert.ToBoolean(tableParametros.Rows(0).Item("IntegracionCont"))
                gParametros.NumeroLineasFact = CInt(tableParametros.Rows(0).Item("NumeroLineasFact"))
                gParametros.IDPaquete = CInt(tableParametros.Rows(0).Item("IDPaquete"))
                gParametros.CtrImpuesto = CInt(tableParametros.Rows(0).Item("ctrImpuesto"))
                gParametros.ctaimpuesto = CInt(tableParametros.Rows(0).Item("ctaImpuesto"))
                gParametros.AutorizaPrecioPorFactura = CInt(tableParametros.Rows(0).Item("AutorizaPrecioPorFactura"))
                gParametros.FacturaPersonalizada = Convert.ToBoolean(tableParametros.Rows(0).Item("FacturaPersonalizada"))
                gParametros.paginaFacturaAltura = CDec(tableParametros.Rows(0).Item("paginaFacturaAltura"))
                gParametros.paginaFacturaAncho = CDec(tableParametros.Rows(0).Item("paginaFacturaAncho"))
                gParametros.DefaultTipoFact = Convert.ToBoolean(tableParametros.Rows(0).Item("DefaultTipoFact"))
                gParametros.TipoFactDefault = CInt(tableParametros.Rows(0).Item("TipoFactDefault"))
                gParametros.DefaultTipoEntrega = Convert.ToBoolean(tableParametros.Rows(0).Item("DefaultTipoEntrega"))
                gParametros.TipoEntregaDefault = CInt(tableParametros.Rows(0).Item("TipoEntregaDefault"))
                gParametros.EditaPrecioPedidoenFactura = CInt(tableParametros.Rows(0).Item("EditaPrecioPedidoenFactura"))
                gParametros.EditaCantidadPedidoenFactura = CInt(tableParametros.Rows(0).Item("EditaCantidadPedidoenFactura"))
                lbok = True
            End If
        Catch ex As Exception
            lbok = False
        End Try
        Return lbok
    End Function
    Public Function EsMonedaLocal(piMoneda As Integer) As Boolean
        Dim lbok As Boolean = False
        Try

            Dim t As DataTable
            t = cManager.GetDataTable("globalMoneda", "Nacional", "IDMoneda = " & piMoneda.ToString(), "IDMoneda")
            If t.Rows.Count > 0 Then
                If CBool(t.Rows(0).Item("Nacional")) Then
                    lbok = True
                Else
                    lbok = False
                End If
            Else
                lbok = False
            End If
        Catch ex As Exception
            lbok = False
        End Try
        Return lbok

    End Function
    Public Function IsMaskOK(ByVal smask As String, ByVal sConsecutivo As String) As Boolean
        Dim wordChars() As Char = sConsecutivo.ToCharArray()
        Dim maskChars() As Char = smask.ToCharArray()
        Dim lbOk As Boolean = True

        If wordChars.Length <> maskChars.Length Then
            MessageBox.Show("La longitud de la Máscara: " & smask & " no es igual a la longitud del valor del Consecutivo ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lbOk = False
            Return lbOk
        End If
        Dim i As Integer = 0
        While i < wordChars.Length AndAlso i < maskChars.Length AndAlso lbOk

            If maskChars(i) = "A" And Not IsAlphaNumeric(wordChars(i)) Then
                MessageBox.Show("Error en el valor Alfanumérico permitido  ... " & sConsecutivo & " posición " & (i + 1).ToString() & " valor " & wordChars(i) & " Debe ser Alfanumérico permitido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lbOk = False
            End If

            If maskChars(i) = "N" And Not IsNumeric(wordChars(i)) Then
                MessageBox.Show("Error en el valor Numérico  ... " & sConsecutivo & " posición " & (i + 1).ToString() & " valor " & wordChars(i) & " Debe ser Numérico solamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lbOk = False
            End If
            i = i + 1
        End While

        Return lbOk
    End Function
    Public Sub FormatControlNumber(myText As DevExpress.XtraEditors.TextEdit)
        myText.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        myText.Properties.DisplayFormat.FormatString = "n2"
        myText.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        myText.Properties.EditFormat.FormatString = "n2"
        myText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    End Sub
End Module
