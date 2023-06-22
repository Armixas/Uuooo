using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private Transform barrel;
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private GameObject muzzlePrefab;
    [SerializeField]
    private UnityEvent onFire;

    private bool hasAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFire())
            Fire();
    }
    public void UpdateAmmo(int value) => hasAmmo = value > 0;
    private bool IsFire() => hasAmmo && Input.GetButtonDown("Fire1");

    public void Fire()
    {
        if (!hasAmmo)
            return;
        CreateProjectile();
        CreateMuzzleEffect();
        onFire.Invoke();
    }

    private void CreateProjectile()
    {
        Instantiate(projectilePrefab, barrel.position, barrel.rotation);
    }

    private void CreateMuzzleEffect()
    {
        Instantiate(muzzlePrefab, barrel.position, barrel.rotation);
    }
}
