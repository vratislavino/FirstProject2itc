using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    private int bulletCount = 5;

    [SerializeField]
    private float spread = 0.05f;

    protected override void Shoot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            var bullet = Instantiate(BulletPrefab, BulletPoint.position, transform.rotation);
            Debug.Log(bullet.transform.forward + " : " + GetDirection(bullet.transform.forward));
            
            bullet.AddForce(GetDirection(bullet.transform.forward) * 100, ForceMode.Impulse);
            Destroy(bullet.gameObject, 4f);
        }
    }

    private Vector3 GetDirection(Vector3 originDir)
    {
        originDir.x *= Random.Range(1-spread, 1+spread);
        originDir.y *= Random.Range(1-spread, 1+spread);
        originDir.z *= Random.Range(1-spread, 1+spread);

        return originDir.normalized;
    }
}
