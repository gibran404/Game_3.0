using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTown : MonoBehaviour
{
    public GameObject BGDesertB;
    public GameObject BGtownB;
    public GameObject BGDesertG;
    public GameObject BGtownG;
    //make it so when the player leaves to the left, the background shifts to the desert adn when the player leaves to the right, the background shifts to the town
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            BGDesertB.SetActive(false);
            BGtownB.SetActive(true);
            BGDesertG.SetActive(false);
            BGtownG.SetActive(true); 
        }
    }
}
