Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Tools
Imports Microsoft.Office.Tools.Excel
Imports Microsoft.Office.Tools.Excel.Extensions
Imports Microsoft.Office.Tools.Ribbon
Imports CasparObjects
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports Microsoft.Office.Core
Imports System.Diagnostics
Imports System.Web.UI
Imports CasparCGAddIn

Public Class ribCasparCG

#Region "Module vars and Properties"

   Private _Settings As Settings
   Private _ActiveWorkbook As Microsoft.Office.Interop.Excel.Workbook
   Private _IsCasparConnected As Boolean = False

   Private _Dashboard As ucDashboard
   Private _DashboardPane As Microsoft.Office.Tools.CustomTaskPane

   Private _SheetWithPendingRefreshes As Microsoft.Office.Interop.Excel.Worksheet = Nothing
   Private _PlaybackControlWithPendingRefreshes As ucPlaybackControls = Nothing
   Private _PendingRefreshAutoplay As Boolean = False
   Private _PendingRefreshUpdate As Boolean = False
   Private _PendingRefreshPreview As Boolean = False

   Private _PendingRefreshAllStep As Integer = 0
   Private _RefreshAllWebConnections As List(Of Object)
   Private _RefreshAllTableConnections As List(Of Object)

   Private _SlaveSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing

   Private WithEvents _TimerSettings As TimerSettings
   Private _xmlId As String = ""
   Private _TimerSettingsFilename As String


   Public WriteOnly Property Settings As Settings
      Set(value As Settings)

         _Settings = value

         If _Settings IsNot Nothing Then

            btnDashboard.Visible = _Settings.ShowDashboard

         End If

      End Set
   End Property

   Public WriteOnly Property SettingsFilename As String
      Set(value As String)
         _TimerSettingsFilename = IO.Path.GetDirectoryName(value) + "\TimerSettings.xml"
      End Set
   End Property

   Public WriteOnly Property IsCasparConnected As Boolean
      Set(value As Boolean)

         _IsCasparConnected = value

         togConnect.Checked = _IsCasparConnected
         UpdateUIConnectionState()

      End Set
   End Property

   Public WriteOnly Property ActiveWorkbook As Microsoft.Office.Interop.Excel.Workbook
      Set(value As Microsoft.Office.Interop.Excel.Workbook)
         _ActiveWorkbook = value
         'RefreshAllButtons()
         LoadTimerSettings()
         'Restore running timer
      End Set
   End Property

   Public ReadOnly Property TimerSettings As TimerSettings
      Get
         Return _TimerSettings
      End Get
   End Property

#End Region

#Region "Methods and Helper Functions"

   Public Sub SetDashboardObjects(dash As ucDashboard, dashPane As Microsoft.Office.Tools.CustomTaskPane)
      _Dashboard = dash
      _DashboardPane = dashPane
   End Sub


   Public Sub FlagSheetCalculated(sheet As Object)

      If Not CustomProperties.Load(sheet, "IsDashboardList", False) Then

         If CustomProperties.Load(sheet, "AutoUpdate", False) Then

            'AutoUpdate only when not DataSet and no queries to run before.
            If Not CustomProperties.Load(sheet, "AutoUpdateDataset", False) Then
               If Not CustomProperties.Load(sheet, "UpdateQueries", False) Then
                  UpdateTemplate(sheet, Nothing)
               End If
            End If

         End If

      End If

   End Sub

   Public Sub FlagSheetActivated(sheet As Object)

      If sheet IsNot Nothing Then

         Dim sm As String = CustomProperties.Load(sheet, "SelectionMode", "")
         If sm = "" Then

            Dim range As Excel.Range = Nothing

            For Each name As Excel.Name In sheet.Names
               If name.Name.Contains("CasparOutput") Then
                  range = name.RefersToRange
                  Exit For
               End If
            Next

            If range IsNot Nothing Then
               If range.Columns.Count = 2 Then
                  CustomProperties.Save(sheet, "SelectionMode", "V")
               Else
                  CustomProperties.Save(sheet, "SelectionMode", "H")
               End If
            End If

         End If

         'AutoUpdate
         togAutoUpdate.Checked = CustomProperties.Load(sheet, "AutoUpdate", False)

         'BrowserRefresh
         btnBrowserRefresh.Enabled = (CustomProperties.Load(sheet, "WebURL", "") <> "")

      End If

   End Sub


   Public Sub FlagAfterCalculate()

      If _PendingRefreshAllStep = 1 Then

         If _RefreshAllTableConnections.Count > 0 Then

            For Each con In _RefreshAllTableConnections
               con.Refresh
            Next
            _PendingRefreshAllStep = 2

         Else

            'Skip
            _PendingRefreshAllStep = 2
            FlagAfterCalculate()

         End If

      ElseIf _PendingRefreshAllStep = 2 Then

         _PendingRefreshAllStep = 0

         btnRefreshData.Enabled = True
         MsgBox("All data successfully refreshed", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Refresh All")

      End If

      If _SheetWithPendingRefreshes IsNot Nothing AndAlso _PlaybackControlWithPendingRefreshes IsNot Nothing Then

         _PlaybackControlWithPendingRefreshes.State = ucPlaybackButtons.enumState.stQueryFinished

         If _PendingRefreshUpdate Then
            UpdateTemplate(_SheetWithPendingRefreshes, _PlaybackControlWithPendingRefreshes)
         ElseIf _PendingRefreshPreview Then
            PreviewTemplate(_SheetWithPendingRefreshes, _PlaybackControlWithPendingRefreshes)
         Else
            LoadTemplate(_SheetWithPendingRefreshes, _PendingRefreshAutoplay, _PlaybackControlWithPendingRefreshes)
         End If

         _SheetWithPendingRefreshes = Nothing
         _PlaybackControlWithPendingRefreshes = Nothing

      End If

   End Sub

   Private Sub UpdateUIConnectionState()

      btnSaveDataSet.Enabled = togConnect.Checked
      btnSaveAllDataSets.Enabled = togConnect.Checked

      If _Settings.PreviewServer <> "" Then
         btnPreview.Enabled = togConnect.Checked
      End If

   End Sub

   Private Function FormatBorder(border As Border) As String

      Dim s As String = ""
      Dim inte As Integer = 0

      If Integer.TryParse(border.Weight.ToString, inte) Then
         s = XLBorderWeightToString(inte) + " "
      Else
         s = "thin "
      End If

      If Integer.TryParse(border.LineStyle.ToString, inte) Then
         s += XLLineStyleToString(inte) + " "
      Else
         s += "solid "
      End If

      s += XLColorToString(border.Color, False)

      Return s

   End Function

   Private Function LegalizeClassName(name As String) As String

      Dim sb As StringBuilder = New StringBuilder
      Dim chars() As Char = name.ToLower.Normalize(NormalizationForm.FormD).ToCharArray
      Dim lastIsValid As Boolean = False

      For i As Integer = 0 To chars.Count - 1

         If IsNumeric(chars(i)) Then

            If i > 0 Then
               sb.Append(chars(i))
               lastIsValid = True
            Else
               sb.Append("_")
               lastIsValid = False
            End If

         ElseIf Asc(chars(i)) >= 97 And Asc(chars(i)) <= 122 Then

            sb.Append(chars(i))
            lastIsValid = True

         ElseIf Asc(chars(i)) = 45 Then

            sb.Append(chars(i))
            lastIsValid = True

         ElseIf Asc(chars(i)) = 168 Then

         Else

            If lastIsValid Then
               sb.Append("_")
            End If

            lastIsValid = False

         End If

      Next

      Return sb.ToString

   End Function

   Public Sub ExportStyles(filename As String)

      Dim sb As StringBuilder = New StringBuilder
      Dim classNames As HashSet(Of String) = New HashSet(Of String)


      For Each style As Style In _ActiveWorkbook.Styles

         Dim name As String = LegalizeClassName(style.Name.ToString)

         If Not classNames.Contains(name) Then

            classNames.Add(name)

            sb.AppendLine(name + " {")

            sb.AppendLine("   font-family: " + style.Font.Name.ToString + ";")
            sb.AppendLine("   font-size: " + style.Font.Size.ToString + "px;")
            sb.AppendLine("   font-style: " + IIf(style.Font.Italic, "italic", "normal") + ";")
            sb.AppendLine("   font-weight: " + IIf(style.Font.Bold, "bold", "normal") + ";")

            sb.AppendLine("   color: " + XLColorToString(style.Font.Color, False) + ";")
            sb.AppendLine("   background-color: " + InteriorColor(style.Interior) + ";")

            sb.AppendLine("   text-align: " + XLHorAlignToString(Integer.Parse(style.HorizontalAlignment)) + ";")
            sb.AppendLine("   vertical-align: " + XLVertAlignToString(Integer.Parse(style.VerticalAlignment)) + ";")

            sb.AppendLine("   border-left: " + FormatBorder(style.Borders(XlBordersIndex.xlEdgeLeft)) + ";")
            sb.AppendLine("   border-top: " + FormatBorder(style.Borders(XlBordersIndex.xlEdgeTop)) + ";")
            sb.AppendLine("   border-right: " + FormatBorder(style.Borders(XlBordersIndex.xlEdgeRight)) + ";")
            sb.AppendLine("   border-bottom: " + FormatBorder(style.Borders(XlBordersIndex.xlEdgeBottom)) + ";")

            sb.AppendLine("}")
            sb.AppendLine()

         End If

      Next

      IO.File.WriteAllText(filename, sb.ToString)

   End Sub

   Private Sub ReferenceToNumbers(Referece As String, ByRef Col As Integer, ByRef Row As Integer)

      Dim chars() As Char = Referece.ToCharArray()
      Dim alpha As String = ""
      Dim number As String = ""

      For c As Integer = 0 To chars.Length - 1
         If IsNumeric(chars(c).ToString) Then
            number += chars(c).ToString
         Else
            alpha += chars(c).ToString
         End If
      Next

      chars = alpha.ToUpper().ToCharArray()

      Col = 0
      Dim exponent As Integer = 0
      For c As Integer = chars.Length - 1 To 0 Step -1

         Dim wert As Integer = 0

         Select Case alpha(c)
            Case "A"
               wert = 1
            Case "B"
               wert = 2
            Case "C"
               wert = 3
            Case "D"
               wert = 4
            Case "E"
               wert = 5
            Case "F"
               wert = 6
            Case "G"
               wert = 7
            Case "H"
               wert = 8
            Case "I"
               wert = 9
            Case "J"
               wert = 10
            Case "K"
               wert = 11
            Case "L"
               wert = 12
            Case "M"
               wert = 13
            Case "N"
               wert = 14
            Case "O"
               wert = 15
            Case "P"
               wert = 16
            Case "Q"
               wert = 17
            Case "R"
               wert = 18
            Case "S"
               wert = 19
            Case "T"
               wert = 20
            Case "U"
               wert = 21
            Case "V"
               wert = 22
            Case "W"
               wert = 23
            Case "X"
               wert = 24
            Case "Y"
               wert = 25
            Case "Z"
               wert = 26
         End Select

         Col += wert * 26 ^ exponent
         exponent += 1

      Next

      Dim inte As Integer = 0
      If Integer.TryParse(number, inte) Then
         Row = inte
      Else
         Row = 1
      End If


   End Sub

#End Region

#Region "Caspar-Playback Methods"

   Public Sub LoadTemplate(sheet As Microsoft.Office.Interop.Excel.Worksheet, Autoplay As Boolean, PlaybackCtrl As ucPlaybackControls)

      If Not PlaybackCtrl.State = ucPlaybackButtons.enumState.stQueryFinished Then
         _PendingRefreshAutoplay = Autoplay
         RefreshQueries(sheet, PlaybackCtrl)
      End If

      If Not PlaybackCtrl.State = ucPlaybackButtons.enumState.stQueryRunning Then

         _PendingRefreshAutoplay = False

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

         Dim TemplateName As String = CustomProperties.Load(sheet, "Template", "")
         If TemplateName <> "" Then

            If Not CustomProperties.Load(sheet, "AutoUpdateDataset", False) Then

               Dim srv As Integer = CustomProperties.Load(sheet, "ServerNumber", 0)

               Dim channel As Integer = CustomProperties.Load(sheet, "Channel", 1)
               Dim layer As Integer = CustomProperties.Load(sheet, "Layer", 20)

               Dim flashLayer As Integer = 1
               If _Settings.UseFlashLayers Then
                  flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
               End If

               Dim useDVE As Boolean = CustomProperties.Load(sheet, "UseDVE", False)

               Dim dveffect As String = ""
               If useDVE Then
                  dveffect = CustomProperties.Load(sheet, "DVEffect", "0 0 1 1")
               End If

               If srv = 0 Then

                  For Each caspar As CasparCG In _Settings.Servers
                     If caspar.Connected Then
                        If useDVE Then caspar.Mixer_Fill(channel, layer, dveffect)
                        caspar.CG_Add(channel, layer, TemplateName, tmpl, Autoplay, flashLayer)
                     End If
                  Next

               Else

                  If srv <= _Settings.Servers.Count Then
                     Dim caspar As CasparCG = _Settings.Servers(srv - 1)
                     If caspar.Connected Then
                        If useDVE Then caspar.Mixer_Fill(channel, layer, dveffect)
                        caspar.CG_Add(channel, layer, TemplateName, tmpl, Autoplay, flashLayer)
                     End If
                  End If

               End If

               'SlaveSheet processing
               Dim slaveSheet As String = CustomProperties.Load(sheet, "SlaveWorksheet", "")
               If slaveSheet <> "" Then
                  For Each wrk As Microsoft.Office.Interop.Excel.Worksheet In sheet.Application.Sheets
                     If wrk.Name.Trim = slaveSheet Then
                        _SlaveSheet = wrk
                        Exit For
                     End If
                  Next
               End If

               If _SlaveSheet IsNot Nothing Then

                  tmpl = Nothing

                  For Each name As Excel.Name In _SlaveSheet.Names

                     If name.Name.Contains("CasparOutput") Then

                        tmpl = FillTemplate(name, _SlaveSheet)
                        If tmpl Is Nothing Then
                           Exit Sub
                        End If
                        Exit For

                     End If

                  Next

                  TemplateName = CustomProperties.Load(_SlaveSheet, "Template", "")
                  If TemplateName <> "" Then

                     srv = CustomProperties.Load(_SlaveSheet, "ServerNumber", 0)

                     channel = CustomProperties.Load(_SlaveSheet, "Channel", 1)
                     layer = CustomProperties.Load(_SlaveSheet, "Layer", 20)

                     flashLayer = 1
                     If _Settings.UseFlashLayers Then
                        flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
                     End If

                     useDVE = CustomProperties.Load(sheet, "UseDVE", False)

                     dveffect = ""
                     If useDVE Then
                        dveffect = CustomProperties.Load(sheet, "DVEffect", "0 0 1 1")
                     End If

                     If srv = 0 Then

                        For Each caspar As CasparCG In _Settings.Servers
                           If caspar.Connected Then
                              If useDVE Then caspar.Mixer_Fill(channel, layer, dveffect)
                              caspar.CG_Add(channel, layer, TemplateName, tmpl, Autoplay, flashLayer)
                           End If
                        Next

                     Else

                        If srv <= _Settings.Servers.Count Then
                           Dim caspar As CasparCG = _Settings.Servers(srv - 1)
                           If caspar.Connected Then
                              If useDVE Then caspar.Mixer_Fill(channel, layer, dveffect)
                              caspar.CG_Add(channel, layer, TemplateName, tmpl, Autoplay, flashLayer)
                           End If
                        End If

                     End If

                  End If

               End If

               If Autoplay Then
                  PlaybackCtrl.State = ucPlaybackButtons.enumState.stPlaying
               Else
                  PlaybackCtrl.State = ucPlaybackButtons.enumState.stLoaded
               End If

            End If

         End If

      End If

   End Sub

   Public Sub RefreshQueries(sheet As Microsoft.Office.Interop.Excel.Worksheet, PlaybackCtrl As ucPlaybackControls)

      If CustomProperties.Load(sheet, "AutoUpdate", False) Then

         Dim que As String = CustomProperties.Load(sheet, "Queries", "")
         If que <> "" Then

            Dim queries() As String = que.Split("|")

            _SheetWithPendingRefreshes = sheet
            _PlaybackControlWithPendingRefreshes = PlaybackCtrl

            For c As Integer = 0 To queries.Count - 1
               que = queries(c)
               For Each con In _ActiveWorkbook.Connections
                  If con.Name = que Then
                     con.Refresh
                     Exit For
                  End If
               Next
            Next

            PlaybackCtrl.State = ucPlaybackButtons.enumState.stQueryRunning

         End If

      End If

   End Sub

   Public Sub PlayTemplate(sheet As Microsoft.Office.Interop.Excel.Worksheet, PlaybackCtrl As ucPlaybackControls)

      If Not CustomProperties.Load(sheet, "AutoUpdateDataset", False) Then

         Dim srv As Integer = CustomProperties.Load(sheet, "ServerNumber", 0)

         Dim channel As Integer = CustomProperties.Load(sheet, "Channel", 1)
         Dim layer As Integer = CustomProperties.Load(sheet, "Layer", 20)

         Dim flashLayer As Integer = 1
         If _Settings.UseFlashLayers Then
            flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
         End If

         If srv = 0 Then

            For Each caspar As CasparCG In _Settings.Servers
               If caspar.Connected Then
                  caspar.CG_Play(channel, layer, flashLayer)
               End If
            Next

         Else

            If srv <= _Settings.Servers.Count Then
               Dim caspar As CasparCG = _Settings.Servers(srv - 1)
               If caspar.Connected Then
                  caspar.CG_Play(channel, layer, flashLayer)
               End If
            End If

         End If

         'SlaveSheet processing
         If _SlaveSheet IsNot Nothing Then

            srv = CustomProperties.Load(_SlaveSheet, "ServerNumber", 0)

            channel = CustomProperties.Load(_SlaveSheet, "Channel", 1)
            layer = CustomProperties.Load(_SlaveSheet, "Layer", 20)

            flashLayer = 1
            If _Settings.UseFlashLayers Then
               flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
            End If

            If srv = 0 Then

               For Each caspar As CasparCG In _Settings.Servers
                  If caspar.Connected Then
                     caspar.CG_Play(channel, layer, flashLayer)
                  End If
               Next

            Else

               If srv <= _Settings.Servers.Count Then
                  Dim caspar As CasparCG = _Settings.Servers(srv - 1)
                  If caspar.Connected Then
                     caspar.CG_Play(channel, layer, flashLayer)
                  End If
               End If

            End If

         End If

         PlaybackCtrl.State = ucPlaybackButtons.enumState.stPlaying

      End If

   End Sub

   Public Sub PlayNext(sheet As Microsoft.Office.Interop.Excel.Worksheet, PlaybackCtrl As ucPlaybackControls)

      If Not CustomProperties.Load(sheet, "AutoUpdateDataset", False) Then

         Dim srv As Integer = CustomProperties.Load(sheet, "ServerNumber", 0)

         Dim channel As Integer = CustomProperties.Load(sheet, "Channel", 1)
         Dim layer As Integer = CustomProperties.Load(sheet, "Layer", 20)

         Dim flashLayer As Integer = 1
         If _Settings.UseFlashLayers Then
            flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
         End If

         If srv = 0 Then

            For Each caspar As CasparCG In _Settings.Servers
               If caspar.Connected Then
                  caspar.CG_Next(channel, layer, flashLayer)
               End If
            Next

         Else

            If srv <= _Settings.Servers.Count Then
               Dim caspar As CasparCG = _Settings.Servers(srv - 1)
               If caspar.Connected Then
                  caspar.CG_Next(channel, layer, flashLayer)
               End If
            End If

         End If

         'SlaveSheet processing
         If _SlaveSheet IsNot Nothing Then

            srv = CustomProperties.Load(_SlaveSheet, "ServerNumber", 0)

            channel = CustomProperties.Load(_SlaveSheet, "Channel", 1)
            layer = CustomProperties.Load(_SlaveSheet, "Layer", 20)

            flashLayer = 1
            If _Settings.UseFlashLayers Then
               flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
            End If

            If srv = 0 Then

               For Each caspar As CasparCG In _Settings.Servers
                  If caspar.Connected Then
                     caspar.CG_Next(channel, layer, flashLayer)
                  End If
               Next

            Else

               If srv <= _Settings.Servers.Count Then
                  Dim caspar As CasparCG = _Settings.Servers(srv - 1)
                  If caspar.Connected Then
                     caspar.CG_Next(channel, layer, flashLayer)
                  End If
               End If

            End If

         End If

      End If

   End Sub

   Public Sub StoppTemplate(sheet As Microsoft.Office.Interop.Excel.Worksheet, PlaybackCtrl As ucPlaybackControls)

      If Not CustomProperties.Load(sheet, "AutoUpdateDataset", False) Then

         Dim srv As Integer = CustomProperties.Load(sheet, "ServerNumber", 0)

         Dim channel As Integer = CustomProperties.Load(sheet, "Channel", 1)
         Dim layer As Integer = CustomProperties.Load(sheet, "Layer", 20)

         Dim flashLayer As Integer = 1
         If _Settings.UseFlashLayers Then
            flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
         End If

         If srv = 0 Then

            For Each caspar As CasparCG In _Settings.Servers
               If caspar.Connected Then
                  caspar.CG_Stop(channel, layer, flashLayer)
               End If
            Next

         Else

            If srv <= _Settings.Servers.Count Then
               Dim caspar As CasparCG = _Settings.Servers(srv - 1)
               If caspar.Connected Then
                  caspar.CG_Stop(channel, layer, flashLayer)
               End If
            End If

         End If

         PlaybackCtrl.State = ucPlaybackButtons.enumState.stIdle

         'SlaveSheet processing
         If _SlaveSheet IsNot Nothing Then

            srv = CustomProperties.Load(_SlaveSheet, "ServerNumber", 0)

            channel = CustomProperties.Load(_SlaveSheet, "Channel", 1)
            layer = CustomProperties.Load(_SlaveSheet, "Layer", 20)

            flashLayer = 1
            If _Settings.UseFlashLayers Then
               flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
            End If

            If srv = 0 Then

               For Each caspar As CasparCG In _Settings.Servers
                  If caspar.Connected Then
                     caspar.CG_Stop(channel, layer, flashLayer)
                  End If
               Next

            Else

               If srv <= _Settings.Servers.Count Then
                  Dim caspar As CasparCG = _Settings.Servers(srv - 1)
                  If caspar.Connected Then
                     caspar.CG_Stop(channel, layer, flashLayer)
                  End If
               End If

            End If

         End If

      End If

   End Sub

   Public Sub UpdateTemplate(sheet As Microsoft.Office.Interop.Excel.Worksheet, PlaybackCtrl As ucPlaybackControls)

      If PlaybackCtrl IsNot Nothing AndAlso Not PlaybackCtrl.State = ucPlaybackButtons.enumState.stQueryFinished Then
         _PendingRefreshUpdate = True
         RefreshQueries(sheet, PlaybackCtrl)
      End If

      If PlaybackCtrl Is Nothing OrElse Not PlaybackCtrl.State = ucPlaybackButtons.enumState.stQueryRunning Then

         _PendingRefreshUpdate = False

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

         If Not CustomProperties.Load(sheet, "AutoUpdateDataset", False) Then

            Dim srv As Integer = CustomProperties.Load(sheet, "ServerNumber", 0)

            Dim channel As Integer = CustomProperties.Load(sheet, "Channel", 1)
            Dim layer As Integer = CustomProperties.Load(sheet, "Layer", 20)

            Dim flashLayer As Integer = 1
            If _Settings.UseFlashLayers Then
               flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
            End If

            If srv = 0 Then

               For Each caspar As CasparCG In _Settings.Servers
                  If caspar.Connected Then
                     caspar.CG_Update(channel, layer, tmpl, flashLayer)
                  End If
               Next

            Else

               If srv <= _Settings.Servers.Count Then
                  Dim caspar As CasparCG = _Settings.Servers(srv - 1)
                  If caspar.Connected Then
                     caspar.CG_Update(channel, layer, tmpl, flashLayer)
                  End If
               End If

            End If

            'SlaveSheet processing
            If _SlaveSheet IsNot Nothing Then

               tmpl = Nothing

               For Each name As Excel.Name In _SlaveSheet.Names

                  If name.Name.Contains("CasparOutput") Then

                     tmpl = FillTemplate(name, _SlaveSheet)
                     If tmpl Is Nothing Then
                        Exit Sub
                     End If
                     Exit For

                  End If

               Next

               srv = CustomProperties.Load(_SlaveSheet, "ServerNumber", 0)

               channel = CustomProperties.Load(_SlaveSheet, "Channel", 1)
               layer = CustomProperties.Load(_SlaveSheet, "Layer", 20)

               flashLayer = 1
               If _Settings.UseFlashLayers Then
                  flashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
               End If

               If srv = 0 Then

                  For Each caspar As CasparCG In _Settings.Servers
                     If caspar.Connected Then
                        caspar.CG_Update(channel, layer, tmpl, flashLayer)
                     End If
                  Next

               Else

                  If srv <= _Settings.Servers.Count Then
                     Dim caspar As CasparCG = _Settings.Servers(srv - 1)
                     If caspar.Connected Then
                        caspar.CG_Update(channel, layer, tmpl, flashLayer)
                     End If
                  End If

               End If

            End If

            If PlaybackCtrl IsNot Nothing Then
               PlaybackCtrl.State = ucPlaybackButtons.enumState.stOldState
            End If

         End If

      Else
         If PlaybackCtrl IsNot Nothing Then
            PlaybackCtrl.State = ucPlaybackButtons.enumState.stUpdating
         End If
      End If

   End Sub

   Public Sub PreviewTemplate(sheet As Microsoft.Office.Interop.Excel.Worksheet, PlaybackCtrl As ucPlaybackControls)

      If PlaybackCtrl IsNot Nothing AndAlso Not PlaybackCtrl.State = ucPlaybackButtons.enumState.stQueryFinished Then
         _PendingRefreshPreview = True
         RefreshQueries(sheet, PlaybackCtrl)
      End If

      If PlaybackCtrl Is Nothing OrElse Not PlaybackCtrl.State = ucPlaybackButtons.enumState.stQueryRunning Then

         _PendingRefreshPreview = False

         Dim pvw As CasparCG = _Settings.Preview
         If pvw IsNot Nothing AndAlso pvw.Connected Then

            For Each name As Excel.Name In sheet.Names

               If name.Name.Contains("CasparOutput") Then

                  Dim previewTemplateName As String = CustomProperties.Load(sheet, "PreviewTemplate", "")
                  If previewTemplateName = "" Then
                     previewTemplateName = CustomProperties.Load(sheet, "Template", "")
                  End If

                  If previewTemplateName <> "" Then

                     Dim tmpl As Template = FillTemplate(name, sheet)
                     If tmpl Is Nothing Then
                        Exit For
                     End If

                     Dim useDVE As Boolean = CustomProperties.Load(sheet, "UseDVE", False)

                     Dim dveffect As String = ""
                     If useDVE Then
                        dveffect = CustomProperties.Load(sheet, "DVEffect", "0 0 1 1")
                     End If

                     If useDVE Then pvw.Mixer_Fill(_Settings.PreviewChannel, 20, dveffect)
                     pvw.CG_Add(_Settings.PreviewChannel, 20, previewTemplateName, tmpl, True)

                  End If

                  Exit For

               End If

            Next

         End If

      End If

   End Sub

#Region "HTML Helper Functions"

   Private Function ToRangeAddress(col As Integer, row As Integer) As String

      Dim smallCol As Integer = (col - 1) Mod 25
      Dim bigCol As Integer = (col - 1) / 25

      If bigCol > 0 Then
         Return ChrW(bigCol + 65) & ChrW(smallCol + 65) & row.ToString
      Else
         Return ChrW(smallCol + 65) & row.ToString
      End If

   End Function

   Private Function XLHorAlignToString(align As Integer) As String

      Select Case align
         Case -4131
            Return "left"
         Case -4108
            Return "center"
         Case -4152
            Return "right"
         Case -4130
            Return "justify"
         Case Else
            Return "left"
      End Select

   End Function

   Private Function XLVertAlignToString(align As Integer) As String

      Select Case align
         Case -4160
            Return "top"
         Case -4108
            Return "middle"
         Case -4107
            Return "bottom"
         Case Else
            Return "baseline"
      End Select

   End Function

   Private Function XLColorToString(xlcolor As Object, blackAsWhite As Boolean) As String

      Dim color As System.Drawing.Color = ColorTranslator.FromOle(xlcolor)
      If color = Color.Black Then
         color = Color.White
      End If

      Return String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B)

   End Function

   Private Function InteriorColor(interiour As Interior) As String

      If interiour.ColorIndex = -4142 Then
         Return "transparent"
      Else
         Return XLColorToString(interiour.Color, False)
      End If

   End Function

   Private Function XLLineStyleToString(lineStyle As Integer) As String

      Select Case lineStyle
         Case -4115
            Return "dashed"
         Case -4118
            Return "dotted"
         Case -4119
            Return "double"
         Case -4142
            Return "none"
         Case Else
            Return "solid"
      End Select

   End Function

   Private Function XLBorderWeightToString(borderWeight As Integer) As String

      Select Case borderWeight
         Case -4138
            Return "medium"
         Case 4
            Return "thick"
         Case Else
            Return "thin"
      End Select

   End Function

#End Region

   Private Function FillTemplate(name As Excel.Name, wrkSheet As Microsoft.Office.Interop.Excel.Worksheet) As Template
      Dim tmpl As Template = New Template
      Return FillTemplate(name, wrkSheet, tmpl)
   End Function

   Private Function FillTemplate(name As Excel.Name, wrkSheet As Microsoft.Office.Interop.Excel.Worksheet, tmpl As Template) As Template

      Dim range As Excel.Range = name.RefersToRange
      Dim cell As Excel.Range

      Dim varName As Object = Nothing
      Dim varValue As Object = Nothing

      'Dim objClipboard As Object = My.Computer.Clipboard.GetDataObject
      'Dim imgClipboard As System.Drawing.Image
      'Dim blnClipboardUsed As Boolean = False

      'Output-Mode
      Dim mode As String = CustomProperties.Load(wrkSheet, "OutputMode", "")
      Select Case mode
         Case "TABLE"

            Dim blnTextAsWhite As Boolean = CustomProperties.Load(wrkSheet, "TableTextAsWhite", False)
            Dim blnAddBorders As Boolean = CustomProperties.Load(wrkSheet, "TableAddBorders", False)

            'Table Mode
            If range.Columns.Count > 0 And range.Rows.Count > 0 Then

               Dim fld As TemplateField = Nothing

               For row As Integer = 1 To range.Rows.Count

                  For col As Integer = 1 To range.Columns.Count

                     cell = range(row, col)
                     If cell IsNot Nothing Then

                        varName = ToRangeAddress(col, row)
                        varValue = cell.Text

                        If _Settings.UseImageAttributes Then
                           If varValue.ToString.ToLower.StartsWith("file:///") Then
                              fld = New TemplateField(varName.ToString, varValue.ToString, True, TemplateField.enumAttributeType.Image)
                           Else
                              fld = New TemplateField(varName.ToString, varValue.ToString, True)
                           End If
                        Else
                           fld = New TemplateField(varName.ToString, varValue.ToString, True)
                        End If

                        fld.AddAttachement("FontName", cell.Font.Name.ToString)
                        fld.AddAttachement("FontSize", cell.Font.Size.ToString)
                        fld.AddAttachement("FontStyle", IIf(cell.Font.Italic, "italic", "normal"))
                        fld.AddAttachement("FontWeight", IIf(cell.Font.Bold, "bold", "normal"))
                        fld.AddAttachement("FontColor", XLColorToString(cell.Font.Color, blnTextAsWhite))

                        fld.AddAttachement("Background", InteriorColor(cell.Interior))

                        fld.AddAttachement("HorizontalAlignment", XLHorAlignToString(Integer.Parse(cell.HorizontalAlignment.ToString)))
                        fld.AddAttachement("VerticalAlignment", XLVertAlignToString(Integer.Parse(cell.VerticalAlignment.ToString)))

                        If blnAddBorders Then

                           fld.AddAttachement("BorderWidth", String.Format("{0} {1} {2} {3}", XLBorderWeightToString(Integer.Parse(cell.Borders(XlBordersIndex.xlEdgeTop).Weight)),
                                                                                              XLBorderWeightToString(Integer.Parse(cell.Borders(XlBordersIndex.xlEdgeRight).Weight)),
                                                                                              XLBorderWeightToString(Integer.Parse(cell.Borders(XlBordersIndex.xlEdgeBottom).Weight)),
                                                                                              XLBorderWeightToString(Integer.Parse(cell.Borders(XlBordersIndex.xlEdgeLeft).Weight))))

                           fld.AddAttachement("BorderStyle", String.Format("{0} {1} {2} {3}", XLLineStyleToString(Integer.Parse(cell.Borders(XlBordersIndex.xlEdgeTop).LineStyle)),
                                                                                              XLLineStyleToString(Integer.Parse(cell.Borders(XlBordersIndex.xlEdgeRight).LineStyle)),
                                                                                              XLLineStyleToString(Integer.Parse(cell.Borders(XlBordersIndex.xlEdgeBottom).LineStyle)),
                                                                                              XLLineStyleToString(Integer.Parse(cell.Borders(XlBordersIndex.xlEdgeLeft).LineStyle))))

                           fld.AddAttachement("BorderColor", String.Format("{0} {1} {2} {3}", XLColorToString(cell.Borders(XlBordersIndex.xlEdgeTop).Color, blnTextAsWhite),
                                                                                              XLColorToString(cell.Borders(XlBordersIndex.xlEdgeRight).Color, blnTextAsWhite),
                                                                                              XLColorToString(cell.Borders(XlBordersIndex.xlEdgeBottom).Color, blnTextAsWhite),
                                                                                              XLColorToString(cell.Borders(XlBordersIndex.xlEdgeLeft).Color, blnTextAsWhite)))
                        End If

                        fld.AddAttachement("Width", cell.Width.ToString)
                        fld.AddAttachement("Height", cell.Height.ToString)

                        tmpl.Fields.Add(fld)

                     End If

                  Next

               Next

               Return tmpl

            Else
               MsgBox("Invalid range defined, please set the range correctly", MsgBoxStyle.Exclamation, "Invalid Selection")
               Return Nothing
            End If

         Case "HTML"

            If range.Columns.Count > 0 And range.Rows.Count > 0 Then

               Dim firstIsHeader As Boolean = CustomProperties.Load(wrkSheet, "HTMLFirstIsHeader", False)
               Dim fieldname As String = CustomProperties.Load(wrkSheet, "HTMLFieldname", "Table")

               Dim stringwriter As StringWriter = New StringWriter

               Using writer As HtmlTextWriter = New HtmlTextWriter(stringwriter)

                  writer.RenderBeginTag(HtmlTextWriterTag.Table) 'Table

                  For row As Integer = 1 To range.Rows.Count

                     writer.RenderBeginTag(HtmlTextWriterTag.Tr) 'TR

                     For col As Integer = 1 To range.Columns.Count

                        cell = range(row, col)
                        If cell IsNot Nothing Then

                           If row = 1 And firstIsHeader Then

                              writer.AddAttribute(HtmlTextWriterAttribute.Class, LegalizeClassName(cell.Style.Name.ToString))

                              writer.RenderBeginTag(HtmlTextWriterTag.Th)  'TH
                              writer.Write(TemplateField.EncodeText(cell.Text, True))
                              writer.RenderEndTag()  'TH

                           Else

                              writer.AddAttribute(HtmlTextWriterAttribute.Class, LegalizeClassName(cell.Style.Name.ToString))

                              writer.RenderBeginTag(HtmlTextWriterTag.Td)  'TD
                              writer.Write(TemplateField.EncodeText(cell.Text, True))
                              writer.RenderEndTag()  'TD

                           End If

                        End If

                     Next

                     writer.RenderEndTag() 'TR

                  Next

                  writer.RenderEndTag() 'Table

               End Using

               Dim sb As StringBuilder = New StringBuilder()

               sb.Append("<![CDATA[")
               sb.Append(stringwriter.ToString)
               sb.Append("]]>")

               sb.Replace(vbCrLf, "")
               sb.Replace(vbTab, "")
               'sb.Replace("<", "&lt;")
               'sb.Replace(">", "&gt;")

               tmpl.AddField(fieldname, sb.ToString, False, True)

               Dim sheetToAppend As String = CustomProperties.Load(wrkSheet, "SheetToAppend", "")
               If sheetToAppend <> "" Then

                  Dim subSheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing
                  For Each wrk As Microsoft.Office.Interop.Excel.Worksheet In wrkSheet.Application.Sheets
                     If wrk.Name.ToString.Trim() = sheetToAppend Then
                        subSheet = wrk
                        Exit For
                     End If
                  Next

                  If subSheet IsNot Nothing Then
                     For Each subName As Excel.Name In subSheet.Names
                        If subName.Name.Contains("CasparOutput") Then
                           tmpl = FillTemplate(subName, subSheet, tmpl)
                           Exit For
                        End If
                     Next
                  End If

               End If

               Return tmpl

            Else
               MsgBox("Invalid range defined, please set the range correctly", MsgBoxStyle.Exclamation, "Invalid Selection")
               Return Nothing
            End If

         Case Else

            'Standard/Delimited Mode
            Dim deliminter As String = CustomProperties.Load(wrkSheet, "Delimiter", "")
            Select Case deliminter
               Case "TAB"
                  deliminter = vbTab
               Case "COLON"
                  deliminter = ","
               Case "SEMICOLON"
                  deliminter = ";"
            End Select

            If range.Cells.Count > 0 Then

               For row As Integer = 1 To range.Rows.Count

                  cell = range(row, 1)
                  varName = cell.Text

                  'Old code to send cell pictures. Remove?
                  'cell = range(row, 2)
                  'Dim pic As Excel.Shape = GetImage(wrkSheet, row, 2)
                  'If pic IsNot Nothing Then

                  '   If varName IsNot Nothing Then

                  '      blnClipboardUsed = True

                  '      pic.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap)
                  '      imgClipboard = My.Computer.Clipboard.GetData(System.Windows.Forms.DataFormats.Bitmap)

                  '      If imgClipboard IsNot Nothing Then
                  '         tmpl.AddPictureField(varName.ToString, imgClipboard)
                  '      End If


                  '   End If

                  If range.Columns.Count > 2 Then

                     If varName IsNot Nothing AndAlso varName <> "" Then

                        Dim out As String = ""
                        For c As Integer = 2 To range.Columns.Count

                           cell = range(row, c)
                           varValue = cell.Text

                           If varValue Is Nothing Then
                              varValue = ""
                           End If

                           If varValue = "%ignore%" Then
                              Exit For
                           End If

                           If varValue <> "%skip%" Then
                              out += varValue + deliminter
                           End If

                        Next

                        If out <> "" Then
                           tmpl.AddField(varName.ToString, out.Substring(0, out.Length - 1), True)
                        Else
                           tmpl.AddField(varName.ToString, "")
                        End If
                     End If

                  Else

                     cell = range(row, 2)
                     varValue = cell.Text

                     If varName IsNot Nothing Then
                        If varValue IsNot Nothing Then
                           If varName <> "" Then
                              If _Settings.UseImageAttributes Then
                                 If varValue.ToString.ToLower.StartsWith("file:///") Then
                                    tmpl.AddField(varName.ToString, varValue.ToString, True, False, TemplateField.enumAttributeType.Image)
                                 Else
                                    tmpl.AddField(varName.ToString, varValue.ToString, True)
                                 End If
                              Else
                                 tmpl.AddField(varName.ToString, varValue.ToString, True)
                              End If
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
               MsgBox("Invalid range defined, please set the range correctly", MsgBoxStyle.Exclamation, "Invalid Selection")
               Return Nothing
            End If

            'If blnClipboardUsed Then
            '   My.Computer.Clipboard.SetDataObject(objClipboard)
            '   If imgClipboard IsNot Nothing Then
            '      imgClipboard.Dispose()
            '   End If
            'End If

      End Select


   End Function

#End Region

#Region "grpConnections"

   Private Sub togConnect_Click(sender As Object, e As RibbonControlEventArgs) Handles togConnect.Click

      If togConnect.Checked Then
         Globals.ThisAddIn.ConnectAll(_Settings.UseAveco)
      Else
         Globals.ThisAddIn.DisconnectAll()
      End If
      UpdateUIConnectionState()

   End Sub

   Private Sub grpConnections_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpConnections.DialogLauncherClick

      Using fset As frmSettings = New frmSettings

         fset.Settings = _Settings

         fset.ShowDialog()

         If _Settings.ConnectOnStartUp Then
            Globals.ThisAddIn.ConnectAll(_Settings.UseAveco)
         End If

         btnDashboard.Visible = _Settings.ShowDashboard

      End Using

   End Sub

#End Region

#Region "grpSelection"

   Private Sub btnSetOutputRange_Click(sender As Object, e As RibbonControlEventArgs) Handles btnSetOutputRange.Click

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim currRange As Excel.Range = CType(Globals.ThisAddIn.Application.Selection, Excel.Range)

      Dim currWorksheet As Microsoft.Office.Interop.Excel.Worksheet = AppObject.ActiveSheet
      currWorksheet.Names.Add("CasparOutput", currRange)

   End Sub

#End Region

#Region "grpDataset"

   Private Sub DoSaveDataSet(AppObject As Microsoft.Office.Interop.Excel.Workbook, currWorksheet As Microsoft.Office.Interop.Excel.Worksheet, Silent As Boolean)

      For Each name As Excel.Name In currWorksheet.Names

         If name.Name.Contains("CasparOutput") Then

            Dim DatasetName As String = CustomProperties.Load(currWorksheet, "DataSetName", "")
            If DatasetName = "" Then

               If Silent Then

                  CustomProperties.Save(currWorksheet, "DataSetName", currWorksheet.Name)

               Else

                  Dim fsp As frmSheetProperties = New frmSheetProperties
                  fsp.wrkSheet = currWorksheet
                  fsp.Settings = _Settings
                  fsp.Ribbon = Me

                  If fsp.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                     Exit For
                  End If

               End If

            End If

            DatasetName = CustomProperties.Load(currWorksheet, "DataSetName", "")
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

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      DoSaveDataSet(AppObject, AppObject.ActiveSheet, False)

   End Sub

   Private Sub btnSaveAllDataSets_Click(sender As Object, e As RibbonControlEventArgs) Handles btnSaveAllDataSets.Click

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      For Each wrk As Microsoft.Office.Interop.Excel.Worksheet In AppObject.Sheets
         DoSaveDataSet(AppObject, wrk, True)
      Next

   End Sub

   Private Sub grpDataset_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpDataset.DialogLauncherClick

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Using fsp As frmSheetProperties = New frmSheetProperties

         fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeCommon
         fsp.wrkSheet = AppObject.ActiveSheet
         fsp.Settings = _Settings
         fsp.Ribbon = Me

         If fsp.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AppObject.Saved = False
            If _Dashboard.Visible Then
               _Dashboard.RefreshPlaybackControls()
            End If
            UpdateTimerSheets()
         End If

      End Using

   End Sub

#End Region

#Region "grpPreview"

   Private Sub UpdatePreview(sheet As Microsoft.Office.Interop.Excel.Worksheet)

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

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = AppObject.ActiveSheet

      If CustomProperties.Load(sheet, "IsDashboardList", False) Then

         _Dashboard.PlayPreview()

      Else

         Dim previewTemplateName As String = CustomProperties.Load(sheet, "PreviewTemplate", "")
         Dim TemplateName As String = CustomProperties.Load(sheet, "Template", "")

         If previewTemplateName = "" Then
            previewTemplateName = TemplateName
         End If

         If TemplateName = "" Then
            Dim fsp As frmSheetProperties = New frmSheetProperties
            fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeCommon
            fsp.Settings = _Settings
            fsp.wrkSheet = sheet
            fsp.Ribbon = Me

            If fsp.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
               Exit Sub
            Else
               previewTemplateName = CustomProperties.Load(sheet, "PreviewTemplate", "")
               If previewTemplateName = "" Then
                  Exit Sub
               Else
                  AppObject.Saved = False
               End If
            End If
         End If

         PreviewTemplate(sheet, Nothing)

      End If

   End Sub

   Private Sub grpPreview_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpPreview.DialogLauncherClick

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Using fsp As frmSheetProperties = New frmSheetProperties

         fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeCommon
         fsp.wrkSheet = AppObject.ActiveSheet
         fsp.Settings = _Settings
         fsp.Ribbon = Me

         If fsp.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            AppObject.Saved = False
            If _Dashboard.Visible Then
               _Dashboard.RefreshPlaybackControls()
            End If
            UpdateTimerSheets()
         End If

      End Using

   End Sub

#End Region

#Region "grpInsert"

   Private Function GetImage(wrkSheet As Microsoft.Office.Interop.Excel.Worksheet, row As Integer, col As Integer) As Excel.Shape

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

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim ofd As OpenFileDialog = New OpenFileDialog

      Dim basePath As String = CustomProperties.Load(AppObject.ActiveSheet, "ImageBaseFolder", "")

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
            CustomProperties.Save(AppObject.ActiveSheet, "ImageBaseFolder", IO.Path.GetDirectoryName(fName))
         End If

      End If

   End Sub

   Private Sub btnBaseFolder_Click(sender As Object, e As RibbonControlEventArgs) Handles btnBaseFolder.Click

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim fbd As FolderBrowserDialog = New FolderBrowserDialog

      Dim basePath As String = CustomProperties.Load(AppObject.ActiveSheet, "ImageBaseFolder", "")
      If basePath = "" Then
         basePath = My.Computer.FileSystem.SpecialDirectories.MyPictures
      End If

      fbd.SelectedPath = basePath
      fbd.ShowNewFolderButton = False

      If fbd.ShowDialog = DialogResult.OK Then
         CustomProperties.Save(AppObject.ActiveSheet, "ImageBaseFolder", fbd.SelectedPath)
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

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
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

#Region "grpAutoUpdate"

   'Private Sub AutoUpdate(sheet As Worksheet)

   '   If CustomProperties.Load(sheet, "AutoUpdate") = "1" Then

   '      If _SheetWithPendingRefreshes Is sheet Then

   '         _PendingRefreshesIndex += 1

   '         Dim que As String = CustomProperties.Load(sheet, "Queries")
   '         If que <> "" Then
   '            Dim queries() As String = que.Split("|")

   '            If _PendingRefreshesIndex = queries.Count Then

   '               _SheetWithPendingRefreshes = Nothing
   '               _PendingRefreshesIndex = 0

   '               LoadTemplate(sheet, _PendingRefreshAutoplay)

   '            ElseIf _PendingRefreshesIndex < queries.Count Then

   '               que = queries(_PendingRefreshesIndex)
   '               For Each con In _ActiveWorkbook.Connections
   '                  If con.Name = que Then
   '                     con.Refresh
   '                  End If
   '               Next

   '               _timAutoUpdate.Interval = 200
   '               _timAutoUpdate.Start()

   '            End If

   '         End If

   '      End If

   '   End If

   'End Sub

   Private Sub DoBrowserRefresh(ByVal AppObject As Microsoft.Office.Interop.Excel.Workbook, ByVal currWorksheet As Microsoft.Office.Interop.Excel.Worksheet, ByRef ErrorText As String)

      Dim webAddress As String = CustomProperties.Load(currWorksheet, "WebURL", "")

      If webAddress <> "" Then

         Dim fwb As frmWebbrowser = New frmWebbrowser
         fwb.ShowUI = False

         fwb.Settings = _Settings
         fwb.WebAddress = webAddress
         fwb.DomLocation = CustomProperties.Load(currWorksheet, "WebDomLocation", "")
         Dim mode As String = CustomProperties.Load(currWorksheet, "WebMode", "")

         If mode = "Table" Then
            fwb.Mode = frmWebbrowser.enumMode.modeTable
         ElseIf mode = "Div" Then
            fwb.Mode = frmWebbrowser.enumMode.modeDiv
         End If

         fwb.ShowDialog()

         If fwb.Result = frmWebbrowser.enumResult.resData Then

            Dim dt As Data.DataTable = fwb.Data
            If dt IsNot Nothing Then

               Dim range As Excel.Range = currWorksheet.Cells

               For row As Integer = 0 To dt.Rows.Count - 1

                  Dim dr As Data.DataRow = dt.Rows(row)
                  If dr IsNot Nothing Then

                     For col As Integer = 0 To dt.Columns.Count - 1
                        Dim cell As Excel.Range = range(row + 2, col + 1)
                        Dim txt As String = dr(col).ToString
                        cell.Value = txt
                     Next

                  End If

               Next

            End If

         ElseIf fwb.Result = frmWebbrowser.enumResult.resTimedout Then

            ErrorText += String.Format("Webpage: '{0}' timed out while trying to load.{1}", webAddress, vbNewLine)

         End If

         fwb.Dispose()

      End If

   End Sub

   Private Sub togAutoUpdate_Click(sender As Object, e As RibbonControlEventArgs) Handles togAutoUpdate.Click

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim currWorksheet As Microsoft.Office.Interop.Excel.Worksheet = AppObject.ActiveSheet

      If togAutoUpdate.Checked Then
         CustomProperties.Save(currWorksheet, "AutoUpdate", "1")
      Else
         CustomProperties.Save(currWorksheet, "AutoUpdate", "0")
      End If

   End Sub

   Private Sub btnBrowser_Click(sender As Object, e As RibbonControlEventArgs) Handles btnBrowser.Click

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim currWorksheet As Microsoft.Office.Interop.Excel.Worksheet = AppObject.ActiveSheet

      Dim fwb As frmWebbrowser = New frmWebbrowser
      fwb.ShowUI = True

      fwb.Settings = _Settings
      fwb.WebAddress = CustomProperties.Load(currWorksheet, "WebURL", "")
      fwb.DomLocation = CustomProperties.Load(currWorksheet, "WebDomLocation", "")
      Dim mode As String = CustomProperties.Load(currWorksheet, "WebMode", "")

      If mode = "Table" Then
         fwb.Mode = frmWebbrowser.enumMode.modeTable
      ElseIf mode = "Div" Then
         fwb.Mode = frmWebbrowser.enumMode.modeDiv
      End If

      If fwb.ShowDialog() = DialogResult.OK Then

         If fwb.Result = frmWebbrowser.enumResult.resStore Then

            CustomProperties.Save(currWorksheet, "WebURL", fwb.WebAddress)
            CustomProperties.Save(currWorksheet, "WebDomLocation", fwb.DomLocation)

            If fwb.Mode = frmWebbrowser.enumMode.modeTable Then
               CustomProperties.Save(currWorksheet, "WebMode", "Table")
            ElseIf fwb.Mode = frmWebbrowser.enumMode.modeDiv Then
               CustomProperties.Save(currWorksheet, "WebMode", "Div")
            End If

            btnBrowserRefresh.Enabled = True

         End If

         If fwb.Result = frmWebbrowser.enumResult.resData Or fwb.Result = frmWebbrowser.enumResult.resStore Then

            Dim dt As Data.DataTable = fwb.Data
            If dt IsNot Nothing Then

               Dim range As Excel.Range = currWorksheet.Cells

               For row As Integer = 0 To dt.Rows.Count - 1

                  Dim dr As Data.DataRow = dt.Rows(row)
                  If dr IsNot Nothing Then

                     For col As Integer = 0 To dt.Columns.Count - 1
                        Dim cell As Excel.Range = range(row + 2, col + 1)
                        Dim txt As String = dr(col).ToString
                        cell.Value = txt
                     Next

                  End If

               Next

            End If
         End If
      End If

      fwb.Dispose()

   End Sub

   Private Sub btnBrowserRefresh_Click(sender As Object, e As RibbonControlEventArgs) Handles btnBrowserRefresh.Click

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
      Dim currWorksheet As Microsoft.Office.Interop.Excel.Worksheet = AppObject.ActiveSheet

      Dim errorText As String = ""
      DoBrowserRefresh(AppObject, currWorksheet, errorText)

      If errorText <> "" Then
         MsgBox(errorText, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Timeout")
      End If

   End Sub

   Private Sub btnRefreshData_Click(sender As Object, e As RibbonControlEventArgs) Handles btnRefreshData.Click

      btnRefreshData.Enabled = False
      btnRefreshData.PerformLayout()

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Dim errorText As String = ""
      For Each wrk As Microsoft.Office.Interop.Excel.Worksheet In AppObject.Sheets
         DoBrowserRefresh(AppObject, wrk, errorText)
      Next

      If errorText <> "" Then

         btnRefreshData.Enabled = True
         MsgBox(errorText, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Refresh All")

      Else

         _PendingRefreshAllStep = 1

         _RefreshAllWebConnections = New List(Of Object)
         _RefreshAllTableConnections = New List(Of Object)

         If _ActiveWorkbook.Connections.Count > 0 AndAlso _ActiveWorkbook.Queries.Count > 0 Then

            For Each con In _ActiveWorkbook.Connections

               Dim query As Object = Nothing

               For Each que In _ActiveWorkbook.Queries
                  If con.Name.ToString.Contains(que.Name.ToString) Then
                     query = que
                     Exit For
                  End If
               Next

               If query IsNot Nothing Then

                  If query.Formula.ToString.Contains("Web.Contents") Then
                     _RefreshAllWebConnections.Add(con)
                  Else
                     _RefreshAllTableConnections.Add(con)
                  End If

               Else
                  _RefreshAllTableConnections.Add(con)
               End If

            Next

         End If

         If _RefreshAllWebConnections.Count > 0 Then

            For Each con In _RefreshAllWebConnections
               con.Refresh
            Next

         Else
            btnRefreshData.Enabled = True
         End If

      End If

   End Sub

   Private Sub grpAutoUpdate_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpAutoUpdate.DialogLauncherClick

      Dim AppObject As Microsoft.Office.Interop.Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook

      Using fsp As frmSheetProperties = New frmSheetProperties

         fsp.DialogMode = frmSheetProperties.enumDialogMode.ModeAutoUpdate
         fsp.wrkSheet = AppObject.ActiveSheet
         fsp.Settings = _Settings
         fsp.Ribbon = Me

         If fsp.ShowDialog() = DialogResult.OK Then
            AppObject.Saved = False
            If _Dashboard.Visible Then
               _Dashboard.RefreshPlaybackControls()
            End If
            UpdateTimerSheets()
         End If

      End Using

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

   Private Sub btnListPane_Click(sender As Object, e As RibbonControlEventArgs) Handles btnListPane.Click
      If _Dashboard IsNot Nothing Then
         _Dashboard.ListPaneVisible = Not _Dashboard.ListPaneVisible
      End If
   End Sub

   Private Sub btnListSettings_Click(sender As Object, e As RibbonControlEventArgs) Handles btnTimerPane.Click

      grpTimer.Visible = Not grpTimer.Visible

      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then
         grpLap.Visible = grpTimer.Visible And _TimerSettings.SelectedItem.UseLaps
      Else
         grpLap.Visible = False
      End If

      Globals.ThisAddIn.Application.ActiveWorkbook.Saved = False

   End Sub

   'Private Sub _timAutoUpdate_Tick(sender As Object, e As EventArgs) Handles _timAutoUpdate.Tick
   '   _timAutoUpdate.Stop()
   '   AutoUpdate(_SheetWithPendingRefreshes)
   'End Sub


#End Region

#Region "grpTimer"

   Public Sub LoadTimerSettings()

      If _ActiveWorkbook IsNot Nothing Then

         _xmlId = CustomDocumentProperties.Load(_ActiveWorkbook, "XML_ID", "")
         If _xmlId <> "" Then

            Dim xml As String = CustomXML.Load(_ActiveWorkbook, _xmlId)
            _TimerSettings = New TimerSettings(xml)

         End If

         If _TimerSettings IsNot Nothing Then

            _TimerSettings.TempID = _xmlId

            'Restore Timer if necessary
            Dim ts As TimerSettings = New TimerSettings(_TimerSettingsFilename)
            If ts IsNot Nothing AndAlso ts.TempID = _xmlId Then
               If MsgBox("Load the backup-data?", vbQuestion Or vbYesNo Or MsgBoxStyle.DefaultButton1, "Backup-data") = MsgBoxResult.Yes Then
                  _TimerSettings = ts
               End If
            End If

            If _TimerSettings.Items.Count = 0 Then
               Dim item As TimerItem = New TimerItem("Default")
               _TimerSettings.Items.Add(item)
               _TimerSettings.SelectedItem = item
            End If

            'Run timer if necessary
            _TimerSettings.RunTimer()

            Set_ItemControls()
            UpdateTimerSheets()

         End If

      End If

   End Sub

   Private Sub Set_ItemControls()

      cboItems.Items.Clear()
      Dim rddi As RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem

      If _TimerSettings.Items.Count = 0 Then
         rddi.Label = "(None)"
         cboItems.Items.Add(rddi)
         cboItems.Text = "(None)"
      End If

      If _TimerSettings IsNot Nothing Then

         For Each item As TimerItem In _TimerSettings.Items
            rddi = Me.Factory.CreateRibbonDropDownItem
            rddi.Label = item.Name
            cboItems.Items.Add(rddi)
         Next

         If _TimerSettings.SelectedItem IsNot Nothing Then
            cboItems.Text = _TimerSettings.SelectedItem.Name
         End If

         If _TimerSettings.SelectedItem IsNot Nothing Then
            btnPauseTimer.Visible = _TimerSettings.SelectedItem.CanPause
         End If

      End If

      Set_LapControls()

   End Sub

   Public Sub UpdateTimerSheets()

      If _TimerSettings IsNot Nothing Then

         Dim dic As Dictionary(Of String, Microsoft.Office.Interop.Excel.Worksheet) = New Dictionary(Of String, Microsoft.Office.Interop.Excel.Worksheet)
         For Each ws As Microsoft.Office.Interop.Excel.Worksheet In _ActiveWorkbook.Sheets
            dic.Add(ws.Name.ToString.Trim, ws)
         Next

         Dim cnt As Integer = 0
         Dim ts As TimerSheet = Nothing
         Dim sheet As Microsoft.Office.Interop.Excel.Worksheet = Nothing

         Do While _TimerSettings.Sheets.Count > cnt

            ts = _TimerSettings.Sheets(cnt)

            If dic.ContainsKey(ts.WorksheetName) Then

               sheet = dic(ts.WorksheetName)

               ts.Server = CustomProperties.Load(sheet, "ServerNumber", 0)
               ts.Channel = CustomProperties.Load(sheet, "Channel", 1)
               ts.Layer = CustomProperties.Load(sheet, "Layer", 20)

               ts.FlashLayer = 1
               If _Settings.UseFlashLayers Then
                  ts.FlashLayer = CustomProperties.Load(sheet, "FlashLayer", 1)
               End If

               cnt += 1

            Else
               _TimerSettings.Sheets.Remove(ts)
               _ActiveWorkbook.Saved = False
            End If

         Loop

         _TimerSettings.SaveBackupData()

      End If

   End Sub

   Public Sub SaveTimerSettings()
      If _TimerSettings IsNot Nothing AndAlso _ActiveWorkbook IsNot Nothing Then
         _xmlId = CustomXML.Save(_ActiveWorkbook, _xmlId, _TimerSettings.toXmlString)
         CustomDocumentProperties.Save(_ActiveWorkbook, "XML_ID", _xmlId)
      End If
   End Sub

   Public Sub ReleaseTimerSettingsEvents()
      If _TimerSettings IsNot Nothing Then
         _TimerSettings.ReleaseEvents()
      End If
   End Sub

   Private Sub grpTimer_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpTimer.DialogLauncherClick

      If _TimerSettings Is Nothing Then
         _TimerSettings = New TimerSettings()
      End If

      If _TimerSettings IsNot Nothing Then

         Using fts As frmTimerSettings = New frmTimerSettings

            fts.TimerSettings = _TimerSettings

            If fts.ShowDialog() = DialogResult.OK Then

               _ActiveWorkbook.Saved = False
               Set_ItemControls()
               _TimerSettings.SaveBackupData()

            End If

         End Using

      End If

   End Sub

   Private Sub _TimerSettings_TimerRefresh(sender As Object, e As TimerSettings.TimerRefreshEventArgs) Handles _TimerSettings.TimerRefresh

      If _TimerSettings IsNot Nothing AndAlso e.Item IsNot Nothing Then

         If _TimerSettings.SelectedItem.Name = e.Item.Name Then
            txtTimerPreview.Text = e.Item.GetFormatedTime(e.Time)
         End If

         For Each ts As TimerSheet In _TimerSettings.Sheets

            Dim tmpl As Template = New Template
            For Each tf As TimerField In ts.Fields

               If tf.ItemName = e.Item.Name Then
                  tmpl.AddField(tf.FieldName, e.Item.QueryValue(tf.QueryValue))
               End If

            Next

            If tmpl.Fields.Count > 0 Then

               If ts.Server = 0 Then

                  For Each caspar As CasparCG In _Settings.Servers
                     If caspar.Connected Then
                        caspar.CG_Update(ts.Channel, ts.Layer, tmpl, ts.FlashLayer)
                     End If
                  Next

               Else

                  If ts.Server <= _Settings.Servers.Count Then
                     Dim caspar As CasparCG = _Settings.Servers(ts.Server - 1)
                     If caspar.Connected Then
                        caspar.CG_Update(ts.Channel, ts.Layer, tmpl, ts.FlashLayer)
                     End If
                  End If

               End If

            End If

         Next

      End If

   End Sub

   Private Sub _TimerSettings_SaveTimerData(sender As Object, e As EventArgs) Handles _TimerSettings.SaveTimerData
      If _TimerSettings IsNot Nothing Then
         _TimerSettings.Save(_TimerSettingsFilename)
         Try
            _ActiveWorkbook.Saved = False
         Catch ex As Exception
         End Try
      End If
   End Sub


   Private Sub btnTimerPlus_Click(sender As Object, e As RibbonControlEventArgs) Handles btnTimerPlus.Click
      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then
         _TimerSettings.SelectedItem.Plus()
      End If
   End Sub

   Private Sub btnTimerMinus_Click(sender As Object, e As RibbonControlEventArgs) Handles btnTimerMinus.Click
      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then
         _TimerSettings.SelectedItem.Minus()
      End If
   End Sub

   Private Sub btnStartTimer_Click(sender As Object, e As RibbonControlEventArgs) Handles btnStartTimer.Click
      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then
         _TimerSettings.SelectedItem.StartTimer()
      End If
   End Sub

   Private Sub btnPauseTimer_Click(sender As Object, e As RibbonControlEventArgs) Handles btnPauseTimer.Click
      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then
         _TimerSettings.SelectedItem.PauseTimer()
      End If
   End Sub

   Private Sub btnStopTimer_Click(sender As Object, e As RibbonControlEventArgs) Handles btnStopTimer.Click
      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then
         If MsgBox("Do you really want to stop the timer?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1, "Stop Timer") = MsgBoxResult.Yes Then
            _TimerSettings.SelectedItem.StopTimer()
         End If
      End If
   End Sub

   Private Sub cboItems_TextChanged(sender As Object, e As RibbonControlEventArgs) Handles cboItems.TextChanged

      If _TimerSettings IsNot Nothing Then

         _TimerSettings.SelectedItem = Nothing

         For Each item As TimerItem In _TimerSettings.Items
            If item.Name = cboItems.Text Then
               _TimerSettings.SelectedItem = item
               Exit For
            End If
         Next

         If _TimerSettings.SelectedItem IsNot Nothing Then
            btnPauseTimer.Visible = _TimerSettings.SelectedItem.CanPause
         End If

         Set_LapControls()

      End If

   End Sub


#End Region

#Region "grpLap"

   Private Sub Set_LapControls()

      cboLap.Items.Clear()
      Dim rddi As RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
      rddi.Label = "(None)"
      cboLap.Items.Add(rddi)
      cboLap.Text = "(None)"

      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then

         For Each lap As TimerLap In _TimerSettings.SelectedItem.Laps
            rddi = Me.Factory.CreateRibbonDropDownItem
            rddi.Label = lap.Name
            cboLap.Items.Add(rddi)
         Next

         If _TimerSettings.SelectedItem.SelectedLap IsNot Nothing Then
            cboLap.Text = _TimerSettings.SelectedItem.SelectedLap.Name
         End If

         grpLap.Visible = grpTimer.Visible And _TimerSettings.SelectedItem.UseLaps

      End If

   End Sub

   Private Sub cboLap_TextChanged(sender As Object, e As RibbonControlEventArgs) Handles cboLap.TextChanged

      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then

         _TimerSettings.SelectedItem.SelectedLap = Nothing

         For Each lap As TimerLap In _TimerSettings.SelectedItem.Laps
            If lap.Name = cboLap.Text Then
               _TimerSettings.SelectedItem.SelectedLap = lap
               Exit For
            End If
         Next

      End If

   End Sub

   Private Sub btnLapPause_Click(sender As Object, e As RibbonControlEventArgs) Handles btnLapPause.Click
      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then
         _TimerSettings.SelectedItem.LapTimer()
      End If
   End Sub

   Private Sub btnLapResume_Click(sender As Object, e As RibbonControlEventArgs) Handles btnLapResume.Click
      If _TimerSettings IsNot Nothing AndAlso _TimerSettings.SelectedItem IsNot Nothing Then
         _TimerSettings.SelectedItem.ResumeTimer()
      End If
   End Sub

   Private Sub grpLap_DialogLauncherClick(sender As Object, e As RibbonControlEventArgs) Handles grpLap.DialogLauncherClick

      If _TimerSettings IsNot Nothing Then

         Using ftl As frmTimerLaps = New frmTimerLaps

            ftl.TimerSettings = _TimerSettings

            If ftl.ShowDialog() = DialogResult.OK Then

               _ActiveWorkbook.Saved = False

               Set_LapControls()
               _TimerSettings.SaveBackupData()

            End If

         End Using

      End If

   End Sub

#End Region

End Class

