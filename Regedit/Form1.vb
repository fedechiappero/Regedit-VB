﻿Imports System.Management
Imports System
Imports Microsoft.Win32

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'check system architecture
        Dim baseKey
        If Environment.Is64BitOperatingSystem Then '64 bits system
            baseKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64)
        Else '32 bits system
            baseKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry32)
        End If
        'hhd serial = registry entry to be found
        Dim hhd As New ManagementObject("win32_physicalmedia='\\.\physicaldrive0'")
        Dim serial = hhd.Properties("serialnumber").Value.ToString
        Dim readValue As Object
        txt_serial.Text = serial

        ' read registry entry and check his value
        readValue = baseKey.OpenSubKey("SOFTWARE\Test")
        Try
            If readValue.GetValue(serial.Trim) Is Nothing Then
                MsgBox("doesn't exist")
            Else
                MsgBox("readed value: " + readValue.GetValue(serial.Trim))
                Me.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class
