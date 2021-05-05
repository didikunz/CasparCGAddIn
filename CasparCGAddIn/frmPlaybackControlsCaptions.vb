Imports System.Windows.Forms

Public Class frmPlaybackControlsCaptions

   Private _Settings As Settings
   Private _tempCaptionColor As System.Drawing.Color

   Public Property CaptionText As String

   Public Property CaptionColor As System.Drawing.Color

   Public Property OscEndpoint As String

   Public WriteOnly Property Settings As Settings
      Set(value As Settings)
         _Settings = value
      End Set
   End Property

   Private Sub frmPlaybackControlsCaptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      MyColorThemes.Loader.Load(Me, _Settings.Theme)

      txtCaption.Text = Me.CaptionText
      _tempCaptionColor = Me.CaptionColor
      txtOscEndpoint.Text = Me.OscEndpoint

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
      Me.OscEndpoint = txtOscEndpoint.Text.Replace(" ", "")

      Me.DialogResult = DialogResult.OK

   End Sub

End Class