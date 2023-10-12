using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace UralHedgehog
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LocalizationConfig _localizationConfig;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioResources _audioResources;
        
        public LocalizationManager LocalizationManager { get; private set; }
        public AudioManager AudioManager { get; private set; }

        public event Action Loading;
        public event Action Launch;
        public event Action Begin;

        protected void Run()
        {
            //TODO: Установка языка происходит из настроек. Настройки в свою очередь получают из файла даты настроек. Пока принудительно установка английского.
            LocalizationManager = new LocalizationManager(_localizationConfig) { Language = Language.ENGLISH };
            AudioManager = new AudioManager(_audioMixer, _audioResources);
            
            Loading?.Invoke();
            Launch?.Invoke();
            Begin?.Invoke();
        }
    }
}