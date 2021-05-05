Imports Eval3

Public Class EvalFunctions

   Private Shared daylist() As String = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
   Private Shared monthlist() As String = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}

   Public Function Sin(ByVal v As Double) As Double
      Return Math.Sin(v)
   End Function

   Public Function Cos(ByVal v As Double) As Double
      Return Math.Cos(v)
   End Function

   Public Function Now() As DateTime
      Return Microsoft.VisualBasic.Now
   End Function

   Public Function Today() As DateTime
      Return Microsoft.VisualBasic.Today
   End Function

   Public Function Rnd() As Double
      Microsoft.VisualBasic.Randomize()
      Return Microsoft.VisualBasic.Rnd
   End Function

   Public Function Trim(ByVal str As String) As String
      Return Microsoft.VisualBasic.Trim(str)
   End Function

   Public Function LeftTrim(ByVal str As String) As String
      Return Microsoft.VisualBasic.LTrim(str)
   End Function

   Public Function RightTrim(ByVal str As String) As String
      Return Microsoft.VisualBasic.RTrim(str)
   End Function

   Public Function PadLeft(ByVal str As String, ByVal wantedlen As Integer, Optional ByVal addedchar As String = " ") As String
      Do While Len(str) < wantedlen
         str = addedchar & str
      Loop
      Return str
   End Function

   Public Function [Mod](ByVal x As Double, ByVal y As Double) As Double
      Return x Mod y
   End Function

   Public Function [If](ByVal cond As Boolean, ByVal TrueValue As Object, ByVal FalseValue As Object) As Object
      If cond Then
         Return TrueValue
      Else
         Return FalseValue
      End If
   End Function

   Public Function Format(ByVal value As Object, ByVal style As String) As String
      Return String.Format(value, style)
   End Function

   Public Function Lower(ByVal value As String) As String
      Return Microsoft.VisualBasic.LCase(value)
   End Function

   Public Function Upper(ByVal value As String) As String
      Return value.ToUpper
   End Function

   Public Function WCase(ByVal value As String) As String
      If Len(value) = 0 Then Return ""
      Return Microsoft.VisualBasic.UCase(value.Substring(0, 1)) &
              Microsoft.VisualBasic.LCase(value.Substring(1))
   End Function

   Public Function [Date](ByVal year As Integer, ByVal month As Integer, ByVal day As Integer) As DateTime
      Return New Date(year, month, day)
   End Function

   Public Function Year(ByVal d As DateTime) As Integer
      Return d.Year
   End Function

   Public Function Month(ByVal d As DateTime) As Integer
      Return d.Month
   End Function

   Public Function Day(ByVal d As DateTime) As Integer
      Return d.Day
   End Function

   Public Function WeekDay(ByVal d As DateTime) As Integer
      Select Case d.DayOfWeek
         Case DayOfWeek.Sunday
            Return 1
         Case DayOfWeek.Monday
            Return 2
         Case DayOfWeek.Tuesday
            Return 3
         Case DayOfWeek.Wednesday
            Return 4
         Case DayOfWeek.Thursday
            Return 5
         Case DayOfWeek.Friday
            Return 6
         Case DayOfWeek.Saturday
            Return 7
         Case Else
            Return 0
      End Select
   End Function

   Function Replace(ByVal base As String, ByVal search As String, ByVal repl As String) As String
      Return base.Replace(search, repl)
   End Function

   Public Function Substr(ByVal s As String, ByVal from As Integer, Optional ByVal len As Integer = Integer.MaxValue) As String
      If s Is Nothing Then Return String.Empty
      from -= 1
      If from < 1 Then from = 0
      If from >= s.Length Then from = s.Length
      If from + len > s.Length Then len = s.Length - from
      Return s.Substring(from, len)
   End Function

   Public Function Len(ByVal str As String) As Integer
      Return Microsoft.VisualBasic.Len(str)
   End Function

   Public Function Abs(ByVal val As Double) As Double
      If val < 0 Then
         Return -val
      Else
         Return val
      End If
   End Function

   Public Function Int(ByVal value As Object) As Integer
      Return CInt(value)
   End Function

   Public Function Trunc(ByVal value As Double, Optional ByVal prec As Integer = 0) As Integer
      value -= 0.5 / Math.Pow(10, prec)
      Return CInt(Math.Round(value, prec))
   End Function

   Public Function Dec(ByVal value As Object) As Double
      Return CDbl(value)
   End Function

   Public Function Round(ByVal value As Object) As Double
      Return Math.Round(CDbl(value))
   End Function

   Public Function Min(ByVal v1 As Double, ByVal v2 As Double,
           Optional ByVal v3 As Double = Double.MaxValue,
           Optional ByVal v4 As Double = Double.MaxValue,
           Optional ByVal v5 As Double = Double.MaxValue) As Double
      Dim res As Double = v1
      If v2 < res Then res = v2
      If v3 < res Then res = v3
      If v4 < res Then res = v4
      If v5 < res Then res = v5
      Return res
   End Function

   Public Function Max(ByVal v1 As Double, ByVal v2 As Double,
           Optional ByVal v3 As Double = Double.MinValue,
           Optional ByVal v4 As Double = Double.MinValue,
           Optional ByVal v5 As Double = Double.MinValue) As Double
      Dim res As Double = v1
      If v2 > res Then res = v2
      If v3 > res Then res = v3
      If v4 > res Then res = v4
      If v5 > res Then res = v5
      Return res
   End Function

   Public Function Chr(ByVal c As Integer) As String
      Return Chr(c)
   End Function

   Public Function ChCR() As String
      Return vbCr
   End Function

   Public Function ChLF() As String
      Return vbLf
   End Function

   Public Function ChCRLF() As String
      Return vbCrLf
   End Function

   Public Function Entry(ByVal n As Integer, ByVal s As String, Optional ByVal delim As String = ",") As String
      Dim pos, pos2, l As Integer
      l = s.Length
      ' first find the starting pos
      For i As Integer = 0 To n
         If pos2 >= l Then
            Return ""
            Exit Function
         End If
         pos = s.IndexOf(delim, pos2)
         If pos < 0 Then
            pos = s.Length
         End If
         If i = n Then
            Return s.Substring(pos2, pos - pos2)
         End If
         pos2 = pos + 1
      Next
      Return ""
   End Function

   Public Function Exp(ByVal base As Double, ByVal pexp As Double) As Double
      Return Math.Pow(base, pexp)
   End Function

   Public Function Index(ByVal s As String, ByVal search As String, Optional ByVal delim As String = ",") As Integer
      ' Copied from common.globals
      Dim pos As Integer, pos2 As Integer, l As Integer
      l = s.Length
      ' first find the starting pos
      For i As Integer = 0 To Integer.MaxValue
         If pos2 >= l Then
            Return 0
            Exit Function
         End If
         pos = s.IndexOf(delim, pos2)
         If pos < 0 Then
            pos = s.Length
         End If
         If s.Substring(pos2, pos - pos2) = search Then
            Return i
         End If
         pos2 = pos + 1
      Next
      Return 0
   End Function

   Public Function Inlist(ByVal search As String, ByVal list As String, Optional ByVal delim As String = ",") As Boolean
      If Len(delim) = 0 Then Return False
      If Len(list) = 0 Then
         If Len(search) = 0 Then Return True Else Return False
      End If
      ' speed could be improved using indexof repeatidly
      For Each entry As String In list.Split(delim.Chars(0))
         If entry = search Then
            Return True
         End If
      Next
      Return False
   End Function

   Public Function Split(ByVal s As String, Optional ByVal delimiter As String = ",") As String()
      Return s.Split(delimiter.Chars(0))
   End Function

   Function DbNull() As System.DBNull
      Return System.DBNull.Value
   End Function

   Public Function FileExists(ByVal f As String) As Boolean
      Return (FileInfo(f).Exists)
   End Function

   Public Function FileInfo(ByVal f As String) As IO.FileInfo
      Dim altFilename As String = System.Windows.Forms.Application.StartupPath & "\Data\Scripts\" & f

      Dim fi As IO.FileInfo
      fi = New IO.FileInfo(altFilename)

      If fi.Exists = False Then
         fi = New IO.FileInfo(f)
      End If
      Return fi
   End Function

   Public Function Long_date(ByVal d As DateTime) As String
      Return Format_date(d, "d m y")
   End Function

   Public Function Money(ByVal d As Object) As String
      ' Output a currency formatted string from input value d
      ' Zero values and inputs that cannot be converted to numbers return empty string
      Dim p As Double
      Try
         If TypeOf d Is String Then
            p = Math.Round(Val(d), 4)
         Else
            p = Math.Round(CType(d, Double), 4)
            If p = 0 Then
               Return ""
            Else
               Return Format(p, "c")
            End If
         End If
      Catch ex As Exception
         Return ""
      End Try
      Return ""
   End Function

   Public Function Format_date(ByVal d As DateTime, Optional ByVal fmt As String = Nothing) As String
      Dim res As String = ""
      Dim i As Integer
      Dim code As Char
      Dim word As String
      If Len(fmt) = 0 Then fmt = "d m y"
      Dim dd As Integer = d.Day
      For i = 0 To fmt.Length - 1
         word = ""
         code = fmt.Chars(i)
         Select Case code
            Case "w"c
               word = daylist(d.DayOfWeek())
            Case "x"c
               word = Substr(daylist(d.DayOfWeek()), 1, 3)
            Case "d"c
               Dim suff As String
               If dd >= 11 And dd <= 13 Then
                  suff = "th"
               ElseIf (dd Mod 10) = 1 Then
                  suff = "st"
               ElseIf (dd Mod 10) = 2 Then
                  suff = "nd"
               ElseIf (dd Mod 10) = 3 Then
                  suff = "rd"
               Else
                  suff = "th"
               End If
               word = dd.ToString & suff
            Case "e"c
               word = dd.ToString()
            Case "f"c
               word = PadLeft(dd.ToString(), 2, "0")
            Case "m"c
               word = monthlist(d.Month() - 1)
            Case "n"c
               word = d.Month().ToString
            Case "o"c
               word = PadLeft(d.Month().ToString, 2, "0")
            Case "p"c
               word = Substr(monthlist(d.Month() - 1), 1, 3)
            Case "y"c
               word = d.Year().ToString
            Case "z"c
               word = PadLeft((d.Year() Mod 100).ToString, 2, "0")
            Case Else
               word = code
         End Select
         res &= word
      Next
      Return res
   End Function

   Public Function Sqrt(ByVal v As Double) As Double
      Return Math.Sqrt(v)
   End Function

   Public Function Power(ByVal v As Double, ByVal e As Double) As Double
      Return Math.Pow(v, e)
   End Function

   Public ReadOnly Pi As Double = Math.PI
   Public aNumber As Integer = 5

   'Public ReadOnly Property anArray() As String()
   '   Get
   '      Return "How I want a drink alcoholic of course after the heavy lectures involving quantum mechanics".Split(" "c)
   '   End Get
   'End Property

End Class

