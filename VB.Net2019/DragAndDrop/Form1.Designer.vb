<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.cboscale = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.AxTimelineControl1 = New AxTimelineAxLib.AxTimelineControl()
        CType(Me.AxTimelineControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboscale
        '
        Me.cboscale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboscale.FormattingEnabled = True
        Me.cboscale.Location = New System.Drawing.Point(581, 352)
        Me.cboscale.Name = "cboscale"
        Me.cboscale.Size = New System.Drawing.Size(120, 20)
        Me.cboscale.TabIndex = 12
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(526, 354)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 12)
        Me.label2.TabIndex = 11
        Me.label2.Text = "Scale"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(19, 423)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(467, 12)
        Me.label1.TabIndex = 10
        Me.label1.Text = "Drag the listbox item , then drop over  video.audio track on timeline control"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(406, 352)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(102, 26)
        Me.button2.TabIndex = 9
        Me.button2.Text = "Preview"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(295, 351)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(79, 29)
        Me.button1.TabIndex = 8
        Me.button1.Text = "Add"
        Me.button1.UseVisualStyleBackColor = True
        '
        'listBox1
        '
        Me.listBox1.FormattingEnabled = True
        Me.listBox1.ItemHeight = 12
        Me.listBox1.Location = New System.Drawing.Point(18, 343)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.Size = New System.Drawing.Size(264, 76)
        Me.listBox1.TabIndex = 7
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'AxTimelineControl1
        '
        Me.AxTimelineControl1.Enabled = True
        Me.AxTimelineControl1.Location = New System.Drawing.Point(18, 19)
        Me.AxTimelineControl1.Name = "AxTimelineControl1"
        Me.AxTimelineControl1.OcxState = CType(resources.GetObject("AxTimelineControl1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxTimelineControl1.Size = New System.Drawing.Size(727, 318)
        Me.AxTimelineControl1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 443)
        Me.Controls.Add(Me.cboscale)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.listBox1)
        Me.Controls.Add(Me.AxTimelineControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.AxTimelineControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AxTimelineControl1 As AxTimelineAxLib.AxTimelineControl
    Friend WithEvents cboscale As System.Windows.Forms.ComboBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents listBox1 As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
