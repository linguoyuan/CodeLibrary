简述：事件处理系统的变种应用，这里采用了队列+委托的方式来处理Websock网络消息，一个最小网络客户端模块。
 具备接收WebSocket消息，消息用XXTEA+Base64的方式进行加解密，采用Json解析。

* Dispatcher.cs 消息分发静态类，主要对外接口有消息注册，注销，网络关闭开启

* Protocol.cs  协议约束类，每一条协议对应一个枚举数值

* UserTest.cs  用户测试类，这里输出了服务器端发来的内容。同时，这个只是客户端，还模拟了Websock接收到一条服务端发来的消息

* WebSocketConnect.cs  网络接口类

* XXTEA.cs  加解密类

* LitJson   Json插件

* 工程目录图，unity版本2018.3.5

![工程目录图](https://github.com/linguoyuan/CodeLibrary/blob/master/06_NetEventFrame/Mulu.png)

* 测试结果图

![结果图](https://github.com/linguoyuan/CodeLibrary/blob/master/06_NetEventFrame/result.png)

点击按键，发送网络消息。
消息在解密前是一串数字字母，解密后得出原来加密前的数据。
