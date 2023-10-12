using System;
using TMPro;
using UnityEngine;

namespace UralHedgehog
{
    public class LocalizedTextMP : MonoBehaviour
    {
        [SerializeField] private string _key;

        private Bootstrap _bootstrap;
        private TMP_Text _label;
        private LocalizationManager _localizationManager;

        private void Awake()
        {
            _bootstrap = FindObjectOfType<Bootstrap>();
            Debug.Log(_bootstrap.gameObject.name);
            _label = GetComponent<TMP_Text>();
        }

        private void OnDestroy()
        {
            _localizationManager.Localize -= Localize;
        }

        private void Start()
        {
            _localizationManager = _bootstrap.LocalizationManager;
            _localizationManager.Localize += Localize;
            Localize();
        }

        private void Localize()
        {
            switch (_localizationManager.Language)
            {
                case Language.CHINESE_SIMPLIFIED:
                    _label.font = _localizationManager.Config.ChineseTMP;
                    break;
                case Language.RUSSIAN:
                    _label.font = _localizationManager.Config.BasicTMP;
                    break;
                case Language.ENGLISH:
                case Language.GERMAN:
                case Language.FRENCH:
                case Language.SPANISH:
                case Language.ITALIAN:
                    _label.font = _localizationManager.Config.ExtraTMP;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _label.text = _localizationManager.GetTranslate(_key);
        }
    }
}