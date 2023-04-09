using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _leadRound ;
    [SerializeField] private bool _isWalkable; // задает плитке значение проходимости

    private IItem _item; 

    public IItem Item
    {
        get
        {
            return _item;
        }
        private set
        {
            IsEmpty = value == null || value.Pickupble();
            _item = value;
        }
    }

    public bool IsEmpty { get; set; } = true;

    public virtual void Init(int x, int y)
    {

    }

    public virtual IItem PickItem()
    { 
        Item.ItemDestroy();
        Item = null;
        return Item;
    }

    internal virtual void PutItem(IItem item)
    {
        Item = item;
    }

    public void SetLeadRound(bool value)
    {
        _leadRound.SetActive(value);
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
