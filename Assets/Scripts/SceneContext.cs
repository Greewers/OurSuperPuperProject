using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static GridManager GridManager;
    public static ObjectSpawner ObjectSpawner;

    public static void Init()
    {
        GridManager = FindObjectOfType<GridManager>();
        //Все что на сцене
    }
}