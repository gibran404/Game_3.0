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
            if (Score.score >= 10)
                Score.score -= 10;
            else
                Score.score = 0;

            PlayerMovement.alive = false;
            deathPanel.SetActive(true);
            enemyMovement.move = false;
            Debug.Log("Player hit by enemy");
        }
    }

}
