using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    //добавить привязку к клеткам и отсеживание не на время, а на количество ходов игрока 
    [SerializeField] private GameObject[] _objectsToSpawn;

    public Tile[] TileFilter;

    private void SpawnObject<T>(Vector2 transform) where T : MonoBehaviour, ITileItem
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

        if (tile != null && tile.Item == null && canPlaceItem)
        {
            var item = Instantiate(obj, transform, Quaternion.identity).GetComponent<ITileItem>(); //Quaternion.identity - используется для установки поворота созданного объекта на вращение по умолчанию. transform.position добить 
            tile.PutItem(item);

            item.Init(tile);
        }
    }

    internal void Spawn(int bombCount, int shieldCount)
    {

        for (int i = 0; i < shieldCount; i++)
        {
            SpawnObject<Shield>(SceneContext.GridManager.GetRandomPosition());
        }

        for (int i = 0; i < bombCount; i++)
        {
            SpawnObject<Bomb>(SceneContext.GridManager.GetRandomPosition());
        }


    }
}
