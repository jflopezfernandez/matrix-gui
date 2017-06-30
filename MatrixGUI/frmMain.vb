
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
            Dim iteratorControl As Control

            Dim intIterator1 As Integer = 0 'i
            Dim intIterator2 As Integer = 0 'j
            Dim totalItems As Integer = 0

            MsgBox("Controls in group box: " & (gbMatrixViewer.Controls.Count))
            For Each iteratorControl In gbMatrixViewer.Controls

                ' Move the iterators up first
                If intIterator2 = currentMatrixWidth Then
                    If intIterator1 = currentMatrixHeight Then
                        MsgBox("Finished iterating through the matrix.")
                        MsgBox("Max Height: " & intIterator1)
                        MsgBox("Max Width: " & intIterator2)

                        Exit For
                    Else
                        intIterator1 = intIterator1 + 1
                        intIterator2 = 0

                    End If
                Else
                    intIterator2 = intIterator2 + 1

                End If

                ' Text-Set Logic
                If (intIterator1 + 1) = (intIterator2 + 1) Then
                    iteratorControl.Text = 1
                Else
                    iteratorControl.Text = 0
                End If

                totalItems = totalItems + 1
            Next
        End If

    End Sub

    Private Sub btnZeroMatrix_Click(sender As Object, e As EventArgs) Handles btnZeroMatrix.Click
        Dim responseConfirmZeroMatrix As MsgBoxResult = MsgBox("Are you sure you want to zero out the matrix? This cannot be undone.", vbYesNo, "Confirm Matrix Reset")

        If responseConfirmZeroMatrix = vbNo Then
            ' Nothing
        Else
            Dim iteratorControl As Control
            For Each iteratorControl In gbMatrixViewer.Controls
                iteratorControl.Text = "0"
            Next
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
            writeMatrixToOutputFile(newSaveFileDialog)
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
                    '.Text = i + 1 & "," & j + 1
                    .Text = i & j
                    '.Text = newMatrixCell.Name

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

    ' Starting the function over
    Private Sub writeMatrixToOutputFile(ByRef saveFileDialog As SaveFileDialog)

        UseWaitCursor = True

        Dim outputStreamWriter As New StreamWriter(saveFileDialog.FileName)

        ' Prep progress bar and label
        lblMatrixBuildStatus.Text = "Status: Writing matrix to file..."
        pbMatrixBuildProgress.Maximum = currentMatrixHeight * currentMatrixWidth
        pbMatrixBuildProgress.Value = 0

        Dim outputStringDimensions As String = "Matrix Dimensions: " & currentMatrixHeight & " x " & currentMatrixWidth
        outputStreamWriter.WriteLine(outputStringDimensions)
        outputStreamWriter.Flush()

        Dim count As Integer = 0

        Dim iterator1 As Integer = 0
        Dim iterator2 As Integer = 0

        Dim iteratorControl As Control

        Dim outputStringLine As String = ""
        For Each iteratorControl In gbMatrixViewer.Controls
            If iterator2 = currentMatrixWidth - 1 Then
                ' End of the row

                If iterator1 = currentMatrixHeight Then
                    ' Finished
                Else
                    iterator2 = 0
                    iterator1 = iterator1 + 1

                    outputStringLine = String.Concat(outputStringLine, iteratorControl.Text, " ")
                    count = count + 1

                End If

                outputStreamWriter.WriteLine(outputStringLine)
                outputStreamWriter.Flush()

                outputStringLine = ""
            Else
                iterator2 = iterator2 + 1

                outputStringLine = String.Concat(outputStringLine, iteratorControl.Text, " ")
                count = count + 1
            End If

            pbMatrixBuildProgress.Value = pbMatrixBuildProgress.Value + 1
        Next ' Control Container Iteration Loop

        outputStreamWriter.WriteLine(outputStringLine)
        outputStreamWriter.Flush()
        outputStreamWriter.Close()



        ' Finished, reset label and progress bar
        lblMatrixBuildStatus.Text = "Status: Ready"
        pbMatrixBuildProgress.Value = 0
        pbMatrixBuildProgress.Maximum = 100

        ' Let the user know the operation is complete
        MsgBox("Write Operation Successfully Completed.", vbOKOnly, "File Saved")
        MsgBox("Items written to file: " & count)

        UseWaitCursor = False
    End Sub

#End Region

End Class