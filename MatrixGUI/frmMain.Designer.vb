<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.gbMatrixSettings = New System.Windows.Forms.GroupBox()
        Me.btnUpdateView = New System.Windows.Forms.Button()
        Me.numCols = New System.Windows.Forms.NumericUpDown()
        Me.numRows = New System.Windows.Forms.NumericUpDown()
        Me.lblCols = New System.Windows.Forms.Label()
        Me.lblRows = New System.Windows.Forms.Label()
        Me.gbMatrixViewer = New System.Windows.Forms.GroupBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.gbMatrixCalculations = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblMemoryAllocated = New System.Windows.Forms.Label()
        Me.btnForceGC = New System.Windows.Forms.Button()
        Me.gbMemory = New System.Windows.Forms.GroupBox()
        Me.lblMatrixBuildStatus = New System.Windows.Forms.Label()
        Me.pbMatrixBuildProgress = New System.Windows.Forms.ProgressBar()
        Me.btnZeroMatrix = New System.Windows.Forms.Button()
        Me.btnIDMatrix = New System.Windows.Forms.Button()
        Me.lblOutputFileStatus = New System.Windows.Forms.Label()
        Me.gbOutputFileSettings = New System.Windows.Forms.GroupBox()
        Me.txtOutputFileDirectory = New System.Windows.Forms.TextBox()
        Me.txtOutputFileName = New System.Windows.Forms.TextBox()
        Me.tooltipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblOutputFilePath = New System.Windows.Forms.Label()
        Me.lblOutputFileName = New System.Windows.Forms.Label()
        Me.btnCreateFile = New System.Windows.Forms.Button()
        Me.btnSaveToFile = New System.Windows.Forms.Button()
        Me.gbMatrixSettings.SuspendLayout()
        CType(Me.numCols, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRows, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMatrixViewer.SuspendLayout()
        Me.gbMatrixCalculations.SuspendLayout()
        Me.gbMemory.SuspendLayout()
        Me.gbOutputFileSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbMatrixSettings
        '
        Me.gbMatrixSettings.Controls.Add(Me.btnIDMatrix)
        Me.gbMatrixSettings.Controls.Add(Me.btnZeroMatrix)
        Me.gbMatrixSettings.Controls.Add(Me.gbMemory)
        Me.gbMatrixSettings.Controls.Add(Me.btnUpdateView)
        Me.gbMatrixSettings.Controls.Add(Me.numCols)
        Me.gbMatrixSettings.Controls.Add(Me.numRows)
        Me.gbMatrixSettings.Controls.Add(Me.lblCols)
        Me.gbMatrixSettings.Controls.Add(Me.lblRows)
        Me.gbMatrixSettings.Location = New System.Drawing.Point(12, 12)
        Me.gbMatrixSettings.Name = "gbMatrixSettings"
        Me.gbMatrixSettings.Size = New System.Drawing.Size(367, 276)
        Me.gbMatrixSettings.TabIndex = 1
        Me.gbMatrixSettings.TabStop = False
        Me.gbMatrixSettings.Text = "Matrix Settings"
        '
        'btnUpdateView
        '
        Me.btnUpdateView.Location = New System.Drawing.Point(135, 17)
        Me.btnUpdateView.Name = "btnUpdateView"
        Me.btnUpdateView.Size = New System.Drawing.Size(107, 46)
        Me.btnUpdateView.TabIndex = 3
        Me.btnUpdateView.Text = "Update View"
        Me.btnUpdateView.UseVisualStyleBackColor = True
        '
        'numCols
        '
        Me.numCols.Location = New System.Drawing.Point(59, 43)
        Me.numCols.Maximum = New Decimal(New Integer() {45000, 0, 0, 0})
        Me.numCols.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numCols.Name = "numCols"
        Me.numCols.Size = New System.Drawing.Size(70, 20)
        Me.numCols.TabIndex = 3
        Me.tooltipMain.SetToolTip(Me.numCols, resources.GetString("numCols.ToolTip"))
        Me.numCols.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'numRows
        '
        Me.numRows.Location = New System.Drawing.Point(59, 17)
        Me.numRows.Maximum = New Decimal(New Integer() {45000, 0, 0, 0})
        Me.numRows.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numRows.Name = "numRows"
        Me.numRows.Size = New System.Drawing.Size(70, 20)
        Me.numRows.TabIndex = 2
        Me.tooltipMain.SetToolTip(Me.numRows, resources.GetString("numRows.ToolTip"))
        Me.numRows.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'lblCols
        '
        Me.lblCols.AutoSize = True
        Me.lblCols.Location = New System.Drawing.Point(6, 45)
        Me.lblCols.Name = "lblCols"
        Me.lblCols.Size = New System.Drawing.Size(47, 13)
        Me.lblCols.TabIndex = 1
        Me.lblCols.Text = "Columns"
        '
        'lblRows
        '
        Me.lblRows.AutoSize = True
        Me.lblRows.Location = New System.Drawing.Point(6, 19)
        Me.lblRows.Name = "lblRows"
        Me.lblRows.Size = New System.Drawing.Size(34, 13)
        Me.lblRows.TabIndex = 0
        Me.lblRows.Text = "Rows"
        '
        'gbMatrixViewer
        '
        Me.gbMatrixViewer.Controls.Add(Me.TextBox7)
        Me.gbMatrixViewer.Controls.Add(Me.TextBox8)
        Me.gbMatrixViewer.Controls.Add(Me.TextBox9)
        Me.gbMatrixViewer.Controls.Add(Me.TextBox4)
        Me.gbMatrixViewer.Controls.Add(Me.TextBox5)
        Me.gbMatrixViewer.Controls.Add(Me.TextBox6)
        Me.gbMatrixViewer.Controls.Add(Me.TextBox3)
        Me.gbMatrixViewer.Controls.Add(Me.TextBox2)
        Me.gbMatrixViewer.Controls.Add(Me.TextBox1)
        Me.gbMatrixViewer.Location = New System.Drawing.Point(385, 12)
        Me.gbMatrixViewer.Name = "gbMatrixViewer"
        Me.gbMatrixViewer.Size = New System.Drawing.Size(1507, 1017)
        Me.gbMatrixViewer.TabIndex = 2
        Me.gbMatrixViewer.TabStop = False
        Me.gbMatrixViewer.Text = "Matrix Viewer"
        '
        'TextBox7
        '
        Me.TextBox7.AcceptsTab = True
        Me.TextBox7.Location = New System.Drawing.Point(62, 71)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox7.Size = New System.Drawing.Size(22, 20)
        Me.TextBox7.TabIndex = 8
        '
        'TextBox8
        '
        Me.TextBox8.AcceptsTab = True
        Me.TextBox8.Location = New System.Drawing.Point(34, 71)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox8.Size = New System.Drawing.Size(22, 20)
        Me.TextBox8.TabIndex = 7
        '
        'TextBox9
        '
        Me.TextBox9.AcceptsTab = True
        Me.TextBox9.Location = New System.Drawing.Point(6, 71)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox9.Size = New System.Drawing.Size(22, 20)
        Me.TextBox9.TabIndex = 6
        '
        'TextBox4
        '
        Me.TextBox4.AcceptsTab = True
        Me.TextBox4.Location = New System.Drawing.Point(62, 45)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox4.Size = New System.Drawing.Size(22, 20)
        Me.TextBox4.TabIndex = 5
        '
        'TextBox5
        '
        Me.TextBox5.AcceptsTab = True
        Me.TextBox5.Location = New System.Drawing.Point(34, 45)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox5.Size = New System.Drawing.Size(22, 20)
        Me.TextBox5.TabIndex = 4
        '
        'TextBox6
        '
        Me.TextBox6.AcceptsTab = True
        Me.TextBox6.Location = New System.Drawing.Point(6, 45)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox6.Size = New System.Drawing.Size(22, 20)
        Me.TextBox6.TabIndex = 3
        '
        'TextBox3
        '
        Me.TextBox3.AcceptsTab = True
        Me.TextBox3.Location = New System.Drawing.Point(62, 19)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox3.Size = New System.Drawing.Size(22, 20)
        Me.TextBox3.TabIndex = 2
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsTab = True
        Me.TextBox2.Location = New System.Drawing.Point(34, 19)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox2.Size = New System.Drawing.Size(22, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.AcceptsTab = True
        Me.TextBox1.Location = New System.Drawing.Point(6, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(22, 20)
        Me.TextBox1.TabIndex = 0
        '
        'gbMatrixCalculations
        '
        Me.gbMatrixCalculations.Controls.Add(Me.gbOutputFileSettings)
        Me.gbMatrixCalculations.Controls.Add(Me.lblOutputFileStatus)
        Me.gbMatrixCalculations.Location = New System.Drawing.Point(12, 294)
        Me.gbMatrixCalculations.Name = "gbMatrixCalculations"
        Me.gbMatrixCalculations.Size = New System.Drawing.Size(367, 338)
        Me.gbMatrixCalculations.TabIndex = 3
        Me.gbMatrixCalculations.TabStop = False
        Me.gbMatrixCalculations.Text = "Operations"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(12, 638)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(367, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblMemoryAllocated
        '
        Me.lblMemoryAllocated.AutoSize = True
        Me.lblMemoryAllocated.Location = New System.Drawing.Point(149, 27)
        Me.lblMemoryAllocated.Name = "lblMemoryAllocated"
        Me.lblMemoryAllocated.Size = New System.Drawing.Size(81, 13)
        Me.lblMemoryAllocated.TabIndex = 6
        Me.lblMemoryAllocated.Text = "Memory In Use:"
        '
        'btnForceGC
        '
        Me.btnForceGC.AutoSize = True
        Me.btnForceGC.Location = New System.Drawing.Point(6, 19)
        Me.btnForceGC.Name = "btnForceGC"
        Me.btnForceGC.Size = New System.Drawing.Size(137, 28)
        Me.btnForceGC.TabIndex = 7
        Me.btnForceGC.Text = "Force Garbage Collection"
        Me.btnForceGC.UseVisualStyleBackColor = True
        '
        'gbMemory
        '
        Me.gbMemory.Controls.Add(Me.lblMatrixBuildStatus)
        Me.gbMemory.Controls.Add(Me.pbMatrixBuildProgress)
        Me.gbMemory.Controls.Add(Me.lblMemoryAllocated)
        Me.gbMemory.Controls.Add(Me.btnForceGC)
        Me.gbMemory.Location = New System.Drawing.Point(6, 71)
        Me.gbMemory.Name = "gbMemory"
        Me.gbMemory.Size = New System.Drawing.Size(355, 199)
        Me.gbMemory.TabIndex = 8
        Me.gbMemory.TabStop = False
        Me.gbMemory.Text = "Memory"
        '
        'lblMatrixBuildStatus
        '
        Me.lblMatrixBuildStatus.AutoSize = True
        Me.lblMatrixBuildStatus.Location = New System.Drawing.Point(6, 155)
        Me.lblMatrixBuildStatus.Name = "lblMatrixBuildStatus"
        Me.lblMatrixBuildStatus.Size = New System.Drawing.Size(74, 13)
        Me.lblMatrixBuildStatus.TabIndex = 9
        Me.lblMatrixBuildStatus.Text = "Status: Ready"
        '
        'pbMatrixBuildProgress
        '
        Me.pbMatrixBuildProgress.Location = New System.Drawing.Point(3, 171)
        Me.pbMatrixBuildProgress.Name = "pbMatrixBuildProgress"
        Me.pbMatrixBuildProgress.Size = New System.Drawing.Size(346, 23)
        Me.pbMatrixBuildProgress.TabIndex = 8
        '
        'btnZeroMatrix
        '
        Me.btnZeroMatrix.ForeColor = System.Drawing.Color.Red
        Me.btnZeroMatrix.Location = New System.Drawing.Point(248, 17)
        Me.btnZeroMatrix.Name = "btnZeroMatrix"
        Me.btnZeroMatrix.Size = New System.Drawing.Size(107, 22)
        Me.btnZeroMatrix.TabIndex = 9
        Me.btnZeroMatrix.Text = "Zero Matrix"
        Me.btnZeroMatrix.UseVisualStyleBackColor = True
        '
        'btnIDMatrix
        '
        Me.btnIDMatrix.ForeColor = System.Drawing.Color.Red
        Me.btnIDMatrix.Location = New System.Drawing.Point(248, 41)
        Me.btnIDMatrix.Name = "btnIDMatrix"
        Me.btnIDMatrix.Size = New System.Drawing.Size(107, 22)
        Me.btnIDMatrix.TabIndex = 10
        Me.btnIDMatrix.Text = "ID Matrix"
        Me.btnIDMatrix.UseVisualStyleBackColor = True
        '
        'lblOutputFileStatus
        '
        Me.lblOutputFileStatus.AutoSize = True
        Me.lblOutputFileStatus.Location = New System.Drawing.Point(6, 16)
        Me.lblOutputFileStatus.Name = "lblOutputFileStatus"
        Me.lblOutputFileStatus.Size = New System.Drawing.Size(176, 13)
        Me.lblOutputFileStatus.TabIndex = 0
        Me.lblOutputFileStatus.Text = "Status: [No Output File Created Yet]"
        '
        'gbOutputFileSettings
        '
        Me.gbOutputFileSettings.Controls.Add(Me.btnSaveToFile)
        Me.gbOutputFileSettings.Controls.Add(Me.btnCreateFile)
        Me.gbOutputFileSettings.Controls.Add(Me.lblOutputFileName)
        Me.gbOutputFileSettings.Controls.Add(Me.lblOutputFilePath)
        Me.gbOutputFileSettings.Controls.Add(Me.txtOutputFileName)
        Me.gbOutputFileSettings.Controls.Add(Me.txtOutputFileDirectory)
        Me.gbOutputFileSettings.Location = New System.Drawing.Point(6, 32)
        Me.gbOutputFileSettings.Name = "gbOutputFileSettings"
        Me.gbOutputFileSettings.Size = New System.Drawing.Size(355, 141)
        Me.gbOutputFileSettings.TabIndex = 1
        Me.gbOutputFileSettings.TabStop = False
        Me.gbOutputFileSettings.Text = "Output File Settings"
        '
        'txtOutputFileDirectory
        '
        Me.txtOutputFileDirectory.Location = New System.Drawing.Point(129, 19)
        Me.txtOutputFileDirectory.Name = "txtOutputFileDirectory"
        Me.txtOutputFileDirectory.Size = New System.Drawing.Size(220, 20)
        Me.txtOutputFileDirectory.TabIndex = 0
        '
        'txtOutputFileName
        '
        Me.txtOutputFileName.Location = New System.Drawing.Point(129, 45)
        Me.txtOutputFileName.Name = "txtOutputFileName"
        Me.txtOutputFileName.Size = New System.Drawing.Size(220, 20)
        Me.txtOutputFileName.TabIndex = 1
        Me.tooltipMain.SetToolTip(Me.txtOutputFileName, "You do not have to add an extension to this file. The" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "program will automatically" &
        " append a .matrix extension" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to indicate that this file adheres to the defacto s" &
        "tandard" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "we have created.")
        '
        'tooltipMain
        '
        Me.tooltipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.tooltipMain.ToolTipTitle = "Information"
        '
        'lblOutputFilePath
        '
        Me.lblOutputFilePath.AutoSize = True
        Me.lblOutputFilePath.ForeColor = System.Drawing.Color.Red
        Me.lblOutputFilePath.Location = New System.Drawing.Point(8, 22)
        Me.lblOutputFilePath.Name = "lblOutputFilePath"
        Me.lblOutputFilePath.Size = New System.Drawing.Size(86, 13)
        Me.lblOutputFilePath.TabIndex = 2
        Me.lblOutputFilePath.Text = "Output File Path:"
        '
        'lblOutputFileName
        '
        Me.lblOutputFileName.AutoSize = True
        Me.lblOutputFileName.ForeColor = System.Drawing.Color.Red
        Me.lblOutputFileName.Location = New System.Drawing.Point(8, 48)
        Me.lblOutputFileName.Name = "lblOutputFileName"
        Me.lblOutputFileName.Size = New System.Drawing.Size(92, 13)
        Me.lblOutputFileName.TabIndex = 3
        Me.lblOutputFileName.Text = "Output File Name:"
        '
        'btnCreateFile
        '
        Me.btnCreateFile.ForeColor = System.Drawing.Color.Red
        Me.btnCreateFile.Location = New System.Drawing.Point(129, 71)
        Me.btnCreateFile.Name = "btnCreateFile"
        Me.btnCreateFile.Size = New System.Drawing.Size(220, 23)
        Me.btnCreateFile.TabIndex = 4
        Me.btnCreateFile.Text = "Create File"
        Me.btnCreateFile.UseVisualStyleBackColor = True
        '
        'btnSaveToFile
        '
        Me.btnSaveToFile.ForeColor = System.Drawing.Color.Red
        Me.btnSaveToFile.Location = New System.Drawing.Point(129, 100)
        Me.btnSaveToFile.Name = "btnSaveToFile"
        Me.btnSaveToFile.Size = New System.Drawing.Size(220, 23)
        Me.btnSaveToFile.TabIndex = 5
        Me.btnSaveToFile.Text = "Save To File"
        Me.btnSaveToFile.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.gbMatrixCalculations)
        Me.Controls.Add(Me.gbMatrixViewer)
        Me.Controls.Add(Me.gbMatrixSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMain"
        Me.Text = "Matrix Builder"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbMatrixSettings.ResumeLayout(False)
        Me.gbMatrixSettings.PerformLayout()
        CType(Me.numCols, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRows, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMatrixViewer.ResumeLayout(False)
        Me.gbMatrixViewer.PerformLayout()
        Me.gbMatrixCalculations.ResumeLayout(False)
        Me.gbMatrixCalculations.PerformLayout()
        Me.gbMemory.ResumeLayout(False)
        Me.gbMemory.PerformLayout()
        Me.gbOutputFileSettings.ResumeLayout(False)
        Me.gbOutputFileSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbMatrixSettings As GroupBox
    Friend WithEvents btnUpdateView As Button
    Friend WithEvents numCols As NumericUpDown
    Friend WithEvents numRows As NumericUpDown
    Friend WithEvents lblCols As Label
    Friend WithEvents lblRows As Label
    Friend WithEvents gbMatrixViewer As GroupBox
    Friend WithEvents gbMatrixCalculations As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lblMemoryAllocated As Label
    Friend WithEvents btnIDMatrix As Button
    Friend WithEvents btnZeroMatrix As Button
    Friend WithEvents gbMemory As GroupBox
    Friend WithEvents lblMatrixBuildStatus As Label
    Friend WithEvents pbMatrixBuildProgress As ProgressBar
    Friend WithEvents btnForceGC As Button
    Friend WithEvents gbOutputFileSettings As GroupBox
    Friend WithEvents lblOutputFileName As Label
    Friend WithEvents lblOutputFilePath As Label
    Friend WithEvents txtOutputFileName As TextBox
    Friend WithEvents txtOutputFileDirectory As TextBox
    Friend WithEvents lblOutputFileStatus As Label
    Friend WithEvents tooltipMain As ToolTip
    Friend WithEvents btnSaveToFile As Button
    Friend WithEvents btnCreateFile As Button
End Class
