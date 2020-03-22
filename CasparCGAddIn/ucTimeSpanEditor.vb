Public Class ucTimeSpanEditor

   Public Property Value As TimeSpan
      Get
         Return New TimeSpan(nudDay.Value, nudHour.Value, nudMinutes.Value, nudSeconds.Value)
      End Get
      Set(value As TimeSpan)
         nudDay.Value = value.Days
         nudHour.Value = value.Hours
         nudMinutes.Value = value.Minutes
         nudSeconds.Value = value.Seconds
      End Set
   End Property

End Class
