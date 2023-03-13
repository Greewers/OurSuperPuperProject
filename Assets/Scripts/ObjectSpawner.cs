<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

=======
using UnityEngine;


>>>>>>> RandomPosition_KostinCode
public class ObjectSpawner : MonoBehaviour
{
    //добавить прив€зку к клеткам и отсеживание не на врем€, а на количество ходов игрока 

    public GameObject[] objectsToSpawn;
<<<<<<< HEAD
=======
    public Tile[] TileFilter;
>>>>>>> RandomPosition_KostinCode
    public float spawnDelay = 1f; // частота спавна

    private float timeSinceLastSpawn = 0f; //переменна€, чтобы отслеживать, сколько времени прошло с момента создани€ последнего объекта

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {
<<<<<<< HEAD
            SpawnObject();//сделать получение точки спавна
=======

            SpawnObject(SceneContext.GridManager.GetRandomPosition()); //сделать получение точки спавна
>>>>>>> RandomPosition_KostinCode
            timeSinceLastSpawn = 0f;
        }
    }

<<<<<<< HEAD
    void SpawnObject(Transform transform) //выбирает случайный объект из массива objectsToSpawn и создает его экземпл€р в позиции GameObject
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity); //Quaternion.identity - используетс€ дл€ установки поворота созданного объекта на вращение по умолчанию. transform.position добить 
    }
=======
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


        
>>>>>>> RandomPosition_KostinCode
}
