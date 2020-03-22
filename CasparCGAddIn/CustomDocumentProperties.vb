Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel

Public Class CustomDocumentProperties

   Public Shared Function Save(wrkBook As Workbook, Key As String, Value As String) As Boolean
      Try
         Dim props As DocumentProperties = wrkBook.CustomDocumentProperties

         Delete(wrkBook, Key)
         props.Add(Key, False, MsoDocProperties.msoPropertyTypeString, Value)

         Return True

      Catch ex As Exception
         Return False
      End Try
   End Function

   Public Shared Function Load(wrkBook As Workbook, Key As String, DefaultValue As Integer) As Integer
      Dim inte As Integer = 0
      If Integer.TryParse(Load(wrkBook, Key), inte) Then
         Return inte
      Else
         Return DefaultValue
      End If
   End Function

   Public Shared Function Load(wrkBook As Workbook, Key As String, DefaultValue As Boolean) As Boolean
      Dim inte As Integer = Load(wrkBook, Key, IIf(DefaultValue, 1, 0))
      Return (inte = 1)
   End Function

   Public Shared Function Load(wrkBook As Workbook, Key As String, DefaultValue As String) As String
      Dim s As String = Load(wrkBook, Key)
      If s = "" Then
         Return DefaultValue
      Else
         Return s
      End If
   End Function

   Public Shared Function Delete(wrkBook As Workbook, Key As String) As Boolean
      Try
         Dim props As DocumentProperties = wrkBook.CustomDocumentProperties
         props(Key).Delete()
         Return True
      Catch ex As Exception
         Return False
      End Try
   End Function

   'Basic Load function
   Private Shared Function Load(wrkBook As Workbook, Key As String) As String
      Try
         Dim props As DocumentProperties = wrkBook.CustomDocumentProperties

         For Each prop As Office.DocumentProperty In props
            If prop.Name = Key Then
               Return prop.Value.ToString
            End If
         Next
         Return ""

      Catch ex As Exception
         Return ""
      End Try
   End Function

End Class
