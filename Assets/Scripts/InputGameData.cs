using UnityEngine;

/// <summary>
/// Входные данные с главного меню. 
/// </summary>
public class InputGameData : MonoBehaviour
{
    public PlayerData PlayerData { get; } = new PlayerData();

    private void Awake()
    {
        PlayerData.WeaponNumber = PlayerPrefs.GetInt("PlayerWeaponNumber");
    }
}