using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    keyObjects tempKey = new keyObjects();

    private void Awake()
    {
        tempKey.name = "Notepad";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);

        tempKey.name = "Trophy";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);

        tempKey.name = "Blox";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);

        tempKey.name = "Box";
        tempKey.isInteracted = false;
        tempKey.obj = null;
        keyList.Add(tempKey);

    }

}
