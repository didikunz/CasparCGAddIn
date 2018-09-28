Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Tools
Imports Microsoft.Office.Tools.Ribbon
Imports CasparObjects
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports Microsoft.Office.Core

Public Class ribCasparCG

#Region "Module vars and Properties"

   Private _Settings As Settings
   Private _ActiveWorkbook As Workbook

   Private _Dashboard As ucDashboard
   Private _DashboardPane As Microsoft.Office.Tools.CustomTaskPane

   Private _SheetWithPendingRefreshes As Worksheet = Nothing
   Private _PendingRefreshesIndex As Integer = 0
   Private _PendingLoadAutoplay As Boolean = False
   Private _CallingWorksheet As Worksheet = Nothing

   Public WriteOnly Property Settings As Settings
      Set(value As Settings)

         _Settings = value

         If _Settings IsNot Nothing AndAlso _Settings.ConnectOnStartUp Then
            togConnect.Checked = True
            UpdateUIConnectionState()
         End If

      End Set
   End Property

   Public WriteOnly Property ActiveWorkbook As Workbook
      Set(value As Workbook)
         _ActiveWorkbook = value
      End Set
   End Property
#End Region

#Region "Methods and Helper Functions"

   Public Sub SetDashboardObjects(dash As ucDashboard, dashPane As Microsoft.Office.Tools.CustomTaskPane)
      _Dashboard = dash
      _DashboardPane = dashPane
   End Sub


   Public Sub FlagSheetCalculated(sheet As Object)

      'If togLiveUpdate.Checked Then
      '   UpdatePreview(sheet)
      'End If

      If CustomProperies.Load(sheet, "IsDashboardList") = "1" Then
         If _Dashboard IsNot Nothing AndAlso _Dashboard.pendingRefresh Then
            _Dashboard.AutoUpdate()
         End If
      Else
         AutoUpdate(sheet)
      End If

   End Sub

   Public Sub LoadTemplate(sheet As Worksheet, Autoplay As Boolean)

      Dim tmpl As Template = Nothing

      For Each name As Excel.Name In sheet.Names

         If name.Name.Contains("CasparOutput") Then

            tmpl = FillTemplate(name, sheet)
            If tmpl Is Nothing Then
               Exit Sub
            End If
            Exit For

         End If

      Next

      Dim TemplateName As String = CustomProperies.Load(sheet, "Template")
      If TemplateName <> "" Then

         Dim dataset As Integer = 0
         Integer.TryParse(CustomProperies.Load(sheet, "AutoUpdateDataset"), dataset)
         If dataset = 0 Then

            Dim srv As Integer = 0
            Integer.TryParse(CustomProperies.Load(sheet, "ServerNumber"), srv)

            Dim channel As Integer = 0
            If Not Integer.TryParse(CustomProperies.Load(sheet, "Channel"), channel) Then
               channel = 1
            End If

            Dim layer As Integer = 0
            If Not Integer.TryParse(CustomProperies.Load(sheet, "Layer"), layer) Then
               layer = 20
            End If

            If srv = 0 Then

               For Each caspar As CasparCG In _Settings.Servers
                  If caspar.Connected Then
                     caspar.CG_Add(channel, layer, TemplateName, tmpl, Autoplay)
                  End If
               Next

            Else

               If srv <= _Settings.Servers.Count Then
                  Dim caspar As CasparCG = _Settings.Servers(srv - 1)
                  If caspar.Connected Then
                     caspar.CG_Add(channel, layer, TemplateName, tmpl, Autoplay)
                  End If
               End If

            End If

         End If

      End If

   End Sub

   Public Function RefreshQueries(sheet As Worksheet, Autoplay As Boolean) As Boolean

      Dim refreshPending As Boolean = False

      If CustomProperies.Load(sheet, "AutoUpdate") = "1" Then

         Dim que As String = CustomProperies.Load(sheet, "Queries")
         If que <> "" Then
            Dim queries() As String = que.Split("|")

            _PendingRefreshesIndex = 0
            _SheetWithPendingRefreshes = sheet
            _PendingLoadAutoplay = Autoplay
            _CallingWorksheet = _ActiveWorkbook.ActiveSheet
            refreshPending = True

            que = queries(0)
            For Each con In _ActiveWorkbook.Connections
               If con.Name = que Then
                  con.Refresh
               End If
            Next

         End If

      End If

      If _SheetWithPendingRefreshes Is Nothing Then

         If _CallingWorksheet IsNot Nothing Then

            For i As Integer = 1 To _ActiveWorkbook.Sheets.Count

               Dim ws As Worksheet = _ActiveWorkbook.Sheets(i)

               If ws Is _CallingWorksheet Then
                  _ActiveWorkbook.Sheets(i).Select()
                  Exit For
               End If

            Next

            _CallingWorksheet = Nothing

         End If

      End If

      Return refreshPending

   End Function

   Public Sub PlayTemplate(sheet As Worksheet)

      Dim dataset As Integer = 0
      Integer.TryParse(CustomProperies.Load(sheet, "AutoUpdateDataset"), dataset)
      If dataset = 0 Then

         Dim srv As Integer = 0
         Integer.TryParse(CustomProperies.Load(sheet, "ServerNumber"), srv)

         Dim channel As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(sheet, "Channel"), channel) Then
            channel = 1
         End If

         Dim layer As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(sheet, "Layer"), layer) Then
            layer = 20
         End If

         If srv = 0 Then

            For Each caspar As CasparCG In _Settings.Servers
               If caspar.Connected Then
                  caspar.CG_Play(channel, layer)
               End If
            Next

         Else

            If srv <= _Settings.Servers.Count Then
               Dim caspar As CasparCG = _Settings.Servers(srv - 1)
               If caspar.Connected Then
                  caspar.CG_Play(channel, layer)
               End If
            End If

         End If

      End If

   End Sub
   Public Sub PlayNext(sheet As Worksheet)

      Dim dataset As Integer = 0
      Integer.TryParse(CustomProperies.Load(sheet, "AutoUpdateDataset"), dataset)
      If dataset = 0 Then

         Dim srv As Integer = 0
         Integer.TryParse(CustomProperies.Load(sheet, "ServerNumber"), srv)

         Dim channel As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(sheet, "Channel"), channel) Then
            channel = 1
         End If

         Dim layer As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(sheet, "Layer"), layer) Then
            layer = 20
         End If

         If srv = 0 Then

            For Each caspar As CasparCG In _Settings.Servers
               If caspar.Connected Then
                  caspar.CG_Next(channel, layer)
               End If
            Next

         Else

            If srv <= _Settings.Servers.Count Then
               Dim caspar As CasparCG = _Settings.Servers(srv - 1)
               If caspar.Connected Then
                  caspar.CG_Next(channel, layer)
               End If
            End If

         End If

      End If

   End Sub

   Public Sub StoppTemplate(sheet As Worksheet)

      Dim dataset As Integer = 0
      Integer.TryParse(CustomProperies.Load(sheet, "AutoUpdateDataset"), dataset)
      If dataset = 0 Then

         Dim srv As Integer = 0
         Integer.TryParse(CustomProperies.Load(sheet, "ServerNumber"), srv)

         Dim channel As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(sheet, "Channel"), channel) Then
            channel = 1
         End If

         Dim layer As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(sheet, "Layer"), layer) Then
            layer = 20
         End If

         If srv = 0 Then

            For Each caspar As CasparCG In _Settings.Servers
               If caspar.Connected Then
                  caspar.CG_Stop(channel, layer)
               End If
            Next

         Else

            If srv <= _Settings.Servers.Count Then
               Dim caspar As CasparCG = _Settings.Servers(srv - 1)
               If caspar.Connected Then
                  caspar.CG_Stop(channel, layer)
               End If
            End If

         End If

      End If

   End Sub

   Public Sub UpdateTemplate(sheet As Worksheet)


      Dim tmpl As Template = Nothing

      For Each name As Excel.Name In sheet.Names

         If name.Name.Contains("CasparOutput") Then

            tmpl = FillTemplate(name, sheet)
            If tmpl Is Nothing Then
               Exit Sub
            End If
            Exit For

         End If

      Next

      Dim dataset As Integer = 0
      Integer.TryParse(CustomProperies.Load(sheet, "AutoUpdateDataset"), dataset)
      If dataset = 0 Then

         Dim srv As Integer = 0
         Integer.TryParse(CustomProperies.Load(sheet, "ServerNumber"), srv)

         Dim channel As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(sheet, "Channel"), channel) Then
            channel = 1
         End If

         Dim layer As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(sheet, "Layer"), layer) Then
            layer = 20
         End If

         If srv = 0 Then

            For Each caspar As CasparCG In _Settings.Servers
               If caspar.Connected Then
                  caspar.CG_Update(channel, layer, tmpl)
               End If
            Next

         Else

            If srv <= _Settings.Servers.Count Then
               Dim caspar As CasparCG = _Settings.Servers(srv - 1)
               If caspar.Connected Then
                  caspar.CG_Update(channel, layer, tmpl)
               End If
            End If

         End If

      End If

   End Sub

   Public Sub FlagSheetActivated(sheet As Object)

      If sheet IsNot Nothing Then

         'Dim basePath As String = CustomProperies.Load(sheet, "ImageBaseFolder")

         If CustomProperies.Load(sheet, "AutoUpdate") = "1" Then
            togAutoUpdate.Checked = True
         Else
            togAutoUpdate.Checked = False
         End If

      End If

   End Sub

   Private Sub UpdateUIConnectionState()

      btnSaveDataSet.Enabled = togConnect.Checked
      btnSaveAllDataSets.Enabled = togConnect.Checked

      If _Settings.PreviewServer <> "" Then
         btnPreview.Enabled = togConnect.Checked
      End If

   End Sub

   Private Function FillTemplate(name As Excel.Name, wrkSheet As Worksheet) As Template

      Dim range As Excel.Range = name.RefersToRange
      Dim tmpl As Template = New Template
      Dim cell As Excel.Range

      Dim varName As Object = Nothing
      Dim varValue As Object = Nothing

      Dim objClipboard As Object = My.Computer.Clipboard.GetDataObject
      Dim imgClipboard As System.Drawing.Image
      Dim blnClipboardUsed As Boolean = False

      If range.Columns.Count = 2 Then

         For row As Integer = 1 To range.Rows.Count

            cell = range(row, 1)
            varName = cell.Text
            cell = range(row, 2)

            Dim pic As Excel.Shape = GetImage(wrkSheet, row, 2)
            If pic IsNot Nothing Then

               If varName IsNot Nothing Then

                  blnClipboardUsed = True

                  pic.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap)
                  imgClipboard = My.Computer.Clipboard.GetData(System.Windows.Forms.DataFormats.Bitmap)

                  If imgClipboard IsNot Nothing Then
                     tmpl.AddPictureField(varName.ToString, imgClipboard)
                  End If


               End If

            Else

               varValue = cell.Text

               If varName IsNot Nothing Then
                  If varValue IsNot Nothing Then
                     If varName <> "" Then
                        tmpl.AddField(varName.ToString, varValue.ToString)
                     End If
                  Else
                     If varName <> "" Then
                        tmpl.AddField(varName.ToString, "")
                     End If
                  End If
               End If

            End If

         Next

         Return tmpl

      ElseIf range.Rows.Count = 2 Then

         For col As Integer = 1 To range.Columns.Count

            cell = range(1, col)
            varName = cell.Text
            cell = range(2, col)

            Dim pic As Excel.Shape = GetImage(wrkSheet, 2, col)
            If pic IsNot Nothing Then

               If varName IsNot Nothing Then

                  blnClipboardUsed = True

                  pic.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap)
                  imgClipboard = My.Computer.Clipboard.GetData(System.Windows.Forms.DataFormats.Bitmap)

                  If imgClipboard IsNot Nothing Then
                     tmpl.AddPictureField(varName.ToString, imgClipboard)
                  End If

               End If

            Else

               varValue = cell.Text

               If varName IsNot Nothing Then
                  If varValue IsNot Nothing Then
                     If varName <> "" Then
                        tmpl.AddField(varName.ToString, varValue.ToString)
                     End If
                  Else
                     If varName <> "" Then
                        tmpl.AddField(varName.ToString, "")
                     End If
                  End If
               End If

            End If

         Next

         Return tmpl

      Else
         MsgBox("Invalid Range defined, needs to be either 2 columns or 2 rows wide.", MsgBoxStyle.Exclamation, "Invalid Selection")
         Return Nothing
      End If

      If blnClipboardUsed Then
         My.Computer.Clipboard.SetDataObject(objClipboard)
         If imgClipboard IsNot Nothing Then
            imgClipboard.Dispose()
         End If
      End If

   End Function

#End Region

#Region "grpConnections"

   Private Sub togConnect_Click(sender As Object, e As RibbonControlEventArgs) Handles togConnect.Click

      If togConnect.Checked Then
         Globals.ThisAddIn.ConnectAll()
      Else
         Globals.ThisAddIn.DisconnectAll()
      End If
      UpdateUIConnectionState()

   End Sub

   Private Sub grpConnections_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpConnections.DialogLauncherClick

      Dim fset As frmSettings = New frmSettings
      fset.Settings = _Settings

      fset.ShowDialog()

      If _Settings.ConnectOnStartUp Then
         Globals.ThisAddIn.DisconnectAll()
         Globals.ThisAddIn.ConnectAll()
      End If

   End Sub

#End Region

#Region "grpSelection"

   Private Sub btnSetOutputRange_Click(sender As Object, e As RibbonControlEventArgs) Handles btnSetOutputRange.Click

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim currRange As Excel.Range = CType(Globals.ThisAddIn.Application.Selection, Excel.Range)

      Dim currWorksheet As Microsoft.Office.Interop.Excel.Worksheet = AppObject.ActiveSheet
      currWorksheet.Names.Add("CasparOutput", currRange)

   End Sub

   Private Sub grpSelection_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpSelection.DialogLauncherClick

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim fsp As frmSheetProperties = New frmSheetProperties

      fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeAll
      fsp.wrkSheet = AppObject.ActiveSheet
      fsp.Settings = _Settings

      If fsp.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         AppObject.Saved = False
      End If

   End Sub

#End Region

#Region "grpDataset"

   Private Sub DoSaveDataSet(AppObject As Workbook, currWorksheet As Worksheet, Silent As Boolean)

      For Each name As Excel.Name In currWorksheet.Names

         If name.Name.Contains("CasparOutput") Then

            Dim DatasetName As String = CustomProperies.Load(currWorksheet, "DataSetName")
            If DatasetName = "" Then

               If Silent Then

                  CustomProperies.Save(currWorksheet, "DataSetName", currWorksheet.Name)

               Else

                  Dim fsp As frmSheetProperties = New frmSheetProperties
                  fsp.wrkSheet = currWorksheet
                  If fsp.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                     Exit For
                  End If

               End If

            End If

            DatasetName = CustomProperies.Load(currWorksheet, "DataSetName")
            If DatasetName = "" Then
               Exit For
            Else
               AppObject.Saved = False
            End If

            Dim tmpl As Template = FillTemplate(name, currWorksheet)
            If tmpl IsNot Nothing Then

               For Each caspar In _Settings.Servers
                  If caspar.Connected Then
                     caspar.Data_Store(DatasetName, tmpl)
                  End If
               Next

            End If

            Exit For

         End If

      Next

   End Sub

   Private Sub btnSaveDataSet_Click(sender As Object, e As RibbonControlEventArgs) Handles btnSaveDataSet.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      DoSaveDataSet(AppObject, AppObject.ActiveSheet, False)

   End Sub

   Private Sub btnSaveAllDataSets_Click(sender As Object, e As RibbonControlEventArgs) Handles btnSaveAllDataSets.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      For Each wrk As Worksheet In AppObject.Sheets
         DoSaveDataSet(AppObject, wrk, True)
      Next

   End Sub

   Private Sub grpDataset_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpDataset.DialogLauncherClick

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim fsp As frmSheetProperties = New frmSheetProperties

      fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeDataSetName
      fsp.wrkSheet = AppObject.ActiveSheet
      fsp.Settings = _Settings

      If fsp.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         AppObject.Saved = False
      End If

   End Sub

#End Region

#Region "grpPreview"

   Private Sub UpdatePreview(sheet As Worksheet)

      'Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      'Dim currWorksheet As Worksheet = AppObject.ActiveSheet

      'If currWorksheet Is sheet Then

      '   Dim pvw As CasparCG = _Settings.Preview
      '   If pvw IsNot Nothing AndAlso pvw.Connected Then

      '      For Each name As Excel.Name In currWorksheet.Names

      '         If name.Name.Contains("CasparOutput") Then

      '            Dim tmpl As Template = FillTemplate(name, currWorksheet)
      '            If tmpl Is Nothing Then
      '               Exit For
      '            End If

      '            pvw.CG_Update(_Settings.PreviewChannel, 20, tmpl)
      '            Exit For

      '         End If

      '      Next

      '   End If

      'End If

   End Sub

   Private Sub btnPreview_Click(sender As Object, e As RibbonControlEventArgs) Handles btnPreview.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim currWorksheet As Worksheet = AppObject.ActiveSheet

      Dim pvw As CasparCG = _Settings.Preview
      If pvw IsNot Nothing AndAlso pvw.Connected Then

         For Each name As Excel.Name In currWorksheet.Names

            If name.Name.Contains("CasparOutput") Then

               Dim TemplateName As String = CustomProperies.Load(currWorksheet, "Template")
               If TemplateName = "" Then
                  Dim fsp As frmSheetProperties = New frmSheetProperties
                  fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeTemplate
                  fsp.Settings = _Settings
                  fsp.wrkSheet = currWorksheet
                  If fsp.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                     Exit For
                  Else
                     TemplateName = CustomProperies.Load(currWorksheet, "Template")
                     If TemplateName = "" Then
                        Exit For
                     Else
                        AppObject.Saved = False
                     End If
                  End If
               End If

               Dim tmpl As Template = FillTemplate(name, currWorksheet)
               If tmpl Is Nothing Then
                  Exit For
               End If

               pvw.CG_Add(_Settings.PreviewChannel, 20, TemplateName, tmpl, True)
               togLiveUpdate.Enabled = True
               Exit For

            End If

         Next

      End If

   End Sub

   Private Sub grpPreview_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpPreview.DialogLauncherClick

      Dim pvw As CasparCG = _Settings.Preview
      If pvw IsNot Nothing AndAlso pvw.Connected Then

         Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

         Dim fsp As frmSheetProperties = New frmSheetProperties

         fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeTemplate
         fsp.wrkSheet = AppObject.ActiveSheet
         fsp.Settings = _Settings

         If fsp.ShowDialog() = DialogResult.OK Then
            AppObject.Saved = False
         End If

      End If

   End Sub

#End Region

#Region "grpInsert"

   Private Function GetImage(wrkSheet As Worksheet, row As Integer, col As Integer) As Excel.Shape

      Dim sh As Excel.Shape = Nothing

      For Each pic As Excel.Shape In wrkSheet.Shapes

         Dim range As Excel.Range = pic.TopLeftCell
         If range.Row = row And range.Column = col Then
            sh = pic
            Exit For
         End If

      Next

      Return sh

   End Function

   Private Sub btnImageFile_Click(sender As Object, e As RibbonControlEventArgs) Handles btnImageFile.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim ofd As OpenFileDialog = New OpenFileDialog

      Dim basePath As String = CustomProperies.Load(AppObject.ActiveSheet, "ImageBaseFolder")

      If basePath <> "" Then
         ofd.InitialDirectory = basePath
      Else
         ofd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
      End If

      ofd.Filter = "Image Files|*.bmp;*.png;*.jpg;*.tif|All Files (*.*)|*.*||"
      ofd.FilterIndex = 0

      If ofd.ShowDialog = DialogResult.OK Then

         Dim fName As String = ofd.FileName
         Dim currRange As Excel.Range = CType(Globals.ThisAddIn.Application.Selection, Excel.Range)

         currRange.Value = New System.Uri(fName, UriKind.Absolute).ToString

         If basePath = "" Then
            CustomProperies.Save(AppObject.ActiveSheet, "ImageBaseFolder", IO.Path.GetDirectoryName(fName))
         End If

      End If

   End Sub

   Private Sub btnBaseFolder_Click(sender As Object, e As RibbonControlEventArgs) Handles btnBaseFolder.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim fbd As FolderBrowserDialog = New FolderBrowserDialog

      Dim basePath As String = CustomProperies.Load(AppObject.ActiveSheet, "ImageBaseFolder")
      If basePath = "" Then
         basePath = My.Computer.FileSystem.SpecialDirectories.MyPictures
      End If

      fbd.SelectedPath = basePath
      fbd.ShowNewFolderButton = False

      If fbd.ShowDialog = DialogResult.OK Then
         CustomProperies.Save(AppObject.ActiveSheet, "ImageBaseFolder", fbd.SelectedPath)
         AppObject.Saved = False
      End If

   End Sub

   Private Function ContrastingColor(col As Color) As Color

      Dim pl As Single = 1 - (0.299 * col.R + 0.587 * col.G + 0.114 * col.B) / 255

      If pl < 0.5 Then
         Return Color.Black
      Else
         Return Color.White
      End If

   End Function

   Private Sub btnColor_Click(sender As Object, e As RibbonControlEventArgs) Handles btnColor.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim currRange As Excel.Range = CType(Globals.ThisAddIn.Application.Selection, Excel.Range)

      Dim cdg As ColorDialog = New ColorDialog

      cdg.Color = ColorTranslator.FromOle(currRange.Interior.Color)
      cdg.FullOpen = True

      If cdg.ShowDialog = DialogResult.OK Then

         currRange.Interior.Color = ColorTranslator.ToOle(cdg.Color)
         currRange.Font.Color = ColorTranslator.ToOle(ContrastingColor(cdg.Color))

         currRange.Value = String.Format("0x{0:X8}", cdg.Color.ToArgb)

      End If

   End Sub

#End Region

#Region "grpWeb"

   Private Sub btnWeb_Click(sender As Object, e As RibbonControlEventArgs) Handles btnWeb.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim wrkSheet As Worksheet = AppObject.ActiveSheet
      Dim range As Excel.Range = wrkSheet.Cells()
      Dim cell As Excel.Range = Nothing
      Dim isRowQuery As Boolean = False

      Dim col As Integer = 1
      Dim dicNames As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)

      cell = range(2, 1)
      If cell.Text = "" Then
         isRowQuery = True
         col = 2
      End If

      Do
         cell = range(2, col)
         If cell.Text <> "" Then
            dicNames.Add(cell.Text, col)
         Else
            Exit Do
         End If
         col += 1
      Loop

      Dim row As Integer = 3
      Dim hasValue As Boolean = False
      col -= 1

      Dim start As Integer = 1
      If isRowQuery Then start = 2

      Do
         hasValue = False
         For c As Integer = start To col
            cell = range(row, c)
            If cell.Text <> "" Then
               hasValue = True
            End If
            If cell.Value IsNot Nothing Then
               cell.Value = ""
            End If
         Next
         If hasValue = False Then
            Exit Do
         End If
         row += 1
      Loop

      row = 2
      Using client As WebClient = New WebClient

         Try

            Dim varName As String = ""

            cell = range(1, 1)
            Dim url As String = cell.Text.ToString

            If url.Contains("?") Then
               url += "&" + Guid.NewGuid.ToString
            Else
               url += "?" + Guid.NewGuid.ToString
            End If

            If Uri.IsWellFormedUriString(url, UriKind.Absolute) Then
               'Page Query

               Dim json As String = client.DownloadString(cell.Text)

               'ToDo: Starnge Encoding trick, need to know why it's not the other way around
               Dim bytes() As Byte = Encoding.GetEncoding(1252).GetBytes(json)
               json = Encoding.UTF8.GetString(bytes)

               Dim rd As JsonTextReader = New JsonTextReader(New StringReader(json))
               While rd.Read

                  If rd.Value <> Nothing Then

                     If rd.TokenType = JsonToken.PropertyName Then

                        varName = rd.Path.Substring(rd.Path.IndexOf("]", 0) + 2)

                     Else

                        If rd.TokenType <> JsonToken.EndObject And rd.TokenType <> JsonToken.StartObject Then

                           If dicNames.ContainsKey(varName) Then

                              col = dicNames(varName)
                              If col = 1 Then
                                 row += 1
                              End If

                              cell = range(row, col)
                              cell.Value = rd.Value

                           End If

                        End If

                     End If

                  End If

               End While

               wrkSheet.Calculate()
               AppObject.Saved = False

            Else     'Could be a row query, first cell in row would be the url

               row = 3

               Do
                  cell = range(row, 1)
                  url = cell.Text.ToString

                  If url.Contains("?") Then
                     url += "&" + Guid.NewGuid.ToString
                  Else
                     url += "?" + Guid.NewGuid.ToString
                  End If

                  If Uri.IsWellFormedUriString(url, UriKind.Absolute) Then

                     Dim json As String = client.DownloadString(cell.Text)

                     'ToDo: Starnge Encoding trick, need to know why it's not the other way around
                     Dim bytes() As Byte = Encoding.GetEncoding(1252).GetBytes(json)
                     json = Encoding.UTF8.GetString(bytes)

                     Dim rd As JsonTextReader = New JsonTextReader(New StringReader(json))
                     While rd.Read

                        If rd.Value <> Nothing Then

                           If rd.TokenType = JsonToken.PropertyName Then

                              varName = rd.Path.Substring(rd.Path.IndexOf("]", 0) + 1)

                           Else

                              If rd.TokenType <> JsonToken.EndObject And rd.TokenType <> JsonToken.StartObject Then

                                 If dicNames.ContainsKey(varName) Then

                                    col = dicNames(varName)

                                    cell = range(row, col)
                                    cell.Value = rd.Value

                                 End If

                              End If

                           End If

                        End If

                     End While

                  Else
                     Exit Do
                  End If

                  row += 1

               Loop

               wrkSheet.Calculate()
               AppObject.Saved = False

            End If

         Catch ex As Exception

         End Try

      End Using

   End Sub

   Private Sub btnStartTimer_Click(sender As Object, e As RibbonControlEventArgs) Handles btnStartTimer.Click

   End Sub


   Private Sub grpWeb_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpWeb.DialogLauncherClick

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim fswd As frmSetupWebData = New frmSetupWebData
      fswd.wrkSheet = AppObject.ActiveSheet

      If fswd.ShowDialog() = DialogResult.OK Then
         AppObject.Saved = False
      End If

   End Sub

#End Region

#Region "grpAutoUpdate"

   Private Sub AutoUpdate(sheet As Worksheet)

      If CustomProperies.Load(sheet, "AutoUpdate") = "1" Then

         If _SheetWithPendingRefreshes Is sheet Then

            _PendingRefreshesIndex += 1

            Dim que As String = CustomProperies.Load(sheet, "Queries")
            If que <> "" Then
               Dim queries() As String = que.Split("|")

               If _PendingRefreshesIndex = queries.Count Then

                  _SheetWithPendingRefreshes = Nothing
                  _PendingRefreshesIndex = 0

                  LoadTemplate(sheet, _PendingLoadAutoplay)

               ElseIf _PendingRefreshesIndex < queries.Count Then

                  que = queries(_PendingRefreshesIndex)
                  For Each con In _ActiveWorkbook.Connections
                     If con.Name = que Then
                        con.Refresh
                     End If
                  Next

               End If

            End If

         Else

            UpdateTemplate(sheet)

         End If

      End If

   End Sub

   Private Sub togAutoUpdate_Click(sender As Object, e As RibbonControlEventArgs) Handles togAutoUpdate.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim currWorksheet As Worksheet = AppObject.ActiveSheet

      If togAutoUpdate.Checked Then
         CustomProperies.Save(currWorksheet, "AutoUpdate", "1")
      Else
         CustomProperies.Save(currWorksheet, "AutoUpdate", "0")
      End If

   End Sub

   Private Sub grpAutoUpdate_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpAutoUpdate.DialogLauncherClick

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim fsp As frmSheetProperties = New frmSheetProperties

      fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeAutoUpdate
      fsp.wrkSheet = AppObject.ActiveSheet
      fsp.Settings = _Settings

      If fsp.ShowDialog() = DialogResult.OK Then
         AppObject.Saved = False
      End If

   End Sub

#End Region

#Region "grpView"

   Private Sub btnDashboard_Click(sender As Object, e As RibbonControlEventArgs) Handles btnDashboard.Click
      Try
         _DashboardPane.Visible = Not _DashboardPane.Visible
         _Settings.DashboardVisible = _DashboardPane.Visible
      Catch ex As Exception

      End Try
   End Sub


#End Region

   Private Sub btnTest_Click(sender As Object, e As RibbonControlEventArgs) Handles btnTest.Click

      Dim AppObject As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      For Each con In AppObject.Connections
         MsgBox(con.Name)
         con.Refresh()
      Next

      MsgBox("jhljh")

   End Sub


End Class

