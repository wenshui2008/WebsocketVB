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
