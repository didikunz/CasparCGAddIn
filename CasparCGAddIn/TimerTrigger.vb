Imports System.Xml.Serialization

<Serializable()>
Public Class TimerTrigger

   Public Enum enumTriggerEvent
      doNothing
      doStart
      doPause
      doUnPause
      doLap
      doResume
      doStop
   End Enum

   Public Property TimerName As String = ""
   Public Property TriggerEvent As enumTriggerEvent = enumTriggerEvent.doNothing


   Public Sub New()
   End Sub

   Public Sub New(timerName As String, triggerEvent As enumTriggerEvent)
      Me.TimerName = timerName
      Me.TriggerEvent = triggerEvent
   End Sub

End Class
