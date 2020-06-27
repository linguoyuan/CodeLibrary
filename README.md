# CodeLibrary
积累的实用代码库、工具类库等

#### * [01_EventManager](https://github.com/linguoyuan/CodeLibrary/tree/master/01_EventManager)
简单的事件/消息管理类，便于各层传递消息，包含事件类型定义，订阅，发布，取消四步操作

#### * [02_WaitTimeManager](https://github.com/linguoyuan/CodeLibrary/tree/master/02_WaitTimeManager)
unity自带的协程和Update都可以做延时，但这个延时类不依赖于Monobehaviour，在特定场合很有用处

#### * [03_ToolsHelper](https://github.com/linguoyuan/CodeLibrary/tree/master/03_ToolsHelper)
常用的Unity工具类。
 * ##### [FindHelper.cs](https://github.com/linguoyuan/CodeLibrary/blob/master/03_ToolsHelper/FindHelper.cs)
         unity自带的查找子物体无法往更深层次查找，或者从某个节点找，全局查找又太耗性能。
         这个类采用递归方法实现更高效率查找物体或者组件。
#### * [05_EventManagerSystem](https://github.com/linguoyuan/CodeLibrary/tree/master/05_EventManagerSystem)
 01_EventManager的简单消息管理类只是简单地解决了各层之间的消息传递问题，对于简单的应用场合是足够的，但是仍然有不完善的地方，
 第一个问题，如果有多个事件同时发生的话，那到底谁该先执行呢？所以还得引入事件队列。
 第二个问题，为了脚本复用如果同一个事件接收脚本，挂载在不同的物体，要是只想其中的某个物体对此事件有响应就
 相对麻烦点，因为在01_EventManager中是以广播的方式发送事件出去的，虽然也可以用判断事件传参的方式来区别开来，
 那能否在发送的时候就指定特定的物体能收到消息呢？当然是可以的，在事件的发送参数里专门定义一个事件目标接收源，
 就更加地清晰明了了。
