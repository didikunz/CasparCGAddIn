Imports System.IO
Imports CasparObjects
Imports System.Xml.Serialization
Imports System.Windows.Forms

Public Class Settings

   Public Enum enumVideoResolution
      vrPAL
      vrNTSC
      vrHD720
      vrHD1080
      vr4K
   End Enum

   Private _ServerList As List(Of String) = New List(Of String)
   Private _Servers As List(Of CasparCG) = New List(Of CasparCG)

   Private _Theme As Theme

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

   Public ReadOnly Property Theme As Theme
      Get
         If _Theme Is Nothing Then
            If Me.UseDarkTheme Then
               _Theme = Loader.CreateDarkTheme()
            Else
               _Theme = Loader.CreateDefaultTheme()
               _Theme.WindowBackgroundImageTopColor = Drawing.SystemColors.Control
               _Theme.WindowBackgroundImageBottomColor = Drawing.SystemColors.Control
            End If
         End If
         Return _Theme
      End Get
   End Property


   Public Property PreviewServer As String = ""
   Public Property PreviewChannel As Integer = 1
   Public Property ConnectOnStartUp As Boolean = False
   Public Property DashboardVisible As Boolean = False
   Public Property DefaultDataFields As String = "f0|f1|f2|f3|f4|f5"
   Public Property DefaultLayerRules As String = ""
   Public Property UseAveco As Boolean = False
   Public Property ShowDashboard As Boolean = True
   Public Property UseImageAttributes As Boolean = False
   Public Property InhibitPlayback4Slave As Boolean = True
   Public Property UseFlashLayers As Boolean = False
   Public Property FormatTextsForHTML As Boolean = False
   Public Property UseDarkTheme As Boolean = False

   Public Property VideoResolution As enumVideoResolution = enumVideoResolution.vrHD1080

   Public Property BrowserLocation As System.Drawing.Point = New System.Drawing.Point(10, 10)
   Public Property BrowserSize As System.Drawing.Size = New System.Drawing.Size(1072, 645)
   Public Property BrowserWindowstate As System.Windows.Forms.FormWindowState = FormWindowState.Normal

   Public Property UseOSCInput As Boolean = False
   Public Property OSCInputPort As Integer = 8250


   <XmlIgnore()>
   Public ReadOnly Property Preview As CasparCG
      Get
         For Each caspar As CasparCG In _Servers
            If caspar.Name = PreviewServer Then
               Return caspar
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
      Me.DefaultLayerRules = sets.DefaultLayerRules
      Me.UseAveco = sets.UseAveco
      Me.ShowDashboard = sets.ShowDashboard
      Me.UseImageAttributes = sets.UseImageAttributes
      Me.InhibitPlayback4Slave = sets.InhibitPlayback4Slave
      Me.UseFlashLayers = sets.UseFlashLayers
      Me.FormatTextsForHTML = sets.FormatTextsForHTML
      Me.UseDarkTheme = sets.UseDarkTheme

      Me.VideoResolution = sets.VideoResolution

      Me.BrowserLocation = sets.BrowserLocation
      Me.BrowserSize = sets.BrowserSize
      Me.BrowserWindowstate = sets.BrowserWindowstate

      Me.UseOSCInput = sets.UseOSCInput
      Me.OSCInputPort = sets.OSCInputPort

   End Sub

End Class
