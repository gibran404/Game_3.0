using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standingposCheck : MonoBehaviour
{
    private bool flag = false;
    private bool isEnemyPresent = false;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        isEnemyPresent = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerMovementIso.isFollowed)
        {
            if (!isEnemyPresent)
            {
                playerMovementIso.issafe = true;
                playerMovementIso.isFollowed = false;
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            isEnemyPresent = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isEnemyPresent = false;
        }
    }
}
