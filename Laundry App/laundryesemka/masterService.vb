Public Class masterService
    Dim ids
    Dim edit As Boolean = False
    Sub load()
        DataGridView1.DataSource = getdata($"SELECT TOP (1000) [Id]
      ,[Name]
      ,[IdKategori]
      ,[IdUnit]
      ,[PriceUnit]
      ,[EstimationDuration]
  FROM [DBMeja_02].[dbo].[Service] WHERE Name LIKE '%{TextBox1.Text}%'")

        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False

        TextBox2.Select()

        GroupBox2.Enabled = False
        clearForm(GroupBox2)

        ComboBox1.DataSource = getdata("SELECT TOP (1000) [Id]
      ,[Name]
  FROM [DBMeja_02].[dbo].[Category]")
        ComboBox1.DisplayMember = "Name"
        ComboBox1.ValueMember = "Id"

        ComboBox2.DataSource = getdata("SELECT TOP (1000) [Id]
      ,[Name]
  FROM [DBMeja_02].[dbo].[Unit]")
        ComboBox2.DisplayMember = "Name"
        ComboBox2.ValueMember = "Id"
    End Sub
    Private Sub ToolStripLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripLabel7.Click
        mainForm.Show()
        Me.Hide()

    End Sub

    Private Sub ToolStripLabel1_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        masterEmployee.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel2_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        MsgBox("Anda sudah disini")
    End Sub

    Private Sub ToolStripLabel3_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        masterPackage.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel4_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel4.Click
        trasnDeposit.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel5_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel5.Click
        prepaidPackage.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel6_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel6.Click
        viewTransaction.Show()
        Me.Hide()
    End Sub

    Private Sub masterService_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub masterService_FormClosed(sender As Object, e As FormClosedEventArgs)
        mainForm.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        load()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox2.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True

        edit = False



    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            ids = DataGridView1.Item(0, e.RowIndex).Value
            TextBox2.Text = DataGridView1.Item("Name", e.RowIndex).Value
            ComboBox1.SelectedValue = DataGridView1.Item("IdKategori", e.RowIndex).Value
            ComboBox1.SelectedValue = DataGridView1.Item("IdUnit", e.RowIndex).Value
            TextBox10.Text = DataGridView1.Item("PriceUnit", e.RowIndex).Value
            TextBox11.Text = DataGridView1.Item("EstimationDuration", e.RowIndex).Value


            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True

            GroupBox2.Enabled = True
            edit = True
        End If
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit = True
        Button2.Enabled = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If edit Then
            If exc($"UPDATE [dbo].[Service]
   SET [Name] = '{TextBox2.Text}'
      ,[IdKategori] = '{ComboBox1.SelectedValue}'
      ,[IdUnit] = '{ComboBox2.SelectedValue}'
      ,[PriceUnit] = '{TextBox10.Text}'
      ,[EstimationDuration] = '{TextBox11.Text}'
 WHERE Id = '{ids}'") Then
                MsgBox(edited)
                load()

            End If
        Else
            If adakosong(GroupBox2) Then
                MsgBox(kosong)
            Else
                If exc($"INSERT INTO [dbo].[Service]
           ([Name]
           ,[IdKategori]
           ,[IdUnit]
           ,[PriceUnit]
           ,[EstimationDuration])
     VALUES
           ('{TextBox2.Text}'
           ,'{ComboBox1.SelectedValue}'
           ,'{ComboBox2.SelectedValue}'
           ,'{TextBox10.Text}'
           ,'{TextBox11.Text}')") Then

                    MsgBox(added)
                    load()


                End If
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.SelectedCells.Count > 0 Then
            If dialog(confirmation) Then
                If exc($"DELETE FROM [dbo].[Service]
      WHERE Id='{ids}'") Then
                    MsgBox(deleted)
                    load()

                End If
            End If
        End If
    End Sub

    Private Sub masterService_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        load()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        clearForm(GroupBox2)
        load()

    End Sub
End Class