using UnityEngine;

public interface IItem
{
    void UpdateTimer();
}

public class Bomb : MonoBehaviour, IItem
{
    [SerializeField][Range(0, 10)] private int _bombTimer = 3;
    public void UpdateTimer()
    {

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