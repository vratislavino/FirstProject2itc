using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : FallingObject
{
    public override void Use() {
        Score.Instance.AddScore(38);
    }
}
