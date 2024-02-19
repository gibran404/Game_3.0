using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guard : MonoBehaviour
{
    public GameObject dialogPanel;
        public Text dialogText;
        public string[] dialog;
    private int index;
    public GameObject contButton;
    public GameObject playButton;

    public GameObject guard_img;
    public GameObject player_img;
    bool flag;

    public float wordSpeed = 0.02f;
    public bool playerIsClose;
    public bool TextOver;
    public bool Initiated;
    
    //public GameObject winPanel;
    // Start is called before the first frame update

    void Start()
    {
        dialogPanel.SetActive(false);
        contButton.SetActive(false);
        playButton.SetActive(false);
//        winPanel.SetActive(false);
        Initiated = false;
        flag = true;
    }
    void Update()
    {
        // if (!playerIsClose){
        //     //GamePanel.SetActive(false);
        //     winPanel.SetActive(false);
        // }
        if(!Initiated && playerIsClose){
            if(dialogPanel.activeInHierarchy){
                zeroText();
            }
            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Type());
            }
            Initiated = true;
        }

        if(dialogText.text == dialog[index]){
            contButton.SetActive(true);
        }
        else{
            contButton.SetActive(false);
            playButton.SetActive(false);
        }
        if(TextOver == true){
            contButton.SetActive(false);
            playButton.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            Initiated = false;
            zeroText();
        }
    }

    public void zeroText(){
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }

    IEnumerator Type(){
        foreach(char letter in dialog[index].ToCharArray()){
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        if(index == dialog.Length - 1){
            TextOver = true;
        }
        else{
            TextOver = false;
        }
    }

    public void switchchar()
    {
        if(flag){
            guard_img.SetActive(false);
            player_img.SetActive(true);
            flag = false;
        }
        else{
            guard_img.SetActive(true);
            player_img.SetActive(false);
            flag = true;
        }
    }
    public void NextLine()
    {
        if(index < dialog.Length - 1){
            index++;
            dialogText.text = "";

            StartCoroutine(Type());
        }
        else{
            zeroText();
        }
        switchchar();
    }


}
