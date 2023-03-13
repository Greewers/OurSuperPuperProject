<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

=======
using UnityEngine;


>>>>>>> RandomPosition_KostinCode
public class ObjectSpawner : MonoBehaviour
{
    //�������� �������� � ������� � ����������� �� �� �����, � �� ���������� ����� ������ 

    public GameObject[] objectsToSpawn;
<<<<<<< HEAD
=======
    public Tile[] TileFilter;
>>>>>>> RandomPosition_KostinCode
    public float spawnDelay = 1f; // ������� ������

    private float timeSinceLastSpawn = 0f; //����������, ����� �����������, ������� ������� ������ � ������� �������� ���������� �������

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {
<<<<<<< HEAD
            SpawnObject();//������� ��������� ����� ������
=======

            SpawnObject(SceneContext.GridManager.GetRandomPosition()); //������� ��������� ����� ������
>>>>>>> RandomPosition_KostinCode
            timeSinceLastSpawn = 0f;
        }
    }

<<<<<<< HEAD
    void SpawnObject(Transform transform) //�������� ��������� ������ �� ������� objectsToSpawn � ������� ��� ��������� � ������� GameObject
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity); //Quaternion.identity - ������������ ��� ��������� �������� ���������� ������� �� �������� �� ���������. transform.position ������ 
    }
=======
    void SpawnObject(Vector2 transform) //�������� ��������� ������ �� ������� objectsToSpawn � ������� ��� ��������� � ������� GameObject
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
            Instantiate(objectsToSpawn[randomItem], transform, Quaternion.identity); //Quaternion.identity - ������������ ��� ��������� �������� ���������� ������� �� �������� �� ���������. transform.position ������ 
        }

    }


        
>>>>>>> RandomPosition_KostinCode
}
