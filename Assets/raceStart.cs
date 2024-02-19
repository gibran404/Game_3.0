using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raceStart : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;
    public GameObject woman;

    public GameObject StartScreen;

    [SerializeField] public float StartTime;
    [SerializeField] public float timePassed;

    public GameObject Timer;
    public static bool raceStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        StartScreen.SetActive(true);
        Timer.SetActive(true);

        StartTime = Time.time;

        if (charSlection.character == "Boy")
        {
            girl.SetActive(false);
            boy.SetActive(true);
        }
        if (charSlection.character == "Girl")
        {
            girl.SetActive(true);
            boy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Time.time - StartTime;
        if (timePassed > 4.5f)
        {
            raceStarted = true;
            StartScreen.SetActive(false);
            Timer.SetActive(false);
        }
        else if (timePassed > 4f)
        {
            Timer.GetComponent<Text>().text = "GO!";
        }
        else if (timePassed > 3f)
        {
            Timer.GetComponent<Text>().text = "Race Starting in: 1";
        }
        else if (timePassed > 2f)
        {
            Timer.GetComponent<Text>().text = "Race Starting in: 2";
        }
        else if (timePassed > 1f)
        {
            Timer.GetComponent<Text>().text = "Race Starting in: 3";
        }
    }
}
