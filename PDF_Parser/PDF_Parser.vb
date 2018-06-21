Imports PdfSharp.Drawing
Imports PdfSharp.Pdf
Imports System.IO
Imports System.Windows
Imports System.Data.SqlClient
Imports System.Windows.Media.Imaging
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
            Dim newPage As PdfPage = parsedDoc.AddPage
            Dim gfx As XGraphics = XGraphics.FromPdfPage(newPage) 'Creates a gfx object.
            Dim img As Image = Image.FromFile(i)
            Dim ximg As XImage = getXImage(img)
            Dim imgPoint As New Point(0, 0)
            gfx.DrawImage(ximg, imgPoint)
        Next
        'Saves the created PDF document as a file and displays it.
        Dim filename As String = "Doc.pdf"
        parsedDoc.Save(filename)
        Process.Start(filename)
    End Sub



    Public Function getXImage(image As Image) As XImage 'Creates an XImage object from an Image.
        Dim path As String = "files\"
        Dim bmpsrc As BitmapSource = Nothing
        'Convert the given image into a bitmap.
        Dim bitmap = New Bitmap(image)

        'Convert the bitmap into bitmapData.
        Dim bitmapData = bitmap.LockBits(New Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly,
                                         bitmap.PixelFormat)

        'Create a BitmapSource from the raw BitmapData.
        bmpsrc = BitmapSource.Create(bitmapData.Width, bitmapData.Height, bitmap.HorizontalResolution, bitmap.VerticalResolution,
                                     System.Windows.Media.PixelFormats.Bgr32, Nothing, bitmapData.Scan0, bitmapData.Stride * bitmapData.Height,
                                     bitmapData.Stride)


        'Create an XImage object from the BitmapSource object.
        Dim ximg As XImage = XImage.FromBitmapSource(bmpsrc)
        getXImage = ximg 'Returns the image file.
    End Function

End Module

Public Class Parser_Window
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
        Cmd.CommandText = "SELECT varbinary from FILES" 'Default/sample database column with binary files.

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ParseButton.Click
        Parser.Main()
    End Sub
End Class