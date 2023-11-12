Public Class addCustomer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cek = getCount($"SELECT TOP (1000) [Id]
      ,[Name]
      ,[PhoneNumber]
      ,[Address]
      ,[Password]
  FROM [DBmeja_02].[dbo].[Customer] WHERE PhoneNumber='{TextBox2.Text}'")
        If adakosong(GroupBox1) Then
            MsgBox(kosong)
        Else
            If cek.Equals(0) Then
                If exc($"INSERT INTO [dbo].[Customer]
           ([Name]
           ,[PhoneNumber]
           ,[Address])
     VALUES
           ('{TextBox1.Text}'
           ,'{TextBox2.Text}'
           ,'{TextBox3.Text}')") Then

                    MsgBox(added)
                End If
            Else
                MsgBox("Nomor telepon sudah ada, harap gunakan nomor lain")
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub addCustomer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        trasnDeposit.Show()
        Me.Hide()

    End Sub

    Private Sub addCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()

    End Sub
End Class