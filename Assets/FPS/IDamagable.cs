using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    int Hp { get; set; }

    void TakeDamage(int dmg);

    void Die();
}
