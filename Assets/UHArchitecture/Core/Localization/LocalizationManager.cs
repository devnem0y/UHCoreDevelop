using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace UralHedgehog
{
    public enum Language
    {
        ENGLISH = 0,
        RUSSIAN = 1,
        GERMAN = 2,
        FRENCH = 3,
        SPANISH = 4,
        ITALIAN = 5,
        CHINESE_SIMPLIFIED = 6,
    }

    public class LocalizationManager
    {
        private static Dictionary<string, List<string>> _localization;

        public static LocalizationConfig Config { get; private set; }
        public static Language Language { get; private set; }

        public static event Action Localize;

        public LocalizationManager(LocalizationConfig config, Language language)
        {
            Config = config;
            Language = language;
            
            LoadLocalization();
        }

        private static void LoadLocalization()
        {
            _localization = new Dictionary<string, List<string>>();

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(Config.LocalizationFile.text);

            foreach (XmlNode key in xmlDocument["Keys"].ChildNodes)
            {
                var keyStr = key.Attributes["Name"].Value;
                var values = new List<string>();
                
                foreach (XmlNode translate in key["Translates"].ChildNodes)
                {
                    values.Add(translate.InnerText);
                }

                _localization[keyStr] = values;
            }

            Debug.Log("Localization loading: <color=green>DONE</color>");
        }

        public static string GetTranslate(string key)
        {
            return _localization.TryGetValue(key, out var value) ? 
                value[Language.GetHashCode()] : key;
        }

        public static void OnLocalize(Language language)
        {
            Language = language;
            Localize?.Invoke();
        }
    }
}