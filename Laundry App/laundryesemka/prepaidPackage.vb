Public Class prepaidPackage
    Dim idcus
    Sub load()
        ComboBox1.DataSource = getdata($"SELECT TOP (1000) [Id]
      ,[IdService]
      ,[TotalUnit]
      ,[Price]
  FROM [DBmeja_02].[dbo].[Package]  '{TextBox1.Text}")
        ComboBox1.DisplayMember = "Id"
        ComboBox1.ValueMember = "Id"

        Label1.Text = ""
        Label8.Text = ""

        DataGridView1.DataSource = getdata($"SELECT TOP (1000) [Id]
      ,[IdCustomer]
      ,[IdPackage]
      ,[Price]
      ,[StartDateTime]
      ,[IdService]
      ,[TotalUnit]
      ,[PackagePrice]
      ,[Name]
      ,[PhoneNumber]
      ,[Address]
  FROM [DBmeja_02].[dbo].[VPP]")

    End Sub
    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs)
        masterService.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs)
        masterPackage.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel4_Click(sender As Object, e As EventArgs)
        trasnDeposit.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel5_Click(sender As Object, e As EventArgs)
        Me.Show()
    End Sub

    Private Sub ToolStripLabel6_Click(sender As Object, e As EventArgs)
        viewTransaction.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel7_Click(sender As Object, e As EventArgs)
        mainForm.Show()
        Me.Hide()

    End Sub

    Private Sub ToolStripLabel1_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        masterEmployee.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel2_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        masterService.Show()
        Me.Hide()
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
        MsgBox("Anda sudah disini")
    End Sub

    Private Sub ToolStripLabel6_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel6.Click
        viewTransaction.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel7_Click_1(sender As Object, e As EventArgs) Handles ToolStripLabel7.Click
        mainForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        addCustomer.Show()
        Me.Hide()

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        onlyNumber(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            Dim sql = $"SELECT TOP (1000) [Id]
      ,[Name]
      ,[PhoneNumber]
      ,[Address]
  FROM [DBmeja_02].[dbo].[Customer] WHERE PhoneNumber='{TextBox2.Text}'"
            'MsgBox(getCount(sql))
            If getCount(sql) = 0 Then

                MsgBox("Data tidak ada")
            Else
                idcus = getValue(sql, "Id")
                Label1.Text = getValue(sql, "Name")
                Label8.Text = getValue(sql, "Address")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql = $"INSERT INTO [dbo].[PrepaidPackage]
           ([IdCustomer]
           ,[IdPackage]
           ,[Price]
           ,[StartDateTime])
     VALUES
           ('{idcus}'
           ,'{ComboBox1.SelectedValue}'
           ,'{TextBox3.Text}'
           ,'{Now.ToString("yyyy-MM-dd")}')"

        If adakosong(GroupBox2) Or adakosong(GroupBox3) Then
            MsgBox(kosong)
        Else
            If exc(sql) Then
                MsgBox(added)
                load()
            Else
                MsgBox(failed)
                load()

            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        onlyNumber(e)
    End Sub

    Private Sub prepaidPackage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()

    End Sub
End Class