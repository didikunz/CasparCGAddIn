<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucPlaybackButtons
   Inherits System.Windows.Forms.UserControl

   'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
   <System.Diagnostics.DebuggerNonUserCode()>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Wird vom Windows Form-Designer benötigt.
   Private components As System.ComponentModel.IContainer

   'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
   'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
   'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.btnLoad_LPSU = New System.Windows.Forms.Button()
      Me.btnUpdate_LPSU = New System.Windows.Forms.Button()
      Me.btnStop_LPSU = New System.Windows.Forms.Button()
      Me.btnPlay_LPSU = New System.Windows.Forms.Button()
      Me.tlpPlayStop = New System.Windows.Forms.TableLayoutPanel()
      Me.btnStop_PS = New System.Windows.Forms.Button()
      Me.btnPlay_PS = New System.Windows.Forms.Button()
      Me.tlpLoadPlayStop = New System.Windows.Forms.TableLayoutPanel()
      Me.btnStop_LPS = New System.Windows.Forms.Button()
      Me.btnPlay_LPS = New System.Windows.Forms.Button()
      Me.btnLoad_LPS = New System.Windows.Forms.Button()
      Me.tlpPlayNextStop = New System.Windows.Forms.TableLayoutPanel()
      Me.btnStop_PNS = New System.Windows.Forms.Button()
      Me.btnNext_PNS = New System.Windows.Forms.Button()
      Me.btnPlay_PNS = New System.Windows.Forms.Button()
      Me.tlpPlayStopUpdate = New System.Windows.Forms.TableLayoutPanel()
      Me.btnUpdate_PSU = New System.Windows.Forms.Button()
      Me.btnStop_PSU = New System.Windows.Forms.Button()
      Me.btnPlay_PSU = New System.Windows.Forms.Button()
      Me.tlpLoadPlayNextStop = New System.Windows.Forms.TableLayoutPanel()
      Me.btnStop_LPNS = New System.Windows.Forms.Button()
      Me.btnNext_LPNS = New System.Windows.Forms.Button()
      Me.btnLoad_LPNS = New System.Windows.Forms.Button()
      Me.btnPlay_LPNS = New System.Windows.Forms.Button()
      Me.tlpPlayNextStopUpdate = New System.Windows.Forms.TableLayoutPanel()
      Me.btnNext_PNSU = New System.Windows.Forms.Button()
      Me.btnPlay_PNSU = New System.Windows.Forms.Button()
      Me.btnUpdate_PNSU = New System.Windows.Forms.Button()
      Me.btnStop_PNSU = New System.Windows.Forms.Button()
      Me.tlpLoadPlayStopUpdate = New System.Windows.Forms.TableLayoutPanel()
      Me.tlpPlayStop.SuspendLayout()
      Me.tlpLoadPlayStop.SuspendLayout()
      Me.tlpPlayNextStop.SuspendLayout()
      Me.tlpPlayStopUpdate.SuspendLayout()
      Me.tlpLoadPlayNextStop.SuspendLayout()
      Me.tlpPlayNextStopUpdate.SuspendLayout()
      Me.tlpLoadPlayStopUpdate.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnLoad_LPSU
      '
      Me.btnLoad_LPSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnLoad_LPSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Load
      Me.btnLoad_LPSU.Location = New System.Drawing.Point(3, 3)
      Me.btnLoad_LPSU.Name = "btnLoad_LPSU"
      Me.btnLoad_LPSU.Size = New System.Drawing.Size(46, 47)
      Me.btnLoad_LPSU.TabIndex = 13
      Me.btnLoad_LPSU.UseVisualStyleBackColor = True
      '
      'btnUpdate_LPSU
      '
      Me.btnUpdate_LPSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnUpdate_LPSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Update
      Me.btnUpdate_LPSU.Location = New System.Drawing.Point(159, 3)
      Me.btnUpdate_LPSU.Name = "btnUpdate_LPSU"
      Me.btnUpdate_LPSU.Size = New System.Drawing.Size(47, 47)
      Me.btnUpdate_LPSU.TabIndex = 12
      Me.btnUpdate_LPSU.UseVisualStyleBackColor = True
      '
      'btnStop_LPSU
      '
      Me.btnStop_LPSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnStop_LPSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop_LPSU.Location = New System.Drawing.Point(107, 3)
      Me.btnStop_LPSU.Name = "btnStop_LPSU"
      Me.btnStop_LPSU.Size = New System.Drawing.Size(46, 47)
      Me.btnStop_LPSU.TabIndex = 11
      Me.btnStop_LPSU.UseVisualStyleBackColor = True
      '
      'btnPlay_LPSU
      '
      Me.btnPlay_LPSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnPlay_LPSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay_LPSU.Location = New System.Drawing.Point(55, 3)
      Me.btnPlay_LPSU.Name = "btnPlay_LPSU"
      Me.btnPlay_LPSU.Size = New System.Drawing.Size(46, 47)
      Me.btnPlay_LPSU.TabIndex = 9
      Me.btnPlay_LPSU.UseVisualStyleBackColor = True
      '
      'tlpPlayStop
      '
      Me.tlpPlayStop.ColumnCount = 2
      Me.tlpPlayStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.tlpPlayStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.tlpPlayStop.Controls.Add(Me.btnStop_PS, 0, 0)
      Me.tlpPlayStop.Controls.Add(Me.btnPlay_PS, 0, 0)
      Me.tlpPlayStop.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tlpPlayStop.Location = New System.Drawing.Point(0, 0)
      Me.tlpPlayStop.Name = "tlpPlayStop"
      Me.tlpPlayStop.RowCount = 1
      Me.tlpPlayStop.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tlpPlayStop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
      Me.tlpPlayStop.Size = New System.Drawing.Size(209, 53)
      Me.tlpPlayStop.TabIndex = 14
      '
      'btnStop_PS
      '
      Me.btnStop_PS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnStop_PS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop_PS.Location = New System.Drawing.Point(107, 3)
      Me.btnStop_PS.Name = "btnStop_PS"
      Me.btnStop_PS.Size = New System.Drawing.Size(99, 47)
      Me.btnStop_PS.TabIndex = 12
      Me.btnStop_PS.UseVisualStyleBackColor = True
      '
      'btnPlay_PS
      '
      Me.btnPlay_PS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnPlay_PS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay_PS.Location = New System.Drawing.Point(3, 3)
      Me.btnPlay_PS.Name = "btnPlay_PS"
      Me.btnPlay_PS.Size = New System.Drawing.Size(98, 47)
      Me.btnPlay_PS.TabIndex = 10
      Me.btnPlay_PS.UseVisualStyleBackColor = True
      '
      'tlpLoadPlayStop
      '
      Me.tlpLoadPlayStop.ColumnCount = 3
      Me.tlpLoadPlayStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpLoadPlayStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpLoadPlayStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpLoadPlayStop.Controls.Add(Me.btnStop_LPS, 0, 0)
      Me.tlpLoadPlayStop.Controls.Add(Me.btnPlay_LPS, 0, 0)
      Me.tlpLoadPlayStop.Controls.Add(Me.btnLoad_LPS, 0, 0)
      Me.tlpLoadPlayStop.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tlpLoadPlayStop.Location = New System.Drawing.Point(0, 0)
      Me.tlpLoadPlayStop.Name = "tlpLoadPlayStop"
      Me.tlpLoadPlayStop.RowCount = 1
      Me.tlpLoadPlayStop.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tlpLoadPlayStop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
      Me.tlpLoadPlayStop.Size = New System.Drawing.Size(209, 53)
      Me.tlpLoadPlayStop.TabIndex = 15
      '
      'btnStop_LPS
      '
      Me.btnStop_LPS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnStop_LPS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop_LPS.Location = New System.Drawing.Point(141, 3)
      Me.btnStop_LPS.Name = "btnStop_LPS"
      Me.btnStop_LPS.Size = New System.Drawing.Size(65, 47)
      Me.btnStop_LPS.TabIndex = 16
      Me.btnStop_LPS.UseVisualStyleBackColor = True
      '
      'btnPlay_LPS
      '
      Me.btnPlay_LPS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnPlay_LPS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay_LPS.Location = New System.Drawing.Point(72, 3)
      Me.btnPlay_LPS.Name = "btnPlay_LPS"
      Me.btnPlay_LPS.Size = New System.Drawing.Size(63, 47)
      Me.btnPlay_LPS.TabIndex = 15
      Me.btnPlay_LPS.UseVisualStyleBackColor = True
      '
      'btnLoad_LPS
      '
      Me.btnLoad_LPS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnLoad_LPS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Load
      Me.btnLoad_LPS.Location = New System.Drawing.Point(3, 3)
      Me.btnLoad_LPS.Name = "btnLoad_LPS"
      Me.btnLoad_LPS.Size = New System.Drawing.Size(63, 47)
      Me.btnLoad_LPS.TabIndex = 14
      Me.btnLoad_LPS.UseVisualStyleBackColor = True
      '
      'tlpPlayNextStop
      '
      Me.tlpPlayNextStop.ColumnCount = 3
      Me.tlpPlayNextStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpPlayNextStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpPlayNextStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpPlayNextStop.Controls.Add(Me.btnStop_PNS, 0, 0)
      Me.tlpPlayNextStop.Controls.Add(Me.btnNext_PNS, 0, 0)
      Me.tlpPlayNextStop.Controls.Add(Me.btnPlay_PNS, 0, 0)
      Me.tlpPlayNextStop.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tlpPlayNextStop.Location = New System.Drawing.Point(0, 0)
      Me.tlpPlayNextStop.Name = "tlpPlayNextStop"
      Me.tlpPlayNextStop.RowCount = 1
      Me.tlpPlayNextStop.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tlpPlayNextStop.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
      Me.tlpPlayNextStop.Size = New System.Drawing.Size(209, 53)
      Me.tlpPlayNextStop.TabIndex = 16
      '
      'btnStop_PNS
      '
      Me.btnStop_PNS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnStop_PNS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop_PNS.Location = New System.Drawing.Point(141, 3)
      Me.btnStop_PNS.Name = "btnStop_PNS"
      Me.btnStop_PNS.Size = New System.Drawing.Size(65, 47)
      Me.btnStop_PNS.TabIndex = 12
      Me.btnStop_PNS.UseVisualStyleBackColor = True
      '
      'btnNext_PNS
      '
      Me.btnNext_PNS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnNext_PNS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Next
      Me.btnNext_PNS.Location = New System.Drawing.Point(72, 3)
      Me.btnNext_PNS.Name = "btnNext_PNS"
      Me.btnNext_PNS.Size = New System.Drawing.Size(63, 47)
      Me.btnNext_PNS.TabIndex = 11
      Me.btnNext_PNS.UseVisualStyleBackColor = True
      '
      'btnPlay_PNS
      '
      Me.btnPlay_PNS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnPlay_PNS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay_PNS.Location = New System.Drawing.Point(3, 3)
      Me.btnPlay_PNS.Name = "btnPlay_PNS"
      Me.btnPlay_PNS.Size = New System.Drawing.Size(63, 47)
      Me.btnPlay_PNS.TabIndex = 10
      Me.btnPlay_PNS.UseVisualStyleBackColor = True
      '
      'tlpPlayStopUpdate
      '
      Me.tlpPlayStopUpdate.ColumnCount = 3
      Me.tlpPlayStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpPlayStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpPlayStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.tlpPlayStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.tlpPlayStopUpdate.Controls.Add(Me.btnUpdate_PSU, 0, 0)
      Me.tlpPlayStopUpdate.Controls.Add(Me.btnStop_PSU, 0, 0)
      Me.tlpPlayStopUpdate.Controls.Add(Me.btnPlay_PSU, 0, 0)
      Me.tlpPlayStopUpdate.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tlpPlayStopUpdate.Location = New System.Drawing.Point(0, 0)
      Me.tlpPlayStopUpdate.Name = "tlpPlayStopUpdate"
      Me.tlpPlayStopUpdate.RowCount = 1
      Me.tlpPlayStopUpdate.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tlpPlayStopUpdate.Size = New System.Drawing.Size(209, 53)
      Me.tlpPlayStopUpdate.TabIndex = 17
      '
      'btnUpdate_PSU
      '
      Me.btnUpdate_PSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnUpdate_PSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Update
      Me.btnUpdate_PSU.Location = New System.Drawing.Point(141, 3)
      Me.btnUpdate_PSU.Name = "btnUpdate_PSU"
      Me.btnUpdate_PSU.Size = New System.Drawing.Size(65, 47)
      Me.btnUpdate_PSU.TabIndex = 13
      Me.btnUpdate_PSU.UseVisualStyleBackColor = True
      '
      'btnStop_PSU
      '
      Me.btnStop_PSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnStop_PSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop_PSU.Location = New System.Drawing.Point(72, 3)
      Me.btnStop_PSU.Name = "btnStop_PSU"
      Me.btnStop_PSU.Size = New System.Drawing.Size(63, 47)
      Me.btnStop_PSU.TabIndex = 12
      Me.btnStop_PSU.UseVisualStyleBackColor = True
      '
      'btnPlay_PSU
      '
      Me.btnPlay_PSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnPlay_PSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay_PSU.Location = New System.Drawing.Point(3, 3)
      Me.btnPlay_PSU.Name = "btnPlay_PSU"
      Me.btnPlay_PSU.Size = New System.Drawing.Size(63, 47)
      Me.btnPlay_PSU.TabIndex = 10
      Me.btnPlay_PSU.UseVisualStyleBackColor = True
      '
      'tlpLoadPlayNextStop
      '
      Me.tlpLoadPlayNextStop.ColumnCount = 4
      Me.tlpLoadPlayNextStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpLoadPlayNextStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpLoadPlayNextStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpLoadPlayNextStop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpLoadPlayNextStop.Controls.Add(Me.btnStop_LPNS, 3, 0)
      Me.tlpLoadPlayNextStop.Controls.Add(Me.btnNext_LPNS, 0, 0)
      Me.tlpLoadPlayNextStop.Controls.Add(Me.btnLoad_LPNS, 0, 0)
      Me.tlpLoadPlayNextStop.Controls.Add(Me.btnPlay_LPNS, 0, 0)
      Me.tlpLoadPlayNextStop.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tlpLoadPlayNextStop.Location = New System.Drawing.Point(0, 0)
      Me.tlpLoadPlayNextStop.Name = "tlpLoadPlayNextStop"
      Me.tlpLoadPlayNextStop.RowCount = 1
      Me.tlpLoadPlayNextStop.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tlpLoadPlayNextStop.Size = New System.Drawing.Size(209, 53)
      Me.tlpLoadPlayNextStop.TabIndex = 18
      '
      'btnStop_LPNS
      '
      Me.btnStop_LPNS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnStop_LPNS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop_LPNS.Location = New System.Drawing.Point(159, 3)
      Me.btnStop_LPNS.Name = "btnStop_LPNS"
      Me.btnStop_LPNS.Size = New System.Drawing.Size(47, 47)
      Me.btnStop_LPNS.TabIndex = 17
      Me.btnStop_LPNS.UseVisualStyleBackColor = True
      '
      'btnNext_LPNS
      '
      Me.btnNext_LPNS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnNext_LPNS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Next
      Me.btnNext_LPNS.Location = New System.Drawing.Point(107, 3)
      Me.btnNext_LPNS.Name = "btnNext_LPNS"
      Me.btnNext_LPNS.Size = New System.Drawing.Size(46, 47)
      Me.btnNext_LPNS.TabIndex = 16
      Me.btnNext_LPNS.UseVisualStyleBackColor = True
      '
      'btnLoad_LPNS
      '
      Me.btnLoad_LPNS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnLoad_LPNS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Load
      Me.btnLoad_LPNS.Location = New System.Drawing.Point(3, 3)
      Me.btnLoad_LPNS.Name = "btnLoad_LPNS"
      Me.btnLoad_LPNS.Size = New System.Drawing.Size(46, 47)
      Me.btnLoad_LPNS.TabIndex = 14
      Me.btnLoad_LPNS.UseVisualStyleBackColor = True
      '
      'btnPlay_LPNS
      '
      Me.btnPlay_LPNS.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnPlay_LPNS.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay_LPNS.Location = New System.Drawing.Point(55, 3)
      Me.btnPlay_LPNS.Name = "btnPlay_LPNS"
      Me.btnPlay_LPNS.Size = New System.Drawing.Size(46, 47)
      Me.btnPlay_LPNS.TabIndex = 15
      Me.btnPlay_LPNS.UseVisualStyleBackColor = True
      '
      'tlpPlayNextStopUpdate
      '
      Me.tlpPlayNextStopUpdate.ColumnCount = 4
      Me.tlpPlayNextStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpPlayNextStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpPlayNextStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpPlayNextStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpPlayNextStopUpdate.Controls.Add(Me.btnNext_PNSU, 0, 0)
      Me.tlpPlayNextStopUpdate.Controls.Add(Me.btnPlay_PNSU, 0, 0)
      Me.tlpPlayNextStopUpdate.Controls.Add(Me.btnUpdate_PNSU, 3, 0)
      Me.tlpPlayNextStopUpdate.Controls.Add(Me.btnStop_PNSU, 2, 0)
      Me.tlpPlayNextStopUpdate.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tlpPlayNextStopUpdate.Location = New System.Drawing.Point(0, 0)
      Me.tlpPlayNextStopUpdate.Name = "tlpPlayNextStopUpdate"
      Me.tlpPlayNextStopUpdate.RowCount = 1
      Me.tlpPlayNextStopUpdate.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tlpPlayNextStopUpdate.Size = New System.Drawing.Size(209, 53)
      Me.tlpPlayNextStopUpdate.TabIndex = 19
      '
      'btnNext_PNSU
      '
      Me.btnNext_PNSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnNext_PNSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Next
      Me.btnNext_PNSU.Location = New System.Drawing.Point(55, 3)
      Me.btnNext_PNSU.Name = "btnNext_PNSU"
      Me.btnNext_PNSU.Size = New System.Drawing.Size(46, 47)
      Me.btnNext_PNSU.TabIndex = 11
      Me.btnNext_PNSU.UseVisualStyleBackColor = True
      '
      'btnPlay_PNSU
      '
      Me.btnPlay_PNSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnPlay_PNSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Play
      Me.btnPlay_PNSU.Location = New System.Drawing.Point(3, 3)
      Me.btnPlay_PNSU.Name = "btnPlay_PNSU"
      Me.btnPlay_PNSU.Size = New System.Drawing.Size(46, 47)
      Me.btnPlay_PNSU.TabIndex = 10
      Me.btnPlay_PNSU.UseVisualStyleBackColor = True
      '
      'btnUpdate_PNSU
      '
      Me.btnUpdate_PNSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnUpdate_PNSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Update
      Me.btnUpdate_PNSU.Location = New System.Drawing.Point(159, 3)
      Me.btnUpdate_PNSU.Name = "btnUpdate_PNSU"
      Me.btnUpdate_PNSU.Size = New System.Drawing.Size(47, 47)
      Me.btnUpdate_PNSU.TabIndex = 13
      Me.btnUpdate_PNSU.UseVisualStyleBackColor = True
      '
      'btnStop_PNSU
      '
      Me.btnStop_PNSU.Dock = System.Windows.Forms.DockStyle.Fill
      Me.btnStop_PNSU.Image = Global.CasparCGAddIn.My.Resources.Resources.Playback_Controls_Stop
      Me.btnStop_PNSU.Location = New System.Drawing.Point(107, 3)
      Me.btnStop_PNSU.Name = "btnStop_PNSU"
      Me.btnStop_PNSU.Size = New System.Drawing.Size(46, 47)
      Me.btnStop_PNSU.TabIndex = 12
      Me.btnStop_PNSU.UseVisualStyleBackColor = True
      '
      'tlpLoadPlayStopUpdate
      '
      Me.tlpLoadPlayStopUpdate.ColumnCount = 4
      Me.tlpLoadPlayStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpLoadPlayStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpLoadPlayStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpLoadPlayStopUpdate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.tlpLoadPlayStopUpdate.Controls.Add(Me.btnLoad_LPSU, 0, 0)
      Me.tlpLoadPlayStopUpdate.Controls.Add(Me.btnPlay_LPSU, 1, 0)
      Me.tlpLoadPlayStopUpdate.Controls.Add(Me.btnStop_LPSU, 2, 0)
      Me.tlpLoadPlayStopUpdate.Controls.Add(Me.btnUpdate_LPSU, 3, 0)
      Me.tlpLoadPlayStopUpdate.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tlpLoadPlayStopUpdate.Location = New System.Drawing.Point(0, 0)
      Me.tlpLoadPlayStopUpdate.Name = "tlpLoadPlayStopUpdate"
      Me.tlpLoadPlayStopUpdate.RowCount = 1
      Me.tlpLoadPlayStopUpdate.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.tlpLoadPlayStopUpdate.Size = New System.Drawing.Size(209, 53)
      Me.tlpLoadPlayStopUpdate.TabIndex = 20
      '
      'ucPlaybackButtons
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.Transparent
      Me.Controls.Add(Me.tlpLoadPlayStopUpdate)
      Me.Controls.Add(Me.tlpPlayNextStopUpdate)
      Me.Controls.Add(Me.tlpLoadPlayNextStop)
      Me.Controls.Add(Me.tlpPlayStopUpdate)
      Me.Controls.Add(Me.tlpPlayNextStop)
      Me.Controls.Add(Me.tlpLoadPlayStop)
      Me.Controls.Add(Me.tlpPlayStop)
      Me.Margin = New System.Windows.Forms.Padding(0)
      Me.Name = "ucPlaybackButtons"
      Me.Size = New System.Drawing.Size(209, 53)
      Me.tlpPlayStop.ResumeLayout(False)
      Me.tlpLoadPlayStop.ResumeLayout(False)
      Me.tlpPlayNextStop.ResumeLayout(False)
      Me.tlpPlayStopUpdate.ResumeLayout(False)
      Me.tlpLoadPlayNextStop.ResumeLayout(False)
      Me.tlpPlayNextStopUpdate.ResumeLayout(False)
      Me.tlpLoadPlayStopUpdate.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnLoad_LPSU As System.Windows.Forms.Button
   Friend WithEvents btnUpdate_LPSU As System.Windows.Forms.Button
   Friend WithEvents btnStop_LPSU As System.Windows.Forms.Button
   Friend WithEvents btnPlay_LPSU As System.Windows.Forms.Button
   Friend WithEvents tlpPlayStop As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents btnStop_PS As System.Windows.Forms.Button
   Friend WithEvents btnPlay_PS As System.Windows.Forms.Button
   Friend WithEvents tlpLoadPlayStop As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents btnStop_LPS As System.Windows.Forms.Button
   Friend WithEvents btnPlay_LPS As System.Windows.Forms.Button
   Friend WithEvents btnLoad_LPS As System.Windows.Forms.Button
   Friend WithEvents tlpPlayNextStop As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents btnStop_PNS As System.Windows.Forms.Button
   Friend WithEvents btnNext_PNS As System.Windows.Forms.Button
   Friend WithEvents btnPlay_PNS As System.Windows.Forms.Button
   Friend WithEvents tlpPlayStopUpdate As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents btnUpdate_PSU As System.Windows.Forms.Button
   Friend WithEvents btnStop_PSU As System.Windows.Forms.Button
   Friend WithEvents btnPlay_PSU As System.Windows.Forms.Button
   Friend WithEvents tlpLoadPlayNextStop As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents btnNext_LPNS As System.Windows.Forms.Button
   Friend WithEvents btnPlay_LPNS As System.Windows.Forms.Button
   Friend WithEvents btnLoad_LPNS As System.Windows.Forms.Button
   Friend WithEvents tlpPlayNextStopUpdate As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents tlpLoadPlayStopUpdate As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents btnStop_LPNS As System.Windows.Forms.Button
   Friend WithEvents btnNext_PNSU As System.Windows.Forms.Button
   Friend WithEvents btnPlay_PNSU As System.Windows.Forms.Button
   Friend WithEvents btnUpdate_PNSU As System.Windows.Forms.Button
   Friend WithEvents btnStop_PNSU As System.Windows.Forms.Button
End Class
