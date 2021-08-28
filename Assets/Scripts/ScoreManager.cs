using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private EventHolder eventHolder;
    private float gameScore;
    private float scoreCoefficient;

    private void Awake()
    {
        eventHolder.CallScoreUpdated(gameScore);
        eventHolder.OnCallScoreChanged += CalculateScore;
        eventHolder.OnNewLevelLoaded += ResetScore;
        eventHolder.OnCollisionCameraIsOff += UpdateScore;
        eventHolder.OnCollisionWithOtherObject += UpdateScore;
        eventHolder.OnScoreCoefficientUpdated += UpdateScoreCoefficient;
    }

    private void CalculateScore(float score) 
    {
        gameScore += score * scoreCoefficient;
    }

    private void ResetScore() 
    {
        gameScore = 0;
    }

    private void UpdateScore()
    {
        eventHolder.CallScoreUpdated(gameScore);
    }

    private void UpdateScoreCoefficient(IScoreCoefficientHolder scoreCoefficientHolder)
    {
        scoreCoefficient = scoreCoefficientHolder.ScoreCoefficient;
    }
}