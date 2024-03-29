﻿Imports Microsoft.Office.Interop.Excel
Imports CasparObjects
Imports System.Windows.Forms
Imports System.Globalization

Public Class frmSheetProperties

   Public Enum enumDialogMode
      ModeAll
      ModeCommon
      ModeAutoUpdate
   End Enum

   Public Enum enumMoveDirection
      mdNone
      mdLeft
      mdRight
      mdUp
      mdDown
      mdIn
      mdOut
      mdFastLeft
      mdFastRight
      mdFastUp
      mdFastDown
      mdFastIn
      mdFastOut
   End Enum

   Private _DialogMode As enumDialogMode = enumDialogMode.ModeCommon
   Private _wrkSheet As Worksheet
   Private _CasparCG As CasparCG
   Private _Settings As Settings
   Private _Ribbon As ribCasparCG

   Private _x As Double = 0
   Private _y As Double = 0
   Private _w As Double = 1
   Private _h As Double = 1
   Private _xIncr As Double = 0
   Private _yIncr As Double = 0
   Private _xRes As Double = 0
   Private _yRes As Double = 0

   Private _delay As Integer = 0
   Private _speed As Integer = 0

   Private _movement As enumMoveDirection = enumMoveDirection.mdNone
   Private WithEvents _moveTimer As System.Windows.Forms.Timer = New System.Windows.Forms.Timer

   Private _TimerSheet As TimerSheet = Nothing

   Public WriteOnly Property DialogMode As enumDialogMode
      Set(value As enumDialogMode)
         _DialogMode = value
      End Set
   End Property

   Public WriteOnly Property wrkSheet As Worksheet
      Set(value As Worksheet)
         _wrkSheet = value
      End Set
   End Property

   Public WriteOnly Property Settings As Settings
      Set(value As Settings)

         _Settings = value
         If _Settings IsNot Nothing Then

            If _Settings.Preview IsNot Nothing AndAlso _Settings.Preview.Connected Then
               _CasparCG = _Settings.Preview
            Else
               For Each cas As CasparCG In _Settings.Servers
                  If cas.Connected Then
                     _CasparCG = cas
                     Exit For
                  End If
               Next
            End If

         End If

      End Set
   End Property

   Public WriteOnly Property Ribbon As ribCasparCG
      Set(value As ribCasparCG)
         _Ribbon = value
      End Set
   End Property

   Private Sub frmSheetProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Loader.Load(Me, _Settings.Theme)

      For Each s As String In [Enum].GetNames(GetType(TimerItem.enumQueryValues))

         s = System.Text.RegularExpressions.Regex.Replace(s, "([A-Z])", " $1").Trim()

         cboTimerQueryValue_1.Items.Add(s)
         cboTimerQueryValue_2.Items.Add(s)
         cboTimerQueryValue_3.Items.Add(s)
         cboTimerQueryValue_4.Items.Add(s)
         cboTimerQueryValue_5.Items.Add(s)
         cboTimerQueryValue_6.Items.Add(s)
         cboTimerQueryValue_7.Items.Add(s)
         cboTimerQueryValue_8.Items.Add(s)

      Next

      'DataSet
      txtDataSetName.Text = CustomProperties.Load(_wrkSheet, "DataSetName", _wrkSheet.Name)

      'Output-Mode
      Dim mode As String = CustomProperties.Load(_wrkSheet, "OutputMode", "")
      Select Case mode
         Case ""
            rbStandardMode.Checked = True
         Case "DELIMITED"
            rbStandardMode.Checked = True
         Case "TABLE"
            rbTableMode.Checked = True
         Case "HTML"
            rbHTMLMode.Checked = True
      End Select

      'Delimiter Settings
      Dim deliminter As String = CustomProperties.Load(_wrkSheet, "Delimiter", "")
      Select Case deliminter
         Case ""
            rbTabDelimited.Checked = True
         Case "TAB"
            rbTabDelimited.Checked = True
         Case "COLON"
            rbColonDelimited.Checked = True
         Case "SEMICOLON"
            rbSemicolonDelimited.Checked = True
         Case Else
            rbCustomDelimited.Checked = True
            txtCustomDelimiter.Text = deliminter
      End Select

      'Table-Settings
      chkTextAsWhite.Checked = CustomProperties.Load(_wrkSheet, "TableTextAsWhite", False)
      chkAddBorders.Checked = CustomProperties.Load(_wrkSheet, "TableAddBorders", False)

      'HTML-Settings
      chkFirstIsHeader.Checked = CustomProperties.Load(_wrkSheet, "HTMLFirstIsHeader", False)

      Dim fieldname As String = CustomProperties.Load(_wrkSheet, "HTMLFieldname", "")
      If fieldname <> "" Then
         txtHTMLFieldname.Text = fieldname
      End If

      cboSheetToAppend.Items.Clear()
      cboSlaveWorksheet.Items.Clear()
      cboSheetToAppend.Items.Add("(None)")
      cboSlaveWorksheet.Items.Add("(None)")
      For Each wrk As Worksheet In _wrkSheet.Application.Sheets
         Dim sh As String = wrk.Name.ToString.Trim
         If sh <> _wrkSheet.Name.Trim Then
            cboSheetToAppend.Items.Add(sh)
         End If
         cboSlaveWorksheet.Items.Add(sh)
      Next

      Dim sheetToAppend As String = CustomProperties.Load(_wrkSheet, "SheetToAppend", "")
      For c As Integer = 0 To cboSheetToAppend.Items.Count - 1
         If cboSheetToAppend.Items(c) = sheetToAppend Then
            cboSheetToAppend.SelectedIndex = c
            Exit For
         End If
      Next

      'Auto-Update & Live
      cboServers.Items.Clear()
      cboServers.Items.Add("All")
      For Each casp As CasparCG In _Settings.Servers
         cboServers.Items.Add(casp.Name)
      Next

      If CustomProperties.Load(_wrkSheet, "AutoUpdateDataset", 0) Then
         rbDataset.Checked = True
      Else
         rbLive.Checked = True
      End If

      Dim si As Integer = CustomProperties.Load(_wrkSheet, "ServerNumber", 0)
      If si < cboServers.Items.Count Then
         cboServers.SelectedIndex = si
      End If

      nudChannel.Value = CustomProperties.Load(_wrkSheet, "Channel", 1)

      nudLayer.Value = CustomProperties.Load(_wrkSheet, "Layer", 20)

      If _Settings.UseFlashLayers Then
         lblFlashLayer.Visible = True
         nudFlashLayer.Visible = True
         nudLayer.Width = 88
         nudFlashLayer.Value = CustomProperties.Load(_wrkSheet, "FlashLayer", 1)
      Else
         lblFlashLayer.Visible = False
         nudFlashLayer.Visible = False
         nudLayer.Width = 183
      End If

      Dim slaveSheet As String = CustomProperties.Load(_wrkSheet, "SlaveWorksheet", "").Trim
      For c As Integer = 0 To cboSlaveWorksheet.Items.Count - 1
         If cboSlaveWorksheet.Items(c) = slaveSheet Then
            cboSlaveWorksheet.SelectedIndex = c
            Exit For
         End If
      Next

      nudSlaveChannel.Value = CustomProperties.Load(_wrkSheet, "SlaveChannel", CInt(nudChannel.Value) + 1)
      nudSlaveChannel.Enabled = (slaveSheet = _wrkSheet.Name.Trim)

      'Templates
      If _CasparCG IsNot Nothing AndAlso _CasparCG.Connected Then

         cboTemplate.Items.Clear()
         cboPreviewTemplate.Items.Clear()

         Dim lst As List(Of String) = _CasparCG.GetTemplateNames()

         For Each s As String In lst
            cboTemplate.Items.Add(s)
            cboPreviewTemplate.Items.Add(s)
         Next

         Dim mainTemplateName As String = CustomProperties.Load(_wrkSheet, "Template", "")
         cboTemplate.Text = mainTemplateName
         If cboTemplate.SelectedIndex = -1 Then
            lblMissingTemplate.Text = mainTemplateName
         End If

         Dim previewTemplateName As String = CustomProperties.Load(_wrkSheet, "PreviewTemplate", "")
         If previewTemplateName = "" Then
            cboPreviewTemplate.Text = mainTemplateName
         Else
            cboPreviewTemplate.Text = previewTemplateName
         End If

      End If

      cboControlSet.SelectedIndex = CustomProperties.Load(_wrkSheet, "ControlsSet", 6)
      chkShowInDashboard.Checked = CustomProperties.Load(_wrkSheet, "ShowInDashboard", True)

      'Queries
      chkRefreshQueries.Checked = CustomProperties.Load(_wrkSheet, "UpdateQueries", False)

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      clstQueries.Items.Clear()
      Dim hash As HashSet(Of String) = New HashSet(Of String)

      Dim que As String = CustomProperties.Load(_wrkSheet, "Queries", "")
      If que <> "" Then
         Dim queries() As String = que.Split("|")
         For Each s As String In queries
            hash.Add(s)
         Next
      End If

      For Each con In AppObject.Connections
         Dim n As String = con.Name
         If hash.Contains(n) Then
            clstQueries.Items.Add(n, CheckState.Checked)
         Else
            clstQueries.Items.Add(n, CheckState.Unchecked)
         End If
      Next

      'DVE
      chkUseDVE.Checked = CustomProperties.Load(_wrkSheet, "UseDVE", False)
      SetVariables(CustomProperties.Load(_wrkSheet, "DVEffect", "0 0 1 1"))

      Select Case _Settings.VideoResolution
         Case CasparCGAddIn.Settings.enumVideoResolution.vrPAL
            _xRes = 720
            _yRes = 576
         Case CasparCGAddIn.Settings.enumVideoResolution.vrNTSC
            _xRes = 720
            _yRes = 486
         Case CasparCGAddIn.Settings.enumVideoResolution.vrHD720
            _xRes = 1280
            _yRes = 720
         Case CasparCGAddIn.Settings.enumVideoResolution.vrHD1080
            _xRes = 1920
            _yRes = 1080
         Case CasparCGAddIn.Settings.enumVideoResolution.vr4K
            _xRes = 3840
            _yRes = 2160
      End Select

      _xIncr = 1 / _xRes
      _yIncr = 1 / _yRes

      _delay = (System.Windows.Forms.SystemInformation.KeyboardDelay + 1) * 250
      _speed = CInt(1000 / ((System.Windows.Forms.SystemInformation.KeyboardSpeed + 2.5) * 0.8955))

      DVEPreview()

      'Timer
      If _Ribbon.TimerSettings IsNot Nothing Then

         For Each ts As TimerSheet In _Ribbon.TimerSettings.Sheets
            If ts.WorksheetName = _wrkSheet.Name.ToString.Trim Then
               _TimerSheet = ts
               Exit For
            End If
         Next

         For Each item As TimerItem In _Ribbon.TimerSettings.Items
            cboTimerItem_1.Items.Add(item.Name)
            cboTimerItem_2.Items.Add(item.Name)
            cboTimerItem_3.Items.Add(item.Name)
            cboTimerItem_4.Items.Add(item.Name)
            cboTimerItem_5.Items.Add(item.Name)
            cboTimerItem_6.Items.Add(item.Name)
            cboTimerItem_7.Items.Add(item.Name)
            cboTimerItem_8.Items.Add(item.Name)
            cboTimerTriggerItem.Items.Add(item.Name)
            cboAutoStopItem.Items.Add(item.Name)
         Next

         If _TimerSheet IsNot Nothing Then

            If _TimerSheet.Fields.Count >= 1 Then
               FillTimerControls(_TimerSheet.Fields(0), txtTimerField_1, cboTimerItem_1, cboTimerQueryValue_1)
            End If
            If _TimerSheet.Fields.Count >= 2 Then
               FillTimerControls(_TimerSheet.Fields(1), txtTimerField_2, cboTimerItem_2, cboTimerQueryValue_2)
            End If
            If _TimerSheet.Fields.Count >= 3 Then
               FillTimerControls(_TimerSheet.Fields(2), txtTimerField_3, cboTimerItem_3, cboTimerQueryValue_3)
            End If
            If _TimerSheet.Fields.Count >= 4 Then
               FillTimerControls(_TimerSheet.Fields(3), txtTimerField_4, cboTimerItem_4, cboTimerQueryValue_4)
            End If
            If _TimerSheet.Fields.Count >= 5 Then
               FillTimerControls(_TimerSheet.Fields(4), txtTimerField_5, cboTimerItem_5, cboTimerQueryValue_5)
            End If
            If _TimerSheet.Fields.Count >= 6 Then
               FillTimerControls(_TimerSheet.Fields(5), txtTimerField_6, cboTimerItem_6, cboTimerQueryValue_6)
            End If
            If _TimerSheet.Fields.Count >= 7 Then
               FillTimerControls(_TimerSheet.Fields(6), txtTimerField_7, cboTimerItem_7, cboTimerQueryValue_7)
            End If
            If _TimerSheet.Fields.Count >= 8 Then
               FillTimerControls(_TimerSheet.Fields(7), txtTimerField_8, cboTimerItem_8, cboTimerQueryValue_8)
            End If

            txtTimerInvoke.Text = _TimerSheet.OnTimeInvoke

            For c As Integer = 0 To cboTimerTriggerItem.Items.Count - 1
               If _TimerSheet.OnTimeTimer = cboTimerTriggerItem.Items(c) Then
                  cboTimerTriggerItem.SelectedIndex = c
                  Exit For
               End If
            Next

            cboAutoPlayMode.SelectedIndex = _TimerSheet.AutoPlayMode

            For c As Integer = 0 To cboAutoStopItem.Items.Count - 1
               If _TimerSheet.AutoPlayTimer = cboAutoStopItem.Items(c) Then
                  cboAutoStopItem.SelectedIndex = c
                  Exit For
               End If
            Next

         End If

      End If

      'Web-Download
      cboDownloadSource.Text = CustomProperties.Load(_wrkSheet, "DownloadSource", "A")
      cboDownloadDest.Text = CustomProperties.Load(_wrkSheet, "DownloadDestination", "B")
      ptbDownloadPath.Path = CustomProperties.Load(_wrkSheet, "DownloadPath", "")


      Select Case _DialogMode
         Case enumDialogMode.ModeCommon
            tabTab.SelectedTab = tabCommon

         Case enumDialogMode.ModeAutoUpdate
            tabTab.SelectedTab = tabAutoUpdate

         Case enumDialogMode.ModeAll
            tabTab.SelectedTab = tabCommon

      End Select

   End Sub

   Private Sub FillTimerControls(field As TimerField, nameTextbox As System.Windows.Forms.TextBox, itemCombo As ComboBox, queryCombo As ComboBox)

      If field IsNot Nothing Then

         nameTextbox.Text = field.FieldName

         For i As Integer = 0 To itemCombo.Items.Count - 1
            If field.ItemName = itemCombo.Items(i) Then
               itemCombo.SelectedIndex = i
               Exit For
            End If
         Next

         queryCombo.SelectedIndex = field.QueryValue

      End If

   End Sub

   Private Sub btnExportStyles_Click(sender As Object, e As EventArgs) Handles btnExportStyles.Click

      If _Ribbon IsNot Nothing Then

         Dim dlg As SaveFileDialog = New SaveFileDialog
         dlg.AddExtension = True
         dlg.DefaultExt = ".css"
         dlg.Filter = "Cascading Style Sheets (*.css)|*.css|All Files (*.*)|*.*||"
         dlg.FilterIndex = 0

         If dlg.ShowDialog(Me) = DialogResult.OK Then

            _Ribbon.ExportStyles(dlg.FileName)

         End If

      End If

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      'Dataset
      CustomProperties.Save(_wrkSheet, "DataSetName", txtDataSetName.Text)

      'Output-Mode
      If rbTableMode.Checked Then
         CustomProperties.Save(_wrkSheet, "OutputMode", "TABLE")
      ElseIf rbHTMLMode.Checked Then
         CustomProperties.Save(_wrkSheet, "OutputMode", "HTML")
      Else
         CustomProperties.Save(_wrkSheet, "OutputMode", "DELIMITED")
      End If

      'Delimiter Settings
      If rbTabDelimited.Checked Then
         CustomProperties.Save(_wrkSheet, "Delimiter", "TAB")
      ElseIf rbColonDelimited.Checked Then
         CustomProperties.Save(_wrkSheet, "Delimiter", "COLON")
      ElseIf rbSemicolonDelimited.Checked Then
         CustomProperties.Save(_wrkSheet, "Delimiter", "SEMICOLON")
      Else
         If txtCustomDelimiter.Text.Trim <> "" Then
            CustomProperties.Save(_wrkSheet, "Delimiter", txtCustomDelimiter.Text.Trim.Substring(0, 1))
         Else
            CustomProperties.Save(_wrkSheet, "Delimiter", "TAB")
         End If
      End If

      'Table-Settings
      CustomProperties.Save(_wrkSheet, "TableTextAsWhite", IIf(chkTextAsWhite.Checked, "1", "0"))
      CustomProperties.Save(_wrkSheet, "TableAddBorders", IIf(chkAddBorders.Checked, "1", "0"))

      'HTML-Settings
      CustomProperties.Save(_wrkSheet, "HTMLFirstIsHeader", IIf(chkFirstIsHeader.Checked, "1", "0"))
      CustomProperties.Save(_wrkSheet, "HTMLFieldname", txtHTMLFieldname.Text)
      If cboSheetToAppend.SelectedIndex > -1 Then
         CustomProperties.Save(_wrkSheet, "SheetToAppend", cboSheetToAppend.Items(cboSheetToAppend.SelectedIndex))
      End If

      'Update template
      If _CasparCG IsNot Nothing AndAlso _CasparCG.Connected Then
         CustomProperties.Save(_wrkSheet, "Template", cboTemplate.Text)
         CustomProperties.Save(_wrkSheet, "PreviewTemplate", cboPreviewTemplate.Text)
      End If

      'Autoupdate
      If rbDataset.Checked Then
         CustomProperties.Save(_wrkSheet, "AutoUpdateDataset", "1")
      Else
         CustomProperties.Save(_wrkSheet, "AutoUpdateDataset", "0")
         CustomProperties.Save(_wrkSheet, "ServerNumber", cboServers.SelectedIndex.ToString)
         CustomProperties.Save(_wrkSheet, "Channel", nudChannel.Value.ToString)
         CustomProperties.Save(_wrkSheet, "Layer", nudLayer.Value.ToString)
         If _Settings.UseFlashLayers Then
            CustomProperties.Save(_wrkSheet, "FlashLayer", nudFlashLayer.Value.ToString)
         End If

         CustomProperties.Save(_wrkSheet, "ControlsSet", cboControlSet.SelectedIndex.ToString)
         CustomProperties.Save(_wrkSheet, "ShowInDashboard", IIf(chkShowInDashboard.Checked, "1", "0"))

         If cboSlaveWorksheet.SelectedIndex > -1 Then
            CustomProperties.Save(_wrkSheet, "SlaveWorksheet", cboSlaveWorksheet.Items(cboSlaveWorksheet.SelectedIndex))
         End If
         CustomProperties.Save(_wrkSheet, "SlaveChannel", nudSlaveChannel.Value.ToString)
      End If

      'Queries
      CustomProperties.Save(_wrkSheet, "UpdateQueries", IIf(chkRefreshQueries.Checked, "1", "0"))

      Dim que As String = ""
      For Each i As Integer In clstQueries.CheckedIndices
         que += clstQueries.Items(i) + "|"
      Next

      If que <> "" Then
         CustomProperties.Save(_wrkSheet, "Queries", que.Substring(0, que.Length - 1))
      End If

      'DVE
      CustomProperties.Save(_wrkSheet, "UseDVE", IIf(chkUseDVE.Checked, 1, 0))
      CustomProperties.Save(_wrkSheet, "DVEffect", GetVariables())

      'Timer
      If _Ribbon.TimerSettings IsNot Nothing Then

         If _TimerSheet Is Nothing Then
            If txtTimerField_1.Text <> "" Or txtTimerField_2.Text <> "" Or txtTimerField_3.Text <> "" Or txtTimerField_4.Text <> "" Or txtTimerField_5.Text <> "" Or txtTimerField_6.Text <> "" Or txtTimerField_7.Text <> "" Or txtTimerField_8.Text <> "" Then
               _TimerSheet = New TimerSheet(_wrkSheet.Name)
               _Ribbon.TimerSettings.Sheets.Add(_TimerSheet)
            End If
         End If

         If _TimerSheet IsNot Nothing Then

            _TimerSheet.Fields.Clear()

            If txtTimerField_1.Text <> "" Then
               _TimerSheet.Fields.Add(New TimerField(txtTimerField_1.Text, cboTimerItem_1.Items(cboTimerItem_1.SelectedIndex), cboTimerQueryValue_1.SelectedIndex))
            End If
            If txtTimerField_2.Text <> "" Then
               _TimerSheet.Fields.Add(New TimerField(txtTimerField_2.Text, cboTimerItem_2.Items(cboTimerItem_2.SelectedIndex), cboTimerQueryValue_2.SelectedIndex))
            End If
            If txtTimerField_3.Text <> "" Then
               _TimerSheet.Fields.Add(New TimerField(txtTimerField_3.Text, cboTimerItem_3.Items(cboTimerItem_3.SelectedIndex), cboTimerQueryValue_3.SelectedIndex))
            End If
            If txtTimerField_4.Text <> "" Then
               _TimerSheet.Fields.Add(New TimerField(txtTimerField_4.Text, cboTimerItem_4.Items(cboTimerItem_4.SelectedIndex), cboTimerQueryValue_4.SelectedIndex))
            End If
            If txtTimerField_5.Text <> "" Then
               _TimerSheet.Fields.Add(New TimerField(txtTimerField_5.Text, cboTimerItem_5.Items(cboTimerItem_5.SelectedIndex), cboTimerQueryValue_5.SelectedIndex))
            End If
            If txtTimerField_6.Text <> "" Then
               _TimerSheet.Fields.Add(New TimerField(txtTimerField_6.Text, cboTimerItem_6.Items(cboTimerItem_6.SelectedIndex), cboTimerQueryValue_6.SelectedIndex))
            End If
            If txtTimerField_7.Text <> "" Then
               _TimerSheet.Fields.Add(New TimerField(txtTimerField_7.Text, cboTimerItem_7.Items(cboTimerItem_7.SelectedIndex), cboTimerQueryValue_7.SelectedIndex))
            End If
            If txtTimerField_8.Text <> "" Then
               _TimerSheet.Fields.Add(New TimerField(txtTimerField_8.Text, cboTimerItem_8.Items(cboTimerItem_8.SelectedIndex), cboTimerQueryValue_8.SelectedIndex))
            End If

            _TimerSheet.OnTimeInvoke = txtTimerInvoke.Text

            If cboTimerTriggerItem.SelectedIndex > -1 Then
               _TimerSheet.OnTimeTimer = cboTimerTriggerItem.Items(cboTimerTriggerItem.SelectedIndex)
            End If

            If cboAutoPlayMode.SelectedIndex > -1 Then
               _TimerSheet.AutoPlayMode = cboAutoPlayMode.SelectedIndex
            End If

            If cboAutoStopItem.SelectedIndex > -1 Then
               _TimerSheet.AutoPlayTimer = cboAutoStopItem.Items(cboAutoStopItem.SelectedIndex)
            End If
         End If

      End If

      'Web-Download
      CustomProperties.Save(_wrkSheet, "DownloadSource", cboDownloadSource.Text)
      CustomProperties.Save(_wrkSheet, "DownloadDestination", cboDownloadDest.Text)
      CustomProperties.Save(_wrkSheet, "DownloadPath", ptbDownloadPath.Path)

   End Sub

   Private Sub lnkLablReset_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLablReset.LinkClicked
      'ToDo: Update the settings
      If MsgBox("This will delete all settings made for this worksheet. Proceed?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Reset to defaults") = MsgBoxResult.Yes Then
         CustomProperties.Clear(_wrkSheet)
         Me.Close()
      End If

   End Sub

   Private Sub chkRefreshQueries_CheckedChanged(sender As Object, e As EventArgs) Handles chkRefreshQueries.CheckedChanged
      tabQueries.Enabled = chkRefreshQueries.Checked
   End Sub

   Private Sub btnChangeTemplatePath_Click(sender As Object, e As EventArgs) Handles btnChangeTemplatePath.Click

      Dim fctp As frmChangeTemplatePath = New frmChangeTemplatePath
      fctp.Settings = _Settings
      fctp.wrkSheet = _wrkSheet
      fctp.CasparCG = _CasparCG

      fctp.ShowDialog(Me)

   End Sub

   Private Sub cboSlaveWorksheet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSlaveWorksheet.SelectedIndexChanged
      nudSlaveChannel.Enabled = (cboSlaveWorksheet.Items(cboSlaveWorksheet.SelectedIndex).ToString.Trim = _wrkSheet.Name.Trim)
   End Sub

   Private Sub SetVariables(dveString As String)

      Dim arr() As String = dveString.Split(" ")
      Dim err As Boolean = False
      If arr.Length = 4 Then
         If Not Double.TryParse(arr(0), _x) Then
            err = True
         End If
         If Not Double.TryParse(arr(1), _y) Then
            err = True
         End If
         If Not Double.TryParse(arr(2), _w) Then
            err = True
         End If
         If Not Double.TryParse(arr(3), _h) Then
            err = True
         End If
      End If

      If err Then
         SetVariables("0 0 1 1")
      End If

   End Sub

   Private Function GetVariables() As String
      Return String.Format(CultureInfo.InvariantCulture, "{0:F6} {1:F6} {2:F6} {3:F6}", _x, _y, _w, _h)
   End Function

   Private Sub DVEPreview()
      If Not rbNone.Checked Then
         If rbProgram.Checked Then
            If _CasparCG IsNot Nothing AndAlso _CasparCG.Connected Then
               _CasparCG.Mixer_Fill(CInt(nudChannel.Value), CInt(nudLayer.Value), GetVariables())
            End If
         Else
            If _CasparCG IsNot Nothing AndAlso _CasparCG.Connected Then
               _CasparCG.Mixer_Fill(_Settings.PreviewChannel, 20, GetVariables())
            End If
         End If
      End If
      lblCorrdinates.Text = String.Format("{0:###0}, {1:###0} - {2:###0}, {3:###0}", _xRes * _x, _yRes * _y, _xRes * _w, _yRes * _h)
   End Sub

   Private Sub lnklblCopy_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblCopy.LinkClicked
      Clipboard.SetText(GetVariables())
   End Sub

   Private Sub lnklblPaste_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPaste.LinkClicked
      Dim dve As String = Clipboard.GetText()
      SetVariables(dve)
      DVEPreview()
   End Sub

   Private Sub rbPreview_CheckedChanged(sender As Object, e As EventArgs) Handles rbPreview.CheckedChanged
      If rbPreview.Checked Then
         DVEPreview()
      End If
   End Sub

   Private Sub rbProgram_CheckedChanged(sender As Object, e As EventArgs) Handles rbProgram.CheckedChanged
      If rbProgram.Checked Then
         DVEPreview()
      End If
   End Sub

   Private Sub btnLeft_MouseDown(sender As Object, e As MouseEventArgs) Handles btnLeft.MouseDown
      _movement = enumMoveDirection.mdLeft
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnRight_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRight.MouseDown
      _movement = enumMoveDirection.mdRight
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnUp_MouseDown(sender As Object, e As MouseEventArgs) Handles btnUp.MouseDown
      _movement = enumMoveDirection.mdUp
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnDown_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDown.MouseDown
      _movement = enumMoveDirection.mdDown
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnZoomIn_MouseDown(sender As Object, e As MouseEventArgs) Handles btnZoomIn.MouseDown
      _movement = enumMoveDirection.mdIn
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnZoomOut_MouseDown(sender As Object, e As MouseEventArgs) Handles btnZoomOut.MouseDown
      _movement = enumMoveDirection.mdOut
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub
   Private Sub btnFastLeft_MouseDown(sender As Object, e As MouseEventArgs) Handles btnFastLeft.MouseDown
      _movement = enumMoveDirection.mdFastLeft
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnFastRight_MouseDown(sender As Object, e As MouseEventArgs) Handles btnFastRight.MouseDown
      _movement = enumMoveDirection.mdFastRight
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub
   Private Sub btnFastUp_MouseDown(sender As Object, e As MouseEventArgs) Handles btnFastUp.MouseDown
      _movement = enumMoveDirection.mdFastUp
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnFastDown_MouseDown(sender As Object, e As MouseEventArgs) Handles btnFastDown.MouseDown
      _movement = enumMoveDirection.mdFastDown
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnZoomFastIn_MouseDown(sender As Object, e As MouseEventArgs) Handles btnZoomFastIn.MouseDown
      _movement = enumMoveDirection.mdFastIn
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub btnZoomFastOut_MouseDown(sender As Object, e As MouseEventArgs) Handles btnZoomFastOut.MouseDown
      _movement = enumMoveDirection.mdFastOut
      _moveTimer.Interval = _delay
      _moveTimer.Start()
   End Sub

   Private Sub MoveButtoms_MouseUp(sender As Object, e As MouseEventArgs) Handles btnFastUp.MouseUp, btnFastDown.MouseUp, btnFastLeft.MouseUp, btnFastRight.MouseUp, btnDown.MouseUp, btnLeft.MouseUp, btnRight.MouseUp, btnUp.MouseUp, btnZoomFastIn.MouseUp, btnZoomFastOut.MouseUp, btnZoomIn.MouseUp, btnZoomOut.MouseUp
      _moveTimer.Stop()
      If _moveTimer.Interval = _delay Then
         DoMovement()
      End If
      _movement = enumMoveDirection.mdNone
   End Sub

   Private Sub btnCenter_Click(sender As Object, e As EventArgs) Handles btnCenter.Click
      _x = 0
      _y = 0
      DVEPreview()
   End Sub

   Private Sub btnZoom100_Click(sender As Object, e As EventArgs) Handles btnZoom100.Click
      _x -= (1 - _w) / 2
      _y -= (1 - _h) / 2
      _w = 1
      _h = 1
      DVEPreview()
   End Sub

   Private Sub DoMovement()

      Select Case _movement
         Case enumMoveDirection.mdLeft
            _x -= _xIncr
         Case enumMoveDirection.mdRight
            _x += _xIncr
         Case enumMoveDirection.mdUp
            _y -= _yIncr
         Case enumMoveDirection.mdDown
            _y += _yIncr
         Case enumMoveDirection.mdIn
            _x += _xIncr
            _y += _xIncr
            _w -= _xIncr * 2
            _h -= _xIncr * 2
         Case enumMoveDirection.mdOut
            _x -= _xIncr
            _y -= _xIncr
            _w += _xIncr * 2
            _h += _xIncr * 2
         Case enumMoveDirection.mdFastLeft
            _x -= _xIncr * 10
         Case enumMoveDirection.mdFastRight
            _x += _xIncr * 10
         Case enumMoveDirection.mdFastUp
            _y -= _yIncr * 10
         Case enumMoveDirection.mdFastDown
            _y += _yIncr * 10
         Case enumMoveDirection.mdFastIn
            _x += _xIncr * 10
            _y += _xIncr * 10
            _w -= _xIncr * 20
            _h -= _xIncr * 20
         Case enumMoveDirection.mdFastOut
            _x -= _xIncr * 10
            _y -= _xIncr * 10
            _w += _xIncr * 20
            _h += _xIncr * 20
      End Select

      DVEPreview()

   End Sub

   Private Sub _moveTimer_Tick(sender As Object, e As EventArgs) Handles _moveTimer.Tick

      _moveTimer.Stop()
      _moveTimer.Interval = _speed

      DoMovement()

      If _movement <> enumMoveDirection.mdNone Then
         _moveTimer.Start()
      End If

   End Sub

End Class