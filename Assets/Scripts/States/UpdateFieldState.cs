using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFieldState : BaseState
{
    public GridManager GridManager { get; }
    public GlobalOptions GlobalOptions { get; }

    public UpdateFieldState(string name, StateMachine stateMachine, GridManager gridManager, GlobalOptions globalOptions, Player player) : base(name, stateMachine)
    {
        GridManager = gridManager;
        GlobalOptions = globalOptions;
        player.OnPlayerKilled += OnPlayerKilled;
    }

    private void OnPlayerKilled() 
        => _stateMachine.ChangeState(typeof(EndState));


    public override void Enter()
    {
        var items = GridManager.GetAllItem();
        foreach (var item in items)
        {
            item.UpdateTimer();
        }

        //GlobalOptions.ScoreIncriment();

        _stateMachine.ChangeState(typeof(SpawnState));
    }

    public override void Exit()
    {
    }
}

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