using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect_Head : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //destroy parent object
            if (PlayerMovement.alive)
            {
                Destroy(transform.parent.gameObject);
                Score.score += 10;
                Debug.Log("Player hit head");
            }
        }
    }
}
