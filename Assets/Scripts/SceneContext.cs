using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static GridManager GridManager;
    public static Player Player;
    public static ObjectSpawner ObjectSpawner;

    private void Awake()
    {
        Debug.Log("Zalupa");
        GridManager = FindObjectOfType<GridManager>();
        Player = FindObjectOfType<Player>();
        //Все что на сцене
    }
}