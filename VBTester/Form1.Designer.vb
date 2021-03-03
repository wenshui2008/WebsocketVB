<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenBtn = New System.Windows.Forms.Button()
        Me.urlInput = New System.Windows.Forms.TextBox()
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.msgInputBox = New System.Windows.Forms.TextBox()
        Me.SendBtn = New System.Windows.Forms.Button()
        Me.msgListbox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'OpenBtn
        '
        Me.OpenBtn.Location = New System.Drawing.Point(69, 25)
        Me.OpenBtn.Name = "OpenBtn"
        Me.OpenBtn.Size = New System.Drawing.Size(75, 23)
        Me.OpenBtn.TabIndex = 0
        Me.OpenBtn.Text = "Open"
        Me.OpenBtn.UseVisualStyleBackColor = True
        '
        'urlInput
        '
        Me.urlInput.Location = New System.Drawing.Point(161, 27)
        Me.urlInput.Name = "urlInput"
        Me.urlInput.Size = New System.Drawing.Size(260, 21)
        Me.urlInput.TabIndex = 1
        '
        'CloseBtn
        '
        Me.CloseBtn.Location = New System.Drawing.Point(427, 25)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(75, 23)
        Me.CloseBtn.TabIndex = 3
        Me.CloseBtn.Text = "Close"
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'msgInputBox
        '
        Me.msgInputBox.Location = New System.Drawing.Point(66, 307)
        Me.msgInputBox.Name = "msgInputBox"
        Me.msgInputBox.Size = New System.Drawing.Size(355, 21)
        Me.msgInputBox.TabIndex = 4
        '
        'SendBtn
        '
        Me.SendBtn.Location = New System.Drawing.Point(427, 307)
        Me.SendBtn.Name = "SendBtn"
        Me.SendBtn.Size = New System.Drawing.Size(75, 23)
        Me.SendBtn.TabIndex = 5
        Me.SendBtn.Text = "Send"
        Me.SendBtn.UseVisualStyleBackColor = True
        '
        'msgListbox
        '
        Me.msgListbox.Location = New System.Drawing.Point(66, 54)
        Me.msgListbox.Multiline = True
        Me.msgListbox.Name = "msgListbox"
        Me.msgListbox.Size = New System.Drawing.Size(436, 247)
        Me.msgListbox.TabIndex = 6
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 356)
        Me.Controls.Add(Me.msgListbox)
        Me.Controls.Add(Me.SendBtn)
        Me.Controls.Add(Me.msgInputBox)
        Me.Controls.Add(Me.CloseBtn)
        Me.Controls.Add(Me.urlInput)
        Me.Controls.Add(Me.OpenBtn)
        Me.Name = "mainForm"
        Me.Text = "VB.net Websocket Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenBtn As System.Windows.Forms.Button
    Friend WithEvents urlInput As System.Windows.Forms.TextBox
    Friend WithEvents CloseBtn As System.Windows.Forms.Button
    Friend WithEvents msgInputBox As System.Windows.Forms.TextBox
    Friend WithEvents SendBtn As System.Windows.Forms.Button
    Friend WithEvents msgListbox As System.Windows.Forms.TextBox

End Class
