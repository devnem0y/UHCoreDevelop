using UralHedgehog;

public class Player : PlayerBase
{
    private int _soft;
    
    public Player(PlayerData data)
    {
        Data = data;
    }

    public override void Save()
    {
        Data = new PlayerData(Data.Name, _soft);
    }
}