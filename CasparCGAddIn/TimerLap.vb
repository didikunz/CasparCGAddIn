Imports System.Xml.Serialization
Imports Microsoft.Office.Interop.Excel
Imports System.ComponentModel

<Serializable()>
Public Class TimerLap
   Implements ICloneable

   Private _wrksheet As Worksheet = Nothing

   Public Property Name As String = "(New)"
   <XmlIgnore>
   Public Property Time As TimeSpan = New TimeSpan(0)

   Public Property UseForDistanceSimulation As Boolean = True
   Public Property Distance As Double

   Public Property Sheet As String = ""
   Public Property Cell As String = ""
   Public Property Format As TimerItem.enumTimerFormat = TimerItem.enumTimerFormat.MinSec

   <XmlElement("Time")>
   <Browsable(False)>
   <EditorBrowsable(EditorBrowsableState.Never)>
   Public Property TimeTicks As Long
      Get
         Return Me.Time.Ticks
      End Get
      Set(value As Long)
         Me.Time = New TimeSpan(value)
      End Set
   End Property

   Public Sub SetTime(time As TimeSpan)

      Me.Time = time
      Dim ts As TimerSettings = Globals.ThisAddIn.CasparRibon.TimerSettings

      If Me.UseForDistanceSimulation Then
         If ts.SelectedItem IsNot Nothing Then
            ts.SelectedItem.PartDistance = Me.Distance
            ts.SelectedItem.PartTime = Me.Time
         End If
      End If

      If Me.Sheet <> "" AndAlso Me.Cell <> "" Then

         If _wrksheet Is Nothing OrElse _wrksheet.Name.ToString <> Me.Sheet Then

            Dim workbook As Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
            For Each wrk As Worksheet In workbook.Sheets
               If wrk.Name.ToString = Me.Sheet Then
                  _wrksheet = wrk
                  Exit For
               End If
            Next

         End If

         If _wrksheet IsNot Nothing Then

            Dim col As Integer = 0
            Dim row As Integer = 0
            ReferenceToNumbers(Me.Cell, col, row)

            Dim range As Range = CType(_wrksheet.Cells(row, col), Range)

            Select Case Me.Format
               Case TimerItem.enumTimerFormat.MinSec
                  range.Value = String.Format("{0:mm\:ss}", Me.Time)
               Case TimerItem.enumTimerFormat.HourMinSec
                  range.Value = String.Format("{0:hh\:mm\:ss}", Me.Time)
               Case TimerItem.enumTimerFormat.DaysHourMinSec
                  range.Value = String.Format("{0:d\:hh\:mm\:ss}", Me.Time)
               Case TimerItem.enumTimerFormat.DaysHourMin
                  range.Value = String.Format("{0:d\:hh\:mm}", Me.Time)
            End Select

         End If

      End If

      ts.SaveBackupData()

   End Sub

   Public Sub New()
   End Sub

   Public Sub New(name As String)
      Me.Name = name
   End Sub

   Private Sub ReferenceToNumbers(Referece As String, ByRef Col As Integer, ByRef Row As Integer)

      Dim chars() As Char = Referece.ToCharArray()
      Dim alpha As String = ""
      Dim number As String = ""

      For c As Integer = 0 To chars.Length - 1
         If IsNumeric(chars(c).ToString) Then
            number += chars(c).ToString
         Else
            alpha += chars(c).ToString
         End If
      Next

      chars = alpha.ToUpper().ToCharArray()

      Col = 0
      Dim exponent As Integer = 0
      For c As Integer = chars.Length - 1 To 0 Step -1

         Dim wert As Integer = 0

         Select Case alpha(c)
            Case "A"
               wert = 1
            Case "B"
               wert = 2
            Case "C"
               wert = 3
            Case "D"
               wert = 4
            Case "E"
               wert = 5
            Case "F"
               wert = 6
            Case "G"
               wert = 7
            Case "H"
               wert = 8
            Case "I"
               wert = 9
            Case "J"
               wert = 10
            Case "K"
               wert = 11
            Case "L"
               wert = 12
            Case "M"
               wert = 13
            Case "N"
               wert = 14
            Case "O"
               wert = 15
            Case "P"
               wert = 16
            Case "Q"
               wert = 17
            Case "R"
               wert = 18
            Case "S"
               wert = 19
            Case "T"
               wert = 20
            Case "U"
               wert = 21
            Case "V"
               wert = 22
            Case "W"
               wert = 23
            Case "X"
               wert = 24
            Case "Y"
               wert = 25
            Case "Z"
               wert = 26
         End Select

         Col += wert * 26 ^ exponent
         exponent += 1

      Next

      Dim inte As Integer = 0
      If Integer.TryParse(number, inte) Then
         Row = inte
      Else
         Row = 1
      End If


   End Sub

   Public Function Clone() As Object Implements ICloneable.Clone

      Dim clonedLap As TimerLap = New TimerLap()

      clonedLap.Name = Me.Name
      clonedLap.Time = Me.Time

      clonedLap.UseForDistanceSimulation = Me.UseForDistanceSimulation
      clonedLap.Distance = Me.Distance

      clonedLap.Sheet = Me.Sheet
      clonedLap.Cell = Me.Cell
      clonedLap.Format = Me.Format

      Return clonedLap

   End Function

End Class
