Imports System.Windows.Forms

Public Class frmLayerRules

   Private _Settings As Settings

   Public Property LayerRules As LayerRules = New LayerRules

   Public WriteOnly Property Settings As Settings
      Set(value As Settings)
         _Settings = value
      End Set
   End Property

   Private Sub frmLayerRules_Load(sender As Object, e As EventArgs) Handles MyBase.Load

      Loader.Load(Me, _Settings.Theme)

      If LayerRules IsNot Nothing Then

         bsRules.DataSource = LayerRules.Rules
         bsRules.ResetBindings(False)

      End If

   End Sub
   Private Sub frmLayerRules_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      bsRules.EndEdit()
   End Sub

   Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

      If LayerRules IsNot Nothing Then

         Dim newRule As LayerRule = New LayerRule("(New-Rule)")
         LayerRules.Rules.Add(newRule)

         bsRules.ResetBindings(False)
         bsRules.Position = bsRules.IndexOf(newRule)

      End If

   End Sub

   Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

      If LayerRules IsNot Nothing Then

         Dim oldRule As LayerRule = CType(bsRules.Current, LayerRule)
         If oldRule IsNot Nothing Then

            LayerRules.Rules.Remove(oldRule)

            bsRules.ResetBindings(False)
            bsRules.Position = 0

         End If

      End If

   End Sub

   Private Sub btnFinish_Click(sender As Object, e As EventArgs) Handles btnFinish.Click
      DialogResult = DialogResult.OK
      Close()
   End Sub

   Private Sub bsRules_PositionChanged(sender As Object, e As EventArgs) Handles bsRules.PositionChanged

      If LayerRules IsNot Nothing Then

         Dim rule As LayerRule = CType(bsRules.Current, LayerRule)
         If rule IsNot Nothing Then

            Select Case rule.RulesMode
               Case LayerRule.enumRulesMode.rmNone
                  rbNone.Checked = True
               Case LayerRule.enumRulesMode.rmBeginsWith
                  rbStarts.Checked = True
               Case LayerRule.enumRulesMode.rmContains
                  rbContains.Checked = True
               Case LayerRule.enumRulesMode.rmEndsWith
                  rbEnds.Checked = True
            End Select

         End If

      End If

   End Sub

   Private Sub rbNone_CheckedChanged(sender As Object, e As EventArgs) Handles rbNone.CheckedChanged
      If rbNone.Checked Then
         lblMode.Text = 0
      End If
   End Sub

   Private Sub rbStarts_CheckedChanged(sender As Object, e As EventArgs) Handles rbStarts.CheckedChanged
      If rbStarts.Checked Then
         lblMode.Text = 1
      End If
   End Sub

   Private Sub rbContains_CheckedChanged(sender As Object, e As EventArgs) Handles rbContains.CheckedChanged
      If rbContains.Checked Then
         lblMode.Text = 2
      End If
   End Sub

   Private Sub rbEnds_CheckedChanged(sender As Object, e As EventArgs) Handles rbEnds.CheckedChanged
      If rbEnds.Checked Then
         lblMode.Text = 3
      End If
   End Sub

   Private Sub lnklblSetDefault_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblSetDefault.LinkClicked
      If MsgBox("This will overwrite the default for all new Excel-Files. Proceed?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Set as Default") = MsgBoxResult.Yes Then
         bsRules.EndEdit()
         _Settings.DefaultLayerRules = LayerRules.GetRules()
      End If
   End Sub
End Class