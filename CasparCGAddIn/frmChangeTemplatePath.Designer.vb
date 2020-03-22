<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeTemplatePath
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
      Me.lblHelp = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cboSource = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cboDestination = New System.Windows.Forms.ComboBox()
      Me.btnStart = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'lblHelp
      '
      Me.lblHelp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.lblHelp.Location = New System.Drawing.Point(12, 9)
      Me.lblHelp.Name = "lblHelp"
      Me.lblHelp.Size = New System.Drawing.Size(334, 49)
      Me.lblHelp.TabIndex = 0
      Me.lblHelp.Text = "Use this if you have moved the templates into another sub-folder of your CasparCG" &
    "'s template folder."
      Me.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 67)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(254, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Old folder (this is what is inside this Excel workbook):"
      '
      'cboSource
      '
      Me.cboSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboSource.FormattingEnabled = True
      Me.cboSource.Location = New System.Drawing.Point(12, 85)
      Me.cboSource.Name = "cboSource"
      Me.cboSource.Size = New System.Drawing.Size(334, 21)
      Me.cboSource.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 112)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(235, 13)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "New folder (this is where the templates are now):"
      '
      'cboDestination
      '
      Me.cboDestination.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboDestination.FormattingEnabled = True
      Me.cboDestination.Location = New System.Drawing.Point(12, 130)
      Me.cboDestination.Name = "cboDestination"
      Me.cboDestination.Size = New System.Drawing.Size(334, 21)
      Me.cboDestination.TabIndex = 4
      '
      'btnStart
      '
      Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.btnStart.Location = New System.Drawing.Point(253, 172)
      Me.btnStart.Name = "btnStart"
      Me.btnStart.Size = New System.Drawing.Size(93, 32)
      Me.btnStart.TabIndex = 5
      Me.btnStart.Text = "Start"
      Me.btnStart.UseVisualStyleBackColor = True
      '
      'frmChangeTemplatePath
      '
      Me.AcceptButton = Me.btnStart
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(358, 216)
      Me.Controls.Add(Me.btnStart)
      Me.Controls.Add(Me.cboDestination)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cboSource)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblHelp)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmChangeTemplatePath"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Change Template Path"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents lblHelp As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cboSource As System.Windows.Forms.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cboDestination As System.Windows.Forms.ComboBox
   Friend WithEvents btnStart As System.Windows.Forms.Button
End Class
