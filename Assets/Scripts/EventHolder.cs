using System;
using UnityEngine;

/// <summary>
/// Осуществляет хранение и вызов всех игровых событий.
/// </summary>
public class EventHolder : MonoBehaviour
{
    public event Action<float> OnCallScoreChanged;
    public event Action<float> OnPlayerAmmoChanged;
    public event Action<float> OnScoreUpdated;
    public event Action<Vector3> OnCollisionPositionWithTargetUpdated;
    public event Action OnNewLevelLoaded;
    public event Action OnCollisionCameraIsOff;
    public event Action OnCollisionWithOtherObject;
    public event Action<IScoreCoefficientHolder> OnScoreCoefficientUpdated;

    public void CallScoreChanged(float score) 
    {
        OnCallScoreChanged?.Invoke(score);
    }

    public void CallCollisionPositionWithTargetUpdated(Vector3 position) 
    {
        OnCollisionPositionWithTargetUpdated?.Invoke(position);
    }
    
    public void CallPlayerAmmoChanged(float playerAmmo) 
    {
        OnPlayerAmmoChanged?.Invoke(playerAmmo);
    }
    
    public void CallScoreUpdated(float score) 
    {
        OnScoreUpdated?.Invoke(score);
    }

    public void NewLevelLoaded() 
    {
        OnNewLevelLoaded?.Invoke();
    }
    
    public void CallCameraForCollisionObservingOff() 
    {
        OnCollisionCameraIsOff?.Invoke();
    }

    public void CallCollisionWithOtherGameObject() 
    {
        OnCollisionWithOtherObject?.Invoke();
    }

    public void CallScoreCoefficientUpdated(IScoreCoefficientHolder scoreCoefficientHolder)
    {
        OnScoreCoefficientUpdated?.Invoke(scoreCoefficientHolder);
    }
}
