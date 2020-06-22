using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receiver : MonoBehaviour
{
    public Text receiveText1 = null;
    public Text receiveText2 = null;

    private void Awake()
    {
        //带参数回调

        //注册方法1 写法一：
        EventManager.AddEvent<float>(EventTypeList.EventType1, OnNumberChangeEventHandler);

        //注册方法2 写法二：
        EventManager.AddEvent(EventTypeList.EventType1, delegate (float arg) 
        {
            receiveText2.text = (Convert.ToInt32(arg*100)).ToString();
        });

        //无参回调
        EventManager.AddEvent(EventTypeList.EventType2, delegate () 
        {
            Debug.Log("无参回调");
        });

        EventManager.AddEvent(EventTypeList.EventType3, OnBtnClick);

    }

    private void OnBtnClick()
    {
        Debug.Log("点击了按键");
    }

    /// <summary>
    /// 事件处理方法
    /// </summary>
    /// <param name="arg"></param>
    private void OnNumberChangeEventHandler(float arg)
    {
        receiveText1.text = (Convert.ToInt32(arg*100)).ToString();
    }


}
