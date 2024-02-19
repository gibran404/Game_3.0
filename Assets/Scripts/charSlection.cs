using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charSlection : MonoBehaviour
{
    public static string character = "Boy";
    public static string charName = "";


    // Start is called before the first frame update
    public void PickBoy()
    {
        character = "Boy";
        charName = "Hammad";
    }
    public void Pickgirl()
    {
        character = "Girl";
        charName = "Ayesha";
    }
}
