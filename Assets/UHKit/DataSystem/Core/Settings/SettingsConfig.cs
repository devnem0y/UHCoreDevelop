using UnityEngine;
using UralHedgehog;

[CreateAssetMenu(fileName = "SettingsConfig", menuName = "Data System/Settings", order = 1)]
public class SettingsConfig : ScriptableObject
{
    [SerializeField] private SettingsData _data;
    public SettingsData Data => _data;
}
