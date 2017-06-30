
Option Explicit On

Imports System.IO
Imports System.Dynamic
Imports Microsoft.VisualBasic.FileIO

' MASTER BUG LIST
' RESOLVED_BUG: Memory-like error on exit
'   DIDN'T DO ANYTHING, IT JUST WENT AWAY. ?
'   UPDATE: The problem seems to be that I wasn't closing the streamwriter stream after
'           writing the output file


Public Class frmMain

#Region "PROGRAM_CONSTANTS_OPTIONS_GLOBALS_ETC"
    ' Constants
    Const maxDimension As Decimal = 40
    Const minDimension As Decimal = 2

    Const initialX As Decimal = 3
    Const initialY As Decimal = 3

    Dim currentMatrixWidth As Decimal
    Dim currentMatrixHeight As Decimal


    ' Options
    Public settingOutputFileDirectory As String

#End Region


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Update Current Matrix Dimension Variables
        currentMatrixWidth = initialX
        currentMatrixHeight = initialY

        updateStatusLabels()
    End Sub


#Region "BUTTON_HANDLERS"
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' The program will never not prompt the user if they are sure they want to exit

        Dim responseConfirmExit As MsgBoxResult = MsgBox("Are you sure you want to exit?", vbYesNo, "Confirm Exit")

        If responseConfirmExit = vbYes Then
            End
        ElseIf responseConfirmExit = vbNo Then
            Exit Sub
        End If

    End Sub

    Private Sub btnUpdateView_Click(sender As Object, e As EventArgs) Handles btnUpdateView.Click

        ' Limit the creation of matrices to 50 by 50, anything beyond that is excessive and the GUI is useless

        If numRows.Value > maxDimension Or numCols.Value > maxDimension Then
            MsgBox("The row and column parameter maximum is " & maxDimension & " units.")
            Exit Sub
        Else

            ' Update the current matrix dimensions variables
            currentMatrixWidth = numRows.Value
            currentMatrixHeight = numCols.Value

            generateMatrix(numRows.Value, numCols.Value)
        End If

    End Sub

    Private Sub btnIDMatrix_Click(sender As Object, e As EventArgs) Handles btnIDMatrix.Click

        ' An Identity Matrix can only be generated if it is a square matrix

        If currentMatrixWidth <> currentMatrixHeight Then
            MsgBox("Cannot create an identity matrix from a non-square matrix.", vbOKOnly, "Error - Matrix Dimensions Incompatible With Operation")
        Else
            MsgBox("[PRETEND THE MATRIX IS BEING MADE TO BE AN IDENTITY MATRIX]")
        End If

    End Sub

    Private Sub btnZeroMatrix_Click(sender As Object, e As EventArgs) Handles btnZeroMatrix.Click
        Dim responseConfirmZeroMatrix As MsgBoxResult = MsgBox("Are you sure you want to zero out the matrix? This cannot be undone.", vbYesNo, "Confirm Matrix Reset")

        If responseConfirmZeroMatrix = vbNo Then
            ' Nothing
        Else
            MsgBox("[PRETEND MATRIX IS BEING ZEROED OUT RIGHT NOW]")
        End If
    End Sub

    Private Sub btnCreateFile_Click(sender As Object, e As EventArgs)
        Dim newOpenFileDialog As New OpenFileDialog()

        With newOpenFileDialog
            .DefaultExt = ".matrix"
            .FileName = txtOutputFileName.Text

            If txtOutputFileDirectory.Text.Length = 0 Then
                txtOutputFileDirectory.Text.DefaultIfEmpty(Text("C:\Users\admin\Desktop\"))
            End If

            .InitialDirectory = txtOutputFileDirectory.Text

        End With

        newOpenFileDialog.ShowDialog()

    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim newSaveFileDialog As New SaveFileDialog

        With newSaveFileDialog

            If txtOutputFileDirectory.Text.Length = 0 Then
                .InitialDirectory = My.Computer.FileSystem.CurrentDirectory
            Else
                .InitialDirectory = txtOutputFileDirectory.Text
            End If

            .FileName = txtOutputFileName.Text
            .DefaultExt = ".matrix"
            .OverwritePrompt = True
            .Title = "Create Output File"
            .ValidateNames = False
            .SupportMultiDottedExtensions = True
            .RestoreDirectory = False
            .AddExtension = True
            .DereferenceLinks = True

        End With

        If newSaveFileDialog.ShowDialog() = DialogResult.OK Then
            writeMatrixToFile(newSaveFileDialog)
        End If

    End Sub

#End Region


#Region "CONTEXT_MENU"

    Private Sub SetMaxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetMaxToolStripMenuItem.Click

        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(tsmi.Owner, ContextMenuStrip)

        Dim currentControl As NumericUpDown = DirectCast(cms.SourceControl, NumericUpDown)
        currentControl.Value = maxDimension

    End Sub

    Private Sub SetMinToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetMinToolStripMenuItem.Click

        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(tsmi.Owner, ContextMenuStrip)

        Dim currentControl As NumericUpDown = DirectCast(cms.SourceControl, NumericUpDown)
        currentControl.Value = minDimension

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim localConst As Decimal = 3


        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(tsmi.Owner, ContextMenuStrip)

        Dim currentControl As NumericUpDown = DirectCast(cms.SourceControl, NumericUpDown)
        currentControl.Value = localConst

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim localConst As Decimal = 4

        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(tsmi.Owner, ContextMenuStrip)

        Dim currentControl As NumericUpDown = DirectCast(cms.SourceControl, NumericUpDown)
        currentControl.Value = localConst

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Dim localConst As Decimal = 5

        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(tsmi.Owner, ContextMenuStrip)

        Dim currentControl As NumericUpDown = DirectCast(cms.SourceControl, NumericUpDown)
        currentControl.Value = localConst

    End Sub

    ' TODO:     Fix this menu item
    ' NOTES:    Abstraction/indirection I couldn't figure out
    '           30-June-2017 (4:25AM) JFLF

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Dim localConst As Decimal = 10

        ' ATTEMPT 1
        'Dim tsmi As ToolStripDropDown = CType(sender, ToolStripDropDown)
        'Dim tsmp As ToolStripMenuItem = CType(tsmi.OwnerItem, ToolStripMenuItem)
        'Dim cms As ContextMenuStrip = CType(tsmp.Owner, ContextMenuStrip)

        'Dim currentControl As NumericUpDown = DirectCast(cms.SourceControl, NumericUpDown)
        'currentControl.Value = localConst

        'MsgBox(ToolStripMenuItem5.OwnerItem.Owner.Name)

        ' ATTEMPT 2
        'Dim ts1 As ToolStripDropDown = CType(sender, ToolStripDropDown)
        'Dim ts2 As ToolStripDropDownButton = CType(ts1., ToolStripDropDownButton)
        'Dim ts3 As ToolStripMenuItem = CType()
        'Dim cms As ContextMenuStrip = CType(ToolStripMenuItem5.OwnerItem.Owner, ContextMenuStrip)

        'Dim currentControl As NumericUpDown = DirectCast(cms.SourceControl, NumericUpDown)
        'currentControl.Value = localConst

        'MsgBox(ToolStripMenuItem5.OwnerItem.Owner.Name)
        ''MsgBox(ToolStripMenuItem5.OwnerItem.Owner.Parent.Name)

        'Dim tsmi As ToolStripDropDownButton = CType(sender, ToolStripDropDownButton)
        'Dim tsdm As ToolStripDropDownMenu = CType(tsmi.Owner, ToolStripDropDownMenu)
        'Dim csm As ContextMenuStrip = DirectCast(tsdm.Parent, ContextMenuStrip)

        'Dim currentControl As NumericUpDown = DirectCast(csm.Parent, NumericUpDown)
        'currentControl.Value = localConst
    End Sub



#End Region


#Region "UTILITY_FUNCTIONS"

    Private Sub updateStatusLabels()

        ' Memory Allocated Label
        Dim memoryAllocatedKB = GC.GetTotalMemory(False) / 1000
        lblMemoryAllocated.Text = "Memory Allocated: " & Format(memoryAllocatedKB, "#,##0.##KB")

    End Sub



    Private Sub forceGarbageCollection()
        updateStatusLabels()

        GC.Collect(True)
        updateStatusLabels()

    End Sub

#End Region


#Region "MATRIX_GENERATOR"

    ' Generate Matrix
    Public Sub generateMatrix(ByVal rows As Decimal, ByVal columns As Decimal)

        ' Initialize Progress Bar
        lblMatrixBuildStatus.Text = "Status: Initializing..."

        With pbMatrixBuildProgress
            .Value = 0
            .Maximum = (rows + 1) * (columns + 1)
        End With

        lblMatrixBuildStatus.Text = "Status: Performing Garbage Collection before starting build process..."

        ' Rebuild the matrix from scratch for correctness
        gbMatrixViewer.Controls.Clear()
        GC.Collect()
        updateStatusLabels()

        lblMatrixBuildStatus.Text = "Status: Building Matrix..."

        ' Position of first cell
        Const initialX As Decimal = 6
        Const initialY As Decimal = 19

        Const paddingX As Int32 = 3
        Const paddingY As Int32 = 3

        Const sizeX As Int32 = 22
        Const sizeY As Int32 = 20

        Dim countCellsBuilt As Decimal = 0

        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To columns - 1
                Dim newMatrixCell As New TextBox

                ' Update Label first then Progress Bar after cell is built


                With newMatrixCell
                    .Name = "mc" & i & j

                    ' Just for debug to see which cells go where
                    'Text = i & "," & j
                    .Text = "(" & i & "," & j & ")"

                    '.Text = ""


                    .Size = New Size(sizeX, sizeY)
                    .Location = New Point(initialX + (j * paddingX) + (j * sizeX), initialY + (i * paddingY) + (i * sizeY))

                    .AcceptsTab = True
                    .TabIndex = i

                End With

                gbMatrixViewer.Controls.Add(newMatrixCell)
                countCellsBuilt = countCellsBuilt + 1
                pbMatrixBuildProgress.Value = countCellsBuilt

            Next
        Next


        ' Reset Progress Bar and Label when finished
        lblMatrixBuildStatus.Text = "Status: Ready"

        With pbMatrixBuildProgress
            .Value = 0
            .Maximum = 100
        End With

        updateStatusLabels()

    End Sub

#End Region


#Region "FILE_IO_FUNCTIONS"

    Private Sub writeMatrixToFile(ByRef saveFileDialog As SaveFileDialog)
        Dim saveFileStream As FileStream = New FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)

        If saveFileStream IsNot Nothing Then
            ' Logic to output the Matrix to File
            Dim streamwriter As StreamWriter = New StreamWriter(saveFileStream)

            ' Set up the label and progress bar
            Dim counterCellsWritten As Integer = 0

            lblMatrixBuildStatus.Text = "Status: Writing matrix to file..."


            With pbMatrixBuildProgress
                .Value = 0
                .Maximum = currentMatrixWidth * currentMatrixWidth
            End With

            ' Write the file line by line
            Dim descriptionString As String = "Matrix Dimensions: " & currentMatrixHeight & " x " & currentMatrixWidth & vbCr & vbCr
            streamwriter.WriteLine(descriptionString)
            streamwriter.Flush()

            Dim lineOutputString As String = ""

            ' TODO: Refactor this. I have once again stooped extremely low
            ' 30-June-2017 (5:33AM) JFLF
            Dim total_cells_found As Integer = 0

            For i = 0 To currentMatrixHeight - 1
                ' Reset the output string before every line
                'lineOutputString = ""
i_loop:
                For j = 0 To currentMatrixWidth - 1
                    Dim currentCellName As String = "mc" & i & j

                    ' TODO: Refactor this. I can't believe I stooped this low. I am ashamed
                    '       30-June-2017 (5:28AM) JFLF
                    Dim cells_found_on_this_line As Integer = 0
j_loop:
                    ' Find the current cell by looking it up by name, iterating through each textbox in the container
                    Dim iteratorCell As Control
                    For Each iteratorCell In gbMatrixViewer.Controls

                        ' Correct cell has been found
                        If iteratorCell.Name = currentCellName Then
                            total_cells_found = total_cells_found + 1


                            lineOutputString = String.Concat(lineOutputString, iteratorCell.Text, " ")

                            ' Update the progress bar
                            If pbMatrixBuildProgress.Value = pbMatrixBuildProgress.Maximum Then
                                ' Do nothing - finished
                                GoTo finished
                            Else
                                pbMatrixBuildProgress.Value = pbMatrixBuildProgress.Value + 1
                                cells_found_on_this_line = cells_found_on_this_line + 1

                                If cells_found_on_this_line = currentMatrixWidth - 1 Then
                                    GoTo i_loop
                                Else
                                    GoTo j_loop
                                End If
                            End If

                        End If

                        streamwriter.WriteLine(lineOutputString)
                        streamwriter.Flush()
                    Next

                    streamwriter.WriteLine(vbCr)
                    streamwriter.Flush()

                Next

                MsgBox("Finished j-iteration" & vbCr & "i-iteration: " & i + 1)
            Next
finished:
            MsgBox("cells found: " & total_cells_found)


            streamwriter.Close()
            saveFileStream.Close()

            ' Finished, reset label and progress bar
            lblMatrixBuildStatus.Text = "Status: Ready"
            pbMatrixBuildProgress.Value = 0
            pbMatrixBuildProgress.Maximum = 100

            ' Let the user know the operation is complete
            MsgBox("Write Operation Successfully Completed.", vbOKOnly, "File Saved")

        End If

    End Sub

#End Region

End Class