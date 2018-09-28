Imports System.IO
Imports CasparObjects
Imports System.Xml.Serialization

Public Class Settings

   Private _ServerList As List(Of String) = New List(Of String)
   Private _Servers As List(Of CasparCG) = New List(Of CasparCG)

   Public ReadOnly Property ServerList As List(Of String)
      Get
         Return _ServerList
      End Get
   End Property

   <XmlIgnore()>
   Public ReadOnly Property Servers As List(Of CasparCG)
      Get
         Return _Servers
      End Get
   End Property

   Public Property PreviewServer As String = ""
   Public Property PreviewChannel As Integer = 1
   Public Property ConnectOnStartUp As Boolean = False
   Public Property DashboardVisible As Boolean = False
   Public Property DefaultDataFields As String = "f0|f1|f2|f3|f4|f5"

   <XmlIgnore()>
   Public ReadOnly Property Preview As CasparCG
      Get
         For Each caspar As CasparCG In _Servers
            If caspar.Name = PreviewServer Then
               Return caspar
               Exit For
            End If
         Next
         Return Nothing
      End Get
   End Property

   Public Sub Save(ByVal XMLFile As String)

      _ServerList.Clear()
      For Each casp As CasparCG In _Servers
         _ServerList.Add(casp.SerializeToString())
      Next

      Dim wr As StreamWriter = Nothing

      Try
         Dim ser As XmlSerializer = New XmlSerializer(GetType(Settings))
         wr = New StreamWriter(XMLFile)
         ser.Serialize(wr, Me)
      Catch ex As Exception
         Throw (New Exception("WriteToXML: " + ex.Message, ex))
      Finally
         wr.Close()
      End Try

   End Sub

   Private Function ReadFromXML(ByVal XMLFile As String) As Object

      Dim fs As FileStream = Nothing
      Dim obj As Object

      Try
         Dim ser As XmlSerializer = New XmlSerializer(GetType(Settings))
         fs = New FileStream(XMLFile, FileMode.Open)
         obj = ser.Deserialize(fs)
      Catch ex As Exception
         Throw (New Exception("ReadFromXML: " + ex.Message, ex))
      Finally
         fs.Close()
      End Try

      Return obj

   End Function

   Public Sub New()
   End Sub

   Sub New(ByVal XMLFile As String)

      Dim sets As Settings = ReadFromXML(XMLFile)

      _ServerList = sets.ServerList

      For Each casp As String In _ServerList
         If casp <> "" Then
            _Servers.Add(New CasparCG(casp))
         End If
      Next

      Me.PreviewServer = sets.PreviewServer
      Me.PreviewChannel = sets.PreviewChannel
      Me.ConnectOnStartUp = sets.ConnectOnStartUp
      Me.DashboardVisible = sets.DashboardVisible
      Me.DefaultDataFields = sets.DefaultDataFields

   End Sub

End Class
