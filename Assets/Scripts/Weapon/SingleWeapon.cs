using UnityEngine;

public class SingleWeapon : WeaponBase
{
    public override void Fire(Vector3 firePosition, Vector3 direction)
    {
        if (Ammo > 0)
        {
            Instantiate(projectile, firePosition, Quaternion.LookRotation(direction));
            Ammo--;
        }
    }
}