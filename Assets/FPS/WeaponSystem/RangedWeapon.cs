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
        UsesControl = Input.GetButtonDown;
    }

    void Update()
    {
        if(Input.GetButtonDown("Reload"))
        {
            currentReloadProgress = ReloadSpeed;
        }
        if(currentReloadProgress > 0)
        {
            currentReloadProgress -= Time.deltaTime;
            if(currentReloadProgress <= 0)
            {
                currentAmmo = MaxAmmo;
            }
        }

        // fireCooldown update
        fireCooldown -= Time.deltaTime;
    }


    protected virtual bool IsPossibleToShoot()
    {
        return currentAmmo > 0 && !IsReloading && fireCooldown <= 0;
    }

    public override void Attack()
    {
        if (IsPossibleToShoot())
        {
            Shoot();
            fireCooldown = FireRate;
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
