Imports Microsoft.Office.Interop.Excel
Imports CasparObjects
Imports System.Windows.Forms

Public Class frmSheetProperties

   Public Enum enumDialogMode
      ModeAll
      ModeDataSetName
      ModeTemplate
      ModeAutoUpdate
   End Enum

   Private _DialogMode As enumDialogMode = enumDialogMode.ModeDataSetName
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
      Dim dsn As String = CustomProperies.Load(_wrkSheet, "DataSetName")
      If dsn = "" Then
         dsn = _wrkSheet.Name
      End If

      txtDataSetName.Text = dsn
      tabDataSetName.Enabled = True
      tabTab.SelectedTab = tabDataSetName

      'Template
      If _CasparCG IsNot Nothing AndAlso _CasparCG.Connected Then
         cboPreviewTemplate.Items.Clear()
         Dim lst As List(Of String) = _CasparCG.GetTemplateNames()
         For Each s As String In lst
            cboPreviewTemplate.Items.Add(s)
         Next
         cboPreviewTemplate.Text = CustomProperies.Load(_wrkSheet, "Template")
         tabTemplate.Enabled = True
      End If

      'Auto-Update
      cboServers.Items.Clear()
      cboServers.Items.Add("All")
      For Each casp As CasparCG In _Settings.Servers
         cboServers.Items.Add(casp.Name)
      Next

      Dim inte As Integer = 0
      Integer.TryParse(CustomProperies.Load(_wrkSheet, "AutoUpdateDataset"), inte)
      If inte = 1 Then
         rbDataset.Checked = True
      Else
         rbLive.Checked = True
      End If

      If Integer.TryParse(CustomProperies.Load(_wrkSheet, "ServerNumber"), inte) Then
         cboServers.SelectedIndex = inte
      Else
         cboServers.SelectedIndex = 0
      End If

      If Integer.TryParse(CustomProperies.Load(_wrkSheet, "Channel"), inte) Then
         nudChannel.Value = inte
      End If

      If Integer.TryParse(CustomProperies.Load(_wrkSheet, "Layer"), inte) Then
         nudLayer.Value = inte
      End If

      If Integer.TryParse(CustomProperies.Load(_wrkSheet, "ControlsSet"), inte) Then
         cboControlSet.SelectedIndex = inte
      Else
         cboControlSet.SelectedIndex = 6     'csLoadPlayStopUpdate
      End If

      'Queries
      If Integer.TryParse(CustomProperies.Load(_wrkSheet, "UpdateQueries"), inte) Then
         chkRefreshQueries.Checked = (inte = 1)
      Else
         chkRefreshQueries.Checked = False
      End If

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      clstQueries.Items.Clear()
      Dim hash As HashSet(Of String) = New HashSet(Of String)

      Dim que As String = CustomProperies.Load(_wrkSheet, "Queries")
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


      'Select default tab
      If _DialogMode = enumDialogMode.ModeDataSetName Or _DialogMode = enumDialogMode.ModeAll Then
         tabTab.SelectedTab = tabDataSetName
      ElseIf _DialogMode = enumDialogMode.ModeTemplate Then
         tabTab.SelectedTab = tabTemplate
      ElseIf _DialogMode = enumDialogMode.ModeAutoUpdate Then
         tabTab.SelectedTab = tabAutoUpdate
      End If

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      'Dataset
      CustomProperies.Save(_wrkSheet, "DataSetName", txtDataSetName.Text)

      'Update template
      CustomProperies.Save(_wrkSheet, "Template", cboPreviewTemplate.Text)

      'Autoupdate
      If rbDataset.Checked Then
         CustomProperies.Save(_wrkSheet, "AutoUpdateDataset", "1")
      Else
         CustomProperies.Save(_wrkSheet, "AutoUpdateDataset", "0")
         CustomProperies.Save(_wrkSheet, "ServerNumber", cboServers.SelectedIndex.ToString)
         CustomProperies.Save(_wrkSheet, "Channel", nudChannel.Value.ToString)
         CustomProperies.Save(_wrkSheet, "Layer", nudLayer.Value.ToString)
         CustomProperies.Save(_wrkSheet, "ControlsSet", cboControlSet.SelectedIndex.ToString)
      End If

      'Queries
      CustomProperies.Save(_wrkSheet, "UpdateQueries", IIf(chkRefreshQueries.Checked, "1", "0"))

      Dim que As String = ""
      For Each i As Integer In clstQueries.CheckedIndices
         que += clstQueries.Items(i) + "|"
      Next

      If que <> "" Then
         CustomProperies.Save(_wrkSheet, "Queries", que.Substring(0, que.Length - 1))
      End If

   End Sub

   Private Sub chkRefreshQueries_CheckedChanged(sender As Object, e As EventArgs) Handles chkRefreshQueries.CheckedChanged
      tabQueries.Enabled = chkRefreshQueries.Checked
   End Sub
End Class