using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    /// <summary>
    /// 带返回参数的回调列表,参数类型为T，支持一对多
    /// </summary>
    public static Dictionary<EventTypeList, List<Delegate>> events = new Dictionary<EventTypeList, List<Delegate>>();

    /// <summary>
    /// 通用注册事件方法
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    private static void CommonAdd (EventTypeList eventName, Delegate callback)
    {
        List<Delegate> actions = null;

        //eventName已存在
        if (events.TryGetValue(eventName, out actions))
        {
            actions.Add(callback);
        }
        //eventName不存在
        else
        {
            actions = new List<Delegate>();

            actions.Add(callback);
            events.Add(eventName, actions);
        }
    }
    #region Add
    /// <summary>
    /// 注册事件，0个返回参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public static void AddEvent(EventTypeList eventName, Action callback)
    {
        CommonAdd(eventName, callback);
    }

    /// <summary>
    /// 注册事件，1个返回参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public static void AddEvent<T> (EventTypeList eventName, Action<T> callback)
    {
        CommonAdd(eventName, callback);
    }
    /// <summary>
    /// 注册事件，2个返回参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public static void AddEvent<T, T1>(EventTypeList eventName, Action<T, T1> callback)
    {
        CommonAdd(eventName, callback);
    }
    /// <summary>
    /// 注册事件，3个返回参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public static void AddEvent<T, T1, T2>(EventTypeList eventName, Action<T, T1, T2> callback)
    {
        CommonAdd(eventName, callback);
    }
    #endregion
    /// <summary>
    /// 通用移除事件的方法
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    private static void CommonRemove (EventTypeList eventName, Delegate callback)
    {
        List<Delegate> actions = null;

        if (events.TryGetValue(eventName, out actions))
        {
            actions.Remove(callback);
            if (actions.Count == 0)
            {
                events.Remove(eventName);
            }
        }
    }
    #region Remove
    /// <summary>
    /// 移除事件 0参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public static void RemoveEvent(EventTypeList eventName, Action callback)
    {
        CommonRemove(eventName, callback);
    }

    /// <summary>
    /// 移除事件 1个参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public static void RemoveEvent<T>(EventTypeList eventName, Action<T> callback)
    {
        CommonRemove(eventName, callback);
    }

    /// <summary>
    /// 移除事件 2个参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public static void RemoveEvent<T, T1>(EventTypeList eventName, Action<T, T1> callback)
    {
        CommonRemove(eventName, callback);
    }
    /// <summary>
    /// 移除事件 3个参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public static void RemoveEvent<T, T1, T2>(EventTypeList eventName, Action<T, T1, T2> callback)
    {
        CommonRemove(eventName, callback);
    }

    /// <summary>
    /// 移除全部事件
    /// </summary>
    public static void RemoveAllEvents ()
    {
        events.Clear();
    }
    #endregion
    #region DispatchEvent
    /// <summary>
    /// 派发事件，0参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="arg"></param>
    public static void DispatchEvent(EventTypeList eventName)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);

            foreach (var act in actions)
            {
                act.DynamicInvoke();
            }
        }
    }

    /// <summary>
    /// 派发事件 1个参数
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="arg"></param>
    public static void DispatchEvent<T>(EventTypeList eventName, T arg)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);

            foreach (var act in actions)
            {
                act.DynamicInvoke(arg);
            }
        }
    }

    /// <summary>
    /// 派发事件 2个参数
    /// </summary>
    /// <param name="eventName">事件名</param>
    /// <param name="arg">参数1</param>
    /// <param name="arg2">参数2</param>
    public static void DispatchEvent<T, T1>(EventTypeList eventName, T arg, T1 arg2)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);

            foreach (var act in actions)
            {
                act.DynamicInvoke(arg, arg2);
            }
        }
    }

    /// <summary>
    /// 派发事件 3个参数
    /// </summary>
    /// <param name="eventName">事件名</param>
    /// <param name="arg">参数1</param>
    /// <param name="arg2">参数2</param>
    /// <param name="arg3">参数3</param>
    public static void DispatchEvent<T1, T2, T3>(EventTypeList eventName, T1 arg, T2 arg2, T3 arg3)
    {
        List<Delegate> actions = null;

        if (events.ContainsKey(eventName))
        {
            events.TryGetValue(eventName, out actions);

            foreach (var act in actions)
            {
                act.DynamicInvoke(arg, arg2, arg3);
            }
        }
    }
    #endregion
}

