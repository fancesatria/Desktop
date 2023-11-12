Public Class viewTransaction
    Dim iddep
    Dim iddede
    Sub load()
        DataGridView1.DataSource = getdata($"SELECT TOP (1000) [Id]
      ,[IdCustomer]
      ,[IdEmployee]
      ,[TransactionDateTime]
      ,[CompletedEstimationDateTime]
      ,[status]
      ,[Name]
  FROM [DBmeja_02].[dbo].[VHD]")

        DataGridView2.DataSource = getdata($"SELECT TOP (1000) [Id]
      ,[IdDeposit]
      ,[IdService]
      ,[IdPrepaidPackage]
      ,[PriceUnit]
      ,[TotalUnit]
      ,[CompletedDateTime]
      ,[status]
      ,[Expr1]
      ,[CompletedEstimationDateTime]
      ,[TransactionDateTime]
      ,[IdEmployee]
      ,[IdCustomer]
      ,[Name]
      ,[Expr2]
      ,[IdKategori]
      ,[IdUnit]
      ,[EstimationDuration]
      ,[Expr3]
      ,[PhoneNumber]
      ,[Address]
      ,[Expr4]
  FROM [DBmeja_02].[dbo].[VDT3] WHERE IdDeposit='{iddep}'")

        Button1.Enabled = False
    End Sub
    Private Sub ToolStripLabel6_Click(sender As Object, e As EventArgs)
        MsgBox("Anda sudah disini")
    End Sub

    Private Sub ToolStripLabel7_Click(sender As Object, e As EventArgs)
        mainForm.Show()
        Me.Hide()

    End Sub


    Private Sub ToolStripLabel5_Click_1(sender As Object, e As EventArgs)
        prepaidPackage.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel4_Click_1(sender As Object, e As EventArgs)
        trasnDeposit.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel3_Click_1(sender As Object, e As EventArgs)
        masterPackage.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel2_Click_1(sender As Object, e As EventArgs)
        masterService.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripLabel1_Click_1(sender As Object, e As EventArgs)
        masterEmployee.Show()
        Me.Hide()
    End Sub

    Private Sub viewTransaction_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        mainForm.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            iddep = DataGridView1.Item(0, e.RowIndex).Value

            Dim sql = $"SELECT TOP (1000) [Id]
      ,[IdDeposit]
      ,[IdService]
      ,[IdPrepaidPackage]
      ,[PriceUnit]
      ,[TotalUnit]
      ,[CompletedDateTime]
  FROM [DBmeja_02].[dbo].[DetailDeposit] where Id = '{iddep}'"

            DataGridView2.DataSource = getdata(sql)
        End If
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            iddede = DataGridView1.Item(0, e.RowIndex).Value
            If iddede = 0 Then
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql = $"UPDATE [dbo].[DetailDeposit]
   SET [CompletedDateTime] = '{Now.ToString("yyyy-MM-dd")}'
 WHERE Id = '{iddede}'"

        If exc(sql) Then
            MsgBox(edited)
            load()

        End If
    End Sub

    Private Sub viewTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()

    End Sub
End Class