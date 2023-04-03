using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //�������� �������� � ������� � ����������� �� �� �����, � �� ���������� ����� ������ 
    [SerializeField] private GameObject[] _objectsToSpawn;

    public Tile[] TileFilter;        
    private int _shieldCount = 0;


    private void SpawnObject<T>(Vector2 transform) where T : MonoBehaviour, IItem
    {
        var obj = _objectsToSpawn.First(o => o.GetComponent<T>() != null);
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

        if (tile != null && tile.IsEmpty && canPlaceItem)
        {
            var item = Instantiate(obj, transform, Quaternion.identity).GetComponent<IItem>(); //Quaternion.identity - ������������ ��� ��������� �������� ���������� ������� �� �������� �� ���������. transform.position ������ 
            tile.PutItem(item);

            item.Init(tile);
        }
    }

    internal void Spawn(int maxBombCount, int maxShieldCount)
    {
        _shieldCount++;       

        if (_shieldCount >= 5)
        {
            SpawnObject<Shield>(SceneContext.GridManager.GetRandomPosition());
            _shieldCount = 0;            
        }
        for (int i = 0; i < maxBombCount; i++)
        {
            SpawnObject<Bomb>(SceneContext.GridManager.GetRandomPosition());
        }


    }
}
