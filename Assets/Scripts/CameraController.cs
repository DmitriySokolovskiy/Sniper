using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private EventHolder eventHolder;
    [SerializeField] private Camera playerCamera;
    /// <summary>
    /// Камера для наблюдения столкновения снаряда с мишенью.
    /// </summary>
    [SerializeField] private Camera collisionCamera;
    /// <summary>
    /// Время наблюдения столкновения снаряда с мишенью.
    /// </summary>
    [SerializeField] private float collisionObservingTime;
    /// <summary>
    /// Смещение позиции камеры от места столкновения снаряда с мишенью, для корректного наблюдения.
    /// </summary>
    private readonly Vector3 collisionCameraPositionOffset = new Vector3(5, 5, -5);

    private void Start() 
    {
        eventHolder.OnCollisionPositionWithTargetUpdated += UpdateParametersCollisionCamera;
    }

    /// <summary>
    /// Производим перемещение камеры в позицию столкновения снаряда с мишенью со смещением,
    /// производим запуск процесса наблюдения.
    /// </summary>
    /// <param name="position"></param>
    private void UpdateParametersCollisionCamera(Vector3 position) 
    {
        collisionCamera.transform.position = position + collisionCameraPositionOffset;
        collisionCamera.transform.LookAt(position, Vector3.up);
        StartCoroutine(UpdateCamerasStatusForCollisionObserving());
    }
    
    /// <summary>
    /// Производим наблюдение за местом столкновения снаряда с мишенью, уведомляем о завершении наблюдения.
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpdateCamerasStatusForCollisionObserving() 
    {
        collisionCamera.enabled = true;
        playerCamera.enabled = false;

        yield return new WaitForSeconds(collisionObservingTime);
        
        collisionCamera.enabled = false;
        eventHolder.CallCameraForCollisionObservingOff();
        playerCamera.enabled = true;
    }
}
