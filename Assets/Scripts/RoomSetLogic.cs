using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetLogic : MonoBehaviour
{
    int currRoom = 0;

    // Start is called before the first frame update
    void Awake()
    {
        // Disable all but 0
        Debug.Log("HAHA");
        updateSet(0);
    }

    void AdvanceToNext(){ // Won't be called due to destroying
        currRoom = (currRoom + 1) % 6;
        updateSet(currRoom);
    }

    public void updateSet(int room){
        Debug.Log("PPP" + room.ToString());
        int i = 0;
        foreach(Transform child in transform){
            if (i == room)
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
            i++;
        }
    }
}
