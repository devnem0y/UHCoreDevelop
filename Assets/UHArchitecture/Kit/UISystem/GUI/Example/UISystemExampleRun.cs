using UnityEngine;
using UralHedgehog;
using UralHedgehog.UI;

/// <summary>
/// Сцена может иметь только один UIRoot.
/// При смене сцены в UIManager нужно передать новый UIRoot.
/// </summary>
public class UISystemExampleRun : MonoBehaviour
{
    public static UISystemExampleRun Instance { get; private set; }
    
    [SerializeField] private ScreenTransition _screenTransition; //TODO: Для красоты
    
    public UIManager UIManager { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _screenTransition.Perform(null, TransitionMode.STATIC);
        
        UIManager = new UIManager(FindObjectOfType<UIRoot>());
        
        var example = new Example();
        UIManager.OpenViewExample(example);
        
        _screenTransition.Show();
    }

    private void Update()
    {
        //TODO: Принудительное уничтожение виджета
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.CloseViewExample();
        }
    }
}
