using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnPlayerEndTurn;
    public event Action OnPlayerKilled;
    public bool IsDead { get; private set; } = false;

    [SerializeField, Range(0, 10)]
    private float _speed = 1f;
    [SerializeField]
    private List<Tile> _filter = new List<Tile>();

    private List<IPlayerItem> _items = new List<IPlayerItem>();
    private GridManager _gridManager = SceneContext.GridManager;
    private bool _canMoving = false;
    private bool _isMoving = false;
    private Vector2 _targetPosition;
    private float _moveTrashhold = 0.01f;
    private Tile _currentPosition;
    private List<Tile> _neighborTiles = new List<Tile>();

    private void Awake()
    {
        _currentPosition = GetCurrentPosition();
        _gridManager.OnExplosion += OnExplosion;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _canMoving)
        {
            _targetPosition = Vector2Int.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            var tile = _gridManager.GetTileAtPosition(_targetPosition);

            if (CanMove(tile))
            {
                foreach (var t in _neighborTiles)
                    _gridManager.HighLight(t, false);

                _isMoving = true;
                _canMoving = false;
            }
        }

        if (_isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _speed);

            if (Math.Abs(transform.position.x - _targetPosition.x) < _moveTrashhold
                && Math.Abs(transform.position.y - _targetPosition.y) < _moveTrashhold)
            {
                _isMoving = false;
                _currentPosition = GetCurrentPosition();

                PickItem();

                OnPlayerEndTurn?.Invoke();
            }
        }
    }

    public void MarkMovebleTiles()
    {
        _neighborTiles = _gridManager.FindNeighbors(_currentPosition);
        foreach (var tile in _neighborTiles)
        {
            if (CanMove(tile))
                _gridManager.HighLight(tile, true);
        }
    }

    private void PickItem()
    {
        if (_currentPosition.Item?.Pickupble() ?? false)
        {
            var item = _currentPosition.PickItem();
            if (item != null)
            {
                Debug.Log("Item has been picked");
                _items.Add(item);
            }
        }
    }

    private bool CanMove(Tile tile)
        => tile != null
            && _neighborTiles.Contains(tile)
            && _filter.Any(t => t.GetType() == tile.GetType())
            && tile.IsEmpty;

    private Tile GetCurrentPosition()
        => _gridManager.GetTileAtPosition(Vector2Int.RoundToInt(gameObject.transform.position));

    public void AllowMoving()
        => _canMoving = true;

    public Player PlayerSpawn(Vector2 startPositon)
        => Instantiate(this, startPositon, Quaternion.identity);

    private void Kill()
    {
        var shield = _items.FirstOrDefault(i => i.GetType() == typeof(ShieldPlayerItem));
        if (shield != null)
            _items.Remove(shield);
        else
        {
            IsDead = true;
            OnPlayerKilled?.Invoke();
        }
    }

    private void OnExplosion(List<Tile> tiles)
    {
        foreach (var tile in tiles)
        {
            if (_currentPosition == tile)
            {
                Kill();
                return;
            }
        }
    }
}