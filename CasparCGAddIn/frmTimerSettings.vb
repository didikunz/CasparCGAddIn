Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class frmTimerSettings

   Private _Settings As Settings
   Private _TimerSettings As TimerSettings

   Private _currentItem As TimerItem = Nothing
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

   Private Sub frmTimerSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Loader.Load(Me, _Settings.Theme)

      If _TimerSettings IsNot Nothing Then

         If _TimerSettings.Items.Count = 0 Then
            _TimerSettings.AddTimerItem(New TimerItem("Default"))
         End If

         bsItems.DataSource = _TimerSettings
         bsItems.ResetBindings(False)

      End If

   End Sub

   Private Sub RefreshTriggerCombos()

      cboOnStartTimer.Items.Clear()
      cboOnPauseTimer.Items.Clear()
      cboOnUnPauseTimer.Items.Clear()
      cboOnLapTimer.Items.Clear()
      cboOnResumeTimer.Items.Clear()
      cboOnStopTimer.Items.Clear()
      cboOnTimeTimer.Items.Clear()

      cboOnStartTimer.Items.Add("(None)")
      cboOnPauseTimer.Items.Add("(None)")
      cboOnUnPauseTimer.Items.Add("(None)")
      cboOnLapTimer.Items.Add("(None)")
      cboOnResumeTimer.Items.Add("(None)")
      cboOnStopTimer.Items.Add("(None)")
      cboOnTimeTimer.Items.Add("(None)")

      For Each ti As TimerItem In _TimerSettings.Items
         cboOnStartTimer.Items.Add(ti.Name)
         cboOnPauseTimer.Items.Add(ti.Name)
         cboOnUnPauseTimer.Items.Add(ti.Name)
         cboOnLapTimer.Items.Add(ti.Name)
         cboOnResumeTimer.Items.Add(ti.Name)
         cboOnStopTimer.Items.Add(ti.Name)
         cboOnTimeTimer.Items.Add(ti.Name)
      Next

      cboOnStartTimer.SelectedIndex = 0
      cboOnPauseTimer.SelectedIndex = 0
      cboOnUnPauseTimer.SelectedIndex = 0
      cboOnLapTimer.SelectedIndex = 0
      cboOnResumeTimer.SelectedIndex = 0
      cboOnStopTimer.SelectedIndex = 0
      cboOnTimeTimer.SelectedIndex = 0

      Dim i As Integer = 0

      For i = 0 To cboOnStartTimer.Items.Count - 1
         If cboOnStartTimer.Items(i) = _currentItem.OnStart.TimerName Then
            cboOnStartTimer.SelectedIndex = i
            Exit For
         End If
      Next

      For i = 0 To cboOnPauseTimer.Items.Count - 1
         If cboOnPauseTimer.Items(i) = _currentItem.OnPause.TimerName Then
            cboOnPauseTimer.SelectedIndex = i
            Exit For
         End If
      Next

      For i = 0 To cboOnUnPauseTimer.Items.Count - 1
         If cboOnUnPauseTimer.Items(i) = _currentItem.OnUnPause.TimerName Then
            cboOnUnPauseTimer.SelectedIndex = i
            Exit For
         End If
      Next

      For i = 0 To cboOnLapTimer.Items.Count - 1
         If cboOnLapTimer.Items(i) = _currentItem.OnLap.TimerName Then
            cboOnLapTimer.SelectedIndex = i
            Exit For
         End If
      Next

      For i = 0 To cboOnResumeTimer.Items.Count - 1
         If cboOnResumeTimer.Items(i) = _currentItem.OnResume.TimerName Then
            cboOnResumeTimer.SelectedIndex = i
            Exit For
         End If
      Next

      For i = 0 To cboOnStopTimer.Items.Count - 1
         If cboOnStopTimer.Items(i) = _currentItem.OnStop.TimerName Then
            cboOnStopTimer.SelectedIndex = i
            Exit For
         End If
      Next

      For i = 0 To cboOnTimeTimer.Items.Count - 1
         If cboOnTimeTimer.Items(i) = _currentItem.OnTime.TimerName Then
            cboOnTimeTimer.SelectedIndex = i
            Exit For
         End If
      Next

   End Sub

   Private Sub SetControls()

      If _currentItem IsNot Nothing Then

         txtName.Text = _currentItem.Name
         cboType.SelectedIndex = _currentItem.PreviewFormat
         chkUseLaps.Checked = _currentItem.UseLaps
         chkCanPause.Checked = _currentItem.CanPause
         chkInhibitQuery.Checked = _currentItem.InhibitQuery
         tseOffset.Value = _currentItem.Offset

         RefreshTriggerCombos()

         cboOnStartTrigger.SelectedIndex = CInt(_currentItem.OnStart.TriggerEvent)
         cboOnPauseTrigger.SelectedIndex = CInt(_currentItem.OnPause.TriggerEvent)
         cboOnUnPauseTrigger.SelectedIndex = CInt(_currentItem.OnUnPause.TriggerEvent)
         cboOnLapTrigger.SelectedIndex = CInt(_currentItem.OnLap.TriggerEvent)
         cboOnResumeTrigger.SelectedIndex = CInt(_currentItem.OnResume.TriggerEvent)
         cboOnStopTrigger.SelectedIndex = CInt(_currentItem.OnStop.TriggerEvent)

         tseOnTimeTime.Value = _currentItem.OnTimeTime
         cboOnTimeTrigger.SelectedIndex = CInt(_currentItem.OnTime.TriggerEvent)

         txtFullDistance.Text = _currentItem.FullDistance
         txtPartDistance.Text = _currentItem.PartDistance
         tsePartTime.Value = _currentItem.PartTime

      End If

   End Sub

   Private Function GetControls(isRepositioning As Boolean) As Boolean

      Dim isOk As Boolean = True

      If Not isRepositioning AndAlso _currentItem IsNot Nothing Then

         _currentItem.Name = txtName.Text
         _currentItem.PreviewFormat = cboType.SelectedIndex
         _currentItem.UseLaps = chkUseLaps.Checked
         _currentItem.CanPause = chkCanPause.Checked
         _currentItem.InhibitQuery = chkInhibitQuery.Checked
         _currentItem.Offset = tseOffset.Value

         _currentItem.OnStart.TriggerEvent = cboOnStartTrigger.SelectedIndex
         _currentItem.OnStart.TimerName = cboOnStartTimer.Items(cboOnStartTimer.SelectedIndex)

         _currentItem.OnPause.TriggerEvent = cboOnPauseTrigger.SelectedIndex
         _currentItem.OnPause.TimerName = cboOnPauseTimer.Items(cboOnPauseTimer.SelectedIndex)

         _currentItem.OnUnPause.TriggerEvent = cboOnUnPauseTrigger.SelectedIndex
         _currentItem.OnUnPause.TimerName = cboOnUnPauseTimer.Items(cboOnUnPauseTimer.SelectedIndex)

         _currentItem.OnLap.TriggerEvent = cboOnLapTrigger.SelectedIndex
         _currentItem.OnLap.TimerName = cboOnLapTimer.Items(cboOnLapTimer.SelectedIndex)

         _currentItem.OnResume.TriggerEvent = cboOnResumeTrigger.SelectedIndex
         _currentItem.OnResume.TimerName = cboOnResumeTimer.Items(cboOnResumeTimer.SelectedIndex)

         _currentItem.OnStop.TriggerEvent = cboOnStopTrigger.SelectedIndex
         _currentItem.OnStop.TimerName = cboOnStopTimer.Items(cboOnStopTimer.SelectedIndex)

         _currentItem.OnTimeTime = tseOnTimeTime.Value
         _currentItem.OnTime.TriggerEvent = cboOnTimeTrigger.SelectedIndex
         _currentItem.OnTime.TimerName = cboOnTimeTimer.Items(cboOnTimeTimer.SelectedIndex)

         Dim dbl As Double = 0

         If txtFullDistance.Text <> "" Then
            If Double.TryParse(txtFullDistance.Text, dbl) Then
               _currentItem.FullDistance = dbl
               txtFullDistance.ForeColor = _Settings.Theme.ForeColor
               txtFullDistance.BackColor = _Settings.Theme.BackColor
            Else
               txtFullDistance.ForeColor = _Settings.Theme.HighliteForeColor
               txtFullDistance.BackColor = _Settings.Theme.HighliteBackColor
               isOk = False
            End If
         End If

         If txtPartDistance.Text <> "" Then
            If Double.TryParse(txtPartDistance.Text, dbl) Then
               _currentItem.PartDistance = dbl
               txtPartDistance.ForeColor = _Settings.Theme.ForeColor
               txtPartDistance.BackColor = _Settings.Theme.BackColor
            Else
               txtPartDistance.ForeColor = _Settings.Theme.HighliteForeColor
               txtPartDistance.BackColor = _Settings.Theme.HighliteBackColor
               isOk = False
            End If
         End If

         _currentItem.PartTime = tsePartTime.Value

      End If

      Return isOk

   End Function

   Private Sub bsItems_PositionChanged(sender As Object, e As EventArgs) Handles bsItems.PositionChanged

      Static reposition As Boolean = False

      If GetControls(reposition) Then
         reposition = False
         _currentItem = CType(bsItems.Current, TimerItem)
         _currentPos = bsItems.Position
         SetControls()
      Else
         reposition = True
         bsItems.Position = _currentPos
      End If

   End Sub

   Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click

      If GetControls(False) Then
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      End If

   End Sub

   Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

      If _TimerSettings IsNot Nothing Then

         Dim newItem As TimerItem = New TimerItem
         _TimerSettings.AddTimerItem(newItem)

         bsItems.ResetBindings(False)
         bsItems.Position = bsItems.IndexOf(newItem)

      End If

   End Sub

   Private Sub btnDublicate_Click(sender As Object, e As EventArgs) Handles btnDublicate.Click

      If _TimerSettings IsNot Nothing Then

         If GetControls(False) Then

            If _currentItem IsNot Nothing Then

               Dim newItem As TimerItem = _currentItem.Clone
               If newItem IsNot Nothing Then

                  _TimerSettings.AddTimerItem(newItem)

                  bsItems.ResetBindings(False)
                  bsItems.Position = bsItems.IndexOf(newItem)

               End If

            End If

         End If

      End If

   End Sub


   Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

      If _TimerSettings IsNot Nothing Then

         Dim oldItem As TimerItem = CType(bsItems.Current, TimerItem)
         If oldItem IsNot Nothing Then

            _TimerSettings.RemoveTimerItem(oldItem)

            bsItems.ResetBindings(False)
            bsItems.Position = 0

         End If

      End If

   End Sub

   Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus

      If _currentItem IsNot Nothing Then

         _currentItem.Name = txtName.Text

         Dim pos As Integer = bsItems.Position
         bsItems.ResetBindings(False)
         bsItems.Position = pos

      End If

   End Sub

End Class