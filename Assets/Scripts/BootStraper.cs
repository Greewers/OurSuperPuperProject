using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStraper : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;

    private StateMachine _stateMachine;
    private SpawnSettings _spawnSettings;
    private GlobalOptions _globalOptions;

    public void Awake()
    {
        SceneContext.Init();
        SceneContext.GridManager.GenerateGrid();

        _globalOptions = new GlobalOptions();
        var player = playerPrefab.PlayerSpawn(SceneContext.GridManager.FindCenter());

        _spawnSettings = Resources.Load<SpawnSettings>("LowDificulty");
        _stateMachine = new StateMachine(SceneContext.ObjectSpawner, _spawnSettings, player, SceneContext.GridManager, _globalOptions);
        _stateMachine.Initialize();

    }


}
