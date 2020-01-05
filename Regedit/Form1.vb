Imports System.Management
Imports System
Imports Microsoft.Win32

Public Class Form1

    Dim serial

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' hhd serial = registry entry to be found
        Dim hhd As New ManagementObject("win32_physicalmedia='\\.\physicaldrive0'")
        serial = hhd.Properties("serialnumber").Value.ToString

        txt_serial.Text = serial.Trim

        Dim stayIn As Boolean = True
        Try

            If Registry.LocalMachine.OpenSubKey("SOFTWARE\OrgName\SoftName") Is Nothing Then ' registry key not found
                While stayIn ' until click cancel button OR serial input correct 
                    Dim msg = InputBox("Serial input...", "Provide a serial", " ")
                    If msg = "" Then ' cancel button
                        stayIn = False
                        Application.Exit()
                        End
                    ElseIf msg.Trim = serial.Trim Then ' serial input correct
                        Registry.LocalMachine.OpenSubKey("SOFTWARE", True).CreateSubKey("OrgName\SoftName")
                        Dim values() As String = {}
                        ' new value with serial as name, multiline for storage several values
                        Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\OrgName\SoftName", serial.Trim, values, Microsoft.Win32.RegistryValueKind.MultiString)
                        stayIn = False
                    Else
                        MsgBox("Invalid serial")
                    End If
                End While
            End If

            ' retrieve values from registry (if any)
            readValues()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            Dim values() As String = {}
            Dim i As Integer = 0
            For Each line As String In Me.txt_values.Lines
                If line.Trim <> "" Then ' avoiding enpty lines
                    ReDim Preserve values(i)
                    values(i) = line.Trim
                    i += 1
                End If
            Next line

            If values.Length > 0 Then
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\OrgName\SoftName", serial.Trim, values, Microsoft.Win32.RegistryValueKind.MultiString)
                MsgBox("New values saved")
            Else
                MsgBox("No values to save")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub readValues()
        Dim values() As String = {}
        ' check if key has values before read them
        If Registry.LocalMachine.OpenSubKey("SOFTWARE\OrgName\SoftName\").ValueCount > 0 Then
            values = Registry.LocalMachine.OpenSubKey("SOFTWARE\OrgName\SoftName\").GetValue(serial.Trim)
            For Each line As String In values
                Me.txt_values.Text += line & Environment.NewLine
            Next
        End If
    End Sub
End Class
