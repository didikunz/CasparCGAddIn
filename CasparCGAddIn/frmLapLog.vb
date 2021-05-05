Imports Microsoft.Office.Interop.Excel
Imports CasparObjects
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class frmLapLog

   Private _currentLapLogItem As LapLogItem = Nothing

   Private _wrkBook As Workbook

   Public Property currentLapLogItem As LapLogItem
      Get
         Return _currentLapLogItem
      End Get
      Set(value As LapLogItem)
         _currentLapLogItem = value
      End Set
   End Property

   Public WriteOnly Property wrkBook As Workbook
      Set(value As Workbook)
         _wrkBook = value
      End Set
   End Property

   Private Sub frmLapLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      If _currentLapLogItem IsNot Nothing AndAlso _wrkBook IsNot Nothing Then

         cboLapSheet.Items.Clear()
         cboLogSheet.Items.Clear()
         cboLapSheet.Items.Add("(None)")
         cboLogSheet.Items.Add("(None)")
         For Each wrk As Worksheet In _wrkBook.Sheets
            Dim sh As String = wrk.Name.ToString.Trim
            cboLapSheet.Items.Add(sh)
            cboLogSheet.Items.Add(sh)
         Next

         txtName.Text = _currentLapLogItem.Name

         'LAP
         cboLapSheet.SelectedIndex = 0
         For i As Integer = 0 To cboLapSheet.Items.Count - 1
            If _currentLapLogItem.LapSheet = cboLapSheet.Items(i) Then
               cboLapSheet.SelectedIndex = i
               Exit For
            End If
         Next

         txtLapCell1.Text = _currentLapLogItem.LapCell_1
         cboLapFormat1.SelectedIndex = _currentLapLogItem.LapFormat_1
         txtLapCell2.Text = _currentLapLogItem.LapCell_2
         cboLapFormat2.SelectedIndex = _currentLapLogItem.LapFormat_2
         txtLapCell3.Text = _currentLapLogItem.LapCell_3
         cboLapFormat3.SelectedIndex = _currentLapLogItem.LapFormat_3
         txtLapCell4.Text = _currentLapLogItem.LapCell_4
         cboLapFormat4.SelectedIndex = _currentLapLogItem.LapFormat_4

         'LOG
         cboLogSheet.SelectedIndex = 0
         For i As Integer = 0 To cboLogSheet.Items.Count - 1
            If _currentLapLogItem.LogSheet = cboLogSheet.Items(i) Then
               cboLogSheet.SelectedIndex = i
               Exit For
            End If
         Next

         txtSource.Text = _currentLapLogItem.LogSource
         txtDestination.Text = _currentLapLogItem.LogDestination
         chkIncrement.Checked = _currentLapLogItem.LogIncrementRowCounter

      End If

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      If _currentLapLogItem IsNot Nothing Then

         _currentLapLogItem.Name = txtName.Text

         'LAP
         _currentLapLogItem.LapSheet = cboLapSheet.Items(cboLapSheet.SelectedIndex)

         _currentLapLogItem.LapCell_1 = txtLapCell1.Text
         _currentLapLogItem.LapFormat_1 = cboLapFormat1.SelectedIndex
         _currentLapLogItem.LapCell_2 = txtLapCell2.Text
         _currentLapLogItem.LapFormat_2 = cboLapFormat2.SelectedIndex
         _currentLapLogItem.LapCell_3 = txtLapCell3.Text
         _currentLapLogItem.LapFormat_3 = cboLapFormat3.SelectedIndex
         _currentLapLogItem.LapCell_4 = txtLapCell4.Text
         _currentLapLogItem.LapFormat_4 = cboLapFormat4.SelectedIndex

         'LOG
         _currentLapLogItem.LogSheet = cboLogSheet.Items(cboLogSheet.SelectedIndex)

         _currentLapLogItem.LogSource = txtSource.Text
         _currentLapLogItem.LogDestination = txtDestination.Text
         _currentLapLogItem.LogIncrementRowCounter = chkIncrement.Checked

      End If

   End Sub

End Class