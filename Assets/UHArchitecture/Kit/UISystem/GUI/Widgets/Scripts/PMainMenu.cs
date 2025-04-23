using UnityEngine;
using UnityEngine.UI;
using UralHedgehog;
using UralHedgehog.UI;

public class PMainMenu : Widget<IEmptyWidget>
{
    [SerializeField] private Button _btnPlay;
    [SerializeField] private Button _btnSettings;
    [SerializeField] private Button _btnQuit;

    public override void Init(IEmptyWidget model)
    {
        base.Init(model);

        hide += OnHide;
        _btnPlay.onClick.AddListener(Hide);
        
        _btnSettings.onClick.AddListener(() => { Game.Instance.UIManager.OpenViewSettings(); });
        
        _btnQuit.onClick.AddListener(() =>
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        });
    }

    private static void OnHide(IWidget obj)
    {
        Game.Instance.ChangeState(GameState.PLAY);
    }
}
