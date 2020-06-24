# CodeLibrary
>积累的实用代码库、工具类库等

#### * [01_EventManager](https://github.com/linguoyuan/CodeLibrary/tree/master/01_EventManager)
>事件/消息管理类，便于各层传递消息，包含事件类型定义，订阅，发布，取消四步操作

#### * [02_WaitTimeManager](https://github.com/linguoyuan/CodeLibrary/tree/master/02_WaitTimeManager)
>unity自带的协程和Update都可以做延时，但这个延时类不依赖于Monobehaviour，在特定场合很有用处

#### * [03_ToolsHelper](https://github.com/linguoyuan/CodeLibrary/tree/master/03_ToolsHelper)
常用的Unity工具类。
 >> * ##### [FindHelper.cs](https://github.com/linguoyuan/CodeLibrary/blob/master/03_ToolsHelper/FindHelper.cs)
 >> unity自带的查找子物体无法往更深层次查找，或者从某个节点找，全局查找又太耗性能。
 >> 这个类采用递归方法实现更高效率查找物体或者组件。
