<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucPlaybackControls
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
      Me.components = New System.ComponentModel.Container()
      Me.lblHeader = New System.Windows.Forms.Label()
      Me.btnLoad = New System.Windows.Forms.Button()
      Me.btnChangeCaption = New System.Windows.Forms.Button()
      Me.btnUpdate = New System.Windows.Forms.Button()
      Me.btnStop = New System.Windows.Forms.Button()
      Me.btnNext = New System.Windows.Forms.Button()
      Me.btnPlay = New System.Windows.Forms.Button()
      Me.ttTips = New System.Windows.Forms.ToolTip(Me.components)
      Me.SuspendLayout()
      '
      'lblHeader
      '
      Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblHeader.BackColor = System.Drawing.SystemColors.ButtonShadow
      Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight
      Me.lblHeader.Location = New System.Drawing.Point(0, 0)
      Me.lblHeader.Name = "lblHeader"
      Me.lblHeader.Size = New System.Drawing.Size(196, 23)
      Me.lblHeader.TabIndex = 0
      Me.lblHeader.Text = "Header"
      Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnLoad
      '
      Me.btnLoad.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Load
      Me.btnLoad.Location = New System.Drawing.Point(37, 34)
      Me.btnLoad.Name = "btnLoad"
      Me.btnLoad.Size = New System.Drawing.Size(42, 46)
      Me.btnLoad.TabIndex = 6
      Me.ttTips.SetToolTip(Me.btnLoad, "Load")
      Me.btnLoad.UseVisualStyleBackColor = True
      '
      'btnChangeCaption
      '
      Me.btnChangeCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnChangeCaption.Image = Global.CasparCGAddIn.My.Resources.Resources.ThreeDots
      Me.btnChangeCaption.Location = New System.Drawing.Point(182, 0)
      Me.btnChangeCaption.Name = "btnChangeCaption"
      Me.btnChangeCaption.Size = New System.Drawing.Size(23, 23)
      Me.btnChangeCaption.TabIndex = 5
      Me.ttTips.SetToolTip(Me.btnChangeCaption, "Change the Caption")
      Me.btnChangeCaption.UseVisualStyleBackColor = True
      '
      'btnUpdate
      '
      Me.btnUpdate.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Update
      Me.btnUpdate.Location = New System.Drawing.Point(154, 34)
      Me.btnUpdate.Name = "btnUpdate"
      Me.btnUpdate.Size = New System.Drawing.Size(42, 46)
      Me.btnUpdate.TabIndex = 4
      Me.ttTips.SetToolTip(Me.btnUpdate, "Update")
      Me.btnUpdate.UseVisualStyleBackColor = True
      '
      'btnStop
      '
      Me.btnStop.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop.Location = New System.Drawing.Point(106, 34)
      Me.btnStop.Name = "btnStop"
      Me.btnStop.Size = New System.Drawing.Size(42, 46)
      Me.btnStop.TabIndex = 3
      Me.ttTips.SetToolTip(Me.btnStop, "Stop")
      Me.btnStop.UseVisualStyleBackColor = True
      '
      'btnNext
      '
      Me.btnNext.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Next
      Me.btnNext.Location = New System.Drawing.Point(58, 34)
      Me.btnNext.Name = "btnNext"
      Me.btnNext.Size = New System.Drawing.Size(42, 46)
      Me.btnNext.TabIndex = 2
      Me.ttTips.SetToolTip(Me.btnNext, "Next")
      Me.btnNext.UseVisualStyleBackColor = True
      '
      'btnPlay
      '
      Me.btnPlay.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay.Location = New System.Drawing.Point(10, 34)
      Me.btnPlay.Name = "btnPlay"
      Me.btnPlay.Size = New System.Drawing.Size(42, 46)
      Me.btnPlay.TabIndex = 1
      Me.ttTips.SetToolTip(Me.btnPlay, "Play")
      Me.btnPlay.UseVisualStyleBackColor = True
      '
      'ucPlaybackControls
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.btnLoad)
      Me.Controls.Add(Me.btnChangeCaption)
      Me.Controls.Add(Me.btnUpdate)
      Me.Controls.Add(Me.btnStop)
      Me.Controls.Add(Me.btnNext)
      Me.Controls.Add(Me.btnPlay)
      Me.Controls.Add(Me.lblHeader)
      Me.Name = "ucPlaybackControls"
      Me.Size = New System.Drawing.Size(205, 89)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents lblHeader As System.Windows.Forms.Label
   Friend WithEvents btnPlay As System.Windows.Forms.Button
   Friend WithEvents btnNext As System.Windows.Forms.Button
   Friend WithEvents btnStop As System.Windows.Forms.Button
   Friend WithEvents btnUpdate As System.Windows.Forms.Button
   Friend WithEvents btnChangeCaption As System.Windows.Forms.Button
   Friend WithEvents btnLoad As System.Windows.Forms.Button
   Friend WithEvents ttTips As System.Windows.Forms.ToolTip
End Class
