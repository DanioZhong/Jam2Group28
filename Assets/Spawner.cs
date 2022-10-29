using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //grab global setting
    private Setting global_setting;
    


    //create a list of all prefabs
    private List<GameObject> prefabs_rooms;
    private List<GameObject> prefabs_triggers;
    private List<GameObject> prefabs_keys;


    //create a list of rooms
    private List<GameObject> rooms = new List<GameObject>();
    private GameObject defaultRoom;
    //other variable for generate rooms
    [HideInInspector] public bool enableGenerate;

    //create a list of trigger
    private List<GameObject> triggers = new List<GameObject>();
    private GameObject defaultTrigger;

    //create a list of key
    private List<GameObject> keys = new List<GameObject>();
    private GameObject defaultKey;


    //info about where to put the spawn room
    public Vector3 init_Pos;
    public float roomWidth;

    //info about trigger
    public GameObject first_Trigger;
    //info about key
    public GameObject first_Key;

    //local private variables
    Vector3 spawnPos;
    int currRoom = 0; // Dinig room = 1, Bed room = 2

    //local private store init pos
    Vector3 currentPos_Room;
    Vector3 currentPos_Key;
    Vector3 currentPos_Trigger;

    // Start is called before the first frame update
    void Start()
    {
        //init
        enableGenerate = false;
        init_Pos = new Vector3(2.38f, -0.9110641f, -2.690001f);
        currentPos_Room = init_Pos;
        currentPos_Key = first_Key.transform.position;
        currentPos_Trigger = first_Trigger.transform.position;

        //assign global setting
        global_setting = GameObject.Find("Global").GetComponent<Setting>();

        //init prefab
        init_roomPrefab();
        init_keyPrefab();
        init_triggerPrefab();
        generateFurniture();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Trigge " + enableGenerate + " Key " + global_setting.enableDoor);


        //============================================================
        //when trigger is triggered and key has found enable generation

        if (enableGenerate && global_setting.enableDoor)
        {
            generateRoom();
            generateTrigger();
            generateKey();

            //generate another stuffs here;
            generateFurniture();

            destroySpawnedObj();



            global_setting.enableDoor = false;
        }

        //==============================================================

    }



    void init_roomPrefab()
    {

        //store all types of room
        prefabs_rooms = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/Room"));
        //store different rooms into obj variable
        for (int i = 0; i < prefabs_rooms.Count; i++)
        {
            //put assign default room
            if (prefabs_rooms[i].name == "Room")
            {
                defaultRoom = prefabs_rooms[i];
            }
        }
    }

    void init_triggerPrefab()
    {
        //store all types of trigger
        prefabs_triggers = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/Trigger"));
        //store different trigger into obj variable
        for (int i = 0; i < prefabs_triggers.Count; i++)
        {
            //put assign default room
            if (prefabs_triggers[i].name == "Trigger")
            {
                defaultTrigger = prefabs_triggers[i];
            }
        }
    }

    void init_keyPrefab()
    {
        //store all types of keys
        prefabs_keys = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/RoomObject/Key"));
        //store different trigger into obj variable
        for (int i = 0; i < prefabs_keys.Count; i++)
        {
            //put assign default room
            if (prefabs_keys[i].name == "Example")
            {
                defaultKey = prefabs_keys[i];

            }
        }
    }


    void generateRoom()
    {
        //make a room
        //increment init_pos (for new room)
        spawnPos = currentPos_Room;
        spawnPos.x += roomWidth;
        GameObject newRoom = Instantiate(defaultRoom, spawnPos, Quaternion.Euler(0, 0, 0));
        rooms.Add(newRoom);
        currentPos_Room = spawnPos;

    }

    void generateKey()
    {


        //make a key
        spawnPos = currentPos_Key;
        spawnPos.x += roomWidth;
        GameObject newKey = Instantiate(defaultKey, spawnPos, Quaternion.Euler(0, 0, 0));
        keys.Add(newKey);
        currentPos_Key = spawnPos;


    }

    void generateTrigger()
    {
        //make a trigger
        spawnPos = currentPos_Trigger;
        spawnPos.x += roomWidth;
        GameObject newTrigger = Instantiate(defaultTrigger, spawnPos, Quaternion.Euler(0, 0, 0));
        triggers.Add(newTrigger);
        currentPos_Trigger = spawnPos;

    }

    void generateFurniture(){
        //generate Furniture
        // Given children 
        transform.GetChild(currRoom).gameObject.SetActive(false);

        currRoom = (currRoom + 1)% transform.childCount;
        GameObject furnset = transform.GetChild(currRoom).gameObject;
        furnset.SetActive(true);
        
        Vector3 pos;
        foreach (Transform child in furnset.transform){
            spawnPos = child.position;
            spawnPos.x -= roomWidth/2;
            
            child.transform.position = spawnPos;
        }
//        spawnPos = currentPos_Key;
//        spawnPos.x += roomWidth;

    }

    void destroySpawnedObj()
    {
        //destroy
        if (rooms.Count > 1)
        {

            GameObject.Destroy(rooms[0]);
            GameObject.Destroy(triggers[0]);
            GameObject.Destroy(keys[0]);
            rooms.RemoveAt(0);
            triggers.RemoveAt(0);
            keys.RemoveAt(0);
        }

    }


}
