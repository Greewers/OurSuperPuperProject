using TMPro;
using UnityEngine;

public class Shield : MonoBehaviour, ITileItem
{
    [SerializeField][Range(1, 10)] private int _sheildTimer = 5;
    [SerializeField] private TMPro.TextMeshProUGUI _textMeshPro;

    private Tile _cureentTile;

    public IPlayerItem PlayerItem { get ; private set; }

    public void Init(Tile tile)
    {
        _cureentTile = tile;
        _textMeshPro.text = _sheildTimer.ToString();
        PlayerItem = new ShieldPlayerItem();
    }

    public bool Pickupble() => true;

    public void UpdateTimer()
    {
        if (_sheildTimer > 1)
        {
            _sheildTimer--;
            _textMeshPro.text = _sheildTimer.ToString();
        }
        else
        {
            ItemDestroy();
        }
    }

    public void ItemDestroy()
    {
        Destroy(gameObject);
        _cureentTile.PutItem(null);
    }
}