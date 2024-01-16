using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{ 
    public virtual void Start()
    {
        
    }

    public abstract void Attack();
}
