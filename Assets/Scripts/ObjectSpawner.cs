using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //добавить прив€зку к клеткам и отсеживание не на врем€, а на количество ходов игрока 
    private GameObject[] _objectsToSpawn;

    public Tile[] TileFilter;

    void SpawnObjectBombs(Transform transform) //выбирает случайный объект из массива objectsToSpawn и создает его экземпл€р в позиции GameObject
    {
        int randomIndex = Random.Range(0, _objectsToSpawn.Length);
        Instantiate(_objectsToSpawn[randomIndex], transform.position, Quaternion.identity); //Quaternion.identity - используетс€ дл€ установки поворота созданного объекта на вращение по умолчанию. transform.position добить 
    }

    void SpawnObject<T>(Transform transform)
    {
        GameObject gObj = null;
        foreach (var obj in _objectsToSpawn)
        {
            //Ќе уверн что сработает правильно приведение типов
            if (obj is T)
            { 
                gObj = obj;
                break;
            }
        }

        Instantiate(gObj, transform.position, Quaternion.identity); //Quaternion.identity - используетс€ дл€ установки поворота созданного объекта на вращение по умолчанию. transform.position добить 
    }

    void SpawnRandomObject(Vector2 transform) //выбирает случайный объект из массива objectsToSpawn и создает его экземпл€р в позиции GameObject
    {
        var tile = SceneContext.GridManager.GetTileAtPosition(transform);

        bool canPlaceItem = false;
        foreach (var t in TileFilter)
        {
            canPlaceItem = t.GetType() == tile.GetType();
            if (canPlaceItem == true)
            {
                break;
            }
        }

        if (tile != null && tile.Item == null && canPlaceItem)
        {
            int randomItem = Random.Range(0, _objectsToSpawn.Length + 1);
            Instantiate(_objectsToSpawn[randomItem], transform, Quaternion.identity); //Quaternion.identity - используетс€ дл€ установки поворота созданного объекта на вращение по умолчанию. transform.position добить 
        }

    }

    internal void Spawn(int maxItemCount)
    {
        for (int i = 0; i < maxItemCount; i++)
        {
            SpawnRandomObject(SceneContext.GridManager.GetRandomPosition());
        }
    }
}
