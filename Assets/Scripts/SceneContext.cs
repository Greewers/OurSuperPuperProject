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
    private bool isMoving = false;
    private Vector3 targetPosition;
    public float speed = 1f;



    public event Action OnPlayerEndTurn;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }


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


