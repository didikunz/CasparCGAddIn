Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Tools
Imports Microsoft.Office.Tools.Excel
Imports Microsoft.Office.Tools.Excel.Extensions
Imports Microsoft.Office.Tools.Ribbon
Imports CasparObjects
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Net
Imports Microsoft.Office.Core
Imports System.Diagnostics
Imports System.Web.UI
Imports CasparCGAddIn

Public Class zzTrash

   Private Sub RefreshAllButtons()

      If _ActiveWorkbook IsNot Nothing Then

         For Each nativeWorksheet As Microsoft.Office.Interop.Excel.Worksheet In _ActiveWorkbook.Sheets

            Dim currWorksheet As Microsoft.Office.Tools.Excel.Worksheet = Globals.Factory.GetVstoObject(nativeWorksheet)

            For Each name As Excel.Name In nativeWorksheet.Names

               Dim id As String = name.Name.ToString.Trim.Substring(nativeWorksheet.Name.Length + 1)
               If id.StartsWith("L") Then

                  'LapLog
                  Dim range As Excel.Range = name.RefersToRange
                  Dim llitem As LapLogItem = New LapLogItem(CustomDocumentProperties.Load(_ActiveWorkbook, id, ""))

                  Dim button As Microsoft.Office.Tools.Excel.Controls.Button = New Microsoft.Office.Tools.Excel.Controls.Button
                  button.Text = llitem.Name
                  button.Tag = id
                  AddHandler button.MouseUp, AddressOf LapLog_MouseUp
                  currWorksheet.Controls.AddControl(button, range, id)

               End If

            Next

         Next

         _ActiveWorkbook.Saved = True

      End If

   End Sub

   Public Sub RemoveAllButtons()

      If _ActiveWorkbook IsNot Nothing Then

         For Each nativeWorksheet As Microsoft.Office.Interop.Excel.Worksheet In _ActiveWorkbook.Sheets

            Dim currWorksheet As Microsoft.Office.Tools.Excel.Worksheet = Globals.Factory.GetVstoObject(nativeWorksheet)

            Do While currWorksheet.Controls.Count > 0

               Dim ctrl As System.Windows.Forms.Control = currWorksheet.Controls(0)

               If TypeOf ctrl Is Microsoft.Office.Tools.Excel.Controls.Button Then
                  Dim button As Microsoft.Office.Tools.Excel.Controls.Button = CType(ctrl, Microsoft.Office.Tools.Excel.Controls.Button)
                  If button.Tag.ToString.StartsWith("L") Then
                     RemoveHandler button.MouseUp, AddressOf LapLog_MouseUp
                     currWorksheet.Controls.Remove(button)
                  End If
               End If

            Loop

         Next

      End If

   End Sub

   Private Sub btnAddLapLog_Click(sender As Object, e As RibbonControlEventArgs)

      Dim currRange As Range = CType(Globals.ThisAddIn.Application.Selection, Range)
      If currRange.Cells.Count > 0 Then

         Dim llitem As LapLogItem = New LapLogItem
         Dim fll As frmLapLog = New frmLapLog
         fll.wrkBook = _ActiveWorkbook
         fll.currentLapLogItem = llitem

         If fll.ShowDialog() = DialogResult.OK Then

            Dim id As String = "L" + Guid.NewGuid().ToString.Replace("-", "")

            Dim nativeWorksheet As Microsoft.Office.Interop.Excel.Worksheet = _ActiveWorkbook.ActiveSheet
            Dim currWorksheet As Microsoft.Office.Tools.Excel.Worksheet = Globals.Factory.GetVstoObject(nativeWorksheet)
            currWorksheet.Names.Add(id, currRange)

            Dim button As Microsoft.Office.Tools.Excel.Controls.Button = New Microsoft.Office.Tools.Excel.Controls.Button
            button.Text = llitem.Name
            button.Tag = id
            AddHandler button.MouseUp, AddressOf LapLog_MouseUp
            currWorksheet.Controls.AddControl(button, currRange, id)

            CustomDocumentProperties.Save(_ActiveWorkbook, id, llitem.ToDelimited)
            _ActiveWorkbook.Saved = False

         End If

      End If

   End Sub

   Private Sub LapLog_MouseUp(sender As Object, e As MouseEventArgs)

      Dim button As Microsoft.Office.Tools.Excel.Controls.Button = CType(sender, Microsoft.Office.Tools.Excel.Controls.Button)
      Dim id As String = button.Tag

      If e.Button = MouseButtons.Left Then

      ElseIf e.Button = MouseButtons.Right Then

         Dim llitem As LapLogItem = New LapLogItem(CustomDocumentProperties.Load(_ActiveWorkbook, id, ""))

         Dim fll As frmLapLog = New frmLapLog
         fll.wrkBook = _ActiveWorkbook
         fll.currentLapLogItem = llitem

         If fll.ShowDialog() = DialogResult.OK Then

            button.Text = llitem.Name

            CustomDocumentProperties.Save(_ActiveWorkbook, id, llitem.ToDelimited)
            _ActiveWorkbook.Saved = False

         End If

      End If

   End Sub

End Class
