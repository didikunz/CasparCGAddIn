Imports System.Xml.Serialization
Imports System.Windows.Forms
Imports System.ComponentModel

<Serializable()>
Public Class TimerItem
   Implements ICloneable

   Public Enum enumQueryValues
      MainMinSec
      MainHourMinSec
      MainDaysHourMinSec
      MainDaysHourMin
      MainSeconds
      MainTotalSeconds
      MainSecondNumber
      MainMinutes
      MainTotalMinutes
      MainMinuteNumber
      MainHours
      MainTotalHours
      MainHourNumber
      MainDays
      MainDayNumber
      LapMinSec
      LapHourMinSec
      LapDaysHourMinSec
      LapDaysHourMin
      LapSeconds
      LapTotalSeconds
      LapMinutes
      LapTotalMinutes
      LapHours
      LapTotalHours
      LapDays
      RawDistancePercent
      RawDistanceKilometers
      RawDistanceMeters
      RawDistanceYards
      RawDistanceChains
      RawDistanceFurlongs
      RawDistanceMiles
      FormatedDistancePercent
      FormatedDistanceKilometers
      FormatedDistanceMeters
      FormatedDistanceYards
      FormatedDistanceChains
      FormatedDistanceFurlongs
      FormatedDistanceMiles
   End Enum

   Public Enum enumTimerFormat
      MinSec
      HourMinSec
      DaysHourMinSec
      DaysHourMin
   End Enum

   Private _Parent As TimerSettings = Nothing

   Private _Laps As List(Of TimerLap) = New List(Of TimerLap)

   Private _CurrentOffset As TimeSpan = New TimeSpan(0)

   Private _LapOffset As TimeSpan = New TimeSpan(0)
   Private _IsLapEngaged As Boolean = False

   Private WithEvents _timTicker As Timer = New Timer

#Region "Properties"

   Public Property Name As String = "(New)"
   Public Property StartTime As Date
   Public Property StopTime As Date
   <XmlIgnore>
   Public Property Offset As TimeSpan = New TimeSpan(0)   'Used to start the clock not from zero
   Public Property IsRunning As Boolean = False
   Public Property IsPaused As Boolean = False

   Public Property CanPause As Boolean = False
   Public Property UseLaps As Boolean = True
   Public Property PreviewFormat As enumTimerFormat = enumTimerFormat.MinSec

   Public Property FullDistance As Double = 1
   Public Property PartDistance As Double = 0
   <XmlIgnore>
   Public Property PartTime As TimeSpan = New TimeSpan(0)
   <XmlIgnore>
   Public Property SelectedLap As TimerLap

   Public ReadOnly Property Laps As List(Of TimerLap)
      Get
         Return _Laps
      End Get
   End Property

   <XmlElement("Offset")>
   <Browsable(False)>
   <EditorBrowsable(EditorBrowsableState.Never)>
   Public Property OffsetTicks As Long
      Get
         Return Me.Offset.Ticks
      End Get
      Set(value As Long)
         Me.Offset = New TimeSpan(value)
      End Set
   End Property

   <XmlElement("PartTime")>
   <Browsable(False)>
   <EditorBrowsable(EditorBrowsableState.Never)>
   Public Property PartTimeTicks As Long
      Get
         Return Me.PartTime.Ticks
      End Get
      Set(value As Long)
         Me.PartTime = New TimeSpan(value)
      End Set
   End Property

   <XmlElement("SelectedLap")>
   <Browsable(False)>
   <EditorBrowsable(EditorBrowsableState.Never)>
   Public Property SelectedLapName As String
      Get
         If Me.SelectedLap IsNot Nothing Then
            Return Me.SelectedLap.Name
         Else
            Return "(None)"
         End If
      End Get
      Set(value As String)
         For Each lp As TimerLap In Me.Laps
            If lp.Name = value Then
               Me.SelectedLap = lp
               Exit For
            End If
         Next
      End Set
   End Property

   <XmlIgnore>
   Public WriteOnly Property Parent As TimerSettings
      Set(value As TimerSettings)
         _Parent = value
      End Set
   End Property

#End Region

#Region "Events"

   Public Class TimerRefreshEventArgs
      Inherits EventArgs

      Public Property Time As TimeSpan

      Public Sub New(Time As TimeSpan)
         Me.Time = Time
      End Sub

   End Class

   ''' <summary>
   ''' Fires every second. Used to update the graphics.
   ''' </summary>
   Public Event TimerRefresh As EventHandler(Of TimerRefreshEventArgs)

   Public Delegate Sub TimerRefreshHandler(sender As Object, e As TimerRefreshEventArgs)

   ''' <summary>
   ''' Used to save data
   ''' </summary>
   Public Event SaveTimerData As EventHandler

#End Region

#Region "Methods"

   ''' <summary>
   ''' Initialize all variables, start the timer and save the data.
   ''' </summary>
   Public Sub StartTimer()

      Me.StartTime = Date.Now
      Me.IsPaused = False
      _CurrentOffset = New TimeSpan(0)

      _timTicker.Interval = 100
      _timTicker.Start()

      Me.IsRunning = True

      For Each lap As TimerLap In _Laps
         lap.Time = New TimeSpan(0)
      Next

      RaiseEvent SaveTimerData(Me, EventArgs.Empty)

   End Sub

   ''' <summary>
   ''' Runs the timer whitout setting any variables.
   ''' </summary>
   Public Sub RunTimer()
      If Not Me.IsPaused Then
         _timTicker.Interval = 100
         _timTicker.Start()
      End If
   End Sub

   ''' <summary>
   ''' Pause the Timer
   ''' </summary>
   Public Sub PauseTimer()

      If Not Me.IsPaused Then
         'running
         Me.StopTime = Date.Now
         Me.IsPaused = True

         _timTicker.Stop()

      Else
         'paused
         Dim diff As TimeSpan = Date.Now - Me.StopTime
         Me.StartTime = Me.StartTime + diff

         Me.IsPaused = False
         _CurrentOffset = New TimeSpan(0)

         _timTicker.Interval = 100
         _timTicker.Start()

      End If

      RaiseEvent SaveTimerData(Me, EventArgs.Empty)

   End Sub

   ''' <summary>
   ''' Stop the timer and save data.
   ''' </summary>
   Public Sub StopTimer()

      _timTicker.Stop()
      IsRunning = False

      RaiseEvent SaveTimerData(Me, EventArgs.Empty)

   End Sub

   Public Sub Plus()
      StartTime = StartTime.AddSeconds(-1)
      _Parent.SaveBackupData()
   End Sub

   Public Sub Minus()
      StartTime = StartTime.AddSeconds(1)
      _Parent.SaveBackupData()
   End Sub

   Public Sub LapTimer()
      _LapOffset = _CurrentOffset
      _IsLapEngaged = True
      If SelectedLap IsNot Nothing Then
         SelectedLap.SetTime(_LapOffset)
      End If
   End Sub

   Public Sub ResumeTimer()
      _IsLapEngaged = False
   End Sub


   Public Function QueryValue(query As enumQueryValues) As String

      Dim ret As String = ""

      Select Case query
         Case enumQueryValues.MainMinSec
            ret = String.Format("{0:mm\:ss}", _CurrentOffset)
         Case enumQueryValues.MainHourMinSec
            ret = String.Format("{0:hh\:mm\:ss}", _CurrentOffset)
         Case enumQueryValues.MainDaysHourMinSec
            ret = String.Format("{0:d\:hh\:mm\:ss}", _CurrentOffset)
         Case enumQueryValues.MainDaysHourMin
            ret = String.Format("{0:d\:hh\:mm}", _CurrentOffset)
         Case enumQueryValues.MainSeconds
            ret = String.Format("{0:ss}", _CurrentOffset)
         Case enumQueryValues.MainTotalSeconds
            ret = String.Format("{0:#####00}", _CurrentOffset.TotalSeconds)
         Case enumQueryValues.MainSecondNumber
            ret = String.Format("{0:######0}", _CurrentOffset.TotalSeconds + 1)
         Case enumQueryValues.MainMinutes
            ret = String.Format("{0:mm}", _CurrentOffset)
         Case enumQueryValues.MainTotalMinutes
            ret = String.Format("{0:#####00}", _CurrentOffset.TotalMinutes)
         Case enumQueryValues.MainMinuteNumber
            ret = String.Format("{0:######0}", _CurrentOffset.TotalMinutes + 1)
         Case enumQueryValues.MainHours
            ret = String.Format("{0:hh}", _CurrentOffset)
         Case enumQueryValues.MainTotalHours
            ret = String.Format("{0:######0}", _CurrentOffset.TotalHours)
         Case enumQueryValues.MainHourNumber
            ret = String.Format("{0:######0}", _CurrentOffset.TotalHours + 1)
         Case enumQueryValues.MainDays
            ret = String.Format("{0:%d}", _CurrentOffset)
         Case enumQueryValues.MainDayNumber
            ret = String.Format("{0:######0}", _CurrentOffset.TotalDays + 1)

         Case enumQueryValues.LapMinSec
            If _IsLapEngaged Then
               ret = String.Format("{0:mm\:ss}", _LapOffset)
            Else
               ret = String.Format("{0:mm\:ss}", _CurrentOffset)
            End If
         Case enumQueryValues.LapHourMinSec
            If _IsLapEngaged Then
               ret = String.Format("{0:hh\:mm\:ss}", _LapOffset)
            Else
               ret = String.Format("{0:hh\:mm\:ss}", _CurrentOffset)
            End If
         Case enumQueryValues.LapDaysHourMinSec
            If _IsLapEngaged Then
               ret = String.Format("{0:d\:hh\:mm\:ss}", _LapOffset)
            Else
               ret = String.Format("{0:d\:hh\:mm\:ss}", _CurrentOffset)
            End If
         Case enumQueryValues.LapDaysHourMin
            If _IsLapEngaged Then
               ret = String.Format("{0:d\:hh\:mm}", _LapOffset)
            Else
               ret = String.Format("{0:d\:hh\:mm}", _CurrentOffset)
            End If
         Case enumQueryValues.LapSeconds
            If _IsLapEngaged Then
               ret = String.Format("{0:ss}", _LapOffset)
            Else
               ret = String.Format("{0:ss}", _CurrentOffset)
            End If
         Case enumQueryValues.LapTotalSeconds
            If _IsLapEngaged Then
               ret = String.Format("{0:#####00}", _LapOffset.TotalSeconds)
            Else
               ret = String.Format("{0:#####00}", _CurrentOffset.TotalSeconds)
            End If
         Case enumQueryValues.LapMinutes
            If _IsLapEngaged Then
               ret = String.Format("{0:mm}", _LapOffset)
            Else
               ret = String.Format("{0:mm}", _CurrentOffset)
            End If
         Case enumQueryValues.LapTotalMinutes
            If _IsLapEngaged Then
               ret = String.Format("{0:#####00}", _LapOffset.TotalMinutes)
            Else
               ret = String.Format("{0:#####00}", _CurrentOffset.TotalMinutes)
            End If
         Case enumQueryValues.LapHours
            If _IsLapEngaged Then
               ret = String.Format("{0:hh}", _LapOffset)
            Else
               ret = String.Format("{0:hh}", _CurrentOffset)
            End If
         Case enumQueryValues.LapTotalHours
            If _IsLapEngaged Then
               ret = String.Format("{0:######0}", _LapOffset.TotalHours)
            Else
               ret = String.Format("{0:######0}", _CurrentOffset.TotalHours)
            End If
         Case enumQueryValues.LapDays
            If _IsLapEngaged Then
               ret = String.Format("{0:%d}", _LapOffset)
            Else
               ret = String.Format("{0:%d}", _CurrentOffset)
            End If

         Case enumQueryValues.RawDistancePercent
            ret = String.Format("{0:##0.00}", CalculateDistanceSimulation(_CurrentOffset) * 100)

         Case enumQueryValues.RawDistanceKilometers
            ret = String.Format("{0:###0.000}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 1000)
         Case enumQueryValues.RawDistanceMeters
            ret = String.Format("{0:####,##0}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance)
         Case enumQueryValues.RawDistanceYards
            ret = String.Format("{0:####,##0}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance)
         Case enumQueryValues.RawDistanceChains
            ret = String.Format("{0:#####0.0}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 22)
         Case enumQueryValues.RawDistanceFurlongs
            ret = String.Format("{0:####0.00}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 220)
         Case enumQueryValues.RawDistanceMiles
            ret = String.Format("{0:####0.000}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 1760)

         Case enumQueryValues.FormatedDistancePercent
            ret = String.Format("{0:##0.00}%", CalculateDistanceSimulation(_CurrentOffset) * 100)
         Case enumQueryValues.FormatedDistanceKilometers
            ret = String.Format("{0:#,##0.000}km", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 1000)
         Case enumQueryValues.FormatedDistanceMeters
            ret = String.Format("{0:#,###,##0}m", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance)
         Case enumQueryValues.FormatedDistanceYards
            ret = String.Format("{0:#,###,##0}yd", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance)
         Case enumQueryValues.FormatedDistanceChains
            ret = String.Format("{0:###,##0.0}ch", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 22)
         Case enumQueryValues.FormatedDistanceFurlongs
            ret = String.Format("{0:##,##0.00}fur", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 220)
         Case enumQueryValues.FormatedDistanceMiles
            ret = String.Format("{0:##,##0.000}mi", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 1760)
      End Select

      Return ret

   End Function

   Private Function CalculateDistanceSimulation(time As TimeSpan) As Double
      If Me.PartTime.TotalSeconds > 0 AndAlso Me.PartDistance > 0 AndAlso Me.FullDistance > 1 Then
         Return (time.TotalSeconds / Me.PartTime.TotalSeconds) * (Me.PartDistance / Me.FullDistance)
      Else
         Return 0.00001
      End If
   End Function

   Public Function GetFormatedTime(duration As TimeSpan) As String

      Dim ret As String = ""

      Select Case Me.PreviewFormat
         Case enumTimerFormat.MinSec
            ret = String.Format("{0:mm\:ss}", duration)
         Case enumTimerFormat.HourMinSec
            ret = String.Format("{0:hh\:mm\:ss}", duration)
         Case enumTimerFormat.DaysHourMinSec
            ret = String.Format("{0:d\:hh\:mm\:ss}", duration)
         Case enumTimerFormat.DaysHourMin
            ret = String.Format("{0:d\:hh\:mm}", duration)
      End Select

      Return ret

   End Function

   Private Sub _timTicker_Tick(sender As Object, e As EventArgs) Handles _timTicker.Tick

      Static tsOldOffset As TimeSpan

      If Not IsPaused Then

         _CurrentOffset = (Date.Now - _StartTime) + _Offset

         If Int(_CurrentOffset.TotalSeconds) <> Int(tsOldOffset.TotalSeconds) Then

            Dim trea As TimerRefreshEventArgs = New TimerRefreshEventArgs(_CurrentOffset)
            RaiseEvent TimerRefresh(Me, trea)

            tsOldOffset = _CurrentOffset

         End If

      Else  '_ClockIsPaused = True

         'If dtTempNow.Ticks = 0 Then dtTempNow = Date.Now

         'If dtTempNow.Second <> Date.Now.Second Then
         '   dtTempNow = Date.Now

         '   _StartTime = DateAdd(DateInterval.Second, 1, _StartTime)
         '   '_EndTime = DateAdd(DateInterval.Second, 1, _EndTime)

         '   _currentMatch.ClockStartTime = _StartTime
         '   '_currentMatch.ClockEndTime = _EndTime

         'End If

      End If

   End Sub

#End Region

#Region "Constructors"

   Public Sub New()
   End Sub

   Public Sub New(name As String)
      Me.Name = name
   End Sub

   Public Function Clone() As Object Implements ICloneable.Clone

      Dim clonedItem As TimerItem = New TimerItem(String.Format("{0}-Clone", Me.Name))

      clonedItem.StartTime = Me.StartTime
      clonedItem.Offset = Me.Offset
      clonedItem.IsRunning = Me.IsRunning
      clonedItem.IsPaused = Me.IsPaused

      clonedItem.CanPause = Me.CanPause
      clonedItem.UseLaps = Me.UseLaps
      clonedItem.PreviewFormat = Me.PreviewFormat

      clonedItem.FullDistance = Me.FullDistance
      clonedItem.PartDistance = Me.PartDistance
      clonedItem.PartTime = Me.PartTime

      Dim selectedLapName As String = ""
      If Me.SelectedLap IsNot Nothing Then
         selectedLapName = Me.SelectedLap.Name
      End If

      For Each originalLap As TimerLap In Me.Laps
         clonedItem.Laps.Add(originalLap.Clone)
      Next

      For Each lap As TimerLap In clonedItem.Laps
         If lap.Name = selectedLapName Then
            clonedItem.SelectedLap = lap
            Exit For
         End If
      Next

      clonedItem.Parent = _Parent

      Return clonedItem

   End Function

#End Region

End Class
