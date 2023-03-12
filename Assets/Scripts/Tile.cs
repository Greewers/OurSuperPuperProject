using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable; // задает плитке значение проходимости

    public BaseObjects OccupiedObject; 
    public bool Walkable => _isWalkable && OccupiedObject == null; //определеяет финальную проходимость (проходимость клетке и занята ли объектом)



    public virtual void Init(int x, int y)
    {

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
