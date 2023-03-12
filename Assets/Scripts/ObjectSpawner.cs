using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //�������� �������� � ������� � ����������� �� �� �����, � �� ���������� ����� ������ 

    public GameObject[] objectsToSpawn;
    public float spawnDelay = 1f; // ������� ������

    private float timeSinceLastSpawn = 0f; //����������, ����� �����������, ������� ������� ������ � ������� �������� ���������� �������

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {
            SpawnObject();//������� ��������� ����� ������
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnObject(Transform transform) //�������� ��������� ������ �� ������� objectsToSpawn � ������� ��� ��������� � ������� GameObject
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity); //Quaternion.identity - ������������ ��� ��������� �������� ���������� ������� �� �������� �� ���������. transform.position ������ 
    }
}
