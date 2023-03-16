using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static GridManager GridManager;
    public static Player Player;
    public static ObjectSpawner ObjectSpawner;

    private void Awake()
    {
        GridManager = FindObjectOfType<GridManager>();
        Player = FindObjectOfType<Player>();
        //Все что на сцене
    }

}

public class Bootstraper : MonoBehaviour
{
    private StateMachine _stateMachine;
    private SpawnSettings _spawnSettings;

    private void Awake()
    {
        SceneContext.GridManager.GenerateGrid();
        SceneContext.Player.Init(SceneContext.GridManager.FindCenter());

        _spawnSettings = Resources.Load<SpawnSettings>("Assets/Settings/Resources/LowDificulty.asset");
        _stateMachine = new StateMachine(SceneContext.ObjectSpawner, _spawnSettings);
        _stateMachine.Initialize();
    }
}


