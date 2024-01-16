using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<FPSPlayerController>();
        if (player != null)
        {
            player.ChangeEnvironmentSpeedMult(0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.gameObject.GetComponentInParent<FPSPlayerController>();
        if (player != null)
        {
            player.ChangeEnvironmentSpeedMult(1f);
        }
    }
}
