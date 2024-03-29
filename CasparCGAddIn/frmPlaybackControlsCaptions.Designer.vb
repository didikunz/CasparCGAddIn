﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPlaybackControlsCaptions
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCaption = New System.Windows.Forms.TextBox()
        Me.btnCaptionColor = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOscEndpoint = New System.Windows.Forms.TextBox()
        Me.ttToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(293, 97)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(212, 97)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOk.TabIndex = 12
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Caption-Text:"
        '
        'txtCaption
        '
        Me.txtCaption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCaption.Location = New System.Drawing.Point(15, 25)
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.Size = New System.Drawing.Size(353, 20)
        Me.txtCaption.TabIndex = 15
        Me.ttToolTips.SetToolTip(Me.txtCaption, "Caption text to be displayed above the playback buttons.")
        '
        'btnCaptionColor
        '
        Me.btnCaptionColor.Location = New System.Drawing.Point(15, 64)
        Me.btnCaptionColor.Name = "btnCaptionColor"
        Me.btnCaptionColor.Size = New System.Drawing.Size(113, 25)
        Me.btnCaptionColor.TabIndex = 16
        Me.btnCaptionColor.Text = "Caption-Color..."
        Me.ttToolTips.SetToolTip(Me.btnCaptionColor, "Choose the color for the caption bar.")
        Me.btnCaptionColor.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "OSC-Endpoint:"
        '
        'txtOscEndpoint
        '
        Me.txtOscEndpoint.Location = New System.Drawing.Point(144, 67)
        Me.txtOscEndpoint.Name = "txtOscEndpoint"
        Me.txtOscEndpoint.Size = New System.Drawing.Size(224, 20)
        Me.txtOscEndpoint.TabIndex = 18
        Me.ttToolTips.SetToolTip(Me.txtOscEndpoint, "Set a unique text to be used as a OSC endpoint name.")
        '
        'frmPlaybackControlsCaptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 134)
        Me.Controls.Add(Me.txtOscEndpoint)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCaptionColor)
        Me.Controls.Add(Me.txtCaption)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlaybackControlsCaptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caption Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents btnOk As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtCaption As System.Windows.Forms.TextBox
   Friend WithEvents btnCaptionColor As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtOscEndpoint As System.Windows.Forms.TextBox
    Friend WithEvents ttToolTips As System.Windows.Forms.ToolTip
End Class
