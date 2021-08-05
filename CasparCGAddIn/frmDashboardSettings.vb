Imports Microsoft.Office.Interop.Excel
Imports CasparObjects

Public Class frmDashboardSettings

   Private _Settings As Settings
   Private _CasparServerNames As List(Of String)

   Public WriteOnly Property Settings As Settings
      Set(value As Settings)
         _Settings = value
      End Set
   End Property

   Public WriteOnly Property CasparServerNames As List(Of String)
      Set(value As List(Of String))
         _CasparServerNames = value
      End Set
   End Property

   Public Property ServerNumber As Integer = 1
   Public Property Channel As Integer = 1
   Public Property Layer As Integer = 20
   Public Property DataFields As String = ""
   Public Property ControlsSet As ucPlaybackButtons.enumControlSets = ucPlaybackButtons.enumControlSets.csLoadPlayStopUpdate
   Public Property AutoClearEffect As String = "CUT"
   Public Property AutoClearEffectDuration As Integer = 0
   Public Property LayerRules As LayerRules = New LayerRules

   Private Sub frmDashboardSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Loader.Load(Me, _Settings.Theme)

      cboServers.Items.Clear()
      cboServers.Items.Add("All")
      For Each s As String In _CasparServerNames
         cboServers.Items.Add(s)
      Next

      If cboServers.Items.Count > ServerNumber Then
         cboServers.SelectedIndex = ServerNumber
      End If

      nudChannel.Value = Channel
      nudLayer.Value = Layer

      cboControlSet.SelectedIndex = CInt(Me.ControlsSet)

      Dim flds As String = DataFields
      If flds = "" Then
         flds = "f0|f1|f2|f3|f4|f5"
      End If
      flds = flds.Replace("|", vbCrLf)
      txtFields.Text = flds

      If AutoClearEffect = "CUT" Then
         cboAutoClearEffect.SelectedIndex = 0
      Else
         cboAutoClearEffect.SelectedIndex = 1
      End If

      nudAutoClearEffectDuration.Value = AutoClearEffectDuration

   End Sub

   Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

      ServerNumber = cboServers.SelectedIndex
      Channel = CInt(nudChannel.Value)
      Layer = CInt(nudLayer.Value)

      ControlsSet = cboControlSet.SelectedIndex

      Dim flds As String = txtFields.Text
      flds = flds.Replace(vbCrLf, "|")
      flds = flds.Replace("||", "|")
      DataFields = flds

      If cboAutoClearEffect.SelectedIndex = 0 Then
         AutoClearEffect = "CUT"
      Else
         AutoClearEffect = "MIX"
      End If

      AutoClearEffectDuration = CInt(nudAutoClearEffectDuration.Value)

      DialogResult = System.Windows.Forms.DialogResult.OK

   End Sub

   Private Sub lnklblDefaultDatafields_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblDefaultDatafields.LinkClicked
      If _Settings IsNot Nothing Then
         _Settings.DefaultDataFields = DataFields
      End If
   End Sub

   Private Sub lnklblLayerRules_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnklblLayerRules.LinkClicked
      Dim flr As frmLayerRules = New frmLayerRules
      flr.Settings = _Settings
      flr.LayerRules = LayerRules
      flr.ShowDialog()
   End Sub

End Class