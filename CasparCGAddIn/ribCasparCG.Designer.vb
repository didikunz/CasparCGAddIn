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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ribCasparCG))
      Dim RibbonDialogLauncherImpl2 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl3 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl4 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl5 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Dim RibbonDialogLauncherImpl6 As Microsoft.Office.Tools.Ribbon.RibbonDialogLauncher = Me.Factory.CreateRibbonDialogLauncher
      Me.tabCasparCG = Me.Factory.CreateRibbonTab
      Me.grpConnections = Me.Factory.CreateRibbonGroup
      Me.togConnect = Me.Factory.CreateRibbonToggleButton
      Me.grpSelection = Me.Factory.CreateRibbonGroup
      Me.btnSetOutputRange = Me.Factory.CreateRibbonButton
      Me.grpDataset = Me.Factory.CreateRibbonGroup
      Me.btnSaveDataSet = Me.Factory.CreateRibbonButton
      Me.btnSaveAllDataSets = Me.Factory.CreateRibbonButton
      Me.grpPreview = Me.Factory.CreateRibbonGroup
      Me.btnPreview = Me.Factory.CreateRibbonButton
      Me.togLiveUpdate = Me.Factory.CreateRibbonToggleButton
      Me.grpInsert = Me.Factory.CreateRibbonGroup
      Me.btnImageFile = Me.Factory.CreateRibbonButton
      Me.btnBaseFolder = Me.Factory.CreateRibbonButton
      Me.btnColor = Me.Factory.CreateRibbonButton
      Me.grpWeb = Me.Factory.CreateRibbonGroup
      Me.btnWeb = Me.Factory.CreateRibbonButton
      Me.btnStartTimer = Me.Factory.CreateRibbonButton
      Me.grpAutoUpdate = Me.Factory.CreateRibbonGroup
      Me.togAutoUpdate = Me.Factory.CreateRibbonToggleButton
      Me.grpView = Me.Factory.CreateRibbonGroup
      Me.btnDashboard = Me.Factory.CreateRibbonButton
      Me.btnTest = Me.Factory.CreateRibbonButton
      Me.tabCasparCG.SuspendLayout()
      Me.grpConnections.SuspendLayout()
      Me.grpSelection.SuspendLayout()
      Me.grpDataset.SuspendLayout()
      Me.grpPreview.SuspendLayout()
      Me.grpInsert.SuspendLayout()
      Me.grpWeb.SuspendLayout()
      Me.grpAutoUpdate.SuspendLayout()
      Me.grpView.SuspendLayout()
      Me.SuspendLayout()
      '
      'tabCasparCG
      '
      Me.tabCasparCG.Groups.Add(Me.grpConnections)
      Me.tabCasparCG.Groups.Add(Me.grpSelection)
      Me.tabCasparCG.Groups.Add(Me.grpDataset)
      Me.tabCasparCG.Groups.Add(Me.grpPreview)
      Me.tabCasparCG.Groups.Add(Me.grpInsert)
      Me.tabCasparCG.Groups.Add(Me.grpWeb)
      Me.tabCasparCG.Groups.Add(Me.grpAutoUpdate)
      Me.tabCasparCG.Groups.Add(Me.grpView)
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
      'togConnect
      '
      Me.togConnect.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.togConnect.Image = CType(resources.GetObject("togConnect.Image"), System.Drawing.Image)
      Me.togConnect.Label = "Connect"
      Me.togConnect.Name = "togConnect"
      Me.togConnect.ShowImage = True
      '
      'grpSelection
      '
      Me.grpSelection.DialogLauncher = RibbonDialogLauncherImpl2
      Me.grpSelection.Items.Add(Me.btnSetOutputRange)
      Me.grpSelection.Label = "Selection"
      Me.grpSelection.Name = "grpSelection"
      '
      'btnSetOutputRange
      '
      Me.btnSetOutputRange.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnSetOutputRange.Image = Global.CasparCGAddIn.My.Resources.Resources.Select_Range
      Me.btnSetOutputRange.Label = "Set Output Range"
      Me.btnSetOutputRange.Name = "btnSetOutputRange"
      Me.btnSetOutputRange.ShowImage = True
      '
      'grpDataset
      '
      Me.grpDataset.DialogLauncher = RibbonDialogLauncherImpl3
      Me.grpDataset.Items.Add(Me.btnSaveDataSet)
      Me.grpDataset.Items.Add(Me.btnSaveAllDataSets)
      Me.grpDataset.Label = "Data-Sets"
      Me.grpDataset.Name = "grpDataset"
      '
      'btnSaveDataSet
      '
      Me.btnSaveDataSet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnSaveDataSet.Enabled = False
      Me.btnSaveDataSet.Image = Global.CasparCGAddIn.My.Resources.Resources.Save_Dataset
      Me.btnSaveDataSet.Label = "Save"
      Me.btnSaveDataSet.Name = "btnSaveDataSet"
      Me.btnSaveDataSet.ShowImage = True
      '
      'btnSaveAllDataSets
      '
      Me.btnSaveAllDataSets.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnSaveAllDataSets.Enabled = False
      Me.btnSaveAllDataSets.Image = Global.CasparCGAddIn.My.Resources.Resources.Save_All_Datasets
      Me.btnSaveAllDataSets.Label = "Save All"
      Me.btnSaveAllDataSets.Name = "btnSaveAllDataSets"
      Me.btnSaveAllDataSets.ShowImage = True
      '
      'grpPreview
      '
      Me.grpPreview.DialogLauncher = RibbonDialogLauncherImpl4
      Me.grpPreview.Items.Add(Me.btnPreview)
      Me.grpPreview.Items.Add(Me.togLiveUpdate)
      Me.grpPreview.Label = "Preview"
      Me.grpPreview.Name = "grpPreview"
      '
      'btnPreview
      '
      Me.btnPreview.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnPreview.Enabled = False
      Me.btnPreview.Image = Global.CasparCGAddIn.My.Resources.Resources.Preview
      Me.btnPreview.Label = "Show Preview"
      Me.btnPreview.Name = "btnPreview"
      Me.btnPreview.ShowImage = True
      '
      'togLiveUpdate
      '
      Me.togLiveUpdate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.togLiveUpdate.Enabled = False
      Me.togLiveUpdate.Image = Global.CasparCGAddIn.My.Resources.Resources.PreviewRefresh
      Me.togLiveUpdate.Label = "Live Update"
      Me.togLiveUpdate.Name = "togLiveUpdate"
      Me.togLiveUpdate.ShowImage = True
      Me.togLiveUpdate.Visible = False
      '
      'grpInsert
      '
      Me.grpInsert.Items.Add(Me.btnImageFile)
      Me.grpInsert.Items.Add(Me.btnBaseFolder)
      Me.grpInsert.Items.Add(Me.btnColor)
      Me.grpInsert.Label = "Insert"
      Me.grpInsert.Name = "grpInsert"
      '
      'btnImageFile
      '
      Me.btnImageFile.Image = Global.CasparCGAddIn.My.Resources.Resources.Open_Image
      Me.btnImageFile.Label = "Image Filemane"
      Me.btnImageFile.Name = "btnImageFile"
      Me.btnImageFile.ShowImage = True
      '
      'btnBaseFolder
      '
      Me.btnBaseFolder.Image = Global.CasparCGAddIn.My.Resources.Resources.Base_Folder
      Me.btnBaseFolder.Label = "Set Default-Folder"
      Me.btnBaseFolder.Name = "btnBaseFolder"
      Me.btnBaseFolder.ShowImage = True
      '
      'btnColor
      '
      Me.btnColor.Image = Global.CasparCGAddIn.My.Resources.Resources.Paint_Palette
      Me.btnColor.Label = "Color code"
      Me.btnColor.Name = "btnColor"
      Me.btnColor.ShowImage = True
      '
      'grpWeb
      '
      Me.grpWeb.DialogLauncher = RibbonDialogLauncherImpl5
      Me.grpWeb.Items.Add(Me.btnWeb)
      Me.grpWeb.Items.Add(Me.btnStartTimer)
      Me.grpWeb.Label = "Web"
      Me.grpWeb.Name = "grpWeb"
      Me.grpWeb.Visible = False
      '
      'btnWeb
      '
      Me.btnWeb.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnWeb.Image = Global.CasparCGAddIn.My.Resources.Resources.ASPNETWeb_64x
      Me.btnWeb.Label = "JSON Data"
      Me.btnWeb.Name = "btnWeb"
      Me.btnWeb.ShowImage = True
      '
      'btnStartTimer
      '
      Me.btnStartTimer.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnStartTimer.Image = Global.CasparCGAddIn.My.Resources.Resources.StartTime_64x
      Me.btnStartTimer.Label = "Start Timer"
      Me.btnStartTimer.Name = "btnStartTimer"
      Me.btnStartTimer.ShowImage = True
      '
      'grpAutoUpdate
      '
      Me.grpAutoUpdate.DialogLauncher = RibbonDialogLauncherImpl6
      Me.grpAutoUpdate.Items.Add(Me.togAutoUpdate)
      Me.grpAutoUpdate.Items.Add(Me.btnTest)
      Me.grpAutoUpdate.Label = "Auto"
      Me.grpAutoUpdate.Name = "grpAutoUpdate"
      '
      'togAutoUpdate
      '
      Me.togAutoUpdate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.togAutoUpdate.Image = Global.CasparCGAddIn.My.Resources.Resources.Synchronize
      Me.togAutoUpdate.Label = "Update"
      Me.togAutoUpdate.Name = "togAutoUpdate"
      Me.togAutoUpdate.ShowImage = True
      '
      'grpView
      '
      Me.grpView.Items.Add(Me.btnDashboard)
      Me.grpView.Label = "View"
      Me.grpView.Name = "grpView"
      '
      'btnDashboard
      '
      Me.btnDashboard.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnDashboard.Image = Global.CasparCGAddIn.My.Resources.Resources.GaugeMeter
      Me.btnDashboard.Label = "Dashboard"
      Me.btnDashboard.Name = "btnDashboard"
      Me.btnDashboard.ShowImage = True
      '
      'btnTest
      '
      Me.btnTest.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
      Me.btnTest.Image = Global.CasparCGAddIn.My.Resources.Resources.Refresh_Icon
      Me.btnTest.Label = "Test"
      Me.btnTest.Name = "btnTest"
      Me.btnTest.ShowImage = True
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
      Me.grpWeb.ResumeLayout(False)
      Me.grpWeb.PerformLayout()
      Me.grpAutoUpdate.ResumeLayout(False)
      Me.grpAutoUpdate.PerformLayout()
      Me.grpView.ResumeLayout(False)
      Me.grpView.PerformLayout()
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
   Friend WithEvents grpWeb As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnWeb As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents btnStartTimer As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents grpAutoUpdate As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents togAutoUpdate As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
   Friend WithEvents grpView As Microsoft.Office.Tools.Ribbon.RibbonGroup
   Friend WithEvents btnDashboard As Microsoft.Office.Tools.Ribbon.RibbonButton
   Friend WithEvents togLiveUpdate As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
   Friend WithEvents btnTest As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

   <System.Diagnostics.DebuggerNonUserCode()> _
   Friend ReadOnly Property ribCasparCG() As ribCasparCG
      Get
         Return Me.GetRibbon(Of ribCasparCG)()
      End Get
   End Property
End Class
