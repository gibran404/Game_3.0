using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect_Attack : MonoBehaviour
{
    public GameObject deathPanel;

    public void Start()
    {
        deathPanel.SetActive(false);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement.alive = false;
            deathPanel.SetActive(true);
            enemyMovement.move = false;
            Debug.Log("Player hit by enemy");
        }
    }

}
