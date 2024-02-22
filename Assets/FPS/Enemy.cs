using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField]
    protected int MaxHp = 100;

    protected FPSPlayerController player;

    public int Hp { get; set; }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int dmg)
    {
        Hp -= dmg;
        if(Hp <= 0) {
            Die();
        }
    }

    protected virtual void Start()
    {
        Hp = MaxHp;
        player = FindObjectOfType<FPSPlayerController>();
    }
}
