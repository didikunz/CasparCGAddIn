Imports System.Windows.Forms

Public Class Loader

   Private Shared Sub WriteSubControls(ByVal ct As Control, theme As Theme)

      Dim perform As Boolean = False

      For Each ctrl As Control In ct.Controls

         If ctrl.Tag IsNot Nothing AndAlso ctrl.Tag.ToString.ToLower.Contains("[ignore]") Then
            perform = False
         Else
            perform = True
         End If

         'Debug.Print(ctrl.Name + " " + ctrl.GetType.ToString + " " + perform.ToString)

         If perform Then

            If TypeOf ctrl Is DataGridView Then

               Dim dgv As DataGridView = CType(ctrl, DataGridView)

               Dim headerStyle As DataGridViewCellStyle = New DataGridViewCellStyle
               headerStyle.ForeColor = theme.GridHeaderForeColor
               headerStyle.BackColor = theme.GridHeaderBackColor
               headerStyle.SelectionForeColor = theme.SelectionForeColor
               headerStyle.SelectionBackColor = theme.SelectionBackColor

               dgv.ColumnHeadersDefaultCellStyle = headerStyle
               dgv.RowHeadersDefaultCellStyle = headerStyle

               dgv.EnableHeadersVisualStyles = False
               dgv.ForeColor = theme.ForeColor
               dgv.BackColor = theme.GridBackColor
               dgv.BackgroundColor = theme.GridBackColor
               dgv.GridColor = theme.GridColor

               Dim style As DataGridViewCellStyle = New DataGridViewCellStyle
               style.ForeColor = theme.ForeColor
               style.BackColor = theme.BackColor
               style.SelectionForeColor = theme.SelectionForeColor
               style.SelectionBackColor = theme.SelectionBackColor

               dgv.DefaultCellStyle = style
               dgv.RowsDefaultCellStyle = style
               dgv.AlternatingRowsDefaultCellStyle = style

               For Each col As DataGridViewColumn In dgv.Columns
                  If TypeOf col Is DataGridViewLinkColumn Then
                     CType(col, DataGridViewLinkColumn).LinkColor = theme.ForeColor
                     CType(col, DataGridViewLinkColumn).ActiveLinkColor = theme.ForeColor
                     CType(col, DataGridViewLinkColumn).VisitedLinkColor = theme.ForeColor
                  End If
               Next


            ElseIf TypeOf ctrl Is LinkLabel Then

               Dim lnklbl As LinkLabel = CType(ctrl, LinkLabel)
               lnklbl.LinkColor = theme.ForeColor
               lnklbl.VisitedLinkColor = theme.ForeColor
               lnklbl.ForeColor = theme.ForeColor
               lnklbl.BackColor = System.Drawing.Color.Transparent


            ElseIf TypeOf ctrl Is Label Then

               If ctrl.Tag IsNot Nothing Then
                  If ctrl.Tag.ToString.ToLower.Contains("[highlite]") Then
                     ctrl.ForeColor = theme.HighliteForeColor
                     ctrl.BackColor = theme.HighliteBackColor
                  Else
                     ctrl.ForeColor = theme.ForeColor
                     ctrl.BackColor = System.Drawing.Color.Transparent
                  End If
               Else
                  ctrl.ForeColor = theme.ForeColor
                  ctrl.BackColor = System.Drawing.Color.Transparent
               End If


            ElseIf TypeOf ctrl Is Button Then

               If ctrl.Tag IsNot Nothing Then
                  If ctrl.Tag.ToString.ToLower.Contains("[highlite]") Then
                     ctrl.ForeColor = theme.HighliteForeColor
                     ctrl.BackColor = theme.HighliteBackColor
                  Else
                     ctrl.ForeColor = theme.ForeColor
                     ctrl.BackColor = theme.BackColor
                  End If
               Else
                  ctrl.ForeColor = theme.ForeColor
                  ctrl.BackColor = theme.BackColor
               End If

            ElseIf TypeOf ctrl Is CheckBox Then

               If ctrl.Tag IsNot Nothing Then
                  If ctrl.Tag.ToString.ToLower.Contains("[highlite]") Then
                     ctrl.ForeColor = theme.HighliteForeColor
                     ctrl.BackColor = theme.HighliteBackColor
                  Else
                     ctrl.ForeColor = theme.ForeColor
                     ctrl.BackColor = System.Drawing.Color.Transparent
                  End If
               Else
                  ctrl.ForeColor = theme.ForeColor
                  ctrl.BackColor = System.Drawing.Color.Transparent
               End If

            ElseIf TypeOf ctrl Is TabPage Then

               ctrl.ForeColor = theme.ForeColor
               ctrl.BackColor = theme.BackColor

            Else

               'Debug.Print(ctrl.Name + " " + ctrl.GetType.ToString)

               ctrl.ForeColor = theme.ForeColor
               If Not ctrl.BackColor = Drawing.Color.Transparent Then
                  ctrl.BackColor = theme.BackColor
               End If

               If ctrl.BackgroundImage IsNot Nothing Then
                  ctrl.BackgroundImage = theme.WindowBackgroundImage
                  ctrl.BackgroundImageLayout = ImageLayout.Stretch
               End If

            End If

         End If

         If ctrl.HasChildren Then
            WriteSubControls(ctrl, theme)
         End If

      Next

   End Sub

   Public Shared Sub Load(frm As Form, theme As Theme)

      If theme IsNot Nothing Then

         Dim ctrl As Control = CType(frm, Control)

         ctrl.ForeColor = theme.ForeColor
         ctrl.BackColor = theme.WindowColor

         'If ctrl.BackgroundImage IsNot Nothing Then
         ctrl.BackgroundImage = theme.WindowBackgroundImage
         ctrl.BackgroundImageLayout = ImageLayout.Stretch
         'End If

         If ctrl.HasChildren Then
            WriteSubControls(ctrl, theme)
         End If

      End If

   End Sub

   Public Shared Sub LoadControl(ctrl As Control, theme As Theme)

      If theme IsNot Nothing Then

         ctrl.ForeColor = theme.ForeColor
         ctrl.BackColor = theme.WindowColor

         ctrl.BackgroundImage = theme.WindowBackgroundImage
         ctrl.BackgroundImageLayout = ImageLayout.Stretch

         If ctrl.HasChildren Then
            WriteSubControls(ctrl, theme)
         End If

      End If

   End Sub

   Public Shared Sub LoadMenu(ctrl As ToolStripMenuItem, theme As Theme)

      If theme IsNot Nothing Then

         ctrl.ForeColor = theme.ForeColor
         ctrl.BackColor = theme.WindowColor

         For Each item As ToolStripItem In ctrl.DropDownItems
            If TypeOf item Is ToolStripSeparator Then
               item.ForeColor = theme.ForeColor
               item.BackColor = Drawing.Color.Transparent
            ElseIf TypeOf item Is ToolStripMenuItem Then
               item.ForeColor = theme.ForeColor
               item.BackColor = theme.WindowColor
               LoadSubMenu(CType(item, ToolStripMenuItem), theme)
            Else
               item.ForeColor = theme.ForeColor
               item.BackColor = theme.WindowColor
            End If
         Next

      End If

   End Sub

   Public Shared Sub LoadContextMenu(ctrl As ContextMenuStrip, theme As Theme)

      If theme IsNot Nothing Then

         ctrl.SuspendLayout()

         ctrl.ForeColor = theme.ForeColor
         ctrl.BackColor = theme.WindowColor

         For Each item As ToolStripItem In ctrl.Items
            If TypeOf item Is ToolStripSeparator Then
               item.ForeColor = theme.ForeColor
               item.BackColor = Drawing.Color.Transparent
            ElseIf TypeOf item Is ToolStripMenuItem Then
               item.ForeColor = theme.ForeColor
               item.BackColor = theme.WindowColor
               LoadSubMenu(CType(item, ToolStripMenuItem), theme)
            Else
               item.ForeColor = theme.ForeColor
               item.BackColor = theme.WindowColor
            End If
         Next

         ctrl.PerformLayout()

      End If

   End Sub

   Public Shared Sub LoadSubMenu(ctrl As ToolStripMenuItem, theme As Theme)

      If theme IsNot Nothing Then

         For Each item As ToolStripItem In ctrl.DropDownItems
            If TypeOf item Is ToolStripSeparator Then
               item.ForeColor = theme.ForeColor
               item.BackColor = Drawing.Color.FromArgb(0, 0, 0, 0)
            Else
               item.ForeColor = theme.ForeColor
               item.BackColor = theme.WindowColor
            End If
         Next

      End If

   End Sub

   Public Shared Function CreateDefaultTheme() As Theme
      Return New Theme
   End Function

   Public Shared Function CreateDarkTheme() As Theme

      Dim th As Theme = New Theme

      th.ForeColor = Drawing.Color.White
      th.BackColor = Drawing.Color.FromArgb(54, 54, 54)

      th.WindowColor = Drawing.Color.Black

      th.HighliteForeColor = Drawing.Color.White
      th.HighliteBackColor = Drawing.Color.FromArgb(135, 17, 18)

      th.SelectionForeColor = Drawing.Color.White
      th.SelectionBackColor = Drawing.Color.FromArgb(135, 17, 18)

      th.GridBackColor = Drawing.Color.Black
      th.GridColor = Drawing.Color.DarkGray
      th.GridHeaderForeColor = Drawing.Color.White
      th.GridHeaderBackColor = Drawing.Color.DarkGray

      th.WindowBackgroundImageTopColor = Drawing.Color.FromArgb(85, 85, 85)
      th.WindowBackgroundImageBottomColor = Drawing.Color.FromArgb(7, 7, 7)

      th.ErrorBackColor = Drawing.Color.FromArgb(196, 25, 26)

      Return th

   End Function

End Class
