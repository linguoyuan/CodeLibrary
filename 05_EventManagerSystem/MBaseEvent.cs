using System;
using System.Collections.Generic;

public class MBaseEvent
{
    protected long eventID; // 事件ID
    protected int eventType; // 事件类型
    public int Type
    {
        get
        {
            return eventType;
        }
    }
    public int what; // 事件携带的基础信息
    public object obj;
    public bool needWakeUp = false; // 是否需要唤醒接收方，可用于将非活动状态的物体唤起
    public bool isBroadcast = false; // 是否广播，一般而言不建议和needWakeUp同时为True，广播事件将会向所有对象发送
    public string eventSource; // 事件源（来自分发表键名）
    public string dispatchTarget; // 事件目标（来自分发表键名）
    protected Dictionary<string, object> extra; // 事件携带的额外信息

    protected MBaseEvent(int type)
    { // 构造方法设置为保护类型，避免直接创建基类对象
        eventID = DateTime.Now.Ticks; // 打上时间戳
        eventType = type;
    }

    public void putExtra(string key, Object value)
    { // 放入额外信息
        if (extra == null)
        {
            extra = new Dictionary<string, Object>();
        }
        extra[key] = value;
    }

    public object getExtra(string key)
    { // 获取额外信息
        object result = null;
        if (extra != null)
        {
            result = extra.TryGetValue(key, out result);
        }
        return result;
    }

    public void setupTarget(string src, string target)
    { // 设置事件源和目标
        eventSource = src;
        dispatchTarget = target;
    }
}