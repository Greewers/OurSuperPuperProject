using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _canMoving = false;
    private bool _isMoving = false;
    private Vector2 _targetPosition;
    public float _speed = 1f;
    private float _moveTrashhold = 0.01f;
    private Vector2 _currentPosition;
    private List<Tile> _neighborTiles = new List<Tile>();

    public event Action OnPlayerEndTurn;

    private void Start()
    {
        _currentPosition = this.transform.position;
        _neighborTiles = SceneContext.GridManager.FindNeighbors(SceneContext.GridManager.GetTileAtPosition(_currentPosition));
        //Запомнить свой тайл
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _canMoving)
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition = new Vector2((int)_targetPosition.x,(int)_targetPosition.y);
            var tile = SceneContext.GridManager.GetTileAtPosition(_targetPosition);
            _targetPosition = tile.transform.position;
            //запросить у грида соседние тайлы
            //Если тот тайл на который вы кликнули соседний
            if(_neighborTiles.Contains(tile))
            {
                _isMoving = true;
                _canMoving = false;

            }

        }

        if (_isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.fixedDeltaTime * _speed);
            if (Math.Abs(transform.position.x - _targetPosition.x) < _moveTrashhold
                && Math.Abs(transform.position.y - _targetPosition.y) < _moveTrashhold)
            {
                _isMoving = false;
                _currentPosition = this.transform.position;
                _neighborTiles = SceneContext.GridManager.FindNeighbors(SceneContext.GridManager.GetTileAtPosition(_currentPosition));
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


