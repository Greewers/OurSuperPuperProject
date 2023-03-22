using UnityEngine;

public interface IItem
{
    void UpdateTimer();
}

public class Bomb : MonoBehaviour, IItem
{
    public void UpdateTimer()
    {
        int _bombTimer = 3;
        if (_bombTimer !=0 )
        {
            _bombTimer--;
        }
        else
        {
            Explosion();
        }
    }

    private void Explosion()
    {
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