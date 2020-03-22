Imports System.Xml.Serialization

<Serializable()>
Public Class TimerSheet

   Private _Fields As List(Of TimerField) = New List(Of TimerField)

   Public Property WorksheetName As String = ""

   Public ReadOnly Property Fields As List(Of TimerField)
      Get
         Return _Fields
      End Get
   End Property

   <XmlIgnore()>
   Public Property Server As Integer = 0
   <XmlIgnore()>
   Public Property Channel As Integer = 1
   <XmlIgnore()>
   Public Property Layer As Integer = 20
   <XmlIgnore()>
   Public Property FlashLayer As Integer = 1

   Public Sub New()
   End Sub

   Public Sub New(worksheetName As String)
      Me.WorksheetName = worksheetName.Trim
   End Sub

End Class
