public interface IItem
{
    void Init(Tile tile);
    void UpdateTimer();
    bool Pickupble();
}

//public class Shield : MonoBehaviour, IItem
//{
//    public void UpdateTimer()
//    {
//        throw new System.NotImplementedException();
//    }
//}