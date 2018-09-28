Imports System.Windows.Forms

Public Class frmPlaybackControlsCaptions

   Private _tempCaptionColor As System.Drawing.Color

   Public Property CaptionText As String

   Public Property CaptionColor As System.Drawing.Color

   Private Sub frmPlaybackControlsCaptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      txtCaption.Text = Me.CaptionText
      _tempCaptionColor = Me.CaptionColor
   End Sub

   Private Sub btnCaptionColor_Click(sender As Object, e As EventArgs) Handles btnCaptionColor.Click

      Dim dlg As ColorDialog = New ColorDialog
      dlg.Color = _tempCaptionColor
      dlg.FullOpen = True

      If dlg.ShowDialog = DialogResult.OK Then
         _tempCaptionColor = dlg.Color
      End If

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      Me.CaptionText = txtCaption.Text
      Me.CaptionColor = _tempCaptionColor

      Me.DialogResult = DialogResult.OK

   End Sub

End Class