public interface IItem
{
    void Init(Tile tile);
    void UpdateTimer();
    bool Pickupble();
    void ItemDestroy();
}

//public class Shield : MonoBehaviour, IItem
//{
//    public void UpdateTimer()
//    {
//        throw new System.NotImplementedException();
//    }
//}