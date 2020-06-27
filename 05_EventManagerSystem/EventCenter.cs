using System.Collections.Generic;
using UnityEngine;

//public interface IMEventHandler
//{
//    void handleEvent(MBaseEvent e); // 事件处理方法
//}

public class EventCenter : MonoBehaviour
{

    private Queue<MBaseEvent> dispatchQueue = new Queue<MBaseEvent>(); // 事件分发队列
    private Dictionary<string, List<BaseEventObject>> dispatchTable = new Dictionary<string, List<BaseEventObject>>(); // 事件分发表
    private bool isDispatching = true;

    void Start()
    {
        //
    }

    // ------ 每一帧都进行分发
    void Update()
    {
        if (isDispatching)
        {
            MBaseEvent dispatchEvent = dispatchDequeue();
            if (dispatchEvent != null)
            { // 队列为空时不分发
                if (dispatchEvent.isBroadcast)
                { // 广播事件不需要考虑目标
                    foreach (List<BaseEventObject> dispatch in dispatchTable.Values)
                    {
                        foreach (BaseEventObject obj in dispatch)
                        {
                            if (obj.gameObject.activeSelf)
                            {
                                obj.EnqueueEvent(dispatchEvent);
                            }
                        }
                    }
                }
                else
                { // 非广播事件需要取到目标对象表
                    //List<BaseEventObject> dispatch = dispatchTable.TryGetValue(dispatchEvent.dispatchTarget, out );
                    List<BaseEventObject> dispatch = dispatchTable[dispatchEvent.dispatchTarget];
                    if (dispatch != null)
                    {
                        foreach (BaseEventObject obj in dispatch)
                        {
                            obj.EnqueueEvent(dispatchEvent);
                        }
                    }
                }
            }
        }
    }

    // ------ 注册分发入口
    public void registerEventObject(string tag, BaseEventObject obj)
    {
        List<BaseEventObject> tempList;
        if (dispatchTable.ContainsKey(tag))
        {
            tempList = dispatchTable[tag];
        }
        else
        {
            tempList = new List<BaseEventObject>();
        }
        tempList.Add(obj);
        dispatchTable[tag] = tempList;
    }

    // ------ 反注册分发入口
    public void unregisterEventObject(string tag, BaseEventObject obj)
    {
        List<BaseEventObject> tempList;
        if (dispatchTable.ContainsKey(tag))
        {
            tempList = dispatchTable[tag];
            tempList.Remove(obj);
            dispatchTable[tag] = tempList;
        }
    }

    // ------ 分发事件入口
    public void dispatchEnqueue(MBaseEvent e)
    {
        lock (dispatchQueue)
        {
            dispatchQueue.Enqueue(e);
        }
    }

    // ------ 取分发事件出队
    private MBaseEvent dispatchDequeue()
    {
        MBaseEvent result = null;
        lock (dispatchQueue)
        {
            if (dispatchQueue.Count > 0)
            {
                result = dispatchQueue.Dequeue();
            }
        }
        return result;
    }

    // ------ 分发开关
    public void dispatchSwitch(bool isOn)
    {
        isDispatching = isOn;
    }
}