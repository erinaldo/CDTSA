Imports System.Data.SqlClient
Imports Security
Imports System.Configuration

Module Moduloconex

    'Public conex As New SqlConnection("Server=. ; database = Ced ; integrated security = true")
    Public conex As New SqlConnection(ConfigurationManager.ConnectionStrings(IIf(Esquema.Compania = "CEDETSA", "StringConCedetsa", "StringConDasa")).ConnectionString)
    Sub Abrir()
        If conex.State = ConnectionState.Closed Then
            conex.Open()
        End If

    End Sub
    Sub Cerrar()
        If conex.State = ConnectionState.Open Then
            conex.Close()
        End If
    End Sub


End Module
