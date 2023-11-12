Public Class Form1
    Dim salah As Integer = 0
    Dim status As Boolean = True
    Dim jam As String
    Sub buatid()
        Dim i = Convert.ToString(getCount("select * from jual"))
        Dim sal = ""

        If i <= 10 Then
            sal = "SAL00" + i
        ElseIf i < 100 And i > 10 Then
            sal = "SAL0"
        ElseIf i >= 100 Then
            sal = "SAL"
        End If
        TextBox1.Text = sal
    End Sub

    Sub load()
        buatid()
        DataGridView1.DataSource = getdata($"select * from transJual where status = 0")
        Timer1.Enabled = True

        setsubtotal()
        setcb()
    End Sub

    Sub setsubtotal()
        Dim subtotal = getValue("select sum(total) as totalz from transJual where status=0", "totalz")
        If IsDBNull(subtotal) Then
            Label1.Text = "0"
        Else
            Label1.Text = subtotal
        End If
        'MsgBox(subtotal.GetType().ToString)
        setjumlahitem()


    End Sub

    Sub setjumlahitem()
        Dim jumlahitem = getValue("select sum(jumlahJual) as jj from transJual where status = 0", "jj")
        If IsDBNull(jumlahitem) Then
            TextBox2.Text = "0"
        Else
            TextBox2.Text = jumlahitem
        End If
    End Sub

    Sub setcb()
        ComboBox1.DataSource = getdata("select * from customer")
        ComboBox1.DisplayMember = "nama"
        ComboBox1.ValueMember = "codeCustomer"

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addBarang.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        clearForm(GroupBox1)
        clearForm(GroupBox4)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label9.Text = Now.ToString("dd MMMMM yyyy hh:mm:ss")
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Dim getCust = $"select * from customer where codeCustomer ='{ComboBox1.SelectedValue}'"
        If exc(getCust) Then
            TextBox3.Text = getValue(getCust, "nama")
            TextBox4.Text = getValue(getCust, "alamat")
            TextBox5.Text = getValue(getCust, "telp")
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
        MsgBox(userlogin)

        'setsubtotal()
        'setcb()
    End Sub


    Private Sub NumericUpDown1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumericUpDown1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Convert.ToInt32(NumericUpDown1.Value) < Convert.ToInt32(Label1.Text) Or Convert.ToInt32(NumericUpDown1.Value) = 0 Then
                MsgBox("Uang kurang")
            Else
                NumericUpDown2.Value = Convert.ToInt32(NumericUpDown1.Value) - Convert.ToInt32(Label1.Text)
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If adakosong(GroupBox1) Or adakosong(GroupBox4) Then
            MsgBox("Data harus diisi semua")
            salah = salah + 1
            'MsgBox(salah)
        Else
            For Each row As DataGridViewRow In DataGridView1.Rows
                If exc($"INSERT INTO [dbo].[jual]
           ([codeJual]
           ,[bayar]
           ,[total]
           ,[kembali]
           ,[itemJual]
           ,[tglJual]
           ,[jamJual]
           ,[idCustomer]
           ,[idEmployee])
     VALUES
           ('{TextBox1.Text}'
           ,'{NumericUpDown1.Value}'
           ,'{Convert.ToInt32(Label1.Text)}'
           ,'{NumericUpDown2.Value}'
           ,'{Convert.ToInt32(TextBox2.Text)}'
           ,'{Now.ToString("yyyy-MM-dd")}'
           ,'{DateTime.Now.TimeOfDay.Hours.ToString("HH:mm")}'
           ,'{ComboBox1.SelectedValue}'
           ,1)") Then

                End If

                If exc($"INSERT INTO [dbo].[detailJual]
           ([codeJual]
           ,[codeBarang]
           ,[nameBarang]
           ,[priceBarang]
           ,[jumlahJual]
           ,[subtotal]
           ,[idEmployee])
     VALUES
           ('{TextBox1.Text}'
           ,'{DataGridView1.Item(1, row.Index).Value}'
           ,'{DataGridView1.Item(2, row.Index).Value}'
           ,'{DataGridView1.Item(3, row.Index).Value}'
           ,'{DataGridView1.Item(4, row.Index).Value}'
           ,'{DataGridView1.Item(5, row.Index).Value}'
           ,1)") Then

                    If exc("UPDATE [dbo].[transJual] SET [status] = 1") Then
                        MsgBox("Data disimpan")
                        load()
                        reportChart.fetchdata()
                        reportJualChart.fetchdata()

                    End If

                End If
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        reportChart.Show()

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If salah = 3 Then
            If status Then
                jam = Now.AddMinutes(1).ToString("mm")
                status = False
                MsgBox(jam)

            End If
            Button4.Enabled = False
            Label14.Text = "Menunggu 1 menit"

            If Now.ToString("mm") = jam Then
                salah = 0
                Button4.Enabled = True
            End If

        Else
            Label14.Text = ""
        End If
    End Sub
End Class
