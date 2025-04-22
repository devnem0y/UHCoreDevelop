using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UralHedgehog.UI;

namespace UralHedgehog
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Loader _loader;
        [SerializeField] private Saver _saver;
        
        [SerializeField] private LocalizationConfig _localizationConfig;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioResources _audioResources;
        
        [SerializeField] private ScreenTransition _screenTransition;
        
        public AudioManager AudioManager { get; private set; }
        public UIManager UIManager { get; protected set; }
        public GameState GameState { get; private set; }
        
        protected ScreenTransition ScreenTransition => _screenTransition;

        public event Action Loading;
        public event Action Launch;
        public event Action Begin;

        private bool _init;
        
        protected LocalizationManager _localizationManager;
        protected Settings _settings;
        protected Player _player;
        
        private IEnumerator Start()
        {
            ChangeState(GameState.LOADING);
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
            _settings = new Settings(_loader.SettingsInfo.SettingsData, _audioMixer);
            _localizationManager = new LocalizationManager(_localizationConfig, _settings.Language);
            AudioManager = new AudioManager(_audioMixer, _audioResources);
            _player = new Player(_loader.UserInfo.PlayerData);
            
            _init = true;
        }

        public void SaveSettings()
        {
            _saver.Write(_settings);
        }
        
        public void SaveUser(bool isCloud = false)
        {
            _saver.Write(_player, isCloud);
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
            
        }
        
        private void OnApplicationQuit()
        {
            SaveSettings();
            SaveUser(true);
        }
    }
}