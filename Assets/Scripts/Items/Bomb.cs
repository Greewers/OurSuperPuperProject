using TMPro;
using UnityEngine;

public class Bomb : MonoBehaviour, IItem
{
    [SerializeField][Range(1, 10)] private int _bombTimer = 3;
    [SerializeField] private TMPro.TextMeshProUGUI _textMeshPro;
     private Tile _cureentTile;

    public void Init(Tile tile)
    {
        _cureentTile = tile;
        _textMeshPro.text = _bombTimer.ToString();
    }

    public void UpdateTimer()
    {

        if (_bombTimer > 1)
        {
            _bombTimer--;
            _textMeshPro.text = _bombTimer.ToString();
        }
        else
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        _cureentTile.PutItem(null);
        Destroy(gameObject);
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