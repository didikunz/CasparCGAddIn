Partial Class ribCasparCG
   Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

   <System.Diagnostics.DebuggerNonUserCode()>
   Public Sub New(ByVal container As System.ComponentModel.IContainer)
      MyClass.New()

      'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
      If (container IsNot Nothing) Then
         container.Add(Me)
      End If

   End Sub

   <System.Diagnostics.DebuggerNonUserCode()>
   Public Sub New()
      MyBase.New(Globals.Factory.GetRibbonFactory())

      'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
      InitializeComponent()

   End Sub

   'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
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

   'Wird vom Komponenten-Designer benötigt.
   Private components As System.ComponentModel.IContainer

   'Hinweis: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
   'Das Bearbeiten ist mit dem Komponenten-Designer möglich.
   'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim RibbonDialogLauncherImpl1 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl2 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl3 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl4 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl5 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl6 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl7 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ribCasparCG))
      Me.tabCasparCG = Me.Factory.CreateRibbonTab
      Me.grpConnections = Me.Factory.CreateRibbonGroup
      Me.grpSelection = Me.Factory.CreateRibbonGroup
      Me.grpDataset = Me.Factory.CreateRibbonGroup
      Me.grpPreview = Me.Factory.CreateRibbonGroup
      Me.grpInsert = Me.Factory.CreateRibbonGroup
      Me.grpAutoUpdate = Me.Factory.CreateRibbonGroup
      Me.sepAutoUpdate1 = Me.Factory.CreateRibbonSeparator
      Me.sepAutoUpdate2 = Me.Factory.CreateRibbonSeparator
      Me.grpView = Me.Factory.CreateRibbonGroup
      Me.sepView1 = Me.Factory.CreateRibbonSeparator
      Me.grpTimer = Me.Factory.CreateRibbonGroup
      Me.sepTimer1 = Me.Factory.CreateRibbonSeparator
      Me.cboItems = Me.Factory.CreateRibbonComboBox
      Me.txtTimerPreview = Me.Factory.CreateRibbonEditBox
      Me.ButtonGroup1 = Me.Factory.CreateRibbonButtonGroup
      Me.grpLap = Me.Factory.CreateRibbonGroup
      Me.cboLap = Me.Factory.CreateRibbonComboBox
      Me.grpUserFunctions = Me.Factory.CreateRibbonGroup
      Me.togConnect = Me.Factory.CreateRibbonToggleButton
      Me.btnSetOutputRange = Me.Factory.CreateRibbonButton
      Me.btnSaveDataSet = Me.Factory.CreateRibbonButton
      Me.btnSaveAllDataSets = Me.Factory.CreateRibbonButton
      Me.btnPreview = Me.Factory.CreateRibbonButton
      Me.btnImageFile = Me.Factory.CreateRibbonButton
      Me.btnBaseFolder = Me.Factory.CreateRibbonButton
      Me.btnColor = Me.Factory.CreateRibbonButton
      Me.togAutoUpdate = Me.Factory.CreateRibbonToggleButton
      Me.btnBrowser = Me.Factory.CreateRibbonButton
      Me.btnBrowserRefresh = Me.Factory.CreateRibbonButton
      Me.btnRefreshData = Me.Factory.CreateRibbonButton
      Me.btnDashboard = Me.Factory.CreateRibbonButton
      Me.btnListPane = Me.Factory.CreateRibbonButton
      Me.btnTimerPane = Me.Factory.CreateRibbonButton
      Me.btnTimerPlus = Me.Factory.CreateRibbonButton
      Me.btnTimerMinus = Me.Factory.CreateRibbonButton
      Me.btnStartTimer = Me.Factory.CreateRibbonButton
      Me.btnPauseTimer = Me.Factory.CreateRibbonButton
      Me.btnStopTimer = Me.Factory.CreateRibbonButton
      Me.btnLapPause = Me.Factory.CreateRibbonButton
      Me.btnLapResume = Me.Factory.CreateRibbonButton
      Me.btnUserFunction1 = Me.Factory.CreateRibbonButton
      Me.btnUserFunction2 = Me.Factory.CreateRibbonButton
      Me.btnUserFunction3 = Me.Factory.CreateRibbonButton
      Me.btnUserFunction4 = Me.Factory.CreateRibbonButton
      Me.btnUserFunction5 = Me.Factory.CreateRibbonButton
      Me.btnUserFunction6 = Me.Factory.CreateRibbonButton
      Me.btnUserFunction7 = Me.Factory.CreateRibbonButton
      Me.btnUserFunction8 = Me.Factory.CreateRibbonButton
      Me.btnUserFunction9 = Me.Factory.CreateRibbonButton
      Me.tabCasparCG.SuspendLayout()
      Me.grpConnections.SuspendLayout()
      Me.grpSelection.SuspendLayout()
      Me.grpDataset.SuspendLayout()
      Me.grpPreview.SuspendLayout()
      Me.grpInsert.SuspendLayout()
      Me.grpAutoUpdate.SuspendLayout()
      Me.grpView.SuspendLayout()
      Me.grpTimer.SuspendLayout()
      Me.ButtonGroup1.SuspendLayout()
      Me.grpLap.SuspendLayout()
      Me.grpUserFunctions.SuspendLayout()
      Me.SuspendLayout()
      '
      'tabCasparCG
      '
      Me.tabCasparCG.Groups.Add(Me.grpConnections)
      Me.tabCasparCG.Groups.Add(Me.grpSelection)
      Me.tabCasparCG.Groups.Add(Me.grpDataset)
      Me.tabCasparCG.Groups.Add(Me.grpPreview)
      Me.tabCasparCG.Groups.Add(Me.grpInsert)
      Me.tabCasparCG.Groups.Add(Me.grpAutoUpdate)
      Me.tabCasparCG.Groups.Add(Me.grpView)
      Me.tabCasparCG.Groups.Add(Me.grpTimer)
      Me.tabCasparCG.Groups.Add(Me.grpLap)
      Me.tabCasparCG.Groups.Add(Me.grpUserFunctions)
      Me.tabCasparCG.Label = "CasparCG"
      Me.tabCasparCG.Name = "tabCasparCG"
      '
      'grpConnections
      '
      Me.grpConnections.DialogLauncher = RibbonDialogLauncherImpl1
      Me.grpConnections.Items.Add(Me.togConnect)
      Me.grpConnections.Label = "Servers"
      Me.grpConnections.Name = "grpConnections"
      '
      'grpSelection
      '
      Me.grpSelection.Items.Add(Me.btnSetOutputRange)
      Me.grpSelection.Label = "Selection"
      Me.grpSelection.Name = "grpSelection"
      '
      'grpDataset
      '
      Me.grpDataset.DialogLauncher = RibbonDialogLauncherImpl2
      Me.grpDataset.Items.Add(Me.btnSaveDataSet)
      Me.grpDataset.Items.Add(Me.btnSaveAllDataSets)
      Me.grpDataset.Label = "Data-Sets"
      Me.grpDataset.Name = "grpDataset"
      '
      'grpPreview
      '
      Me.grpPreview.DialogLauncher = RibbonDialogLauncherImpl3
      Me.grpPreview.Items.Add(Me.btnPreview)
      Me.grpPreview.Label = "Preview"
      Me.grpPreview.Name = "grpPreview"
      '
      'grpInsert
      '
      Me.grpInsert.Items.Add(Me.btnImageFile)
      Me.grpInsert.Items.Add(Me.btnBaseFolder)
      Me.grpInsert.Items.Add(Me.btnColor)
      Me.grpInsert.Label = "Insert"
      Me.grpInsert.Name = "grpInsert"
      '
      'grpAutoUpdate
      '
      Me.grpAutoUpdate.DialogLauncher = RibbonDialogLauncherImpl4
      Me.grpAutoUpdate.Items.Add(Me.togAutoUpdate)
      Me.grpAutoUpdate.Items.Add(Me.sepAutoUpdate1)
      Me.grpAutoUpdate.Items.Add(Me.btnBrowser)
      Me.grpAutoUpdate.Items.Add(Me.btnBrowserRefresh)
      Me.grpAutoUpdate.Items.Add(Me.sepAutoUpdate2)
      Me.grpAutoUpdate.Items.Add(Me.btnRefreshData)
      Me.grpAutoUpdate.Label = "Data"
      Me.grpAutoUpdate.Name = "grpAutoUpdate"
      '
      'sepAutoUpdate1
      '
      Me.sepAutoUpdate1.Name = "sepAutoUpdate1"
      '
      'sepAutoUpdate2
      '
      Me.sepAutoUpdate2.Name = "sepAutoUpdate2"
      '
      'grpView
      '
      Me.grpView.Items.Add(Me.btnDashboard)
      Me.grpView.Items.Add(Me.sepView1)
      Me.grpView.Items.Add(Me.btnListPane)
      Me.grpView.Items.Add(Me.btnTimerPane)
      Me.grpView.Label = "View"
      Me.grpView.Name = "grpView"
      '
      'sepView1
      '
      Me.sepView1.Name = "sepView1"
      '
      'grpTimer
      '
      Me.grpTimer.DialogLauncher = RibbonDialogLauncherImpl5
      Me.grpTimer.Items.Add(Me.cboItems)
      Me.grpTimer.Items.Add(Me.txtTimerPreview)
      Me.grpTimer.Items.Add(Me.ButtonGroup1)
      Me.grpTimer.Items.Add(Me.sepTimer1)
      Me.grpTimer.Items.Add(Me.btnStartTimer)
      Me.grpTimer.Items.Add(Me.btnPauseTimer)
      Me.grpTimer.Items.Add(Me.btnStopTimer)
      Me.grpTimer.Label = "Timer"
      Me.grpTimer.Name = "grpTimer"
      '
      'sepTimer1
      '
      Me.sepTimer1.Name = "sepTimer1"
      '
      'cboItems
      '
      Me.cboItems.Label = "ComboBox1"
      Me.cboItems.Name = "cboItems"
      Me.cboItems.ScreenTip = "Selected Item"
      Me.cboItems.ShowLabel = False
      Me.cboItems.SuperTip = "Select the current timer-item to be handled."
      Me.cboItems.Text = Nothing
      '
      'txtTimerPreview
      '
      Me.txtTimerPreview.Label = "EditBox1"
      Me.txtTimerPreview.MaxLength = 15
      Me.txtTimerPreview.Name = "txtTimerPreview"
      Me.txtTimerPreview.ScreenTip = "Timer preview"
      Me.txtTimerPreview.ShowLabel = False
      Me.txtTimerPreview.SizeString = "00:00:00:00:00:00"
      Me.txtTimerPreview.SuperTip = "Displays the timers current time"
      Me.txtTimerPreview.Text = Nothing
      '
      'ButtonGroup1
      '
      Me.ButtonGroup1.Items.Add(Me.btnTimerPlus)
      Me.ButtonGroup1.Items.Add(Me.btnTimerMinus)
      Me.ButtonGroup1.Name = "ButtonGroup1"
      '
      'grpLap
      '
      Me.grpLap.DialogLauncher = RibbonDialogLauncherImpl6
      Me.grpLap.Items.Add(Me.cboLap)
      Me.grpLap.Items.Add(Me.btnLapPause)
      Me.grpLap.Items.Add(Me.btnLapResume)
      Me.grpLap.Label = "Laps"
      Me.grpLap.Name = "grpLap"
      '
      'cboLap
      '
      Me.cboLap.Label = "Lap"
      Me.cboLap.Name = "cboLap"
      Me.cboLap.ScreenTip = "Select Lap"
      Me.cboLap.ShowItemImage = False
      Me.cboLap.ShowLabel = False
      Me.cboLap.SuperTip = "Select the Lap to handle"
      Me.cboLap.Text = Nothing
      '
      'grpUserFunctions
      '
      Me.grpUserFunctions.DialogLauncher = RibbonDialogLauncherImpl7
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction1)
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction2)
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction3)
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction4)
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction5)
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction6)
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction7)
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction8)
      Me.grpUserFunctions.Items.Add(Me.btnUserFunction9)
      Me.grpUserFunctions.Label = "User functions"
      Me.grpUserFunctions.Name = "grpUserFunctions"
      Me.grpUserFunctions.Visible = False
      '
      'togConnect
      '
      Me.togConnect.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.togConnect.Image = CType(resources.GetObject("togConnect.Image"), System.Drawing.Image)
      Me.togConnect.Label = "Connect"
      Me.togConnect.Name = "togConnect"
      Me.togConnect.ScreenTip = "Connect to CasparCG-Server(s)"
      Me.togConnect.ShowImage = True
      Me.togConnect.SuperTip = "Connects or disconnects from the server(s). Setup the servers using the dialog-la" &
    "uncher bellow."
      '
      'btnSetOutputRange
      '
      Me.btnSetOutputRange.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnSetOutputRange.Image = Global.CasparCGAddIn.My.Resources.Resources.Select_Range
      Me.btnSetOutputRange.Label = "Set Output Range"
      Me.btnSetOutputRange.Name = "btnSetOutputRange"
      Me.btnSetOutputRange.ScreenTip = "Set Output Range"
      Me.btnSetOutputRange.ShowImage = True
      Me.btnSetOutputRange.SuperTip = "Set the Excel-range that is sent to CasparCG."
      '
      'btnSaveDataSet
      '
      Me.btnSaveDataSet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnSaveDataSet.Enabled = False
      Me.btnSaveDataSet.Image = Global.CasparCGAddIn.My.Resources.Resources.Save_Dataset
      Me.btnSaveDataSet.Label = "Save"
      Me.btnSaveDataSet.Name = "btnSaveDataSet"
      Me.btnSaveDataSet.ScreenTip = "Save Data-Set"
      Me.btnSaveDataSet.ShowImage = True
      Me.btnSaveDataSet.SuperTip = "Saves the Data-Set of the current worksheet to CasparCG."
      '
      'btnSaveAllDataSets
      '
      Me.btnSaveAllDataSets.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnSaveAllDataSets.Enabled = False
      Me.btnSaveAllDataSets.Image = Global.CasparCGAddIn.My.Resources.Resources.Save_All_Datasets
      Me.btnSaveAllDataSets.Label = "Save All"
      Me.btnSaveAllDataSets.Name = "btnSaveAllDataSets"
      Me.btnSaveAllDataSets.ScreenTip = "Save all Data-Sets"
      Me.btnSaveAllDataSets.ShowImage = True
      Me.btnSaveAllDataSets.SuperTip = "Safe all Data-Sets of all worksheets to CasparCG."
      '
      'btnPreview
      '
      Me.btnPreview.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnPreview.Enabled = False
      Me.btnPreview.Image = Global.CasparCGAddIn.My.Resources.Resources.Preview
      Me.btnPreview.Label = "Show Preview"
      Me.btnPreview.Name = "btnPreview"
      Me.btnPreview.ScreenTip = "Show Preview"
      Me.btnPreview.ShowImage = True
      Me.btnPreview.SuperTip = "Shows the current worksheet on CasparCG's preview channel (if one is defined)."
      '
      'btnImageFile
      '
      Me.btnImageFile.Image = Global.CasparCGAddIn.My.Resources.Resources.Open_Image
      Me.btnImageFile.Label = "Image Filenane"
      Me.btnImageFile.Name = "btnImageFile"
      Me.btnImageFile.ScreenTip = "Image-Filename"
      Me.btnImageFile.ShowImage = True
      Me.btnImageFile.SuperTip = "Inserts the filename of an image into the current cell. The file-url format is us" &
    "ed."
      '
      'btnBaseFolder
      '
      Me.btnBaseFolder.Image = Global.CasparCGAddIn.My.Resources.Resources.Base_Folder
      Me.btnBaseFolder.Label = "Set Default-Folder"
      Me.btnBaseFolder.Name = "btnBaseFolder"
      Me.btnBaseFolder.ScreenTip = "Set Default-Folder"
      Me.btnBaseFolder.ShowImage = True
      Me.btnBaseFolder.SuperTip = "Sets the default-folder, from where images will be loaded."
      '
      'btnColor
      '
      Me.btnColor.Image = Global.CasparCGAddIn.My.Resources.Resources.Paint_Palette
      Me.btnColor.Label = "Color Code"
      Me.btnColor.Name = "btnColor"
      Me.btnColor.ScreenTip = "Color Code"
      Me.btnColor.ShowImage = True
      Me.btnColor.SuperTip = "Insert a color into the current cell. The color will be formated as a hexadecimal" &
    " number."
      '
      'togAutoUpdate
      '
      Me.togAutoUpdate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.togAutoUpdate.Image = Global.CasparCGAddIn.My.Resources.Resources.Synchronize
      Me.togAutoUpdate.Label = "Auto Update"
      Me.togAutoUpdate.Name = "togAutoUpdate"
      Me.togAutoUpdate.ScreenTip = "Toggle Auto-Update"
      Me.togAutoUpdate.ShowImage = True
      Me.togAutoUpdate.SuperTip = "If activated perform an auto-update for the current worksheet."
      '
      'btnBrowser
      '
      Me.btnBrowser.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnBrowser.Image = Global.CasparCGAddIn.My.Resources.Resources.ASPNETWeb_64x
      Me.btnBrowser.Label = "Browser Import"
      Me.btnBrowser.Name = "btnBrowser"
      Me.btnBrowser.ScreenTip = "Import data from a browser"
      Me.btnBrowser.ShowImage = True
      Me.btnBrowser.SuperTip = "Allows the definition of a web-browser data-import."
      '
      'btnBrowserRefresh
      '
      Me.btnBrowserRefresh.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnBrowserRefresh.Image = CType(resources.GetObject("btnBrowserRefresh.Image"), System.Drawing.Image)
      Me.btnBrowserRefresh.Label = "Browser Refresh"
      Me.btnBrowserRefresh.Name = "btnBrowserRefresh"
      Me.btnBrowserRefresh.ScreenTip = "Refreshes data from a browser"
      Me.btnBrowserRefresh.ShowImage = True
      Me.btnBrowserRefresh.SuperTip = "Refreshes the data for the current worksheet."
      '
      'btnRefreshData
      '
      Me.btnRefreshData.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnRefreshData.Image = Global.CasparCGAddIn.My.Resources.Resources.PreviewRefresh
      Me.btnRefreshData.Label = "Refresh All"
      Me.btnRefreshData.Name = "btnRefreshData"
      Me.btnRefreshData.ScreenTip = "Refresh all data"
      Me.btnRefreshData.ShowImage = True
      Me.btnRefreshData.SuperTip = "Refreshes all data from all browser imports and Power Queries"
      '
      'btnDashboard
      '
      Me.btnDashboard.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnDashboard.Image = Global.CasparCGAddIn.My.Resources.Resources.GaugeMeter
      Me.btnDashboard.Label = "Dashboard"
      Me.btnDashboard.Name = "btnDashboard"
      Me.btnDashboard.ScreenTip = "View Dashboard"
      Me.btnDashboard.ShowImage = True
      Me.btnDashboard.SuperTip = "Shows the CasparCG Dashboard"
      '
      'btnListPane
      '
      Me.btnListPane.Image = Global.CasparCGAddIn.My.Resources.Resources.FlatList_16x
      Me.btnListPane.Label = "List-pane"
      Me.btnListPane.Name = "btnListPane"
      Me.btnListPane.ScreenTip = "View list pane"
      Me.btnListPane.ShowImage = True
      Me.btnListPane.SuperTip = "Shows the list pane inside the CasparCG Dashboard"
      '
      'btnTimerPane
      '
      Me.btnTimerPane.Image = Global.CasparCGAddIn.My.Resources.Resources.TimerPane
      Me.btnTimerPane.Label = "Timer Groups"
      Me.btnTimerPane.Name = "btnTimerPane"
      Me.btnTimerPane.ScreenTip = "Timer Group"
      Me.btnTimerPane.ShowImage = True
      Me.btnTimerPane.SuperTip = "Show the timer group"
      '
      'btnTimerPlus
      '
      Me.btnTimerPlus.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Plus
      Me.btnTimerPlus.Label = "Plus"
      Me.btnTimerPlus.Name = "btnTimerPlus"
      Me.btnTimerPlus.ScreenTip = "Plus"
      Me.btnTimerPlus.ShowImage = True
      Me.btnTimerPlus.SuperTip = "Plus one second"
      '
      'btnTimerMinus
      '
      Me.btnTimerMinus.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Minus
      Me.btnTimerMinus.Label = "Minus"
      Me.btnTimerMinus.Name = "btnTimerMinus"
      Me.btnTimerMinus.ScreenTip = "Minus"
      Me.btnTimerMinus.ShowImage = True
      Me.btnTimerMinus.SuperTip = "Minus one second"
      '
      'btnStartTimer
      '
      Me.btnStartTimer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnStartTimer.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Start
      Me.btnStartTimer.Label = "Start"
      Me.btnStartTimer.Name = "btnStartTimer"
      Me.btnStartTimer.ScreenTip = "Start Timer"
      Me.btnStartTimer.ShowImage = True
      Me.btnStartTimer.SuperTip = "Start the timer"
      '
      'btnPauseTimer
      '
      Me.btnPauseTimer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnPauseTimer.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Pause
      Me.btnPauseTimer.Label = "Pause"
      Me.btnPauseTimer.Name = "btnPauseTimer"
      Me.btnPauseTimer.ScreenTip = "Pause Timer"
      Me.btnPauseTimer.ShowImage = True
      Me.btnPauseTimer.SuperTip = "Pause the timer. Suspends the timer."
      Me.btnPauseTimer.Visible = False
      '
      'btnStopTimer
      '
      Me.btnStopTimer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnStopTimer.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Stop
      Me.btnStopTimer.Label = "Stop"
      Me.btnStopTimer.Name = "btnStopTimer"
      Me.btnStopTimer.ScreenTip = "Stop Timer"
      Me.btnStopTimer.ShowImage = True
      Me.btnStopTimer.SuperTip = "Stops the timer"
      '
      'btnLapPause
      '
      Me.btnLapPause.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Lap
      Me.btnLapPause.Label = "Lap Pause"
      Me.btnLapPause.Name = "btnLapPause"
      Me.btnLapPause.ScreenTip = "Lap Pause"
      Me.btnLapPause.ShowImage = True
      Me.btnLapPause.SuperTip = "Stops the timer to show a a lap"
      '
      'btnLapResume
      '
      Me.btnLapResume.Image = Global.CasparCGAddIn.My.Resources.Resources.Timer_Resume
      Me.btnLapResume.Label = "Lap Resume"
      Me.btnLapResume.Name = "btnLapResume"
      Me.btnLapResume.ScreenTip = "Lap Resume"
      Me.btnLapResume.ShowImage = True
      Me.btnLapResume.SuperTip = "Resumes the running timer display"
      '
      'btnUserFunction1
      '
      Me.btnUserFunction1.Image = Global.CasparCGAddIn.My.Resources.Resources.F1
      Me.btnUserFunction1.Label = "User Function"
      Me.btnUserFunction1.Name = "btnUserFunction1"
      Me.btnUserFunction1.ScreenTip = "User Function"
      Me.btnUserFunction1.ShowImage = True
      Me.btnUserFunction1.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction1.Tag = "1"
      '
      'btnUserFunction2
      '
      Me.btnUserFunction2.Image = Global.CasparCGAddIn.My.Resources.Resources.F2
      Me.btnUserFunction2.Label = "User Function"
      Me.btnUserFunction2.Name = "btnUserFunction2"
      Me.btnUserFunction2.ScreenTip = "User Function"
      Me.btnUserFunction2.ShowImage = True
      Me.btnUserFunction2.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction2.Tag = "2"
      '
      'btnUserFunction3
      '
      Me.btnUserFunction3.Image = Global.CasparCGAddIn.My.Resources.Resources.F3
      Me.btnUserFunction3.Label = "User Function"
      Me.btnUserFunction3.Name = "btnUserFunction3"
      Me.btnUserFunction3.ScreenTip = "User Function"
      Me.btnUserFunction3.ShowImage = True
      Me.btnUserFunction3.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction3.Tag = "3"
      '
      'btnUserFunction4
      '
      Me.btnUserFunction4.Image = Global.CasparCGAddIn.My.Resources.Resources.F4
      Me.btnUserFunction4.Label = "User Function"
      Me.btnUserFunction4.Name = "btnUserFunction4"
      Me.btnUserFunction4.ScreenTip = "User Function"
      Me.btnUserFunction4.ShowImage = True
      Me.btnUserFunction4.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction4.Tag = "4"
      '
      'btnUserFunction5
      '
      Me.btnUserFunction5.Image = Global.CasparCGAddIn.My.Resources.Resources.F5
      Me.btnUserFunction5.Label = "User Function"
      Me.btnUserFunction5.Name = "btnUserFunction5"
      Me.btnUserFunction5.ScreenTip = "User Function"
      Me.btnUserFunction5.ShowImage = True
      Me.btnUserFunction5.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction5.Tag = "5"
      '
      'btnUserFunction6
      '
      Me.btnUserFunction6.Image = Global.CasparCGAddIn.My.Resources.Resources.F6
      Me.btnUserFunction6.Label = "User Function"
      Me.btnUserFunction6.Name = "btnUserFunction6"
      Me.btnUserFunction6.ScreenTip = "User Function"
      Me.btnUserFunction6.ShowImage = True
      Me.btnUserFunction6.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction6.Tag = "6"
      '
      'btnUserFunction7
      '
      Me.btnUserFunction7.Image = Global.CasparCGAddIn.My.Resources.Resources.F7
      Me.btnUserFunction7.Label = "User Function"
      Me.btnUserFunction7.Name = "btnUserFunction7"
      Me.btnUserFunction7.ScreenTip = "User Function"
      Me.btnUserFunction7.ShowImage = True
      Me.btnUserFunction7.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction7.Tag = "7"
      '
      'btnUserFunction8
      '
      Me.btnUserFunction8.Image = Global.CasparCGAddIn.My.Resources.Resources.F8
      Me.btnUserFunction8.Label = "User Function"
      Me.btnUserFunction8.Name = "btnUserFunction8"
      Me.btnUserFunction8.ScreenTip = "User Function"
      Me.btnUserFunction8.ShowImage = True
      Me.btnUserFunction8.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction8.Tag = "8"
      '
      'btnUserFunction9
      '
      Me.btnUserFunction9.Image = Global.CasparCGAddIn.My.Resources.Resources.F9
      Me.btnUserFunction9.Label = "User Function"
      Me.btnUserFunction9.Name = "btnUserFunction9"
      Me.btnUserFunction9.ScreenTip = "User Function"
      Me.btnUserFunction9.ShowImage = True
      Me.btnUserFunction9.SuperTip = "Triggers a user function by running a script"
      Me.btnUserFunction9.Tag = "9"
      '
      'ribCasparCG
      '
      Me.Name = "ribCasparCG"
      Me.RibbonType = "Microsoft.Excel.Workbook"
      Me.Tabs.Add(Me.tabCasparCG)
      Me.tabCasparCG.ResumeLayout(False)
      Me.tabCasparCG.PerformLayout()
      Me.grpConnections.ResumeLayout(False)
      Me.grpConnections.PerformLayout()
      Me.grpSelection.ResumeLayout(False)
      Me.grpSelection.PerformLayout()
      Me.grpDataset.ResumeLayout(False)
      Me.grpDataset.PerformLayout()
      Me.grpPreview.ResumeLayout(False)
      Me.grpPreview.PerformLayout()
      Me.grpInsert.ResumeLayout(False)
      Me.grpInsert.PerformLayout()
      Me.grpAutoUpdate.ResumeLayout(False)
      Me.grpAutoUpdate.PerformLayout()
      Me.grpView.ResumeLayout(False)
      Me.grpView.PerformLayout()
      Me.grpTimer.ResumeLayout(False)
      Me.grpTimer.PerformLayout()
      Me.ButtonGroup1.ResumeLayout(False)
      Me.ButtonGroup1.PerformLayout()
      Me.grpLap.ResumeLayout(False)
      Me.grpLap.PerformLayout()
      Me.grpUserFunctions.ResumeLayout(False)
      Me.grpUserFunctions.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents tabCasparCG As Microsoft.Office.Tools.Ribbon.RibbonTab
   Friend WithEvents grpSelection As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnSetOutputRange As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents grpDataset As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnSaveDataSet As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnSaveAllDataSets As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents grpPreview As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnPreview As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents grpConnections As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents togConnect As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
   Friend WithEvents grpInsert As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnImageFile As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnColor As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnBaseFolder As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnStartTimer As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents grpAutoUpdate As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents togAutoUpdate As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
   Friend WithEvents grpView As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnDashboard As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents grpTimer As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnBrowser As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnBrowserRefresh As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents sepAutoUpdate1 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
   Friend WithEvents sepAutoUpdate2 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
   Friend WithEvents btnRefreshData As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents sepView1 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
   Friend WithEvents btnListPane As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnTimerPane As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnPauseTimer As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnStopTimer As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents sepTimer1 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
   Friend WithEvents btnTimerPlus As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnTimerMinus As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents txtTimerPreview As Microsoft.Office.Tools.Ribbon.RibbonEditBox
   Friend WithEvents grpLap As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents cboLap As Microsoft.Office.Tools.Ribbon.RibbonComboBox
   Friend WithEvents btnLapPause As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnLapResume As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents grpUserFunctions As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnUserFunction1 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnUserFunction2 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnUserFunction3 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnUserFunction4 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnUserFunction5 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnUserFunction6 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnUserFunction7 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnUserFunction8 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnUserFunction9 As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents cboItems As Microsoft.Office.Tools.Ribbon.RibbonComboBox
   Friend WithEvents ButtonGroup1 As Microsoft.Office.Tools.Ribbon.RibbonButtonGroup
End Class

Partial Class ThisRibbonCollection

   <System.Diagnostics.DebuggerNonUserCode()> _
   Friend ReadOnly Property ribCasparCG() As ribCasparCG
      Get
         Return Me.GetRibbon(Of ribCasparCG)()
      End Get
   End Property
End Class
