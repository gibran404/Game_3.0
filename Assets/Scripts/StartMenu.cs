using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public static string gamemode;

    public void NextScene()
    {
        if (gamemode == "MiniGame")
        {
            // move to the last endingscreen
            SceneManager.LoadScene(9);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (gamemode == "MiniGame")
        {
            if (Score.score >= 30)
                Score.score -= 30;
            else
                Score.score = 0;
        }
        else
        {
            Score.score = 0;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Score.score = 0;
    }
    public void Continue()
    {
        transform.parent.gameObject.SetActive(false);
    }
    public void Continue_PauseMenu()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void MiniGameMode()
    {
        gamemode = "MiniGame";
    }
    public void StoryMode()
    {
        gamemode = "Story";
    }

    public void StartCamel()
    {
        SceneManager.LoadScene(2);
    }
    public void StartMorris()
    {
        SceneManager.LoadScene(4);
    }
    public void StartTyre()
    {
        SceneManager.LoadScene(6);
    }
    public void StartTag()
    {
        SceneManager.LoadScene(8);
    }
}
