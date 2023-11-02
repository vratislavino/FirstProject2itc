using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float border;

    float xMove = 0;

    // Update is called once per frame
    void Update() {

        xMove = 0;

        if (Input.GetKey(KeyCode.A)) {
            xMove = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            xMove = 1;
        }

        transform.Translate(xMove * speed * Time.deltaTime, 0, 0);

        if (transform.position.x < -border) {
            transform.position = new Vector3(-border, transform.position.y, transform.position.z);
        }
        if (transform.position.x > border) {
            transform.position = new Vector3(border, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision) {

        var comp = collision.gameObject.GetComponent<FallingObject>();
        comp.Use();
        Destroy(collision.gameObject);
    }
}
