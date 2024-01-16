using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class RangedWeapon : Weapon
{
    [SerializeField] protected int MaxAmmo;
    protected int currentAmmo;
    [SerializeField] protected float ReloadSpeed;
    protected float currentReloadProgress = 0;
    public bool IsReloading => currentReloadProgress > 0;

    [SerializeField] protected int Damage;

    [SerializeField] protected float FireRate;
    protected float fireCooldown = 0;

    [SerializeField] protected Transform BulletPoint;

    [SerializeField] protected Rigidbody BulletPrefab;

    public override void Start()
    {
        base.Start();
        currentAmmo = MaxAmmo;
    }

    void Update()
    {
        // check reload
        
        // fireCooldown update
    }


    protected virtual bool IsPossibleToShoot()
    {
        return currentAmmo > 0 && !IsReloading;
    }

    public override void Attack()
    {
        if (IsPossibleToShoot())
        {
            Shoot();
            currentAmmo--;
        }
    }

    protected virtual void Shoot()
    {
        var bullet = Instantiate(BulletPrefab, BulletPoint.position, transform.rotation);
        bullet.AddForce(bullet.transform.forward * 100, ForceMode.Impulse);
        Destroy(bullet.gameObject, 4f);
    }
}
