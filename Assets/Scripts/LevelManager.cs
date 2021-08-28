using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TargetCreator targetCreator;
    [SerializeField] private EventHolder eventHolder;
    [SerializeField] private Player player;
    [SerializeField] private float scoreForWin;
    [SerializeField] private List<Vector3> targetPositions;
    private int currentNumberOfTargetPositions;

    private void Start() 
    {
        targetCreator.CreateTarget(targetPositions[currentNumberOfTargetPositions]);
        eventHolder.OnScoreUpdated += LoadNextLevel;
    }

    private void LoadNextLevel(float currentScore)
    {
        if (currentScore >= scoreForWin)
        {
            currentNumberOfTargetPositions++;

            if (currentNumberOfTargetPositions >= targetPositions.Count)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                UpdateTargetPosition();
                eventHolder.NewLevelLoaded();
            }
        }
        else if (currentScore < scoreForWin && player.CurrentWeapon.Ammo == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            UpdateTargetPosition();
        }
    }

    private void UpdateTargetPosition() 
    {
        targetCreator.DestroyTarget();
        targetCreator.CreateTarget(targetPositions[currentNumberOfTargetPositions]);
    }
}
