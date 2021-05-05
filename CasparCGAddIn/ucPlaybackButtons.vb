Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Public Class ucPlaybackButtons

   Public Enum enumCommandType
      ctLoad
      ctPlay
      ctLoadAndPlay
      ctNext
      ctStop
      ctUpdate
      ctPreview
      'ctQuery
   End Enum

   Public Enum enumControlSets
      csPlayStop
      csLoadPlayStop
      csPlayNextStop
      csPlayStopUpdate
      csLoadPlayNextStop
      csPlayNextStopUpdate
      csLoadPlayStopUpdate
      csNone
   End Enum

   Public Enum enumState
      stIdle
      stQueryRunning
      stQueryFinished
      stLoaded
      stPlaying
      stUpdating
      stOldState
   End Enum

   Public Class CommandEventArgs
      Inherits EventArgs

      Public Property Command As enumCommandType

      Public Property Sheet As Excel.Worksheet

      Public Sub New(command As enumCommandType, sheet As Excel.Worksheet)
         MyBase.New()
         Me.Command = command
         Me.Sheet = sheet
      End Sub

   End Class

   Public Delegate Sub CommandEventHandler(ByVal sender As Object, ByVal e As CommandEventArgs)

   Public Event CommandEvent As CommandEventHandler

   Private _State As enumState = enumState.stIdle
   Private _oldState As enumState = enumState.stIdle
   Private _sheet As Excel.Worksheet
   Private _ControlsSet As enumControlSets

   Private _OscIsProcessing As Boolean = False

   Private Sub SetOldState()
      State = _oldState
   End Sub

   Public Property State As enumState
      Get
         Return _State
      End Get
      Set(value As enumState)

         Select Case value
            Case enumState.stIdle
               _State = value
               _oldState = _State

               LoadEnabler(True)
               PlayEnabler(True)
               NextEnabler(False)
               StopEnabler(True)
               UpdateEnabler(False)

            Case enumState.stQueryRunning
               _State = value

               LoadEnabler(False)
               PlayEnabler(False)
               NextEnabler(False)
               StopEnabler(False)
               UpdateEnabler(False)

            Case enumState.stQueryFinished
               _State = value

               LoadEnabler(True)
               PlayEnabler(True)
               NextEnabler(False)
               StopEnabler(True)
               UpdateEnabler(True)

            Case enumState.stLoaded
               _State = value
               _oldState = _State

               LoadEnabler(True)
               PlayEnabler(True)
               NextEnabler(False)
               StopEnabler(True)
               UpdateEnabler(False)

            Case enumState.stPlaying
               _State = value
               _oldState = _State

               LoadEnabler(True)
               PlayEnabler(False)
               NextEnabler(True)
               StopEnabler(True)
               UpdateEnabler(True)

            Case enumState.stUpdating
               _State = value

               LoadEnabler(False)
               PlayEnabler(False)
               NextEnabler(False)
               StopEnabler(False)
               UpdateEnabler(False)

            Case enumState.stOldState
               SetOldState()

         End Select

         _OscIsProcessing = False

      End Set
   End Property


   Public WriteOnly Property Sheet As Excel.Worksheet
      Set(value As Excel.Worksheet)
         _sheet = value
      End Set
   End Property

   Public Property ControlsSet As enumControlSets
      Get
         Return _ControlsSet
      End Get
      Set(value As enumControlSets)
         _ControlsSet = value
         UpdateUIButtons()
      End Set
   End Property

   Private Sub UpdateUIButtons()

      tlpPlayStop.Visible = False
      tlpLoadPlayStop.Visible = False
      tlpPlayNextStop.Visible = False
      tlpPlayStopUpdate.Visible = False
      tlpLoadPlayNextStop.Visible = False
      tlpPlayNextStopUpdate.Visible = False
      tlpLoadPlayStopUpdate.Visible = False

      Select Case _ControlsSet
         Case enumControlSets.csPlayStop
            tlpPlayStop.Visible = True

         Case enumControlSets.csLoadPlayStop
            tlpLoadPlayStop.Visible = True

         Case enumControlSets.csPlayNextStop
            tlpPlayNextStop.Visible = True

         Case enumControlSets.csPlayStopUpdate
            tlpPlayStopUpdate.Visible = True

         Case enumControlSets.csLoadPlayNextStop
            tlpLoadPlayNextStop.Visible = True

         Case enumControlSets.csPlayNextStopUpdate
            tlpPlayNextStopUpdate.Visible = True

         Case enumControlSets.csLoadPlayStopUpdate
            tlpLoadPlayStopUpdate.Visible = True

      End Select

   End Sub

#Region "Helpers"

   Private Function ContrastingColor(col As System.Drawing.Color) As System.Drawing.Color

      Dim pl As Single = 1 - (0.299 * col.R + 0.587 * col.G + 0.144 * col.B) / 255
      If pl < 0.5 Then
         Return System.Drawing.Color.Black
      Else
         Return System.Drawing.Color.White
      End If

   End Function

   Private Sub LoadEnabler(Enabled As Boolean)
      If Not _OscIsProcessing Then
         btnLoad_LPS.Enabled = Enabled
         btnLoad_LPNS.Enabled = Enabled
         btnLoad_LPSU.Enabled = Enabled
      End If
   End Sub

   Private Sub PlayEnabler(Enabled As Boolean)
      If Not _OscIsProcessing Then
         btnPlay_LPNS.Enabled = Enabled
         btnPlay_LPS.Enabled = Enabled
         btnPlay_LPSU.Enabled = Enabled
         btnPlay_PNS.Enabled = Enabled
         btnPlay_PNSU.Enabled = Enabled
         btnPlay_PS.Enabled = Enabled
         btnPlay_PSU.Enabled = Enabled
      End If
   End Sub

   Private Sub NextEnabler(Enabled As Boolean)
      If Not _OscIsProcessing Then
         btnNext_LPNS.Enabled = Enabled
         btnNext_PNS.Enabled = Enabled
         btnNext_PNSU.Enabled = Enabled
      End If
   End Sub

   Private Sub StopEnabler(Enabled As Boolean)
      If Not _OscIsProcessing Then
         btnStop_LPNS.Enabled = Enabled
         btnStop_LPS.Enabled = Enabled
         btnStop_LPSU.Enabled = Enabled
         btnStop_PNS.Enabled = Enabled
         btnStop_PNSU.Enabled = Enabled
         btnStop_PS.Enabled = Enabled
         btnStop_PSU.Enabled = Enabled
      End If
   End Sub

   Private Sub UpdateEnabler(Enabled As Boolean)
      If Not _OscIsProcessing Then
         btnUpdate_LPSU.Enabled = Enabled
         btnUpdate_PNSU.Enabled = Enabled
         btnUpdate_PSU.Enabled = Enabled
      End If
   End Sub

#End Region

#Region "Methods"

   Public Sub DoLoad(oscProcessing As Boolean)

      _OscIsProcessing = oscProcessing

      LoadEnabler(False)
      PlayEnabler(False)

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandEventArgs(enumCommandType.ctLoad, _sheet))
      End If

      LoadEnabler(True)
      PlayEnabler(True)

   End Sub

   Public Sub DoPlay(oscProcessing As Boolean)

      _OscIsProcessing = oscProcessing

      PlayEnabler(False)

      If _sheet IsNot Nothing Then
         If State = enumState.stLoaded Then
            RaiseEvent CommandEvent(Me, New CommandEventArgs(enumCommandType.ctPlay, _sheet))
         Else
            RaiseEvent CommandEvent(Me, New CommandEventArgs(enumCommandType.ctLoadAndPlay, _sheet))
         End If
      End If

      PlayEnabler(True)

   End Sub

   Public Sub DoNext(oscProcessing As Boolean)

      _OscIsProcessing = oscProcessing

      NextEnabler(False)

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandEventArgs(enumCommandType.ctNext, _sheet))
      End If

      NextEnabler(True)

   End Sub

   Public Sub DoStop(oscProcessing As Boolean)

      _OscIsProcessing = oscProcessing

      StopEnabler(False)

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandEventArgs(enumCommandType.ctStop, _sheet))
      End If

      StopEnabler(True)

   End Sub

   Public Sub DoUpdate(oscProcessing As Boolean)

      _OscIsProcessing = oscProcessing

      UpdateEnabler(False)

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandEventArgs(enumCommandType.ctUpdate, _sheet))
      End If

      UpdateEnabler(True)

   End Sub

   Public Sub DoPreview()

      If _sheet IsNot Nothing Then
         RaiseEvent CommandEvent(Me, New CommandEventArgs(enumCommandType.ctPreview, _sheet))
      End If

   End Sub

#End Region

#Region "UI Code"

   Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad_LPS.Click, btnLoad_LPNS.Click, btnLoad_LPSU.Click
      DoLoad(False)
   End Sub

   Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay_LPNS.Click, btnPlay_LPS.Click, btnPlay_LPSU.Click, btnPlay_PNS.Click, btnPlay_PNSU.Click, btnPlay_PS.Click, btnPlay_PSU.Click
      DoPlay(False)
   End Sub

   Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext_LPNS.Click, btnNext_PNS.Click, btnNext_PNSU.Click
      DoNext(False)
   End Sub

   Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop_LPNS.Click, btnStop_LPS.Click, btnStop_LPSU.Click, btnStop_PNS.Click, btnStop_PNSU.Click, btnStop_PS.Click, btnStop_PSU.Click
      DoStop(False)
   End Sub

   Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate_LPSU.Click, btnUpdate_PNSU.Click, btnUpdate_PSU.Click
      DoUpdate(False)
   End Sub

#End Region

End Class
