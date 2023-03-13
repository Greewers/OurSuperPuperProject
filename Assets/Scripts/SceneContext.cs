using System;
using UnityEngine;

public class SceneContext : MonoBehaviour
{
    public static GridManager GridManager;

    private void Awake()
    {
        GridManager = FindObjectOfType<GridManager>();
    }

}

public class Bootstraper : MonoBehaviour
{
    private void Awake()
    {
        SceneContext.GridManager.GenerateGrid();
        //SceneContext.Payer.Instantiate();

    }

    private void Start()
    {
        var player = new Player();
        player.OnPlayerEndTurn += OnPlayerEndTurn;

    }

    private void OnPlayerEndTurn()
    {
        Debug.Log("end turn");

    }
}


/*
 * Field Updates
 * Player turn
 */

  

public class Player : MonoBehaviour
{
    public event Action OnPlayerEndTurn;

    private void Update()
    {

        /* if (moouse.Boot.Down())
         * 
         * 
         * if (Input.GetMouseButtonDown(0))
         * {
         * 
         * }
         * 
         /* {
         * Move(Mouse.Position); */
        OnPlayerEndTurn?.Invoke();

        /*} 
        */

    }





}


