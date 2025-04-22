using System;
using UnityEngine;
using UnityEngine.UI;

namespace UralHedgehog
{
    public class LocalizedText : MonoBehaviour
    {
        [SerializeField] private string _key;

        private EntryPoint _entryPoint;
        private Text _label;

        private void Awake()
        {
            _label = GetComponent<Text>();
        }

        private void OnDestroy()
        {
            LocalizationManager.Localize -= Localize;
        }

        private void Start()
        {
            LocalizationManager.Localize += Localize;
            Localize();
        }

        private void Localize()
        {
            switch (LocalizationManager.Language)
            {
                case Language.CHINESE_SIMPLIFIED:
                    _label.font = LocalizationManager.Config.Chinese;
                    break;
                case Language.RUSSIAN:
                    _label.font = LocalizationManager.Config.Basic;
                    break;
                case Language.ENGLISH:
                case Language.GERMAN:
                case Language.FRENCH:
                case Language.SPANISH:
                case Language.ITALIAN:
                    _label.font = LocalizationManager.Config.Extra;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _label.text = LocalizationManager.GetTranslate(_key);
        }
    }
}