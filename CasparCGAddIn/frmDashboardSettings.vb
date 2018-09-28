Imports Microsoft.Office.Interop.Excel
Imports CasparObjects

Public Class frmDashboardSettings

   Private _CasparServerNames As List(Of String)

   Public WriteOnly Property CasparServerNames As List(Of String)
      Set(value As List(Of String))
         _CasparServerNames = value
      End Set
   End Property

   Public Property ServerNumber As Integer = 1
   Public Property Channel As Integer = 1
   Public Property Layer As Integer = 20
   Public Property DataFields As String = ""
   Public Property ControlsSet As ucPlaybackControls.enumControlSets = ucPlaybackControls.enumControlSets.csLoadPlayStopUpdate

   Private Sub frmDashboardSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

      Me.DialogResult = System.Windows.Forms.DialogResult.OK

   End Sub

End Class