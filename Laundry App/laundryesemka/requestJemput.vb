Public Class requestJemput
    Dim idj
    Private Sub requestJemput_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        mainForm.Show()
        Me.Hide()

    End Sub

    Sub load()
        DataGridView1.DataSource = getdata("SELECT TOP (1000) [Id]
      ,[IdCustomer]
      ,[IdService]
      ,[ReceiverName]
      ,[ReceiverAddress]
      ,[ReceiverPhone]
      ,[StatusRequest]
  FROM [DBmeja_02].[dbo].[Jemput]")
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            idj = DataGridView1.Item("IdJemput", e.RowIndex).Value
            TextBox2.Text = DataGridView1.Item("Name", e.RowIndex).Value
            TextBox5.Text = DataGridView1.Item("phoneNumber", e.RowIndex).Value
            TextBox6.Text = DataGridView1.Item("Address", e.RowIndex).Value
            'clearForm(GroupBox2)
            'clearForm(GroupBox3)


        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sql = $"UPDATE [dbo].[Jemput]
      ,[StatusRequest] = 'Diterima'
 WHERE IdJemput = '{idj}'"

        If exc(sql) Then
            MsgBox(edited)
            load()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql = $"UPDATE [dbo].[Jemput]
      ,[StatusRequest] = 'Selesai'
 WHERE IdJemput = '{idj}'"

        If exc(sql) Then
            MsgBox(edited)
            load()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sql = $""
        If exc(Sql) Then

        End If
    End Sub
End Class