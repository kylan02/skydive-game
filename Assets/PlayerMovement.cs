using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        DirectionalMove();
    }

    void DirectionalMove() {

        Vector3 curentSpeed = rb.velocity;

        if (Input.GetKey(KeyCode.W)) {
            curentSpeed.z = speed;
        }
        if (Input.GetKey(KeyCode.S)) {
            curentSpeed.z = -speed;
        }
        if (Input.GetKey(KeyCode.A)) {
            curentSpeed.x = -speed;
        }
        if (Input.GetKey(KeyCode.D)) {
            curentSpeed.x = speed;
        }
        rb.velocity = curentSpeed;
    }
}
