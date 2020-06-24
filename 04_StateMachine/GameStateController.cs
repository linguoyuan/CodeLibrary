using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController
{
    private IGameState mState;

    public void SetState(IGameState state)
    {
        if (mState != null)
        {
            mState.StateEnd();//上一个状态的清理工作
        }
        mState = state;//切换状态
        mState.StateStart();//当前状态的初始化工作
        mState.StateHandler();//当前状态要处理的事情
    }

    public void StateUpdate()
    {
        if (mState != null)
        {
            mState.StateUpdate();//这个状态要处理的事情
        }
    }
}
