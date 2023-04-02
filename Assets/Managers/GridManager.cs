using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _wight;
    [SerializeField] private int _height;
    [SerializeField] private Tile _floorTile;
    [SerializeField] private Tile _wallTile;

    [SerializeField] private Transform _cam;
    [SerializeField][Range(0, 1)] private float _wallSpawnFrequency;

    private Dictionary<Vector2, Tile> _tiles;
    private List<Vector2> offsetList = new List<Vector2>() { new Vector2(0, -1), new Vector2(-1, -1), new Vector2(-1, 0), new Vector2(0, +1), new Vector2(+1, +1), new Vector2(-1, 0) } ;

public void GenerateGrid()
    {
        GenerateGrid_Internal();

        Camera.main.transform.position = FindCenter();
    }

    private void GenerateGrid_Internal()
    {
        _wallSpawnFrequency = _wallSpawnFrequency * 100;
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _wight; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Tile tile;

                if (IsCenter(x, y))
                {
                    tile = _floorTile;
                }
                else
                {
                    tile = Random.Range(0, 100) > _wallSpawnFrequency ? _floorTile : _wallTile;
                }

                var spawnedTile = Instantiate(tile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(x, y);

                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }

    private bool IsCenter(int x, int y)
    {
        var center = FindCenter();
        return (int)center.x == x && (int)center.y == y;

    }

    public Tile GetTileAtPosition(Vector2 pos)
        => _tiles.TryGetValue(pos, out var tile) ? tile : null;

    public Vector3 FindCenter()
        => new Vector3(((float)_wight / 2) - 0.5f, (float)_height / 2 - 0.5f, -10);

    public Vector2 GetRandomPosition()
        => new Vector2(Random.Range(0, _wight), Random.Range(0, _height));

    public List<Tile> FindNeighbors(Tile currentTile)
    {
        var variantList = new List<Tile>();
        Vector2 currentPosition = currentTile.gameObject.transform.position;

        foreach (Vector2 offset in offsetList)
        {
            var targetPosition = currentPosition + offset;
            var targetTile = GetTileAtPosition(targetPosition);
            variantList.Add(targetTile);
        }

        return variantList;
    }

    internal IItem[] GetAllItem()
    {
        return _tiles.Select(t => t.Value.Item).Where(i => i != null).ToArray();
    }
}
