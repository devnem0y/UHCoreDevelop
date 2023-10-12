using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UralHedgehog.UI;

namespace UralHedgehog
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Loader _loader;
        
        [SerializeField] private LocalizationConfig _localizationConfig;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioResources _audioResources;
        
        public LocalizationManager LocalizationManager { get; private set; }
        public AudioManager AudioManager { get; private set; }
        public GameState GameState { get; private set; }

        public event Action Loading;
        public event Action Launch;
        public event Action Begin;

        private bool _init;
        
        private Settings _settings;
        private Player _player;

        protected void Run()
        {
            ChangeState(GameState.LOADING);
            StartCoroutine(AlternateСall());
        }
        
        private IEnumerator AlternateСall()
        {
            _loader.Load();
            yield return new WaitUntil(() => _loader.IsLoaded);
            Loading?.Invoke();
            yield return new WaitForSeconds(0.01f);
            Initialization();
            yield return new WaitUntil(() => _init);
            Launch?.Invoke();
            yield return new WaitForSeconds(0.01f);
            Begin?.Invoke();
            ChangeState(GameState.MAIN);
        }

        /// <summary>
        /// Base не удалять! Все что нужно писать после.
        /// </summary>
        protected virtual void Initialization()
        {
            _settings = new Settings(Loader.UserInfo.SettingsData, _audioMixer);
            LocalizationManager = new LocalizationManager(_localizationConfig) { Language = _settings.Language };
            _settings.OnChangeLanguage += OnLocalize;
            AudioManager = new AudioManager(_audioMixer, _audioResources);
            _player = new Player(Loader.UserInfo.PlayerData);
            
            _init = true;
        }

        public void Save()
        {
            _settings.Save();
            _player.Save();
            Saver.Write(new UserInfo(_settings.Data, _player.Data));
        }

        public virtual void ChangeState(GameState state)
        {
            GameState = state;
        }

        /// <summary>
        /// Base не удалять! Все что нужно писать после.
        /// </summary>
        protected virtual void OnDestroy()
        {
            _settings.OnChangeLanguage -= OnLocalize;
        }

        /// <summary>
        /// Поднимает виджет настроек
        /// </summary>
        public void OpenViewSettings()
        {
            var wSettingsData = new Data(nameof(WSettings), _settings);
            UIDispatcher.Send(EventUI.SHOW_WIDGET, wSettingsData);
        }

        private void OnLocalize()
        {
            LocalizationManager.OnLocalize();
        }
        
        private void OnApplicationQuit()
        {
            Save();
        }
    }
}