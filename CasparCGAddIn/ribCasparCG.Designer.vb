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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ribCasparCG))
      Me.tabCasparCG = Me.Factory.CreateRibbonTab
      Me.grpConnections = Me.Factory.CreateRibbonGroup
      Me.grpSelection = Me.Factory.CreateRibbonGroup
      Me.grpDataset = Me.Factory.CreateRibbonGroup
      Me.grpPreview = Me.Factory.CreateRibbonGroup
      Me.grpInsert = Me.Factory.CreateRibbonGroup
      Me.grpAutoUpdate = Me.Factory.CreateRibbonGroup
      Me.grpView = Me.Factory.CreateRibbonGroup
      Me.Group1 = Me.Factory.CreateRibbonGroup
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
      Me.btnDashboard = Me.Factory.CreateRibbonButton
      Me.btnStartTimer = Me.Factory.CreateRibbonButton
      Me.sepAutoUpdate1 = Me.Factory.CreateRibbonSeparator
      Me.btnRefreshData = Me.Factory.CreateRibbonButton
      Me.sepAutoUpdate2 = Me.Factory.CreateRibbonSeparator
      Me.tabCasparCG.SuspendLayout()
      Me.grpConnections.SuspendLayout()
      Me.grpSelection.SuspendLayout()
      Me.grpDataset.SuspendLayout()
      Me.grpPreview.SuspendLayout()
      Me.grpInsert.SuspendLayout()
      Me.grpAutoUpdate.SuspendLayout()
      Me.grpView.SuspendLayout()
      Me.Group1.SuspendLayout()
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
      Me.tabCasparCG.Groups.Add(Me.Group1)
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
      'grpView
      '
      Me.grpView.Items.Add(Me.btnDashboard)
      Me.grpView.Label = "View"
      Me.grpView.Name = "grpView"
      '
      'Group1
      '
      Me.Group1.Items.Add(Me.btnStartTimer)
      Me.Group1.Label = "Spare"
      Me.Group1.Name = "Group1"
      Me.Group1.Visible = False
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
      'btnStartTimer
      '
      Me.btnStartTimer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnStartTimer.Image = Global.CasparCGAddIn.My.Resources.Resources.StartTime_64x
      Me.btnStartTimer.Label = "Start Timer"
      Me.btnStartTimer.Name = "btnStartTimer"
      Me.btnStartTimer.ShowImage = True
      '
      'sepAutoUpdate1
      '
      Me.sepAutoUpdate1.Name = "sepAutoUpdate1"
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
      'sepAutoUpdate2
      '
      Me.sepAutoUpdate2.Name = "sepAutoUpdate2"
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
      Me.Group1.ResumeLayout(False)
      Me.Group1.PerformLayout()
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
   Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnBrowser As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnBrowserRefresh As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents sepAutoUpdate1 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
   Friend WithEvents sepAutoUpdate2 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
   Friend WithEvents btnRefreshData As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

   <System.Diagnostics.DebuggerNonUserCode()> _
   Friend ReadOnly Property ribCasparCG() As ribCasparCG
      Get
         Return Me.GetRibbon(Of ribCasparCG)()
      End Get
   End Property
End Class
