<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPlaybackButtons
   Inherits System.Windows.Forms.UserControl

   'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Wird vom Windows Form-Designer benötigt.
   Private components As System.ComponentModel.IContainer

   'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
   'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
   'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.btnLoad = New System.Windows.Forms.Button()
      Me.btnUpdate = New System.Windows.Forms.Button()
      Me.btnStop = New System.Windows.Forms.Button()
      Me.btnNext = New System.Windows.Forms.Button()
      Me.btnPlay = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'btnLoad
      '
      Me.btnLoad.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Load
      Me.btnLoad.Location = New System.Drawing.Point(74, 0)
      Me.btnLoad.Name = "btnLoad"
      Me.btnLoad.Size = New System.Drawing.Size(42, 46)
      Me.btnLoad.TabIndex = 13
      Me.btnLoad.UseVisualStyleBackColor = True
      '
      'btnUpdate
      '
      Me.btnUpdate.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Update
      Me.btnUpdate.Location = New System.Drawing.Point(145, 0)
      Me.btnUpdate.Name = "btnUpdate"
      Me.btnUpdate.Size = New System.Drawing.Size(42, 46)
      Me.btnUpdate.TabIndex = 12
      Me.btnUpdate.UseVisualStyleBackColor = True
      '
      'btnStop
      '
      Me.btnStop.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop.Location = New System.Drawing.Point(97, 0)
      Me.btnStop.Name = "btnStop"
      Me.btnStop.Size = New System.Drawing.Size(42, 46)
      Me.btnStop.TabIndex = 11
      Me.btnStop.UseVisualStyleBackColor = True
      '
      'btnNext
      '
      Me.btnNext.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Next
      Me.btnNext.Location = New System.Drawing.Point(49, 0)
      Me.btnNext.Name = "btnNext"
      Me.btnNext.Size = New System.Drawing.Size(42, 46)
      Me.btnNext.TabIndex = 10
      Me.btnNext.UseVisualStyleBackColor = True
      '
      'btnPlay
      '
      Me.btnPlay.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay.Location = New System.Drawing.Point(1, 0)
      Me.btnPlay.Name = "btnPlay"
      Me.btnPlay.Size = New System.Drawing.Size(42, 46)
      Me.btnPlay.TabIndex = 9
      Me.btnPlay.UseVisualStyleBackColor = True
      '
      'ucPlaybackButtons
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.Transparent
      Me.Controls.Add(Me.btnLoad)
      Me.Controls.Add(Me.btnUpdate)
      Me.Controls.Add(Me.btnStop)
      Me.Controls.Add(Me.btnNext)
      Me.Controls.Add(Me.btnPlay)
      Me.Name = "ucPlaybackButtons"
      Me.Size = New System.Drawing.Size(189, 48)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnLoad As System.Windows.Forms.Button
   Friend WithEvents btnUpdate As System.Windows.Forms.Button
   Friend WithEvents btnStop As System.Windows.Forms.Button
   Friend WithEvents btnNext As System.Windows.Forms.Button
   Friend WithEvents btnPlay As System.Windows.Forms.Button
End Class
