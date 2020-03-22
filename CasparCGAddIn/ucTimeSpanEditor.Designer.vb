<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTimeSpanEditor
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
      Me.nudDay = New System.Windows.Forms.NumericUpDown()
      Me.tblPanel = New System.Windows.Forms.TableLayoutPanel()
      Me.nudHour = New System.Windows.Forms.NumericUpDown()
      Me.nudMinutes = New System.Windows.Forms.NumericUpDown()
      Me.nudSeconds = New System.Windows.Forms.NumericUpDown()
      Me.ttHelp = New System.Windows.Forms.ToolTip(Me.components)
      CType(Me.nudDay, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tblPanel.SuspendLayout()
      CType(Me.nudHour, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudMinutes, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'nudDay
      '
      Me.nudDay.Dock = System.Windows.Forms.DockStyle.Fill
      Me.nudDay.Location = New System.Drawing.Point(0, 0)
      Me.nudDay.Margin = New System.Windows.Forms.Padding(0)
      Me.nudDay.Name = "nudDay"
      Me.nudDay.Size = New System.Drawing.Size(40, 20)
      Me.nudDay.TabIndex = 0
      Me.ttHelp.SetToolTip(Me.nudDay, "Days")
      '
      'tblPanel
      '
      Me.tblPanel.ColumnCount = 4
      Me.tblPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tblPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tblPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tblPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tblPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.tblPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.tblPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.tblPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.tblPanel.Controls.Add(Me.nudDay, 0, 0)
      Me.tblPanel.Controls.Add(Me.nudHour, 1, 0)
      Me.tblPanel.Controls.Add(Me.nudMinutes, 2, 0)
      Me.tblPanel.Controls.Add(Me.nudSeconds, 3, 0)
      Me.tblPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tblPanel.Location = New System.Drawing.Point(0, 0)
      Me.tblPanel.Name = "tblPanel"
      Me.tblPanel.RowCount = 1
      Me.tblPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.tblPanel.Size = New System.Drawing.Size(160, 20)
      Me.tblPanel.TabIndex = 1
      '
      'nudHour
      '
      Me.nudHour.Dock = System.Windows.Forms.DockStyle.Fill
      Me.nudHour.Location = New System.Drawing.Point(40, 0)
      Me.nudHour.Margin = New System.Windows.Forms.Padding(0)
      Me.nudHour.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
      Me.nudHour.Name = "nudHour"
      Me.nudHour.Size = New System.Drawing.Size(40, 20)
      Me.nudHour.TabIndex = 2
      Me.ttHelp.SetToolTip(Me.nudHour, "Hours")
      '
      'nudMinutes
      '
      Me.nudMinutes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.nudMinutes.Location = New System.Drawing.Point(80, 0)
      Me.nudMinutes.Margin = New System.Windows.Forms.Padding(0)
      Me.nudMinutes.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
      Me.nudMinutes.Name = "nudMinutes"
      Me.nudMinutes.Size = New System.Drawing.Size(40, 20)
      Me.nudMinutes.TabIndex = 4
      Me.ttHelp.SetToolTip(Me.nudMinutes, "Minutes")
      '
      'nudSeconds
      '
      Me.nudSeconds.Dock = System.Windows.Forms.DockStyle.Fill
      Me.nudSeconds.Location = New System.Drawing.Point(120, 0)
      Me.nudSeconds.Margin = New System.Windows.Forms.Padding(0)
      Me.nudSeconds.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
      Me.nudSeconds.Name = "nudSeconds"
      Me.nudSeconds.Size = New System.Drawing.Size(40, 20)
      Me.nudSeconds.TabIndex = 6
      Me.ttHelp.SetToolTip(Me.nudSeconds, "Seconds")
      '
      'ucTimeSpanEditor
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.tblPanel)
      Me.MaximumSize = New System.Drawing.Size(1920, 20)
      Me.MinimumSize = New System.Drawing.Size(160, 20)
      Me.Name = "ucTimeSpanEditor"
      Me.Size = New System.Drawing.Size(160, 20)
      CType(Me.nudDay, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tblPanel.ResumeLayout(False)
      CType(Me.nudHour, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudMinutes, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudSeconds, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents nudDay As System.Windows.Forms.NumericUpDown
   Friend WithEvents tblPanel As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents nudHour As System.Windows.Forms.NumericUpDown
   Friend WithEvents nudMinutes As System.Windows.Forms.NumericUpDown
   Friend WithEvents nudSeconds As System.Windows.Forms.NumericUpDown
   Friend WithEvents ttHelp As System.Windows.Forms.ToolTip
End Class
