# WebsocketVB
A websocket communication component for VB/VB.NET/C#

一个用于VB6/VB.NET/C#进行Websocket通信的COM组件，支持WS/WSS，采用异步事件机制，性能优。 

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
