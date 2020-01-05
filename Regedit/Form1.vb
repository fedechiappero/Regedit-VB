﻿Imports System.Management
Imports System
Imports Microsoft.Win32

Public Class Form1

    Dim serial

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'hhd serial = registry entry to be found
        Dim hhd As New ManagementObject("win32_physicalmedia='\\.\physicaldrive0'")
        serial = hhd.Properties("serialnumber").Value.ToString

        txt_serial.Text = serial

        Try
            If Registry.LocalMachine.OpenSubKey("SOFTWARE\OrgName\SoftName") Is Nothing Then ' registry key not found
                Dim msg = InputBox("Serial input...", "Provide a serial", Nothing)
                If msg.Trim = serial.Trim Then
                    Registry.LocalMachine.OpenSubKey("SOFTWARE", True).CreateSubKey("OrgName\SoftName")
                    Dim values() As String = {}
                    Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\OrgName\SoftName", serial.Trim, values, Microsoft.Win32.RegistryValueKind.MultiString)
                Else
                    MsgBox("Invalid serial")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            Dim values() As String = {}
            Dim i As Integer = 0
            For Each line As String In Me.txt_values.Lines
                If line <> "" Then
                    ReDim Preserve values(i)
                    values(i) = line.Trim
                    i += 1
                End If
            Next line

            If values.Length > 0 Then
                Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\OrgName\SoftName", serial.Trim, values, Microsoft.Win32.RegistryValueKind.MultiString)
            Else
                MsgBox("No values to save")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
