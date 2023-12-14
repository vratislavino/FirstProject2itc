using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPSPlayerController : MonoBehaviour
{
    Vector3 rotation;
    Vector3 cameraRotation;

    [SerializeField] float sensitivity = 3f;
    [SerializeField] float speed = 50f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] Transform cameraHolder;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        DoRotation();
        DoMovement();
    }

    private void DoMovement() {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        var dir = new Vector3(hor, rb.velocity.y, ver); // svìtový movement
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * dir; // local -> global

        if(Input.GetButtonDown("Jump")) {
            move.y = jumpSpeed;
        }

        rb.velocity = new Vector3(move.x * speed, move.y, move.z * speed);
    }

    private void DoRotation() {
        float rotX = Input.GetAxis("Mouse X");
        float rotY = Input.GetAxis("Mouse Y");

        cameraRotation.x -= rotY * sensitivity;
        rotation.y += rotX * sensitivity;

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -50, 80);

        transform.rotation = Quaternion.Euler(rotation);
        cameraHolder.localRotation = Quaternion.Euler(cameraRotation);
    }
}
