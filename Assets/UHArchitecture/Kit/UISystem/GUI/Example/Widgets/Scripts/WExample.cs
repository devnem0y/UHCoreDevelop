using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.UI;

namespace UralHedgehog
{
    public class WExample : Widget<IExample>
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _btnClose;
        [SerializeField] private Button _btnOpenExampleEmpty;
        
        public override void Init(IExample model)
        {
            base.Init(model);
            
            _title.text = model.Title;

            _btnClose.onClick.AddListener(Hide);

            _btnOpenExampleEmpty.onClick.AddListener(() =>
            {
                UISystemExampleRun.Instance.UIManager.OpenViewExampleEmpty();
                Hide();
            });
        }
        
        
    }
}