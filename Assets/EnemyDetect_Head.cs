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
            Destroy(transform.parent.gameObject);
            Debug.Log("Player hit head");
        }
    }
}
