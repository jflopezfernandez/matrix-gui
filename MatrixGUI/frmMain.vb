
Option Explicit On

Imports System.IO
Imports System.Dynamic

Public Class frmMain

    Dim currentMatrixWidth As Decimal
    Dim currentMatrixHeight As Decimal


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        ' The program will never not prompt the user if they are sure they want to exit

        Dim responseConfirmExit As MsgBoxResult = MsgBox("Are you sure you want to exit?", vbYesNo, "Confirm Exit")

        If responseConfirmExit = vbYes Then
            End
        ElseIf responseConfirmExit = vbNo Then
            Exit Sub
        End If

    End Sub


    ' Generate Matrix
    Public Sub generateMatrix(ByVal rows As Decimal, ByVal columns As Decimal)

        ' Initialize Progress Bar
        lblMatrixBuildStatus.Text = "Status: Initializing..."

        With pbMatrixBuildProgress
            .Value = 0
            .Maximum = (rows + 1) * (columns + 1)
        End With


        ' Rebuild the matrix from scratch for correctness
        gbMatrixViewer.Controls.Clear()
        GC.Collect()
        updateStatusLabels()

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
                lblMatrixBuildStatus.Text = "Status: Building Cell (" & 1 + countCellsBuilt & ")"

                With newMatrixCell
                    .Name = "mc" & i

                    ' Just for debug to see which cells go where
                    'Text = i & "," & j

                    .Text = ""

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

    Private Sub btnUpdateView_Click(sender As Object, e As EventArgs) Handles btnUpdateView.Click

        ' Limit the creation of matrices to 50 by 50, anything beyond that is excessive and the GUI is useless

        If numRows.Value > 50 Or numCols.Value > 50 Then
            MsgBox("The row and column parameter maximum is 50 units.")
            Exit Sub
        Else

            ' Update the current matrix dimensions variables
            currentMatrixWidth = numRows.Value
            currentMatrixHeight = numCols.Value

            generateMatrix(numRows.Value, numCols.Value)
        End If

    End Sub

    Private Sub updateStatusLabels()

        ' Memory Allocated Label
        Dim memoryAllocatedKB = GC.GetTotalMemory(False) / 1000
        lblMemoryAllocated.Text = "Memory Allocated: " & Format(memoryAllocatedKB, "#,##0.##KB")

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Update Current Matrix Dimension Variables
        currentMatrixWidth = 3
        currentMatrixHeight = 3

        updateStatusLabels()
    End Sub

    Private Sub forceGarbageCollection()
        updateStatusLabels()

        GC.Collect(True)
        updateStatusLabels()

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
End Class
