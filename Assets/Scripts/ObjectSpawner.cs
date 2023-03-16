using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //�������� �������� � ������� � ����������� �� �� �����, � �� ���������� ����� ������ 
    private GameObject[] _objectsToSpawn;

    public Tile[] TileFilter;

    void SpawnObjectBombs(Transform transform) //�������� ��������� ������ �� ������� objectsToSpawn � ������� ��� ��������� � ������� GameObject
    {
        int randomIndex = Random.Range(0, _objectsToSpawn.Length);
        Instantiate(_objectsToSpawn[randomIndex], transform.position, Quaternion.identity); //Quaternion.identity - ������������ ��� ��������� �������� ���������� ������� �� �������� �� ���������. transform.position ������ 
    }

    void SpawnObject<T>(Transform transform)
    {
        GameObject gObj = null;
        foreach (var obj in _objectsToSpawn)
        {
            //�� ����� ��� ��������� ��������� ���������� �����
            if (obj is T)
            { 
                gObj = obj;
                break;
            }
        }

        Instantiate(gObj, transform.position, Quaternion.identity); //Quaternion.identity - ������������ ��� ��������� �������� ���������� ������� �� �������� �� ���������. transform.position ������ 
    }

    void SpawnRandomObject(Vector2 transform) //�������� ��������� ������ �� ������� objectsToSpawn � ������� ��� ��������� � ������� GameObject
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
            Instantiate(_objectsToSpawn[randomItem], transform, Quaternion.identity); //Quaternion.identity - ������������ ��� ��������� �������� ���������� ������� �� �������� �� ���������. transform.position ������ 
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
