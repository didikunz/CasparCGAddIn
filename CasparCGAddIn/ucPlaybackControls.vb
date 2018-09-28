Imports Microsoft.Office.Interop
Imports System.Windows.Forms
Public Class ucPlaybackControls

   Public Enum enumCommandType
      ctLoad
      ctPlay
      ctLoadAndPlay
      ctPlayDirect
      ctNext
      ctStop
      ctUpdate
   End Enum

   Public Enum enumControlSets
      csPlayStop
      csLoadPlayStop
      csPlayNextStop
      csPlayStopUpdate
      csLoadPlayNextStop
      csPlayNextStopUpdate
      csLoadPlayStopUpdate
   End Enum

   Public Class CommandkEventArgs
      Inherits EventArgs

      Public Property Command As enumCommandType

      Public Property Sheet As Excel.Worksheet

      Public Sub New(command As enumCommandType, sheet As Excel.Worksheet)
         MyBase.New()
         Me.Command = command
         Me.Sheet = sheet
      End Sub

   End Class

   Public Delegate Sub CommandEventHandler(ByVal sender As Object, ByVal e As CommandkEventArgs)

   Public Event CommandEvent As CommandEventHandler


   Private _sheet As Excel.Worksheet
   Private _ControlsSet As enumControlSets
   Private _isLoaded As Boolean = False

   Public WriteOnly Property Sheet As Excel.Worksheet
      Set(value As Excel.Worksheet)

         _sheet = value

         If _sheet IsNot Nothing Then

            Dim nam As String = CustomProperies.Load(_sheet, "DashboardCaption")
            If nam = "" Then
               nam = _sheet.Name
            End If
            Me.lblHeader.Text = nam

         End If

      End Set
   End Property

   Public WriteOnly Property ControlsSet As enumControlSets
      Set(value As enumControlSets)

         _ControlsSet = value

         btnLoad.Visible = False
         btnPlay.Visible = False
         btnNext.Visible = False
         btnStop.Visible = False
         btnUpdate.Visible = False

         Select Case _ControlsSet
            Case enumControlSets.csPlayStop
               btnPlay.Left = 10
               btnPlay.Width = 90
               btnPlay.Visible = True

               btnStop.Left = 106
               btnStop.Width = 90
               btnStop.Visible = True

            Case enumControlSets.csLoadPlayStop
               btnLoad.Left = 10
               btnLoad.Width = 58
               btnLoad.Visible = True

               btnPlay.Left = 74
               btnPlay.Width = 58
               btnPlay.Visible = True

               btnStop.Left = 138
               btnStop.Width = 58
               btnStop.Visible = True

            Case enumControlSets.csPlayNextStop
               btnPlay.Left = 10
               btnPlay.Width = 58
               btnPlay.Visible = True

               btnNext.Left = 74
               btnNext.Width = 58
               btnNext.Visible = True

               btnStop.Left = 138
               btnStop.Width = 58
               btnStop.Visible = True

            Case enumControlSets.csPlayStopUpdate
               btnPlay.Left = 10
               btnPlay.Width = 58
               btnPlay.Visible = True

               btnStop.Left = 74
               btnStop.Width = 58
               btnStop.Visible = True

               btnUpdate.Left = 138
               btnUpdate.Width = 58
               btnUpdate.Visible = True

            Case enumControlSets.csLoadPlayNextStop
               btnLoad.Left = 10
               btnLoad.Width = 46
               btnLoad.Visible = True

               btnPlay.Left = 58
               btnPlay.Width = 46
               btnPlay.Visible = True

               btnNext.Left = 106
               btnNext.Width = 46
               btnNext.Visible = True

               btnStop.Left = 154
               btnStop.Width = 46
               btnStop.Visible = True

            Case enumControlSets.csPlayNextStopUpdate
               btnPlay.Left = 10
               btnPlay.Width = 46
               btnPlay.Visible = True

               btnNext.Left = 58
               btnNext.Width = 46
               btnNext.Visible = True

               btnStop.Left = 106
               btnStop.Width = 46
               btnStop.Visible = True

               btnUpdate.Left = 154
               btnUpdate.Width = 46
               btnUpdate.Visible = True

            Case enumControlSets.csLoadPlayStopUpdate
               btnLoad.Left = 10
               btnLoad.Width = 46
               btnLoad.Visible = True

               btnPlay.Left = 58
               btnPlay.Width = 46
               btnPlay.Visible = True

               btnStop.Left = 106
               btnStop.Width = 46
               btnStop.Visible = True

               btnUpdate.Left = 154
               btnUpdate.Width = 46
               btnUpdate.Visible = True

         End Select

      End Set
   End Property

   Private Function ContrastingColor(col As System.Drawing.Color) As System.Drawing.Color

      'var pl: Number = 1 - (0.299 * extractRed(col) + 0.587 * extractGreen(col) + 0.114 * extractBlue(col)) / 255;

      'if (pl < 0.5) Then
      '      			{
      '	Return 0xFF000000;
      '}
      'else
      '{
      '	Return 0xFFFFFFFF;
      '}

      Dim pl As Single = 1 - (0.299 * col.R + 0.587 * col.G + 0.144 * col.B) / 255
      If pl < 0.5 Then
         Return System.Drawing.Color.Black
      Else
         Return System.Drawing.Color.White
      End If

   End Function

   Private Sub ucPlaybackControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      If _sheet IsNot Nothing Then

         Dim nam As String = CustomProperies.Load(_sheet, "DashboardCaption")
         If nam = "" Then
            nam = _sheet.Name
         End If
         Me.lblHeader.Text = nam

         Dim inte As Integer = 0
         If Integer.TryParse(CustomProperies.Load(_sheet, "DashboardCaptionColor"), inte) Then
            Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(inte)
            Me.lblHeader.ForeColor = ContrastingColor(Me.lblHeader.BackColor)
         Else
            Me.lblHeader.BackColor = System.Drawing.Color.FromArgb(160, 160, 160)
            Me.lblHeader.ForeColor = System.Drawing.Color.White
         End If

      End If

   End Sub

   Private Sub btnChangeCaption_Click(sender As Object, e As EventArgs) Handles btnChangeCaption.Click

      Dim fpcc As frmPlaybackControlsCaptions = New frmPlaybackControlsCaptions
      fpcc.CaptionText = Me.lblHeader.Text
      fpcc.CaptionColor = Me.lblHeader.BackColor

      If fpcc.ShowDialog = DialogResult.OK Then

         CustomProperies.Save(_sheet, "DashboardCaption", fpcc.CaptionText)
         Me.lblHeader.Text = fpcc.CaptionText

         CustomProperies.Save(_sheet, "DashboardCaptionColor", fpcc.CaptionColor.ToArgb.ToString)
         Me.lblHeader.BackColor = fpcc.CaptionColor
         Me.lblHeader.ForeColor = ContrastingColor(fpcc.CaptionColor)

      End If

   End Sub

   Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

      btnLoad.Enabled = False
      btnPlay.Enabled = False

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandkEventArgs(enumCommandType.ctLoad, _sheet))
         _isLoaded = True
      End If

      btnLoad.Enabled = True
      btnPlay.Enabled = True

   End Sub

   Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click

      btnPlay.Enabled = False

      If _sheet IsNot Nothing Then
         If _isLoaded Then
            RaiseEvent CommandEvent(Me, New CommandkEventArgs(enumCommandType.ctPlay, _sheet))
         Else
            If _ControlsSet = enumControlSets.csLoadPlayStop Or _ControlsSet = enumControlSets.csLoadPlayNextStop Or _ControlsSet = enumControlSets.csLoadPlayStopUpdate Then
               RaiseEvent CommandEvent(Me, New CommandkEventArgs(enumCommandType.ctPlayDirect, _sheet))
            Else
               RaiseEvent CommandEvent(Me, New CommandkEventArgs(enumCommandType.ctLoadAndPlay, _sheet))
            End If

         End If
         _isLoaded = False
      End If

      btnPlay.Enabled = True

   End Sub

   Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

      btnNext.Enabled = False

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandkEventArgs(enumCommandType.ctNext, _sheet))
      End If

      btnNext.Enabled = True

   End Sub

   Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

      btnStop.Enabled = False

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandkEventArgs(enumCommandType.ctStop, _sheet))
      End If

      btnStop.Enabled = True

   End Sub

   Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

      btnUpdate.Enabled = False

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandkEventArgs(enumCommandType.ctUpdate, _sheet))
      End If

      btnUpdate.Enabled = True

   End Sub

End Class
