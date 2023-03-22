using System;
using System.Collections.Generic;

public class StateMachine
{
    protected BaseState _currentState;
    public Dictionary<Type, BaseState> _states;

    public StateMachine(ObjectSpawner objectSpawner, SpawnSettings spawnSettings, Player player, GridManager gridManager, GlobalOptions globalOptions)
    {
        _states = new Dictionary<Type, BaseState>()
        {
            { typeof(SpawnState), new SpawnState("Появление игрока и бомб", this, objectSpawner, spawnSettings) },
            { typeof(PlayerMoveState), new PlayerMoveState("Перемещение игрока", this, player) },
            { typeof(UpdateFieldState), new UpdateFieldState("Обновление элементов на поле", this, gridManager, globalOptions) }
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
