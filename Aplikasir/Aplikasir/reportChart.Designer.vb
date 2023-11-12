<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class reportChart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.DetailJualTableAdapter1 = New Aplikasir.dbKasirDataSetTableAdapters.detailJualTableAdapter()
        Me.DetailJualTableAdapter = New Aplikasir.KasirDataSetTableAdapters.detailJualTableAdapter()
        Me.DetailJualBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KasirDataSet = New Aplikasir.KasirDataSet()
        Me.DbKasirDataSet = New Aplikasir.dbKasirDataSet()
        Me.DetailJualBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DetailJualBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KasirDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DbKasirDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailJualBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DetailJualTableAdapter1
        '
        Me.DetailJualTableAdapter1.ClearBeforeFill = True
        '
        'DetailJualTableAdapter
        '
        Me.DetailJualTableAdapter.ClearBeforeFill = True
        '
        'DetailJualBindingSource
        '
        Me.DetailJualBindingSource.DataMember = "detailJual"
        '
        'KasirDataSet
        '
        Me.KasirDataSet.DataSetName = "KasirDataSet"
        Me.KasirDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DbKasirDataSet
        '
        Me.DbKasirDataSet.DataSetName = "dbKasirDataSet"
        Me.DbKasirDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DetailJualBindingSource1
        '
        Me.DetailJualBindingSource1.DataMember = "detailJual"
        Me.DetailJualBindingSource1.DataSource = Me.DbKasirDataSet
        '
        'Chart1
        '
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.DataSource = Me.DetailJualBindingSource1
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(38, 151)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "BarangTerjual"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(911, 462)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(38, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 65)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Berdasarkan Customer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'reportChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 651)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Chart1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "reportChart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "reportChart"
        CType(Me.DetailJualBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KasirDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DbKasirDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailJualBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DetailJualTableAdapter1 As dbKasirDataSetTableAdapters.detailJualTableAdapter
    Friend WithEvents DetailJualTableAdapter As KasirDataSetTableAdapters.detailJualTableAdapter
    Friend WithEvents DetailJualBindingSource As BindingSource
    Friend WithEvents KasirDataSet As KasirDataSet
    Friend WithEvents DbKasirDataSet As dbKasirDataSet
    Friend WithEvents DetailJualBindingSource1 As BindingSource
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Button1 As Button
End Class
