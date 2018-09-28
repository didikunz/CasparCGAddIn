Imports Microsoft.Office.Interop.Excel
Imports CasparObjects

Public Class ThisAddIn

   Private _Settings As Settings
   Private _SettingsFName As String

   Private _Dashboard As ucDashboard
   Private WithEvents _DashboardPane As Microsoft.Office.Tools.CustomTaskPane

   Public Sub ConnectAll()

      Dim errText As String = ""

      For Each caspar In _Settings.Servers

         Select Case caspar.Connect()
            Case CasparCG.enumConnectResult.crMachineNotAvailable
               errText += String.Format("The machine '{0}' - '{1}' is not available.", caspar.ServerAdress, caspar.Name) + vbNewLine
            Case CasparCG.enumConnectResult.crCasparCGNotStarted
               errText += String.Format("CasparCG '{0}' is not running.", caspar.Name) + vbNewLine
            Case CasparCG.enumConnectResult.crLOcalCasprCGCouldNotBeStarted
               errText += String.Format("CasparCG '{0}' could not be started. The path to the exe-file is probably invalid.", caspar.Name) + vbNewLine
            Case CasparCG.enumConnectResult.crIsNotLocal
               errText += String.Format("This CasparCG '{0}' is not local.", caspar.Name) + vbNewLine
         End Select

      Next

      If errText <> "" Then
         MsgBox(errText, MsgBoxStyle.Exclamation, "Connection problem")
         _Dashboard.IsCasparConnected = False
      Else
         _Dashboard.IsCasparConnected = True
      End If

   End Sub

   Public Sub DisconnectAll()

      For Each caspar In _Settings.Servers
         If caspar.Connected Then
            caspar.Disconnect()
         End If
         _Dashboard.IsCasparConnected = False
      Next

   End Sub


   Private Sub ThisAddIn_Startup() Handles Me.Startup

      Dim cap As CommonAppData.CommonApplicationData = New CommonAppData.CommonApplicationData("MediaSupport", "CasparCGAddIn", True)
      _SettingsFName = IO.Path.Combine(cap.ApplicationFolderPath, "Settings.xml")

      If IO.File.Exists(_SettingsFName) Then
         _Settings = New Settings(_SettingsFName)
      Else
         _Settings = New Settings()
      End If

      _Dashboard = New ucDashboard
      _DashboardPane = Me.CustomTaskPanes.Add(_Dashboard, "CasparCG Dashboard")
      _DashboardPane.Visible = _Settings.DashboardVisible

      _Dashboard.Settings = _Settings
      _Dashboard.CasparRibon = Globals.Ribbons.ribCasparCG

      Globals.Ribbons.ribCasparCG.Settings = _Settings
      Globals.Ribbons.ribCasparCG.SetDashboardObjects(_Dashboard, _DashboardPane)

      If _Settings.ConnectOnStartUp Then
         ConnectAll()
      End If

   End Sub

   Private Sub _DashboardPane_DockPositionChanged(sender As Object, e As EventArgs) Handles _DashboardPane.DockPositionChanged

      Dim paneSize As System.Drawing.Size = New System.Drawing.Size(_DashboardPane.Width, _DashboardPane.Height)
      _Dashboard.Size = paneSize

      If _DashboardPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionFloating Then
         _Dashboard.DockingMode = ucDashboard.enumDockingMode.dmFloating
      ElseIf _DashboardPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionTop Or _DashboardPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionBottom Then
         _Dashboard.DockingMode = ucDashboard.enumDockingMode.dmHorizontal
         '_Dashboard.flpFlow.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
      Else
         _Dashboard.DockingMode = ucDashboard.enumDockingMode.dmVertical
         '_Dashboard.flpFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
      End If

   End Sub

   'Private Sub _DashboardPane_VisibleChanged(sender As Object, e As EventArgs) Handles _DashboardPane.VisibleChanged
   '   If _DashboardPane.Visible Then
   '      _Dashboard.BecomesVisible()
   '   End If
   'End Sub

   Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

      If _Settings IsNot Nothing Then
         _Settings.Save(_SettingsFName)
         DisconnectAll()
      End If

   End Sub

   Private Sub Application_SheetCalculate(Sh As Object) Handles Application.SheetCalculate
      Globals.Ribbons.ribCasparCG.FlagSheetCalculated(Sh)
   End Sub

   Private Sub Application_SheetActivate(Sh As Object) Handles Application.SheetActivate
      Globals.Ribbons.ribCasparCG.FlagSheetActivated(Sh)
   End Sub

   Private Sub Application_WorkbookActivate(Wb As Workbook) Handles Application.WorkbookActivate
      Globals.Ribbons.ribCasparCG.ActiveWorkbook = Wb
      Globals.Ribbons.ribCasparCG.FlagSheetActivated(Wb.ActiveSheet)
      _Dashboard.ActiveWorkbook = Wb
   End Sub

End Class
