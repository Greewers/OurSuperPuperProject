using UnityEngine;

public class EndState : BaseState
{
    private InGameUIController _inGameUIController { get; }
    public EndState(string name, StateMachine stateMachine, InGameUIController inGameUIController) : base(name, stateMachine)
    {
        _inGameUIController = inGameUIController;
    }

    public override void Enter()
    {
        Debug.Log("GAME OVER");
        _inGameUIController.GameEnd();
    }

    public override void Exit()
    {

    }
}