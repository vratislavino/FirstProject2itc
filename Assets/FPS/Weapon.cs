using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
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

    public virtual void Start()
    {
        
    }

    void Update()
    {
        // check reload
        CheckInput();
        // fireCooldown update
    }

    protected virtual void CheckInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // ?? TryToShoot
            if (IsPossibleToShoot())
            {
                Shoot();
            }
        }
    }

    protected virtual bool IsPossibleToShoot()
    {
        return currentAmmo > 0 && !IsReloading;
    }

    protected virtual void Shoot()
    {

    }
}
