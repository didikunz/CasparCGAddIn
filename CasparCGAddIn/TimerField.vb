Imports System.Xml.Serialization

<Serializable()>
Public Class TimerField

   Public Property FieldName As String = "(New)"
   Public Property ItemName As String = "Default"
   Public Property QueryValue As TimerItem.enumQueryValues

   Public Sub New()
   End Sub

   Public Sub New(fieldName As String, itemName As String, queryValue As TimerItem.enumQueryValues)
      Me.FieldName = fieldName
      Me.ItemName = itemName
      Me.QueryValue = queryValue
   End Sub

End Class
