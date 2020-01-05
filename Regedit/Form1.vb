Imports System.Management
Imports System
Imports Microsoft.Win32

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'hhd serial = registry entry to be found
        Dim hhd As New ManagementObject("win32_physicalmedia='\\.\physicaldrive0'")
        Dim serial = hhd.Properties("serialnumber").Value.ToString

        txt_serial.Text = serial

        Try
            If Registry.LocalMachine.OpenSubKey("SOFTWARE\OrgName\SoftName") Is Nothing Then ' registry key not found
                Dim msg = InputBox("Serial input...", "Provide a serial", Nothing)
                If msg.Trim = serial.Trim Then
                    Registry.LocalMachine.OpenSubKey("SOFTWARE", True).CreateSubKey("OrgName\SoftName")
                    Dim valores() As String = {}
                    Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\OrgName\SoftName", serial.Trim, valores, Microsoft.Win32.RegistryValueKind.MultiString)
                Else
                    MsgBox("Invalid serial")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class
