Public Class frmWait

   Public WriteOnly Property Info As String
      Set(value As String)
         lblInfo.Text = value
      End Set
   End Property

End Class