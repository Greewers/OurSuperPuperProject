using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFieldState : BaseState
{
    public GridManager GridManager { get; }
    public GlobalOptions GlobalOptions { get; }

    public UpdateFieldState(string name, StateMachine stateMachine, GridManager gridManager, GlobalOptions globalOptions) : base(name, stateMachine)
    {
        GridManager = gridManager;
        GlobalOptions = globalOptions;
    }

    public override void Enter()
    {
        /*var tiles = GridManager.GetAllTile();
        foreach (var tile in tiles)
        {
            tile.Item.UpdateTimer();
        }

        GlobalOptions.ScoreIncriment();

        _stateMachine.ChangeState(typeof(SpawnState));*/
    }

    public override void Exit()
    {
    }
}