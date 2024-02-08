using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var dmg = collision.collider.GetComponent<IDamagable>();
        if(dmg != null)
        {
            dmg.TakeDamage(5);
        }

        Destroy(gameObject);
    }
}
