<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimerLaps
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
      Me.tabTab = New System.Windows.Forms.TabControl()
      Me.tpGeneral = New System.Windows.Forms.TabPage()
      Me.btnRemove = New System.Windows.Forms.Button()
      Me.btnAdd = New System.Windows.Forms.Button()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.txtCell = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cboWorksheet = New System.Windows.Forms.ComboBox()
      Me.cboFormat = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.lbLaps = New System.Windows.Forms.ListBox()
      Me.bsLaps = New System.Windows.Forms.BindingSource(Me.components)
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.txtPartDistance = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.chkUse = New System.Windows.Forms.CheckBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.tseTime = New CasparCGAddIn.ucTimeSpanEditor()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.btnFinish = New System.Windows.Forms.Button()
      Me.tabTab.SuspendLayout()
      Me.tpGeneral.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      CType(Me.bsLaps, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tabTab
      '
      Me.tabTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tabTab.Controls.Add(Me.tpGeneral)
      Me.tabTab.Location = New System.Drawing.Point(4, 12)
      Me.tabTab.Name = "tabTab"
      Me.tabTab.SelectedIndex = 0
      Me.tabTab.Size = New System.Drawing.Size(447, 292)
      Me.tabTab.TabIndex = 2
      '
      'tpGeneral
      '
      Me.tpGeneral.Controls.Add(Me.btnRemove)
      Me.tpGeneral.Controls.Add(Me.btnAdd)
      Me.tpGeneral.Controls.Add(Me.GroupBox3)
      Me.tpGeneral.Controls.Add(Me.lbLaps)
      Me.tpGeneral.Controls.Add(Me.GroupBox2)
      Me.tpGeneral.Controls.Add(Me.GroupBox1)
      Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
      Me.tpGeneral.Name = "tpGeneral"
      Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
      Me.tpGeneral.Size = New System.Drawing.Size(439, 266)
      Me.tpGeneral.TabIndex = 0
      Me.tpGeneral.Text = "General"
      Me.tpGeneral.UseVisualStyleBackColor = True
      '
      'btnRemove
      '
      Me.btnRemove.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Minus
      Me.btnRemove.Location = New System.Drawing.Point(62, 233)
      Me.btnRemove.Name = "btnRemove"
      Me.btnRemove.Size = New System.Drawing.Size(50, 25)
      Me.btnRemove.TabIndex = 35
      Me.btnRemove.UseVisualStyleBackColor = True
      '
      'btnAdd
      '
      Me.btnAdd.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Plus
      Me.btnAdd.Location = New System.Drawing.Point(6, 233)
      Me.btnAdd.Name = "btnAdd"
      Me.btnAdd.Size = New System.Drawing.Size(50, 25)
      Me.btnAdd.TabIndex = 34
      Me.btnAdd.UseVisualStyleBackColor = True
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.txtCell)
      Me.GroupBox3.Controls.Add(Me.Label6)
      Me.GroupBox3.Controls.Add(Me.Label2)
      Me.GroupBox3.Controls.Add(Me.cboWorksheet)
      Me.GroupBox3.Controls.Add(Me.cboFormat)
      Me.GroupBox3.Controls.Add(Me.Label4)
      Me.GroupBox3.Location = New System.Drawing.Point(118, 152)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(310, 108)
      Me.GroupBox3.TabIndex = 33
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Write lap to worksheet"
      '
      'txtCell
      '
      Me.txtCell.Location = New System.Drawing.Point(6, 77)
      Me.txtCell.Name = "txtCell"
      Me.txtCell.Size = New System.Drawing.Size(87, 20)
      Me.txtCell.TabIndex = 9
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(6, 58)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(27, 13)
      Me.Label6.TabIndex = 8
      Me.Label6.Text = "Cell:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 18)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(62, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Worksheet:"
      '
      'cboWorksheet
      '
      Me.cboWorksheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboWorksheet.FormattingEnabled = True
      Me.cboWorksheet.Location = New System.Drawing.Point(6, 36)
      Me.cboWorksheet.Name = "cboWorksheet"
      Me.cboWorksheet.Size = New System.Drawing.Size(298, 21)
      Me.cboWorksheet.TabIndex = 3
      '
      'cboFormat
      '
      Me.cboFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboFormat.FormattingEnabled = True
      Me.cboFormat.Items.AddRange(New Object() {"Minutes and Seconds (MM:SS)", "Hours, Minutes and Seconds (HH:MM:SS)", "Days, Hours, Minutes and Seconds (D HH:MM:SS)", "Days, Hours and Minutes (D HH:MM)"})
      Me.cboFormat.Location = New System.Drawing.Point(99, 76)
      Me.cboFormat.Name = "cboFormat"
      Me.cboFormat.Size = New System.Drawing.Size(205, 21)
      Me.cboFormat.TabIndex = 2
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(99, 58)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(76, 13)
      Me.Label4.TabIndex = 1
      Me.Label4.Text = "Display format:"
      '
      'lbLaps
      '
      Me.lbLaps.DataSource = Me.bsLaps
      Me.lbLaps.DisplayMember = "Name"
      Me.lbLaps.FormattingEnabled = True
      Me.lbLaps.Location = New System.Drawing.Point(6, 12)
      Me.lbLaps.Name = "lbLaps"
      Me.lbLaps.Size = New System.Drawing.Size(106, 212)
      Me.lbLaps.TabIndex = 32
      '
      'bsLaps
      '
      Me.bsLaps.DataMember = "Laps"
      Me.bsLaps.DataSource = GetType(CasparCGAddIn.TimerItem)
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.txtPartDistance)
      Me.GroupBox2.Controls.Add(Me.Label3)
      Me.GroupBox2.Controls.Add(Me.chkUse)
      Me.GroupBox2.Location = New System.Drawing.Point(118, 80)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(310, 64)
      Me.GroupBox2.TabIndex = 31
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Distance-Simulation"
      '
      'txtPartDistance
      '
      Me.txtPartDistance.Location = New System.Drawing.Point(6, 34)
      Me.txtPartDistance.Name = "txtPartDistance"
      Me.txtPartDistance.Size = New System.Drawing.Size(298, 20)
      Me.txtPartDistance.TabIndex = 5
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(6, 18)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(185, 13)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Part of the distance, (meters or yards):"
      '
      'chkUse
      '
      Me.chkUse.AutoSize = True
      Me.chkUse.Location = New System.Drawing.Point(217, 17)
      Me.chkUse.Name = "chkUse"
      Me.chkUse.Size = New System.Drawing.Size(59, 17)
      Me.chkUse.TabIndex = 3
      Me.chkUse.Text = "Enable"
      Me.chkUse.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.tseTime)
      Me.GroupBox1.Controls.Add(Me.txtName)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.Label5)
      Me.GroupBox1.Location = New System.Drawing.Point(118, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(310, 64)
      Me.GroupBox1.TabIndex = 30
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Settings"
      '
      'tseTime
      '
      Me.tseTime.Location = New System.Drawing.Point(99, 34)
      Me.tseTime.MaximumSize = New System.Drawing.Size(1920, 20)
      Me.tseTime.MinimumSize = New System.Drawing.Size(200, 20)
      Me.tseTime.Name = "tseTime"
      Me.tseTime.Size = New System.Drawing.Size(203, 20)
      Me.tseTime.TabIndex = 10
      Me.tseTime.Value = System.TimeSpan.Parse("00:00:00")
      '
      'txtName
      '
      Me.txtName.Location = New System.Drawing.Point(6, 34)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(87, 20)
      Me.txtName.TabIndex = 9
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 18)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 8
      Me.Label1.Text = "Name:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(96, 18)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(33, 13)
      Me.Label5.TabIndex = 6
      Me.Label5.Text = "Time:"
      '
      'btnFinish
      '
      Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnFinish.Location = New System.Drawing.Point(372, 310)
      Me.btnFinish.Name = "btnFinish"
      Me.btnFinish.Size = New System.Drawing.Size(75, 25)
      Me.btnFinish.TabIndex = 35
      Me.btnFinish.Text = "Finish"
      Me.btnFinish.UseVisualStyleBackColor = True
      '
      'frmTimerLaps
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(455, 342)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnFinish)
      Me.Controls.Add(Me.tabTab)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmTimerLaps"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Laps"
      Me.tabTab.ResumeLayout(False)
      Me.tpGeneral.ResumeLayout(False)
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      CType(Me.bsLaps, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents tabTab As System.Windows.Forms.TabControl
   Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtPartDistance As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chkUse As System.Windows.Forms.CheckBox
   Friend WithEvents cboFormat As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents btnFinish As System.Windows.Forms.Button
   Friend WithEvents bsLaps As System.Windows.Forms.BindingSource
   Friend WithEvents lbLaps As System.Windows.Forms.ListBox
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents txtName As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents btnRemove As System.Windows.Forms.Button
   Friend WithEvents btnAdd As System.Windows.Forms.Button
   Friend WithEvents txtCell As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboWorksheet As System.Windows.Forms.ComboBox
   Friend WithEvents tseTime As ucTimeSpanEditor
End Class
