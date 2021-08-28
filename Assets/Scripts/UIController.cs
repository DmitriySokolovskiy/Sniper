using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private EventHolder eventHolder;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text playerAmmoText;
    [SerializeField] private Text newLevelText;
    [SerializeField] private float newLevelTextVisibilityTime;

    private void Awake() 
    {
        newLevelText.enabled = false;
        eventHolder.OnScoreUpdated += UpdateScoreText;
        eventHolder.OnPlayerAmmoChanged += UpdatePlayerAmmoText;
        eventHolder.OnNewLevelLoaded += ResetScore;
        eventHolder.OnNewLevelLoaded += UpdateNewLevelText;
    }

    private void UpdateScoreText(float score) 
    {
        scoreText.text = "Очки: " + score;
    }

    private void UpdatePlayerAmmoText(float currentCountOfPatron) 
    {
        playerAmmoText.text = "Выстрелы: " + currentCountOfPatron;
    }

    private void ResetScore() 
    {
        scoreText.text = "Очки: " + 0;
    }

    /// <summary>
    /// Производит включение видимости текста на заданное время, при запуске нового уровня.
    /// </summary>
    private void UpdateNewLevelText() 
    {
        StartCoroutine(ShowNewLevelText());
    }
    
    private IEnumerator ShowNewLevelText() 
    {
        newLevelText.enabled = true;
        yield return new WaitForSeconds(newLevelTextVisibilityTime);
        newLevelText.enabled = false;
    }
}




