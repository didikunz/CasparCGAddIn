Imports System.IO
Imports System.Xml.Serialization
Imports System.Drawing
Imports System.Drawing.Drawing2D

<Serializable()>
Public Class Theme

   Private _WindowBackgroundImage As Image = Nothing

   Public Property ForeColor As Color = Color.Black
   Public Property BackColor As Color = Color.White

   Public Property WindowColor As Color = Color.FromArgb(230, 240, 255)

   Public Property HighliteForeColor As Color = Color.FromArgb(255, 255, 255)
   Public Property HighliteBackColor As Color = Color.FromArgb(204, 26, 27)

   Public Property SelectionForeColor As Color = Color.FromKnownColor(KnownColor.HighlightText)
   Public Property SelectionBackColor As Color = Color.FromKnownColor(KnownColor.Highlight)

   Public Property GridBackColor As Color = Color.FromKnownColor(KnownColor.AppWorkspace)
   Public Property GridColor As Color = Color.FromKnownColor(KnownColor.ControlDark)
   Public Property GridHeaderForeColor As Color = Color.FromKnownColor(KnownColor.WindowText)
   Public Property GridHeaderBackColor As Color = Color.FromKnownColor(KnownColor.Control)

   Public Property WindowBackgroundImageTopColor As Color = Color.FromArgb(153, 204, 255)
   Public Property WindowBackgroundImageBottomColor As Color = Color.FromArgb(254, 255, 255)

   Public Property ErrorBackColor As Color = Color.Red

   Public ReadOnly Property WindowBackgroundImage As Image
      Get
         If _WindowBackgroundImage Is Nothing Then
            _WindowBackgroundImage = New Bitmap(20, 100, Imaging.PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(_WindowBackgroundImage)
            Dim lgb As LinearGradientBrush = New LinearGradientBrush(New Point(10, 0), New Point(10, 100), WindowBackgroundImageTopColor, WindowBackgroundImageBottomColor)
            g.FillRectangle(lgb, New Rectangle(0, 0, 20, 100))
         End If
         Return _WindowBackgroundImage
      End Get
   End Property


   Public Sub Save(ByVal XMLFile As String)

      Dim wr As StreamWriter = Nothing

      Try
         Dim ser As XmlSerializer = New XmlSerializer(GetType(Theme))
         wr = New StreamWriter(XMLFile)
         ser.Serialize(wr, Me)
      Catch ex As Exception
         Throw (New Exception("WriteToXML: " + ex.Message, ex))
      Finally
         wr.Close()
      End Try

   End Sub

   Private Function ReadFromXML(ByVal XMLFile As String) As Theme

      Dim fs As FileStream = Nothing
      Dim th As Theme

      Try
         Dim ser As XmlSerializer = New XmlSerializer(GetType(Theme))
         fs = New FileStream(XMLFile, FileMode.Open)
         th = CType(ser.Deserialize(fs), Theme)
      Catch ex As Exception
         Throw (New Exception("ReadFromXML: " + ex.Message, ex))
      Finally
         fs.Close()
      End Try

      Return th

   End Function

   Public Sub New()

   End Sub

   Public Sub New(Filename As String)

      Dim th As Theme = ReadFromXML(Filename)

      Me.ForeColor = th.ForeColor
      Me.BackColor = th.BackColor

      Me.WindowColor = th.WindowColor

      Me.HighliteForeColor = th.HighliteForeColor
      Me.HighliteBackColor = th.HighliteBackColor

      Me.SelectionForeColor = th.SelectionForeColor
      Me.SelectionBackColor = th.SelectionBackColor

      Me.GridBackColor = th.GridBackColor
      Me.GridColor = th.GridColor
      Me.GridHeaderForeColor = th.GridHeaderForeColor
      Me.GridHeaderBackColor = th.GridHeaderBackColor

      Me.WindowBackgroundImageTopColor = th.WindowBackgroundImageTopColor
      Me.WindowBackgroundImageBottomColor = th.WindowBackgroundImageBottomColor

      Me.ErrorBackColor = th.ErrorBackColor

   End Sub

End Class
