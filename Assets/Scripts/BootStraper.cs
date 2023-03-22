using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStraper : MonoBehaviour
{

    private StateMachine _stateMachine;
    private SpawnSettings _spawnSettings;
    private GlobalOptions _globalOptions;

    public void Awake()
    {
        Debug.Log("Zalupa2222");
        SceneContext.GridManager.GenerateGrid();
        //SceneContext.Player.Init(SceneContext.GridManager.FindCenter());

        _spawnSettings = Resources.Load<SpawnSettings>("Assets/Settings/Resources/LowDificulty.asset");
        _stateMachine = new StateMachine(SceneContext.ObjectSpawner, _spawnSettings, SceneContext.Player, SceneContext.GridManager, _globalOptions);
        _stateMachine.Initialize();

    }


}
