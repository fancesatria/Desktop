Public Class masterEmployee
    Dim edit As Boolean = False
    Dim ide
    Sub load()
        DataGridView1.DataSource = getdata($"SELECT TOP (1000) [Id]
      ,[Name]
      ,[Password]
      ,[Email]
      ,[Address]
      ,[PhoneNumber]
      ,[IdJob]
      ,[DateOfBirth]
      ,[Salary]
  FROM [DBmeja_02].[dbo].[Employee] WHERE Name LIKE '%{TextBox1.Text}%' OR Email LIKE '%{TextBox1.Text}%' OR phoneNumber LIKE '%{TextBox1.Text}%'")

        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False

        TextBox2.Select()

        GroupBox2.Enabled = False
        GroupBox3.Enabled = False



        ComboBox1.DataSource = getdata("SELECT TOP (1000) [Id]
      ,[Name]
  FROM [DBmeja_02].[dbo].[Job]")
        ComboBox1.DisplayMember = "Name"
        ComboBox1.ValueMember = "Id"
    End Sub



    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        MsgBox("Anda sudah disini")

    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        masterService.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        masterPackage.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel4_Click(sender As Object, e As EventArgs) Handles ToolStripLabel4.Click
        trasnDeposit.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel5_Click(sender As Object, e As EventArgs) Handles ToolStripLabel5.Click
        prepaidPackage.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel6_Click(sender As Object, e As EventArgs) Handles ToolStripLabel6.Click
        viewTransaction.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripLabel7.Click
        mainForm.Show()
        Me.Hide()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            ide = DataGridView1.Item(0, e.RowIndex).Value
            TextBox2.Text = DataGridView1.Item("Name", e.RowIndex).Value
            TextBox4.Text = DataGridView1.Item("Email", e.RowIndex).Value
            TextBox5.Text = DataGridView1.Item("phoneNumber", e.RowIndex).Value
            TextBox6.Text = DataGridView1.Item("Address", e.RowIndex).Value
            TextBox11.Text = DataGridView1.Item("salary", e.RowIndex).Value

            DateTimePicker1.Value = DataGridView1.Item("dateOfBirth", e.RowIndex).Value

            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True

            GroupBox2.Enabled = True
            GroupBox3.Enabled = True
            'clearForm(GroupBox2)
            'clearForm(GroupBox3)

            edit = True

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        load()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        clearForm(GroupBox2)
        clearForm(GroupBox3)
        load()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            If dialog(confirmation) Then
                If exc($"DELETE FROM [dbo].[employee]
      WHERE Id='{ide}'") Then
                    MsgBox(deleted)
                    load()
                    clearForm(GroupBox2)
                    clearForm(GroupBox3)
                End If
            End If
            End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox9.Text <> TextBox10.Text Then
            MsgBox("Password tak sama")
        Else
            If isEmail(TextBox4.Text) Then
                If edit Then
                    If exc($"UPDATE [dbo].[Employee]
   SET [Name] = '{TextBox2.Text}'
      ,[Password] = '{hash256(TextBox10.Text)}'
      ,[Email] = '{TextBox4.Text}'
      ,[Address] = '{TextBox6.Text}'
      ,[PhoneNumber] = '{TextBox5.Text}'
      ,[IdJob] ='{ComboBox1.SelectedValue}'
      ,[DateOfBirth] = '{getDateValue(DateTimePicker1)}'
      ,[Salary] = '{TextBox11.Text}'
 WHERE Id = '{ide}'") Then
                        MsgBox(edited)
                        load()

                        clearForm(GroupBox2)
                        clearForm(GroupBox3)
                    End If
                Else
                    If adakosong(GroupBox2) Or adakosong(GroupBox3) Then
                        MsgBox(kosong)
                    Else
                        If exc($"INSERT INTO [dbo].[employee]
           ([Name]
           ,[Password]
           ,[Email]
           ,[Address]
           ,[PhoneNumber]
           ,[IdJob]
           ,[DateOfBirth]
           ,[Salary])
     VALUES
           ('{TextBox2.Text}'
           ,'{hash256(TextBox10.Text)}'
           ,'{TextBox4.Text}'
           ,'{TextBox6.Text}'
           ,'{TextBox5.Text}'
           ,'{ComboBox1.SelectedValue}'
           ,'{getDateValue(DateTimePicker1)}'
           ,'{TextBox11.Text}')") Then

                            MsgBox(added)
                            load()
                            clearForm(GroupBox2)
                            clearForm(GroupBox3)

                        End If
                    End If
                End If

            Else
                MsgBox("Masukkan email yang valid")
            End If

        End If
    End Sub

    Private Sub masterEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit = True
        Button2.Enabled = False
    End Sub
End Class