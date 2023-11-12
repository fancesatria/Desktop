Public Class reportChart
    Private Sub reportChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbKasirDataSet.detailJual' table. You can move, or remove it, as needed.
        'Me.DetailJualTableAdapter1.Fill(Me.DbKasirDataSet.detailJual)
        fetchdata()
        MsgBox(userlogin)

    End Sub


    Sub fetchdata()
        Dim sql = "select * from detailJual "
        Dim data As DataTable = getdata(sql)

        If IsDBNull(data) Then
            MsgBox("Tidak ada data untuk ditampilkan")
        Else
            For Each row As DataRow In data.Rows
                Chart1.Series("BarangTerjual").Points.AddXY(row("nameBarang"), row("jumlahJual"))
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        reportJualChart.Show()
        Me.Close()

    End Sub
End Class