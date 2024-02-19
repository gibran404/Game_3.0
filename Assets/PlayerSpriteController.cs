using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSpriteController : MonoBehaviour
{
    public GameObject Boy;
    public GameObject Girl;

    public GameObject BoyMugshot;
    public GameObject GirlMugshot;

    public Text charname_dialogue;

    // Start is called before the first frame update
    void Start()
    {
        if (charSlection.character == "Boy")
        {
            Boy.SetActive(true);
            BoyMugshot.SetActive(true);
            Girl.SetActive(false);
            GirlMugshot.SetActive(false);
        }
        else
        {
            Boy.SetActive(false);
            BoyMugshot.SetActive(false);
            Girl.SetActive(true);
            GirlMugshot.SetActive(true);
        }
        charname_dialogue.text = charSlection.charName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
