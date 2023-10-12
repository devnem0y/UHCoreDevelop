namespace UralHedgehog
{
    public class PlayerBase : ISaver
    {
        public PlayerData Data { get; protected set; }
        
        public virtual void Save()
        {
            
        }
    }
}