using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.UI;

public class WTest : Widget
{
    [SerializeField] private Button _btnClose;

    protected override void Awake()
    {
        base.Awake();
        _btnClose.onClick.AddListener(Hide);
    }

    public override void Init(params object[] param)
    {
        Debug.Log(param[0].ToString());
    }

    public override void Show()
    {
        base.Show();
        Open(() =>
        {
            //TODO: Можно вставить анимацию
            Debug.Log("Open callback");
        });
    }

    public override void Hide()
    {
        Close(() =>
        {
            //TODO: Можно вставить анимацию
            Debug.Log("Close callback");
        });
        base.Hide();
    }
}