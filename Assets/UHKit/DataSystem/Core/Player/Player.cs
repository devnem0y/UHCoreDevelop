using UralHedgehog;

public class Player : PlayerBase, IPlayer
{
    public string Name { get; }
    public int Soft { get; }
    
    public Player(PlayerData data)
    {
        Data = data;

        Name = data.Name;
        Soft = data.Soft;
    }

    public override void Save()
    {
        Data = new PlayerData(Name, Soft);
    }
}