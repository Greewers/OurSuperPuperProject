using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour, ITileItem
{
    [SerializeField][Range(1, 10)] private int _bombTimer = 3;
    [SerializeField] private TMPro.TextMeshProUGUI _textMeshPro;
     private Tile _cureentTile;

    [SerializeField] private Explosion _explosion;


    public IPlayerItem PlayerItem { get; private set; }

    public void Init(Tile tile)
    {
        _cureentTile = tile;
        _textMeshPro.text = _bombTimer.ToString();
        PlayerItem = null;
    }

    public bool Pickupble() => false;

    public void UpdateTimer()
    {

        if (_bombTimer > 1)
        {
            _bombTimer--;
            _textMeshPro.text = _bombTimer.ToString();
        }
        else
        {
            ItemDestroy();
        }
    }

    public void ItemDestroy()
    {
        Instantiate(_explosion, transform.position, transform.rotation);
        _cureentTile.PutItem(null);
        Destroy(gameObject);

        SceneContext.GridManager.Explosion(_cureentTile);

        //через OccupiedObject
    }
}

//public class Shield : MonoBehaviour, IItem
//{
//    public void UpdateTimer()
//    {
//        throw new System.NotImplementedException();
//    }
//}