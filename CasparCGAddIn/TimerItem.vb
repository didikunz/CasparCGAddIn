Imports System.Xml.Serialization
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Globalization

<Serializable()>
Public Class TimerItem
   Implements ICloneable

   Public Enum enumQueryValues
      MainMinSec
      MainMinSecTenth
      MainHourMinSec
      MainLongHourMinSec
      MainDaysHourMinSec
      MainDaysHourMin
      MainTenth
      MainTenthOrEmpty
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
      LapMinSecTenth
      LapHourMinSec
      LapLongHourMinSec
      LapDaysHourMinSec
      LapDaysHourMin
      LapTenth
      LapTenthOrEmpty
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
      RawSpeedMetersPerSecond
      RawSpeedKilometersPerHour
      RawSpeedYardsPerSecond
      RawSpeedMilesPerHour
      FormatedDistancePercent
      FormatedDistanceKilometers
      FormatedDistanceMeters
      FormatedDistanceYards
      FormatedDistanceChains
      FormatedDistanceFurlongs
      FormatedDistanceMiles
      FormatedSpeedMetersPerSecond
      FormatedSpeedKilometersPerHour
      FormatedSpeedYardsPerSecond
      FormatedSpeedMilesPerHour
   End Enum

   Public Enum enumTimerFormat
      MinSec
      HourMinSec
      DaysHourMinSec
      DaysHourMin
   End Enum

   Private _Parent As TimerSettings = Nothing

   Private _Laps As List(Of TimerLap) = New List(Of TimerLap)

   Private _CurrentOffset As TimeSpan = TimeSpan.Zero
   Private _StartOffset As TimeSpan = TimeSpan.Zero

   Private _LapOffset As TimeSpan = TimeSpan.Zero
   Private _IsLapEngaged As Boolean = False

   Private _TimeTriggerHasFired As Boolean = False

   Private WithEvents _timTicker As Timer = New Timer

#Region "Properties"

   Public Property Name As String = "(New)"
   Public Property StartTime As Date
   Public Property StopTime As Date
   <XmlIgnore>
   Public Property Offset As TimeSpan = TimeSpan.Zero   'Used to start the clock not from zero
   Public Property IsRunning As Boolean = False
   Public Property IsPaused As Boolean = False

   Public Property CanPause As Boolean = False
   Public Property UseLaps As Boolean = True
   Public Property CountDown As Boolean = False
   Public Property InhibitQuery As Boolean = False
   Public Property PreviewFormat As enumTimerFormat = enumTimerFormat.MinSec

   Public Property OnStart As TimerTrigger = New TimerTrigger
   Public Property OnPause As TimerTrigger = New TimerTrigger
   Public Property OnUnPause As TimerTrigger = New TimerTrigger
   Public Property OnLap As TimerTrigger = New TimerTrigger
   Public Property OnResume As TimerTrigger = New TimerTrigger
   Public Property OnStop As TimerTrigger = New TimerTrigger

   <XmlIgnore>
   Public Property OnTimeTime As TimeSpan = TimeSpan.Zero
   Public Property OnTime As TimerTrigger = New TimerTrigger

   Public Property FullDistance As Double = 1
   Public Property PartDistance As Double = 0
   <XmlIgnore>
   Public Property PartTime As TimeSpan = TimeSpan.Zero
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

   <XmlElement("OnTimeTime")>
   <Browsable(False)>
   <EditorBrowsable(EditorBrowsableState.Never)>
   Public Property OnTimeTimeTicks As Long
      Get
         Return Me.OnTimeTime.Ticks
      End Get
      Set(value As Long)
         Me.OnTimeTime = New TimeSpan(value)
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
      Public Property HasStopped As Boolean

      Public Sub New(Time As TimeSpan, HasStopped As Boolean)
         Me.Time = Time
         Me.HasStopped = HasStopped
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

   ''' <summary>
   ''' Fired when OnTimeTime has expired.
   ''' </summary>
   Public Event TimeTrigger As EventHandler

   ''' <summary>
   ''' Fired when the Start button is pressed
   ''' </summary>
   Public Event PlayTrigger As EventHandler

   ''' <summary>
   ''' Fired when the Stop button is pressed or a countdown timer reaches zero
   ''' </summary>
   Public Event StopTrigger As EventHandler


#End Region

#Region "Methods"

   Private Sub RunTimerTrigger(trigger As TimerTrigger)
      RunTimerTrigger(trigger, TimeSpan.Zero)
   End Sub

   Private Sub RunTimerTrigger(trigger As TimerTrigger, offset As TimeSpan)

      If trigger IsNot Nothing AndAlso Not trigger.TriggerEvent = TimerTrigger.enumTriggerEvent.doNothing Then

         Dim ti As TimerItem = _Parent.GetTimerByName(trigger.TimerName)
         If ti IsNot Nothing Then
            Select Case trigger.TriggerEvent
               Case TimerTrigger.enumTriggerEvent.doStart
                  ti.StartTimer(offset)
               Case TimerTrigger.enumTriggerEvent.doPause
                  ti.PauseTimer()
               Case TimerTrigger.enumTriggerEvent.doUnPause
                  ti.UnPauseTimer()
               Case TimerTrigger.enumTriggerEvent.doLap
                  ti.LapTimer()
               Case TimerTrigger.enumTriggerEvent.doResume
                  ti.ResumeTimer()
               Case TimerTrigger.enumTriggerEvent.doStop
                  ti.StopTimer()
            End Select
         End If

      End If

   End Sub

   ''' <summary>
   ''' Initialize all variables, start the timer and save the data.
   ''' </summary>
   Public Sub StartTimer(startOffset As TimeSpan)

      Me.StartTime = Date.Now
      Me.IsPaused = False

      If CountDown Then
         _CurrentOffset = startOffset
      Else
         _CurrentOffset = TimeSpan.Zero
      End If
      _StartOffset = startOffset
      _TimeTriggerHasFired = False

      _timTicker.Interval = 100
      _timTicker.Start()

      Me.IsRunning = True

      For Each lap As TimerLap In _Laps
         lap.Time = TimeSpan.Zero
      Next

      RunTimerTrigger(Me.OnStart, startOffset)
      RaiseEvent PlayTrigger(Me, EventArgs.Empty)

      If CountDown Then
         Dim trea As TimerRefreshEventArgs = New TimerRefreshEventArgs(_CurrentOffset, True)
         RaiseEvent TimerRefresh(Me, trea)
      End If

      RaiseEvent SaveTimerData(Me, EventArgs.Empty)

   End Sub

   ''' <summary>
   ''' Runs the timer whitout setting any variables.
   ''' </summary>
   Public Sub RunTimer()
      If Not Me.IsPaused Then
         RaiseEvent PlayTrigger(Me, EventArgs.Empty)
         _timTicker.Interval = 100
         _timTicker.Start()
      End If
   End Sub

   ''' <summary>
   ''' Pause the Timer
   ''' </summary>
   Public Sub PauseTimer()

      If Not Me.IsPaused Then

         Me.StopTime = Date.Now
         Me.IsPaused = True

         _timTicker.Stop()

         Dim trea As TimerRefreshEventArgs = New TimerRefreshEventArgs(_CurrentOffset, True)
         RaiseEvent TimerRefresh(Me, trea)

         RunTimerTrigger(Me.OnPause)

      End If

      RaiseEvent SaveTimerData(Me, EventArgs.Empty)

   End Sub

   ''' <summary>
   ''' Resumes the timer from pause
   ''' </summary>
   Public Sub UnPauseTimer()

      If Me.IsPaused Then

         Dim diff As TimeSpan = Date.Now - Me.StopTime
         Me.StartTime = Me.StartTime + diff

         Me.IsPaused = False
         _CurrentOffset = TimeSpan.Zero

         _timTicker.Interval = 100
         _timTicker.Start()

         RunTimerTrigger(Me.OnUnPause)

         RaiseEvent SaveTimerData(Me, EventArgs.Empty)

      End If

   End Sub

   ''' <summary>
   ''' Stop the timer and save data.
   ''' </summary>
   Public Sub StopTimer()

      _timTicker.Stop()
      IsRunning = False

      Dim trea As TimerRefreshEventArgs = New TimerRefreshEventArgs(_CurrentOffset, True)
      RaiseEvent TimerRefresh(Me, trea)

      RunTimerTrigger(Me.OnStop)

      RaiseEvent StopTrigger(Me, EventArgs.Empty)
      RaiseEvent SaveTimerData(Me, EventArgs.Empty)

   End Sub

   Public Sub Plus()

      StartTime = StartTime.AddSeconds(-1)

      If OnStart IsNot Nothing AndAlso OnStart.TriggerEvent = TimerTrigger.enumTriggerEvent.doStart Then
         Dim ti As TimerItem = _Parent.GetTimerByName(OnStart.TimerName)
         If ti IsNot Nothing Then
            ti.Plus()
         End If
      End If

      _Parent.SaveBackupData()

   End Sub

   Public Sub Minus()

      StartTime = StartTime.AddSeconds(1)

      If OnStart IsNot Nothing AndAlso OnStart.TriggerEvent = TimerTrigger.enumTriggerEvent.doStart Then
         Dim ti As TimerItem = _Parent.GetTimerByName(OnStart.TimerName)
         If ti IsNot Nothing Then
            ti.Minus()
         End If
      End If

      _Parent.SaveBackupData()

   End Sub

   Public Sub LapTimer()

      _LapOffset = _CurrentOffset '+ _StartOffset
      _IsLapEngaged = True

      Dim trea As TimerRefreshEventArgs = New TimerRefreshEventArgs(_CurrentOffset, False)
      RaiseEvent TimerRefresh(Me, trea)

      If SelectedLap IsNot Nothing Then
         SelectedLap.SetTime(_LapOffset)
      End If

      RunTimerTrigger(Me.OnLap)

   End Sub

   Public Sub ResumeTimer()

      _IsLapEngaged = False

      Dim trea As TimerRefreshEventArgs = New TimerRefreshEventArgs(_CurrentOffset, False)
      RaiseEvent TimerRefresh(Me, trea)

      RunTimerTrigger(Me.OnResume)

   End Sub


   Public Function QueryValue(query As enumQueryValues, HasStopped As Boolean) As String

      Dim ret As String = ""

      Select Case query
         Case enumQueryValues.MainMinSec
            ret = String.Format("{0:mm\:ss}", _CurrentOffset)
         Case enumQueryValues.MainMinSecTenth
            If HasStopped Then
               ret = String.Format("{0:mm\:ss\.f}", _CurrentOffset)
            Else
               ret = String.Format("{0:mm\:ss}" + ".0", _CurrentOffset)
            End If
         Case enumQueryValues.MainHourMinSec
            ret = String.Format("{0:h\:mm\:ss}", _CurrentOffset)
         Case enumQueryValues.MainLongHourMinSec
            ret = String.Format("{0:hh\:mm\:ss}", _CurrentOffset)
         Case enumQueryValues.MainDaysHourMinSec
            ret = String.Format("{0:d\:hh\:mm\:ss}", _CurrentOffset)
         Case enumQueryValues.MainDaysHourMin
            ret = String.Format("{0:d\:hh\:mm}", _CurrentOffset)
         Case enumQueryValues.MainTenth
            If HasStopped Then
               ret = String.Format("{0:%f}", _CurrentOffset)
            Else
               ret = "0"
            End If
         Case enumQueryValues.MainTenthOrEmpty
            If HasStopped Then
               ret = String.Format("{0:%f}", _CurrentOffset)
            End If
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
            ret = String.Format("{0:%h}", _CurrentOffset)
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
         Case enumQueryValues.LapMinSecTenth
            If _IsLapEngaged Then
               ret = String.Format("{0:mm\:ss\.f}", _LapOffset)
            ElseIf HasStopped Then
               ret = String.Format("{0:mm\:ss\.f}", _CurrentOffset)
            Else
               ret = String.Format("{0:mm\:ss}" + ".0", _CurrentOffset)
            End If
         Case enumQueryValues.LapHourMinSec
            If _IsLapEngaged Then
               ret = String.Format("{0:h\:mm\:ss}", _LapOffset)
            Else
               ret = String.Format("{0:h\:mm\:ss}", _CurrentOffset)
            End If
         Case enumQueryValues.LapLongHourMinSec
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
         Case enumQueryValues.LapTenth
            If _IsLapEngaged Then
               ret = String.Format("{0:%f}", _LapOffset)
            ElseIf HasStopped Then
               ret = String.Format("{0:%f}", _CurrentOffset)
            Else
               ret = "0"
            End If
         Case enumQueryValues.LapTenthOrEmpty
            If _IsLapEngaged Then
               ret = String.Format("{0:%f}", _LapOffset)
            ElseIf HasStopped Then
               ret = String.Format("{0:%f}", _CurrentOffset)
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
               ret = String.Format("{0:%h}", _LapOffset)
            Else
               ret = String.Format("{0:%h}", _CurrentOffset)
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
            ret = String.Format(CultureInfo.InvariantCulture, "{0:##0.00}", CalculateDistanceSimulation(_CurrentOffset) * 100)

         Case enumQueryValues.RawDistanceKilometers
            ret = String.Format(CultureInfo.InvariantCulture, "{0:###0.000}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 1000)
         Case enumQueryValues.RawDistanceMeters
            ret = String.Format(CultureInfo.InvariantCulture, "{0:####,##0}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance)
         Case enumQueryValues.RawDistanceYards
            ret = String.Format(CultureInfo.InvariantCulture, "{0:####,##0}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance)
         Case enumQueryValues.RawDistanceChains
            ret = String.Format(CultureInfo.InvariantCulture, "{0:#####0.0}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 22)
         Case enumQueryValues.RawDistanceFurlongs
            ret = String.Format(CultureInfo.InvariantCulture, "{0:####0.00}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 220)
         Case enumQueryValues.RawDistanceMiles
            ret = String.Format(CultureInfo.InvariantCulture, "{0:####0.000}", CalculateDistanceSimulation(_CurrentOffset) * Me.FullDistance / 1760)

         Case enumQueryValues.RawSpeedMetersPerSecond
            ret = String.Format(CultureInfo.InvariantCulture, "{0:##0.00}", CalculateSpeedSimulation())
         Case enumQueryValues.RawSpeedKilometersPerHour
            ret = String.Format(CultureInfo.InvariantCulture, "{0:###0}", CalculateSpeedSimulation() * 3.6)
         Case enumQueryValues.RawSpeedYardsPerSecond
            ret = String.Format(CultureInfo.InvariantCulture, "{0:##0.00}", CalculateSpeedSimulation())
         Case enumQueryValues.RawSpeedMilesPerHour
            ret = String.Format(CultureInfo.InvariantCulture, "{0:###0}", CalculateSpeedSimulation() * 0.0020455)

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

         Case enumQueryValues.FormatedSpeedMetersPerSecond
            ret = String.Format("{0:##0.00}m/s", CalculateSpeedSimulation())
         Case enumQueryValues.FormatedSpeedKilometersPerHour
            ret = String.Format("{0:###0}km/h", CalculateSpeedSimulation() * 3.6)
         Case enumQueryValues.FormatedSpeedYardsPerSecond
            ret = String.Format("{0:##0.00}yd/s", CalculateSpeedSimulation())
         Case enumQueryValues.FormatedSpeedMilesPerHour
            ret = String.Format("{0:###0}mph", CalculateSpeedSimulation() * 0.0020455)

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

   Private Function CalculateSpeedSimulation() As Double
      If Me.PartTime.TotalSeconds > 0 AndAlso Me.PartDistance > 0 Then
         Return Me.PartDistance / Me.PartTime.TotalSeconds
      Else
         Return 0
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

         If CountDown Then
            _CurrentOffset = _StartOffset - (Date.Now - _StartTime)
         Else  'Count Up
            _CurrentOffset = (Date.Now - _StartTime) + _StartOffset
         End If

         If Int(_CurrentOffset.TotalSeconds) <> Int(tsOldOffset.TotalSeconds) Then

            Dim trea As TimerRefreshEventArgs = New TimerRefreshEventArgs(_CurrentOffset, False)
            RaiseEvent TimerRefresh(Me, trea)

            If OnTimeTime.Ticks > 0 AndAlso Not _TimeTriggerHasFired Then
               If CountDown Then
                  If _CurrentOffset.Ticks <= OnTimeTime.Ticks Then
                     RaiseEvent TimeTrigger(Me, EventArgs.Empty)
                     RunTimerTrigger(Me.OnTime)
                     _TimeTriggerHasFired = True
                  End If
               Else
                  If _CurrentOffset.Ticks >= OnTimeTime.Ticks Then
                     RaiseEvent TimeTrigger(Me, EventArgs.Empty)
                     RunTimerTrigger(Me.OnTime)
                     _TimeTriggerHasFired = True
                  End If
               End If
            End If

            tsOldOffset = _CurrentOffset

            If CountDown And Int(_CurrentOffset.TotalSeconds) = 0 Then
               StopTimer()
            End If

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
      clonedItem.CountDown = Me.CountDown
      clonedItem.InhibitQuery = Me.InhibitQuery
      clonedItem.PreviewFormat = Me.PreviewFormat

      clonedItem.OnStart = New TimerTrigger(Me.OnStart.TimerName, Me.OnStart.TriggerEvent)
      clonedItem.OnPause = New TimerTrigger(Me.OnPause.TimerName, Me.OnPause.TriggerEvent)
      clonedItem.OnUnPause = New TimerTrigger(Me.OnUnPause.TimerName, Me.OnUnPause.TriggerEvent)
      clonedItem.OnLap = New TimerTrigger(Me.OnLap.TimerName, Me.OnLap.TriggerEvent)
      clonedItem.OnResume = New TimerTrigger(Me.OnResume.TimerName, Me.OnResume.TriggerEvent)
      clonedItem.OnStop = New TimerTrigger(Me.OnStop.TimerName, Me.OnStop.TriggerEvent)

      clonedItem.OnTimeTime = Me.OnTimeTime
      clonedItem.OnTime = New TimerTrigger(Me.OnTime.TimerName, Me.OnTime.TriggerEvent)

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
