Imports Microsoft.Office.Interop.Excel
Imports CasparObjects
Imports System.Windows.Forms

Public Class frmChangeTemplatePath

   Private _wrkSheet As Worksheet
   Private _CasparCG As CasparCG

   Public WriteOnly Property wrkSheet As Worksheet
      Set(value As Worksheet)
         _wrkSheet = value
      End Set
   End Property

   Public WriteOnly Property CasparCG As CasparCG
      Set(value As CasparCG)
         _CasparCG = value
      End Set
   End Property

   Private Sub frmChangeTemplatePath_Load(sender As Object, e As EventArgs) Handles Me.Load

      Dim lst As List(Of String) = _CasparCG.GetTemplateFolderNames()

      For Each t As String In lst
         cboSource.Items.Add(t)
         cboDestination.Items.Add(t)
      Next

   End Sub

   Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

      If MsgBox("This will change the settings on ALL worksheets of the whole workbook. Proceed?", vbQuestion Or MsgBoxStyle.YesNo, "Change Template paths") = MsgBoxResult.Yes Then

         Dim src As String = ""
         Dim dst As String = ""

         If Not (cboSource.SelectedIndex = 0 Or cboSource.SelectedIndex = -1) Then
            src = cboSource.Text
         End If
         If Not (cboDestination.SelectedIndex = 0 Or cboDestination.SelectedIndex = -1) Then
            dst = cboDestination.Text
         End If

         If Not (src = "" And dst = "") Then


            Dim wb As Workbook = CType(_wrkSheet.Parent, Workbook)
            For Each ws As Worksheet In wb.Sheets

               Dim mainTemplateName As String = CustomProperties.Load(ws, "Template", "")
               Dim previewTemplateName As String = CustomProperties.Load(ws, "PreviewTemplate", "")

               If src = "" Then
                  If mainTemplateName <> "" And Not mainTemplateName.StartsWith(dst) Then
                     mainTemplateName = dst + "/" + mainTemplateName
                  End If
                  If previewTemplateName <> "" And Not previewTemplateName.StartsWith(dst) Then
                     previewTemplateName = dst + "/" + previewTemplateName
                  End If
               Else
                  If mainTemplateName <> "" And Not mainTemplateName.StartsWith(dst) Then
                     mainTemplateName.Replace(src, dst)
                  End If
                  If previewTemplateName <> "" And Not previewTemplateName.StartsWith(dst) Then
                     previewTemplateName.Replace(src, dst)
                  End If
               End If

               If mainTemplateName <> "" Then
                  CustomProperties.Save(ws, "Template", mainTemplateName)
               End If
               If previewTemplateName <> "" Then
                  CustomProperties.Save(ws, "PreviewTemplate", previewTemplateName)
               End If
            Next

         End If

      End If

      Me.DialogResult = DialogResult.OK
      Me.Close()

   End Sub

End Class