using UnityEngine;
using UralHedgehog.UI;

public class Test : MonoBehaviour
{
    private Data _dataExample;
    
    private void Start()
    {
       _dataExample = new Data(nameof(WTest), 1);
        
        UIDispatcher.Send(EventUI.SHOW_WIDGET, _dataExample);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            UIDispatcher.Send(EventUI.SHOW_WIDGET, _dataExample);
        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            UIDispatcher.Send(EventUI.HIDE_WIDGET, _dataExample);
        }
    }
}
