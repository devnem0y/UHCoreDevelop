using UralHedgehog.UI;

namespace UralHedgehog
{
    public class Game : Bootstrap
    {
        protected void Start()
        {
            Run();
            
            var dataExample = new Data(nameof(WTest), 1);
            UIDispatcher.Send(EventUI.SHOW_WIDGET, dataExample);
        }
    }
}