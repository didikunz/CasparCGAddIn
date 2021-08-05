Imports Microsoft.Office.Interop.Excel

Public Class frmTimerLaps

   Private _Settings As Settings
   Private _TimerSettings As TimerSettings

   Private _currentLap As TimerLap = Nothing
   Private _currentPos As Integer = 0

   Public WriteOnly Property Settings As Settings
      Set(value As Settings)
         _Settings = value
      End Set
   End Property

   Public WriteOnly Property TimerSettings As TimerSettings
      Set(value As TimerSettings)
         _TimerSettings = value
      End Set
   End Property


   Private Sub frmTimerLaps_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Loader.Load(Me, _Settings.Theme)

      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then

         Dim workbook As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

         cboWorksheet.Items.Clear()
         cboWorksheet.Items.Add("(None)")
         For Each wrk As Worksheet In workbook.Sheets
            cboWorksheet.Items.Add(wrk.Name.ToString.Trim)
         Next

         If _TimerSettings.SelectedItem.Laps.Count = 0 Then
            _TimerSettings.SelectedItem.Laps.Add(New TimerLap())
         End If

         bsLaps.DataSource = _TimerSettings.SelectedItem
         bsLaps.ResetBindings(False)

      End If

   End Sub

   Private Sub SetControls()

      If _currentLap IsNot Nothing Then

         txtName.Text = _currentLap.Name
         tseTime.Value = _currentLap.Time

         chkUse.Checked = _currentLap.UseForDistanceSimulation
         txtPartDistance.Text = _currentLap.Distance.ToString

         cboWorksheet.SelectedIndex = 0
         For i As Integer = 0 To cboWorksheet.Items.Count - 1
            If _currentLap.Sheet = cboWorksheet.Items(i) Then
               cboWorksheet.SelectedIndex = i
               Exit For
            End If
         Next

         txtCell.Text = _currentLap.Cell
         cboFormat.SelectedIndex = _currentLap.Format

      End If

   End Sub

   Private Function GetControls(isRepositioning As Boolean) As Boolean

      Dim isOk As Boolean = True

      If Not isRepositioning AndAlso _currentLap IsNot Nothing Then

         _currentLap.Name = txtName.Text
         _currentLap.Time = tseTime.Value

         _currentLap.UseForDistanceSimulation = chkUse.Checked

         Dim dbl As Double = 0

         If txtPartDistance.Text <> "" Then
            If Double.TryParse(txtPartDistance.Text, dbl) Then
               _currentLap.Distance = dbl
               txtPartDistance.ForeColor = _Settings.Theme.ForeColor
               txtPartDistance.BackColor = _Settings.Theme.BackColor
            Else
               txtPartDistance.ForeColor = _Settings.Theme.HighliteForeColor
               txtPartDistance.BackColor = _Settings.Theme.HighliteBackColor
               isOk = False
            End If
         End If

         If cboWorksheet.SelectedIndex >= 0 Then
            _currentLap.Sheet = cboWorksheet.Items(cboWorksheet.SelectedIndex)
         End If
         _currentLap.Cell = txtCell.Text
         _currentLap.Format = cboFormat.SelectedIndex

      End If

      Return isOk

   End Function

   Private Sub bsLaps_PositionChanged(sender As Object, e As EventArgs) Handles bsLaps.PositionChanged

      Static reposition As Boolean = False

      If GetControls(reposition) Then
         reposition = False
         _currentLap = CType(bsLaps.Current, TimerLap)
         _currentPos = bsLaps.Position
         SetControls()
      Else
         reposition = True
         bsLaps.Position = _currentPos
      End If

   End Sub

   Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click

      If GetControls(False) Then
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      End If

   End Sub

   Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then

         Dim newTl As TimerLap = New TimerLap
         _TimerSettings.SelectedItem.Laps.Add(newTl)

         bsLaps.ResetBindings(False)
         bsLaps.Position = bsLaps.IndexOf(newTl)

      End If

   End Sub

   Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then

         Dim oldTl As TimerLap = CType(bsLaps.Current, TimerLap)
         If oldTl IsNot Nothing Then

            _TimerSettings.SelectedItem.Laps.Remove(oldTl)

            bsLaps.ResetBindings(False)
            bsLaps.Position = 0

         End If

      End If

   End Sub

   Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus

      If _currentLap IsNot Nothing Then

         _currentLap.Name = txtName.Text

         Dim pos As Integer = bsLaps.Position
         bsLaps.ResetBindings(False)
         bsLaps.Position = pos

      End If

   End Sub

End Class