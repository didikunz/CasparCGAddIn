Imports Microsoft.Office.Interop.Excel
Imports CasparObjects
Imports System.Windows.Forms

Public Class frmSheetProperties

   Public Enum enumDialogMode
      ModeAll
      ModeCommon
      ModeAutoUpdate
   End Enum

   Private _DialogMode As enumDialogMode = enumDialogMode.ModeCommon
   Private _wrkSheet As Worksheet
   Private _CasparCG As CasparCG
   Private _Settings As Settings

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

   Private Sub frmSheetProperties_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      'DataSet
      Dim dsn As String = CustomProperties.Load(_wrkSheet, "DataSetName")
      If dsn = "" Then
         dsn = _wrkSheet.Name
      End If

      txtDataSetName.Text = dsn

      'Delimiter Settings
      Dim deliminter As String = CustomProperties.Load(_wrkSheet, "Delimiter")
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

      'Auto-Update
      cboServers.Items.Clear()
      cboServers.Items.Add("All")
      For Each casp As CasparCG In _Settings.Servers
         cboServers.Items.Add(casp.Name)
      Next

      Dim inte As Integer = 0
      Integer.TryParse(CustomProperties.Load(_wrkSheet, "AutoUpdateDataset"), inte)
      If inte = 1 Then
         rbDataset.Checked = True
      Else
         rbLive.Checked = True
      End If

      If Integer.TryParse(CustomProperties.Load(_wrkSheet, "ServerNumber"), inte) Then
         cboServers.SelectedIndex = inte
      Else
         cboServers.SelectedIndex = 0
      End If

      If Integer.TryParse(CustomProperties.Load(_wrkSheet, "Channel"), inte) Then
         nudChannel.Value = inte
      End If

      If Integer.TryParse(CustomProperties.Load(_wrkSheet, "Layer"), inte) Then
         nudLayer.Value = inte
      End If

      'Templates
      If _CasparCG IsNot Nothing AndAlso _CasparCG.Connected Then

         cboTemplate.Items.Clear()
         cboPreviewTemplate.Items.Clear()

         Dim lst As List(Of String) = _CasparCG.GetTemplateNames()

         For Each s As String In lst
            cboTemplate.Items.Add(s)
            cboPreviewTemplate.Items.Add(s)
         Next

         cboTemplate.Text = CustomProperties.Load(_wrkSheet, "Template")
         cboPreviewTemplate.Text = CustomProperties.Load(_wrkSheet, "Template")

      End If

      If Integer.TryParse(CustomProperties.Load(_wrkSheet, "ControlsSet"), inte) Then
         cboControlSet.SelectedIndex = inte
      Else
         cboControlSet.SelectedIndex = 6     'csLoadPlayStopUpdate
      End If

      'Queries
      If Integer.TryParse(CustomProperties.Load(_wrkSheet, "UpdateQueries"), inte) Then
         chkRefreshQueries.Checked = (inte = 1)
      Else
         chkRefreshQueries.Checked = False
      End If

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      clstQueries.Items.Clear()
      Dim hash As HashSet(Of String) = New HashSet(Of String)

      Dim que As String = CustomProperties.Load(_wrkSheet, "Queries")
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

      Select Case _DialogMode
         Case enumDialogMode.ModeCommon
            tabTab.SelectedTab = tabCommon
            tabCommon.Enabled = True
            tabAutoUpdate.Enabled = False
            tabQueries.Enabled = False

         Case enumDialogMode.ModeAutoUpdate
            tabTab.SelectedTab = tabAutoUpdate
            tabCommon.Enabled = False
            tabAutoUpdate.Enabled = True
            tabQueries.Enabled = True

         Case enumDialogMode.ModeAll
            tabTab.SelectedTab = tabCommon
            tabCommon.Enabled = True
            tabAutoUpdate.Enabled = True
            tabQueries.Enabled = True

      End Select

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      'Dataset
      CustomProperties.Save(_wrkSheet, "DataSetName", txtDataSetName.Text)

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

      'Update template
      If _CasparCG IsNot Nothing AndAlso _CasparCG.Connected Then

         If _DialogMode = enumDialogMode.ModeCommon Then
            CustomProperties.Save(_wrkSheet, "Template", cboPreviewTemplate.Text)
         Else
            CustomProperties.Save(_wrkSheet, "Template", cboTemplate.Text)
         End If

      End If

      'Autoupdate
      If rbDataset.Checked Then
         CustomProperties.Save(_wrkSheet, "AutoUpdateDataset", "1")
      Else
         CustomProperties.Save(_wrkSheet, "AutoUpdateDataset", "0")
         CustomProperties.Save(_wrkSheet, "ServerNumber", cboServers.SelectedIndex.ToString)
         CustomProperties.Save(_wrkSheet, "Channel", nudChannel.Value.ToString)
         CustomProperties.Save(_wrkSheet, "Layer", nudLayer.Value.ToString)
         CustomProperties.Save(_wrkSheet, "ControlsSet", cboControlSet.SelectedIndex.ToString)
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

   End Sub

   Private Sub chkRefreshQueries_CheckedChanged(sender As Object, e As EventArgs) Handles chkRefreshQueries.CheckedChanged
      tabQueries.Enabled = chkRefreshQueries.Checked
   End Sub

End Class