using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sender : MonoBehaviour
{
    public Slider slider = null;

    public GameObject btn = null;

    private void Awake()
    {
        slider.onValueChanged.AddListener(delegate (float value) 
        {
            Debug.LogFormat("slider:{0}", value);
            //有参分发
            EventManager.DispatchEvent<float>(EventTypeList.EventType1, value);

            //无参分发
            EventManager.DispatchEvent(EventTypeList.EventType2);
        });


        

        btn.GetComponent<Button>().onClick.AddListener(BtnOnClick);
    }

    private void BtnOnClick()
    {
        EventManager.DispatchEvent(EventTypeList.EventType3);
    }
}
