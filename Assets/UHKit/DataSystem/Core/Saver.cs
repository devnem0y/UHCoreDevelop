using UnityEngine;

namespace UralHedgehog
{
    public static class Saver
    {
        public static void Write(UserInfo userInfo)
        {
            var json = JsonUtility.ToJson(userInfo);
            
            PlayerPrefs.SetString(nameof(UserInfo), json); //TODO: Сохранение в PlayerPrefs всех данных
            
            //TODO: Если делать на WebGL, нужно интегрировать яндекс sdk и мутить через него
            Debug.Log("Data save: <color=green>DONE</color>");
        }
    }
}