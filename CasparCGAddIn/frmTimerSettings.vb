Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class frmTimerSettings

   Private _TimerSettings As TimerSettings

   Private _currentItem As TimerItem = Nothing
   Private _currentPos As Integer = 0

   Public WriteOnly Property TimerSettings As TimerSettings
      Set(value As TimerSettings)
         _TimerSettings = value
      End Set
   End Property

   Private Sub frmTimerSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      If _TimerSettings IsNot Nothing Then

         If _TimerSettings.Items.Count = 0 Then
            _TimerSettings.Items.Add(New TimerItem("Default"))
         End If

         bsItems.DataSource = _TimerSettings
         bsItems.ResetBindings(False)

      End If

   End Sub

   Private Sub SetControls()

      If _currentItem IsNot Nothing Then

         txtName.Text = _currentItem.Name
         cboType.SelectedIndex = _currentItem.PreviewFormat
         chkUseLaps.Checked = _currentItem.UseLaps
         chkCanPause.Checked = _currentItem.CanPause

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

         Dim dbl As Double = 0

         If txtFullDistance.Text <> "" Then
            If Double.TryParse(txtFullDistance.Text, dbl) Then
               _currentItem.FullDistance = dbl
               txtFullDistance.BackColor = System.Drawing.SystemColors.Window
            Else
               txtFullDistance.BackColor = System.Drawing.Color.LightPink
               isOk = False
            End If
         End If

         If txtPartDistance.Text <> "" Then
            If Double.TryParse(txtPartDistance.Text, dbl) Then
               _currentItem.PartDistance = dbl
               txtPartDistance.BackColor = System.Drawing.SystemColors.Window
            Else
               txtPartDistance.BackColor = System.Drawing.Color.LightPink
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
         _TimerSettings.Items.Add(newItem)

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

                  _TimerSettings.Items.Add(newItem)

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

            _TimerSettings.Items.Remove(oldItem)

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