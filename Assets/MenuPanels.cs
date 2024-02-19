using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanels : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject deathPanel;

    public void Start()
    {
        deathPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerMovement.alive == true)
        {
            if (PausePanel.activeSelf == false)
            {
                PausePanel.SetActive(true);
            }
            else
            {
                PausePanel.SetActive(false);
            }
        }

        if (PlayerMovement.alive == false)
        {
            deathPanel.SetActive(true);
        }
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
    }
}
