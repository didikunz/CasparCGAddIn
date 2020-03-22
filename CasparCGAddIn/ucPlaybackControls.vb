Imports Microsoft.Office.Interop
Imports System.Windows.Forms
Imports CasparCGAddIn

Public Class ucPlaybackControls

   Private _sheet As Excel.Worksheet

   Private _DoReload As Boolean = False
   Private WithEvents _timResetRelaod As Timer = New Timer

   Public Property State As ucPlaybackButtons.enumState
      Get
         Return upcPlaybackButtons.State
      End Get
      Set(value As ucPlaybackButtons.enumState)
         upcPlaybackButtons.State = value
      End Set
   End Property

   Public WriteOnly Property Sheet As Excel.Worksheet
      Set(value As Excel.Worksheet)

         _sheet = value

         If _sheet IsNot Nothing Then

            Me.lblHeader.Text = CustomProperties.Load(_sheet, "DashboardCaption", _sheet.Name)
            upcPlaybackButtons.Sheet = _sheet

         End If

      End Set
   End Property

   Public WriteOnly Property ControlsSet As ucPlaybackButtons.enumControlSets
      Set(value As ucPlaybackButtons.enumControlSets)
         upcPlaybackButtons.ControlsSet = value
      End Set
   End Property


   'Events
   Public Delegate Sub CommandEventHandler(ByVal sender As Object, ByVal e As ucPlaybackButtons.CommandkEventArgs)

   Public Event CommandEvent As CommandEventHandler


   Private Function ContrastingColor(col As System.Drawing.Color) As System.Drawing.Color

      Dim pl As Single = 1 - (0.299 * col.R + 0.587 * col.G + 0.144 * col.B) / 255
      If pl < 0.5 Then
         Return System.Drawing.Color.Black
      Else
         Return System.Drawing.Color.White
      End If

   End Function

   Private Sub ucPlaybackControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      If _sheet IsNot Nothing Then

         Me.lblHeader.Text = CustomProperties.Load(_sheet, "DashboardCaption", _sheet.Name)

         Dim inte As Integer = 0
         If Integer.TryParse(CustomProperties.Load(_sheet, "DashboardCaptionColor", ""), inte) Then
            Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(inte)
            Me.lblHeader.ForeColor = ContrastingColor(Me.lblHeader.BackColor)
            Me.btnPreview.BackColor = System.Drawing.Color.FromArgb(inte)
            Me.btnPreview.ForeColor = ContrastingColor(Me.lblHeader.BackColor)
         Else
            Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(160, 160, 160)
            Me.lblHeader.ForeColor = System.Drawing.Color.White
            Me.btnPreview.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control)
            Me.btnPreview.ForeColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.ControlText)
         End If

      End If

   End Sub

   Private Sub btnChangeCaption_Click(sender As Object, e As EventArgs) Handles btnChangeCaption.Click

      Dim fpcc As frmPlaybackControlsCaptions = New frmPlaybackControlsCaptions
      fpcc.CaptionText = Me.lblHeader.Text
      fpcc.CaptionColor = Me.lblHeader.BackColor

      If fpcc.ShowDialog = DialogResult.OK Then

         CustomProperties.Save(_sheet, "DashboardCaption", fpcc.CaptionText)
         Me.lblHeader.Text = fpcc.CaptionText

         CustomProperties.Save(_sheet, "DashboardCaptionColor", fpcc.CaptionColor.ToArgb.ToString)
         Me.lblHeader.BackColor = fpcc.CaptionColor
         Me.lblHeader.ForeColor = ContrastingColor(fpcc.CaptionColor)

      End If

   End Sub

   Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

      btnPreview.Enabled = False

      If _sheet IsNot Nothing Then

         If _DoReload Then
            State = ucPlaybackButtons.enumState.stIdle
         End If

         RaiseEvent CommandEvent(Me, New ucPlaybackButtons.CommandkEventArgs(ucPlaybackButtons.enumCommandType.ctPreview, _sheet))

         _DoReload = True
         _timResetRelaod.Interval = 3000
         _timResetRelaod.Start()

      End If

      btnPreview.Enabled = True

   End Sub


   Private Sub upcPlaybackButtons_CommandEvent(sender As Object, e As ucPlaybackButtons.CommandkEventArgs) Handles upcPlaybackButtons.CommandEvent
      RaiseEvent CommandEvent(Me, e)
   End Sub

   Private Sub _timResetRelaod_Tick(sender As Object, e As EventArgs) Handles _timResetRelaod.Tick
      _timResetRelaod.Stop()
      _DoReload = False
   End Sub

End Class
