using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputGameData inputGameData;
    [SerializeField] private EventHolder eventHolder;
    [SerializeField] private Camera cam;
    [SerializeField] private List<WeaponBase> playerArsenal;
    [SerializeField] private float firePointDistance;
    [SerializeField] private float fireRate;
    [Header("Параметры вращения игрока")]
    [SerializeField] private float sensitivityX;
    [SerializeField] private float sensitivityY;
    [SerializeField] private float minimumRotationY;
    [SerializeField] private float maximumRotationY;
    [SerializeField] private float minimumRotationX;
    [SerializeField] private float maximumRotationX;
    private Transform currentTransform;
    private Vector3 firePoint;
    private Vector3 fireDirection;
    private bool fireIsActive = true;
    private float rotationX;
    private float rotationY;
    public WeaponBase CurrentWeapon { get; private set; }

    private void Start()
    {
        currentTransform = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdatePlayerConfiguration(inputGameData.PlayerData);

        eventHolder.OnNewLevelLoaded += ReloadWeapon;
        eventHolder.OnCollisionCameraIsOff += ActivatePlayerFire;
        eventHolder.OnCollisionWithOtherObject += ActivatePlayerFire;
    }

    private void Update()
    {
        RotatePlayer();
        Fire();
    }

    private void UpdatePlayerConfiguration(PlayerData playerData)
    {
        CurrentWeapon = playerArsenal[playerData.WeaponNumber];
        SetWeaponAim();
        ReloadWeapon();
        eventHolder.CallScoreCoefficientUpdated(CurrentWeapon);
    }

    private void Fire()
    {
        if (Input.GetMouseButton(0) && Time.time >= fireRate && fireIsActive)
        {
            fireRate = Time.time + 1 / CurrentWeapon.FireRate;
            CurrentWeapon.Fire(firePoint, fireDirection);
            fireIsActive = false;
            
            eventHolder.CallPlayerAmmoChanged(CurrentWeapon.Ammo);
        }
    }

    private void RotatePlayer()
    {
        rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY = Mathf.Clamp(rotationY, minimumRotationY, maximumRotationY);
        rotationX = Mathf.Clamp(rotationX, minimumRotationX, maximumRotationX);
        Vector3 currentRotation = new Vector3(rotationX, rotationY, 0);
        currentTransform.localEulerAngles = currentRotation;
        firePoint = new Vector3(cam.pixelWidth / 2f, cam.pixelHeight / 2f, 0);
        Ray rayMouse = cam.ScreenPointToRay(firePoint);
        firePoint = rayMouse.GetPoint(firePointDistance);
        fireDirection = firePoint - currentTransform.position;
    }

    private void ReloadWeapon() 
    {
        CurrentWeapon.Ammo = CurrentWeapon.MaxAmmo;
        eventHolder.CallPlayerAmmoChanged(CurrentWeapon.Ammo);
    }

    private void SetWeaponAim()
    {
        StopCoroutine(CurrentWeapon.WeaponAim.AimDeviation());
        StartCoroutine(CurrentWeapon.WeaponAim.AimDeviation());
    }

    private void ActivatePlayerFire() 
    {
        fireIsActive = true;
    }
}
