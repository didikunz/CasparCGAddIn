Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel

Public Class CustomXML

   ''' <summary>
   ''' Saves an XML, that is serialized into a string
   ''' </summary>
   ''' <param name="wrkBook">The workbook to save in</param>
   ''' <param name="id">The Guid as string</param>
   ''' <param name="XML">The serialized xml</param>
   ''' <returns>The id. Always when you save a new id is returned</returns>
   Public Shared Function Save(wrkBook As Workbook, id As String, XML As String) As String
      Try
         Dim part As CustomXMLPart = wrkBook.CustomXMLParts.SelectByID(id)
         If part IsNot Nothing Then
            part.Delete()
         End If
         part = wrkBook.CustomXMLParts.Add(XML)
         Return part.Id
      Catch ex As Exception
         Return ""
      End Try
   End Function

   ''' <summary>
   ''' Loads a XML string from a workbook
   ''' </summary>
   ''' <param name="wrkBook">The workbook to load from</param>
   ''' <param name="id">The Guid as string</param>
   ''' <returns>The serialized xml</returns>
   Public Shared Function Load(wrkBook As Workbook, id As String) As String
      Try
         Dim part As CustomXMLPart = wrkBook.CustomXMLParts.SelectByID(id)
         If part IsNot Nothing Then
            Return part.DocumentElement.XML
         Else
            Return ""
         End If
      Catch ex As Exception
         Return ""
      End Try
   End Function

End Class
