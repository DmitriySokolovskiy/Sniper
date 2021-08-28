using UnityEngine;

public class MultiWeapon : WeaponBase
{
    /// <summary>
    /// Смещение позиции снаряда относительно позиции центрального снаряда. 
    /// </summary>
    private float projectileOffset;
    /// <summary>
    /// Снаряд с камерами, для наблюдения за его полетом с заданных позиций.
    /// </summary>
    [SerializeField] private Projectile projectileWithCameras;
    
    private void Start() 
    {
        projectileOffset = 0.5f - projectile.gameObject.GetComponent<SphereCollider>().radius * projectile.transform.localScale.x;
    }

    public override void Fire(Vector3 firePosition, Vector3 direction)
    {
        Quaternion currentProjectileDirection = Quaternion.LookRotation(direction);
        float projectilePosWithPositiveOffsetX = firePosition.x + projectileOffset;
        float projectilePosWithNegativeOffsetX = firePosition.x - projectileOffset;
        float projectilePosWithPositiveOffsetY = firePosition.y + projectileOffset;
        float projectilePosWithNegativeOffsetY = firePosition.y - projectileOffset;

        if (Ammo > 0) 
        {
            Instantiate(projectile, new Vector3(projectilePosWithPositiveOffsetX, projectilePosWithPositiveOffsetY, firePosition.z), currentProjectileDirection);
            Instantiate(projectile, new Vector3(projectilePosWithNegativeOffsetX, projectilePosWithNegativeOffsetY, firePosition.z), currentProjectileDirection);
            Instantiate(projectile, new Vector3(projectilePosWithPositiveOffsetX, projectilePosWithNegativeOffsetY, firePosition.z), currentProjectileDirection);
            Instantiate(projectile, new Vector3(projectilePosWithNegativeOffsetX, projectilePosWithPositiveOffsetY, firePosition.z), currentProjectileDirection);
            Instantiate(projectileWithCameras, firePosition, currentProjectileDirection);
            Ammo--;
        }      
    }
}
