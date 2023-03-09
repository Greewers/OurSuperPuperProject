using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField] private int _wight, _height;
    [SerializeField] private Tile _floorTile, _wallTile;
    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        instance = this;
    }

    public void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _wight; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var randomTile = Random.Range(0,10) ==   3 ? _wallTile : _floorTile; 
                var spawnedTile = Instantiate(randomTile, new Vector3(x,y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

       
                spawnedTile.Init(x,y);

                _tiles[new Vector2(x,y)] = spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_wight/2 -0.5f, (float)_height/ 2 - 0.5f,-10);

        GameManager.instance.ChangeState(GameState.SpawnHero);
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;

    }
}
