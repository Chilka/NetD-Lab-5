' Developer: Chilka Patel
' Date: July 26, 2019
' Description: This program  will be creating a Windows Forms application that will need to be able to open, close, 
'              edit, save, save As, And create New files (.txt).
'             -The application will alsobe able to copy, cut, and paste text.    
'             -The solution will also allow the user to Exit the program.  

Option Strict On
Imports System.IO       ' importing system Input output library

Public Class frmTextEditor

    Dim savePath As String

    ''' <summary>
    '''it goes to save dialog and gets the file to save as .txt extension
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveAsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem1.Click

        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtText.Text, False)
        End If

    End Sub

    ''' <summary>
    ''' opens a .txt file from the Most Recentaly Used List or from the path selected by user
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub OpenAsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OpenAsToolStripMenuItem1.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim reader As New StreamReader(OpenFileDialog1.FileName)
                txtText.Text = reader.ReadToEnd
                reader.Close()
            Catch ex As Exception
                Throw New ApplicationException(ex.ToString)
            End Try
        End If

    End Sub

    ''' <summary>
    ''' closes the application
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub CloseToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    ''' <summary>
    ''' starts a new document
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem1.Click

        savePath = String.Empty
        txtText.Text = ""

    End Sub

    ''' <summary>
    ''' Saves the document as .txt file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click

        ' checks if the savePath variable is empty then it goes to save dialog and gets the file to save as .txt extension
        ' and if not empty then it will store .txt file to the specific path that user selects
        If savePath = "" Then
            SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtText.Text, False)
            End If
        Else
            My.Computer.FileSystem.WriteAllText(savePath, txtText.Text, False)
        End If
    End Sub

    ''' <summary>
    ''' cuts the specific text that user selects
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub CutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CutToolStripMenuItem1.Click
        My.Computer.Clipboard.SetText(txtText.SelectedText)
        txtText.SelectedText = ""
    End Sub

    ''' <summary>
    ''' Copy selected text 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click

        If txtText.SelectionLength > 0 Then
            My.Computer.Clipboard.SetText(txtText.SelectedText)
        End If

    End Sub

    ''' <summary>
    ''' Paste the text that user cut or copied 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        txtText.Paste(My.Computer.Clipboard.GetText())
    End Sub
End Class
