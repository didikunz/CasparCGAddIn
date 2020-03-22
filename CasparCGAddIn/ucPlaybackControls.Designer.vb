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
      Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
      Me.upcPlaybackButtons = New CasparCGAddIn.ucPlaybackButtons()
      Me.tlpMain.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblHeader
      '
      Me.lblHeader.BackColor = System.Drawing.SystemColors.ButtonShadow
      Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight
      Me.lblHeader.Location = New System.Drawing.Point(42, 0)
      Me.lblHeader.Margin = New System.Windows.Forms.Padding(0)
      Me.lblHeader.Name = "lblHeader"
      Me.lblHeader.Size = New System.Drawing.Size(138, 24)
      Me.lblHeader.TabIndex = 0
      Me.lblHeader.Text = "Header"
      Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnChangeCaption
      '
      Me.btnChangeCaption.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnChangeCaption.Image = Global.CasparCGAddIn.My.Resources.Resources.ThreeDots
      Me.btnChangeCaption.Location = New System.Drawing.Point(180, 0)
      Me.btnChangeCaption.Margin = New System.Windows.Forms.Padding(0)
      Me.btnChangeCaption.Name = "btnChangeCaption"
      Me.btnChangeCaption.Size = New System.Drawing.Size(25, 24)
      Me.btnChangeCaption.TabIndex = 5
      Me.ttTips.SetToolTip(Me.btnChangeCaption, "Change the Caption")
      Me.btnChangeCaption.UseVisualStyleBackColor = True
      '
      'btnPreview
      '
      Me.btnPreview.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnPreview.Location = New System.Drawing.Point(0, 0)
      Me.btnPreview.Margin = New System.Windows.Forms.Padding(0)
      Me.btnPreview.Name = "btnPreview"
      Me.btnPreview.Size = New System.Drawing.Size(42, 24)
      Me.btnPreview.TabIndex = 7
      Me.btnPreview.Text = "PVW"
      Me.btnPreview.UseVisualStyleBackColor = True
      '
      'tlpMain
      '
      Me.tlpMain.BackColor = System.Drawing.Color.Transparent
      Me.tlpMain.ColumnCount = 3
      Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
      Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
      Me.tlpMain.Controls.Add(Me.btnPreview, 0, 0)
      Me.tlpMain.Controls.Add(Me.lblHeader, 1, 0)
      Me.tlpMain.Controls.Add(Me.btnChangeCaption, 2, 0)
      Me.tlpMain.Controls.Add(Me.upcPlaybackButtons, 0, 1)
      Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tlpMain.Location = New System.Drawing.Point(0, 0)
      Me.tlpMain.Name = "tlpMain"
      Me.tlpMain.RowCount = 2
      Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
      Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tlpMain.Size = New System.Drawing.Size(205, 80)
      Me.tlpMain.TabIndex = 9
      '
      'upcPlaybackButtons
      '
      Me.upcPlaybackButtons.BackColor = System.Drawing.Color.Transparent
      Me.tlpMain.SetColumnSpan(Me.upcPlaybackButtons, 3)
      Me.upcPlaybackButtons.ControlsSet = CasparCGAddIn.ucPlaybackButtons.enumControlSets.csNone
      Me.upcPlaybackButtons.Dock = System.Windows.Forms.DockStyle.Fill
      Me.upcPlaybackButtons.Location = New System.Drawing.Point(0, 24)
      Me.upcPlaybackButtons.Margin = New System.Windows.Forms.Padding(0)
      Me.upcPlaybackButtons.Name = "upcPlaybackButtons"
      Me.upcPlaybackButtons.Size = New System.Drawing.Size(205, 56)
      Me.upcPlaybackButtons.State = CasparCGAddIn.ucPlaybackButtons.enumState.stIdle
      Me.upcPlaybackButtons.TabIndex = 8
      '
      'ucPlaybackControls
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.tlpMain)
      Me.Name = "ucPlaybackControls"
      Me.Size = New System.Drawing.Size(205, 80)
      Me.tlpMain.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents lblHeader As System.Windows.Forms.Label
   Friend WithEvents btnChangeCaption As System.Windows.Forms.Button
   Friend WithEvents ttTips As System.Windows.Forms.ToolTip
   Friend WithEvents btnPreview As System.Windows.Forms.Button
   Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents upcPlaybackButtons As ucPlaybackButtons
End Class
