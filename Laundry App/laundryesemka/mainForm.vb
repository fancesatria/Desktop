Public Class mainForm

    Sub load()
        Label4.Text = username
    End Sub
    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        masterEmployee.Show()
        Me.Hide()

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
        MsgBox("Anda sudah disini")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Now.ToString("dd MMMMM yyyy HH:mm:ss")
    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()

    End Sub

    Private Sub ToolStripLabel9_Click(sender As Object, e As EventArgs) Handles ToolStripLabel9.Click
        requestJemput.Show()
        Me.Hide()

    End Sub
End Class