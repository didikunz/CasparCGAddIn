Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net

Public Class frmSetupWebData

   Public Class WebData
      Public Property Name As String
      Public Property Value As String
      Public Property IsSelected As Boolean

      Public Overrides Function ToString() As String
         Return String.Format("{0}: '{1}'", Me.Name, Me.Value)
      End Function

   End Class


   Private _wrkSheet As Worksheet
   Private _webDatas As List(Of WebData)
   Private _hashPropNames As HashSet(Of String)

   Private _isRowQuery As Boolean = False

   Public WriteOnly Property wrkSheet As Worksheet
      Set(value As Worksheet)
         _wrkSheet = value
      End Set
   End Property

   Private Sub frmSetupWebData_Load(sender As Object, e As EventArgs) Handles Me.Load

      If _wrkSheet IsNot Nothing Then

         Dim range As Excel.Range = _wrkSheet.Cells()
         Dim cell As Excel.Range = range(1, 1)

         Dim url As String = cell.Text.ToString
         If Uri.IsWellFormedUriString(url, UriKind.Absolute) Then

            'Page Query
            txtURL.Text = url

            If LoadFieldNames() Then
               SelectField()
            End If

         Else

            cell = range(3, 1)
            url = cell.Text.ToString

            If Uri.IsWellFormedUriString(url, UriKind.Absolute) Then

               'Row Query
               _isRowQuery = True

               txtURL.Text = url

               If LoadFieldNames() Then
                  SelectField()
               End If

            End If

         End If

      End If

   End Sub

   Private Function LoadFieldNames() As Boolean

      Dim retVal As Boolean = False

      _webDatas = New List(Of WebData)
      _hashPropNames = New HashSet(Of String)

      Using client As WebClient = New WebClient

         Try

            Dim json As String = client.DownloadString(txtURL.Text)

            Dim rd As JsonTextReader = New JsonTextReader(New StringReader(json))
            Dim wData As WebData = Nothing

            While rd.Read

               If rd.Value <> Nothing Then

                  If rd.TokenType = JsonToken.PropertyName Then

                     Dim s = rd.Path.Substring(rd.Path.IndexOf("]", 0) + 1)

                     If Not _hashPropNames.Contains(s) Then
                        wData = New WebData
                        wData.Name = s
                     End If

                  Else

                     If wData IsNot Nothing Then

                        If rd.TokenType <> JsonToken.EndObject And rd.TokenType <> JsonToken.StartObject Then

                           If Not _hashPropNames.Contains(wData.Name) Then

                              wData.Value = rd.Value.ToString

                              _hashPropNames.Add(wData.Name)
                              _webDatas.Add(wData)

                           End If

                        End If

                     End If

                  End If

               Else

                  If wData IsNot Nothing Then

                     If rd.TokenType <> JsonToken.EndObject And rd.TokenType <> JsonToken.StartObject Then

                        If Not _hashPropNames.Contains(wData.Name) Then

                           wData.Value = "{Nothing}"

                           _hashPropNames.Add(wData.Name)
                           _webDatas.Add(wData)

                        End If

                     End If

                  End If

               End If

            End While


            bsWebDatas.DataSource = _webDatas
            bsWebDatas.ResetBindings(False)

            retVal = True

         Catch ex As Exception

            MsgBox(String.Format("Connection to web service failed '{0}'", ex.Message))

         End Try

      End Using

      Return retVal

   End Function

   Private Sub SelectField()

      Dim col As Integer = 1
      Dim range As Excel.Range = _wrkSheet.Cells()
      Dim cell As Excel.Range = Nothing

      Dim hashNames As HashSet(Of String) = New HashSet(Of String)

      If _isRowQuery Then col = 2

      Do
         cell = range(2, col)
         If cell.Text <> "" Then
            hashNames.Add(cell.Text)
         Else
            Exit Do
         End If
         col += 1
      Loop

      For Each wd As WebData In _webDatas
         wd.IsSelected = hashNames.Contains(wd.Name)
      Next

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      Dim col As Integer = 1
      Dim range As Excel.Range = _wrkSheet.Cells()
      Dim cell As Excel.Range = Nothing

      If _isRowQuery Then col = 2

      For Each wd As WebData In _webDatas

         If wd.IsSelected Then

            cell = range(2, col)
            cell.Value = wd.Name
            col += 1

         End If

      Next

      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()

   End Sub

End Class