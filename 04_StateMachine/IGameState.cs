using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IGameState
{
    protected GameStateController mController;

    public IGameState(GameStateController controller)
    {
        mController = controller;
    }

    //每次进入到这个状态的时候调用
    public virtual void StateStart() { }
    public virtual void StateEnd() { }    
    public virtual void StateHandler() { }
    public virtual void StateUpdate() { }
}
