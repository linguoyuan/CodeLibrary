using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEventObject : MonoBehaviour
{
    protected Queue<MBaseEvent> eventQueue = new Queue<MBaseEvent>(); // 事件队列
    protected EventCenter eventCenter; // 事件分发中心引用

    // ------ 事件进入缓冲队列
    public void EnqueueEvent(MBaseEvent e)
    {
        lock (eventQueue)
        {
            eventQueue.Enqueue(e);
            if (e.needWakeUp && !gameObject.activeSelf)
            {
                setActive(true);
            }
        }
    }

    // ------ 从缓冲队列中取事件
    protected MBaseEvent DequeueEvent()
    {
        MBaseEvent result = null;
        lock (eventQueue)
        {
            if (eventQueue.Count > 0)
            {
                result = eventQueue.Dequeue();
            }
        }
        return result;
    }

    protected abstract void execute(); // 帧更新时调用的执行方法，子类实现
    public abstract string getTagName(); // 获取当前子类对应的事件分发表键名
    protected abstract void handleEvent(MBaseEvent e); // 事件处理方法，子类实现
    protected virtual void release()
    { // 子类可重写用于对象回收时释放资源
        lock (eventQueue)
        {
            eventQueue.Clear();
        }
    }

    public void setActive(bool active)
    {
        gameObject.SetActive(active);
    }

    void Start()
    {
        eventCenter = GameObject.Find("EventCenter").GetComponent<EventCenter>();
        // 自动注册本类实例到事件分发表
        eventCenter.registerEventObject(getTagName(), this);
    }

    void Update()
    {
        try
        {
            execute(); // 子类实现更新调用
            MBaseEvent e = DequeueEvent(); // 取出一个待处理事件
            if (e != null)
            {
                handleEvent(e);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.StackTrace);
        }
    }

    private void OnDestroy()
    {
        release();
        eventCenter.unregisterEventObject(getTagName(), this);
    }
}