Imports System.Text

Public Class LayerRule

   Public Enum enumRulesMode
      rmNone
      rmBeginsWith
      rmContains
      rmEndsWith
   End Enum

   Public Property NamePart As String = ""
   Public Property Layer As Integer = 20
   Public Property RulesMode As enumRulesMode = enumRulesMode.rmNone

   Public Sub New()
   End Sub

   Public Sub New(namePart As String)
      Me.NamePart = namePart
   End Sub

   Public Sub New(namePart As String, layer As Integer, mode As enumRulesMode)
      Me.NamePart = namePart
      Me.Layer = layer
      Me.RulesMode = mode
   End Sub

End Class

Public Class LayerRules

   Private _Rules As List(Of LayerRule) = New List(Of LayerRule)

   Public ReadOnly Property Rules As List(Of LayerRule)
      Get
         Return _Rules
      End Get
   End Property

   Public Function CheckRules(name As String, defaultLayer As Integer) As Integer

      name = name.ToUpper
      Dim retVal As Integer = defaultLayer

      For Each lr As LayerRule In _Rules

         Select Case lr.RulesMode
            Case LayerRule.enumRulesMode.rmBeginsWith
               If name.StartsWith(lr.NamePart.ToUpper) Then
                  retVal = lr.Layer
                  Exit For
               End If

            Case LayerRule.enumRulesMode.rmContains
               If name.Contains(lr.NamePart.ToUpper) Then
                  retVal = lr.Layer
                  Exit For
               End If

            Case LayerRule.enumRulesMode.rmEndsWith
               If name.EndsWith(lr.NamePart.ToUpper) Then
                  retVal = lr.Layer
                  Exit For
               End If

         End Select

      Next

      Return retVal

   End Function

   Public Function GetRules() As String

      Dim sb As StringBuilder = New StringBuilder

      For Each lr As LayerRule In _Rules
         sb.Append(lr.NamePart)
         sb.Append(":")
         sb.Append(lr.Layer.ToString)
         sb.Append(":")
         sb.Append(CInt(lr.RulesMode).ToString)
         sb.Append("|")
      Next

      Return sb.ToString

   End Function

   Private Sub SetRules(rules As String)

      Dim arr() As String = rules.Split("|")

      For Each s As String In arr
         Dim parts() As String = s.Split(":")
         If parts.Length = 3 Then
            _Rules.Add(New LayerRule(parts(0), Integer.Parse(parts(1)), Integer.Parse(parts(2))))
         End If
      Next

   End Sub

   Public Sub New()
   End Sub

   Public Sub New(rules As String)
      SetRules(rules)
   End Sub

End Class
