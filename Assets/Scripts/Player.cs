using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 targetPosition;
    public float speed = 1f;
    private float _moveTrashhold;

    public event Action OnPlayerEndTurn;

    private void Update()
    {
        if(Input.GetMouseButton(0) && isMoving != true)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);
            if (transform.position.x - targetPosition.x < _moveTrashhold 
                && transform.position.y - targetPosition.y < _moveTrashhold)
            {
                isMoving = false;
                OnPlayerEndTurn?.Invoke();
            }
        }
    }

    internal void Init(Vector2 startPositon)
    {
        throw new NotImplementedException();
    }
}


