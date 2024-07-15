using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.UI;

namespace UralHedgehog
{
    /// <summary>
    /// Для примера используем пустую модель
    /// </summary>
    public class WExampleEmpty : Widget<IEmptyWidget>
    {
        [SerializeField] private Button _btnClose;

        protected override void Awake()
        {
            base.Awake();
            _btnClose.onClick.AddListener(Hide);
        }
        
        public override void Init(IEmptyWidget model)
        {
            base.Init(model);
            
            Debug.Log("Init WExampleEmpty");
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
}