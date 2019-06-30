Imports System.Data
Imports System.Windows.Forms

Public Class frmWebbrowser

   Public Enum enumMode
      modeTable
      modeDiv
   End Enum

   Public Enum enumResult
      resStore
      resData
      resCancel
      resTimedout
   End Enum

   Private _Data As DataTable
   Private _Result As enumResult = enumResult.resCancel

   Private _currentData As DataTable = Nothing
   Private _currentDomLocation As String = ""
   Private _currentMode As enumMode = enumMode.modeTable
   Private _Settings As Settings

   Private _fw As frmWait = New frmWait

   Private WithEvents _timTick As Timer = New Timer
   Private WithEvents _timTimeout As Timer = New Timer
   Private _timeoutCounter As Integer = 0

   Public Property WebAddress As String = ""
   Public Property DomLocation As String = ""
   Public Property Mode As enumMode = enumMode.modeTable
   Public Property ShowUI As Boolean = True

   Public ReadOnly Property Data As DataTable
      Get
         Return _Data
      End Get
   End Property

   Public ReadOnly Property Result As enumResult
      Get
         Return _Result
      End Get
   End Property

   Public WriteOnly Property Settings As Settings
      Set(value As Settings)
         _Settings = value
      End Set
   End Property

#Region "Helpers"

   Private Sub TraverseTree(ByVal Parent As HtmlElement, ByVal PartentLocation As String, ByVal FindTagName As String, Node As TreeNode, ByRef lxi As XInfos)

      If Parent IsNot Nothing AndAlso Parent.CanHaveChildren Then

         For c As Integer = 0 To Parent.Children.Count - 1

            Dim che As HtmlElement = Parent.Children.Item(c)

            If FindTagName = "" Or FindTagName.ToUpper = che.TagName Then

               Dim newNode As TreeNode = New TreeNode(che.TagName)
               Dim xi As ExtractInfo = Nothing

               If che.Id <> "" Then

                  xi = New ExtractInfo(String.Format("{0}.{1}", PartentLocation, c), che.Id, che.TagName)
                  lxi.XInfos.Add(xi)

                  newNode.Tag = xi.Location
                  Node.Nodes.Add(newNode)

               Else

                  xi = New ExtractInfo(String.Format("{0}.{1}", PartentLocation, c), String.Format("{0} {1}", che.TagName, c + 1), che.TagName)
                  lxi.XInfos.Add(xi)

                  newNode.Tag = xi.Location
                  Node.Nodes.Add(newNode)

               End If

               TraverseTree(che, String.Format("{0}.{1}", PartentLocation, c), FindTagName, newNode, lxi)

            Else

               TraverseTree(che, String.Format("{0}.{1}", PartentLocation, c), FindTagName, Node, lxi)

            End If


         Next

      End If

   End Sub

   Private Function GetElementByLocation(ByVal Parent As HtmlElement, ByVal PartentLocation As String, ByVal LocationToFind As String) As HtmlElement

      Dim che As HtmlElement = Nothing

      If Parent IsNot Nothing AndAlso Parent.CanHaveChildren Then

         For c As Integer = 0 To Parent.Children.Count - 1

            che = Parent.Children.Item(c)
            If LocationToFind = String.Format("{0}.{1}", PartentLocation, c) Then
               Exit For
            Else
               che = GetElementByLocation(che, String.Format("{0}.{1}", PartentLocation, c), LocationToFind)
            End If

            If che IsNot Nothing Then
               Exit For
            End If

         Next

      End If

      Return che

   End Function

   Private Function GetColumnName(col As Integer) As String
      If col < 26 Then
         Return Chr(col + 65)
      Else
         Return Chr((col \ 26 - 1) + 65) + Chr(col Mod 26 + 65)
      End If
   End Function

   Private Function CreateAndFillTable(ByVal RootElement As HtmlElement) As DataTable

      Dim dt As DataTable = New DataTable("HTMLTable")
      Dim col As Integer = 1
      Dim dr As DataRow = Nothing

      If _currentMode = enumMode.modeTable Then

         For Each he As HtmlElement In RootElement.All
            If he.TagName = "TR" Then
               If dr IsNot Nothing Then
                  dt.Rows.Add(dr)
               End If
               dr = dt.NewRow
               col = 0
            ElseIf he.TagName = "TD" Then
               If dt.Columns.Count <= col Then
                  Dim dc As DataColumn = New DataColumn(GetColumnName(col), Type.GetType("System.String"))
                  dt.Columns.Add(dc)
               End If
               If dr Is Nothing Then
                  dr = dt.NewRow
               End If
               If he.InnerText IsNot Nothing Then
                  dr(col) = he.InnerText.Replace(vbLf, "").Replace(vbCr, "").Trim
               Else
                  dr(col) = ""
               End If
               col += 1
            End If
         Next

         If dt.Rows.Count > 1 Then
            If Not dr.Equals(dt.Rows(dt.Rows.Count - 1)) Then
               dt.Rows.Add(dr)
            End If
         End If


      ElseIf _currentMode = enumMode.modeDiv Then

         For Each he As HtmlElement In RootElement.Children

            If dr IsNot Nothing Then
               dt.Rows.Add(dr)
            End If
            dr = dt.NewRow
            col = 0

            If he.Children.Count > 0 Then

               For Each che As HtmlElement In he.Children

                  If che.InnerText IsNot Nothing AndAlso che.InnerText <> "" Then

                     If dt.Columns.Count <= col Then
                        Dim dc As DataColumn = New DataColumn(GetColumnName(col), Type.GetType("System.String"))
                        dt.Columns.Add(dc)
                     End If
                     If dr Is Nothing Then
                        dr = dt.NewRow
                     End If
                     If he.InnerText IsNot Nothing Then
                        dr(col) = che.InnerText.Replace(vbLf, "").Replace(vbCr, " ").Trim
                     Else
                        dr(col) = ""
                     End If
                     col += 1

                  End If

               Next

            End If

         Next

         If dt.Rows.Count > 1 Then
            If Not dr.Equals(dt.Rows(dt.Rows.Count - 1)) Then
               dt.Rows.Add(dr)
            End If
         End If

      End If

      Return dt

   End Function

   Private Function AddDummyToURL(Url As String) As String

      If Not Url.Contains("dummy") Then

         If Url.Contains("?") Then
            Url += "&dummy=" + Guid.NewGuid.ToString
         Else
            Url += "?dummy=" + Guid.NewGuid.ToString
         End If

      End If

      Return Url

   End Function

   Private Function GetTreeNodeByLocation(ByVal Node As TreeNode, ByVal LocationToFind As String) As TreeNode

      Dim childNode As TreeNode = Nothing

      If Node IsNot Nothing AndAlso Node.Nodes.Count > 0 Then

         For c As Integer = 0 To Node.Nodes.Count - 1

            childNode = Node.Nodes(c)
            If LocationToFind = childNode.Tag Then
               Exit For
            Else
               childNode = GetTreeNodeByLocation(childNode, LocationToFind)
            End If

            If childNode IsNot Nothing Then
               Exit For
            End If

         Next

      End If

      Return childNode

   End Function


#End Region

   Private Sub frmWebbrowser_Load(sender As Object, e As EventArgs) Handles Me.Load

      txtUrl.Text = WebAddress

      Select Case Mode
         Case enumMode.modeTable
            rbModeTable.Checked = True
         Case enumMode.modeDiv
            rbModeDiv.Checked = True
         Case Else
            rbModeTable.Checked = True
      End Select
      _currentMode = Mode
      _currentDomLocation = DomLocation

      webBrowser.ScriptErrorsSuppressed = True

      If _Settings IsNot Nothing Then

         Me.Location = _Settings.BrowserLocation
         Me.Size = _Settings.BrowserSize

         If ShowUI Then
            Me.WindowState = _Settings.BrowserWindowstate
         End If

      End If

      If Not ShowUI Then
         Me.Top = System.Windows.Forms.SystemInformation.VirtualScreen.Top - Me.Height - 20
      End If

      If Not ShowUI Or WebAddress <> "" Then

         _fw.Info = txtUrl.Text
         _fw.Show()
         _fw.TopMost = True

         webBrowser.Refresh(WebBrowserRefreshOption.Completely)
         webBrowser.AllowNavigation = True
         webBrowser.Navigate(AddDummyToURL(txtUrl.Text))

      End If

   End Sub

   Private Sub frmWebbrowser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

      _fw.Hide()

      If _Settings IsNot Nothing AndAlso ShowUI Then

         If Me.WindowState = FormWindowState.Normal Then

            _Settings.BrowserLocation = Me.Location
            _Settings.BrowserSize = Me.Size
            _Settings.BrowserWindowstate = Me.WindowState

         ElseIf Me.WindowState = FormWindowState.Maximized Then

            _Settings.BrowserWindowstate = Me.WindowState

         End If

      End If

   End Sub

   Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

      If txtUrl.Text <> "" Then

         _timTick.Stop()

         If WebAddress = txtUrl.Text Then

            trvTree.Enabled = False

         Else

            _currentDomLocation = ""

            trvTree.Enabled = True

         End If

         _fw.Info = txtUrl.Text
         _fw.Show()
         _fw.TopMost = True

         _timTimeout.Interval = 59000  '59s
         _timTimeout.Start()

         webBrowser.Refresh(WebBrowserRefreshOption.Completely)
         webBrowser.AllowNavigation = True
         webBrowser.Navigate(AddDummyToURL(txtUrl.Text))

      End If

   End Sub

   Private Sub webBrowser_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles webBrowser.DocumentCompleted

      _timTimeout.Stop()
      webBrowser.Stop()

      _timTick.Interval = 1000
      _timTick.Start()

   End Sub

   Private Sub txtUrl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUrl.KeyUp
      If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
         btnRefresh_Click(Me, System.EventArgs.Empty)
      End If
   End Sub

   Private Sub _timTick_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _timTick.Tick

      _timTick.Stop()
      _timTimeout.Stop()

      _fw.Info = txtUrl.Text
      _fw.Show()
      _fw.TopMost = True

      Dim doc As HtmlDocument = webBrowser.Document
      Dim he As HtmlElement = doc.Body

      If ShowUI Then
         'Select a new

         Dim xInfos As XInfos = New XInfos

         trvTree.Enabled = False
         trvTree.BeginUpdate()
         trvTree.Nodes.Clear()

         Dim node As TreeNode = New TreeNode("body")

         If _currentMode = enumMode.modeTable Then
            TraverseTree(he, "0", "Table", node, xInfos)
         Else
            TraverseTree(he, "0", "div", node, xInfos)
         End If

         trvTree.Nodes.Add(node)
         trvTree.EndUpdate()

         If xInfos.XInfos.Count > 0 Then

            If _currentDomLocation <> "" Then

               Dim node2Search As TreeNode = GetTreeNodeByLocation(node, _currentDomLocation)
               If node2Search IsNot Nothing Then

                  trvTree.SelectedNode = node2Search

                  he = GetElementByLocation(he, "0", _currentDomLocation)
                  If he IsNot Nothing Then

                     _currentData = CreateAndFillTable(he)
                     dgvTable.DataSource = _currentData

                  End If

               End If

            End If

            trvTree.Enabled = True

         End If

      ElseIf DomLocation <> "" Then

         'Update Data
         webBrowser.Stop()

         he = GetElementByLocation(he, "0", DomLocation)

         If he IsNot Nothing Then
            _Data = CreateAndFillTable(he)
            _Result = enumResult.resData
         End If

         Me.Close()

      End If

      _fw.Hide()
      _fw.TopMost = False

   End Sub

   Private Sub _timTimeout_Tick(sender As Object, e As EventArgs) Handles _timTimeout.Tick

      webBrowser.Stop()
      _timTimeout.Stop()

      If _timeoutCounter < 3 Then

         _timeoutCounter += 1

         _fw.Info = txtUrl.Text
         _fw.Show()
         _fw.TopMost = True

         _timTimeout.Interval = 59000  '59s
         _timTimeout.Start()

         webBrowser.Refresh(WebBrowserRefreshOption.Completely)
         webBrowser.AllowNavigation = True
         webBrowser.Navigate(AddDummyToURL(txtUrl.Text))

      Else

         _Result = enumResult.resTimedout
         Me.Close()

      End If

   End Sub


   Private Sub trvTree_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles trvTree.NodeMouseClick

      Dim node As TreeNode = e.Node
      If node IsNot Nothing Then

         Dim doc As HtmlDocument = webBrowser.Document
         Dim he As HtmlElement = doc.Body

         he = GetElementByLocation(he, "0", node.Tag)

         If he IsNot Nothing Then

            _currentDomLocation = node.Tag

            _currentData = CreateAndFillTable(he)
            dgvTable.DataSource = _currentData

         End If

      End If

   End Sub

   Private Sub btnStore_Click(sender As Object, e As EventArgs) Handles btnStore.Click

      WebAddress = txtUrl.Text
      DomLocation = _currentDomLocation

      Mode = _currentMode
      _Data = _currentData

      _Result = enumResult.resStore
      Me.DialogResult = DialogResult.OK
      Me.Close()

   End Sub

   Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
      _Result = enumResult.resCancel
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub rbModeTable_CheckedChanged(sender As Object, e As EventArgs) Handles rbModeTable.CheckedChanged
      If rbModeTable.Checked Then
         _currentMode = enumMode.modeTable
      End If
   End Sub

   Private Sub rbModeDiv_CheckedChanged(sender As Object, e As EventArgs) Handles rbModeDiv.CheckedChanged
      If rbModeDiv.Checked Then
         _currentMode = enumMode.modeDiv
      End If
   End Sub

End Class