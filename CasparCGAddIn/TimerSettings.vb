Imports System.IO
Imports System.Xml.Serialization
Imports System.Windows.Forms
Imports System.ComponentModel

<Serializable()>
Public Class TimerSettings

   Private _Items As List(Of TimerItem) = New List(Of TimerItem)
   Private _Sheets As List(Of TimerSheet) = New List(Of TimerSheet)

   Private WithEvents _timSaver As Timer = New Timer

#Region "Properties"

   Public Property TempID As String

   <XmlIgnore>
   Public Property SelectedItem As TimerItem

   Public ReadOnly Property Items As List(Of TimerItem)
      Get
         Return _Items
      End Get
   End Property

   Public ReadOnly Property Sheets As List(Of TimerSheet)
      Get
         Return _Sheets
      End Get
   End Property

   <XmlElement("SelectedItem")>
   <Browsable(False)>
   <EditorBrowsable(EditorBrowsableState.Never)>
   Public Property SelectedItemName As String
      Get
         If Me.SelectedItem IsNot Nothing Then
            Return Me.SelectedItem.Name
         Else
            Return "(None)"
         End If
      End Get
      Set(value As String)
         For Each li As TimerItem In Me.Items
            If li.Name = value Then
               Me.SelectedItem = li
               Exit For
            End If
         Next
      End Set
   End Property

#End Region

#Region "Events"

   Public Class TimerRefreshEventArgs
      Inherits EventArgs

      Public Property Item As TimerItem
      Public Property Time As TimeSpan
      Public Property HasStopped As Boolean

      Public Sub New(Item As TimerItem, Time As TimeSpan, HasStopped As Boolean)
         Me.Item = Item
         Me.Time = Time
         Me.HasStopped = HasStopped
      End Sub

   End Class

   ''' <summary>
   ''' Fires every second. Used to update the graphics.
   ''' </summary>
   Public Event TimerRefresh As EventHandler(Of TimerRefreshEventArgs)

   Public Class TimeTriggerEventArgs
      Inherits EventArgs

      Public Enum enumMode
         TimeTrigger
         PlayTrigger
         StopTrigger
      End Enum

      Public Property Mode As enumMode
      Public Property Item As TimerItem

      Public Sub New(Mode As enumMode, Item As TimerItem)
         Me.Mode = Mode
         Me.Item = Item
      End Sub

   End Class

   ''' <summary>
   ''' Fired when OnTimeTime of a timer has expired.
   ''' </summary>
   Public Event TimeTrigger As EventHandler(Of TimeTriggerEventArgs)

   ''' <summary>
   ''' Used to save data
   ''' </summary>
   Public Event SaveTimerData As EventHandler


   Private Sub HandleTimerRefresh(sender As Object, e As TimerItem.TimerRefreshEventArgs)
      Dim trea As TimerRefreshEventArgs = New TimerRefreshEventArgs(CType(sender, TimerItem), e.Time, e.HasStopped)
      RaiseEvent TimerRefresh(Me, trea)
   End Sub

   Private Sub HandleTimeTrigger(sender As Object, e As EventArgs)
      Dim ttea As TimeTriggerEventArgs = New TimeTriggerEventArgs(TimeTriggerEventArgs.enumMode.TimeTrigger, CType(sender, TimerItem))
      RaiseEvent TimeTrigger(Me, ttea)
   End Sub

   Private Sub HandlePlayTrigger(sender As Object, e As EventArgs)
      Dim ttea As TimeTriggerEventArgs = New TimeTriggerEventArgs(TimeTriggerEventArgs.enumMode.PlayTrigger, CType(sender, TimerItem))
      RaiseEvent TimeTrigger(Me, ttea)
   End Sub

   Private Sub HandleStopTrigger(sender As Object, e As EventArgs)
      Dim ttea As TimeTriggerEventArgs = New TimeTriggerEventArgs(TimeTriggerEventArgs.enumMode.StopTrigger, CType(sender, TimerItem))
      RaiseEvent TimeTrigger(Me, ttea)
   End Sub

   Private Sub HandleSaveTimerData(sender As Object, e As EventArgs)
      SaveBackupData()
   End Sub
#End Region

#Region "Methods"

   Public Sub AddTimerItem(item As TimerItem)

      item.Parent = Me
      AddHandler item.TimerRefresh, AddressOf HandleTimerRefresh
      AddHandler item.TimeTrigger, AddressOf HandleTimeTrigger
      AddHandler item.PlayTrigger, AddressOf HandlePlayTrigger
      AddHandler item.StopTrigger, AddressOf HandleStopTrigger
      AddHandler item.SaveTimerData, AddressOf HandleSaveTimerData

      _Items.Add(item)

   End Sub

   Public Sub RemoveTimerItem(item As TimerItem)

      RemoveHandler item.TimerRefresh, AddressOf HandleTimerRefresh
      RemoveHandler item.TimeTrigger, AddressOf HandleTimeTrigger
      RemoveHandler item.PlayTrigger, AddressOf HandlePlayTrigger
      RemoveHandler item.StopTrigger, AddressOf HandleStopTrigger
      RemoveHandler item.SaveTimerData, AddressOf HandleSaveTimerData

      _Items.Remove(item)

   End Sub

   Public Function GetTimerByName(name As String) As TimerItem

      Dim ret As TimerItem = Nothing

      For Each ti As TimerItem In _Items
         If ti.Name = name Then
            ret = ti
            Exit For
         End If
      Next

      Return ret

   End Function

   Public Sub RunTimer()
      For Each ti As TimerItem In _Items
         If ti.IsRunning Then
            ti.RunTimer()
         End If
      Next
   End Sub

   Public Sub SaveBackupData()
      _timSaver.Interval = 3000
      _timSaver.Start()
   End Sub

   Public Function toXmlString() As String
      Try
         Using st As MemoryStream = New MemoryStream
            Dim ser As XmlSerializer = New XmlSerializer(GetType(TimerSettings))
            ser.Serialize(st, Me)
            st.Position = 0
            Dim reader As StreamReader = New StreamReader(st)
            Return reader.ReadToEnd()
         End Using
      Catch ex As Exception
         Return ""
      End Try
   End Function

   Public Sub Save(ByVal XMLFile As String)

      Dim wr As StreamWriter = Nothing

      Try
         Dim ser As XmlSerializer = New XmlSerializer(GetType(TimerSettings))
         wr = New StreamWriter(XMLFile)
         ser.Serialize(wr, Me)
      Catch ex As Exception
         'Ignore
      Finally
         wr.Close()
      End Try

   End Sub


#End Region


   Public Sub New()
   End Sub

   Public Sub New(XmlStringOrFilename As String)
      Try

         Dim sets As TimerSettings

         If XmlStringOrFilename.StartsWith("<") Then
            'xmlstring
            Using reader As StringReader = New StringReader(XmlStringOrFilename)
               Dim ser As XmlSerializer = New XmlSerializer(GetType(TimerSettings))
               sets = ser.Deserialize(reader)
            End Using
         Else
            'filename
            Using fs As FileStream = New FileStream(XmlStringOrFilename, FileMode.Open)
               Dim ser As XmlSerializer = New XmlSerializer(GetType(TimerSettings))
               sets = ser.Deserialize(fs)
            End Using
         End If


         Me.TempID = sets.TempID

         _Items = sets.Items
         _Sheets = sets.Sheets

         Me.SelectedItem = sets.SelectedItem

         For Each item As TimerItem In _Items
            item.Parent = Me
            AddHandler item.TimerRefresh, AddressOf HandleTimerRefresh
            AddHandler item.TimeTrigger, AddressOf HandleTimeTrigger
            AddHandler item.PlayTrigger, AddressOf HandlePlayTrigger
            AddHandler item.StopTrigger, AddressOf HandleStopTrigger
            AddHandler item.SaveTimerData, AddressOf HandleSaveTimerData
         Next

      Catch ex As Exception
         'Ignore
      End Try
   End Sub

   Public Sub ReleaseEvents()
      For Each item As TimerItem In _Items
         RemoveHandler item.TimerRefresh, AddressOf HandleTimerRefresh
         RemoveHandler item.TimeTrigger, AddressOf HandleTimeTrigger
         RemoveHandler item.PlayTrigger, AddressOf HandlePlayTrigger
         RemoveHandler item.StopTrigger, AddressOf HandleStopTrigger
         RemoveHandler item.SaveTimerData, AddressOf HandleSaveTimerData
      Next
   End Sub

   Private Sub _timSaver_Tick(sender As Object, e As EventArgs) Handles _timSaver.Tick
      _timSaver.Stop()
      RaiseEvent SaveTimerData(Me, EventArgs.Empty)
   End Sub
End Class
