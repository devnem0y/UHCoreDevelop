using UnityEngine;

namespace UralHedgehog
{
    [CreateAssetMenu(fileName = "Saver", menuName = "Data System/Saver", order = 1)]
    public class Saver : ScriptableObject
    {
        [SerializeField] private SettingsConfig _settingsMock;
        [SerializeField] private PlayerConfig _playerMock;
        
        public void Write(ISaver settings, ISaver player)
        {
            settings.Save();
            player.Save();

            var settingsData = (SettingsData) settings.Data;
            var playerData = (PlayerData) player.Data;
            
#if UNITY_EDITOR
            _settingsMock.Data = settingsData;
            _playerMock.Data = playerData;
#endif
            
            var userInfo = new UserInfo(settingsData, playerData);
            var json = JsonUtility.ToJson(userInfo);
            
            PlayerPrefs.SetString(nameof(UserInfo), json); //TODO: Сохранение в PlayerPrefs всех данных
            
            //TODO: Если делать на WebGL, нужно интегрировать яндекс sdk и мутить через него
            
            Debug.Log("Data save: <color=green>DONE</color>");
        }
    }
}