using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _canMoving = false;
    private bool _isMoving = false;
    private Vector3 _targetPosition;
    public float _speed = 1f;
    private float _moveTrashhold = 0.01f;

    public event Action OnPlayerEndTurn;

    private void Start()
    {
        //Запомнить свой тайл
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && _canMoving)
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //запросить у грида соседние тайлы
            //Если тот тайл на который вы кликнули соседний
            _isMoving = true;
            _canMoving = false;
        }

        if (_isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.fixedDeltaTime * _speed);
            if (Math.Abs( transform.position.x - _targetPosition.x) < _moveTrashhold 
                && Math.Abs(transform.position.y - _targetPosition.y) < _moveTrashhold)
            {
                _isMoving = false;
                //Запомнить свой тайл
                OnPlayerEndTurn?.Invoke();
            }
        }
    }

    public void AllowMoving()
    {
        _canMoving = true;
    }

    public Player PlayerSpawn(Vector2 startPositon) 
        => Instantiate(this, startPositon, Quaternion.identity);
}


