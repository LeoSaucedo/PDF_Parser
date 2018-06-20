Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Module Parser

    Sub Main()
        'Creates a new PDF Document object.
        Console.WriteLine("Initiating file parse.")
        Dim parsedDoc As PdfDocument = New PdfDocument
        parsedDoc.Info.Title = "Parsed Document"

        'Adds a page for every image in the database.
        'TODO add SQL database and image conversion.
        Dim page As PdfPage = parsedDoc.AddPage

        'Saves the created PDF document as a file and displays it.
        Dim filename As String = "Doc.pdf"
        parsedDoc.Save(filename)
        Process.Start(filename)
    End Sub

End Module

Public Class Parser_Window
    Private Sub Parser_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ParseButton.Click
        Parser.Main()
    End Sub
End Class
