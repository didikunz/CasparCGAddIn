<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSheetProperties
   Inherits System.Windows.Forms.Form

   'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.tabTab = New System.Windows.Forms.TabControl()
      Me.tabDataSetName = New System.Windows.Forms.TabPage()
      Me.txtDataSetName = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.tabTemplate = New System.Windows.Forms.TabPage()
      Me.cboPreviewTemplate = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tabAutoUpdate = New System.Windows.Forms.TabPage()
      Me.chkRefreshQueries = New System.Windows.Forms.CheckBox()
      Me.gbLive = New System.Windows.Forms.GroupBox()
      Me.cboControlSet = New System.Windows.Forms.ComboBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.nudLayer = New System.Windows.Forms.NumericUpDown()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.nudChannel = New System.Windows.Forms.NumericUpDown()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cboServers = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.rbDataset = New System.Windows.Forms.RadioButton()
      Me.rbLive = New System.Windows.Forms.RadioButton()
      Me.tabQueries = New System.Windows.Forms.TabPage()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.clstQueries = New System.Windows.Forms.CheckedListBox()
      Me.tabTab.SuspendLayout()
      Me.tabDataSetName.SuspendLayout()
      Me.tabTemplate.SuspendLayout()
      Me.tabAutoUpdate.SuspendLayout()
      Me.gbLive.SuspendLayout()
      CType(Me.nudLayer, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudChannel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabQueries.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(357, 222)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 25)
      Me.btnCancel.TabIndex = 9
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.Location = New System.Drawing.Point(276, 222)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 25)
      Me.btnOk.TabIndex = 8
      Me.btnOk.Text = "OK"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'tabTab
      '
      Me.tabTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tabTab.Controls.Add(Me.tabDataSetName)
      Me.tabTab.Controls.Add(Me.tabTemplate)
      Me.tabTab.Controls.Add(Me.tabAutoUpdate)
      Me.tabTab.Controls.Add(Me.tabQueries)
      Me.tabTab.Location = New System.Drawing.Point(12, 12)
      Me.tabTab.Name = "tabTab"
      Me.tabTab.SelectedIndex = 0
      Me.tabTab.Size = New System.Drawing.Size(420, 204)
      Me.tabTab.TabIndex = 10
      '
      'tabDataSetName
      '
      Me.tabDataSetName.Controls.Add(Me.txtDataSetName)
      Me.tabDataSetName.Controls.Add(Me.Label1)
      Me.tabDataSetName.Location = New System.Drawing.Point(4, 22)
      Me.tabDataSetName.Name = "tabDataSetName"
      Me.tabDataSetName.Padding = New System.Windows.Forms.Padding(3)
      Me.tabDataSetName.Size = New System.Drawing.Size(412, 178)
      Me.tabDataSetName.TabIndex = 0
      Me.tabDataSetName.Text = "Data Set"
      Me.tabDataSetName.UseVisualStyleBackColor = True
      '
      'txtDataSetName
      '
      Me.txtDataSetName.Location = New System.Drawing.Point(8, 28)
      Me.txtDataSetName.Name = "txtDataSetName"
      Me.txtDataSetName.Size = New System.Drawing.Size(397, 20)
      Me.txtDataSetName.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 11)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Name:"
      '
      'tabTemplate
      '
      Me.tabTemplate.Controls.Add(Me.cboPreviewTemplate)
      Me.tabTemplate.Controls.Add(Me.Label2)
      Me.tabTemplate.Location = New System.Drawing.Point(4, 22)
      Me.tabTemplate.Name = "tabTemplate"
      Me.tabTemplate.Padding = New System.Windows.Forms.Padding(3)
      Me.tabTemplate.Size = New System.Drawing.Size(412, 178)
      Me.tabTemplate.TabIndex = 1
      Me.tabTemplate.Text = "Template"
      Me.tabTemplate.UseVisualStyleBackColor = True
      '
      'cboPreviewTemplate
      '
      Me.cboPreviewTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboPreviewTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboPreviewTemplate.FormattingEnabled = True
      Me.cboPreviewTemplate.Location = New System.Drawing.Point(8, 28)
      Me.cboPreviewTemplate.Name = "cboPreviewTemplate"
      Me.cboPreviewTemplate.Size = New System.Drawing.Size(398, 21)
      Me.cboPreviewTemplate.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 11)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(54, 13)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Template:"
      '
      'tabAutoUpdate
      '
      Me.tabAutoUpdate.Controls.Add(Me.chkRefreshQueries)
      Me.tabAutoUpdate.Controls.Add(Me.gbLive)
      Me.tabAutoUpdate.Controls.Add(Me.rbDataset)
      Me.tabAutoUpdate.Controls.Add(Me.rbLive)
      Me.tabAutoUpdate.Location = New System.Drawing.Point(4, 22)
      Me.tabAutoUpdate.Name = "tabAutoUpdate"
      Me.tabAutoUpdate.Padding = New System.Windows.Forms.Padding(3)
      Me.tabAutoUpdate.Size = New System.Drawing.Size(412, 178)
      Me.tabAutoUpdate.TabIndex = 2
      Me.tabAutoUpdate.Text = "Auto-Update"
      Me.tabAutoUpdate.UseVisualStyleBackColor = True
      '
      'chkRefreshQueries
      '
      Me.chkRefreshQueries.AutoSize = True
      Me.chkRefreshQueries.Location = New System.Drawing.Point(139, 9)
      Me.chkRefreshQueries.Name = "chkRefreshQueries"
      Me.chkRefreshQueries.Size = New System.Drawing.Size(169, 17)
      Me.chkRefreshQueries.TabIndex = 3
      Me.chkRefreshQueries.Text = "Refresh queries before update"
      Me.chkRefreshQueries.UseVisualStyleBackColor = True
      '
      'gbLive
      '
      Me.gbLive.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.gbLive.Controls.Add(Me.cboControlSet)
      Me.gbLive.Controls.Add(Me.Label6)
      Me.gbLive.Controls.Add(Me.nudLayer)
      Me.gbLive.Controls.Add(Me.Label5)
      Me.gbLive.Controls.Add(Me.nudChannel)
      Me.gbLive.Controls.Add(Me.Label4)
      Me.gbLive.Controls.Add(Me.cboServers)
      Me.gbLive.Controls.Add(Me.Label3)
      Me.gbLive.Location = New System.Drawing.Point(8, 31)
      Me.gbLive.Name = "gbLive"
      Me.gbLive.Size = New System.Drawing.Size(387, 141)
      Me.gbLive.TabIndex = 2
      Me.gbLive.TabStop = False
      Me.gbLive.Text = "Playback-Settings"
      '
      'cboControlSet
      '
      Me.cboControlSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboControlSet.FormattingEnabled = True
      Me.cboControlSet.Items.AddRange(New Object() {"Play & Stop", "Load, Play & Stop", "Play, Next & Stop", "Play, Stop & Update", "Load, Play, Next & Stop", "Play, Next, Stop & Update", "Load, Play, Stop & Update"})
      Me.cboControlSet.Location = New System.Drawing.Point(6, 113)
      Me.cboControlSet.Name = "cboControlSet"
      Me.cboControlSet.Size = New System.Drawing.Size(375, 21)
      Me.cboControlSet.TabIndex = 7
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(6, 97)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(114, 13)
      Me.Label6.TabIndex = 6
      Me.Label6.Text = "Playback Controls-Set:"
      '
      'nudLayer
      '
      Me.nudLayer.Location = New System.Drawing.Point(198, 74)
      Me.nudLayer.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
      Me.nudLayer.Name = "nudLayer"
      Me.nudLayer.Size = New System.Drawing.Size(183, 20)
      Me.nudLayer.TabIndex = 5
      Me.nudLayer.Value = New Decimal(New Integer() {20, 0, 0, 0})
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(195, 56)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(36, 13)
      Me.Label5.TabIndex = 4
      Me.Label5.Text = "Layer:"
      '
      'nudChannel
      '
      Me.nudChannel.Location = New System.Drawing.Point(6, 74)
      Me.nudChannel.Maximum = New Decimal(New Integer() {32, 0, 0, 0})
      Me.nudChannel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudChannel.Name = "nudChannel"
      Me.nudChannel.Size = New System.Drawing.Size(183, 20)
      Me.nudChannel.TabIndex = 3
      Me.nudChannel.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(6, 58)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(49, 13)
      Me.Label4.TabIndex = 2
      Me.Label4.Text = "Channel:"
      '
      'cboServers
      '
      Me.cboServers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboServers.FormattingEnabled = True
      Me.cboServers.Location = New System.Drawing.Point(9, 32)
      Me.cboServers.Name = "cboServers"
      Me.cboServers.Size = New System.Drawing.Size(372, 21)
      Me.cboServers.TabIndex = 1
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(6, 16)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(94, 13)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "CasparCG Servers"
      '
      'rbDataset
      '
      Me.rbDataset.AutoSize = True
      Me.rbDataset.Location = New System.Drawing.Point(66, 8)
      Me.rbDataset.Name = "rbDataset"
      Me.rbDataset.Size = New System.Drawing.Size(67, 17)
      Me.rbDataset.TabIndex = 1
      Me.rbDataset.Text = "Data Set"
      Me.rbDataset.UseVisualStyleBackColor = True
      '
      'rbLive
      '
      Me.rbLive.AutoSize = True
      Me.rbLive.Location = New System.Drawing.Point(8, 8)
      Me.rbLive.Name = "rbLive"
      Me.rbLive.Size = New System.Drawing.Size(45, 17)
      Me.rbLive.TabIndex = 0
      Me.rbLive.Text = "Live"
      Me.rbLive.UseVisualStyleBackColor = True
      '
      'tabQueries
      '
      Me.tabQueries.Controls.Add(Me.Label7)
      Me.tabQueries.Controls.Add(Me.clstQueries)
      Me.tabQueries.Location = New System.Drawing.Point(4, 22)
      Me.tabQueries.Name = "tabQueries"
      Me.tabQueries.Padding = New System.Windows.Forms.Padding(3)
      Me.tabQueries.Size = New System.Drawing.Size(412, 178)
      Me.tabQueries.TabIndex = 3
      Me.tabQueries.Text = "Queries"
      Me.tabQueries.UseVisualStyleBackColor = True
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(6, 4)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(307, 13)
      Me.Label7.TabIndex = 1
      Me.Label7.Text = "Select all queries, which need to be updated before the update."
      '
      'clstQueries
      '
      Me.clstQueries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.clstQueries.FormattingEnabled = True
      Me.clstQueries.Location = New System.Drawing.Point(6, 20)
      Me.clstQueries.Name = "clstQueries"
      Me.clstQueries.Size = New System.Drawing.Size(400, 154)
      Me.clstQueries.TabIndex = 0
      '
      'frmSheetProperties
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(442, 257)
      Me.Controls.Add(Me.tabTab)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSheetProperties"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Properties"
      Me.tabTab.ResumeLayout(False)
      Me.tabDataSetName.ResumeLayout(False)
      Me.tabDataSetName.PerformLayout()
      Me.tabTemplate.ResumeLayout(False)
      Me.tabTemplate.PerformLayout()
      Me.tabAutoUpdate.ResumeLayout(False)
      Me.tabAutoUpdate.PerformLayout()
      Me.gbLive.ResumeLayout(False)
      Me.gbLive.PerformLayout()
      CType(Me.nudLayer, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudChannel, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabQueries.ResumeLayout(False)
      Me.tabQueries.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents tabTab As System.Windows.Forms.TabControl
   Friend WithEvents tabDataSetName As System.Windows.Forms.TabPage
   Friend WithEvents txtDataSetName As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tabTemplate As System.Windows.Forms.TabPage
   Friend WithEvents cboPreviewTemplate As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents tabAutoUpdate As System.Windows.Forms.TabPage
   Friend WithEvents gbLive As System.Windows.Forms.GroupBox
   Friend WithEvents nudLayer As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents nudChannel As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cboServers As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents rbDataset As System.Windows.Forms.RadioButton
   Friend WithEvents rbLive As System.Windows.Forms.RadioButton
   Friend WithEvents cboControlSet As System.Windows.Forms.ComboBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents chkRefreshQueries As System.Windows.Forms.CheckBox
   Friend WithEvents tabQueries As System.Windows.Forms.TabPage
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents clstQueries As System.Windows.Forms.CheckedListBox
End Class
