using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public Text dialogText;
    public GameObject EndButton;
    public GameObject guard_img;

    public bool playerWon;

    public GameObject winPanel;
    public GameObject ScorePanel;
    public GameObject HintPanel;
    public GameObject SpeedPanel;

    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerWon = true;
            raceStart.raceStarted = false;
        }
        else if (other.CompareTag("AI"))
        {
            playerWon = false;
            raceStart.raceStarted = false;
        }
        HintPanel.SetActive(false);
        SpeedPanel.SetActive(false);
        ScorePanel.SetActive(true);
        winPanel.SetActive(true);
        Win();
    }
    public void Win()
    {
        if (playerWon)
        {
            dialogText.GetComponent<Text>().text = "Congratulations you won the Race!\n You can now continue onwards or Retry";
            winPanel.SetActive(true);

            
            Score.score += 40;
        }
        if (!playerWon)
        {
            dialogText.GetComponent<Text>().text = "You Lost the game, Better luck next time!\n You can now continue onwards or Retry";
            winPanel.SetActive(true);

            if (Score.score >= 20)
                Score.score -= 20;
            else
                Score.score = 0;
        }
    }

}