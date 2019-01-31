Public Class XInfos

   Private _XInfos As List(Of ExtractInfo)

   Public ReadOnly Property XInfos() As List(Of ExtractInfo)
      Get
         Return _XInfos
      End Get
   End Property

   Public Sub New()
      _XInfos = New List(Of ExtractInfo)
   End Sub

End Class
