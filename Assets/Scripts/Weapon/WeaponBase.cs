using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IScoreCoefficientHolder
{
    [Header("Параметры оружия")]
    [SerializeField] protected Projectile projectile;
    [SerializeField] private Aim weaponAim;
    [SerializeField] private float fireRate;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float scoreCoefficient;
    public Aim WeaponAim { get => weaponAim; }
    public int Ammo { get; set; }
    public int MaxAmmo { get => maxAmmo; }
    public float FireRate { get => fireRate; }
    public float ScoreCoefficient { get => scoreCoefficient; }

    public abstract void Fire(Vector3 firePosition, Vector3 direction);
}
