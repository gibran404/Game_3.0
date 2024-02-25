using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_indicator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // after 4 seconds, disable parent gameobject
        StartCoroutine(DisableAfterTime());
    }

    IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(2);
        //fade out before disabling

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
