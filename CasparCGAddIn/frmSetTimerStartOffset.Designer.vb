<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetTimerStartOffset
   Inherits System.Windows.Forms.Form

   'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
      Me.tseOffset = New CasparCGAddIn.ucTimeSpanEditor()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.btnStop = New System.Windows.Forms.Button()
      Me.btnStart = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'tseOffset
      '
      Me.tseOffset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tseOffset.Location = New System.Drawing.Point(13, 27)
      Me.tseOffset.MaximumSize = New System.Drawing.Size(1920, 20)
      Me.tseOffset.MinimumSize = New System.Drawing.Size(160, 20)
      Me.tseOffset.Name = "tseOffset"
      Me.tseOffset.Size = New System.Drawing.Size(269, 20)
      Me.tseOffset.TabIndex = 10
      Me.tseOffset.Value = System.TimeSpan.Parse("00:00:00")
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(10, 9)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(92, 13)
      Me.Label6.TabIndex = 9
      Me.Label6.Text = "Start from (Offset):"
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(377, 58)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 25)
      Me.btnCancel.TabIndex = 13
      Me.btnCancel.Tag = ""
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.Location = New System.Drawing.Point(296, 58)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 25)
      Me.btnOk.TabIndex = 12
      Me.btnOk.Tag = ""
      Me.btnOk.Text = "OK"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'btnStop
      '
      Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnStop.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Stop_s
      Me.btnStop.Location = New System.Drawing.Point(377, 13)
      Me.btnStop.Name = "btnStop"
      Me.btnStop.Size = New System.Drawing.Size(75, 38)
      Me.btnStop.TabIndex = 15
      Me.btnStop.Tag = "[ignore]"
      Me.btnStop.UseVisualStyleBackColor = True
      '
      'btnStart
      '
      Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnStart.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Start_s
      Me.btnStart.Location = New System.Drawing.Point(296, 12)
      Me.btnStart.Name = "btnStart"
      Me.btnStart.Size = New System.Drawing.Size(75, 38)
      Me.btnStart.TabIndex = 14
      Me.btnStart.Tag = "[ignore]"
      Me.btnStart.UseVisualStyleBackColor = True
      '
      'frmSetTimerStartOffset
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(464, 95)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnStop)
      Me.Controls.Add(Me.btnStart)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.tseOffset)
      Me.Controls.Add(Me.Label6)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSetTimerStartOffset"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Set Timer Start Offset"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents tseOffset As ucTimeSpanEditor
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents btnStart As System.Windows.Forms.Button
   Friend WithEvents btnStop As System.Windows.Forms.Button
End Class
