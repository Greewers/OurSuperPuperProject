using System.Collections;
using System.Collections.Generic;

public class SpawnState : BaseState
{
    private ObjectSpawner _objectSpawner { get; }
    private SpawnSettings _spawnSettings { get; }

    public SpawnState(string name, StateMachine stateMachine, ObjectSpawner objectSpawner, SpawnSettings spawnSettings) : base(name, stateMachine)
    {
        _objectSpawner = objectSpawner;
        _spawnSettings = spawnSettings;
    }

    public override void Enter()
    {
        _objectSpawner.Spawn(_spawnSettings.MaxBombCount);
        _stateMachine.ChangeState(typeof(PlayerMoveState));
    }

    public override void Exit()
    {

    }

}
