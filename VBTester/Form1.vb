Public Class mainForm
    Dim WithEvents websock As VBToolsLib.Websocket

    Delegate Sub appendText(s As String)
    Dim useSetwindowhandle As Boolean = False


    Private Sub mainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim count As Integer

        'TextBox.CheckForIllegalCrossThreadCalls = False
        '在窗口的初始化事件里创建Websocket对象
        websock = New VBToolsLib.Websocket

        '接着关联一个主线程窗口句柄便于接收Websocket消息
        'setwindowhandle方法用于设置关联窗口句柄（仅用于32位版本），setwindowhandle64为64位版本
        '仅需要调用这两个方法中的一个即可，64位版本必须用setwindowhandle64方法
        'websock.setwindowhandle(Me.Handle)
        'setwindowhandle64 即能够用于Windows 32位又能用于64位
        websock.setwindowhandle64(Me.Handle)
        '因为调用了setwindowhandle64方法，所以设置标志为True
        useSetwindowhandle = True
        '任何事件可以调用bufferedAmount属性获取尚未发送的缓冲数目，这里仅是演示
        count = websock.bufferedAmount

        '在调用open 方法之前可以设置Http 请求头，这些头放在标准的HTTP协议请求头里发送给服务器
        websock.setHttpHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36")
        websock.setHttpHeader("Cookie", "XMPlayer=V1.0; PHPSESSID=3nm364h6bu2i80lp4esik5ki56")

        urlInput.Text = "wss://192.168.2.134:3000/"

        If (IntPtr.Size = 8) Then
            Me.Text &= " (x64)"
        End If
    End Sub

    Private Sub mainForm_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        '在窗口关闭事件里取消窗口句柄关联，不是必须
        If useSetwindowhandle Then
            websock.setwindowhandle(0)
        End If
    End Sub

    Private Sub OpenBtn_Click(sender As System.Object, e As System.EventArgs) Handles OpenBtn.Click
        Dim url
        url = urlInput.Text

        If url <> "" Then
            '连接服务器，执行的是异步操作，只能通过监听onopen与onerror事件来判断是否成功
            websock.open(url)
        End If
    End Sub

    Private Sub CloseBtn_Click(sender As System.Object, e As System.EventArgs) Handles CloseBtn.Click
        websock.close()
    End Sub

    Private Sub SendBtn_Click(sender As System.Object, e As System.EventArgs) Handles SendBtn.Click
        Dim sMsg As String = msgInputBox.Text

        If sMsg <> "" Then
            websock.send(sMsg)
        End If
    End Sub

    Private Sub websock_onopen() Handles websock.onopen
        Dim sTime As String = DateDiff("s", "1970-01-01 00:00:00", Now)
        Dim sMsg = ""
        websock.send("login: " & sTime)

        sMsg = "OnOpen" & Chr(13) & Chr(10)
        If useSetwindowhandle Then
            msgListbox.AppendText(sMsg)
        Else
            '如果没有调用setwindowhandle关联窗体句柄，就必须用委托方式，否则可能会有多线程界面死锁问题
            Me.Invoke(New appendText(AddressOf AppendTextMethod), sMsg)
        End If
    End Sub

    Private Sub websock_onmessage(ByVal msg As String) Handles websock.onmessage
        Dim sMsg As String

        sMsg = msg & Chr(13) & Chr(10)
        If useSetwindowhandle Then
            msgListbox.AppendText(sMsg)
        Else
            '如果没有调用setwindowhandle(x64)，就必须用委托方式，否则会有多线程界面死锁问题
            Me.Invoke(New appendText(AddressOf AppendTextMethod), sMsg)
        End If

        '这里演示处理消息，具体业务逻辑的实现可能不是这样的，这里仅为演示
        If (msg = "[MSG]:close") Then
            websock.close()
        ElseIf (msg.Substring(0, 14) = "[MSG]:foreward") Then
            Dim newmsg = msg.Substring(14)
            '演示将消息重新转发出去，具体业务逻辑由调用者自己实现，这里仅仅为演示
            websock.send("[MSG]:This is a foreward MSG:" & newmsg)
        End If
    End Sub

    Private Sub websock_onclose() Handles websock.onclose
        Dim sMsg As String
        sMsg = "Onclose" & Chr(13) & Chr(10)
        If useSetwindowhandle Then
            msgListbox.AppendText(sMsg)
        Else
            '没有调用setwindowhandle(x64)，就必须用委托方式，否则有多线程问题
            Me.Invoke(New appendText(AddressOf AppendTextMethod), sMsg)
        End If
    End Sub

    Private Sub websock_onerror(ByVal msg As String) Handles websock.onerror
        Dim sMsg As String

        sMsg = "onerror:" & msg & Chr(13) & Chr(10)
        If useSetwindowhandle Then
            msgListbox.AppendText(sMsg)
        Else
            '调用了 setwindowhandle(x64) 就不用委托方式了，否则会有多线程问题
            Me.Invoke(New appendText(AddressOf AppendTextMethod), sMsg)
        End If
    End Sub

    Public Sub AppendTextMethod(msgText As String)
        msgListbox.AppendText(msgText)
    End Sub
End Class
