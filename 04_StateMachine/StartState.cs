using System.Collections;
using System.Collections.Generic;

public class StartState : IGameState
{
    public StartState(GameStateController controller) : base(controller)
    {
    }

    public override void StateStart()
    {
        base.StateStart();
    }   

    public override void StateHandler()
    {
        base.StateHandler();
        //处理这个状态需要处理的事情
        //"执行流程1"
        //"执行流程2"
        //由StartState切换到EndState状态
        mController.SetState(new EndState(mController));
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public override void StateEnd()
    {
        base.StateEnd();
    }
}
