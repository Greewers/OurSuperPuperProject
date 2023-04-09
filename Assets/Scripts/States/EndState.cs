using UnityEngine;

public class EndState : BaseState
{
    public EndState(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("GAME OVER");
    }

    public override void Exit()
    {

    }
}