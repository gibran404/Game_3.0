using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    private bool moveright = true;

    public static bool move = true;

    private void Start()
    {
        move = true;
        
    }

    private void Update()
    {
        if (!move)
        {
            return;
        }
        // Move the parent object in the right direction
        if (moveright)
        {
            transform.parent.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.parent.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the parent object collides with the wall, change direction
        if (collision.gameObject.tag == "Ground")
        {
            moveright = !moveright;
            // Flip the parent object's sprite
            transform.parent.localScale = new Vector3(-transform.parent.localScale.x, transform.parent.localScale.y, transform.parent.localScale.z);
        }
    }
}
