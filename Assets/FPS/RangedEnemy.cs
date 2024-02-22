using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private float shootInterval;
    private float shootCooldown;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootPoint;

    protected override void Start()
    {
        base.Start();
        shootCooldown = shootInterval;
    }

    void Update()
    {
        transform.LookAt(player.transform);

        if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
            if(shootCooldown <= 0) {
                Shoot();
                shootCooldown = shootInterval;
            }
        }
    }

    private void Shoot()
    {
        var blt = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        var rb = blt.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(blt.transform.forward * 20f, ForceMode.Impulse);
    }
}
