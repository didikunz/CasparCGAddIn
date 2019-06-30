<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucDashboard
   Inherits System.Windows.Forms.UserControl

   'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
      Me.flpFlow = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblHeader = New System.Windows.Forms.Label()
      Me.panList = New System.Windows.Forms.Panel()
      Me.pbPlaybackButtons = New CasparCGAddIn.ucPlaybackButtons()
      Me.panMiddle = New System.Windows.Forms.Panel()
      Me.lnkLabelRefreshLists = New System.Windows.Forms.LinkLabel()
      Me.lnklblQueries = New System.Windows.Forms.LinkLabel()
      Me.cboVideo = New System.Windows.Forms.ComboBox()
      Me.cboImages = New System.Windows.Forms.ComboBox()
      Me.cboAudio = New System.Windows.Forms.ComboBox()
      Me.cboTemplates = New System.Windows.Forms.ComboBox()
      Me.btnCreate = New System.Windows.Forms.Button()
      Me.panTop = New System.Windows.Forms.Panel()
      Me.rbTemplate = New System.Windows.Forms.RadioButton()
      Me.rbAudio = New System.Windows.Forms.RadioButton()
      Me.rbImage = New System.Windows.Forms.RadioButton()
      Me.rbVideo = New System.Windows.Forms.RadioButton()
      Me.btnSettings = New System.Windows.Forms.Button()
      Me.ttTips = New System.Windows.Forms.ToolTip(Me.components)
      Me.panList.SuspendLayout()
      Me.panMiddle.SuspendLayout()
      Me.panTop.SuspendLayout()
      Me.SuspendLayout()
      '
      'flpFlow
      '
      Me.flpFlow.AutoScroll = True
      Me.flpFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
      Me.flpFlow.Location = New System.Drawing.Point(0, 0)
      Me.flpFlow.Name = "flpFlow"
      Me.flpFlow.Size = New System.Drawing.Size(205, 414)
      Me.flpFlow.TabIndex = 0
      Me.flpFlow.WrapContents = False
      '
      'lblHeader
      '
      Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblHeader.BackColor = System.Drawing.SystemColors.ButtonShadow
      Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblHeader.ForeColor = System.Drawing.SystemColors.ButtonHighlight
      Me.lblHeader.Location = New System.Drawing.Point(0, 1)
      Me.lblHeader.Name = "lblHeader"
      Me.lblHeader.Size = New System.Drawing.Size(192, 21)
      Me.lblHeader.TabIndex = 10
      Me.lblHeader.Text = "List"
      Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'panList
      '
      Me.panList.Controls.Add(Me.pbPlaybackButtons)
      Me.panList.Controls.Add(Me.panMiddle)
      Me.panList.Controls.Add(Me.panTop)
      Me.panList.Controls.Add(Me.btnSettings)
      Me.panList.Controls.Add(Me.lblHeader)
      Me.panList.Enabled = False
      Me.panList.Location = New System.Drawing.Point(0, 430)
      Me.panList.Name = "panList"
      Me.panList.Size = New System.Drawing.Size(205, 190)
      Me.panList.TabIndex = 11
      '
      'pbPlaybackButtons
      '
      Me.pbPlaybackButtons.BackColor = System.Drawing.Color.Transparent
      Me.pbPlaybackButtons.ControlsSet = CasparCGAddIn.ucPlaybackButtons.enumControlSets.csPlayStop
      Me.pbPlaybackButtons.Location = New System.Drawing.Point(0, 134)
      Me.pbPlaybackButtons.Margin = New System.Windows.Forms.Padding(0)
      Me.pbPlaybackButtons.Name = "pbPlaybackButtons"
      Me.pbPlaybackButtons.Size = New System.Drawing.Size(203, 56)
      Me.pbPlaybackButtons.State = CasparCGAddIn.ucPlaybackButtons.enumState.stIdle
      Me.pbPlaybackButtons.TabIndex = 21
      '
      'panMiddle
      '
      Me.panMiddle.Controls.Add(Me.lnkLabelRefreshLists)
      Me.panMiddle.Controls.Add(Me.lnklblQueries)
      Me.panMiddle.Controls.Add(Me.cboVideo)
      Me.panMiddle.Controls.Add(Me.cboImages)
      Me.panMiddle.Controls.Add(Me.cboAudio)
      Me.panMiddle.Controls.Add(Me.cboTemplates)
      Me.panMiddle.Controls.Add(Me.btnCreate)
      Me.panMiddle.Location = New System.Drawing.Point(0, 82)
      Me.panMiddle.Name = "panMiddle"
      Me.panMiddle.Size = New System.Drawing.Size(203, 46)
      Me.panMiddle.TabIndex = 20
      '
      'lnkLabelRefreshLists
      '
      Me.lnkLabelRefreshLists.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lnkLabelRefreshLists.AutoSize = True
      Me.lnkLabelRefreshLists.Location = New System.Drawing.Point(3, 28)
      Me.lnkLabelRefreshLists.Name = "lnkLabelRefreshLists"
      Me.lnkLabelRefreshLists.Size = New System.Drawing.Size(68, 13)
      Me.lnkLabelRefreshLists.TabIndex = 20
      Me.lnkLabelRefreshLists.TabStop = True
      Me.lnkLabelRefreshLists.Text = "Refresh Lists"
      '
      'lnklblQueries
      '
      Me.lnklblQueries.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lnklblQueries.AutoSize = True
      Me.lnklblQueries.Location = New System.Drawing.Point(160, 30)
      Me.lnklblQueries.Name = "lnklblQueries"
      Me.lnklblQueries.Size = New System.Drawing.Size(44, 13)
      Me.lnklblQueries.TabIndex = 19
      Me.lnklblQueries.TabStop = True
      Me.lnklblQueries.Text = "Query..."
      '
      'cboVideo
      '
      Me.cboVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboVideo.DropDownWidth = 200
      Me.cboVideo.FormattingEnabled = True
      Me.cboVideo.Location = New System.Drawing.Point(143, 6)
      Me.cboVideo.Name = "cboVideo"
      Me.cboVideo.Size = New System.Drawing.Size(202, 21)
      Me.cboVideo.TabIndex = 18
      '
      'cboImages
      '
      Me.cboImages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboImages.DropDownWidth = 200
      Me.cboImages.FormattingEnabled = True
      Me.cboImages.Location = New System.Drawing.Point(95, 6)
      Me.cboImages.Name = "cboImages"
      Me.cboImages.Size = New System.Drawing.Size(202, 21)
      Me.cboImages.TabIndex = 17
      '
      'cboAudio
      '
      Me.cboAudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboAudio.DropDownWidth = 200
      Me.cboAudio.FormattingEnabled = True
      Me.cboAudio.Location = New System.Drawing.Point(46, 6)
      Me.cboAudio.Name = "cboAudio"
      Me.cboAudio.Size = New System.Drawing.Size(202, 21)
      Me.cboAudio.TabIndex = 16
      '
      'cboTemplates
      '
      Me.cboTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTemplates.DropDownWidth = 200
      Me.cboTemplates.FormattingEnabled = True
      Me.cboTemplates.Location = New System.Drawing.Point(1, 6)
      Me.cboTemplates.Name = "cboTemplates"
      Me.cboTemplates.Size = New System.Drawing.Size(202, 21)
      Me.cboTemplates.TabIndex = 15
      '
      'btnCreate
      '
      Me.btnCreate.Location = New System.Drawing.Point(0, 0)
      Me.btnCreate.Name = "btnCreate"
      Me.btnCreate.Size = New System.Drawing.Size(202, 46)
      Me.btnCreate.TabIndex = 19
      Me.btnCreate.Text = "Create list in document"
      Me.btnCreate.UseVisualStyleBackColor = True
      '
      'panTop
      '
      Me.panTop.Controls.Add(Me.rbTemplate)
      Me.panTop.Controls.Add(Me.rbAudio)
      Me.panTop.Controls.Add(Me.rbImage)
      Me.panTop.Controls.Add(Me.rbVideo)
      Me.panTop.Location = New System.Drawing.Point(0, 30)
      Me.panTop.Name = "panTop"
      Me.panTop.Size = New System.Drawing.Size(203, 46)
      Me.panTop.TabIndex = 19
      '
      'rbTemplate
      '
      Me.rbTemplate.Appearance = System.Windows.Forms.Appearance.Button
      Me.rbTemplate.Checked = True
      Me.rbTemplate.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Template
      Me.rbTemplate.Location = New System.Drawing.Point(1, 0)
      Me.rbTemplate.Name = "rbTemplate"
      Me.rbTemplate.Size = New System.Drawing.Size(46, 46)
      Me.rbTemplate.TabIndex = 11
      Me.rbTemplate.TabStop = True
      Me.ttTips.SetToolTip(Me.rbTemplate, "Graphic Template")
      Me.rbTemplate.UseVisualStyleBackColor = True
      '
      'rbAudio
      '
      Me.rbAudio.Appearance = System.Windows.Forms.Appearance.Button
      Me.rbAudio.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Audio
      Me.rbAudio.Location = New System.Drawing.Point(53, 0)
      Me.rbAudio.Name = "rbAudio"
      Me.rbAudio.Size = New System.Drawing.Size(46, 46)
      Me.rbAudio.TabIndex = 12
      Me.ttTips.SetToolTip(Me.rbAudio, "Audio Clip")
      Me.rbAudio.UseVisualStyleBackColor = True
      '
      'rbImage
      '
      Me.rbImage.Appearance = System.Windows.Forms.Appearance.Button
      Me.rbImage.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Images
      Me.rbImage.Location = New System.Drawing.Point(106, 0)
      Me.rbImage.Name = "rbImage"
      Me.rbImage.Size = New System.Drawing.Size(46, 46)
      Me.rbImage.TabIndex = 13
      Me.ttTips.SetToolTip(Me.rbImage, "Image")
      Me.rbImage.UseVisualStyleBackColor = True
      '
      'rbVideo
      '
      Me.rbVideo.Appearance = System.Windows.Forms.Appearance.Button
      Me.rbVideo.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Video
      Me.rbVideo.Location = New System.Drawing.Point(158, 0)
      Me.rbVideo.Name = "rbVideo"
      Me.rbVideo.Size = New System.Drawing.Size(46, 46)
      Me.rbVideo.TabIndex = 14
      Me.ttTips.SetToolTip(Me.rbVideo, "Video Clip")
      Me.rbVideo.UseVisualStyleBackColor = True
      '
      'btnSettings
      '
      Me.btnSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSettings.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Settings
      Me.btnSettings.Location = New System.Drawing.Point(181, 0)
      Me.btnSettings.Name = "btnSettings"
      Me.btnSettings.Size = New System.Drawing.Size(24, 23)
      Me.btnSettings.TabIndex = 9
      Me.ttTips.SetToolTip(Me.btnSettings, "Settings")
      Me.btnSettings.UseVisualStyleBackColor = True
      '
      'ucDashboard
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.Control
      Me.Controls.Add(Me.panList)
      Me.Controls.Add(Me.flpFlow)
      Me.Name = "ucDashboard"
      Me.Size = New System.Drawing.Size(205, 623)
      Me.panList.ResumeLayout(False)
      Me.panMiddle.ResumeLayout(False)
      Me.panMiddle.PerformLayout()
      Me.panTop.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents flpFlow As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents btnSettings As System.Windows.Forms.Button
   Friend WithEvents lblHeader As System.Windows.Forms.Label
   Friend WithEvents ttTips As System.Windows.Forms.ToolTip
   Friend WithEvents panList As System.Windows.Forms.Panel
   Friend WithEvents cboVideo As System.Windows.Forms.ComboBox
   Friend WithEvents cboImages As System.Windows.Forms.ComboBox
   Friend WithEvents cboAudio As System.Windows.Forms.ComboBox
   Friend WithEvents cboTemplates As System.Windows.Forms.ComboBox
   Friend WithEvents rbVideo As System.Windows.Forms.RadioButton
   Friend WithEvents rbImage As System.Windows.Forms.RadioButton
   Friend WithEvents rbAudio As System.Windows.Forms.RadioButton
   Friend WithEvents rbTemplate As System.Windows.Forms.RadioButton
   Friend WithEvents panMiddle As System.Windows.Forms.Panel
   Friend WithEvents panTop As System.Windows.Forms.Panel
   Friend WithEvents btnCreate As System.Windows.Forms.Button
   Friend WithEvents lnklblQueries As System.Windows.Forms.LinkLabel
   Friend WithEvents lnkLabelRefreshLists As System.Windows.Forms.LinkLabel
   Friend WithEvents pbPlaybackButtons As ucPlaybackButtons
End Class
