using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int MaxHp;

    private int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public void TakeDamage(int dmg)
    {
        Hp -= dmg;
        if (Hp <= 0) Die(); 
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Hp = MaxHp;
    }
}
