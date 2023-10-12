using UralHedgehog;

[System.Serializable]
public struct UserInfo
{
    public SettingsData SettingsData;
    public PlayerData PlayerData;

    public UserInfo(SettingsData settingsData, PlayerData playerData)
    {
        SettingsData = settingsData;
        PlayerData = playerData;
    }
}
