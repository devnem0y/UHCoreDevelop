using UnityEngine;
using UralHedgehog.UI;
using Event = UralHedgehog.UI.Event;

public class Test : MonoBehaviour
{
    private Data _dataExample;
    
    private void Start()
    {
       _dataExample = new Data(nameof(WTest), 1);
        
        UIDispatcher.Send(Event.SHOW_WIDGET, _dataExample);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            UIDispatcher.Send(Event.SHOW_WIDGET, _dataExample);
        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            UIDispatcher.Send(Event.HIDE_WIDGET, _dataExample);
        }
    }
}
