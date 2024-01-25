using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smg : RangedWeapon
{
    public override void Start()
    {
        base.Start();
        UsesControl = Input.GetButton;
    }
}
