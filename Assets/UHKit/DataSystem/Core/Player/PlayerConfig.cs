using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Data System/Player", order = 2)]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private PlayerData _data;
    public PlayerData Data => _data;
}