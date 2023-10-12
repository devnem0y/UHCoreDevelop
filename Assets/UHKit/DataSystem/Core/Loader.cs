using UnityEngine;

namespace UralHedgehog
{
    [CreateAssetMenu(fileName = "Loader", menuName = "Data System/Loader", order = 0)]
    public class Loader : ScriptableObject
    {
        //TODO: Config это установки по умолчанию (стартовые)
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private SettingsConfig _settingsConfig;
        
        public static UserInfo UserInfo { get; private set; }
        public bool IsLoaded { get; private set; }
        
        public void Load()
        {
            //TODO: Если делать на WebGL нужно пересмотреть загрузку и сохранение на сервер, вместо PlayerPrefs
            //TODO: Планирую на яндекс

            const string key = nameof(UserInfo);
            
            if (PlayerPrefs.HasKey(key)) //Если есть сохраненные данные, достаем
            {
                var path = PlayerPrefs.GetString(key);
                UserInfo = JsonUtility.FromJson<UserInfo>(path);
            }
            else
            {
                //Иначе берем из конфига по дефолту
                UserInfo = new UserInfo(_settingsConfig.Data, _playerConfig.Data);
            }
            
            //TODO: Этот момент тоже доработать, нужно сделать заглушки, которые можно менять
/*#if UNITY_EDITOR // Если работаем в редакторе, достаем из конфига, перезаписывая то что было взято из PlayerPrefs
            _dataSettings = _configSettings.Data;
            _dataPlayer = _configPlayer.Data;
#endif*/
            
            IsLoaded = true;
            Debug.Log("Data loading: <color=green>DONE</color>");
        }
    }
}