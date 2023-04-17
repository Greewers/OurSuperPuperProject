using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static GridManager GridManager;
    public static ObjectSpawner ObjectSpawner;
    public static Tile Tile;
    public static ScoreCount ScoreCount;
    public static InGameUIController InGameUIController;
    public static GlobalOptions GlobalOptions;

    public static void Init()
    {
        GridManager = FindObjectOfType<GridManager>();
        InGameUIController = FindObjectOfType<InGameUIController>();
        ObjectSpawner = FindObjectOfType<ObjectSpawner>();
        ScoreCount = FindObjectOfType<ScoreCount>();
        //Все что на сцене
    }
}