<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTimerSettings
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
      Me.components = New System.ComponentModel.Container()
      Me.tabTab = New System.Windows.Forms.TabControl()
      Me.tpGeneral = New System.Windows.Forms.TabPage()
      Me.btnDublicate = New System.Windows.Forms.Button()
      Me.btnRemove = New System.Windows.Forms.Button()
      Me.btnAdd = New System.Windows.Forms.Button()
      Me.lbItems = New System.Windows.Forms.ListBox()
      Me.bsItems = New System.Windows.Forms.BindingSource(Me.components)
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.tsePartTime = New CasparCGAddIn.ucTimeSpanEditor()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtPartDistance = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtFullDistance = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.chkUseLaps = New System.Windows.Forms.CheckBox()
      Me.cboType = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.chkCanPause = New System.Windows.Forms.CheckBox()
      Me.btnFinish = New System.Windows.Forms.Button()
      Me.ttTips = New System.Windows.Forms.ToolTip(Me.components)
      Me.tabTab.SuspendLayout()
      Me.tpGeneral.SuspendLayout()
      CType(Me.bsItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.tabTab.TabIndex = 1
      '
      'tpGeneral
      '
      Me.tpGeneral.Controls.Add(Me.btnDublicate)
      Me.tpGeneral.Controls.Add(Me.btnRemove)
      Me.tpGeneral.Controls.Add(Me.btnAdd)
      Me.tpGeneral.Controls.Add(Me.lbItems)
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
      'btnDublicate
      '
      Me.btnDublicate.Image = Global.CasparCGAddIn.My.Resources.Resources.Dublicate
      Me.btnDublicate.Location = New System.Drawing.Point(43, 233)
      Me.btnDublicate.Name = "btnDublicate"
      Me.btnDublicate.Size = New System.Drawing.Size(31, 25)
      Me.btnDublicate.TabIndex = 39
      Me.ttTips.SetToolTip(Me.btnDublicate, "Dublicate the current item")
      Me.btnDublicate.UseVisualStyleBackColor = True
      '
      'btnRemove
      '
      Me.btnRemove.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Minus
      Me.btnRemove.Location = New System.Drawing.Point(80, 233)
      Me.btnRemove.Name = "btnRemove"
      Me.btnRemove.Size = New System.Drawing.Size(31, 25)
      Me.btnRemove.TabIndex = 38
      Me.ttTips.SetToolTip(Me.btnRemove, "Delete the current item")
      Me.btnRemove.UseVisualStyleBackColor = True
      '
      'btnAdd
      '
      Me.btnAdd.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Plus
      Me.btnAdd.Location = New System.Drawing.Point(6, 233)
      Me.btnAdd.Name = "btnAdd"
      Me.btnAdd.Size = New System.Drawing.Size(31, 25)
      Me.btnAdd.TabIndex = 37
      Me.ttTips.SetToolTip(Me.btnAdd, "Add a new item")
      Me.btnAdd.UseVisualStyleBackColor = True
      '
      'lbItems
      '
      Me.lbItems.DataSource = Me.bsItems
      Me.lbItems.DisplayMember = "Name"
      Me.lbItems.FormattingEnabled = True
      Me.lbItems.Location = New System.Drawing.Point(6, 12)
      Me.lbItems.Name = "lbItems"
      Me.lbItems.Size = New System.Drawing.Size(106, 212)
      Me.lbItems.TabIndex = 36
      Me.ttTips.SetToolTip(Me.lbItems, "Select the current item")
      '
      'bsItems
      '
      Me.bsItems.DataMember = "Items"
      Me.bsItems.DataSource = GetType(CasparCGAddIn.TimerSettings)
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.tsePartTime)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.txtPartDistance)
      Me.GroupBox2.Controls.Add(Me.Label3)
      Me.GroupBox2.Controls.Add(Me.txtFullDistance)
      Me.GroupBox2.Controls.Add(Me.Label1)
      Me.GroupBox2.Location = New System.Drawing.Point(118, 107)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(310, 151)
      Me.GroupBox2.TabIndex = 31
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Distance-Simulation"
      '
      'tsePartTime
      '
      Me.tsePartTime.Location = New System.Drawing.Point(6, 120)
      Me.tsePartTime.MaximumSize = New System.Drawing.Size(1920, 20)
      Me.tsePartTime.MinimumSize = New System.Drawing.Size(160, 20)
      Me.tsePartTime.Name = "tsePartTime"
      Me.tsePartTime.Size = New System.Drawing.Size(298, 20)
      Me.tsePartTime.TabIndex = 7
      Me.ttTips.SetToolTip(Me.tsePartTime, "Optional: Give a time for the time it takes to make the part of the distance.")
      Me.tsePartTime.Value = System.TimeSpan.Parse("00:00:00")
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(3, 104)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(33, 13)
      Me.Label5.TabIndex = 6
      Me.Label5.Text = "Time:"
      '
      'txtPartDistance
      '
      Me.txtPartDistance.Location = New System.Drawing.Point(6, 82)
      Me.txtPartDistance.Name = "txtPartDistance"
      Me.txtPartDistance.Size = New System.Drawing.Size(298, 20)
      Me.txtPartDistance.TabIndex = 5
      Me.ttTips.SetToolTip(Me.txtPartDistance, "in the metric system use meters, in imperial system use yards.")
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(6, 66)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(185, 13)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Part of the distance, (meters or yards):"
      '
      'txtFullDistance
      '
      Me.txtFullDistance.Location = New System.Drawing.Point(6, 39)
      Me.txtFullDistance.Name = "txtFullDistance"
      Me.txtFullDistance.Size = New System.Drawing.Size(298, 20)
      Me.txtFullDistance.TabIndex = 1
      Me.ttTips.SetToolTip(Me.txtFullDistance, "in the metric system use meters, in imperial system use yards.")
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 23)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(164, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Whole distance (meters or yards):"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.txtName)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.chkUseLaps)
      Me.GroupBox1.Controls.Add(Me.cboType)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.chkCanPause)
      Me.GroupBox1.Location = New System.Drawing.Point(118, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(310, 87)
      Me.GroupBox1.TabIndex = 30
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Settings"
      '
      'txtName
      '
      Me.txtName.Location = New System.Drawing.Point(6, 36)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(146, 20)
      Me.txtName.TabIndex = 5
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 18)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Name:"
      '
      'chkUseLaps
      '
      Me.chkUseLaps.AutoSize = True
      Me.chkUseLaps.Location = New System.Drawing.Point(6, 63)
      Me.chkUseLaps.Name = "chkUseLaps"
      Me.chkUseLaps.Size = New System.Drawing.Size(119, 17)
      Me.chkUseLaps.TabIndex = 3
      Me.chkUseLaps.Text = "Timer can use Laps"
      Me.chkUseLaps.UseVisualStyleBackColor = True
      '
      'cboType
      '
      Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboType.FormattingEnabled = True
      Me.cboType.Items.AddRange(New Object() {"Minutes and Seconds (MM:SS)", "Hours, Minutes and Seconds (HH:MM:SS)", "Days, Hours, Minutes and Seconds (D HH:MM:SS)", "Days, Hours and Minutes (D HH:MM)"})
      Me.cboType.Location = New System.Drawing.Point(158, 36)
      Me.cboType.Name = "cboType"
      Me.cboType.Size = New System.Drawing.Size(146, 21)
      Me.cboType.TabIndex = 2
      Me.ttTips.SetToolTip(Me.cboType, "Select the format of the timer preview")
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(158, 18)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(80, 13)
      Me.Label4.TabIndex = 1
      Me.Label4.Text = "Preview format:"
      '
      'chkCanPause
      '
      Me.chkCanPause.AutoSize = True
      Me.chkCanPause.Location = New System.Drawing.Point(134, 63)
      Me.chkCanPause.Name = "chkCanPause"
      Me.chkCanPause.Size = New System.Drawing.Size(126, 17)
      Me.chkCanPause.TabIndex = 0
      Me.chkCanPause.Text = "Timer can be paused"
      Me.chkCanPause.UseVisualStyleBackColor = True
      '
      'btnFinish
      '
      Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnFinish.Location = New System.Drawing.Point(372, 310)
      Me.btnFinish.Name = "btnFinish"
      Me.btnFinish.Size = New System.Drawing.Size(75, 25)
      Me.btnFinish.TabIndex = 36
      Me.btnFinish.Text = "Finish"
      Me.btnFinish.UseVisualStyleBackColor = True
      '
      'frmTimerSettings
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
      Me.Name = "frmTimerSettings"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Timer Settings"
      Me.tabTab.ResumeLayout(False)
      Me.tpGeneral.ResumeLayout(False)
      CType(Me.bsItems, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents tabTab As System.Windows.Forms.TabControl
   Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
   Friend WithEvents SheetDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CellDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FormatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents cboType As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents chkCanPause As System.Windows.Forms.CheckBox
   Friend WithEvents chkUseLaps As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents txtPartDistance As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtFullDistance As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tsePartTime As ucTimeSpanEditor
   Friend WithEvents btnRemove As System.Windows.Forms.Button
   Friend WithEvents btnAdd As System.Windows.Forms.Button
   Friend WithEvents lbItems As System.Windows.Forms.ListBox
   Friend WithEvents btnFinish As System.Windows.Forms.Button
   Friend WithEvents bsItems As System.Windows.Forms.BindingSource
   Friend WithEvents btnDublicate As System.Windows.Forms.Button
   Friend WithEvents ttTips As System.Windows.Forms.ToolTip
   Friend WithEvents txtName As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
