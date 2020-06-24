using System.Collections;
using System.Collections.Generic;

public class EndState : IGameState
{
    public EndState(GameStateController controller) : base(controller)
    {
    }

    public override void StateStart()
    {
        base.StateStart();
    }

    public override void StateEnd()
    {
        base.StateEnd();
    }

    public override void StateHandler()
    {
        base.StateHandler();
        //"执行流程1"
        //"执行流程2"
        mController.SetState(new StartState(mController));
    }

    public override void StateUpdate()
    {
        base.StateUpdate();
    }

    public bool CheckCard()
    {
        return false;
    }
}
