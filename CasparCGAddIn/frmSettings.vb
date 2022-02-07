Imports System.ComponentModel
Imports CasparObjects

Public Class frmSettings

   Private _Settings As Settings

   Public WriteOnly Property Settings As Settings
      Set(value As Settings)
         _Settings = value
      End Set
   End Property

   Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Loader.Load(Me, _Settings.Theme)

      If _Settings.Servers.Count = 0 Then
         _Settings.Servers.Add(New CasparCG)
         rbModeRemote.Checked = True
      End If

      For Each cas As CasparCG In _Settings.Servers
         If cas.ServerAdress <> "localhost" Then
            cas.Retries = 1
         End If
      Next

      bsServers.DataSource = _Settings.Servers
      bsServersClone.DataSource = _Settings.Servers

      cboPreviewServer.Text = _Settings.PreviewServer
      nudPreviewChannel.Value = _Settings.PreviewChannel

      chkUseAveco.Checked = _Settings.UseAveco
      chkShowDashboard.Checked = _Settings.ShowDashboard
      chkUseImageAttr.Checked = _Settings.UseImageAttributes
      chkInhibitPlaybackSlave.Checked = _Settings.InhibitPlayback4Slave
      chkUseFlashLayers.Checked = _Settings.UseFlashLayers
      chkFormatForHTML.Checked = _Settings.FormatTextsForHTML

      chkAutoConnect.Checked = _Settings.ConnectOnStartUp

      Select Case _Settings.VideoResolution
         Case CasparCGAddIn.Settings.enumVideoResolution.vrPAL
            cboVideoResolution.SelectedIndex = 0
         Case CasparCGAddIn.Settings.enumVideoResolution.vrNTSC
            cboVideoResolution.SelectedIndex = 1
         Case CasparCGAddIn.Settings.enumVideoResolution.vrHD720
            cboVideoResolution.SelectedIndex = 2
         Case CasparCGAddIn.Settings.enumVideoResolution.vrHD1080
            cboVideoResolution.SelectedIndex = 3
         Case CasparCGAddIn.Settings.enumVideoResolution.vr4K
            cboVideoResolution.SelectedIndex = 4
      End Select
      tseCountDown.Value = _Settings.DefaultCountDownStartTime

      chkUseOscInput.Checked = _Settings.UseOSCInput
      txtOscPort.Text = _Settings.OSCInputPort.ToString

      lblVersion.Text = String.Format("Version: {0}.{1}.{2}.{3:0000}", My.Application.Info.Version.Major, My.Application.Info.Version.MajorRevision, My.Application.Info.Version.Minor, My.Application.Info.Version.MinorRevision)

   End Sub

   Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

      Dim cas As CasparCG = New CasparCG
      cas.ServerAdress = "0.0.0.0"

      _Settings.Servers.Add(cas)

      bsServers.DataSource = _Settings.Servers
      bsServers.ResetBindings(False)
      bsServers.Position = bsServers.IndexOf(cas)

      bsServersClone.DataSource = _Settings.Servers
      bsServersClone.ResetBindings(False)
      cboPreviewServer.Text = _Settings.PreviewServer

   End Sub

   Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

      Dim caspar As CasparCG = CType(bsServers.Current, CasparCG)
      _Settings.Servers.Remove(caspar)

      bsServers.DataSource = _Settings.Servers
      bsServers.ResetBindings(False)
      bsServers.MoveFirst()

      bsServersClone.DataSource = _Settings.Servers
      bsServersClone.ResetBindings(False)
      cboPreviewServer.Text = _Settings.PreviewServer

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      _Settings.ConnectOnStartUp = chkAutoConnect.Checked

      _Settings.PreviewServer = cboPreviewServer.Text
      _Settings.PreviewChannel = nudPreviewChannel.Value

      _Settings.UseAveco = chkUseAveco.Checked
      _Settings.ShowDashboard = chkShowDashboard.Checked
      _Settings.UseImageAttributes = chkUseImageAttr.Checked
      _Settings.InhibitPlayback4Slave = chkInhibitPlaybackSlave.Checked
      _Settings.UseFlashLayers = chkUseFlashLayers.Checked
      _Settings.FormatTextsForHTML = chkFormatForHTML.Checked

      Select Case cboVideoResolution.SelectedIndex
         Case 0
            _Settings.VideoResolution = CasparCGAddIn.Settings.enumVideoResolution.vrPAL
         Case 1
            _Settings.VideoResolution = CasparCGAddIn.Settings.enumVideoResolution.vrNTSC
         Case 2
            _Settings.VideoResolution = CasparCGAddIn.Settings.enumVideoResolution.vrHD720
         Case 3
            _Settings.VideoResolution = CasparCGAddIn.Settings.enumVideoResolution.vrHD1080
         Case 4
            _Settings.VideoResolution = CasparCGAddIn.Settings.enumVideoResolution.vr4K
      End Select
      _Settings.DefaultCountDownStartTime = tseCountDown.Value

      _Settings.UseOSCInput = chkUseOscInput.Checked
      Dim inte As Integer = 0
      If Integer.TryParse(txtOscPort.Text, inte) Then
         _Settings.OSCInputPort = inte
      End If

   End Sub

   Private Sub UpdateUI()

      lblAddress.Visible = (rbModeRemote.Checked = True)
      lblPort.Visible = (rbModeRemote.Checked = True)
      txtAddress.Visible = (rbModeRemote.Checked = True)
      txtPort.Visible = (rbModeRemote.Checked = True)

      lblExeFile.Visible = (rbModeRemote.Checked = False)
      ftbCasparExe.Visible = (rbModeRemote.Checked = False)

      rbModeLocal.Checked = Not rbModeRemote.Checked

   End Sub

   Private Sub rbModeRemote_CheckedChanged(sender As Object, e As EventArgs) Handles rbModeRemote.CheckedChanged

      UpdateUI()

      If rbModeRemote.Checked = False Then
         If bsServers.Current IsNot Nothing Then
            Dim cas As CasparCG = CType(bsServers.Current, CasparCG)
            cas.ServerAdress = "localhost"
            cas.Retries = 20
            bsServers.ResetBindings(False)
         End If
      End If

   End Sub

   Private Sub bsServers_PositionChanged(sender As Object, e As EventArgs) Handles bsServers.PositionChanged

      If bsServers.Current IsNot Nothing Then
         rbModeRemote.Checked = Not CType(bsServers.Current, CasparCG).ServerAdress = "localhost"
         UpdateUI()
      End If

   End Sub

   Private Sub cboPreviewServer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPreviewServer.SelectedIndexChanged

      Dim caspar As CasparCG = CType(bsServers.Current, CasparCG)
      If caspar.Connected Then
         nudPreviewChannel.Maximum = caspar.GetNumberOfChannels
      Else
         nudPreviewChannel.Maximum = 10
      End If
   End Sub

End Class