using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _wight;
    [SerializeField] private int _height;
    [SerializeField] private Tile _floorTile;
    [SerializeField] private Tile _wallTile;

    [SerializeField] private Transform _cam;
    [SerializeField] [Range(0, 1)] private float _wallSpawnFrequency;

    private Dictionary<Vector2, Tile> _tiles;

   

    private void Start()
    {
        GenerateGrid();
    }

   

    public void GenerateGrid()
    {
        GenerateGrid_Internal();

        Camera.main.transform.position = GetFindCenter();
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

                if (IsFindCenter(x, y))
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


    private bool IsFindCenter(int x, int y)
    {
        var center = GetFindCenter();
        return (int)center.x == x && (int)center.y == y;

    }
    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile))
            return tile;
        return null;

    }

    private Vector3 GetFindCenter()
        => new(((float)_wight / 2) - 0.5f, (float)_height / 2 - 0.5f, -10);

    public Vector2 GetRandomPosition()
    {
        //throw new System.NotImplementedException(); //

        int x = UnityEngine.Random.Range(0, _wight);
        int y = UnityEngine.Random.Range(0, _height);
        


        return new Vector2(x, y);
    }

    


}
