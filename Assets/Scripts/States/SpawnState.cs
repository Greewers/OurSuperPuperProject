using System.Collections;
using System.Collections.Generic;

public class SpawnState : BaseState
{
    private int _spawnCount = 0;
    private ObjectSpawner _objectSpawner { get; }
    private SpawnSettings _spawnSettings { get; }

    public SpawnState(string name, StateMachine stateMachine, ObjectSpawner objectSpawner, SpawnSettings spawnSettings) : base(name, stateMachine)
    {
        _objectSpawner = objectSpawner;
        _spawnSettings = spawnSettings;
    }

    public override void Enter()
    {
        _spawnCount++;

        var bombCount = (_spawnCount % _spawnSettings.BombSpawnRate == 0)
            ? _spawnSettings.MaxBombCount
            : 0;

        var shieldCount = (_spawnCount % _spawnSettings.ShieldSpawnRate == 0)
            ? _spawnSettings.MaxShieldCount
            : 0;

        _objectSpawner.Spawn(bombCount, shieldCount);
        _stateMachine.ChangeState(typeof(PlayerMoveState));
    }

    public override void Exit()
    {

    }

}
