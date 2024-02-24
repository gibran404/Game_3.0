using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagGameController : MonoBehaviour
{
    static public int NPCCount = 4;
    public GameObject WinPanel;
    public GameObject DeathPanel;

    // Start is called before the first frame update
    void Start()
    {
        NPCCount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCCount == 0)
        {
            Debug.Log("You win!");
            // player win panel
            WinPanel.SetActive(true);
            NPCCount = -1;
        }
        if (!playerMovementIso.isalive)
        {
            Debug.Log("You lose!");
            // player lose panel
            DeathPanel.SetActive(true);
        }

        
    }
    
}
