using System;
using System.Collections.Generic;

public class StateMachine
{
    protected BaseState _currentState;
    public Dictionary<Type, BaseState> _states;

    public StateMachine(ObjectSpawner objectSpawner, SpawnSettings spawnSettings, Player player, GridManager gridManager, GlobalOptions globalOptions, InGameUIController inGameUIController)
    {
        _states = new Dictionary<Type, BaseState>()
        {
            { typeof(SpawnState), new SpawnState(nameof(SpawnState), this, objectSpawner, spawnSettings) },
            { typeof(PlayerMoveState), new PlayerMoveState(nameof(PlayerMoveState), this, player) },
            { typeof(UpdateFieldState), new UpdateFieldState(nameof(UpdateFieldState), this, gridManager, globalOptions, player) },
            { typeof(EndState), new EndState(nameof(EndState), this, inGameUIController) }
            //Докинуть стейты - done
        };
    }

    public void Initialize()
    {
        _currentState = _states[typeof(SpawnState)];
        _currentState.Enter();
    }

    public void ChangeState(Type type)
    {
        _currentState.Exit();

        _currentState = _states[type];
        _currentState.Enter();
    }

}
