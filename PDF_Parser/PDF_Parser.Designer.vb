<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Parser_Window
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ParseButton = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'ParseButton
        '
        Me.ParseButton.Location = New System.Drawing.Point(232, 80)
        Me.ParseButton.Name = "ParseButton"
        Me.ParseButton.Size = New System.Drawing.Size(75, 23)
        Me.ParseButton.TabIndex = 0
        Me.ParseButton.Text = "Parse Files"
        Me.ParseButton.UseVisualStyleBackColor = True
        '
        'Parser_Window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 115)
        Me.Controls.Add(Me.ParseButton)
        Me.Name = "Parser_Window"
        Me.Text = "PDF_Parser"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ParseButton As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
