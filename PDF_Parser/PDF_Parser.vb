Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports System.IO
Imports System.Windows
Imports System.Data.SqlClient

Module Parser

    Sub Main()
        'Creates a new PDF Document object.
        Console.WriteLine("Initiating file parse.")
        Dim parsedDoc As PdfDocument = New PdfDocument
        parsedDoc.Info.Title = "Parsed Document"

        'Adds a page for every image in the specified directory.
        'As an example, a JPG and a PDF are included in the files/ directory.
        'TODO add a way to convert binary data to a file.
        Dim dirPath As String = "files\"
        For Each i As String In Directory.GetFiles(dirPath) 'Retrieves the files inside of the specififed path.
            Dim newPage As PdfPage = parsedDoc.AddPage
            Dim gfx As XGraphics = XGraphics.FromPdfPage(newPage) 'Creates a gfx object.
            Dim image As XImage = XImage.FromFile(i)
            Dim imgPoint As New Point(0, 0)
            gfx.DrawImage(image, imgPoint)
        Next
        'Saves the created PDF document as a file and displays it.
        Dim filename As String = "Doc.pdf"
        parsedDoc.Save(filename)
        Process.Start(filename)
    End Sub

End Module

Public Class Parser_Window
    Inherits System.Windows.Forms.Form
    'Create ADO.NET objects.
    Private Conn As SqlConnection
    Private Cmd As SqlCommand
    Private Reader As SqlDataReader
    Private results As String

    Private Sub Parser_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Create a Connection object.
        Conn = New SqlConnection() 'Insert connection details here.
        'Create a Command object.
        Cmd = Conn.CreateCommand
        Cmd.CommandText = "SELECT varbinary from FILES" 'Default/sample database columbn with binary files.

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ParseButton.Click
        Parser.Main()
    End Sub
End Class