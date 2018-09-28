<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetupWebData
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
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtURL = New System.Windows.Forms.TextBox()
      Me.bsWebDatas = New System.Windows.Forms.BindingSource(Me.components)
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.dgvWebDatas = New System.Windows.Forms.DataGridView()
      Me.IsSelectedDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.ValueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Label2 = New System.Windows.Forms.Label()
      CType(Me.bsWebDatas, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvWebDatas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(401, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "The URL for the webservice must be placed in the cell A1 of the current worksheet" &
    ":"
      '
      'txtURL
      '
      Me.txtURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtURL.BackColor = System.Drawing.SystemColors.Window
      Me.txtURL.Location = New System.Drawing.Point(15, 25)
      Me.txtURL.Name = "txtURL"
      Me.txtURL.ReadOnly = True
      Me.txtURL.Size = New System.Drawing.Size(611, 20)
      Me.txtURL.TabIndex = 1
      '
      'bsWebDatas
      '
      Me.bsWebDatas.DataSource = GetType(CasparCGAddIn.frmSetupWebData.WebData)
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(551, 403)
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
      Me.btnOk.Location = New System.Drawing.Point(470, 403)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 25)
      Me.btnOk.TabIndex = 10
      Me.btnOk.Text = "OK"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'dgvWebDatas
      '
      Me.dgvWebDatas.AllowUserToAddRows = False
      Me.dgvWebDatas.AllowUserToDeleteRows = False
      Me.dgvWebDatas.AutoGenerateColumns = False
      Me.dgvWebDatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvWebDatas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IsSelectedDataGridViewCheckBoxColumn, Me.NameDataGridViewTextBoxColumn, Me.ValueDataGridViewTextBoxColumn})
      Me.dgvWebDatas.DataSource = Me.bsWebDatas
      Me.dgvWebDatas.Location = New System.Drawing.Point(15, 69)
      Me.dgvWebDatas.Name = "dgvWebDatas"
      Me.dgvWebDatas.RowHeadersWidth = 25
      Me.dgvWebDatas.Size = New System.Drawing.Size(611, 328)
      Me.dgvWebDatas.TabIndex = 12
      '
      'IsSelectedDataGridViewCheckBoxColumn
      '
      Me.IsSelectedDataGridViewCheckBoxColumn.DataPropertyName = "IsSelected"
      Me.IsSelectedDataGridViewCheckBoxColumn.HeaderText = "Select"
      Me.IsSelectedDataGridViewCheckBoxColumn.Name = "IsSelectedDataGridViewCheckBoxColumn"
      Me.IsSelectedDataGridViewCheckBoxColumn.Width = 75
      '
      'NameDataGridViewTextBoxColumn
      '
      Me.NameDataGridViewTextBoxColumn.DataPropertyName = "Name"
      Me.NameDataGridViewTextBoxColumn.HeaderText = "Name"
      Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
      Me.NameDataGridViewTextBoxColumn.ReadOnly = True
      Me.NameDataGridViewTextBoxColumn.Width = 200
      '
      'ValueDataGridViewTextBoxColumn
      '
      Me.ValueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.ValueDataGridViewTextBoxColumn.DataPropertyName = "Value"
      Me.ValueDataGridViewTextBoxColumn.HeaderText = "Value"
      Me.ValueDataGridViewTextBoxColumn.Name = "ValueDataGridViewTextBoxColumn"
      Me.ValueDataGridViewTextBoxColumn.ReadOnly = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 50)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(189, 13)
      Me.Label2.TabIndex = 13
      Me.Label2.Text = "Select the columns you want to import:"
      '
      'frmSetupWebData
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(638, 440)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.dgvWebDatas)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.txtURL)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSetupWebData"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Web Data"
      CType(Me.bsWebDatas, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvWebDatas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtURL As System.Windows.Forms.TextBox
   Friend WithEvents bsWebDatas As System.Windows.Forms.BindingSource
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents dgvWebDatas As System.Windows.Forms.DataGridView
   Friend WithEvents IndentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IsSelectedDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
