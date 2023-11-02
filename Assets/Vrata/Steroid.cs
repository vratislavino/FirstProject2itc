using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steroid : FallingObject
{
    public override void Use() {
        Score.Instance.RemoveScore(500);
    }
}
