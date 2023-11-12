Public Class addBarang
    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        If exc($"select * from barang where codeBarang = '{ComboBox1.SelectedValue}'") Then
            TextBox3.Text = getValue($"select * from barang where codeBarang = '{ComboBox1.SelectedValue}'", "nameBarang")
            TextBox1.Text = getValue($"select * from barang where codeBarang = '{ComboBox1.SelectedValue}'", "price")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If exc($"INSERT INTO [dbo].[transJual]
              ([codeBarang]
              ,[nameBarang]
              ,[priceBarang]
              ,[jumlahJual],[total])
        VALUES
              ('{ComboBox1.SelectedValue}'
              ,'{TextBox3.Text}'
              ,'{TextBox1.Text}'
              ,'{NumericUpDown2.Value}', '{Decimal.Parse(TextBox1.Text) * NumericUpDown2.Value}')") Then

            setstok()

        End If


    End Sub

    Sub load()
        ComboBox1.DataSource = getdata("select * from barang")
        ComboBox1.DisplayMember = "codeBarang"
        ComboBox1.ValueMember = "codeBarang"
    End Sub

    Private Sub addBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
        MsgBox(userlogin)
    End Sub

    Sub setstok()
        Dim getstok = getValue("select stock from barang", "stock")
        Dim cek = Convert.ToInt32(getstok) - Convert.ToInt32(NumericUpDown2.Value)
        If cek <= 0 Then
            MsgBox("Stok tidak cukup")
            Form1.load()
            Form1.setsubtotal()
        Else
            If exc($"UPDATE [dbo].[barang] SET [stock] ='{cek}' WHERE codeBarang = '{ComboBox1.SelectedValue}'") Then
                MsgBox("Data disimpan")
                Form1.load()
                Form1.setsubtotal()
            End If
        End If
    End Sub
End Class