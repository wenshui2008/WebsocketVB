# WebsocketVB
A websocket communication component for VB6/VB.NET/C#

一个用于VB6/VB.NET/C#进行Websocket通信的COM组件，支持WS/WSS，采用异步事件机制，性能优。 完全模仿H5 Websocket 类实现。
添加 setHttpHeader 方法
使用方法请参考：https://blog.csdn.net/ababab12345/article/details/114006605?csdn_share_tail=%7B%22type%22%3A%22blog%22%2C%22rType%22%3A%22article%22%2C%22rId%22%3A%22114006605%22%2C%22source%22%3A%22ababab12345%22%7D



# 文件说明：  
CSTester - C#调用测试程序 Visual Studio 2010项目  
VBTester - VB.NET调用测试程序 Visual Studio 2010项目  
VBToolsLib - Websocket组件库，包含64位与32位组件  
  |  
  +-x64  
  | &nbsp;&nbsp; |-libcrypto-1_1-x64.dll -Openssl 64位加密库  
  | &nbsp;&nbsp; |-libssl-1_1-x64.dll -Openssl调用库  
  | &nbsp;&nbsp; |-msvcr100.dll -VC2010运行时库64位版本，如果系统已经安装了这个库文件，则可以删除  
  | &nbsp;&nbsp; +-VBTools.dll -Websocket 组件64位版本  
  |-x86  
    &nbsp;&nbsp; |-libcrypto-1_1.dll -Openssl 32位加密库  
    &nbsp;&nbsp; |-libssl-1_1.dll -Openssl调用库  
    &nbsp;&nbsp; |-msvcr100.dll - VC2010运行时库32位版本，如果系统已经安装了这个库文件，则可以删除  
    &nbsp;&nbsp; +-VBTools.dll  -Websocket 组件32位版本  
  
VBWebsocket - VB6调用测试程序,请用VB6打开（Visual Studio 98)  
  
VBTools.sln - Visual studio 2010解决方案文件，用Visual studio 2010 IDE 打开  
VBTools.suo - Visual studio 2010附加文件  
  
# 安装步骤： 


比如为 C:\VBWebsocket目录

由于是COM组件，因此需要注册，注册步骤如下：  
1）打开命令行窗口 cmd  

2）如果是32或64位操作系统，需要用于32位程序，则执行：  
regsvr32 C:\VBWebsocket\VBToolsLib\x86\VBTools.dll  

如果是64位操作系统，需要用于64位程序，则执行：  
regsvr32 C:\VBWebsocket\VBToolsLib\x64\VBTools.dll  

在打开项目后，请添加引用，引用的库名称为：VBToolsLib  
  

# 其它备注：  
VBTools.dll 库与其附加的库文件可以放置于任何目录，只需执行正确的regsvr32注册即可。

```cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSTester
{
    public partial class mainForm : Form
    {
        VBToolsLib.Websocket websock;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            int count;
            
            //在窗口的初始化事件里创建Websocket对象
            websock = new VBToolsLib.Websocket();

            //关联主线程句柄便于接收Websocket消息
            //setwindowhandle方法用于关联窗口句柄,setwindowhandle64为64位版本，调用其中一个即可
            //websock.setwindowhandle((int)this.Handle);
            websock.setwindowhandle64((long)this.Handle);

            // 在调用open 方法之前可以设置Http 请求头，这些头放在标准的HTTP协议请求头里发送给服务器
            websock.setHttpHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/105.0.0.0 Safari/537.36");
            websock.setHttpHeader("Cookie", "XMPlayer=V1.0; PHPSESSID=3nm364h6bu2i80lp4esik5ki56");

            urlInput.Text = "wss://192.168.2.134:3000/";
            //演示获取属性
            count = websock.bufferedAmount;
            //C#方式的设置事件
            websock.onopen    += websocket_onopen;
            websock.onclose   += websocket_onclose;
            websock.onmessage += websocket_onmessage;
            websock.onerror   += websocket_onerror;

            if (IntPtr.Size == 8) {
                this.Text += " (x64)";
            }
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //在窗口关闭事件里取消窗口句柄关联，不是必须
            websock.setwindowhandle(0);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string sUrl = urlInput.Text;

            if (sUrl != "") {
                websock.open(sUrl);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            websock.close();
        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            string sMsg = msgInput.Text;

            if (sMsg != "")
            {
                websock.send(sMsg);
            }
        }

        private void websocket_onopen()
        {
            string sTime;
            string sMsg;

            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);

            sTime = Convert.ToInt64(ts.TotalSeconds).ToString();
            //这里演示给服务器发送一个消息，具体业务逻辑应该在服务器上实现
            websock.send("login: " + sTime);

            sMsg = "OnOpen\r\n";
            msgListbox.AppendText(sMsg);
        }

        private void websocket_onclose()
        {
            string sMsg;

            sMsg = "Onclose\r\n";

            msgListbox.AppendText(sMsg);
        }

        private void websocket_onmessage(string msg)
        {
            string sMsg;

            sMsg = msg + "\r\n";

            msgListbox.AppendText(sMsg);
            //这里演示处理消息，具体业务逻辑的实现可能不是这样的，这里仅为演示
            if (msg == "[MSG]:close")
            {
                websock.close();
            }
            else if (msg.Substring(0, 14) == "[MSG]:foreward")
            {
                string newmsg = msg.Substring(14);
                //演示将消息重新转发出去，具体业务逻辑由调用者自己实现，这里仅仅为演示
                websock.send("[MSG]:This is a foreward MSG:" + newmsg);
            }
        }

        private void websocket_onerror(string errmsg)
        {
            string sMsg;

            sMsg = "onerror:" + errmsg + "\r\n";

            msgListbox.AppendText(sMsg);
        }
    }
}
```
