using UnityEngine;
using UnityEngine.UI;
using UralHedgehog;
using UralHedgehog.UI;

public class WSettings : Widget<ISettings>
{
    [SerializeField] private Slider _sliderMaster;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderSound;
    [SerializeField] private Slider _sliderVoice;
    
    [SerializeField] private UHListMenuGroup _listMenuLanguage;
    
    [SerializeField] private Button _btnClose;

    public override void Init(ISettings model)
    {
        base.Init(model);

        _sliderMaster.value = Model.VolumeMaster;
        _sliderMusic.value = Model.VolumeMusic;
        _sliderSound.value = Model.VolumeSound;
        _sliderVoice.value = Model.VolumeVoice;
        
        _sliderMaster.onValueChanged.AddListener((value) => { Model.ChangeVolumeMaster(value); });
        _sliderMusic.onValueChanged.AddListener((value) => { Model.ChangeVolumeMusic(value); });
        _sliderSound.onValueChanged.AddListener((value) => { Model.ChangeVolumeSound(value); });
        _sliderVoice.onValueChanged.AddListener((value) => { Model.ChangeVolumeVoice(value); });
        
        _listMenuLanguage.Init(model.Language.GetHashCode());
        _listMenuLanguage.OnSelect += SetLanguage;
        
        _btnClose.onClick.AddListener(() =>
        {
            Game.Instance.SaveSettings();
            Hide();
        });
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