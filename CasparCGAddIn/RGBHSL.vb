Imports System
Imports System.Drawing

   Public Class RGBHSL

      Public Class HSL

      Private _h As Double
      Private _s As Double
      Private _l As Double

      Public Property H_Deg() As Double
         Get
            Return _h * 360
         End Get
         Set(ByVal value As Double)
            _h = value / 360
         End Set
      End Property

      Public Property H() As Double
         Get
            Return _h
         End Get
         Set(ByVal value As Double)
            _h = value
            _h = IIf(_h > 1, 1, IIf(_h < 0, 0, _h))
         End Set
      End Property

      Public Property S() As Double
         Get
            Return _s
         End Get
         Set(ByVal value As Double)
            _s = value
            _s = IIf(_s > 1, 1, IIf(_s < 0, 0, _s))
         End Set
      End Property

      Public Property L() As Double
         Get
            Return _l
         End Get
         Set(ByVal value As Double)
            _l = value
            _l = IIf(_l > 1, 1, IIf(_l < 0, 0, _l))
         End Set
      End Property

      Public Sub New()
         _h = 0
         _s = 0
         _l = 0
      End Sub

   End Class

   'Sets the absolute brightness of a colour
   Public Shared Function SetBrightness(ByVal c As Color, ByVal brightness As Double) As Color
      Dim hsl As HSL = RGB_to_HSL(c)
      hsl.L = brightness
      Return HSL_to_RGB(hsl)
   End Function

   'Modifies an existing brightness level
   Public Shared Function ModifyBrightness(ByVal c As Color, ByVal brightness As Double) As Color
      Dim hsl As HSL = RGB_to_HSL(c)
      hsl.L *= brightness
      Return HSL_to_RGB(hsl)
   End Function

   'Sets the absolute saturation level
   Public Shared Function SetSaturation(ByVal c As Color, ByVal Saturation As Double) As Color
      Dim hsl As HSL = RGB_to_HSL(c)
      hsl.S = Saturation
      Return HSL_to_RGB(hsl)
   End Function

   'Modifies an existing Saturation level
   Public Shared Function ModifySaturation(ByVal c As Color, ByVal Saturation As Double) As Color
      Dim hsl As HSL = RGB_to_HSL(c)
      hsl.S *= Saturation
      Return HSL_to_RGB(hsl)
   End Function

   'Sets the absolute Hue level
   Public Shared Function SetHue(ByVal c As Color, ByVal Hue As Double) As Color
      Dim hsl As HSL = RGB_to_HSL(c)
      hsl.H = Hue
      Return HSL_to_RGB(hsl)
   End Function

   'Modifies an existing Hue level
   Public Shared Function ModifyHue(ByVal c As Color, ByVal Hue As Double) As Color
      Dim hsl As HSL = RGB_to_HSL(c)
      hsl.H *= Hue
      Return HSL_to_RGB(hsl)
   End Function

   'Converts a colour from HSL to RGB
   Public Shared Function HSL_to_RGB(ByVal hsl As HSL) As Color
      Dim r As Double = 0
      Dim g As Double = 0
      Dim b As Double = 0
      Dim temp1, temp2 As Double

      If hsl.L = 0 Then
         r = 0
         g = 0
         b = 0
      Else
         If hsl.S = 0 Then
            r = hsl.L
            g = hsl.L
            b = hsl.L
         Else
            temp2 = IIf(hsl.L <= 0.5, hsl.L * (1.0 + hsl.S), hsl.L + hsl.S - hsl.L * hsl.S)
            temp1 = 2.0 * hsl.L - temp2

            Dim t3() As Double = {hsl.H + 1.0 / 3.0, hsl.H, hsl.H - 1.0 / 3.0}
            Dim clr() As Double = {0, 0, 0}
            Dim i As Integer
            For i = 0 To 2
               If t3(i) < 0 Then
                  t3(i) += 1.0
               End If
               If t3(i) > 1 Then
                  t3(i) -= 1.0
               End If
               If 6.0 * t3(i) < 1.0 Then
                  clr(i) = temp1 + (temp2 - temp1) * t3(i) * 6.0
               ElseIf 2.0 * t3(i) < 1.0 Then
                  clr(i) = temp2
               ElseIf 3.0 * t3(i) < 2.0 Then
                  clr(i) = temp1 + (temp2 - temp1) * (2.0 / 3.0 - t3(i)) * 6.0
               Else
                  clr(i) = temp1
               End If
            Next i
            r = clr(0)
            g = clr(1)
            b = clr(2)
         End If
      End If

      Return Color.FromArgb(CInt(255 * r), CInt(255 * g), CInt(255 * b))
   End Function

   'Converts RGB to HSL
   Public Shared Function RGB_to_HSL(ByVal c As Color) As HSL
      Dim hsl As New HSL()

      hsl.H = c.GetHue() / 360.0 ' we store hue as 0-1 as opposed to 0-360
      hsl.L = c.GetBrightness()
      hsl.S = c.GetSaturation()

      Return hsl

   End Function

End Class


