namespace UralHedgehog
{
    public class PlayerBase : ISaver
    {
        public IData Data { get; protected set; }
        
        public virtual void Save()
        {
            
        }
    }
}