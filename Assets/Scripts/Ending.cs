using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{

    public int waitSecond;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndingCoroutine());
        //Debug.Log("The application is quitting");
    }


    IEnumerator EndingCoroutine()
    {
        //wait three seconds and then end the program
        yield return new WaitForSeconds(waitSecond);
        Application.Quit();
    }
}
