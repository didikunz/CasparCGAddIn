Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Class frmSelectQuery

   Private _wrkSheet As Worksheet
   Private _currentRow As Integer

   Public WriteOnly Property wrkSheet As Worksheet
      Set(value As Worksheet)
         _wrkSheet = value
      End Set
   End Property

   Public WriteOnly Property currentRow As Integer
      Set(value As Integer)
         _currentRow = value
      End Set
   End Property

   Private Sub frmSelectQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim range As Excel.Range = _wrkSheet.Cells
      Dim que As String = ""

      'Cue/Query
      Dim cell As Excel.Range = Range(_currentRow, 1)
      If cell.Value IsNot Nothing AndAlso cell.Text.ToString.StartsWith("{") Then
         que = cell.Text.ToString.Substring(1, cell.Text.ToString.Length - 2)
      End If

      For Each con In AppObject.Connections
         Dim n As String = con.Name
         lbQueries.Items.Add(n)
      Next

      For c As Integer = 0 To lbQueries.Items.Count - 1
         If que = lbQueries.Items(c) Then
            lbQueries.SelectedIndex = c
            Exit For
         End If
      Next

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      Dim range As Excel.Range = _wrkSheet.Cells

      'Cue/Query
      Dim cell As Excel.Range = range(_currentRow, 1)
      cell.Value = "{" + lbQueries.Items(lbQueries.SelectedIndex) + "}"

      Me.DialogResult = DialogResult.OK

   End Sub

End Class