using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //�������� �������� � ������� � ����������� �� �� �����, � �� ���������� ����� ������ 

    public GameObject[] objectsToSpawn;
    public Tile[] TileFilter;
    public float spawnDelay = 1f; // ������� ������

    private float timeSinceLastSpawn = 0f; //����������, ����� �����������, ������� ������� ������ � ������� �������� ���������� �������

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {

            SpawnObject(SceneContext.GridManager.GetRandomPosition()); //������� ��������� ����� ������
            timeSinceLastSpawn = 0f;
        }
    }

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


        
}
