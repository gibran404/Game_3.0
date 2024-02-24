using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementIso : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    static public bool isalive = true;

    static public bool isFollowed = false;
    static public bool issafe = false;

    public GameObject Boy;
    private SpriteRenderer spriteBoy;
    public GameObject Girl;
    private SpriteRenderer spriteGirl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Freeze rotation so the player doesn't tip over
        isFollowed = false;
        issafe = false;
        isalive = true;

        spriteBoy = Boy.GetComponent<SpriteRenderer>();
        spriteGirl = Girl.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isalive)
        {
            return;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        rb.velocity = movement * speed;

        if (horizontalInput > 0f)
        {
            spriteBoy.flipX = false;
            spriteGirl.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            spriteBoy.flipX = true;
            spriteGirl.flipX = true;
        }

        // if input is horizontal input, flip the player
        // if (horizontalInput != 0)
        // {
        //     transform.rotation = Quaternion.LookRotation(movement);
        // }
    }
}
