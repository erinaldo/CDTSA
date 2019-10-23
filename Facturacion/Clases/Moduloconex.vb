Imports System.Data.SqlClient

Module Moduloconex
    Public conex As New SqlConnection("Server=. ; database = Ced ; integrated security = true")
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
