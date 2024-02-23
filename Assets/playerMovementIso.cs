using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementIso : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze rotation so the player doesn't tip over
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.velocity = movement * speed;

        // if input is horizontal input, flip the player
        // if (horizontalInput != 0)
        // {
        //     transform.rotation = Quaternion.LookRotation(movement);
        // }
    }
}
