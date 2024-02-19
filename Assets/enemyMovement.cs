using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    private bool moveright = true;

    

    private void Update()
    {
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
        }
    }
}
