using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{

    public GameObject teleporters;
    [HideInInspector] public List<GameObject> teleportersList = new List<GameObject>();



    // Start is called before the first frame update
    void Start()
    {



        //store all teleporters into the list;
        for(int i = 0; i < teleporters.transform.childCount; i++)
        {
            //double check if there are teleporters
            if(teleporters.transform.GetChild(i).tag == "teleporter")
            {
                teleportersList.Add(teleporters.transform.GetChild(i).gameObject);
            }
        }//for end

    }
}
