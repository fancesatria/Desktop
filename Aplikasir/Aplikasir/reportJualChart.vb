Public Class reportJualChart
    Sub fetchdata()
        Dim sql = $"select * from jual where tglJual between '{getDateValue(DateTimePicker1)}' and '{getDateValue(DateTimePicker2)}'"
        Dim data As DataTable = getdata(sql)

        If IsDBNull(data) Then
            MsgBox("tak ada data utuk ditampilkan")
        Else
            For Each row As DataRow In data.Rows
                Chart1.Series("codeCustomer").Points.AddXY(row("idCustomer"), row("itemJual"))
            Next
        End If

    End Sub

    Private Sub reportJualChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchdata()

    End Sub
End Class

