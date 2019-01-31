<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWait
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
      Me.pbAnimation = New System.Windows.Forms.PictureBox()
      Me.lblInfo = New System.Windows.Forms.Label()
      CType(Me.pbAnimation, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'pbAnimation
      '
      Me.pbAnimation.Image = Global.CasparCGAddIn.My.Resources.Resources.loader_spinner
      Me.pbAnimation.Location = New System.Drawing.Point(0, 0)
      Me.pbAnimation.Name = "pbAnimation"
      Me.pbAnimation.Size = New System.Drawing.Size(350, 350)
      Me.pbAnimation.TabIndex = 0
      Me.pbAnimation.TabStop = False
      '
      'lblInfo
      '
      Me.lblInfo.Location = New System.Drawing.Point(0, 353)
      Me.lblInfo.Name = "lblInfo"
      Me.lblInfo.Size = New System.Drawing.Size(350, 21)
      Me.lblInfo.TabIndex = 1
      Me.lblInfo.Text = "..."
      Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'frmWait
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(350, 376)
      Me.Controls.Add(Me.lblInfo)
      Me.Controls.Add(Me.pbAnimation)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.Name = "frmWait"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Wait"
      CType(Me.pbAnimation, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents pbAnimation As System.Windows.Forms.PictureBox
   Friend WithEvents lblInfo As System.Windows.Forms.Label
End Class
