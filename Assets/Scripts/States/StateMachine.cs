using System;
using System.Collections.Generic;

public class StateMachine
{
    protected BaseState _currentState;
    public Dictionary<Type, BaseState> _states;

    public StateMachine(ObjectSpawner objectSpawner, SpawnSettings spawnSettings)
    {
        _states = new Dictionary<Type, BaseState>()
        {
            { typeof(SpawnState), new SpawnState("asdasd", this, objectSpawner, spawnSettings) },
            //Докинуть стейты
            //{ typeof(PlayerMoveState), new PlayerMoveState("asdasd", this, objectSpawner, spawnSettings) }
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
