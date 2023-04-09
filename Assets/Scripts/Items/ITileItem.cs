public interface ITileItem
{
    IPlayerItem PlayerItem { get; }
    void Init(Tile tile);
    void UpdateTimer();
    bool Pickupble();
    void ItemDestroy();
}
