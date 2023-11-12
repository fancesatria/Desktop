Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql = $"SELECT TOP (1000) [Id]
      ,[Name]
      ,[Password]
      ,[Email]
      ,[Address]
      ,[PhoneNumber]
      ,[IdJob]
      ,[DateOfBirth]
      ,[Salary]
  FROM [DBmeja_02].[dbo].[Employee] WHERE Email='{TextBox1.Text}' AND Password='{hash256(TextBox2.Text)}'"


        If adakosong(GroupBox1) Then
            MsgBox(kosong)
        Else
            If exc(sql) Then
                'MsgBox(sql)
                Dim role = getValue(sql, "idJob")
                username = getValue(sql, "Name")
                'MsgBox(username)
                'idlogin = getValue(sql, "Id")
                mainForm.Show()
                Me.Hide()
                'MsgBox(idlogin.GetType.ToString)
                'If role.Equals(1) Then
                '    mainForm.Show()
                '    Me.Hide()
                'Else
                '    laundressForm.Show()
                '    Me.Hide()

                'End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clearForm(GroupBox1)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()

    End Sub
End Class
