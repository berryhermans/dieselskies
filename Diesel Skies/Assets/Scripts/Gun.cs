using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private float fireRate = 0;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    public float FireRate => fireRate;

    private float nextFireTime = 0f;

    public void Fire(List<GameObject> _)
    {
        if (Time.time > nextFireTime)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + fireRate;
        }
    }
}