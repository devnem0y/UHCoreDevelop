using UnityEngine;
using UnityEngine.UI;
using UralHedgehog;
using UralHedgehog.UI;

public class WSettings : Widget<ISettings>
{
    [SerializeField] private Button _btnClose;

    protected override void Awake()
    {
        base.Awake();
        _btnClose.onClick.AddListener(Hide);
    }

    public override void Init(ISettings model)
    {
        base.Init(model);
        
        Debug.Log("Init WSettings");
        Debug.Log($"Language {Model.Language}");
    }

    public override void Show()
    {
        base.Show();
        
        //TODO: Можно вставить анимацию
        Debug.Log("Open callback");
    }

    public override void Hide()
    {
        //TODO: Можно вставить анимацию
        Debug.Log("Close callback");
        
        base.Hide();
    }
}