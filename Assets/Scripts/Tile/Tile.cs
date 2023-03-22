using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
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
            IsEmpty = value == null;
            _item = value;
        }
    }

    public bool IsEmpty { get; set; } = true;

    public virtual void Init(int x, int y)
    {

    }

    internal virtual void PutItem(IItem item)
    {
        Item = item;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
