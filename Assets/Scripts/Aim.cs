using System.Collections;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [Header("Параметры колебания прицела")]
    [SerializeField] private float deviationRange;
    [SerializeField] private float deviationSpeed;
    [SerializeField] private float aimDeviationFluency;

    public Aim(Transform aimTransform, float deviationSpeed) 
    {
        this.aimTransform = aimTransform;
        this.deviationSpeed = deviationSpeed;
    }
    
    /// <summary>
    /// Производит колебания прицела игрока 
    /// </summary>
    public IEnumerator AimDeviation() 
    {     
        while (true)
        {
            float aimDeviationX = Random.Range(-deviationRange, deviationRange);
            float aimDeviationY = Random.Range(-deviationRange, deviationRange);
            Vector3 deviationPosition = aimTransform.localEulerAngles + new Vector3(aimDeviationX, aimDeviationY, 0);
            aimTransform.localEulerAngles = Vector3.Lerp(aimTransform.localEulerAngles, deviationPosition, aimDeviationFluency);

            yield return new WaitForSeconds(1/deviationSpeed);
        }
    }
}
