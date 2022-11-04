using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialization : MonoBehaviour
{

    [HideInInspector]
    public class keyObjects
    {
        public string name;
        public GameObject obj;
        public bool isInteracted; 
    }

    [HideInInspector] public  List<keyObjects> keyList = new List<keyObjects>();
    [HideInInspector] public keyObjects tempKey;

    [SerializeField]
    private GameObject fadeOut;
    private FadeControll fadeOut_script;


    private void Awake()
    {
        fadeOut_script = fadeOut.GetComponent<FadeControll>();

        tempKey = new keyObjects();
        tempKey.name = "Notepad";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);


        tempKey = new keyObjects();
        tempKey.name = "Journal";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);


        tempKey = new keyObjects();
        tempKey.name = "Blox";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);

        tempKey = new keyObjects();
        tempKey.name = "Flag";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);

        tempKey = new keyObjects();
        tempKey.name = "Box";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);
    }


    [HideInInspector] public void playEnding()
    {
        fadeOut.SetActive(true);
        //
        StartCoroutine(prepareForFadeOut());


    }

    public int ReadingTime;

    //5 second deley after reading final jounal 
    IEnumerator prepareForFadeOut()
    {
        //reading time adjust from here
        yield return new WaitForSeconds(ReadingTime);
        //three second fade out animation => 
        StartCoroutine(fadeOut_script.fadeoutEnd());
    }



}
