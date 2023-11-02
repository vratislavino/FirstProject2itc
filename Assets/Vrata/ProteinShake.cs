using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinShake : FallingObject
{
    public override void Use() {
        Score.Instance.AddScore(74);
    }
}
