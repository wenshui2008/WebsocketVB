VERSION 5.00
Begin VB.Form mainForm 
   Caption         =   "VB6 Websocket Client"
   ClientHeight    =   5490
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   8100
   LinkTopic       =   "Form1"
   ScaleHeight     =   5490
   ScaleWidth      =   8100
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnSend 
      Caption         =   "Send"
      Height          =   375
      Left            =   6240
      TabIndex        =   5
      Top             =   4560
      Width           =   1095
   End
   Begin VB.TextBox msgInput 
      Height          =   375
      Left            =   600
      TabIndex        =   4
      Top             =   4560
      Width           =   5535
   End
   Begin VB.TextBox msgListbox 
      Height          =   3495
      Left            =   600
      MultiLine       =   -1  'True
      TabIndex        =   3
      Top             =   840
      Width           =   6735
   End
   Begin VB.CommandButton btnClose 
      Caption         =   "Close"
      Height          =   375
      Left            =   6120
      TabIndex        =   2
      Top             =   240
      Width           =   1215
   End
   Begin VB.TextBox urlInput 
      Height          =   375
      Left            =   1800
      TabIndex        =   1
      Text            =   "wss://iavcast.com:3000/"
      Top             =   240
      Width           =   4215
   End
   Begin VB.CommandButton btnOpen 
      Caption         =   "Open"
      Height          =   375
      Left            =   600
      TabIndex        =   0
      Top             =   240
      Width           =   1095
   End
End
Attribute VB_Name = "mainForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim WithEvents websock As VBToolsLib.Websocket
Attribute websock.VB_VarHelpID = -1
Private Sub Form_Load()
    Dim count As Integer
    
    Set websock = New VBToolsLib.Websocket
    '设置一个窗口关联句柄,VB6仅支持32位版本即可
    websock.setwindowhandle (Me.hWnd)
        
    count = websock.bufferedAmount

    urlInput.Text = "wss://192.168.2.134:3000/"
End Sub

Private Sub Form_Unload(Cancel As Integer)
    websock.setwindowhandle (0)
End Sub

Private Sub btnOpen_Click()
    Dim url As String

    url = urlInput.Text

    If url <> "" Then
        websock.open (url)
    End If
End Sub

Private Sub btnClose_Click()
    websock.Close
End Sub

Private Sub btnSend_Click()
    Dim sMsg As String
    sMsg = msgInput.Text

    If sMsg <> "" Then
        websock.send (sMsg)
    End If
End Sub

Private Sub websock_onopen()
    Dim sTime As String
    Dim sMsg As String
    
    sTime = DateDiff("s", "1970-01-01 00:00:00", Now)
    '演示发送消息,具体业务逻辑由开发者自己实现,这里仅为演示代码
    websock.send ("login: " & sTime)

    sMsg = "OnOpen" & Chr(13) & Chr(10)
    msgListbox.Text = msgListbox.Text & sMsg

End Sub

Private Sub websock_onclose()
    Dim sMsg As String
    
    sMsg = "Onclose" & Chr(13) & Chr(10)
    msgListbox.Text = msgListbox.Text & sMsg
    
End Sub
Private Sub websock_onmessage(ByVal msg As String)
    
    Dim sMsg As String

    sMsg = msg & Chr(13) & Chr(10)
    msgListbox.Text = msgListbox.Text & sMsg
    '仅为演示处理消息,具体业务逻辑应该由开发者自己实现
    If (msg = "[MSG]:close") Then
       websock.Close
    ElseIf Mid(msg, 1, 14) = "[MSG]:foreward" Then
       Dim newmsg
       
       newmsg = Mid(msg, 15)

       websock.send ("[MSG]:This is a foreward MSG:" & newmsg)
    End If
End Sub

Private Sub websock_onerror(ByVal errmsg As String)
    Dim sMsg As String
    
    sMsg = "onerror:" & errmsg & Chr(13) & Chr(10)
    
    msgListbox.Text = msgListbox.Text & sMsg
End Sub

Public Sub AppendTextMethod(msgText As String)
    'msgListbox.AppendText (msgText)
End Sub
    


