using System;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable; // задает плитке значение проходимости


    public BaseObjects OccupiedObject; 
    public bool Walkable => _isWalkable && OccupiedObject == null; //определеяет финальную проходимость (проходимость клетке и занята ли объектом)


    //public BaseObjects OccupiedObject; 
    //public bool Walkable => _isWalkable && OccupiedObject == null; //определеяет финальную проходимость (проходимость клетке и занята ли объектом)
    


    public object Item { get; private set; }

    


    public virtual void Init(int x, int y)
    {

    }
    internal virtual void PutItem(int randomItem)
    {
        throw new NotImplementedException();
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
