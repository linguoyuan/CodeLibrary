using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSender : MonoBehaviour
{
    private EventCenter eventCenter; // 事件分发中心引用
    // Start is called before the first frame update
    void Start()
    {
        eventCenter = GameObject.Find("EventCenter").GetComponent<EventCenter>();
    }

    public void NewMethod()
    {
        EventMoveCube move = new EventMoveCube(1)
        {
            what = 1,
            eventSource = "Cylinder",
            dispatchTarget = "evevt1",
            isBroadcast = true
        };
        eventCenter.dispatchEnqueue(move);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
