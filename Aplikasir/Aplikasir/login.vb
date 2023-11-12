Public Class login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql = $"SELECT [id]
      ,[username]
      ,[password]
      ,[role]
  FROM [dbo].[employee] WHERE username='{TextBox1.Text}' AND password = '{TextBox2.Text}'"

        If adakosong(GroupBox1) Then
            MsgBox(kosong)
        Else
            If TextBox3.Text <> Label5.Text Then
                MsgBox("Capctha salah")
                capctha()

            Else
                If getCount(sql) = 0 Then
                    MsgBox("Akun tak ditemukan")
                    MsgBox(getCount(sql))
                Else
                    Dim role = getValue(sql, "role")
                    userlogin = TextBox1.Text

                    If role = "kasir" Then
                        Form1.Show()
                        Me.Hide()
                    Else
                        admin.Show()
                        Me.Hide()

                    End If
                End If
            End If
        End If

    End Sub

    Sub capctha()
        Dim arr As String() = New String() {"Xhy67", "kl09y", "fff5gh6", "kloi87", "kkk9087", "hjahj654"}
        Dim rand = New Random()

        'MsgBox(arr(rand.Next(0, 6)))
        Label5.Text = arr(rand.Next(0, 6))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'capctha()

    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        capctha()

    End Sub
End Class