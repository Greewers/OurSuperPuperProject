using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //добавить прив€зку к клеткам и отсеживание не на врем€, а на количество ходов игрока 

    public GameObject[] objectsToSpawn;
    public float spawnDelay = 1f; // частота спавна

    private float timeSinceLastSpawn = 0f; //переменна€, чтобы отслеживать, сколько времени прошло с момента создани€ последнего объекта

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {
            SpawnObject();//сделать получение точки спавна
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnObject(Transform transform) //выбирает случайный объект из массива objectsToSpawn и создает его экземпл€р в позиции GameObject
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity); //Quaternion.identity - используетс€ дл€ установки поворота созданного объекта на вращение по умолчанию. transform.position добить 
    }
}
