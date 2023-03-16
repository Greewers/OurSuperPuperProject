using UnityEngine;

public interface IItem
{
    void UpdateTimer();
}

public class Bomb : MonoBehaviour, IItem
{
    public void UpdateTimer()
    {
        throw new System.NotImplementedException();
    }
}