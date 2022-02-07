Imports System.Globalization

Public Class SheetProperties

   Public Enum enumOutputMode
      Delimited
      Table
      HTML
   End Enum

   Public Enum enumDelimiter
      Tab
      Colon
      Semicolon
      Custom
   End Enum

   Private _Delimiter As String = ""
   Private _DelimiterMode As enumDelimiter = enumDelimiter.Tab
   Private _Queries As HashSet(Of String) = New HashSet(Of String)

#Region "Common"

   Public Property DataSetName As String = ""
   Public Property OutputMode As enumOutputMode = enumOutputMode.Delimited

   'Delimiter Settings
   Public ReadOnly Property DelimiterMode As enumDelimiter
      Get
         Return _DelimiterMode
      End Get
   End Property

   Public Property Delimiter As String
      Get
         Select Case _DelimiterMode
            Case enumDelimiter.Tab
               Return "TAB"
            Case enumDelimiter.Colon
               Return "COLON"
            Case enumDelimiter.Semicolon
               Return "SEMICOLON"
            Case Else
               Return _Delimiter
         End Select
      End Get
      Set(value As String)

         _Delimiter = ""
         Select Case value.Trim.ToUpper
            Case ""
               _DelimiterMode = enumDelimiter.Tab
            Case "TAB"
               _DelimiterMode = enumDelimiter.Tab
            Case "COLON"
               _DelimiterMode = enumDelimiter.Colon
            Case "SEMICOLON"
               _DelimiterMode = enumDelimiter.Semicolon
            Case Else
               _DelimiterMode = enumDelimiter.Custom
               _Delimiter = value.Trim
         End Select
      End Set
   End Property

   'Table-Settings
   Public Property TableTextAsWhite As Boolean = False
   Public Property TableAddBorders As Boolean = False

   'HTML-Settings
   Public Property HTMLFirstIsHeader As Boolean = False
   Public Property HTMLFieldname As String = ""

   'SheetToAppend
   Public Property SheetToAppend As String = ""

#End Region

#Region "Auto-Update & Live"

   Public Property AutoUpdateDataset As Boolean = True     'True=Dataset, False=Live

   Public Property ServerNumber As Integer = 0             '0=All
   Public Property Channel As Integer = 1
   Public Property Layer As Integer = 20
   Public Property FlashLayer As Integer = 1

   'Slave sheet
   Public Property SlaveWorksheet As String = ""
   Public Property SlaveChannel As Integer = 2

   'Templates
   Public Property Template As String = ""
   Public Property ControlsSet As ucPlaybackButtons.enumControlSets = ucPlaybackButtons.enumControlSets.csLoadPlayStopUpdate
   Public Property ShowInDashboard As Boolean = True

   'Queries
   Public Property UpdateQueries As Boolean = False
   Public ReadOnly Property Queries As List(Of String)
      Get
         Return _Queries.ToList()
      End Get
   End Property
   Public Function IsQueryChecked(queryName As String) As Boolean
      Return _Queries.Contains(queryName)
   End Function

#End Region

#Region "DVE"

   Public Property UseDVE As Boolean = False

   Public Property DVE_X As Double = 0
   Public Property DVE_Y As Double = 0
   Public Property DVE_Width As Double = 1
   Public Property DVE_Height As Double = 1

#End Region

#Region "Helpers"

   Private Sub SetDVEVariables(dveString As String)

      Dim arr() As String = dveString.Split(" ")
      Dim err As Boolean = False
      If arr.Length = 4 Then
         If Not Double.TryParse(arr(0), DVE_X) Then
            err = True
         End If
         If Not Double.TryParse(arr(1), DVE_Y) Then
            err = True
         End If
         If Not Double.TryParse(arr(2), DVE_Width) Then
            err = True
         End If
         If Not Double.TryParse(arr(3), DVE_Height) Then
            err = True
         End If
      End If

      If err Then
         SetDVEVariables("0 0 1 1")
      End If

   End Sub

   Private Function GetDVEVariables() As String
      Return String.Format(CultureInfo.InvariantCulture, "{0:F6} {1:F6} {2:F6} {3:F6}", DVE_X, DVE_Y, DVE_Width, DVE_Height)
   End Function

#End Region

End Class
