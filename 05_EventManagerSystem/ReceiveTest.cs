using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveTest : BaseEventObject
{
    public override string getTagName()
    {
        return "evevt1";
    }

    protected override void execute()
    {
        //Debug.Log("这里每帧都执行一次");
    }

    protected override void handleEvent(MBaseEvent e)
    {
        Debug.Log("1------收到方法，处理中....");
    }

}
