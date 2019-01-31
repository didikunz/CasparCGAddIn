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
      Me.ttTips = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnChangeCaption = New System.Windows.Forms.Button()
      Me.btnPreview = New System.Windows.Forms.Button()
      Me.pbPlaybackButtons = New CasparCGAddIn.ucPlaybackButtons()
      Me.SuspendLayout()
      '
      'lblHeader
      '
      Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblHeader.BackColor = System.Drawing.SystemColors.ButtonShadow
      Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight
      Me.lblHeader.Location = New System.Drawing.Point(30, 1)
      Me.lblHeader.Name = "lblHeader"
      Me.lblHeader.Size = New System.Drawing.Size(160, 21)
      Me.lblHeader.TabIndex = 0
      Me.lblHeader.Text = "Header"
      Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
      'btnPreview
      '
      Me.btnPreview.Location = New System.Drawing.Point(0, 0)
      Me.btnPreview.Name = "btnPreview"
      Me.btnPreview.Size = New System.Drawing.Size(40, 23)
      Me.btnPreview.TabIndex = 7
      Me.btnPreview.Text = "PVW"
      Me.btnPreview.UseVisualStyleBackColor = True
      '
      'pbPlaybackButtons
      '
      Me.pbPlaybackButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pbPlaybackButtons.BackColor = System.Drawing.Color.Transparent
      Me.pbPlaybackButtons.ControlsSet = CasparCGAddIn.ucPlaybackButtons.enumControlSets.csPlayStop
      Me.pbPlaybackButtons.Location = New System.Drawing.Point(0, 30)
      Me.pbPlaybackButtons.Name = "pbPlaybackButtons"
      Me.pbPlaybackButtons.Size = New System.Drawing.Size(205, 48)
      Me.pbPlaybackButtons.TabIndex = 8
      '
      'ucPlaybackControls
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.pbPlaybackButtons)
      Me.Controls.Add(Me.btnPreview)
      Me.Controls.Add(Me.btnChangeCaption)
      Me.Controls.Add(Me.lblHeader)
      Me.Name = "ucPlaybackControls"
      Me.Size = New System.Drawing.Size(205, 89)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents lblHeader As System.Windows.Forms.Label
   Friend WithEvents btnChangeCaption As System.Windows.Forms.Button
   Friend WithEvents ttTips As System.Windows.Forms.ToolTip
   Friend WithEvents btnPreview As System.Windows.Forms.Button
   Friend WithEvents pbPlaybackButtons As ucPlaybackButtons
End Class
