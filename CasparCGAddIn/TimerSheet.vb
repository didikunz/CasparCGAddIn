Imports System.Xml.Serialization

<Serializable()>
Public Class TimerSheet

   Public Enum enumAutoPlayMode
      doNothing
      AutoPlay
      AutoStop
      AutoPlayStop
   End Enum

   Private _Fields As List(Of TimerField) = New List(Of TimerField)

   Public Property WorksheetName As String = ""

   Public ReadOnly Property Fields As List(Of TimerField)
      Get
         Return _Fields
      End Get
   End Property

   Public Property OnTimeTimer As String = ""
   Public Property OnTimeInvoke As String = ""
   Public Property AutoPlayMode As enumAutoPlayMode = enumAutoPlayMode.doNothing
   Public Property AutoPlayTimer As String = ""

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
