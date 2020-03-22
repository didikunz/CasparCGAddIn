Imports Microsoft.Office.Interop.Excel
Public Class CustomProperties

   Public Shared Function Save(wrkSheet As Worksheet, Key As String, Value As String) As Boolean

      If Exists(wrkSheet, Key) Then

         If Not Remove(wrkSheet, Key) Then
            Return False
         End If

      End If

      If Not Add(wrkSheet, Key, Value) Then
         Return False
      End If

      Return True

   End Function

   Public Shared Function Load(wrkSheet As Worksheet, Key As String, DefaultValue As Boolean) As Boolean
      Dim inte As Integer = Load(wrkSheet, Key, IIf(DefaultValue, 1, 0))
      Return (inte = 1)
   End Function

   Public Shared Function Load(wrkSheet As Worksheet, Key As String, DefaultValue As Integer) As Integer
      Dim inte As Integer = 0
      If Integer.TryParse(Load(wrkSheet, Key), inte) Then
         Return inte
      Else
         Return DefaultValue
      End If
   End Function

   Public Shared Function Load(wrkSheet As Worksheet, Key As String, DefaultValue As String) As String
      Dim s As String = Load(wrkSheet, Key)
      If s = "" Then
         Return DefaultValue
      Else
         Return s
      End If
   End Function

   'Basic Load function
   Private Shared Function Load(wrkSheet As Worksheet, Key As String) As String
      Try
         For i As Integer = 1 To wrkSheet.CustomProperties.Count
            If wrkSheet.CustomProperties.Item(i).Name = Key Then
               Return wrkSheet.CustomProperties.Item(i).Value.ToString
            End If
         Next
         Return ""

      Catch ex As Exception
         Return ""
      End Try
   End Function


   Public Shared Function Delete(wrkSheet As Worksheet, Key As String) As Boolean
      Return Remove(wrkSheet, Key)
   End Function

   Public Shared Function Clear(wrkSheet As Worksheet) As Boolean
      Try
         Do While wrkSheet.CustomProperties.Count > 0
            wrkSheet.CustomProperties.Item(0).Delete()
         Loop
         Return True
      Catch ex As Exception
         Return False
      End Try
   End Function

   Private Shared Function Add(wrkSheet As Worksheet, Key As String, Value As String) As Boolean
      Try
         wrkSheet.CustomProperties.Add(Key, Value)
         Return True
      Catch ex As Exception
         Return False
      End Try
   End Function

   Private Shared Function Remove(wrkSheet As Worksheet, Key As String) As Boolean
      Try
         For i As Integer = 1 To wrkSheet.CustomProperties.Count
            If wrkSheet.CustomProperties.Item(i).Name = Key Then
               wrkSheet.CustomProperties.Item(i).Delete()
               Exit For
            End If
         Next
         Return True
      Catch ex As Exception
         Return False
      End Try
   End Function

   Private Shared Function Exists(wrkSheet As Worksheet, Key As String) As Boolean
      Try
         For i As Integer = 1 To wrkSheet.CustomProperties.Count
            If wrkSheet.CustomProperties.Item(i).Name = Key Then
               Return True
            End If
         Next
         Return False
      Catch ex As Exception
         Return False
      End Try
   End Function

End Class
