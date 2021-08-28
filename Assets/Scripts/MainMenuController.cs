using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{        
    [SerializeField] private Button startGame;
    [SerializeField] private Slider weaponChanger;
    [SerializeField] private Text weaponChangerText;
    /// <summary>
    /// Смещение номера текущего оружия для корректного отображения в главном меню.
    /// </summary>
    private readonly float weaponNumberOffset = 1f;

    private void Start()
    {
        weaponChangerText.text = "Оружие: " + (weaponChanger.value + weaponNumberOffset);

        weaponChanger.onValueChanged.AddListener(weaponNumber =>
       {
           weaponChangerText.text = "Оружие: " + (weaponNumber + weaponNumberOffset);
       });

        startGame.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("PlayerWeaponNumber", (int)weaponChanger.value);
            SceneManager.LoadScene("MainScene");
        });
    }
}
