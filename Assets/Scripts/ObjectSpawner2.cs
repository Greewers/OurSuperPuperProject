using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//чисто нейронка сделала
public class ObjectSpawner2 : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private BaseObjects[] _objectsToSpawn;
    [SerializeField] private int _maxAttempts = 10;

    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        int attempts = 0;
        bool objectSpawned = false;

        while (!objectSpawned && attempts < _maxAttempts)
        {
            int x = Random.Range(0, _gridManager.Wight);
            int y = Random.Range(0, _gridManager.Height);

            Tile tile = _gridManager.GetTileAtPosition(new Vector2(x, y));

            if (tile != null && tile.Walkable)
            {
                BaseObjects objectToSpawn = _objectsToSpawn[Random.Range(0, _objectsToSpawn.Length)];
                Instantiate(objectToSpawn, tile.transform.position, Quaternion.identity);
                tile.OccupiedObject = objectToSpawn;
                objectSpawned = true;
            }
            else
            {
                attempts++;
            }
        }
    }
}
