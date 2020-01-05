<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt_serial = New System.Windows.Forms.TextBox()
        Me.txt_values = New System.Windows.Forms.TextBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_serial
        '
        Me.txt_serial.Location = New System.Drawing.Point(79, 35)
        Me.txt_serial.Name = "txt_serial"
        Me.txt_serial.Size = New System.Drawing.Size(100, 20)
        Me.txt_serial.TabIndex = 0
        '
        'txt_values
        '
        Me.txt_values.Location = New System.Drawing.Point(79, 103)
        Me.txt_values.Multiline = True
        Me.txt_values.Name = "txt_values"
        Me.txt_values.Size = New System.Drawing.Size(124, 67)
        Me.txt_values.TabIndex = 1
        Me.txt_values.Text = "efeAohDObmFTRx5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2YeDBKeOCeqVpHs" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3y5BHI3XGB0adEU" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RO5HpPd8y10960q"
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(104, 193)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(75, 23)
        Me.btn_save.TabIndex = 2
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.txt_values)
        Me.Controls.Add(Me.txt_serial)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_serial As System.Windows.Forms.TextBox
    Friend WithEvents txt_values As System.Windows.Forms.TextBox
    Friend WithEvents btn_save As System.Windows.Forms.Button

End Class
