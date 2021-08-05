<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLayerRules
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.bsRules = New System.Windows.Forms.BindingSource(Me.components)
        Me.rbEnds = New System.Windows.Forms.RadioButton()
        Me.rbContains = New System.Windows.Forms.RadioButton()
        Me.rbStarts = New System.Windows.Forms.RadioButton()
        Me.rbNone = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudLayer = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNamePart = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbRules = New System.Windows.Forms.ListBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.ttTools = New System.Windows.Forms.ToolTip(Me.components)
        Me.lnklblSetDefault = New System.Windows.Forms.LinkLabel()
        Me.TabControl1.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.bsRules, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudLayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpGeneral)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(447, 284)
        Me.TabControl1.TabIndex = 0
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.GroupBox2)
        Me.tpGeneral.Controls.Add(Me.GroupBox1)
        Me.tpGeneral.Controls.Add(Me.Label1)
        Me.tpGeneral.Controls.Add(Me.lbRules)
        Me.tpGeneral.Controls.Add(Me.btnRemove)
        Me.tpGeneral.Controls.Add(Me.btnAdd)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGeneral.Size = New System.Drawing.Size(439, 258)
        Me.tpGeneral.TabIndex = 0
        Me.tpGeneral.Text = "General"
        Me.tpGeneral.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblMode)
        Me.GroupBox2.Controls.Add(Me.rbEnds)
        Me.GroupBox2.Controls.Add(Me.rbContains)
        Me.GroupBox2.Controls.Add(Me.rbStarts)
        Me.GroupBox2.Controls.Add(Me.rbNone)
        Me.GroupBox2.Location = New System.Drawing.Point(118, 171)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(315, 81)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Matching-Mode:"
        '
        'lblMode
        '
        Me.lblMode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsRules, "RulesMode", True))
        Me.lblMode.Location = New System.Drawing.Point(6, 62)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(100, 16)
        Me.lblMode.TabIndex = 4
        Me.lblMode.Text = "0"
        '
        'bsRules
        '
        Me.bsRules.DataSource = GetType(CasparCGAddIn.LayerRule)
        '
        'rbEnds
        '
        Me.rbEnds.AutoSize = True
        Me.rbEnds.Location = New System.Drawing.Point(233, 32)
        Me.rbEnds.Name = "rbEnds"
        Me.rbEnds.Size = New System.Drawing.Size(71, 17)
        Me.rbEnds.TabIndex = 3
        Me.rbEnds.TabStop = True
        Me.rbEnds.Text = "Ends with"
        Me.ttTools.SetToolTip(Me.rbEnds, "The name must end with the Name-Part  to get a match.")
        Me.rbEnds.UseVisualStyleBackColor = True
        '
        'rbContains
        '
        Me.rbContains.AutoSize = True
        Me.rbContains.Location = New System.Drawing.Point(161, 32)
        Me.rbContains.Name = "rbContains"
        Me.rbContains.Size = New System.Drawing.Size(66, 17)
        Me.rbContains.TabIndex = 2
        Me.rbContains.TabStop = True
        Me.rbContains.Text = "Contains"
        Me.ttTools.SetToolTip(Me.rbContains, "The name must contain the Name-Part  to get a match.")
        Me.rbContains.UseVisualStyleBackColor = True
        '
        'rbStarts
        '
        Me.rbStarts.AutoSize = True
        Me.rbStarts.Location = New System.Drawing.Point(81, 32)
        Me.rbStarts.Name = "rbStarts"
        Me.rbStarts.Size = New System.Drawing.Size(74, 17)
        Me.rbStarts.TabIndex = 1
        Me.rbStarts.TabStop = True
        Me.rbStarts.Text = "Starts with"
        Me.ttTools.SetToolTip(Me.rbStarts, "The name must start with the Name-Part  to get a match.")
        Me.rbStarts.UseVisualStyleBackColor = True
        '
        'rbNone
        '
        Me.rbNone.AutoSize = True
        Me.rbNone.Location = New System.Drawing.Point(9, 32)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(66, 17)
        Me.rbNone.TabIndex = 0
        Me.rbNone.TabStop = True
        Me.rbNone.Text = "Disabled"
        Me.ttTools.SetToolTip(Me.rbNone, "The rule is disabled.")
        Me.rbNone.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudLayer)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNamePart)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(118, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 104)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Properties"
        '
        'nudLayer
        '
        Me.nudLayer.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.bsRules, "Layer", True))
        Me.nudLayer.Location = New System.Drawing.Point(9, 73)
        Me.nudLayer.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudLayer.Name = "nudLayer"
        Me.nudLayer.Size = New System.Drawing.Size(300, 20)
        Me.nudLayer.TabIndex = 27
        Me.ttTools.SetToolTip(Me.nudLayer, "If a match is found this layer is assigned.")
        Me.nudLayer.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Layer:"
        '
        'txtNamePart
        '
        Me.txtNamePart.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsRules, "NamePart", True))
        Me.txtNamePart.Location = New System.Drawing.Point(9, 34)
        Me.txtNamePart.Name = "txtNamePart"
        Me.txtNamePart.Size = New System.Drawing.Size(300, 20)
        Me.txtNamePart.TabIndex = 1
        Me.ttTools.SetToolTip(Me.txtNamePart, "Text that is searched in the name to get a match")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name-part:"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(118, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(315, 46)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Layer Rules apply only to templates. Based on matching parts of the templates nam" &
    "e, a layer will be assigned."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbRules
        '
        Me.lbRules.DataSource = Me.bsRules
        Me.lbRules.DisplayMember = "NamePart"
        Me.lbRules.FormattingEnabled = True
        Me.lbRules.Location = New System.Drawing.Point(6, 8)
        Me.lbRules.Name = "lbRules"
        Me.lbRules.Size = New System.Drawing.Size(106, 212)
        Me.lbRules.TabIndex = 38
        Me.lbRules.ValueMember = "NamePart"
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Minus
        Me.btnRemove.Location = New System.Drawing.Point(62, 227)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(50, 25)
        Me.btnRemove.TabIndex = 37
        Me.btnRemove.Tag = "[ignore]"
        Me.ttTools.SetToolTip(Me.btnRemove, "Delete the current rule")
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Plus
        Me.btnAdd.Location = New System.Drawing.Point(6, 227)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 25)
        Me.btnAdd.TabIndex = 36
        Me.btnAdd.Tag = "[ignore]"
        Me.ttTools.SetToolTip(Me.btnAdd, "Add a new rule")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnFinish
        '
        Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFinish.Location = New System.Drawing.Point(380, 302)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(75, 25)
        Me.btnFinish.TabIndex = 38
        Me.btnFinish.Text = "Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'lnklblSetDefault
        '
        Me.lnklblSetDefault.AutoSize = True
        Me.lnklblSetDefault.Location = New System.Drawing.Point(9, 308)
        Me.lnklblSetDefault.Name = "lnklblSetDefault"
        Me.lnklblSetDefault.Size = New System.Drawing.Size(74, 13)
        Me.lnklblSetDefault.TabIndex = 39
        Me.lnklblSetDefault.TabStop = True
        Me.lnklblSetDefault.Text = "Set as Default"
        Me.ttTools.SetToolTip(Me.lnklblSetDefault, "Set the current rules as default for all new Excel files and all existing ones, t" &
        "hat do not contain any rules yet.")
        '
        'frmLayerRules
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 339)
        Me.Controls.Add(Me.lnklblSetDefault)
        Me.Controls.Add(Me.btnFinish)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLayerRules"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Layer Rules"
        Me.TabControl1.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.bsRules, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudLayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents lbRules As System.Windows.Forms.ListBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents bsRules As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNamePart As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbEnds As System.Windows.Forms.RadioButton
    Friend WithEvents rbContains As System.Windows.Forms.RadioButton
    Friend WithEvents rbStarts As System.Windows.Forms.RadioButton
    Friend WithEvents rbNone As System.Windows.Forms.RadioButton
    Friend WithEvents nudLayer As System.Windows.Forms.NumericUpDown
    Friend WithEvents ttTools As System.Windows.Forms.ToolTip
    Friend WithEvents lblMode As System.Windows.Forms.Label
    Friend WithEvents lnklblSetDefault As System.Windows.Forms.LinkLabel
End Class
