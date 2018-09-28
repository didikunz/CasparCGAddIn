Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel
Imports CasparObjects

Public Class ucDashboard

   Public Enum enumDockingMode
      dmFloating
      dmVertical
      dmHorizontal
   End Enum

   Private _Settings As Settings
   Private _IsCasparConnected As Boolean

   Private _ActiveWorkbook As Workbook
   Private _CasparRibon As ribCasparCG

   Private _ControlsSet As ucPlaybackControls.enumControlSets = ucPlaybackControls.enumControlSets.csLoadPlayStopUpdate
   Private _isLoaded As Boolean = False

   Private WithEvents _listSheet As Worksheet
   Private _currentRow As Integer = 0
   Private _pendingRefresh As Boolean = False
   Private _pendingAutoplay As Boolean = False

   Private _ServerNumber As Integer = 1
   Private _Channel As Integer = 1
   Private _Layer As Integer = 20
   Private _DataFields As String = ""

   Private _DockingMode As enumDockingMode = enumDockingMode.dmVertical


   Public WriteOnly Property Settings As Settings
      Set(value As Settings)

         _Settings = value

         If _Settings IsNot Nothing Then

            If _DataFields = "" Then
               _DataFields = _Settings.DefaultDataFields
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

            For Each sheet As Worksheet In _ActiveWorkbook.Worksheets

               If CustomProperies.Load(sheet, "Template") <> "" Then

                  Dim upc As ucPlaybackControls = New ucPlaybackControls
                  upc.Sheet = sheet

                  Dim inte As Integer = 0
                  If Integer.TryParse(CustomProperies.Load(sheet, "ControlsSet"), inte) Then
                     upc.ControlsSet = inte
                  Else
                     upc.ControlsSet = ucPlaybackControls.enumControlSets.csLoadPlayStopUpdate
                  End If

                  AddHandler upc.CommandEvent, AddressOf CommandEvent

                  flpFlow.Controls.Add(upc)

               End If

               If _listSheet Is Nothing AndAlso CustomProperies.Load(sheet, "IsDashboardList") = "1" Then

                  _listSheet = sheet

                  cboTemplates.Visible = True
                  btnCreate.Visible = False

                  panTop.Enabled = True
                  panBottom.Enabled = True

                  lnkLabelRefreshLists.Visible = True
                  lnklblQueries.Visible = True

                  RefreshComboboxes()

                  'Load ControlsSet from the _listSheet
                  Dim inte As Integer = 0
                  If Integer.TryParse(CustomProperies.Load(_listSheet, "ControlsSet"), inte) Then
                     Me.ControlsSet = inte
                  Else
                     Me.ControlsSet = ucPlaybackControls.enumControlSets.csLoadPlayStopUpdate
                  End If

                  _currentRow = 0
                  panList.Enabled = False

               End If

            Next

         End If

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

         If _DockingMode = enumDockingMode.dmHorizontal Then
            flpFlow.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight
         ElseIf _DockingMode = enumDockingMode.dmVertical Then
            flpFlow.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
         End If

      End Set
   End Property

   Public ReadOnly Property pendingRefresh As Boolean
      Get
         Return _pendingRefresh
      End Get
   End Property

   Public Property ControlsSet As ucPlaybackControls.enumControlSets
      Get
         Return _ControlsSet
      End Get
      Set(value As ucPlaybackControls.enumControlSets)

         _ControlsSet = value

         btnLoad.Visible = False
         btnPlay.Visible = False
         btnNext.Visible = False
         btnStop.Visible = False
         btnUpdate.Visible = False

         Select Case _ControlsSet
            Case ucPlaybackControls.enumControlSets.csPlayStop
               btnPlay.Left = 0
               btnPlay.Width = 90
               btnPlay.Visible = True

               btnStop.Left = 96
               btnStop.Width = 90
               btnStop.Visible = True

            Case ucPlaybackControls.enumControlSets.csLoadPlayStop
               btnLoad.Left = 0
               btnLoad.Width = 58
               btnLoad.Visible = True

               btnPlay.Left = 64
               btnPlay.Width = 58
               btnPlay.Visible = True

               btnStop.Left = 128
               btnStop.Width = 58
               btnStop.Visible = True

            Case ucPlaybackControls.enumControlSets.csPlayNextStop
               btnPlay.Left = 0
               btnPlay.Width = 58
               btnPlay.Visible = True

               btnNext.Left = 64
               btnNext.Width = 58
               btnNext.Visible = True

               btnStop.Left = 128
               btnStop.Width = 58
               btnStop.Visible = True

            Case ucPlaybackControls.enumControlSets.csPlayStopUpdate
               btnPlay.Left = 0
               btnPlay.Width = 58
               btnPlay.Visible = True

               btnStop.Left = 64
               btnStop.Width = 58
               btnStop.Visible = True

               btnUpdate.Left = 128
               btnUpdate.Width = 58
               btnUpdate.Visible = True

            Case ucPlaybackControls.enumControlSets.csLoadPlayNextStop
               btnLoad.Left = 0
               btnLoad.Width = 46
               btnLoad.Visible = True

               btnPlay.Left = 48
               btnPlay.Width = 46
               btnPlay.Visible = True

               btnNext.Left = 96
               btnNext.Width = 46
               btnNext.Visible = True

               btnStop.Left = 144
               btnStop.Width = 46
               btnStop.Visible = True

            Case ucPlaybackControls.enumControlSets.csPlayNextStopUpdate
               btnPlay.Left = 0
               btnPlay.Width = 46
               btnPlay.Visible = True

               btnNext.Left = 48
               btnNext.Width = 46
               btnNext.Visible = True

               btnStop.Left = 96
               btnStop.Width = 46
               btnStop.Visible = True

               btnUpdate.Left = 144
               btnUpdate.Width = 46
               btnUpdate.Visible = True

            Case ucPlaybackControls.enumControlSets.csLoadPlayStopUpdate
               btnLoad.Left = 0
               btnLoad.Width = 46
               btnLoad.Visible = True

               btnPlay.Left = 48
               btnPlay.Width = 46
               btnPlay.Visible = True

               btnStop.Left = 96
               btnStop.Width = 46
               btnStop.Visible = True

               btnUpdate.Left = 144
               btnUpdate.Width = 46
               btnUpdate.Visible = True

         End Select

      End Set
   End Property

   Private Sub CommandEvent(sender As Object, e As ucPlaybackControls.CommandkEventArgs)

      If _CasparRibon IsNot Nothing AndAlso e.Sheet IsNot Nothing Then

         Select Case e.Command

            Case ucPlaybackControls.enumCommandType.ctLoad
               If Not _CasparRibon.RefreshQueries(e.Sheet, False) Then
                  _CasparRibon.LoadTemplate(e.Sheet, False)
               End If

            Case ucPlaybackControls.enumCommandType.ctPlay
               _CasparRibon.PlayTemplate(e.Sheet)

            Case ucPlaybackControls.enumCommandType.ctLoadAndPlay
               If Not _CasparRibon.RefreshQueries(e.Sheet, False) Then
                  _CasparRibon.LoadTemplate(e.Sheet, True)
               End If

            Case ucPlaybackControls.enumCommandType.ctPlayDirect
               _CasparRibon.LoadTemplate(e.Sheet, True)

            Case ucPlaybackControls.enumCommandType.ctNext
               _CasparRibon.PlayNext(e.Sheet)

            Case ucPlaybackControls.enumCommandType.ctStop
               _CasparRibon.StoppTemplate(e.Sheet)

            Case ucPlaybackControls.enumCommandType.ctUpdate
               _CasparRibon.UpdateTemplate(e.Sheet)

         End Select

      End If

   End Sub

   Private Sub RefreshComboboxes()

      If _listSheet IsNot Nothing AndAlso _IsCasparConnected Then

         Dim srv As Integer = 0
         If Not Integer.TryParse(CustomProperies.Load(_listSheet, "ServerNumber"), srv) Then
            srv = 1
         End If

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

   Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click

      If _listSheet IsNot Nothing Then

         Dim inte As Integer = 0
         If Integer.TryParse(CustomProperies.Load(_listSheet, "ServerNumber"), inte) Then
            _ServerNumber = inte
         Else
            _ServerNumber = 1
         End If

         If Integer.TryParse(CustomProperies.Load(_listSheet, "Channel"), inte) Then
            _Channel = inte
         End If

         If Integer.TryParse(CustomProperies.Load(_listSheet, "Layer"), inte) Then
            _Layer = inte
         End If

         Dim flds As String = CustomProperies.Load(_listSheet, "DataFields")
         If flds = "" Then
            flds = "f0|f1|f2|f3|f4|f5"
         End If
         _DataFields = flds

         If Integer.TryParse(CustomProperies.Load(_listSheet, "ControlsSet"), inte) Then
            Me.ControlsSet = inte
         End If

      End If

      Dim fds As frmDashboardSettings = New frmDashboardSettings

      Dim lst As List(Of String) = New List(Of String)

      For Each casp As CasparCG In _Settings.Servers
         lst.Add(casp.Name)
      Next

      fds.CasparServerNames = lst

      fds.ServerNumber = _ServerNumber
      fds.Channel = _Channel
      fds.Layer = _Layer
      fds.DataFields = _DataFields
      fds.ControlsSet = Me.ControlsSet

      If fds.ShowDialog = DialogResult.OK Then

         _ServerNumber = fds.ServerNumber
         _Channel = fds.Channel
         _Layer = fds.Layer

         _DataFields = fds.DataFields
         _Settings.DefaultDataFields = _DataFields

         Me.ControlsSet = fds.ControlsSet

         If _listSheet IsNot Nothing Then

            CustomProperies.Save(_listSheet, "ServerNumber", _ServerNumber.ToString)
            CustomProperies.Save(_listSheet, "Channel", _Channel.ToString)
            CustomProperies.Save(_listSheet, "Layer", _Layer.ToString)
            CustomProperies.Save(_listSheet, "DataFields", _DataFields)
            CustomProperies.Save(_listSheet, "ControlsSet", CInt(Me.ControlsSet).ToString)

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

      CustomProperies.Save(_listSheet, "IsDashboardList", "1")

      CustomProperies.Save(_listSheet, "ServerNumber", _ServerNumber.ToString)
      CustomProperies.Save(_listSheet, "Channel", _Channel.ToString)
      CustomProperies.Save(_listSheet, "Layer", _Layer.ToString)
      CustomProperies.Save(_listSheet, "DataFields", _DataFields)
      CustomProperies.Save(_listSheet, "ControlsSet", CInt(Me.ControlsSet).ToString)

      _ActiveWorkbook.Saved = False

      cboTemplates.Visible = True
      lnkLabelRefreshLists.Visible = True
      lnklblQueries.Visible = True
      panTop.Enabled = True
      panBottom.Enabled = True

      RefreshComboboxes()

   End Sub

   Private Sub lnkLabelRefreshLists_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLabelRefreshLists.LinkClicked
      RefreshComboboxes()
   End Sub

   Private Sub lnklblQueries_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblQueries.LinkClicked

      Dim fsq As frmSelectQuery = New frmSelectQuery
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

   Public Sub AutoUpdate()
      LoadTemplateOrClip(_pendingAutoplay)
   End Sub

   Private Sub LoadTemplateOrClip(Autoplay As Boolean)

      If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

         Dim range As Excel.Range = _listSheet.Cells
         Dim cell As Excel.Range = Nothing

         If CustomProperies.Load(_listSheet, "AutoUpdate") = "1" Then

            If Not _pendingRefresh And Not _isLoaded Then

               cell = range(_currentRow, 1)
               If cell.Value IsNot Nothing AndAlso cell.Text.ToString.StartsWith("{") Then

                  Dim que As String = cell.Text.ToString.Substring(1, cell.Text.ToString.Length - 2)
                  _pendingRefresh = True
                  _pendingAutoplay = Autoplay

                  For Each con In _ActiveWorkbook.Connections
                     If con.Name = que Then
                        con.Refresh
                     End If
                  Next

               End If

            Else
               _pendingRefresh = False
            End If

         End If

         If Not _pendingRefresh Then

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

                  If _ServerNumber = 0 Then
                     For Each caspar As CasparCG In _Settings.Servers
                        If caspar.Connected Then
                           If Autoplay Then
                              caspar.Play(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear")
                           Else
                              caspar.LoadBG(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear", seemlessplay)
                           End If
                        End If
                     Next
                  Else
                     If _ServerNumber <= _Settings.Servers.Count Then
                        Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                        If caspar.Connected Then
                           If Autoplay Then
                              caspar.Play(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear")
                           Else
                              caspar.LoadBG(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear", seemlessplay)
                           End If
                        End If
                     End If
                  End If

            End If

            _isLoaded = (Not Autoplay)

         End If

      End If

   End Sub

   Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
      LoadTemplateOrClip(False)
   End Sub

   Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click

      If Not _isLoaded Then

         LoadTemplateOrClip(True)

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

               'If Not _isLoaded Then

               '   Dim col As Integer = 6
               '   Dim fieldName As String = ""
               '   Dim fieldValue As String = ""
               '   Dim tmpl As Template = New Template
               '   Do
               '      cell = range(1, col)
               '      fieldName = cell.Text
               '      If fieldName = "" Then Exit Do

               '      cell = range(_currentRow, col)
               '      fieldValue = cell.Text

               '      tmpl.AddField(fieldName, fieldValue)
               '      col += 1
               '   Loop

               '   If _ServerNumber = 0 Then
               '      For Each caspar As CasparCG In _Settings.Servers
               '         If caspar.Connected Then
               '            caspar.CG_Add(channel, layer, tmplClipName, tmpl, True)
               '         End If
               '      Next
               '   Else
               '      If _ServerNumber <= _Settings.Servers.Count Then
               '         Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
               '         If caspar.Connected Then
               '            caspar.CG_Add(channel, layer, tmplClipName, tmpl, True)
               '         End If
               '      End If
               '   End If

               'Else  'is alredy loaded

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

               'End If


            ElseIf kind = "A" Or kind = "I" Or kind = "V" Then

               'If Not _isLoaded Then

               '   Dim col As Integer = 6
               '   Do
               '      cell = range(1, col)
               '      If cell.Text = "" Then Exit Do
               '      col += 1
               '   Loop
               '   col += 1

               '   'Loop
               '   Dim doLoop As Boolean = False
               '   cell = range(1, col)
               '   If cell.Text = "Loop" Then
               '      cell = range(_currentRow, col)
               '      If cell.Text = "1" Then
               '         doLoop = True
               '      End If
               '   End If
               '   col += 1

               '   'Effect
               '   Dim effect As String = ""
               '   cell = range(1, col)
               '   If cell.Text = "Effect" Then
               '      cell = range(_currentRow, col)
               '      effect = cell.Text
               '   End If
               '   col += 1

               '   'Duration
               '   Dim duration As Integer = 12
               '   cell = range(1, col)
               '   If cell.Text = "Duration" Then
               '      cell = range(_currentRow, col)
               '      If IsNumeric(cell.Text.ToString) Then
               '         If Not Integer.TryParse(cell.Text, duration) Then
               '            duration = 12
               '         End If
               '      End If
               '   End If
               '   col += 1

               '   'Direction
               '   Dim direction As String = ""
               '   cell = range(1, col)
               '   If cell.Text = "Direction" Then
               '      cell = range(_currentRow, col)
               '      direction = cell.Text
               '   End If

               '   If _ServerNumber = 0 Then
               '      For Each caspar As CasparCG In _Settings.Servers
               '         If caspar.Connected Then
               '            caspar.Play(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear")
               '         End If
               '      Next
               '   Else
               '      If _ServerNumber <= _Settings.Servers.Count Then
               '         Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
               '         If caspar.Connected Then
               '            caspar.Play(channel, layer, tmplClipName, doLoop, effect, duration, direction, "Linear")
               '         End If
               '      End If
               '   End If

               'Else  'is alredy loaded

               If _ServerNumber = 0 Then
                     For Each caspar As CasparCG In _Settings.Servers
                        If caspar.Connected Then
                           caspar.Play(channel, layer)
                        End If
                     Next
                  Else
                     If _ServerNumber <= _Settings.Servers.Count Then
                        Dim caspar As CasparCG = _Settings.Servers(_ServerNumber - 1)
                        If caspar.Connected Then
                           caspar.Play(channel, layer)
                        End If
                     End If
                  End If

               End If

            'End If

         End If

         _isLoaded = False

      End If

   End Sub

   Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click

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

   Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

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

      End If

   End Sub

   Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

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

   End Sub


   Private Sub ucDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load

      If _listSheet IsNot Nothing Then

         Dim inte As Integer = 0
         If Integer.TryParse(CustomProperies.Load(_listSheet, "ServerNumber"), inte) Then
            _ServerNumber = inte
         Else
            _ServerNumber = 1
         End If

         If Integer.TryParse(CustomProperies.Load(_listSheet, "Channel"), inte) Then
            _Channel = inte
         End If

         If Integer.TryParse(CustomProperies.Load(_listSheet, "Layer"), inte) Then
            _Layer = inte
         End If

         _DataFields = CustomProperies.Load(_listSheet, "DataFields")

         If Integer.TryParse(CustomProperies.Load(_listSheet, "ControlsSet"), inte) Then
            Me.ControlsSet = inte
         End If

      Else
         Me.ControlsSet = ucPlaybackControls.enumControlSets.csLoadPlayStopUpdate
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
      panBottom.Enabled = False

      panList.Enabled = True

   End Sub

   Private Sub ucDashboard_Resize(sender As Object, e As EventArgs) Handles Me.Resize

      If panList.Visible Then

         If _DockingMode = enumDockingMode.dmFloating Then

            panList.Size = New System.Drawing.Size(205, 190)
            panList.Location = New System.Drawing.Point(0, 0)

            panTop.Location = New System.Drawing.Point(9, 30)
            panMiddle.Location = New System.Drawing.Point(9, 82)
            panBottom.Location = New System.Drawing.Point(9, 134)

            flpFlow.Visible = False

         ElseIf _DockingMode = enumDockingMode.dmHorizontal Then

            panList.Size = New System.Drawing.Size(603, 89)
            panList.Location = New System.Drawing.Point(Me.Width - panList.Width, 0)

            panTop.Location = New System.Drawing.Point(9, 30)
            panMiddle.Location = New System.Drawing.Point(204, 30)
            panBottom.Location = New System.Drawing.Point(408, 30)

            flpFlow.Size = New System.Drawing.Size(Me.Width - panList.Width, Me.Height)
            flpFlow.Visible = True

         Else     'enumDockingMode.dmVertical

            panList.Size = New System.Drawing.Size(205, 190)
            panList.Location = New System.Drawing.Point(0, Me.Height - panList.Height)

            panTop.Location = New System.Drawing.Point(9, 30)
            panMiddle.Location = New System.Drawing.Point(9, 82)
            panBottom.Location = New System.Drawing.Point(9, 134)

            flpFlow.Size = New System.Drawing.Size(Me.Width, Me.Height - panList.Height)
            flpFlow.Visible = True

         End If

      Else

         flpFlow.Size = New System.Drawing.Size(Me.Width, Me.Height)

      End If

   End Sub

   Private Sub SetCells(templateOrClipName As String, Kind As String)

      If _listSheet IsNot Nothing AndAlso _currentRow > 1 Then

         Dim range As Excel.Range = _listSheet.Cells

         'Cue/Query
         Dim cell As Excel.Range = range(_currentRow, 1)
         If cell.Text = "" Then
            cell.Value = _currentRow - 1
         End If

         'Template/Clip
         cell = range(_currentRow, 2)
         cell.Value = templateOrClipName

         'Type/Kind
         cell = range(_currentRow, 3)
         cell.Value = Kind

         'Channel
         cell = range(_currentRow, 4)
         If cell.Text = "" Then
            cell.Value = _Channel
         End If

         'Layer
         cell = range(_currentRow, 5)
         If cell.Text = "" Then
            cell.Value = _Layer
         End If

      End If

   End Sub

   Private Sub cboTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTemplates.SelectedIndexChanged
      SetCells(cboTemplates.Items(cboTemplates.SelectedIndex), "T")
   End Sub

   Private Sub cboAudio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAudio.SelectedIndexChanged
      SetCells(cboAudio.Items(cboAudio.SelectedIndex), "A")
   End Sub

   Private Sub cboImages_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboImages.SelectedIndexChanged
      SetCells(cboImages.Items(cboImages.SelectedIndex), "I")
   End Sub

   Private Sub cboVideo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVideo.SelectedIndexChanged
      SetCells(cboVideo.Items(cboVideo.SelectedIndex), "V")
   End Sub

   Private Sub _listSheet_SelectionChange(Target As Range) Handles _listSheet.SelectionChange
      _currentRow = Target.Row
      panList.Enabled = (_currentRow > 1)
   End Sub

   Private Sub ucDashboard_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

   End Sub
End Class
