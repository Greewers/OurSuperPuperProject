using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //добавить прив€зку к клеткам и отсеживание не на врем€, а на количество ходов игрока 

    public GameObject[] objectsToSpawn;
    public Tile[] TileFilter;
    public float spawnDelay = 1f; // частота спавна

    private float timeSinceLastSpawn = 0f; //переменна€, чтобы отслеживать, сколько времени прошло с момента создани€ последнего объекта

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {

            SpawnObject(SceneContext.GridManager.GetRandomPosition()); //сделать получение точки спавна
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnObject(Vector2 transform) //выбирает случайный объект из массива objectsToSpawn и создает его экземпл€р в позиции GameObject
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
        
        if (tile !=null && tile.Item==null && canPlaceItem)

        {
            int randomItem = Random.Range(0, objectsToSpawn.Length);
            Instantiate(objectsToSpawn[randomItem], transform, Quaternion.identity); //Quaternion.identity - используетс€ дл€ установки поворота созданного объекта на вращение по умолчанию. transform.position добить 
        }

    }


        
}
