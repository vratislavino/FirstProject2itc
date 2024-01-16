using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatapultTrigger : MonoBehaviour
{
    public float strength = 1000;

    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.gameObject.GetComponentInParent<FPSPlayerController>();
        Debug.Log(collider.name);
        if (player != null )
        {
            player.Rigidbody.AddForce(Vector3.up* strength);
        }
    }

}
