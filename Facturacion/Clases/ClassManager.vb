Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Collections.Specialized
Imports System.IO
Imports System.Drawing


Public Class ClassManager
    Private cmdb As SqlCommandBuilder
    Private cmd As SqlCommand
    Public ds As New DataSet()
    Public da As New SqlDataAdapter()
    Public batchSQLitem As New StringCollection
    Public batchSQLLista As New List(Of CbatchSQLIitem)

    Public batchReturnAutoNumericInt As Boolean = False
    Public batchAutoNumericInt As Integer = 0
    Public IDAutoFirstParent As Integer = 0
    Public schemaName As String = ""


    Public Function CreateInsertSql(ByVal pTableName As String, ByVal pFields As String, ByVal pValues As String) As String
        Dim SQL As New StringBuilder
        Try
            SQL.AppendLine("INSERT INTO " & IIf(schemaName <> "", schemaName, "dbo" & "." & pTableName))
            SQL.Append(String.Format(" ({0})", pFields))
            SQL.AppendLine(String.Format(" VALUES ({0}) ", pValues))
        Catch ex As Exception
            Throw
            SQL = New StringBuilder
        Finally

        End Try

        Return SQL.ToString
    End Function
    'insertar
    Public Function Insert(ByVal sTableName As String, ByVal sFields As String, ByVal sValues As String) As Boolean
        Dim i As Integer
        Dim sql As String
        Dim bOk As Boolean
        Try
            sql = CreateInsertSql(sTableName, sFields, sValues)
            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If
            conex.Open()
            cmd = New SqlCommand(sql, conex)
            i = cmd.ExecuteNonQuery()
            If i > 0 Then
                bOk = True
            Else
                bOk = False
            End If
            conex.Close()
            Return bOk
        Catch ex As Exception
            Throw
            bOk = False
            Return bOk
        Finally

        End Try

    End Function
    Public Function CreateDeleteSql(ByVal pTableName As String, ByVal pWHERE As String) As String
        Dim SQL As New StringBuilder
        Try
            SQL.AppendLine("DELETE FROM  " & IIf(schemaName <> "", schemaName, "dbo" & "." & pTableName))
            SQL.AppendLine(String.Format("WHERE {0} ", pWHERE))
        Catch ex As Exception
            Throw
            SQL = New StringBuilder
        Finally

        End Try

        Return SQL.ToString
    End Function

    Public Function CreateFunctionSql(ByVal pFunctionName As String, ByVal pParametros As String) As String
        Dim SQL As New StringBuilder
        Try
            SQL.AppendLine("SELECT   " & IIf(schemaName <> "", schemaName, "dbo" & "." & pFunctionName))
            SQL.AppendLine(String.Format("( {0} )", pParametros))
        Catch ex As Exception
            Throw
            SQL = New StringBuilder
        Finally

        End Try

        Return SQL.ToString
    End Function

    'eliminar
    Public Function Delete(sTablaName As String, sCondicion As String) As Boolean
        Dim i As Integer
        Dim sql As String
        Dim bOk As Boolean
        Try
            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If
            conex.Open()
            'Dim sql As String = "Delete From " & sTablaName & sCondicion
            sql = CreateDeleteSql(sTablaName, sCondicion)
            cmd = New SqlCommand(sql, conex)
            i = cmd.ExecuteNonQuery()
            If i > 0 Then
                bOk = True
            Else
                bOk = False
            End If
            conex.Close()
            Return bOk
        Catch ex As Exception
            Throw
            bOk = False
            Return bOk
        Finally

        End Try
        Return bOk
    End Function

    Public Function CreateUpdateSql(ByVal pTableName As String, ByVal pSetValues As String, ByVal pWHERE As String) As String
        Dim SQL As New StringBuilder
        Try
            SQL.AppendLine("UPDATE " & IIf(schemaName <> "", schemaName, "dbo" & "." & pTableName))
            SQL.AppendLine(String.Format("SET {0}", pSetValues))
            SQL.AppendLine(String.Format("WHERE {0} ", pWHERE))
        Catch ex As Exception
            Throw
            SQL = New StringBuilder
        Finally

        End Try

        Return SQL.ToString
    End Function
    Public Function Update(sTableName As String, sSetValues As String, sWhere As String) As Boolean
        Dim i As Integer
        Dim sql As String
        Dim bOk As Boolean
        Try
            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If
            conex.Open()
            'Dim sql As String = "Update " & sTablaName & " set " & sFieldNames & sCondicion
            sql = CreateUpdateSql(sTableName, sSetValues, sWhere)
            cmd = New SqlCommand(sql, conex)
            i = cmd.ExecuteNonQuery()

            If i > 0 Then
                bOk = True
            Else
                bOk = False
            End If
            conex.Close()
            Return bOk
        Catch ex As Exception
            Throw
            bOk = False
            Return bOk
        Finally

        End Try
    End Function

    Public Function ExecSPwithImage(sNameStoreProc As String, sParameters As String, MyImage As Image) As Boolean
        Dim sql As String
        Dim bOk As Boolean
        Dim i As Integer

        Try
            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If
            conex.Open()
            ' sNameStoreProc = IIf(schemaName <> "", schemaName, "dbo" & "." & sNameStoreProc)
            If Not (MyImage Is Nothing) Then
                Dim ImageBytes(0) As Byte
                Using mStream As New MemoryStream()
                    MyImage.Save(mStream, MyImage.RawFormat)
                    ImageBytes = mStream.ToArray()
                End Using

                sParameters = sParameters & ",@MyNewImage"
                sql = CreateStoreProcSql(sNameStoreProc, sParameters)
                cmd = New SqlCommand(sql, conex)

                With cmd.Parameters.Add("@MyNewImage", SqlDbType.Image)
                    .Value = ImageBytes
                    .Size = ImageBytes.Length
                End With
            Else
                sql = CreateStoreProcSql(sNameStoreProc, sParameters)
                cmd = New SqlCommand(sql, conex)
            End If

            i = cmd.ExecuteNonQuery()
            conex.Close()
            bOk = True
        Catch ex As Exception
            Throw
            bOk = False
        Finally

        End Try
        Return bOk

    End Function


    Public Function ExecSP(sNameStoreProc As String, sParameters As String) As Boolean
        Dim sql As String
        Dim bOk As Boolean
        Dim i As Integer

        Try
            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If
            conex.Open()
            ' sNameStoreProc = IIf(schemaName <> "", schemaName, "dbo" & "." & sNameStoreProc)
            sql = CreateStoreProcSql(sNameStoreProc, sParameters)
            cmd = New SqlCommand(sql, conex)
            i = cmd.ExecuteNonQuery()
            conex.Close()
            bOk = True
        Catch ex As Exception
            Throw
            bOk = False
        Finally

        End Try
        Return bOk

    End Function

    Public Function ExecSPgetData(sNameStoreProc As String, sParameters As String) As DataTable
        Dim sql As String
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        Try
            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If
            conex.Open()
            'sNameStoreProc = IIf(schemaName <> "", schemaName, "dbo" & "." & sNameStoreProc)
            sql = CreateStoreProcSql(sNameStoreProc, sParameters)
            cmd = New SqlCommand(sql, conex)
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            conex.Close()
            Return dt
        Catch ex As Exception
            Throw
            dt = New DataTable
            Return dt
        Finally

        End Try


    End Function

    Public Function ExecFunction(sFunctionName As String, sParameters As String) As DataTable
        Dim sql As String
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        Try
            If conex.State = ConnectionState.Open Then
                conex.Close()
            End If
            conex.Open()
            'sNameStoreProc = IIf(schemaName <> "", schemaName, "dbo" & "." & sNameStoreProc)
            sql = CreateFunctionSql(sFunctionName, sParameters)
            cmd = New SqlCommand(sql, conex)
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            conex.Close()
            Return dt
        Catch ex As Exception
            Throw
            dt = New DataTable
            Return dt
        Finally

        End Try


    End Function

    Public Function ExecFunctionWithinTransacction(conex As SqlConnection, tran As SqlTransaction, sFunctionName As String, sParameters As String) As DataTable
        Dim sql As String
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        Try

            'sNameStoreProc = IIf(schemaName <> "", schemaName, "dbo" & "." & sNameStoreProc)
            sql = CreateFunctionSql(sFunctionName, sParameters)
            cmd = New SqlCommand(sql, conex, tran)
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            Return dt
        Catch ex As Exception
            Throw
            dt = New DataTable
            Return dt
        Finally

        End Try


    End Function


    Public Function CreateSelectSql(ByVal pTableName As String, ByVal pFields As String, ByVal pWHERE As String, ByVal pOrderBy As String) As String
        Dim SQL As New StringBuilder
        Try
            pTableName = IIf(schemaName <> "", schemaName, "dbo" & "." & pTableName)
            SQL.AppendLine(String.Format("SELECT {0} FROM {1}  ", pFields, pTableName))

            If pWHERE.Length > 0 Then
                SQL.AppendLine(String.Format("WHERE {0} ", pWHERE))
            End If

            If pOrderBy.Length > 0 Then
                SQL.AppendLine(String.Format("ORDER BY {0} ", pOrderBy))
            End If

        Catch ex As Exception
            Throw
            SQL = New StringBuilder
        Finally

        End Try

        Return SQL.ToString
    End Function

    Public Function CreateStoreProcSql(ByVal pStoreName As String, ByVal pParameters As String) As String
        Dim SQL As New StringBuilder
        Try
            If pStoreName.Length > 0 Then
                pStoreName = IIf(schemaName <> "", schemaName, "dbo" & "." & pStoreName)
                SQL.AppendLine(String.Format(" Exec {0}", pStoreName))
            End If
            If pParameters.Length > 0 Then
                SQL.AppendLine(String.Format("{0}", pParameters))
            End If

        Catch ex As Exception
            Throw
            SQL = New StringBuilder
        Finally

        End Try

        Return SQL.ToString
    End Function

    Public Sub GetData(sTableName As String, sFields As String, sWHERE As String, sOrderBy As String)
        Dim sql As String
        Try
            sTableName = IIf(schemaName <> "", schemaName, "dbo" & "." & sTableName)
            sql = CreateSelectSql(sTableName, sFields, sWHERE, sOrderBy)
            ds.Clear()
            da = New SqlDataAdapter(sql, conex)
            cmdb = New SqlCommandBuilder(da)
            da.Fill(ds, sTableName)
        Catch ex As Exception
            Throw
        Finally

        End Try

    End Sub

    Public Function GetDataTable(sTableName As String, sFields As String, sWHERE As String, sOrderBy As String) As DataTable
        Dim sql As String
        Dim dt As DataTable
        Dim da As SqlDataAdapter
        Dim dts As DataSet
        Try
            ''sTableName = IIf(schemaName <> "", schemaName, "dbo" & "." & sTableName)
            sql = CreateSelectSql(sTableName, sFields, sWHERE, sOrderBy)
            da = New SqlDataAdapter(sql, conex)
            dts = New DataSet()
            da.Fill(dts, sTableName)
            dt = New DataTable()
            dt = dts.Tables(sTableName)
            Return dt
        Catch ex As Exception
            Throw
            dt = New DataTable
            Return dt
        Finally

        End Try
    End Function

    Public Function GetDescrFromTable(sTableName As String, sFieldDescr As String, sWHERE As String, sOrderBy As String) As String
        Dim sql As String
        Dim dt As DataTable
        Dim da As SqlDataAdapter
        Dim dts As DataSet
        Dim strDescr As String = ""
        Try
            ''sTableName = IIf(schemaName <> "", schemaName, "dbo" & "." & sTableName)
            sql = CreateSelectSql(sTableName, sFieldDescr, sWHERE, sOrderBy)
            da = New SqlDataAdapter(sql, conex)
            dts = New DataSet()
            da.Fill(dts, sTableName)
            dt = New DataTable()
            dt = dts.Tables(sTableName)
            If dt.Rows.Count > 0 Then
                strDescr = dt.Rows(0)(sFieldDescr).ToString()
            End If
            Return strDescr
        Catch ex As Exception
            Throw
            strDescr = ""
            Return sFieldDescr
        Finally

        End Try
    End Function

    Public Function ExistsInTable(sTableName As String, sFieldDescr As String, sWHERE As String, sOrderBy As String) As Boolean
        Dim sql As String
        Dim dt As DataTable
        Dim da As SqlDataAdapter
        Dim dts As DataSet
        Dim strDescr As String = ""
        Dim lbResult As Boolean = False
        Try
            sql = CreateSelectSql(sTableName, sFieldDescr, sWHERE, sOrderBy)
            da = New SqlDataAdapter(sql, conex)
            dts = New DataSet()
            da.Fill(dts, sTableName)
            dt = New DataTable()
            dt = dts.Tables(sTableName)
            If dt.Rows.Count > 0 Then
                lbResult = True
            End If
            Return lbResult
        Catch ex As Exception
            Throw
            lbResult = False
            Return lbResult
        Finally

        End Try
    End Function



    Public Sub ClearsqlCollation()
        batchSQLitem.Clear()
    End Sub


    Public Function ExecCmdWithTransaction() As Boolean
        Dim bOk As Boolean
        Dim i As Integer
        Dim index As Integer
        Dim dt As DataTable
        Dim dtItemsSqlParentID As New DataTable
        Dim iAutoNumeric As Integer
        'Dim iAutoNumericAnterior As Integer
        bOk = False

        Dim tran As SqlTransaction
        If conex.State = ConnectionState.Open Then
            conex.Close()
        End If
        conex.Open()
        tran = conex.BeginTransaction
        Try

            dtItemsSqlParentID.Columns.Add("ID", GetType(Integer))
            dtItemsSqlParentID.Columns.Add("EsParent", GetType(Boolean))
            dtItemsSqlParentID.Columns.Add("UsaParent", GetType(Boolean))
            dtItemsSqlParentID.Columns.Add("IDAuto", GetType(Integer))
            dtItemsSqlParentID.Columns.Add("IDParent", GetType(Integer))
            dtItemsSqlParentID.Columns.Add("ProcesoPadre", GetType(String))
            dtItemsSqlParentID.Columns.Add("ProcesoHijo", GetType(String))

            ' LLeno la tabla con los padres e hijos
            index = 0
            For Each item As CbatchSQLIitem In batchSQLLista
                dtItemsSqlParentID.Rows.Add(index, item.EsParentID, item.UsaParentID, 0, 0, item.sProcesoPadre, item.sProcesoHijo)
                index = index + 1
            Next


            batchAutoNumericInt = 0

            index = 0
            For Each item As CbatchSQLIitem In batchSQLLista

                If item.UsaAutoNumericInteger And item.UsaParentID Then
                    Dim theRow As DataRow() = dtItemsSqlParentID.Select("ID=" & (index).ToString())
                    If theRow.Count > 0 Then

                        If Not CBool(theRow(0)("EsParent")) And CBool(theRow(0)("UsaParent")) Then
                            Dim theRow3 As DataRow() = dtItemsSqlParentID.Select("ID=" & (index - 1).ToString())
                            If theRow3.Count > 0 Then
                                iAutoNumeric = CInt(theRow3(0)("IDAuto"))
                                theRow(0)("IDParent") = iAutoNumeric
                                ' si usa autonumeric y aun asi devuelve valor cero el parent
                                If iAutoNumeric = 0 Then
                                    Dim theRow4 As DataRow() = dtItemsSqlParentID.Select("ID=" & (index - 1).ToString())
                                    If theRow4.Count > 0 Then
                                        iAutoNumeric = CInt(theRow4(0)("IDParent"))
                                        theRow(0)("IDParent") = iAutoNumeric
                                    End If
                                End If
                            End If

                        End If
                        If CBool(theRow(0)("EsParent")) And CBool(theRow(0)("UsaParent")) Then
 
                            iAutoNumeric = CInt(theRow(0)("IDParent"))
                            theRow(0)("IDParent") = iAutoNumeric

                        End If
                        item.sql = item.sql.Replace("@@Identity", iAutoNumeric.ToString())

                    End If
                End If
                cmd = New SqlCommand(item.sql, conex, tran)
                i = cmd.ExecuteNonQuery()

                If item.gRetornaIDNumerico = True Then
                    dt = ExecFunctionWithinTransacction(conex, tran, "getAutoIDInt", "")
                    If item.EsParentID Then

                        batchAutoNumericInt = dt.Rows(0).Item(0)

                    End If

                    ' actualizo el IDAuto del parent
                    Dim myRow() As Data.DataRow
                    myRow = dtItemsSqlParentID.Select("ID=" & index.ToString() & " and ProcesoHijo = '" & item.sProcesoHijo & "'")
                    ' si es la raiz de todo
                    If myRow(0)("Esparent") And myRow(0)("UsaParent") = False Then
                        myRow(0)("IDAuto") = batchAutoNumericInt
                        myRow(0)("IDParent") = batchAutoNumericInt
                        IDAutoFirstParent = batchAutoNumericInt
                        ' actualizo el ID padre en toda la gerarquia
                        Dim myRow2() As Data.DataRow
                        myRow2 = dtItemsSqlParentID.Select("ProcesoPadre = '" & item.sProcesoHijo & "'")
                        For j = 0 To myRow2.Count - 1
                            myRow2(j)("IDParent") = batchAutoNumericInt
                        Next
                    Else
                        myRow(0)("IDAuto") = batchAutoNumericInt
                    End If
                End If
                index = index + 1
            Next

            bOk = True
        Catch ex As Exception
            bOk = False
            tran.Rollback()
            conex.Close()
            Throw
            Return bOk
        End Try
        tran.Commit()
        conex.Close()
        Return bOk
    End Function



End Class
