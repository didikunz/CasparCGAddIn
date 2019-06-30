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

      chkAutoConnect.Checked = _Settings.ConnectOnStartUp

      cboPreviewServer.Text = _Settings.PreviewServer
      nudPreviewChannel.Value = _Settings.PreviewChannel

      chkUseAveco.Checked = _Settings.UseAveco
      chkShowDashboard.Checked = _Settings.ShowDashboard

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