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
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.cboOnTimeTrigger = New System.Windows.Forms.ComboBox()
      Me.cboOnTimeTimer = New System.Windows.Forms.ComboBox()
      Me.tseOnTimeTime = New CasparCGAddIn.ucTimeSpanEditor()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cboOnResumeTrigger = New System.Windows.Forms.ComboBox()
      Me.cboOnResumeTimer = New System.Windows.Forms.ComboBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.cboOnLapTrigger = New System.Windows.Forms.ComboBox()
      Me.cboOnLapTimer = New System.Windows.Forms.ComboBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cboOnUnPauseTrigger = New System.Windows.Forms.ComboBox()
      Me.cboOnUnPauseTimer = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.cboOnPauseTrigger = New System.Windows.Forms.ComboBox()
      Me.cboOnPauseTimer = New System.Windows.Forms.ComboBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.cboOnStopTrigger = New System.Windows.Forms.ComboBox()
      Me.cboOnStopTimer = New System.Windows.Forms.ComboBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cboOnStartTrigger = New System.Windows.Forms.ComboBox()
      Me.cboOnStartTimer = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
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
      Me.tseOffset = New CasparCGAddIn.ucTimeSpanEditor()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.chkInhibitQuery = New System.Windows.Forms.CheckBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.chkUseLaps = New System.Windows.Forms.CheckBox()
      Me.cboType = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.chkCanPause = New System.Windows.Forms.CheckBox()
      Me.ttTips = New System.Windows.Forms.ToolTip(Me.components)
      Me.btnFinish = New System.Windows.Forms.Button()
      Me.tabTab.SuspendLayout()
      Me.tpGeneral.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
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
      Me.tabTab.Location = New System.Drawing.Point(12, 12)
      Me.tabTab.Name = "tabTab"
      Me.tabTab.SelectedIndex = 0
      Me.tabTab.Size = New System.Drawing.Size(559, 562)
      Me.tabTab.TabIndex = 1
      '
      'tpGeneral
      '
      Me.tpGeneral.Controls.Add(Me.GroupBox3)
      Me.tpGeneral.Controls.Add(Me.btnDublicate)
      Me.tpGeneral.Controls.Add(Me.btnRemove)
      Me.tpGeneral.Controls.Add(Me.btnAdd)
      Me.tpGeneral.Controls.Add(Me.lbItems)
      Me.tpGeneral.Controls.Add(Me.GroupBox2)
      Me.tpGeneral.Controls.Add(Me.GroupBox1)
      Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
      Me.tpGeneral.Name = "tpGeneral"
      Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
      Me.tpGeneral.Size = New System.Drawing.Size(551, 536)
      Me.tpGeneral.TabIndex = 0
      Me.tpGeneral.Text = "General"
      Me.tpGeneral.UseVisualStyleBackColor = True
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.cboOnTimeTrigger)
      Me.GroupBox3.Controls.Add(Me.cboOnTimeTimer)
      Me.GroupBox3.Controls.Add(Me.tseOnTimeTime)
      Me.GroupBox3.Controls.Add(Me.Label13)
      Me.GroupBox3.Controls.Add(Me.cboOnResumeTrigger)
      Me.GroupBox3.Controls.Add(Me.cboOnResumeTimer)
      Me.GroupBox3.Controls.Add(Me.Label11)
      Me.GroupBox3.Controls.Add(Me.cboOnLapTrigger)
      Me.GroupBox3.Controls.Add(Me.cboOnLapTimer)
      Me.GroupBox3.Controls.Add(Me.Label12)
      Me.GroupBox3.Controls.Add(Me.cboOnUnPauseTrigger)
      Me.GroupBox3.Controls.Add(Me.cboOnUnPauseTimer)
      Me.GroupBox3.Controls.Add(Me.Label9)
      Me.GroupBox3.Controls.Add(Me.cboOnPauseTrigger)
      Me.GroupBox3.Controls.Add(Me.cboOnPauseTimer)
      Me.GroupBox3.Controls.Add(Me.Label10)
      Me.GroupBox3.Controls.Add(Me.cboOnStopTrigger)
      Me.GroupBox3.Controls.Add(Me.cboOnStopTimer)
      Me.GroupBox3.Controls.Add(Me.Label8)
      Me.GroupBox3.Controls.Add(Me.cboOnStartTrigger)
      Me.GroupBox3.Controls.Add(Me.cboOnStartTimer)
      Me.GroupBox3.Controls.Add(Me.Label7)
      Me.GroupBox3.Location = New System.Drawing.Point(118, 151)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(424, 187)
      Me.GroupBox3.TabIndex = 40
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Triggers"
      '
      'cboOnTimeTrigger
      '
      Me.cboOnTimeTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnTimeTrigger.FormattingEnabled = True
      Me.cboOnTimeTrigger.Items.AddRange(New Object() {"Do Nothing", "Do Start", "Do Pause", "Do UnPause", "Do Lap", "Do Resume", "Do Stop"})
      Me.cboOnTimeTrigger.Location = New System.Drawing.Point(216, 157)
      Me.cboOnTimeTrigger.Name = "cboOnTimeTrigger"
      Me.cboOnTimeTrigger.Size = New System.Drawing.Size(79, 21)
      Me.cboOnTimeTrigger.TabIndex = 21
      '
      'cboOnTimeTimer
      '
      Me.cboOnTimeTimer.DisplayMember = "Name"
      Me.cboOnTimeTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnTimeTimer.FormattingEnabled = True
      Me.cboOnTimeTimer.Location = New System.Drawing.Point(299, 157)
      Me.cboOnTimeTimer.Name = "cboOnTimeTimer"
      Me.cboOnTimeTimer.Size = New System.Drawing.Size(119, 21)
      Me.cboOnTimeTimer.TabIndex = 20
      Me.cboOnTimeTimer.ValueMember = "Name"
      '
      'tseOnTimeTime
      '
      Me.tseOnTimeTime.Location = New System.Drawing.Point(6, 157)
      Me.tseOnTimeTime.MaximumSize = New System.Drawing.Size(1920, 20)
      Me.tseOnTimeTime.MinimumSize = New System.Drawing.Size(160, 20)
      Me.tseOnTimeTime.Name = "tseOnTimeTime"
      Me.tseOnTimeTime.Size = New System.Drawing.Size(202, 20)
      Me.tseOnTimeTime.TabIndex = 19
      Me.tseOnTimeTime.Value = System.TimeSpan.Parse("00:00:00")
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(5, 140)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(50, 13)
      Me.Label13.TabIndex = 18
      Me.Label13.Text = "On-Time:"
      '
      'cboOnResumeTrigger
      '
      Me.cboOnResumeTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnResumeTrigger.FormattingEnabled = True
      Me.cboOnResumeTrigger.Items.AddRange(New Object() {"Do Nothing", "Do Start", "Do Pause", "Do UnPause", "Do Lap", "Do Resume", "Do Stop"})
      Me.cboOnResumeTrigger.Location = New System.Drawing.Point(216, 115)
      Me.cboOnResumeTrigger.Name = "cboOnResumeTrigger"
      Me.cboOnResumeTrigger.Size = New System.Drawing.Size(79, 21)
      Me.cboOnResumeTrigger.TabIndex = 17
      '
      'cboOnResumeTimer
      '
      Me.cboOnResumeTimer.DisplayMember = "Name"
      Me.cboOnResumeTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnResumeTimer.FormattingEnabled = True
      Me.cboOnResumeTimer.Location = New System.Drawing.Point(299, 115)
      Me.cboOnResumeTimer.Name = "cboOnResumeTimer"
      Me.cboOnResumeTimer.Size = New System.Drawing.Size(119, 21)
      Me.cboOnResumeTimer.TabIndex = 16
      Me.cboOnResumeTimer.ValueMember = "Name"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(216, 99)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(66, 13)
      Me.Label11.TabIndex = 15
      Me.Label11.Text = "On Resume:"
      '
      'cboOnLapTrigger
      '
      Me.cboOnLapTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnLapTrigger.FormattingEnabled = True
      Me.cboOnLapTrigger.Items.AddRange(New Object() {"Do Nothing", "Do Start", "Do Pause", "Do UnPause", "Do Lap", "Do Resume", "Do Stop"})
      Me.cboOnLapTrigger.Location = New System.Drawing.Point(6, 115)
      Me.cboOnLapTrigger.Name = "cboOnLapTrigger"
      Me.cboOnLapTrigger.Size = New System.Drawing.Size(79, 21)
      Me.cboOnLapTrigger.TabIndex = 14
      '
      'cboOnLapTimer
      '
      Me.cboOnLapTimer.DisplayMember = "Name"
      Me.cboOnLapTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnLapTimer.FormattingEnabled = True
      Me.cboOnLapTimer.Location = New System.Drawing.Point(89, 115)
      Me.cboOnLapTimer.Name = "cboOnLapTimer"
      Me.cboOnLapTimer.Size = New System.Drawing.Size(119, 21)
      Me.cboOnLapTimer.TabIndex = 13
      Me.cboOnLapTimer.ValueMember = "Name"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(6, 99)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(45, 13)
      Me.Label12.TabIndex = 12
      Me.Label12.Text = "On Lap:"
      '
      'cboOnUnPauseTrigger
      '
      Me.cboOnUnPauseTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnUnPauseTrigger.FormattingEnabled = True
      Me.cboOnUnPauseTrigger.Items.AddRange(New Object() {"Do Nothing", "Do Start", "Do Pause", "Do UnPause", "Do Lap", "Do Resume", "Do Stop"})
      Me.cboOnUnPauseTrigger.Location = New System.Drawing.Point(216, 74)
      Me.cboOnUnPauseTrigger.Name = "cboOnUnPauseTrigger"
      Me.cboOnUnPauseTrigger.Size = New System.Drawing.Size(79, 21)
      Me.cboOnUnPauseTrigger.TabIndex = 11
      '
      'cboOnUnPauseTimer
      '
      Me.cboOnUnPauseTimer.DisplayMember = "Name"
      Me.cboOnUnPauseTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnUnPauseTimer.FormattingEnabled = True
      Me.cboOnUnPauseTimer.Location = New System.Drawing.Point(299, 74)
      Me.cboOnUnPauseTimer.Name = "cboOnUnPauseTimer"
      Me.cboOnUnPauseTimer.Size = New System.Drawing.Size(119, 21)
      Me.cboOnUnPauseTimer.TabIndex = 10
      Me.cboOnUnPauseTimer.ValueMember = "Name"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(216, 58)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(74, 13)
      Me.Label9.TabIndex = 9
      Me.Label9.Text = "On Un-Pause:"
      '
      'cboOnPauseTrigger
      '
      Me.cboOnPauseTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnPauseTrigger.FormattingEnabled = True
      Me.cboOnPauseTrigger.Items.AddRange(New Object() {"Do Nothing", "Do Start", "Do Pause", "Do UnPause", "Do Lap", "Do Resume", "Do Stop"})
      Me.cboOnPauseTrigger.Location = New System.Drawing.Point(6, 74)
      Me.cboOnPauseTrigger.Name = "cboOnPauseTrigger"
      Me.cboOnPauseTrigger.Size = New System.Drawing.Size(79, 21)
      Me.cboOnPauseTrigger.TabIndex = 8
      '
      'cboOnPauseTimer
      '
      Me.cboOnPauseTimer.DisplayMember = "Name"
      Me.cboOnPauseTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnPauseTimer.FormattingEnabled = True
      Me.cboOnPauseTimer.Location = New System.Drawing.Point(89, 74)
      Me.cboOnPauseTimer.Name = "cboOnPauseTimer"
      Me.cboOnPauseTimer.Size = New System.Drawing.Size(119, 21)
      Me.cboOnPauseTimer.TabIndex = 7
      Me.cboOnPauseTimer.ValueMember = "Name"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(6, 58)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(57, 13)
      Me.Label10.TabIndex = 6
      Me.Label10.Text = "On Pause:"
      '
      'cboOnStopTrigger
      '
      Me.cboOnStopTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnStopTrigger.FormattingEnabled = True
      Me.cboOnStopTrigger.Items.AddRange(New Object() {"Do Nothing", "Do Start", "Do Pause", "Do UnPause", "Do Lap", "Do Resume", "Do Stop"})
      Me.cboOnStopTrigger.Location = New System.Drawing.Point(216, 33)
      Me.cboOnStopTrigger.Name = "cboOnStopTrigger"
      Me.cboOnStopTrigger.Size = New System.Drawing.Size(79, 21)
      Me.cboOnStopTrigger.TabIndex = 5
      '
      'cboOnStopTimer
      '
      Me.cboOnStopTimer.DisplayMember = "Name"
      Me.cboOnStopTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnStopTimer.FormattingEnabled = True
      Me.cboOnStopTimer.Location = New System.Drawing.Point(299, 33)
      Me.cboOnStopTimer.Name = "cboOnStopTimer"
      Me.cboOnStopTimer.Size = New System.Drawing.Size(119, 21)
      Me.cboOnStopTimer.TabIndex = 4
      Me.cboOnStopTimer.ValueMember = "Name"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(216, 17)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(49, 13)
      Me.Label8.TabIndex = 3
      Me.Label8.Text = "On Stop:"
      '
      'cboOnStartTrigger
      '
      Me.cboOnStartTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnStartTrigger.FormattingEnabled = True
      Me.cboOnStartTrigger.Items.AddRange(New Object() {"Do Nothing", "Do Start", "Do Pause", "Do UnPause", "Do Lap", "Do Resume", "Do Stop"})
      Me.cboOnStartTrigger.Location = New System.Drawing.Point(6, 33)
      Me.cboOnStartTrigger.Name = "cboOnStartTrigger"
      Me.cboOnStartTrigger.Size = New System.Drawing.Size(79, 21)
      Me.cboOnStartTrigger.TabIndex = 2
      '
      'cboOnStartTimer
      '
      Me.cboOnStartTimer.DisplayMember = "Name"
      Me.cboOnStartTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboOnStartTimer.FormattingEnabled = True
      Me.cboOnStartTimer.Location = New System.Drawing.Point(89, 33)
      Me.cboOnStartTimer.Name = "cboOnStartTimer"
      Me.cboOnStartTimer.Size = New System.Drawing.Size(119, 21)
      Me.cboOnStartTimer.TabIndex = 1
      Me.cboOnStartTimer.ValueMember = "Name"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(6, 17)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(49, 13)
      Me.Label7.TabIndex = 0
      Me.Label7.Text = "On Start:"
      '
      'btnDublicate
      '
      Me.btnDublicate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnDublicate.Image = Global.CasparCGAddIn.My.Resources.Resources.Dublicate
      Me.btnDublicate.Location = New System.Drawing.Point(43, 503)
      Me.btnDublicate.Name = "btnDublicate"
      Me.btnDublicate.Size = New System.Drawing.Size(31, 25)
      Me.btnDublicate.TabIndex = 39
      Me.btnDublicate.Tag = "[ignore]"
      Me.ttTips.SetToolTip(Me.btnDublicate, "Dublicate the current item")
      Me.btnDublicate.UseVisualStyleBackColor = True
      '
      'btnRemove
      '
      Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnRemove.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Minus
      Me.btnRemove.Location = New System.Drawing.Point(80, 503)
      Me.btnRemove.Name = "btnRemove"
      Me.btnRemove.Size = New System.Drawing.Size(31, 25)
      Me.btnRemove.TabIndex = 38
      Me.btnRemove.Tag = "[ignore]"
      Me.ttTips.SetToolTip(Me.btnRemove, "Delete the current item")
      Me.btnRemove.UseVisualStyleBackColor = True
      '
      'btnAdd
      '
      Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnAdd.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Plus
      Me.btnAdd.Location = New System.Drawing.Point(6, 503)
      Me.btnAdd.Name = "btnAdd"
      Me.btnAdd.Size = New System.Drawing.Size(31, 25)
      Me.btnAdd.TabIndex = 37
      Me.btnAdd.Tag = "[ignore]"
      Me.ttTips.SetToolTip(Me.btnAdd, "Add a new item")
      Me.btnAdd.UseVisualStyleBackColor = True
      '
      'lbItems
      '
      Me.lbItems.DataSource = Me.bsItems
      Me.lbItems.DisplayMember = "Name"
      Me.lbItems.FormattingEnabled = True
      Me.lbItems.Location = New System.Drawing.Point(9, 10)
      Me.lbItems.Name = "lbItems"
      Me.lbItems.Size = New System.Drawing.Size(106, 485)
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
      Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox2.Controls.Add(Me.tsePartTime)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.txtPartDistance)
      Me.GroupBox2.Controls.Add(Me.Label3)
      Me.GroupBox2.Controls.Add(Me.txtFullDistance)
      Me.GroupBox2.Controls.Add(Me.Label1)
      Me.GroupBox2.Location = New System.Drawing.Point(118, 343)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(425, 151)
      Me.GroupBox2.TabIndex = 31
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Distance-Simulation"
      '
      'tsePartTime
      '
      Me.tsePartTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tsePartTime.Location = New System.Drawing.Point(6, 120)
      Me.tsePartTime.MaximumSize = New System.Drawing.Size(1920, 20)
      Me.tsePartTime.MinimumSize = New System.Drawing.Size(160, 20)
      Me.tsePartTime.Name = "tsePartTime"
      Me.tsePartTime.Size = New System.Drawing.Size(413, 20)
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
      Me.txtPartDistance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPartDistance.Location = New System.Drawing.Point(6, 82)
      Me.txtPartDistance.Name = "txtPartDistance"
      Me.txtPartDistance.Size = New System.Drawing.Size(413, 20)
      Me.txtPartDistance.TabIndex = 5
      Me.ttTips.SetToolTip(Me.txtPartDistance, "In the metric system use meters, in imperial system use yards.")
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
      Me.txtFullDistance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtFullDistance.Location = New System.Drawing.Point(6, 39)
      Me.txtFullDistance.Name = "txtFullDistance"
      Me.txtFullDistance.Size = New System.Drawing.Size(413, 20)
      Me.txtFullDistance.TabIndex = 1
      Me.ttTips.SetToolTip(Me.txtFullDistance, "In the metric system use meters, in imperial system use yards.")
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
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.tseOffset)
      Me.GroupBox1.Controls.Add(Me.Label6)
      Me.GroupBox1.Controls.Add(Me.chkInhibitQuery)
      Me.GroupBox1.Controls.Add(Me.txtName)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.chkUseLaps)
      Me.GroupBox1.Controls.Add(Me.cboType)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.chkCanPause)
      Me.GroupBox1.Location = New System.Drawing.Point(118, 12)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(425, 134)
      Me.GroupBox1.TabIndex = 30
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Settings"
      '
      'tseOffset
      '
      Me.tseOffset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tseOffset.Location = New System.Drawing.Point(6, 103)
      Me.tseOffset.MaximumSize = New System.Drawing.Size(1920, 20)
      Me.tseOffset.MinimumSize = New System.Drawing.Size(160, 20)
      Me.tseOffset.Name = "tseOffset"
      Me.tseOffset.Size = New System.Drawing.Size(413, 20)
      Me.tseOffset.TabIndex = 8
      Me.ttTips.SetToolTip(Me.tseOffset, "Set this to start the timer from a given time, not from zero.")
      Me.tseOffset.Value = System.TimeSpan.Parse("00:00:00")
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(5, 87)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(92, 13)
      Me.Label6.TabIndex = 7
      Me.Label6.Text = "Start from (Offset):"
      '
      'chkInhibitQuery
      '
      Me.chkInhibitQuery.AutoSize = True
      Me.chkInhibitQuery.Location = New System.Drawing.Point(273, 62)
      Me.chkInhibitQuery.Name = "chkInhibitQuery"
      Me.chkInhibitQuery.Size = New System.Drawing.Size(121, 17)
      Me.chkInhibitQuery.TabIndex = 6
      Me.chkInhibitQuery.Text = "Inhibit query on stop"
      Me.chkInhibitQuery.UseVisualStyleBackColor = True
      '
      'txtName
      '
      Me.txtName.Location = New System.Drawing.Point(6, 36)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(261, 20)
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
      Me.cboType.Location = New System.Drawing.Point(273, 35)
      Me.cboType.Name = "cboType"
      Me.cboType.Size = New System.Drawing.Size(146, 21)
      Me.cboType.TabIndex = 2
      Me.ttTips.SetToolTip(Me.cboType, "Select the format of the timer preview")
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(273, 17)
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
      Me.btnFinish.Location = New System.Drawing.Point(492, 580)
      Me.btnFinish.Name = "btnFinish"
      Me.btnFinish.Size = New System.Drawing.Size(75, 25)
      Me.btnFinish.TabIndex = 37
      Me.btnFinish.Text = "Finish"
      Me.btnFinish.UseVisualStyleBackColor = True
      '
      'frmTimerSettings
      '
      Me.AcceptButton = Me.btnFinish
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(579, 612)
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
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
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
   Friend WithEvents bsItems As System.Windows.Forms.BindingSource
   Friend WithEvents btnDublicate As System.Windows.Forms.Button
   Friend WithEvents ttTips As System.Windows.Forms.ToolTip
   Friend WithEvents txtName As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents btnFinish As System.Windows.Forms.Button
   Friend WithEvents chkInhibitQuery As System.Windows.Forms.CheckBox
   Friend WithEvents tseOffset As ucTimeSpanEditor
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cboOnStartTrigger As System.Windows.Forms.ComboBox
   Friend WithEvents cboOnStartTimer As System.Windows.Forms.ComboBox
   Friend WithEvents cboOnStopTrigger As System.Windows.Forms.ComboBox
   Friend WithEvents cboOnStopTimer As System.Windows.Forms.ComboBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cboOnResumeTrigger As System.Windows.Forms.ComboBox
   Friend WithEvents cboOnResumeTimer As System.Windows.Forms.ComboBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cboOnLapTrigger As System.Windows.Forms.ComboBox
   Friend WithEvents cboOnLapTimer As System.Windows.Forms.ComboBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents cboOnUnPauseTrigger As System.Windows.Forms.ComboBox
   Friend WithEvents cboOnUnPauseTimer As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents cboOnPauseTrigger As System.Windows.Forms.ComboBox
   Friend WithEvents cboOnPauseTimer As System.Windows.Forms.ComboBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents cboOnTimeTrigger As System.Windows.Forms.ComboBox
   Friend WithEvents cboOnTimeTimer As System.Windows.Forms.ComboBox
   Friend WithEvents tseOnTimeTime As ucTimeSpanEditor
   Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
