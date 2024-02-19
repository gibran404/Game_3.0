using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGD : MonoBehaviour
{
    public GameObject BGDesert;
    public GameObject BGTown;
    public GameObject BGDesertG;
    public GameObject BGTownG;
    //make it so when the player leaves to the left, the background shifts to the desert adn when the player leaves to the right, the background shifts to the town
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            BGDesert.SetActive(true);
            BGTown.SetActive(false);
            BGDesertG.SetActive(true);
            BGTownG.SetActive(false);
            
        }
    }
}
