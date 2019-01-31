Public Class ExtractInfo

   Public Property Location As String = ""
   Public Property Id As String = ""
   Public Property TagName As String = ""

   Public Overrides Function ToString() As String
      Return String.Format("Id: {0} Name: {1} Location: {2}", Me.Id, Me.TagName, Me.Location)
   End Function

   Public Sub New()
   End Sub

   Public Sub New(ByVal Location As String, ByVal Id As String, ByVal TagName As String)
      Me.Location = Location
      Me.Id = Id
      Me.TagName = TagName
   End Sub

End Class
