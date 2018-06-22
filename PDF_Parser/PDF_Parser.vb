Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports System.IO
Imports System.Drawing.Imaging

Module Parser

    Sub Main()
        'Creates a new PDF Document object.
        Console.WriteLine("Initiating file parse.")
        Dim parsedDoc As PdfDocument = New PdfDocument
        parsedDoc.Info.Title = "Parsed Document"

        'Adds a page for every image in the specified directory.
        Dim dirPath As String = "files\"
        For Each i As String In Directory.GetFiles(dirPath) 'Retrieves the files inside of the specififed path.
            If i.EndsWith(".jpg") Then

                'Create an image object and convert it to a Stream.
                Dim img As Image = Image.FromFile(i)
                Dim imgStream As Stream = toStream(img, img.RawFormat)

                'Convert the imgStream to an XImage.
                Dim ximg As XImage = getXImage(imgStream)

                'Draw the image on the PDF.
                Dim newPage As PdfPage = parsedDoc.AddPage
                newPage.Width = ximg.PixelWidth
                newPage.Height = ximg.PixelHeight
                Dim gfx As XGraphics = XGraphics.FromPdfPage(newPage) 'Creates a gfx object.
                Dim rect As XRect = New XRect(0, 0, ximg.PixelWidth, ximg.PixelHeight)
                gfx.DrawImage(ximg, rect)

            ElseIf i.EndsWith(".pdf") Or i.EndsWith(".PDF") Then
                'Create a fileStream from the specified file.
                Dim fs As FileStream = New FileStream(i, FileMode.Open)
                Dim imgStream As Stream = fs
                Dim form As XPdfForm = XPdfForm.FromStream(fs)
                Dim numpgs As Integer = form.PageCount
                For index As Integer = 1 To numpgs
                    form.PageNumber = index
                    'Draw the image on the PDF.
                    Dim newPage As PdfPage = parsedDoc.AddPage
                    newPage.Width = form.PixelWidth
                    newPage.Height = form.PixelHeight
                    Dim gfx As XGraphics = XGraphics.FromPdfPage(newPage) 'Creates a gfx object.
                    Dim rect As XRect = New XRect(0, 0, form.PixelWidth, form.PixelHeight)
                    gfx.DrawImage(form, rect)
                Next
            Else
                Console.WriteLine(i + "Has an invalid file format. I will ignore this file.")
            End If
        Next

        'Saves the created PDF document as a file and displays it.
        Dim filename As String = "Doc.pdf"
        parsedDoc.Save(filename)
        Process.Start(filename)
    End Sub

    Public Function getXImage(stream As Stream) As XImage 'Creates an XImage object from a Stream.
        Dim ximg As XImage = XImage.FromStream(stream)
        getXImage = ximg
    End Function

    Public Function toStream(image As Image, format As ImageFormat) As Stream 'Saves an image object to a Stream.
        Dim stream As MemoryStream = New MemoryStream()
        image.Save(stream, image.RawFormat)
        toStream = stream
    End Function

    Public Function getImageElements() 'Adds every image element from the SQL database to the images List.

        Return Nothing
    End Function

End Module

Public Class Parser_Window
    Private Sub Parser_Window_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ParseButton.Click
        Parser.Main()
    End Sub
End Class