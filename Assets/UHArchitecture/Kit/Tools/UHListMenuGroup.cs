using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UralHedgehog
{
    public class UHListMenuGroup : MonoBehaviour
    {
        [SerializeField] [Range (0, 10)] private int _maxValue;
        
        [SerializeField] private TMP_Text _lblValue;
        [SerializeField] private Button _btnLeft;
        [SerializeField] private Button _btnRight;

        private int _value;
        
        public event Action<int> OnSelect;

        private void Awake()
        {
            _btnLeft.onClick.AddListener(OnLeft);
            _btnRight.onClick.AddListener(OnRight);
        }

        public void Init(int value)
        {
            _value = value;
            _btnLeft.interactable = _value != 0;
            _btnRight.interactable = _value != _maxValue;
        }

        public void SetLabel(string label)
        {
            _lblValue.text = label;
        }
        
        private void OnLeft()
        {
            _value--;
            Set();
        }
    
        private void OnRight()
        {
            _value++;
            Set();
        }

        private void Set()
        {
            _btnLeft.interactable = _value != 0;
            _btnRight.interactable = _value != _maxValue;
            OnSelect?.Invoke(_value);
        }
    }
}