Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel
Imports CasparObjects
Imports System.Diagnostics
Imports CasparCGAddIn
Imports Bespoke.Common.Osc
Imports System.Net

Public Class ucDashboard

   Public Enum enumDockingMode
      dmFloating
      dmVertical
      dmHorizontal
   End Enum

   Public Enum enumOSCEvents
      oscNone
      oscLoad
      oscPlay
      oscNext
      oscStop
      oscUpdate
      oscPreview
   End Enum

#Region "Proverties and module level variables"

   Private _Settings As Settings
   Private _IsCasparConnected As Boolean

   Private _ActiveWorkbook As Workbook
   Private _CasparRibon As ribCasparCG

   Private _ControlsSet As ucPlaybackButtons.enumControlSets = ucPlaybackButtons.enumControlSets.csLoadPlayStopUpdate
   Private _isLoaded As Boolean = False

   Private WithEvents _listSheet As Worksheet
   Private _currentRow As Integer = 0
   Private _currentCol As String = "A"

   'Private _PendingRefresh As Boolean = False
   Private _PendingRefreshAutoplay As Boolean = False
   Private _PendingRefreshUpdate As Boolean = False
   Private _PendingRefreshPreview As Boolean = False

   Private _ServerNumber As Integer = 1
   Private _Channel As Integer = 1
   Private _Layer As Integer = 20
   Private _DataFields As String = ""
   Private _AutoClearEffect As String = "CUT"
   Private _AutoClearEffectDuration As Integer = 0

   Private _DockingMode As enumDockingMode = enumDockingMode.dmVertical

   Private WithEvents _ResizeTimer As Timer = New Timer
   Private WithEvents _server As OscServer = Nothing

   Public Property ListPaneVisible As Boolean
      Get
         Return panList.Visible
      End Get
      Set(value As Boolean)
         panList.Visible = value
         _ResizeTimer.Interval = 100
         _ResizeTimer.Start()
      End Set
   End Property


   Public WriteOnly Property Settings As Settings
      Set(value As Settings)

         _Settings = value

         If _Settings IsNot Nothing Then

            MyColorThemes.Loader.LoadControl(Me, _Settings.Theme)

            If _DataFields = "" Then
               _DataFields = _Settings.DefaultDataFields
            End If

            If _Settings.UseOSCInput Then
               _server = New OscServer(TransportType.Udp, IPAddress.Loopback, _Settings.OSCInputPort)
               _server.FilterRegisteredMethods = False
               _server.Start()
            End If

         End If

      End Set
   End Property

   Public WriteOnly Property IsCasparConnected As Boolean
      Set(value As Boolean)

         _IsCasparConnected = value

         If _IsCasparConnected Then
            RefreshComboboxes()
         End If

      End Set
   End Property

   Public WriteOnly Property ActiveWorkbook As Workbook
      Set(value As Workbook)
         _ActiveWorkbook = value
         RefreshPlaybackControls()
      End Set
   End Property

   Public WriteOnly Property CasparRibon As ribCasparCG
      Set(value As ribCasparCG)
         _CasparRibon = value
      End Set
   End Property

   Public WriteOnly Property DockingMode As enumDockingMode
      Set(value As enumDockingMode)
         _DockingMode = value
      End Set
   End Property

   Public Property ControlsSet As ucPlaybackButtons.enumControlSets
      Get
         Return pbPlaybackButtons.ControlsSet
      End Get
      Set(value As ucPlaybackButtons.enumControlSets)
         pbPlaybackButtons.ControlsSet = value
      End Set
   End Property

#End Region

#Region "Helper Functions"

   ''' <summary>
   ''' Handles the worksheet based PlaybackButtons
   ''' </summary>
   ''' <param name="sender">Event source</param>
   ''' <param name="e">Indicates the workshhet to use and what commnad to be executed</param>
   Private Sub CommandEvent(sender As Object, e As ucPlaybackButtons.CommandEventArgs)

      If _CasparRibon IsNot Nothing AndAlso e.Sheet IsNot Nothing AndAlso sender IsNot Nothing Then

         Dim pbc As ucPlaybackControls = CType(sender, ucPlaybackControls)
         If pbc IsNot Nothing Then

            Select Case e.Command

               Case ucPlaybackButtons.enumCommandType.ctLoad
                  _CasparRibon.LoadTemplate(e.Sheet, False, pbc)

               Case ucPlaybackButtons.enumCommandType.ctPlay
                  _CasparRibon.PlayTemplate(e.Sheet, pbc)

               Case ucPlaybackButtons.enumCommandType.ctLoadAndPlay
                  _CasparRibon.LoadTemplate(e.Sheet, True, pbc)

               Case ucPlaybackButtons.enumCommandType.ctNext
                  _CasparRibon.PlayNext(e.Sheet, pbc)

               Case ucPlaybackButtons.enumCommandType.ctStop
                  _CasparRibon.StoppTemplate(e.Sheet, pbc)

               Case ucPlaybackButtons.enumCommandType.ctUpdate
                  _CasparRibon.UpdateTemplate(e.Sheet, pbc)

               Case ucPlaybackButtons.enumCommandType.ctPreview
                  _CasparRibon.PreviewTemplate(e.Sheet, pbc)

            End Select

         End If

      End If

   End Sub

   Private Sub RefreshComboboxes()

      If _listSheet IsNot Nothing AndAlso _IsCasparConnected Then

         Dim srv As Integer = CustomProperties.Load(_listSheet, "ServerNumber", 1)
         If srv <= _Settings.Servers.Count Then

            Dim caspar As CasparCG = _Settings.Servers(srv - 1)
            If caspar.Connected Then

               cboTemplates.Items.Clear()
               Dim lst As List(Of String) = caspar.GetTemplateNames()
               For Each s As String In lst
                  cboTemplates.Items.Add(s)
               Next

               cboAudio.Items.Clear()
               lst = caspar.GetMediaClipsNames(CasparCG.MediaTypes.Audio)
               For Each s As String In lst
                  cboAudio.Items.Add(s)
               Next

               cboImages.Items.Clear()
               lst = caspar.GetMediaClipsNames(CasparCG.MediaTypes.Still)
               For Each s As String In lst
                  cboImages.Items.Add(s)
               Next

               cboVideo.Items.Clear()
               lst = caspar.GetMediaClipsNames(CasparCG.MediaTypes.Movie)
               For Each s As String In lst
                  cboVideo.Items.Add(s)
               Next


            End If

         End If

      End If

   End Sub

   Public Sub FlagAfterCalculate()

      If _listSheet IsNot Nothing AndAlso pbPlaybackButtons.State = ucPlaybackButtons.enumState.stQueryRunning Then

         pbPlaybackButtons.State = ucPlaybackButtons.enumState.stQueryFinished

         If _PendingRefreshUpdate Then
            UpdateTemplate()
         ElseIf _PendingRefreshPreview Then
            LoadTemplateOrClip(True, True)
         Else
            LoadTemplateOrClip(_PendingRefreshAutoplay, False)
         End If

         _PendingRefreshAutoplay = False
         _PendingRefreshPreview = False
         _PendingRefreshUpdate = False

      End If

   End Sub

#End Region

#Region "Caspar Functions for List-sheet"

   Private Sub RunQuery(Autoplay As Boolean, Preview As Boolean)

      If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

         Dim range As Excel.Range = _listSheet.Cells
         Dim cell As Excel.Range = Nothing

         If CustomProperties.Load(_listSheet, "AutoUpdate", False) Then

            cell = range(_currentRow, 1)
            If cell.Value IsNot Nothing AndAlso cell.Text.ToString.StartsWith("{") Then

               Dim que As String = cell.Text.ToString.Substring(1, cell.Text.ToString.Length - 2)

               For Each con In _ActiveWorkbook.Connections
                  If con.Name = que Then

                     con.Refresh

                     _PendingRefreshAutoplay = Autoplay
                     _PendingRefreshPreview = Preview
                     pbPlaybackButtons.State = ucPlaybackButtons.enumState.stQueryRunning

                     Exit For

                  End If

               Next

            End If

         End If

      End If

   End Sub

   Private Sub LoadTemplateOrClip(Autoplay As Boolean, Preview As Boolean)

      If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

         Dim range As Excel.Range = _listSheet.Cells
         Dim cell As Excel.Range = Nothing

         'Template/Clip
         cell = range(_currentRow, 2)
         Dim tmplClipName As String = cell.Text

         'Channel
         cell = range(_currentRow, 4)
         Dim channel As Integer = 0
         If Not Integer.TryParse(cell.Text, channel) Then
            channel = _Channel
         End If

         'Layer
         cell = range(_currentRow, 5)
         Dim layer As Integer = 0
         If Not Integer.TryParse(cell.Text, layer) Then
            layer = _Layer
         End If

         'Kind
         cell = range(_currentRow, 3)
         Dim kind As String = cell.Text.ToString.ToUpper()

         If kind = "T" Then

            If Not pbPlaybackButtons.State = ucPlaybackButtons.enumState.stQueryFinished Then
               RunQuery(Autoplay, Preview)
            End If

            If Not pbPlaybackButtons.State = ucPlaybackButtons.enumState.stQueryRunning Then

               Dim col As Integer = 6
               Dim fieldName As String = ""
               Dim fieldValue As String = ""
               Dim tmpl As Template = New Template
               Do
                  cell = range(1, col)
                  fieldName = cell.Text
                  If fieldName = "" Then Exit Do

                  cell = range(_currentRow, col)
                  fieldValue = cell.Text

                  tmpl.AddField(fieldName, fieldValue)
                  col += 1
               Loop

               If Preview Then

                  Dim pvw As CasparCG = _Settings.Preview
                  pvw.CG_Add(_Settings.PreviewChannel, 20, tmplClipName, tmpl, True)

               Else

                  If _ServerNumber = 0 Then
                     For Each caspar As CasparCG In _Settings.Servers
                        If caspar.Connected Then
                           caspar.CG_Add(channel, layer, tmplClipName, tmpl, Autoplay)
                        End If
                     Next
                  Else
                     If _ServerNumber <= _Settings.Servers.Count Then
                        Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                        If caspar.Connected Then
                           caspar.CG_Add(channel, layer, tmplClipName, tmpl, Autoplay)
                        End If
                     End If
                  End If

                  If Autoplay Then
                     pbPlaybackButtons.State = ucPlaybackButtons.enumState.stPlaying
                     _isLoaded = False
                  Else
                     pbPlaybackButtons.State = ucPlaybackButtons.enumState.stLoaded
                     _isLoaded = True
                  End If

               End If

            End If

         ElseIf kind = "A" Or kind = "I" Or kind = "V" Then

            Dim col As Integer = 6
            Do
               cell = range(1, col)
               If cell.Text = "" Then Exit Do
               col += 1
            Loop
            col += 1

            'Loop
            Dim doLoop As Boolean = False
            cell = range(1, col)
            If cell.Text = "Loop" Then
               cell = range(_currentRow, col)
               If cell.Text = "1" Then
                  doLoop = True
               End If
            End If
            col += 1

            'Effect
            Dim effect As String = ""
            cell = range(1, col)
            If cell.Text = "Effect" Then
               cell = range(_currentRow, col)
               effect = cell.Text
            End If
            col += 1

            'Duration
            Dim duration As Integer = 12
            cell = range(1, col)
            If cell.Text = "Duration" Then
               cell = range(_currentRow, col)
               If IsNumeric(cell.Text.ToString) Then
                  If Not Integer.TryParse(cell.Text, duration) Then
                     duration = 12
                  End If
               End If
            End If
            col += 1

            'Direction
            Dim direction As String = ""
            cell = range(1, col)
            If cell.Text = "Direction" Then
               cell = range(_currentRow, col)
               direction = cell.Text
            End If
            col += 1

            'Autoplay
            Dim seemlessplay As Boolean = False
            cell = range(1, col)
            If cell.Text = "Autoplay" Then
               cell = range(_currentRow, col)
               Dim inte As Integer = 0
               If IsNumeric(cell.Text.ToString) Then
                  If Integer.TryParse(cell.Text, inte) Then
                     seemlessplay = (inte = 1)
                  End If
               End If
            End If
            col += 1

            'Show 1st Frame
            Dim showFirstFrame As Boolean = False
            cell = range(1, col)
            If cell.Text = "Show 1st Frame" Then
               cell = range(_currentRow, col)
               Dim inte As Integer = 0
               If IsNumeric(cell.Text.ToString) Then
                  If Integer.TryParse(cell.Text, inte) Then
                     showFirstFrame = (inte = 1)
                  End If
               End If
            End If
            col += 1

            'Auto Clear
            Dim autoClear As Boolean = False
            cell = range(1, col)
            If cell.Text = "Auto Clear" Then
               cell = range(_currentRow, col)
               Dim inte As Integer = 0
               If IsNumeric(cell.Text.ToString) Then
                  If Integer.TryParse(cell.Text, inte) Then
                     autoClear = (inte = 1)
                  End If
               End If
            End If
            col += 1

            If Preview Then

               Dim pvw As CasparCG = _Settings.Preview
               pvw.Play(_Settings.PreviewChannel, 20, tmplClipName, doLoop, effect, duration, direction, "Linear")

            Else

               If _ServerNumber = 0 Then
                  For Each caspar As CasparCG In _Settings.Servers
                     If caspar.Connected Then
                        If Autoplay Then
                           caspar.Play(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear")
                           If autoClear Then
                              caspar.LoadBG(channel, layer, "EMPTY", False, _AutoClearEffect, _AutoClearEffectDuration, "", "linear", True)
                           End If
                        Else
                           If showFirstFrame Then
                              caspar.Load(channel, layer, tmplClipName)
                           Else
                              caspar.LoadBG(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear", seemlessplay)
                           End If
                        End If
                     End If
                  Next
               Else
                  If _ServerNumber <= _Settings.Servers.Count Then
                     Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                     If caspar.Connected Then
                        If Autoplay Then
                           caspar.Play(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear")
                           If autoClear Then
                              caspar.LoadBG(channel, layer, "EMPTY", False, _AutoClearEffect, _AutoClearEffectDuration, "", "linear", True)
                           End If
                        Else
                           If showFirstFrame Then
                              caspar.Load(channel, layer, tmplClipName)
                           Else
                              caspar.LoadBG(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear", seemlessplay)
                           End If
                        End If
                     End If
                  End If
               End If

               If Autoplay Then
                  pbPlaybackButtons.State = ucPlaybackButtons.enumState.stPlaying
                  _isLoaded = False
               Else
                  pbPlaybackButtons.State = ucPlaybackButtons.enumState.stLoaded
                  _isLoaded = True
               End If

            End If

         End If

      End If

   End Sub

   Private Sub PlayTemplateOrClip()

      If Not _isLoaded Then

         LoadTemplateOrClip(True, False)

      Else

         If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

            Dim range As Excel.Range = _listSheet.Cells

            'Template/Clip
            Dim cell As Excel.Range = range(_currentRow, 2)
            Dim tmplClipName As String = cell.Text

            'Channel
            cell = range(_currentRow, 4)
            Dim channel As Integer = 0
            If Not Integer.TryParse(cell.Text, channel) Then
               channel = _Channel
            End If

            'Layer
            cell = range(_currentRow, 5)
            Dim layer As Integer = 0
            If Not Integer.TryParse(cell.Text, layer) Then
               layer = _Layer
            End If

            'Kind
            cell = range(_currentRow, 3)
            Dim kind As String = cell.Text.ToString.ToUpper()
            If kind = "T" Then

               If _ServerNumber = 0 Then
                  For Each caspar As CasparCG In _Settings.Servers
                     If caspar.Connected Then
                        caspar.CG_Play(channel, layer)
                     End If
                  Next
               Else
                  If _ServerNumber <= _Settings.Servers.Count Then
                     Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                     If caspar.Connected Then
                        caspar.CG_Play(channel, layer)
                     End If
                  End If
               End If

            ElseIf kind = "A" Or kind = "I" Or kind = "V" Then

               'Auto Clear
               Dim autoClear As Boolean = False
               Dim col As Integer = 6
               Do
                  cell = range(1, col)
                  If cell.Text = "Auto Clear" Then
                     cell = range(_currentRow, col)
                     Dim inte As Integer = 0
                     If IsNumeric(cell.Text.ToString) Then
                        If Integer.TryParse(cell.Text, inte) Then
                           autoClear = (inte = 1)
                           Exit Do
                        End If
                     End If
                     Exit Do
                  End If
                  col += 1
               Loop Until col > 50

               If _ServerNumber = 0 Then
                  For Each caspar As CasparCG In _Settings.Servers
                     If caspar.Connected Then
                        caspar.Play(channel, layer)
                        If autoClear Then
                           caspar.LoadBG(channel, layer, "EMPTY", False, _AutoClearEffect, _AutoClearEffectDuration, "", "linear", True)
                        End If
                     End If
                  Next
               Else
                  If _ServerNumber <= _Settings.Servers.Count Then
                     Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                     If caspar.Connected Then
                        caspar.Play(channel, layer)
                        If autoClear Then
                           caspar.LoadBG(channel, layer, "EMPTY", False, _AutoClearEffect, _AutoClearEffectDuration, "", "linear", True)
                        End If
                     End If
                  End If
               End If

            End If

         End If

         pbPlaybackButtons.State = ucPlaybackButtons.enumState.stPlaying
         _isLoaded = False

      End If

   End Sub

   Private Sub PlayNext()

      If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

         Dim range As Excel.Range = _listSheet.Cells

         'Channel
         Dim cell As Excel.Range = range(_currentRow, 4)
         Dim channel As Integer = 0
         If Not Integer.TryParse(cell.Text, channel) Then
            channel = _Channel
         End If

         'Layer
         cell = range(_currentRow, 5)
         Dim layer As Integer = 0
         If Not Integer.TryParse(cell.Text, layer) Then
            layer = _Layer
         End If

         'Kind
         cell = range(_currentRow, 3)
         Dim kind As String = cell.Text.ToString.ToUpper()
         If kind = "T" Then

            If _ServerNumber = 0 Then
               For Each caspar As CasparCG In _Settings.Servers
                  If caspar.Connected Then
                     caspar.CG_Next(channel, layer)
                  End If
               Next
            Else
               If _ServerNumber <= _Settings.Servers.Count Then
                  Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                  If caspar.Connected Then
                     caspar.CG_Next(channel, layer)
                  End If
               End If
            End If

         End If

      End If

   End Sub

   Private Sub StopTemplateOrClip()

      If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

         Dim range As Excel.Range = _listSheet.Cells

         'Channel
         Dim cell As Excel.Range = range(_currentRow, 4)
         Dim channel As Integer = 0
         If Not Integer.TryParse(cell.Text, channel) Then
            channel = _Channel
         End If

         'Layer
         cell = range(_currentRow, 5)
         Dim layer As Integer = 0
         If Not Integer.TryParse(cell.Text, layer) Then
            layer = _Layer
         End If

         'Kind
         cell = range(_currentRow, 3)
         Dim kind As String = cell.Text.ToString.ToUpper()
         If kind = "T" Then

            If _ServerNumber = 0 Then
               For Each caspar As CasparCG In _Settings.Servers
                  If caspar.Connected Then
                     caspar.CG_Stop(channel, layer)
                  End If
               Next
            Else
               If _ServerNumber <= _Settings.Servers.Count Then
                  Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                  If caspar.Connected Then
                     caspar.CG_Stop(channel, layer)
                  End If
               End If
            End If

         ElseIf kind = "A" Or kind = "I" Or kind = "V" Then

            Dim col As Integer = 6
            Do
               cell = range(1, col)
               If cell.Text = "" Then Exit Do
               col += 1
            Loop
            col += 2

            'Effect
            Dim effect As String = ""
            cell = range(1, col)
            If cell.Text = "Effect" Then
               cell = range(_currentRow, col)
               effect = cell.Text
            End If
            col += 1

            'Duration
            Dim duration As Integer = 12
            cell = range(1, col)
            If cell.Text = "Duration" Then
               cell = range(_currentRow, col)
               If IsNumeric(cell.Text.ToString) Then
                  If Not Integer.TryParse(cell.Text, duration) Then
                     duration = 12
                  End If
               End If
            End If
            col += 1

            'Direction
            Dim direction As String = ""
            cell = range(1, col)
            If cell.Text = "Direction" Then
               cell = range(_currentRow, col)
               direction = cell.Text
            End If

            If _ServerNumber = 0 Then
               For Each caspar As CasparCG In _Settings.Servers
                  If caspar.Connected Then
                     If effect <> "" Then
                        caspar.Play(channel, layer, "EMPTY", False, effect, duration, direction, "Linear")
                     Else
                        caspar.Stopp(channel, layer)
                     End If
                  End If
               Next
            Else
               If _ServerNumber <= _Settings.Servers.Count Then
                  Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                  If caspar.Connected Then
                     If effect <> "" Then
                        caspar.Play(channel, layer, "EMPTY", False, effect, duration, direction, "Linear")
                     Else
                        caspar.Stopp(channel, layer)
                     End If
                  End If
               End If
            End If

         End If

         pbPlaybackButtons.State = ucPlaybackButtons.enumState.stIdle

      End If

   End Sub

   Private Sub UpdateTemplate()

      If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

         Dim range As Excel.Range = _listSheet.Cells

         'Channel
         Dim cell As Excel.Range = range(_currentRow, 4)
         Dim channel As Integer = 0
         If Not Integer.TryParse(cell.Text, channel) Then
            channel = _Channel
         End If

         'Layer
         cell = range(_currentRow, 5)
         Dim layer As Integer = 0
         If Not Integer.TryParse(cell.Text, layer) Then
            layer = _Layer
         End If

         'Kind
         cell = range(_currentRow, 3)
         Dim kind As String = cell.Text.ToString.ToUpper()
         If kind = "T" Then

            If Not pbPlaybackButtons.State = ucPlaybackButtons.enumState.stQueryFinished Then
               _PendingRefreshUpdate = True
               RunQuery(False, False)
            End If

            If Not pbPlaybackButtons.State = ucPlaybackButtons.enumState.stQueryRunning Then

               Dim col As Integer = 6
               Dim fieldName As String = ""
               Dim fieldValue As String = ""
               Dim tmpl As Template = New Template
               Do
                  cell = range(1, col)
                  fieldName = cell.Text
                  If fieldName = "" Then Exit Do

                  cell = range(_currentRow, col)
                  fieldValue = cell.Text

                  tmpl.AddField(fieldName, fieldValue)
                  col += 1
               Loop

               If _ServerNumber = 0 Then
                  For Each caspar As CasparCG In _Settings.Servers
                     If caspar.Connected Then
                        caspar.CG_Update(channel, layer, tmpl)
                     End If
                  Next
               Else
                  If _ServerNumber <= _Settings.Servers.Count Then
                     Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                     If caspar.Connected Then
                        caspar.CG_Update(channel, layer, tmpl)
                     End If
                  End If
               End If

            End If

         End If

      End If

   End Sub

#End Region

#Region "Methods"

   Public Sub PlayPreview()
      LoadTemplateOrClip(True, True)
   End Sub

   Public Sub RefreshPlaybackControls()

      If _ActiveWorkbook IsNot Nothing Then

         _listSheet = Nothing

         cboTemplates.Visible = False
         btnCreate.Visible = True

         For Each pc As Control In flpFlow.Controls

            If TypeOf pc Is ucPlaybackControls Then
               RemoveHandler CType(pc, ucPlaybackControls).CommandEvent, AddressOf CommandEvent
            End If

         Next
         flpFlow.Controls.Clear()

         Dim slaveSheets As HashSet(Of String) = New HashSet(Of String)
         If _Settings.InhibitPlayback4Slave Then

            Dim slaveSheet As String = ""
            For Each sh As Worksheet In _ActiveWorkbook.Worksheets
               slaveSheet = CustomProperties.Load(sh, "SlaveWorksheet", "").Trim
               If slaveSheet <> "" And sh.Name.Trim <> slaveSheet Then
                  slaveSheets.Add(slaveSheet)
               End If
            Next

         End If

         For Each sheet As Worksheet In _ActiveWorkbook.Worksheets

            If Not slaveSheets.Contains(sheet.Name.Trim) Then

               If CustomProperties.Load(sheet, "Template", "") <> "" Then

                  If CustomProperties.Load(sheet, "ShowInDashboard", True) Then

                     Dim upCntr As ucPlaybackControls = New ucPlaybackControls
                     upCntr.Settings = _Settings
                     upCntr.Sheet = sheet

                     'Add to flpFlow 
                     flpFlow.Controls.Add(upCntr)
                     upCntr.ControlsSet = CustomProperties.Load(sheet, "ControlsSet", CInt(ucPlaybackButtons.enumControlSets.csLoadPlayStopUpdate))
                     AddHandler upCntr.CommandEvent, AddressOf CommandEvent

                  End If

               End If

               If _listSheet Is Nothing AndAlso CustomProperties.Load(sheet, "IsDashboardList", False) Then

                  _listSheet = sheet

                  cboTemplates.Visible = True
                  btnCreate.Visible = False

                  panTop.Enabled = True
                  pbPlaybackButtons.Enabled = True
                  pbPlaybackButtons.Sheet = _listSheet

                  lnkLabelRefreshLists.Visible = True
                  lnklblQueries.Visible = True

                  RefreshComboboxes()

                  'Load ControlsSet from the _listSheet
                  Me.ControlsSet = CustomProperties.Load(_listSheet, "ControlsSet", CInt(ucPlaybackButtons.enumControlSets.csLoadPlayStopUpdate))
                  _currentRow = 0
                  panList.Enabled = False

               End If

            End If

         Next

         ListPaneVisible = (_listSheet IsNot Nothing)

      End If

   End Sub

#End Region

#Region "UI Event Handlers etc."

   Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click

      If _listSheet IsNot Nothing Then

         _ServerNumber = CustomProperties.Load(_listSheet, "ServerNumber", 1)
         _Channel = CustomProperties.Load(_listSheet, "Channel", 1)
         _Layer = CustomProperties.Load(_listSheet, "Layer", 20)

         Dim flds As String = CustomProperties.Load(_listSheet, "DataFields", "")
         If flds = "" Then
            flds = "f0|f1|f2|f3|f4|f5"
         End If
         _DataFields = flds

         _AutoClearEffect = CustomProperties.Load(_listSheet, "AutoClearEffect", "CUT")
         _AutoClearEffectDuration = CustomProperties.Load(_listSheet, "AutoClearEffectDuration", 0)

         Me.ControlsSet = CustomProperties.Load(_listSheet, "ControlsSet", 0)

      End If

      Dim fds As frmDashboardSettings = New frmDashboardSettings

      Dim lst As List(Of String) = New List(Of String)

      For Each casp As CasparCG In _Settings.Servers
         lst.Add(casp.Name)
      Next

      fds.CasparServerNames = lst

      fds.Settings = _Settings
      fds.ServerNumber = _ServerNumber
      fds.Channel = _Channel
      fds.Layer = _Layer
      fds.DataFields = _DataFields
      fds.ControlsSet = Me.ControlsSet
      fds.AutoClearEffect = _AutoClearEffect
      fds.AutoClearEffectDuration = _AutoClearEffectDuration

      If fds.ShowDialog = DialogResult.OK Then

         _ServerNumber = fds.ServerNumber
         _Channel = fds.Channel
         _Layer = fds.Layer

         _DataFields = fds.DataFields
         _Settings.DefaultDataFields = _DataFields

         _AutoClearEffect = fds.AutoClearEffect
         _AutoClearEffectDuration = fds.AutoClearEffectDuration

         Me.ControlsSet = fds.ControlsSet

         If _listSheet IsNot Nothing Then

            CustomProperties.Save(_listSheet, "ServerNumber", _ServerNumber.ToString)
            CustomProperties.Save(_listSheet, "Channel", _Channel.ToString)
            CustomProperties.Save(_listSheet, "Layer", _Layer.ToString)
            CustomProperties.Save(_listSheet, "DataFields", _DataFields)
            CustomProperties.Save(_listSheet, "ControlsSet", CInt(Me.ControlsSet).ToString)
            CustomProperties.Save(_listSheet, "AutoClearEffect", _AutoClearEffect)
            CustomProperties.Save(_listSheet, "AutoClearEffectDuration", _AutoClearEffectDuration)

            _ActiveWorkbook.Saved = False

         End If

      End If

   End Sub

   Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

      btnCreate.Visible = False

      Dim range As Excel.Range = Nothing
      Dim cell As Excel.Range = Nothing

      If _ActiveWorkbook.Worksheets.Count > 1 Then
         Dim first As Worksheet = _ActiveWorkbook.Worksheets(1)
         _listSheet = _ActiveWorkbook.Worksheets.Add(first)
      Else
         _listSheet = _ActiveWorkbook.Worksheets.Add()
      End If

      _listSheet.Name = "List"

      range = _listSheet.Cells()

      'Cue
      cell = range(1, 1)
      cell.Value = "Cue/Query"
      cell.Font.Bold = True

      'Template/Clip
      cell = range(1, 2)
      cell.Value = "Template/Clip"
      cell.Font.Bold = True

      'Kind
      cell = range(1, 3)
      cell.Value = "Kind"
      cell.Font.Bold = True

      'Channel
      cell = range(1, 4)
      cell.Value = "Channel"
      cell.Font.Bold = True

      'Layer
      cell = range(1, 5)
      cell.Value = "Layer"
      cell.Font.Bold = True

      'DataFields
      If _DataFields = "" Then
         _DataFields = "f0|f1|f2|f3|f4|f5"
      End If

      Dim col As Integer = 6
      Dim fldsArray() As String = _DataFields.Split("|")

      For Each fld As String In fldsArray

         cell = range(1, col)
         cell.Value = fld
         cell.Font.Bold = True

         col += 1

      Next
      col += 1

      cell = range(1, col)
      cell.Value = "Loop"
      cell.Font.Bold = True
      col += 1

      cell = range(1, col)
      cell.Value = "Effect"
      cell.Font.Bold = True
      col += 1

      cell = range(1, col)
      cell.Value = "Duration"
      cell.Font.Bold = True
      col += 1

      cell = range(1, col)
      cell.Value = "Direction"
      cell.Font.Bold = True
      col += 1

      cell = range(1, col)
      cell.Value = "Autoplay"
      cell.Font.Bold = True
      col += 1

      cell = range(1, col)
      cell.Value = "Show 1st Frame"
      cell.Font.Bold = True
      col += 1

      cell = range(1, col)
      cell.Value = "Auto Clear"
      cell.Font.Bold = True
      col += 1

      CustomProperties.Save(_listSheet, "IsDashboardList", "1")

      CustomProperties.Save(_listSheet, "ServerNumber", _ServerNumber.ToString)
      CustomProperties.Save(_listSheet, "Channel", _Channel.ToString)
      CustomProperties.Save(_listSheet, "Layer", _Layer.ToString)
      CustomProperties.Save(_listSheet, "DataFields", _DataFields)
      CustomProperties.Save(_listSheet, "ControlsSet", CInt(Me.ControlsSet).ToString)
      CustomProperties.Save(_listSheet, "AutoClearEffect", _AutoClearEffect)
      CustomProperties.Save(_listSheet, "AutoClearEffectDuration", _AutoClearEffectDuration)

      _ActiveWorkbook.Saved = False

      cboTemplates.Visible = True
      lnkLabelRefreshLists.Visible = True
      lnklblQueries.Visible = True
      panTop.Enabled = True
      pbPlaybackButtons.Enabled = True

      RefreshComboboxes()

   End Sub

   Private Sub lnkLabelRefreshLists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLabelRefreshLists.LinkClicked
      RefreshComboboxes()
   End Sub

   Private Sub lnklblQueries_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblQueries.LinkClicked

      Dim fsq As frmSelectQuery = New frmSelectQuery
      fsq.Settings = _Settings
      fsq.wrkSheet = _listSheet
      fsq.currentRow = _currentRow

      fsq.ShowDialog()

   End Sub

   Private Sub rbTemplate_Click(sender As Object, e As EventArgs) Handles rbTemplate.Click
      If _listSheet IsNot Nothing AndAlso rbTemplate.Checked Then
         cboTemplates.Visible = True
         cboAudio.Visible = False
         cboImages.Visible = False
         cboVideo.Visible = False
      End If
   End Sub

   Private Sub rbAudio_Click(sender As Object, e As EventArgs) Handles rbAudio.Click
      If rbAudio.Checked Then
         cboTemplates.Visible = False
         cboAudio.Visible = True
         cboImages.Visible = False
         cboVideo.Visible = False
      End If
   End Sub

   Private Sub rbImage_Click(sender As Object, e As EventArgs) Handles rbImage.Click
      If rbImage.Checked Then
         cboTemplates.Visible = False
         cboAudio.Visible = False
         cboImages.Visible = True
         cboVideo.Visible = False
      End If
   End Sub

   Private Sub rbVideo_Click(sender As Object, e As EventArgs) Handles rbVideo.Click
      If rbVideo.Checked Then
         cboTemplates.Visible = False
         cboAudio.Visible = False
         cboImages.Visible = False
         cboVideo.Visible = True
      End If
   End Sub

   ''' <summary>
   ''' Handles the dashboards own PlaybackButtons
   ''' </summary>
   ''' <param name="sender">Event source</param>
   ''' <param name="e">Indicates what commnad to be executed</param>
   Private Sub pbPlaybackButtons_CommandEvent(sender As Object, e As ucPlaybackButtons.CommandEventArgs) Handles pbPlaybackButtons.CommandEvent

      Select Case e.Command

         Case ucPlaybackButtons.enumCommandType.ctLoad
            LoadTemplateOrClip(False, False)

         Case ucPlaybackButtons.enumCommandType.ctLoadAndPlay
            LoadTemplateOrClip(True, False)

         Case ucPlaybackButtons.enumCommandType.ctPlay
            PlayTemplateOrClip()

         Case ucPlaybackButtons.enumCommandType.ctNext
            PlayNext()

         Case ucPlaybackButtons.enumCommandType.ctStop
            StopTemplateOrClip()

         Case ucPlaybackButtons.enumCommandType.ctUpdate
            UpdateTemplate()

         Case ucPlaybackButtons.enumCommandType.ctPreview
            LoadTemplateOrClip(True, True)

      End Select

   End Sub


   Private Sub ucDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load

      If _listSheet IsNot Nothing Then

         _ServerNumber = CustomProperties.Load(_listSheet, "ServerNumber", 1)
         _Channel = CustomProperties.Load(_listSheet, "Channel", 1)
         _Layer = CustomProperties.Load(_listSheet, "Layer", 20)

         _DataFields = CustomProperties.Load(_listSheet, "DataFields", "")
         _AutoClearEffect = CustomProperties.Load(_listSheet, "AutoClearEffect", "CUT")
         _AutoClearEffectDuration = CustomProperties.Load(_listSheet, "AutoClearEffectDuration", 0)

         Me.ControlsSet = CustomProperties.Load(_listSheet, "ControlsSet", CInt(ucPlaybackButtons.enumControlSets.csLoadPlayStopUpdate))

      Else
         Me.ControlsSet = ucPlaybackButtons.enumControlSets.csLoadPlayStopUpdate
      End If

      cboTemplates.Visible = False
      cboAudio.Left = cboTemplates.Left
      cboAudio.Visible = False
      cboImages.Left = cboTemplates.Left
      cboImages.Visible = False
      cboVideo.Left = cboTemplates.Left
      cboVideo.Visible = False
      lnkLabelRefreshLists.Visible = False
      lnklblQueries.Visible = False

      btnCreate.Top = 0
      btnCreate.Enabled = True

      panTop.Enabled = False
      panMiddle.Enabled = True
      pbPlaybackButtons.Enabled = False

      panList.Enabled = True

   End Sub

   Private Sub _ResizeTimer_Tick(sender As Object, e As EventArgs) Handles _ResizeTimer.Tick

      _ResizeTimer.Stop()

      If _DockingMode = enumDockingMode.dmFloating Then

         panList.Size = New System.Drawing.Size(627, 89)
         panList.Location = New System.Drawing.Point(0, Me.Height - panList.Height)

         panTop.Location = New System.Drawing.Point(0, 30)
         panMiddle.Location = New System.Drawing.Point(211, 30)
         pbPlaybackButtons.Location = New System.Drawing.Point(420, 30)

         If panList.Visible Then
            flpFlow.Size = New System.Drawing.Size(Me.Width, Me.Height - panList.Height)
         Else
            flpFlow.Size = New System.Drawing.Size(Me.Width, Me.Height)
         End If

      ElseIf _DockingMode = enumDockingMode.dmHorizontal Then

         panList.Size = New System.Drawing.Size(627, 89)
         panList.Location = New System.Drawing.Point(Me.Width - panList.Width, 0)

         panTop.Location = New System.Drawing.Point(0, 30)
         panMiddle.Location = New System.Drawing.Point(211, 30)
         pbPlaybackButtons.Location = New System.Drawing.Point(420, 30)

         If panList.Visible Then
            flpFlow.Size = New System.Drawing.Size(Me.Width - panList.Width, Me.Height)
         Else
            flpFlow.Size = New System.Drawing.Size(Me.Width, Me.Height)
         End If

      Else     'enumDockingMode.dmVertical

         panList.Size = New System.Drawing.Size(205, 190)
         panList.Location = New System.Drawing.Point(0, Me.Height - panList.Height)

         panTop.Location = New System.Drawing.Point(0, 30)
         panMiddle.Location = New System.Drawing.Point(0, 82)
         pbPlaybackButtons.Location = New System.Drawing.Point(0, 134)

         If panList.Visible Then
            flpFlow.Size = New System.Drawing.Size(Me.Width, Me.Height - panList.Height)
         Else
            flpFlow.Size = New System.Drawing.Size(Me.Width, Me.Height)
         End If

      End If

   End Sub

   Private Sub ucDashboard_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      If Not _ResizeTimer.Enabled Then
         _ResizeTimer.Interval = 100
         _ResizeTimer.Start()
      End If
   End Sub

   Private Sub SetCells(templateOrClipName As String, Kind As String)

      If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

         Dim range As Excel.Range = _listSheet.Cells

         'Cue/Query
         Dim cell As Excel.Range = range(_currentRow, 1)
         If cell.Text = "" And cell.HasFormula = False Then
            cell.Value = _currentRow - 1
         End If

         'Template/Clip
         cell = range(_currentRow, 2)
         If cell.HasFormula = False Then
            cell.Value = templateOrClipName
         End If

         'Type/Kind
         cell = range(_currentRow, 3)
         If cell.HasFormula = False Then
            cell.Value = Kind
         End If

         'Channel
         cell = range(_currentRow, 4)
         If cell.Text = "" And cell.HasFormula = False Then
            cell.Value = _Channel
         End If

         'Layer
         cell = range(_currentRow, 5)
         If cell.Text = "" And cell.HasFormula = False Then
            cell.Value = _Layer
         End If

      End If

   End Sub

   Private Sub cboTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTemplates.SelectedIndexChanged
      If cboTemplates.SelectedIndex > -1 Then
         SetCells(cboTemplates.Items(cboTemplates.SelectedIndex), "T")
      End If
   End Sub

   Private Sub cboAudio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAudio.SelectedIndexChanged
      If cboAudio.SelectedIndex > -1 Then
         SetCells(cboAudio.Items(cboAudio.SelectedIndex), "A")
      End If
   End Sub

   Private Sub cboImages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboImages.SelectedIndexChanged
      If cboImages.SelectedIndex > -1 Then
         SetCells(cboImages.Items(cboImages.SelectedIndex), "I")
      End If
   End Sub

   Private Sub cboVideo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVideo.SelectedIndexChanged
      If cboVideo.SelectedIndex > -1 Then
         SetCells(cboVideo.Items(cboVideo.SelectedIndex), "V")
      End If
   End Sub

   Private Sub _listSheet_SelectionChange(Target As Range) Handles _listSheet.SelectionChange

      _currentRow = Target.Row
      panList.Enabled = (_currentRow > 1)

      If Target.Column < 27 Then
         _currentCol = ChrW(Target.Column + 64).ToString
      Else
         _currentCol = "Z"
      End If

   End Sub

   Private Sub ucDashboard_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed
      If _server IsNot Nothing Then
         _server.Stop()
      End If
   End Sub

   Private Sub _server_MessageReceived(sender As Object, e As OscMessageReceivedEventArgs) Handles _server.MessageReceived

      Static savedCol As String = ""
      Static savedRow As Integer = 0

      If e.Message IsNot Nothing AndAlso e.Message.Data.Count > 0 Then

         Dim adr As String = ""
         If Not e.Message.Address = "" Then
            adr = e.Message.Address.Trim.ToLower
         End If

         If TypeOf e.Message.Data(0) Is String Then

            Dim com As String = e.Message.Data(0).ToString.Trim.ToLower

            If adr.Contains("listsheet") Then

               If _ActiveWorkbook.ActiveSheet.Name = _listSheet.Name Then

                  Dim rng As Range = Nothing

                  Select Case com
                     Case "load"
                        pbPlaybackButtons.DoLoad(True)

                     Case "play"
                        pbPlaybackButtons.DoPlay(True)

                     Case "next"
                        pbPlaybackButtons.DoNext(True)

                     Case "stop"
                        pbPlaybackButtons.DoStop(True)

                     Case "update"
                        pbPlaybackButtons.DoUpdate(True)

                     Case "preview"
                        LoadTemplateOrClip(True, True)

                     Case "first"
                        rng = _listSheet.Range(String.Format("{0}2", _currentCol))
                        rng.Select()

                     Case "up"
                        If _currentRow > 1 Then
                           rng = _listSheet.Range(String.Format("{0}{1}", _currentCol, _currentRow - 1))
                           rng.Select()
                        End If

                     Case "down"
                        rng = _listSheet.Range(String.Format("{0}{1}", _currentCol, _currentRow + 1))
                        rng.Select()

                     Case "last"
                        Dim s As String = _currentCol
                        rng = _listSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing)
                        rng = _listSheet.Range(String.Format("{0}{1}", s, rng.Row))
                        rng.Select()

                     Case "pageup"
                        Dim cnt As Integer = _ActiveWorkbook.Application.ActiveWindow.VisibleRange.Rows.Count
                        If _currentRow > cnt Then
                           rng = _listSheet.Range(String.Format("{0}{1}", _currentCol, _currentRow - cnt))
                           rng.Select()
                        Else
                           rng = _listSheet.Range(String.Format("{0}2", _currentCol))
                           rng.Select()
                        End If

                     Case "pagedown"
                        Dim cnt As Integer = _ActiveWorkbook.Application.ActiveWindow.VisibleRange.Rows.Count
                        rng = _listSheet.Range(String.Format("{0}{1}", _currentCol, _currentRow + cnt))
                        rng.Select()

                     Case "savepos"
                        savedCol = _currentCol
                        savedRow = _currentRow

                     Case "loadpos"
                        If savedCol <> "" And savedRow > 0 Then
                           rng = _listSheet.Range(String.Format("{0}{1}", savedCol, savedRow))
                           rng.Select()
                        End If

                     Case Else
                        Try
                           rng = _listSheet.Range(com.ToUpper)
                           rng.Select()
                        Catch ex As Exception
                           'Ignore
                        End Try

                  End Select

               End If

            Else

               Dim cmd As enumOSCEvents = enumOSCEvents.oscNone

               Select Case com
                  Case "load"
                     cmd = enumOSCEvents.oscLoad
                  Case "play"
                     cmd = enumOSCEvents.oscPlay
                  Case "next"
                     cmd = enumOSCEvents.oscNext
                  Case "stop"
                     cmd = enumOSCEvents.oscStop
                  Case "update"
                     cmd = enumOSCEvents.oscUpdate
                  Case "preview"
                     cmd = enumOSCEvents.oscPreview
               End Select

               If Not cmd = enumOSCEvents.oscNone Then

                  For Each pc As Control In flpFlow.Controls

                     If TypeOf pc Is ucPlaybackControls Then
                        CType(pc, ucPlaybackControls).HandleOscCommand(adr, cmd)
                     End If

                  Next

               End If

            End If

         End If

      End If

   End Sub


#End Region

End Class
