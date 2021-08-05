<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboardSettings
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
        Me.components = New System.ComponentModel.Container()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.gbLive = New System.Windows.Forms.GroupBox()
        Me.nudLayer = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudChannel = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboServers = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbDatafields = New System.Windows.Forms.GroupBox()
        Me.txtFields = New System.Windows.Forms.TextBox()
        Me.gbControls = New System.Windows.Forms.GroupBox()
        Me.cboControlSet = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudAutoClearEffectDuration = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAutoClearEffect = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnklblLayerRules = New System.Windows.Forms.LinkLabel()
        Me.lnklblDefaultDatafields = New System.Windows.Forms.LinkLabel()
        Me.ttToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbLive.SuspendLayout()
        CType(Me.nudLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDatafields.SuspendLayout()
        Me.gbControls.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAutoClearEffectDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(328, 387)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(247, 387)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOk.TabIndex = 10
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'gbLive
        '
        Me.gbLive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbLive.Controls.Add(Me.nudLayer)
        Me.gbLive.Controls.Add(Me.Label5)
        Me.gbLive.Controls.Add(Me.nudChannel)
        Me.gbLive.Controls.Add(Me.Label4)
        Me.gbLive.Controls.Add(Me.cboServers)
        Me.gbLive.Controls.Add(Me.Label3)
        Me.gbLive.Location = New System.Drawing.Point(12, 5)
        Me.gbLive.Name = "gbLive"
        Me.gbLive.Size = New System.Drawing.Size(391, 104)
        Me.gbLive.TabIndex = 12
        Me.gbLive.TabStop = False
        Me.gbLive.Text = "Playback-Settings"
        '
        'nudLayer
        '
        Me.nudLayer.Location = New System.Drawing.Point(202, 74)
        Me.nudLayer.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudLayer.Name = "nudLayer"
        Me.nudLayer.Size = New System.Drawing.Size(183, 20)
        Me.nudLayer.TabIndex = 5
        Me.ttToolTips.SetToolTip(Me.nudLayer, "Select the Default Layer to be used. This will also be used for all templates, if" &
        " no Layer Rules are set.")
        Me.nudLayer.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(195, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Default-Layer:"
        '
        'nudChannel
        '
        Me.nudChannel.Location = New System.Drawing.Point(9, 74)
        Me.nudChannel.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
        Me.nudChannel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudChannel.Name = "nudChannel"
        Me.nudChannel.Size = New System.Drawing.Size(183, 20)
        Me.nudChannel.TabIndex = 3
        Me.ttToolTips.SetToolTip(Me.nudChannel, "Select the Default Channel to be used.")
        Me.nudChannel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Default-Channel:"
        '
        'cboServers
        '
        Me.cboServers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboServers.FormattingEnabled = True
        Me.cboServers.Location = New System.Drawing.Point(9, 32)
        Me.cboServers.Name = "cboServers"
        Me.cboServers.Size = New System.Drawing.Size(376, 21)
        Me.cboServers.TabIndex = 1
        Me.ttToolTips.SetToolTip(Me.cboServers, "Select the CasparCG-Server to be used by the Dashboard.")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CasparCG Server"
        '
        'gbDatafields
        '
        Me.gbDatafields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbDatafields.Controls.Add(Me.lnklblDefaultDatafields)
        Me.gbDatafields.Controls.Add(Me.txtFields)
        Me.gbDatafields.Location = New System.Drawing.Point(12, 179)
        Me.gbDatafields.Name = "gbDatafields"
        Me.gbDatafields.Size = New System.Drawing.Size(391, 133)
        Me.gbDatafields.TabIndex = 13
        Me.gbDatafields.TabStop = False
        Me.gbDatafields.Text = "Create-List-Datafields:"
        '
        'txtFields
        '
        Me.txtFields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFields.Location = New System.Drawing.Point(9, 19)
        Me.txtFields.Multiline = True
        Me.txtFields.Name = "txtFields"
        Me.txtFields.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFields.Size = New System.Drawing.Size(376, 106)
        Me.txtFields.TabIndex = 0
        Me.ttToolTips.SetToolTip(Me.txtFields, "Set fieldnames to be used by the list worksheet. Use a separate line for each fie" &
        "ldname.")
        '
        'gbControls
        '
        Me.gbControls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbControls.Controls.Add(Me.cboControlSet)
        Me.gbControls.Location = New System.Drawing.Point(12, 117)
        Me.gbControls.Name = "gbControls"
        Me.gbControls.Size = New System.Drawing.Size(391, 54)
        Me.gbControls.TabIndex = 14
        Me.gbControls.TabStop = False
        Me.gbControls.Text = "Playback Controls-Set"
        '
        'cboControlSet
        '
        Me.cboControlSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboControlSet.FormattingEnabled = True
        Me.cboControlSet.Items.AddRange(New Object() {"Play & Stop", "Load, Play & Stop", "Play, Next & Stop", "Play, Stop & Update", "Load, Play, Next & Stop", "Play, Next, Stop & Update", "Load, Play, Stop & Update"})
        Me.cboControlSet.Location = New System.Drawing.Point(9, 19)
        Me.cboControlSet.Name = "cboControlSet"
        Me.cboControlSet.Size = New System.Drawing.Size(376, 21)
        Me.cboControlSet.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudAutoClearEffectDuration)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboAutoClearEffect)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 323)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 58)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Auto-Clear"
        '
        'nudAutoClearEffectDuration
        '
        Me.nudAutoClearEffectDuration.Location = New System.Drawing.Point(198, 32)
        Me.nudAutoClearEffectDuration.Name = "nudAutoClearEffectDuration"
        Me.nudAutoClearEffectDuration.Size = New System.Drawing.Size(187, 20)
        Me.nudAutoClearEffectDuration.TabIndex = 3
        Me.ttToolTips.SetToolTip(Me.nudAutoClearEffectDuration, "Set the duration of the Auto-Clera effect in frames.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(199, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Duration:"
        '
        'cboAutoClearEffect
        '
        Me.cboAutoClearEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAutoClearEffect.FormattingEnabled = True
        Me.cboAutoClearEffect.Items.AddRange(New Object() {"CUT", "MIX"})
        Me.cboAutoClearEffect.Location = New System.Drawing.Point(9, 32)
        Me.cboAutoClearEffect.Name = "cboAutoClearEffect"
        Me.cboAutoClearEffect.Size = New System.Drawing.Size(183, 21)
        Me.cboAutoClearEffect.TabIndex = 1
        Me.ttToolTips.SetToolTip(Me.cboAutoClearEffect, "Select the effect to be used when Auto-Clear is enabled (set to 1).")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Effect:"
        '
        'lnklblLayerRules
        '
        Me.lnklblLayerRules.AutoSize = True
        Me.lnklblLayerRules.Location = New System.Drawing.Point(18, 393)
        Me.lnklblLayerRules.Name = "lnklblLayerRules"
        Me.lnklblLayerRules.Size = New System.Drawing.Size(72, 13)
        Me.lnklblLayerRules.TabIndex = 16
        Me.lnklblLayerRules.TabStop = True
        Me.lnklblLayerRules.Text = "Layer Rules..."
        Me.ttToolTips.SetToolTip(Me.lnklblLayerRules, "Opens a dialog to define Layer-Rules based on template-names.")
        '
        'lnklblDefaultDatafields
        '
        Me.lnklblDefaultDatafields.AutoSize = True
        Me.lnklblDefaultDatafields.Location = New System.Drawing.Point(317, 3)
        Me.lnklblDefaultDatafields.Name = "lnklblDefaultDatafields"
        Me.lnklblDefaultDatafields.Size = New System.Drawing.Size(310, 13)
        Me.lnklblDefaultDatafields.TabIndex = 1
        Me.lnklblDefaultDatafields.TabStop = True
        Me.lnklblDefaultDatafields.Text = "Set the current list of fieldnames as default for all new Excel files."
        Me.ttToolTips.SetToolTip(Me.lnklblDefaultDatafields, "Set ")
        '
        'frmDashboardSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnOk
        Me.ClientSize = New System.Drawing.Size(415, 424)
        Me.Controls.Add(Me.lnklblLayerRules)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbControls)
        Me.Controls.Add(Me.gbDatafields)
        Me.Controls.Add(Me.gbLive)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDashboardSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.gbLive.ResumeLayout(False)
        Me.gbLive.PerformLayout()
        CType(Me.nudLayer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDatafields.ResumeLayout(False)
        Me.gbDatafields.PerformLayout()
        Me.gbControls.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAutoClearEffectDuration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents gbLive As System.Windows.Forms.GroupBox
   Friend WithEvents nudLayer As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents nudChannel As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cboServers As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents gbDatafields As System.Windows.Forms.GroupBox
   Friend WithEvents txtFields As System.Windows.Forms.TextBox
   Friend WithEvents gbControls As System.Windows.Forms.GroupBox
   Friend WithEvents cboControlSet As System.Windows.Forms.ComboBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents cboAutoClearEffect As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents nudAutoClearEffectDuration As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lnklblLayerRules As System.Windows.Forms.LinkLabel
    Friend WithEvents lnklblDefaultDatafields As System.Windows.Forms.LinkLabel
    Friend WithEvents ttToolTips As System.Windows.Forms.ToolTip
End Class
