Public Class trasnDeposit
    Dim idcus
    Dim iddepo
    Dim estimationtime
    Dim filled As Boolean = True
    Sub load()
        settotal()
        setEstimation()
        setprepaid()

        ComboBox1.DataSource = getdata($"SELECT TOP (1000) [Id]
      ,[Name]
      ,[IdKategori]
      ,[IdUnit]
      ,[PriceUnit]
      ,[EstimationDuration]
  FROM [DBmeja_02].[dbo].[Service]")
        ComboBox1.DisplayMember = "Name"
        ComboBox1.ValueMember = "Id"

        Label3.Text = ""
        Label8.Text = ""
        Label14.Visible = False
        ComboBox2.Visible = False

        DataGridView1.DataSource = getdata("SELECT TOP (1000) [EstimationDuration]
      ,[Id]
      ,[IdDeposit]
      ,[IdService]
      ,[IdPrepaidPackage]
      ,[PriceUnit]
      ,[CompletedDateTime]
      ,[TotalUnit]
      ,[status]
      ,[IDDepo]
      ,PriceUnit*TotalUnit AS Subtotal
  FROM [DBmeja_02].[dbo].[VDS] WHERE status = 0")


        filled = False

    End Sub

    Private Sub trasnDeposit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        mainForm.Show()
        Me.Hide()
    End Sub


    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        onlyNumber(e)
        If e.KeyChar = Chr(Keys.Enter) Then
            Dim sql = $"SELECT TOP (1000) [Id]
      ,[Name]
      ,[PhoneNumber]
      ,[Address]
  FROM [DBmeja_02].[dbo].[Customer] WHERE PhoneNumber='{TextBox3.Text}'"
            'MsgBox(getCount(sql))
            If getCount(sql) = 0 Then

                MsgBox("Data tidak ada")
            Else
                idcus = getValue(sql, "Id")
                Label3.Text = getValue(sql, "Name")
                Label8.Text = getValue(sql, "Address")
            End If
        End If

    End Sub

    Private Sub trasnDeposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addCustomer.Show()
        Me.Hide()

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged, ComboBox2.SelectedValueChanged
        Dim sql = $"SELECT TOP (1000) [Id]
      ,[Name]
      ,[IdKategori]
      ,[IdUnit]
      ,[PriceUnit]
      ,[EstimationDuration]
  FROM [DBmeja_02].[dbo].[Service] where Id = '{ComboBox1.SelectedValue}'"

        If exc(sql) Then
            TextBox11.Text = getValue(sql, "PriceUnit")
            estimationtime = getValue(sql, "EstimationDuration")

        End If
    End Sub


    Sub settotal()
        Dim cek = "SELECT TOP (1000) [IdDeposit]
      ,[IdService]
      ,[IdPrepaidPackage]
      ,[TotalUnit]
      ,[PriceUnit]
      ,[CompletedDateTime]
      ,[Name]
      ,[Expr1]
      ,[IdKategori]
      ,[IdUnit]
      ,[Id]
      ,[IdEmployee]
      ,[TransactionDateTime]
      ,[CompletedEstimationDateTime]
      ,[status]
      ,[EstimationDuration]
  FROM [DBmeja_02].[dbo].[VTD2]"

        If exc(cek) Then
            Dim total = getValue("select sum(Subtotal) as Totals from [VDS] where status = 0", "totals")
            Label13.Text = total
        Else
            Label13.Text = "0"
        End If
    End Sub

    Sub setEstimation()
        Dim cek = "SELECT TOP (1000) [IdDeposit]
      ,[IdService]
      ,[IdPrepaidPackage]
      ,[TotalUnit]
      ,[PriceUnit]
      ,[CompletedDateTime]
      ,[Name]
      ,[Expr1]
      ,[IdKategori]
      ,[IdUnit]
      ,[Id]
      ,[IdEmployee]
      ,[TransactionDateTime]
      ,[CompletedEstimationDateTime]
      ,[status]
      ,[EstimationDuration]
  FROM [DBmeja_02].[dbo].[VTD2]"

        If exc(cek) Then
            Dim sql = getValue("select avg(EstimationDuration) as cc from [VDS] where status =0", "cc")
            Label6.Text = sql
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        filled = True
        setprepaid()

    End Sub

    Sub setprepaid()

        ComboBox2.DataSource = getdata("SELECT TOP (1000) [Id]
      ,[IdCustomer]
      ,[IdPackage]
      ,[Price]
      ,[StartDateTime]
      ,[Customer]
      ,[PhoneNumber]
      ,[Address]
  FROM [DBmeja_02].[dbo].[VPRE]")
        ComboBox2.DisplayMember = "Customer"
        ComboBox2.ValueMember = "Id"
        Label14.Visible = True
        ComboBox2.Visible = True
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim estimation = Now.AddHours(estimationtime).ToString("yyyy-MM-dd HH:mm")
        Dim recent = Now.ToString("yyyy-MM-dd HH:mm")

        If adakosong(GroupBox1) Or adakosong(GroupBox2) Then
            MsgBox(kosong)
        Else
            If exc($"INSERT INTO [dbo].[HeaderDeposit]
           ([IdCustomer]
           ,[IdEmployee]
           ,[TransactionDateTime]
           ,[status])
     VALUES
           ('{idcus}'
           ,'{idlogin}'
           ,'{recent}'
           ,0)") Then

                Dim iddepo = getValue("SELECT * FROM [DBmeja_02].[dbo].[HeaderDeposit] Order By Id ", "Id")
                MsgBox(iddepo)

                If filled = False Then
                    If exc($"INSERT INTO [dbo].[DetailDeposit]
           ([IdDeposit]
           ,[IdService]
           ,[PriceUnit]
           ,[TotalUnit],[status])
     VALUES
           ('{iddepo}'
           ,'{ComboBox1.SelectedValue}'
           ,'{Convert.ToInt32(TextBox11.Text)}'
           ,'{Convert.ToInt32(TextBox10.Text)}',0)") Then


                        MsgBox(added)
                        load()
                    Else
                        MsgBox("Gagal insert ke detail")
                        load()
                    End If
                Else
                    If exc($"INSERT INTO [dbo].[DetailDeposit]
           ([IdDeposit]
           ,[IdService]
           ,[IdPrepaidPackage]
           ,[PriceUnit]
           ,[TotalUnit],[status])
     VALUES
           ('{iddepo}'
           ,'{ComboBox1.SelectedValue}'
           ,'{ComboBox2.SelectedValue}'
           ,'{Convert.ToInt32(TextBox11.Text)}'
           ,'{Convert.ToInt32(TextBox10.Text)}',0)") Then


                        MsgBox(added)
                        load()
                    Else
                        MsgBox("Gagal insert ke detail")
                        load()
                    End If
                End If
            Else
                MsgBox("gagal insert di header")
                load()

            End If
            settotal()
            setEstimation()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If dialog("Transaksi akan dilakukan?") Then
            If exc($"UPDATE [dbo].[VDS]
   SET [status] = 1") Then

                MsgBox("Transaksi berhasil")
                load()
            Else
                MsgBox("Transaksi gagal")
                load()

            End If
        End If
    End Sub

    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox10.KeyPress
        settotal()
        setEstimation()

    End Sub
End Class