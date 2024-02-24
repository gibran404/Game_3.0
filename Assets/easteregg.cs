using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easteregg : MonoBehaviour
{
    public GameObject Credits;
    [SerializeField] private string inputString;

    // Start is called before the first frame update
    void Start()
    {
        Credits.SetActive(false);
        inputString = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            inputString += Input.inputString;
        }
        //if S held down, open panel
        if (Input.GetKey(KeyCode.S))
        {
            if (inputString == "credits" || inputString == "Credits" || inputString == "CREDITS")
            {
                Credits.SetActive(true);
            }
            inputString = "";
        }
    }
}
