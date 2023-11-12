Public Class masterPackage
    Dim idp
    Dim edit As Boolean = False
    Sub load()
        DataGridView1.DataSource = getdata($"SELECT TOP (1000) [Id]
      ,[IdService]
      ,[TotalUnit]
      ,[Price]
  FROM [DBmeja_02].[dbo].[Package]")

        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False


        GroupBox2.Enabled = False

        ComboBox1.DataSource = getdata("SELECT TOP (1000) [Id]
      ,[Name]
      ,[IdKategori]
      ,[IdUnit]
      ,[PriceUnit]
      ,[EstimationDuration]
  FROM [DBmeja_02].[dbo].[Service]")
        ComboBox1.DisplayMember = "Name"
        ComboBox1.ValueMember = "Id"

        clearForm(GroupBox2)

    End Sub
    Private Sub ToolStripLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripLabel7.Click
        mainForm.Show()
        Me.Hide()

    End Sub

    Private Sub ToolStripLabel2_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        masterService.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel1_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        masterEmployee.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel3_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        MsgBox("Anda sudah disini")
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

    Private Sub masterPackage_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        mainForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox2.Enabled = True
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        Button5.Enabled = True
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            idp = DataGridView1.Item(0, e.RowIndex).Value
            ComboBox1.SelectedValue = DataGridView1.Item("IdService", e.RowIndex).Value
            TextBox10.Text = DataGridView1.Item("TotalUnit", e.RowIndex).Value
            TextBox11.Text = DataGridView1.Item("Price", e.RowIndex).Value

            GroupBox2.Enabled = True

            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True

            edit = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If edit Then
            If exc($"UPDATE [dbo].[Package]
   SET [IdService] = '{ComboBox1.SelectedValue}'
      ,[TotalUnit] = '{TextBox10.Text}'
      ,[Price] = '{TextBox11.Text}'
 WHERE Id ='{idp}'") Then
                MsgBox(edited)
                load()


            End If
        Else
            If adakosong(GroupBox2) Then
                MsgBox(kosong)
            Else
                If exc($"INSERT INTO [dbo].[Package]
           ([IdService]
           ,[TotalUnit]
           ,[Price])
     VALUES
           ('{ComboBox1.SelectedValue}'
           ,'{TextBox10.Text}'
           ,'{TextBox11.Text}')") Then

                    MsgBox(added)
                    load()


                End If
            End If
        End If
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub masterPackage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        clearForm(GroupBox2)
        load()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit = True
        Button2.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If dialog(confirmation) Then
            If exc($"DELETE FROM [dbo].[Package]
      WHERE id = '{idp}'") Then
                MsgBox(deleted)
                load()

            End If
        End If
    End Sub
End Class