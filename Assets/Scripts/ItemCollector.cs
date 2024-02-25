using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource PickupSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Cherry"))
        {
            PickupSound.Play();
            Debug.Log("Cherry Collected");
            Destroy(collision.gameObject);
            Score.score += 5;
        }
    }
}
