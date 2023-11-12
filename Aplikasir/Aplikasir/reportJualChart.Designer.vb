<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reportJualChart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.DetailJualBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DbKasirDataSet = New Aplikasir.dbKasirDataSet()
        Me.KasirDataSet = New Aplikasir.KasirDataSet()
        Me.DetailJualBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DetailJualTableAdapter = New Aplikasir.KasirDataSetTableAdapters.detailJualTableAdapter()
        Me.DetailJualTableAdapter1 = New Aplikasir.dbKasirDataSetTableAdapters.detailJualTableAdapter()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailJualBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbKasirDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KasirDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailJualBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot
        ChartArea3.AxisX.Interval = 1.0R
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Me.Chart1.DataSource = Me.DetailJualBindingSource1
        Legend3.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend3)
        Me.Chart1.Location = New System.Drawing.Point(49, 146)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Legend = "Legend1"
        Series3.Name = "codeCustomer"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(911, 462)
        Me.Chart1.TabIndex = 3
        Me.Chart1.Text = "Chart1"
        '
        'DetailJualBindingSource1
        '
        Me.DetailJualBindingSource1.DataMember = "detailJual"
        Me.DetailJualBindingSource1.DataSource = Me.DbKasirDataSet
        '
        'DbKasirDataSet
        '
        Me.DbKasirDataSet.DataSetName = "dbKasirDataSet"
        Me.DbKasirDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'KasirDataSet
        '
        Me.KasirDataSet.DataSetName = "KasirDataSet"
        Me.KasirDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DetailJualBindingSource
        '
        Me.DetailJualBindingSource.DataMember = "detailJual"
        Me.DetailJualBindingSource.DataSource = Me.KasirDataSet
        '
        'DetailJualTableAdapter
        '
        Me.DetailJualTableAdapter.ClearBeforeFill = True
        '
        'DetailJualTableAdapter1
        '
        Me.DetailJualTableAdapter1.ClearBeforeFill = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(672, 25)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(288, 26)
        Me.DateTimePicker2.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(603, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sampai"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(115, 25)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(288, 26)
        Me.DateTimePicker1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Dari"
        '
        'reportJualChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 632)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "reportJualChart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "reportJualChart"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailJualBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbKasirDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KasirDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailJualBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents DetailJualBindingSource1 As BindingSource
    Friend WithEvents DbKasirDataSet As dbKasirDataSet
    Friend WithEvents KasirDataSet As KasirDataSet
    Friend WithEvents DetailJualBindingSource As BindingSource
    Friend WithEvents DetailJualTableAdapter As KasirDataSetTableAdapters.detailJualTableAdapter
    Friend WithEvents DetailJualTableAdapter1 As dbKasirDataSetTableAdapters.detailJualTableAdapter
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
End Class
