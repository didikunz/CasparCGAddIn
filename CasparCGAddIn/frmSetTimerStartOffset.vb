Public Class frmSetTimerStartOffset

   Public Property CurrentItem As TimerItem
   Public Property Settings As Settings

   Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
      If CurrentItem IsNot Nothing Then
         CurrentItem.StartTimer(tseOffset.Value)
      End If
   End Sub

   Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
      If CurrentItem IsNot Nothing Then
         CurrentItem.StopTimer()
      End If
   End Sub

   Private Sub frmSetTimerStartOffset_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Loader.Load(Me, Settings.Theme)

      If CurrentItem IsNot Nothing Then
         tseOffset.Value = CurrentItem.Offset
      End If

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
      If CurrentItem IsNot Nothing Then
         CurrentItem.Offset = tseOffset.Value
      End If
   End Sub

End Class