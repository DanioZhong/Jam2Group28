using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomSetLogic : MonoBehaviour
{
    int currRoom = 0;


    private GameObject global;
    private Initialization global_init;


    [HideInInspector]
    public void NextRoomCheck(){ // Won't be called due to destroying
        // Look at this!
        global = GameObject.Find("Global");
        global_init = global.GetComponent<Initialization>();

        if (global_init.keyList.Find(x => x.name == "Box").isInteracted)
        {
            currRoom = 1;
        }
        if (global_init.keyList.Find(x => x.name == "Flag").isInteracted)
        {
            currRoom = 2;
        }
        if (global_init.keyList.Find(x => x.name == "Notepad").isInteracted)
        {
            currRoom = 3;
            transform.GetChild(5).gameObject.SetActive(false);
        }
        if (global_init.keyList.Find(x => x.name == "Blox").isInteracted)
        {
            currRoom = 4;
            transform.GetChild(5).gameObject.SetActive(true);
        }
        if (global_init.keyList.Find(x => x.name == "Journal").isInteracted)
        {
            currRoom = -1;

        }

        Debug.Log("Generate Room " + currRoom);
        updateSet(currRoom);
    }

    [HideInInspector]
    public void updateSet(int room){

        if(currRoom != -1)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == room)
                {
                    Debug.Log("enable room " + i);
                    transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
