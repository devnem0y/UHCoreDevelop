using UnityEngine;
using UnityEngine.UI;
using UralHedgehog;
using UralHedgehog.UI;

public class WSettings : Widget<ISettings>
{
    [SerializeField] private Slider _master;
    [SerializeField] private Slider _music;
    [SerializeField] private Slider _sound;
    [SerializeField] private Slider _voice;
    
    [SerializeField] private UHListMenuGroup _listMenuLanguage;
    
    [SerializeField] private Button _btnClose;

    protected override void Awake()
    {
        base.Awake();
        _btnClose.onClick.AddListener(Hide);
    }

    public override void Init(ISettings model)
    {
        base.Init(model);
        
        _listMenuLanguage.Init(model.Language.GetHashCode());
        _listMenuLanguage.OnSelect += SetLanguage;
    }

    private void OnDestroy()
    {
        _listMenuLanguage.OnSelect -= SetLanguage;
    }

    private void SetLanguage(int value)
    {
        Model.OnChangeLanguage((Language)value);
    }
}