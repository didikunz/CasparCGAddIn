Imports Microsoft.Office.Interop.Excel
Imports CasparObjects

Public Class ThisAddIn

   Private _Settings As Settings
   Private _SettingsFName As String
   Private _IsCasparConnected As Boolean = False

   Private _CasparRibon As ribCasparCG

   Private _Dashboard As ucDashboard
   Private WithEvents _DashboardPane As Microsoft.Office.Tools.CustomTaskPane

   Private _sheetDeleteInProgress As Boolean = False

   Public ReadOnly Property IsCasparConnected As Boolean
      Get
         Return _IsCasparConnected
      End Get
   End Property

   Public Sub ConnectAll(useAveco As Boolean)

      Dim errText As String = ""

      For Each caspar In _Settings.Servers

         If Not caspar.Connected Then

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

         Else
            caspar.AddAvecoFields = useAveco
         End If

      Next

      If errText <> "" Then

         MsgBox(errText, MsgBoxStyle.Exclamation, "Connection problem")

         If _CasparRibon IsNot Nothing Then _CasparRibon.IsCasparConnected = False
         If _Dashboard IsNot Nothing Then _Dashboard.IsCasparConnected = False
         _IsCasparConnected = False

      Else

         If _CasparRibon IsNot Nothing Then _CasparRibon.IsCasparConnected = True
         If _Dashboard IsNot Nothing Then _Dashboard.IsCasparConnected = True
         _IsCasparConnected = True

      End If

   End Sub

   Public Sub DisconnectAll()

      For Each caspar In _Settings.Servers

         If caspar.Connected Then
            caspar.Disconnect()
         End If

         If _CasparRibon IsNot Nothing Then _CasparRibon.IsCasparConnected = False
         If _Dashboard IsNot Nothing Then _Dashboard.IsCasparConnected = False
         _IsCasparConnected = False

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

      _CasparRibon = Globals.Ribbons.ribCasparCG

      _Dashboard = New ucDashboard
      _DashboardPane = Me.CustomTaskPanes.Add(_Dashboard, "CasparCG Dashboard")
      _DashboardPane.Visible = _Settings.DashboardVisible

      _Dashboard.Settings = _Settings
      _Dashboard.CasparRibon = _CasparRibon

      _CasparRibon.Settings = _Settings
      _CasparRibon.SetDashboardObjects(_Dashboard, _DashboardPane)

   End Sub

   Private Sub _DashboardPane_DockPositionChanged(sender As Object, e As EventArgs) Handles _DashboardPane.DockPositionChanged

      Dim paneSize As System.Drawing.Size = New System.Drawing.Size(_DashboardPane.Width, _DashboardPane.Height)
      _Dashboard.Size = paneSize

      If _DashboardPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionFloating Then
         _Dashboard.DockingMode = ucDashboard.enumDockingMode.dmFloating
      ElseIf _DashboardPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionTop Or _DashboardPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionBottom Then
         _Dashboard.DockingMode = ucDashboard.enumDockingMode.dmHorizontal
      Else
         _Dashboard.DockingMode = ucDashboard.enumDockingMode.dmVertical
      End If

   End Sub


   Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

      If _Settings IsNot Nothing Then
         _Settings.Save(_SettingsFName)
         DisconnectAll()
      End If

   End Sub

   Private Sub Application_AfterCalculate() Handles Application.AfterCalculate
      If _CasparRibon IsNot Nothing Then
         _CasparRibon.FlagAfterCalculate()
      End If
      If _Dashboard IsNot Nothing Then
         _Dashboard.FlagAfterCalculate()
      End If
   End Sub

   Private Sub Application_SheetCalculate(Sh As Object) Handles Application.SheetCalculate
      If _CasparRibon IsNot Nothing Then
         _CasparRibon.FlagSheetCalculated(Sh)
      End If
   End Sub

   Private Sub Application_SheetBeforeDelete(Sh As Object) Handles Application.SheetBeforeDelete
      _sheetDeleteInProgress = True
   End Sub

   Private Sub Application_SheetActivate(Sh As Object) Handles Application.SheetActivate

      If _CasparRibon IsNot Nothing Then
         _CasparRibon.FlagSheetActivated(Sh)
      End If

      If _sheetDeleteInProgress AndAlso _Dashboard IsNot Nothing Then
         _Dashboard.RefreshPlaybackControls()
      End If

      _sheetDeleteInProgress = False

   End Sub

   Private Sub Application_WorkbookActivate(Wb As Workbook) Handles Application.WorkbookActivate

      If _Settings.ConnectOnStartUp And Not _IsCasparConnected Then

         Dim isCasparWookkbook As Boolean = False
         For Each ws As Worksheet In Wb.Sheets

            For Each name As Excel.Name In ws.Names

               If name.Name.Contains("CasparOutput") Then
                  isCasparWookkbook = True
                  Exit For
               End If

            Next

            If isCasparWookkbook Then
               Exit For
            End If

         Next

         If isCasparWookkbook Then
            ConnectAll(_Settings.UseAveco)
         End If

      End If

      If _CasparRibon IsNot Nothing Then
         _CasparRibon.ActiveWorkbook = Wb
         _CasparRibon.FlagSheetActivated(Wb.ActiveSheet)
      End If

      If _Dashboard IsNot Nothing Then
         _Dashboard.ActiveWorkbook = Wb
      End If

   End Sub

End Class
