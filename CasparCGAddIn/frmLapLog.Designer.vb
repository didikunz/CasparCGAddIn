<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLapLog
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
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.tabTab = New System.Windows.Forms.TabControl()
      Me.tpLap = New System.Windows.Forms.TabPage()
      Me.cboLapFormat4 = New System.Windows.Forms.ComboBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.txtLapCell4 = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cboLapFormat3 = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.txtLapCell3 = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.cboLapFormat2 = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtLapCell2 = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.cboLapFormat1 = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtLapCell1 = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cboLapSheet = New System.Windows.Forms.ComboBox()
      Me.tpGeneral = New System.Windows.Forms.TabPage()
      Me.tpLog = New System.Windows.Forms.TabPage()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cboLogSheet = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtSource = New System.Windows.Forms.TextBox()
      Me.txtDestination = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.chkIncrement = New System.Windows.Forms.CheckBox()
      Me.tabTab.SuspendLayout()
      Me.tpLap.SuspendLayout()
      Me.tpGeneral.SuspendLayout()
      Me.tpLog.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(363, 188)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 25)
      Me.btnCancel.TabIndex = 38
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = True
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnOk.Location = New System.Drawing.Point(282, 188)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(75, 25)
      Me.btnOk.TabIndex = 37
      Me.btnOk.Text = "OK"
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'tabTab
      '
      Me.tabTab.Controls.Add(Me.tpGeneral)
      Me.tabTab.Controls.Add(Me.tpLap)
      Me.tabTab.Controls.Add(Me.tpLog)
      Me.tabTab.Location = New System.Drawing.Point(4, 13)
      Me.tabTab.Name = "tabTab"
      Me.tabTab.SelectedIndex = 0
      Me.tabTab.Size = New System.Drawing.Size(439, 169)
      Me.tabTab.TabIndex = 36
      '
      'tpLap
      '
      Me.tpLap.Controls.Add(Me.cboLapFormat4)
      Me.tpLap.Controls.Add(Me.Label11)
      Me.tpLap.Controls.Add(Me.cboLapSheet)
      Me.tpLap.Controls.Add(Me.txtLapCell4)
      Me.tpLap.Controls.Add(Me.Label6)
      Me.tpLap.Controls.Add(Me.Label12)
      Me.tpLap.Controls.Add(Me.Label5)
      Me.tpLap.Controls.Add(Me.cboLapFormat3)
      Me.tpLap.Controls.Add(Me.txtLapCell1)
      Me.tpLap.Controls.Add(Me.Label9)
      Me.tpLap.Controls.Add(Me.Label4)
      Me.tpLap.Controls.Add(Me.txtLapCell3)
      Me.tpLap.Controls.Add(Me.cboLapFormat1)
      Me.tpLap.Controls.Add(Me.Label10)
      Me.tpLap.Controls.Add(Me.Label8)
      Me.tpLap.Controls.Add(Me.cboLapFormat2)
      Me.tpLap.Controls.Add(Me.txtLapCell2)
      Me.tpLap.Controls.Add(Me.Label7)
      Me.tpLap.Location = New System.Drawing.Point(4, 22)
      Me.tpLap.Name = "tpLap"
      Me.tpLap.Padding = New System.Windows.Forms.Padding(3)
      Me.tpLap.Size = New System.Drawing.Size(431, 143)
      Me.tpLap.TabIndex = 1
      Me.tpLap.Text = "Lap"
      Me.tpLap.UseVisualStyleBackColor = True
      '
      'cboLapFormat4
      '
      Me.cboLapFormat4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLapFormat4.FormattingEnabled = True
      Me.cboLapFormat4.Items.AddRange(New Object() {"Min Sec", "Hour Min Sec", "Days Hour Min Sec", "Days Hour Min", "Seconds", "Total Seconds", "Second Number", "Minutes", "Total Minutes", "Minute Number", "Hours", "Total Hours", "Hour Number", "Days", "Day Number"})
      Me.cboLapFormat4.Location = New System.Drawing.Point(322, 113)
      Me.cboLapFormat4.Name = "cboLapFormat4"
      Me.cboLapFormat4.Size = New System.Drawing.Size(99, 21)
      Me.cboLapFormat4.TabIndex = 44
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(322, 97)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(42, 13)
      Me.Label11.TabIndex = 43
      Me.Label11.Text = "Format:"
      '
      'txtLapCell4
      '
      Me.txtLapCell4.Location = New System.Drawing.Point(217, 114)
      Me.txtLapCell4.Name = "txtLapCell4"
      Me.txtLapCell4.Size = New System.Drawing.Size(99, 20)
      Me.txtLapCell4.TabIndex = 42
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(214, 95)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(27, 13)
      Me.Label12.TabIndex = 41
      Me.Label12.Text = "Cell:"
      '
      'cboLapFormat3
      '
      Me.cboLapFormat3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLapFormat3.FormattingEnabled = True
      Me.cboLapFormat3.Items.AddRange(New Object() {"Min Sec", "Hour Min Sec", "Days Hour Min Sec", "Days Hour Min", "Seconds", "Total Seconds", "Second Number", "Minutes", "Total Minutes", "Minute Number", "Hours", "Total Hours", "Hour Number", "Days", "Day Number"})
      Me.cboLapFormat3.Location = New System.Drawing.Point(111, 113)
      Me.cboLapFormat3.Name = "cboLapFormat3"
      Me.cboLapFormat3.Size = New System.Drawing.Size(99, 21)
      Me.cboLapFormat3.TabIndex = 40
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(111, 97)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(42, 13)
      Me.Label9.TabIndex = 39
      Me.Label9.Text = "Format:"
      '
      'txtLapCell3
      '
      Me.txtLapCell3.Location = New System.Drawing.Point(6, 114)
      Me.txtLapCell3.Name = "txtLapCell3"
      Me.txtLapCell3.Size = New System.Drawing.Size(99, 20)
      Me.txtLapCell3.TabIndex = 38
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(6, 95)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(27, 13)
      Me.Label10.TabIndex = 37
      Me.Label10.Text = "Cell:"
      '
      'cboLapFormat2
      '
      Me.cboLapFormat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLapFormat2.FormattingEnabled = True
      Me.cboLapFormat2.Items.AddRange(New Object() {"Min Sec", "Hour Min Sec", "Days Hour Min Sec", "Days Hour Min", "Seconds", "Total Seconds", "Second Number", "Minutes", "Total Minutes", "Minute Number", "Hours", "Total Hours", "Hour Number", "Days", "Day Number"})
      Me.cboLapFormat2.Location = New System.Drawing.Point(322, 69)
      Me.cboLapFormat2.Name = "cboLapFormat2"
      Me.cboLapFormat2.Size = New System.Drawing.Size(99, 21)
      Me.cboLapFormat2.TabIndex = 36
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(322, 53)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(42, 13)
      Me.Label7.TabIndex = 35
      Me.Label7.Text = "Format:"
      '
      'txtLapCell2
      '
      Me.txtLapCell2.Location = New System.Drawing.Point(217, 70)
      Me.txtLapCell2.Name = "txtLapCell2"
      Me.txtLapCell2.Size = New System.Drawing.Size(99, 20)
      Me.txtLapCell2.TabIndex = 34
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(214, 51)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(27, 13)
      Me.Label8.TabIndex = 33
      Me.Label8.Text = "Cell:"
      '
      'cboLapFormat1
      '
      Me.cboLapFormat1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLapFormat1.FormattingEnabled = True
      Me.cboLapFormat1.Items.AddRange(New Object() {"Min Sec", "Hour Min Sec", "Days Hour Min Sec", "Days Hour Min", "Seconds", "Total Seconds", "Second Number", "Minutes", "Total Minutes", "Minute Number", "Hours", "Total Hours", "Hour Number", "Days", "Day Number"})
      Me.cboLapFormat1.Location = New System.Drawing.Point(111, 69)
      Me.cboLapFormat1.Name = "cboLapFormat1"
      Me.cboLapFormat1.Size = New System.Drawing.Size(99, 21)
      Me.cboLapFormat1.TabIndex = 32
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(111, 53)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(42, 13)
      Me.Label4.TabIndex = 31
      Me.Label4.Text = "Format:"
      '
      'txtLapCell1
      '
      Me.txtLapCell1.Location = New System.Drawing.Point(6, 70)
      Me.txtLapCell1.Name = "txtLapCell1"
      Me.txtLapCell1.Size = New System.Drawing.Size(99, 20)
      Me.txtLapCell1.TabIndex = 30
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(6, 51)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(27, 13)
      Me.Label5.TabIndex = 29
      Me.Label5.Text = "Cell:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(6, 6)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(38, 13)
      Me.Label6.TabIndex = 28
      Me.Label6.Text = "Sheet:"
      '
      'cboLapSheet
      '
      Me.cboLapSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLapSheet.FormattingEnabled = True
      Me.cboLapSheet.Location = New System.Drawing.Point(6, 25)
      Me.cboLapSheet.Name = "cboLapSheet"
      Me.cboLapSheet.Size = New System.Drawing.Size(415, 21)
      Me.cboLapSheet.TabIndex = 27
      '
      'tpGeneral
      '
      Me.tpGeneral.Controls.Add(Me.txtName)
      Me.tpGeneral.Controls.Add(Me.Label13)
      Me.tpGeneral.Location = New System.Drawing.Point(4, 22)
      Me.tpGeneral.Name = "tpGeneral"
      Me.tpGeneral.Padding = New System.Windows.Forms.Padding(3)
      Me.tpGeneral.Size = New System.Drawing.Size(431, 143)
      Me.tpGeneral.TabIndex = 2
      Me.tpGeneral.Text = "General"
      Me.tpGeneral.UseVisualStyleBackColor = True
      '
      'tpLog
      '
      Me.tpLog.Controls.Add(Me.chkIncrement)
      Me.tpLog.Controls.Add(Me.txtDestination)
      Me.tpLog.Controls.Add(Me.Label3)
      Me.tpLog.Controls.Add(Me.txtSource)
      Me.tpLog.Controls.Add(Me.Label2)
      Me.tpLog.Controls.Add(Me.cboLogSheet)
      Me.tpLog.Controls.Add(Me.Label1)
      Me.tpLog.Location = New System.Drawing.Point(4, 22)
      Me.tpLog.Name = "tpLog"
      Me.tpLog.Padding = New System.Windows.Forms.Padding(3)
      Me.tpLog.Size = New System.Drawing.Size(431, 143)
      Me.tpLog.TabIndex = 3
      Me.tpLog.Text = "Log"
      Me.tpLog.UseVisualStyleBackColor = True
      '
      'txtName
      '
      Me.txtName.Location = New System.Drawing.Point(11, 25)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(413, 20)
      Me.txtName.TabIndex = 5
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(6, 6)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(72, 13)
      Me.Label13.TabIndex = 4
      Me.Label13.Text = "Button-Name:"
      '
      'cboLogSheet
      '
      Me.cboLogSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLogSheet.FormattingEnabled = True
      Me.cboLogSheet.Location = New System.Drawing.Point(6, 25)
      Me.cboLogSheet.Name = "cboLogSheet"
      Me.cboLogSheet.Size = New System.Drawing.Size(415, 21)
      Me.cboLogSheet.TabIndex = 29
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(6, 6)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 30
      Me.Label1.Text = "Sheet:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 51)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(105, 13)
      Me.Label2.TabIndex = 31
      Me.Label2.Text = "Source cell or range:"
      '
      'txtSource
      '
      Me.txtSource.Location = New System.Drawing.Point(6, 70)
      Me.txtSource.Name = "txtSource"
      Me.txtSource.Size = New System.Drawing.Size(204, 20)
      Me.txtSource.TabIndex = 32
      '
      'txtDestination
      '
      Me.txtDestination.Location = New System.Drawing.Point(217, 70)
      Me.txtDestination.Name = "txtDestination"
      Me.txtDestination.Size = New System.Drawing.Size(204, 20)
      Me.txtDestination.TabIndex = 34
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(217, 51)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(105, 13)
      Me.Label3.TabIndex = 33
      Me.Label3.Text = "Destination start cell:"
      '
      'chkIncrement
      '
      Me.chkIncrement.AutoSize = True
      Me.chkIncrement.Location = New System.Drawing.Point(9, 100)
      Me.chkIncrement.Name = "chkIncrement"
      Me.chkIncrement.Size = New System.Drawing.Size(170, 17)
      Me.chkIncrement.TabIndex = 35
      Me.chkIncrement.Text = "Increment (+1) the line counter"
      Me.chkIncrement.UseVisualStyleBackColor = True
      '
      'frmLapLog
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(447, 225)
      Me.ControlBox = False
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.tabTab)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmLapLog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Laps and Logs"
      Me.tabTab.ResumeLayout(False)
      Me.tpLap.ResumeLayout(False)
      Me.tpLap.PerformLayout()
      Me.tpGeneral.ResumeLayout(False)
      Me.tpGeneral.PerformLayout()
      Me.tpLog.ResumeLayout(False)
      Me.tpLog.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents tabTab As System.Windows.Forms.TabControl
   Friend WithEvents tpLap As System.Windows.Forms.TabPage
   Friend WithEvents cboLapFormat4 As System.Windows.Forms.ComboBox
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents txtLapCell4 As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents cboLapFormat3 As System.Windows.Forms.ComboBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents txtLapCell3 As System.Windows.Forms.TextBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents cboLapFormat2 As System.Windows.Forms.ComboBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents txtLapCell2 As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cboLapFormat1 As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtLapCell1 As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cboLapSheet As System.Windows.Forms.ComboBox
   Friend WithEvents tpGeneral As System.Windows.Forms.TabPage
   Friend WithEvents tpLog As System.Windows.Forms.TabPage
   Friend WithEvents txtName As System.Windows.Forms.TextBox
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents cboLogSheet As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtDestination As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtSource As System.Windows.Forms.TextBox
   Friend WithEvents chkIncrement As System.Windows.Forms.CheckBox
End Class
