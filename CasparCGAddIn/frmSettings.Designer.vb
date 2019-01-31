<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
      Me.ftbCasparExe = New CommonControls.ctrFileTextBox()
      Me.bsServers = New System.Windows.Forms.BindingSource(Me.components)
      Me.btnOk = New System.Windows.Forms.Button()
      Me.dgvServers = New System.Windows.Forms.DataGridView()
      Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ServerAdress = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Port = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tabTab = New System.Windows.Forms.TabControl()
      Me.tabServers = New System.Windows.Forms.TabPage()
      Me.chkAutoConnect = New System.Windows.Forms.CheckBox()
      Me.btnDelete = New System.Windows.Forms.Button()
      Me.btnNew = New System.Windows.Forms.Button()
      Me.txtPort = New System.Windows.Forms.TextBox()
      Me.txtAddress = New System.Windows.Forms.TextBox()
      Me.lblPort = New System.Windows.Forms.Label()
      Me.lblAddress = New System.Windows.Forms.Label()
      Me.rbModeLocal = New System.Windows.Forms.RadioButton()
      Me.rbModeRemote = New System.Windows.Forms.RadioButton()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblExeFile = New System.Windows.Forms.Label()
      Me.tabPreview = New System.Windows.Forms.TabPage()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.nudPreviewChannel = New System.Windows.Forms.NumericUpDown()
      Me.cboPreviewServer = New System.Windows.Forms.ComboBox()
      Me.bsServersClone = New System.Windows.Forms.BindingSource(Me.components)
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tabSettings = New System.Windows.Forms.TabPage()
      Me.chkShowDashboard = New System.Windows.Forms.CheckBox()
      Me.chkUseAveco = New System.Windows.Forms.CheckBox()
      CType(Me.bsServers, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvServers, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabTab.SuspendLayout()
      Me.tabServers.SuspendLayout()
      Me.tabPreview.SuspendLayout()
      CType(Me.nudPreviewChannel, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bsServersClone, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tabSettings.SuspendLayout()
      Me.SuspendLayout()
      '
      'ftbCasparExe
      '
      Me.ftbCasparExe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ftbCasparExe.BackColor = System.Drawing.Color.Transparent
      Me.ftbCasparExe.CustomDialogFilter = "CasparCG Exe-File (casparcg.exe)|casparcg.exe|Exe-Files (*.exe)|*.exe||"
      Me.ftbCasparExe.DataBindings.Add(New System.Windows.Forms.Binding("Filename", Me.bsServers, "CasparExePath", True))
      Me.ftbCasparExe.DialogFilter = CommonControls.ctrFileTextBox.DialogFilterType.dtfCustom
      Me.ftbCasparExe.DialogType = CommonControls.ctrFileTextBox.enumDialogType.OpenDialog
      Me.ftbCasparExe.Filename = ""
      Me.ftbCasparExe.IntialDirectory = ""
      Me.ftbCasparExe.Location = New System.Drawing.Point(9, 62)
      Me.ftbCasparExe.Margin = New System.Windows.Forms.Padding(0)
      Me.ftbCasparExe.MaximumSize = New System.Drawing.Size(30000, 20)
      Me.ftbCasparExe.MinimumSize = New System.Drawing.Size(75, 20)
      Me.ftbCasparExe.Name = "ftbCasparExe"
      Me.ftbCasparExe.OverwritePrompt = True
      Me.ftbCasparExe.ShowClearButton = True
      Me.ftbCasparExe.Size = New System.Drawing.Size(457, 20)
      Me.ftbCasparExe.TabIndex = 4
      Me.ftbCasparExe.ToolTipControl = Nothing
      '
      'bsServers
      '
      Me.bsServers.DataSource = GetType(CasparObjects.CasparCG)
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.Location = New System.Drawing.Point(417, 355)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 25)
      Me.btnOk.TabIndex = 6
      Me.btnOk.Text = "Finish"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'dgvServers
      '
      Me.dgvServers.AllowUserToAddRows = False
      Me.dgvServers.AllowUserToDeleteRows = False
      Me.dgvServers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvServers.AutoGenerateColumns = False
      Me.dgvServers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvServers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NameDataGridViewTextBoxColumn, Me.ServerAdress, Me.Port})
      Me.dgvServers.DataSource = Me.bsServers
      Me.dgvServers.Location = New System.Drawing.Point(6, 88)
      Me.dgvServers.Name = "dgvServers"
      Me.dgvServers.ReadOnly = True
      Me.dgvServers.RowHeadersWidth = 25
      Me.dgvServers.Size = New System.Drawing.Size(460, 189)
      Me.dgvServers.TabIndex = 8
      '
      'NameDataGridViewTextBoxColumn
      '
      Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
      Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
      Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
      Me.NameDataGridViewTextBoxColumn.ReadOnly = True
      Me.NameDataGridViewTextBoxColumn.Width = 200
      '
      'ServerAdress
      '
      Me.ServerAdress.DataPropertyName = "ServerAdress"
      Me.ServerAdress.HeaderText = "Address"
      Me.ServerAdress.Name = "ServerAdress"
      Me.ServerAdress.ReadOnly = True
      Me.ServerAdress.Width = 150
      '
      'Port
      '
      Me.Port.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Port.DataPropertyName = "Port"
      Me.Port.HeaderText = "Port"
      Me.Port.Name = "Port"
      Me.Port.ReadOnly = True
      '
      'tabTab
      '
      Me.tabTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tabTab.Controls.Add(Me.tabServers)
      Me.tabTab.Controls.Add(Me.tabPreview)
      Me.tabTab.Controls.Add(Me.tabSettings)
      Me.tabTab.Location = New System.Drawing.Point(12, 10)
      Me.tabTab.Name = "tabTab"
      Me.tabTab.SelectedIndex = 0
      Me.tabTab.Size = New System.Drawing.Size(480, 339)
      Me.tabTab.TabIndex = 9
      '
      'tabServers
      '
      Me.tabServers.Controls.Add(Me.chkAutoConnect)
      Me.tabServers.Controls.Add(Me.btnDelete)
      Me.tabServers.Controls.Add(Me.btnNew)
      Me.tabServers.Controls.Add(Me.txtPort)
      Me.tabServers.Controls.Add(Me.txtAddress)
      Me.tabServers.Controls.Add(Me.lblPort)
      Me.tabServers.Controls.Add(Me.lblAddress)
      Me.tabServers.Controls.Add(Me.rbModeLocal)
      Me.tabServers.Controls.Add(Me.rbModeRemote)
      Me.tabServers.Controls.Add(Me.txtName)
      Me.tabServers.Controls.Add(Me.Label1)
      Me.tabServers.Controls.Add(Me.dgvServers)
      Me.tabServers.Controls.Add(Me.ftbCasparExe)
      Me.tabServers.Controls.Add(Me.lblExeFile)
      Me.tabServers.Location = New System.Drawing.Point(4, 22)
      Me.tabServers.Name = "tabServers"
      Me.tabServers.Padding = New System.Windows.Forms.Padding(3)
      Me.tabServers.Size = New System.Drawing.Size(472, 313)
      Me.tabServers.TabIndex = 0
      Me.tabServers.Text = "Servers"
      Me.tabServers.UseVisualStyleBackColor = True
      '
      'chkAutoConnect
      '
      Me.chkAutoConnect.AutoSize = True
      Me.chkAutoConnect.Location = New System.Drawing.Point(9, 288)
      Me.chkAutoConnect.Name = "chkAutoConnect"
      Me.chkAutoConnect.Size = New System.Drawing.Size(293, 17)
      Me.chkAutoConnect.TabIndex = 20
      Me.chkAutoConnect.Text = "Always connect on opening a Caspar enabled workbook"
      Me.chkAutoConnect.UseVisualStyleBackColor = True
      '
      'btnDelete
      '
      Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnDelete.Location = New System.Drawing.Point(391, 282)
      Me.btnDelete.Name = "btnDelete"
      Me.btnDelete.Size = New System.Drawing.Size(75, 25)
      Me.btnDelete.TabIndex = 19
      Me.btnDelete.Text = "Delete"
      Me.btnDelete.UseVisualStyleBackColor = True
      '
      'btnNew
      '
      Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnNew.Location = New System.Drawing.Point(310, 282)
      Me.btnNew.Name = "btnNew"
      Me.btnNew.Size = New System.Drawing.Size(75, 25)
      Me.btnNew.TabIndex = 18
      Me.btnNew.Text = "New"
      Me.btnNew.UseVisualStyleBackColor = True
      '
      'txtPort
      '
      Me.txtPort.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsServers, "Port", True))
      Me.txtPort.Location = New System.Drawing.Point(338, 62)
      Me.txtPort.Name = "txtPort"
      Me.txtPort.Size = New System.Drawing.Size(128, 20)
      Me.txtPort.TabIndex = 17
      '
      'txtAddress
      '
      Me.txtAddress.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsServers, "ServerAdress", True))
      Me.txtAddress.Location = New System.Drawing.Point(9, 62)
      Me.txtAddress.Name = "txtAddress"
      Me.txtAddress.Size = New System.Drawing.Size(323, 20)
      Me.txtAddress.TabIndex = 16
      '
      'lblPort
      '
      Me.lblPort.AutoSize = True
      Me.lblPort.Location = New System.Drawing.Point(335, 46)
      Me.lblPort.Name = "lblPort"
      Me.lblPort.Size = New System.Drawing.Size(29, 13)
      Me.lblPort.TabIndex = 14
      Me.lblPort.Text = "Port:"
      '
      'lblAddress
      '
      Me.lblAddress.AutoSize = True
      Me.lblAddress.Location = New System.Drawing.Point(6, 46)
      Me.lblAddress.Name = "lblAddress"
      Me.lblAddress.Size = New System.Drawing.Size(48, 13)
      Me.lblAddress.TabIndex = 13
      Me.lblAddress.Text = "Address:"
      '
      'rbModeLocal
      '
      Me.rbModeLocal.AutoSize = True
      Me.rbModeLocal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.rbModeLocal.Location = New System.Drawing.Point(415, 4)
      Me.rbModeLocal.Name = "rbModeLocal"
      Me.rbModeLocal.Size = New System.Drawing.Size(51, 17)
      Me.rbModeLocal.TabIndex = 12
      Me.rbModeLocal.TabStop = True
      Me.rbModeLocal.Text = "Local"
      Me.rbModeLocal.UseVisualStyleBackColor = True
      '
      'rbModeRemote
      '
      Me.rbModeRemote.AutoSize = True
      Me.rbModeRemote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.rbModeRemote.Location = New System.Drawing.Point(347, 4)
      Me.rbModeRemote.Name = "rbModeRemote"
      Me.rbModeRemote.Size = New System.Drawing.Size(62, 17)
      Me.rbModeRemote.TabIndex = 11
      Me.rbModeRemote.TabStop = True
      Me.rbModeRemote.Text = "Remote"
      Me.rbModeRemote.UseVisualStyleBackColor = True
      '
      'txtName
      '
      Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsServers, "Name", True))
      Me.txtName.Location = New System.Drawing.Point(9, 22)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(457, 20)
      Me.txtName.TabIndex = 10
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 6)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 9
      Me.Label1.Text = "Name:"
      '
      'lblExeFile
      '
      Me.lblExeFile.AutoSize = True
      Me.lblExeFile.Location = New System.Drawing.Point(6, 46)
      Me.lblExeFile.Name = "lblExeFile"
      Me.lblExeFile.Size = New System.Drawing.Size(98, 13)
      Me.lblExeFile.TabIndex = 15
      Me.lblExeFile.Text = "CasparCG-Exe-File:"
      '
      'tabPreview
      '
      Me.tabPreview.Controls.Add(Me.Label3)
      Me.tabPreview.Controls.Add(Me.nudPreviewChannel)
      Me.tabPreview.Controls.Add(Me.cboPreviewServer)
      Me.tabPreview.Controls.Add(Me.Label2)
      Me.tabPreview.Location = New System.Drawing.Point(4, 22)
      Me.tabPreview.Name = "tabPreview"
      Me.tabPreview.Padding = New System.Windows.Forms.Padding(3)
      Me.tabPreview.Size = New System.Drawing.Size(472, 313)
      Me.tabPreview.TabIndex = 1
      Me.tabPreview.Text = "Preview"
      Me.tabPreview.UseVisualStyleBackColor = True
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(394, 6)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(49, 13)
      Me.Label3.TabIndex = 3
      Me.Label3.Text = "Channel:"
      '
      'nudPreviewChannel
      '
      Me.nudPreviewChannel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.nudPreviewChannel.Location = New System.Drawing.Point(397, 23)
      Me.nudPreviewChannel.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.nudPreviewChannel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudPreviewChannel.Name = "nudPreviewChannel"
      Me.nudPreviewChannel.Size = New System.Drawing.Size(69, 20)
      Me.nudPreviewChannel.TabIndex = 2
      Me.nudPreviewChannel.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'cboPreviewServer
      '
      Me.cboPreviewServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboPreviewServer.DataSource = Me.bsServersClone
      Me.cboPreviewServer.DisplayMember = "Name"
      Me.cboPreviewServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboPreviewServer.FormattingEnabled = True
      Me.cboPreviewServer.Location = New System.Drawing.Point(10, 22)
      Me.cboPreviewServer.Name = "cboPreviewServer"
      Me.cboPreviewServer.Size = New System.Drawing.Size(381, 21)
      Me.cboPreviewServer.TabIndex = 1
      '
      'bsServersClone
      '
      Me.bsServersClone.DataSource = GetType(CasparObjects.CasparCG)
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(7, 6)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(82, 13)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Preview-Server:"
      '
      'tabSettings
      '
      Me.tabSettings.Controls.Add(Me.chkShowDashboard)
      Me.tabSettings.Controls.Add(Me.chkUseAveco)
      Me.tabSettings.Location = New System.Drawing.Point(4, 22)
      Me.tabSettings.Name = "tabSettings"
      Me.tabSettings.Padding = New System.Windows.Forms.Padding(3)
      Me.tabSettings.Size = New System.Drawing.Size(472, 313)
      Me.tabSettings.TabIndex = 2
      Me.tabSettings.Text = "Settings"
      Me.tabSettings.UseVisualStyleBackColor = True
      '
      'chkShowDashboard
      '
      Me.chkShowDashboard.AutoSize = True
      Me.chkShowDashboard.Location = New System.Drawing.Point(18, 48)
      Me.chkShowDashboard.Name = "chkShowDashboard"
      Me.chkShowDashboard.Size = New System.Drawing.Size(141, 17)
      Me.chkShowDashboard.TabIndex = 1
      Me.chkShowDashboard.Text = "Show Dashboard button"
      Me.chkShowDashboard.UseVisualStyleBackColor = True
      '
      'chkUseAveco
      '
      Me.chkUseAveco.AutoSize = True
      Me.chkUseAveco.Location = New System.Drawing.Point(18, 25)
      Me.chkUseAveco.Name = "chkUseAveco"
      Me.chkUseAveco.Size = New System.Drawing.Size(203, 17)
      Me.chkUseAveco.TabIndex = 0
      Me.chkUseAveco.Text = "Use with Aveco compatible templates"
      Me.chkUseAveco.UseVisualStyleBackColor = True
      '
      'frmSettings
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(504, 390)
      Me.Controls.Add(Me.tabTab)
      Me.Controls.Add(Me.btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSettings"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Settings"
      CType(Me.bsServers, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvServers, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabTab.ResumeLayout(False)
      Me.tabServers.ResumeLayout(False)
      Me.tabServers.PerformLayout()
      Me.tabPreview.ResumeLayout(False)
      Me.tabPreview.PerformLayout()
      CType(Me.nudPreviewChannel, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bsServersClone, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tabSettings.ResumeLayout(False)
      Me.tabSettings.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ftbCasparExe As CommonControls.ctrFileTextBox
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents bsServers As System.Windows.Forms.BindingSource
   Friend WithEvents dgvServers As System.Windows.Forms.DataGridView
   Friend WithEvents tabTab As System.Windows.Forms.TabControl
   Friend WithEvents tabServers As System.Windows.Forms.TabPage
   Friend WithEvents tabPreview As System.Windows.Forms.TabPage
   Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ServerAdress As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Port As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents rbModeLocal As System.Windows.Forms.RadioButton
   Friend WithEvents rbModeRemote As System.Windows.Forms.RadioButton
   Friend WithEvents txtName As System.Windows.Forms.TextBox
   Friend WithEvents lblPort As System.Windows.Forms.Label
   Friend WithEvents lblAddress As System.Windows.Forms.Label
   Friend WithEvents lblExeFile As System.Windows.Forms.Label
   Friend WithEvents txtPort As System.Windows.Forms.TextBox
   Friend WithEvents txtAddress As System.Windows.Forms.TextBox
   Friend WithEvents btnDelete As System.Windows.Forms.Button
   Friend WithEvents btnNew As System.Windows.Forms.Button
   Friend WithEvents cboPreviewServer As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents nudPreviewChannel As System.Windows.Forms.NumericUpDown
   Friend WithEvents bsServersClone As System.Windows.Forms.BindingSource
   Friend WithEvents chkAutoConnect As System.Windows.Forms.CheckBox
   Friend WithEvents tabSettings As System.Windows.Forms.TabPage
   Friend WithEvents chkShowDashboard As System.Windows.Forms.CheckBox
   Friend WithEvents chkUseAveco As System.Windows.Forms.CheckBox
End Class
