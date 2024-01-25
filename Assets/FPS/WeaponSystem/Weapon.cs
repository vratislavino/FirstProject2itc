using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Func<string, bool> UsesControl;

    public event Action<bool> PossibleToAttackChanged;

    protected void RaisePossibleToAttackChanged(bool possibleToAttack)
    {
        PossibleToAttackChanged?.Invoke(possibleToAttack);
    }

    public virtual void Start()
    {
        
    }

    public abstract void Attack();
}
