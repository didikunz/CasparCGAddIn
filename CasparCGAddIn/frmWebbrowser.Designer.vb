<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWebbrowser
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWebbrowser))
      Me.panTop = New System.Windows.Forms.Panel()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnStore = New System.Windows.Forms.Button()
      Me.rbModeDiv = New System.Windows.Forms.RadioButton()
      Me.rbModeTable = New System.Windows.Forms.RadioButton()
      Me.txtUrl = New System.Windows.Forms.TextBox()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.scMain = New System.Windows.Forms.SplitContainer()
      Me.webBrowser = New System.Windows.Forms.WebBrowser()
      Me.scRight = New System.Windows.Forms.SplitContainer()
      Me.trvTree = New System.Windows.Forms.TreeView()
      Me.dgvTable = New System.Windows.Forms.DataGridView()
      Me.panTop.SuspendLayout()
      CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.scMain.Panel1.SuspendLayout()
      Me.scMain.Panel2.SuspendLayout()
      Me.scMain.SuspendLayout()
      CType(Me.scRight, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.scRight.Panel1.SuspendLayout()
      Me.scRight.Panel2.SuspendLayout()
      Me.scRight.SuspendLayout()
      CType(Me.dgvTable, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'panTop
      '
      Me.panTop.Controls.Add(Me.btnCancel)
      Me.panTop.Controls.Add(Me.btnStore)
      Me.panTop.Controls.Add(Me.rbModeDiv)
      Me.panTop.Controls.Add(Me.rbModeTable)
      Me.panTop.Controls.Add(Me.txtUrl)
      Me.panTop.Controls.Add(Me.btnRefresh)
      Me.panTop.Dock = System.Windows.Forms.DockStyle.Top
      Me.panTop.Location = New System.Drawing.Point(0, 0)
      Me.panTop.Name = "panTop"
      Me.panTop.Size = New System.Drawing.Size(1056, 68)
      Me.panTop.TabIndex = 0
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(967, 38)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(77, 22)
      Me.btnCancel.TabIndex = 5
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnStore
      '
      Me.btnStore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnStore.Location = New System.Drawing.Point(823, 38)
      Me.btnStore.Name = "btnStore"
      Me.btnStore.Size = New System.Drawing.Size(138, 22)
      Me.btnStore.TabIndex = 4
      Me.btnStore.Text = "Store and Load"
      Me.btnStore.UseVisualStyleBackColor = True
      '
      'rbModeDiv
      '
      Me.rbModeDiv.AutoSize = True
      Me.rbModeDiv.Location = New System.Drawing.Point(131, 40)
      Me.rbModeDiv.Name = "rbModeDiv"
      Me.rbModeDiv.Size = New System.Drawing.Size(88, 17)
      Me.rbModeDiv.TabIndex = 3
      Me.rbModeDiv.TabStop = True
      Me.rbModeDiv.Text = "Look for Divs"
      Me.rbModeDiv.UseVisualStyleBackColor = True
      '
      'rbModeTable
      '
      Me.rbModeTable.AutoSize = True
      Me.rbModeTable.Location = New System.Drawing.Point(12, 40)
      Me.rbModeTable.Name = "rbModeTable"
      Me.rbModeTable.Size = New System.Drawing.Size(99, 17)
      Me.rbModeTable.TabIndex = 2
      Me.rbModeTable.TabStop = True
      Me.rbModeTable.Text = "Look for Tables"
      Me.rbModeTable.UseVisualStyleBackColor = True
      '
      'txtUrl
      '
      Me.txtUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtUrl.Location = New System.Drawing.Point(12, 12)
      Me.txtUrl.Name = "txtUrl"
      Me.txtUrl.Size = New System.Drawing.Size(949, 20)
      Me.txtUrl.TabIndex = 1
      '
      'btnRefresh
      '
      Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnRefresh.Location = New System.Drawing.Point(967, 12)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(77, 20)
      Me.btnRefresh.TabIndex = 0
      Me.btnRefresh.Text = "Refresh"
      Me.btnRefresh.UseVisualStyleBackColor = True
      '
      'scMain
      '
      Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
      Me.scMain.Location = New System.Drawing.Point(0, 68)
      Me.scMain.Name = "scMain"
      '
      'scMain.Panel1
      '
      Me.scMain.Panel1.Controls.Add(Me.webBrowser)
      '
      'scMain.Panel2
      '
      Me.scMain.Panel2.Controls.Add(Me.scRight)
      Me.scMain.Size = New System.Drawing.Size(1056, 539)
      Me.scMain.SplitterDistance = 562
      Me.scMain.TabIndex = 1
      '
      'webBrowser
      '
      Me.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill
      Me.webBrowser.Location = New System.Drawing.Point(0, 0)
      Me.webBrowser.MinimumSize = New System.Drawing.Size(20, 20)
      Me.webBrowser.Name = "webBrowser"
      Me.webBrowser.Size = New System.Drawing.Size(562, 539)
      Me.webBrowser.TabIndex = 0
      '
      'scRight
      '
      Me.scRight.Dock = System.Windows.Forms.DockStyle.Fill
      Me.scRight.Location = New System.Drawing.Point(0, 0)
      Me.scRight.Name = "scRight"
      Me.scRight.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'scRight.Panel1
      '
      Me.scRight.Panel1.Controls.Add(Me.trvTree)
      '
      'scRight.Panel2
      '
      Me.scRight.Panel2.Controls.Add(Me.dgvTable)
      Me.scRight.Size = New System.Drawing.Size(490, 539)
      Me.scRight.SplitterDistance = 244
      Me.scRight.TabIndex = 0
      '
      'trvTree
      '
      Me.trvTree.Dock = System.Windows.Forms.DockStyle.Fill
      Me.trvTree.HideSelection = False
      Me.trvTree.Location = New System.Drawing.Point(0, 0)
      Me.trvTree.Name = "trvTree"
      Me.trvTree.Size = New System.Drawing.Size(490, 244)
      Me.trvTree.TabIndex = 0
      '
      'dgvTable
      '
      Me.dgvTable.AllowUserToAddRows = False
      Me.dgvTable.AllowUserToDeleteRows = False
      Me.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill
      Me.dgvTable.Location = New System.Drawing.Point(0, 0)
      Me.dgvTable.Name = "dgvTable"
      Me.dgvTable.ReadOnly = True
      Me.dgvTable.RowHeadersWidth = 25
      Me.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvTable.Size = New System.Drawing.Size(490, 291)
      Me.dgvTable.TabIndex = 0
      '
      'frmWebbrowser
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(1056, 607)
      Me.Controls.Add(Me.scMain)
      Me.Controls.Add(Me.panTop)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmWebbrowser"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Browser Import"
      Me.panTop.ResumeLayout(False)
      Me.panTop.PerformLayout()
      Me.scMain.Panel1.ResumeLayout(False)
      Me.scMain.Panel2.ResumeLayout(False)
      CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
      Me.scMain.ResumeLayout(False)
      Me.scRight.Panel1.ResumeLayout(False)
      Me.scRight.Panel2.ResumeLayout(False)
      CType(Me.scRight, System.ComponentModel.ISupportInitialize).EndInit()
      Me.scRight.ResumeLayout(False)
      CType(Me.dgvTable, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents panTop As System.Windows.Forms.Panel
   Friend WithEvents txtUrl As System.Windows.Forms.TextBox
   Friend WithEvents btnRefresh As System.Windows.Forms.Button
   Friend WithEvents scMain As System.Windows.Forms.SplitContainer
   Friend WithEvents scRight As System.Windows.Forms.SplitContainer
   Friend WithEvents trvTree As System.Windows.Forms.TreeView
   Friend WithEvents dgvTable As System.Windows.Forms.DataGridView
   Friend WithEvents webBrowser As System.Windows.Forms.WebBrowser
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnStore As System.Windows.Forms.Button
   Friend WithEvents rbModeDiv As System.Windows.Forms.RadioButton
   Friend WithEvents rbModeTable As System.Windows.Forms.RadioButton
End Class
