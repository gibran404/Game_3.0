using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continueButtonPauseMenu : MonoBehaviour
{
    public void Continue()
    {
        //hide the parent object
        transform.parent.gameObject.SetActive(false);
    }
}
