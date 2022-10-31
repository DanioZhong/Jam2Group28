using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

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

    //create a list of stairs
    private List<GameObject> stairs = new List<GameObject>();
    private GameObject defaultStairs;

    //other variable for generate rooms
    [HideInInspector] public bool enableGenerate;

    //create a list of trigger
    private List<GameObject> triggers = new List<GameObject>();
    private GameObject defaultTrigger;

    //create a list of key
    private List<GameObject> furnitureSets = new List<GameObject>();
    private GameObject defaultFurnitureSets;






    //info about where to put the spawn room
    //public Vector3 init_Pos;
    public Vector3 roomPosChange;

    //info about trigger
    //public GameObject first_Trigger;
    //info about key
    //public GameObject first_Key;

    //local private variables
    Vector3 spawnPos;


    //room trigger keyObj Chest
    public List<GameObject> initialObjects;




    //int currRoom = 0; // Dinig room = 1, Bed room = 2

    //local private store init pos
    Vector3 currentPos_Room;
    Vector3 currentPos_Trigger;
    Vector3 currentPos_Stairs;
    Vector3 currentPos_FurnitureSets;

    // Start is called before the first frame update
    void Start()
    {
        //init
        enableGenerate = false;
        currentPos_Room = initialObjects[0].transform.position;
        currentPos_Stairs = initialObjects[1].transform.position;
        currentPos_Trigger = initialObjects[2].transform.position;
        currentPos_FurnitureSets = initialObjects[3].transform.position;

        //push them into the list and remove from current list after getting the current pos
        rooms.Add(initialObjects[0]);
        stairs.Add(initialObjects[1]);
        triggers.Add(initialObjects[2]);
        furnitureSets.Add(initialObjects[3]);


        //assign global setting
        global_setting = GameObject.Find("Global").GetComponent<Setting>();

        //load prefab
        init_roomPrefab();
        init_FurniturePrefab();
        init_triggerPrefab();
        //generateFurniture();

    }
    
    // Update is called once per frame
    private void Update()
    {

        //Debug.Log("Trigge " + enableRoomChange + " Key " + global_setting.enableDoor);

        //============================================================
        //when trigger is triggered and key has found enable generation

        //  if (enableGenerate && global_setting.enableRoomChange)
        if (enableGenerate)
        {
            enableGenerate = false;
            Debug.Log("Generate");
            generateRoom();
            generateTrigger();
            generateFurniture();


            destroySpawnedObj();

            // generateKey();

            // //generate another stuffs here;
            //// generateFurniture();
            //spawnPos = currentPos_Room;
            //GameObject newRoom = Instantiate(defaultRoom, spawnPos, Quaternion.Euler(0, 0, 0));
            //destroySpawnedObj();

            // global_setting.enableRoomChange = false;
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
            }else if (prefabs_rooms[i].name == "Stairs")
            {
                defaultStairs = prefabs_rooms[i];
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

    void init_FurniturePrefab()
    {
        //store all types of keys
        prefabs_keys = new List<GameObject>(Resources.LoadAll<GameObject>("Prefabs/Furniture"));
        //store different trigger into obj variable
        for (int i = 0; i < prefabs_keys.Count; i++)
        {
            //put assign default room
            if (prefabs_keys[i].name == "Furniture Sets")
            {
                defaultFurnitureSets = prefabs_keys[i];

            }
        }
    }


    void generateRoom()
    {

        
        //make a room
        //increment init_pos (for new room)
        spawnPos = currentPos_Room;
        spawnPos.x += roomPosChange.x;
        spawnPos.y += roomPosChange.y;
        GameObject newRoom = Instantiate(defaultRoom, spawnPos, Quaternion.Euler(0, 0, 0));
        rooms.Add(newRoom);
        currentPos_Room = spawnPos;
        //make a stair
        spawnPos = currentPos_Stairs;
        spawnPos.x += roomPosChange.x;
        spawnPos.y += roomPosChange.y;
        GameObject newStairs = Instantiate(defaultStairs, spawnPos, Quaternion.Euler(0, -90, 0));
        stairs.Add(newStairs);
        currentPos_Stairs = spawnPos;


    }

    void generateFurniture()
    {
        //make furniture set
        spawnPos = currentPos_FurnitureSets;
        spawnPos.x += roomPosChange.x;
        spawnPos.y += roomPosChange.y;
        GameObject newSet = Instantiate(defaultFurnitureSets, spawnPos, Quaternion.Euler(0, 0, 0));
        furnitureSets.Add(newSet);
        currentPos_FurnitureSets = spawnPos;
    }


    void generateTrigger()
    {
        //make a trigger
        spawnPos = currentPos_Trigger;
        spawnPos.x += roomPosChange.x;
        spawnPos.y += roomPosChange.y;
        GameObject newTrigger = Instantiate(defaultTrigger, spawnPos, Quaternion.Euler(0, 0, 0));
        triggers.Add(newTrigger);
        currentPos_Trigger = spawnPos;
    }

    //void generateFurniture()
    //{
    //    //generate Furniture
    //    // Given children 
    //    transform.GetChild(currRoom).gameObject.SetActive(false);

    //    currRoom = (currRoom + 1) % transform.childCount;
    //    GameObject furnset = transform.GetChild(currRoom).gameObject;
    //    furnset.SetActive(true);

    //    //Vector3 pos;
    //    foreach (Transform child in furnset.transform)
    //    {
    //        spawnPos = currentPos_Room;
    //        // spawnPos.x -= roomWidth/2;

    //        child.transform.position = spawnPos;
    //    }
    //    //        spawnPos = currentPos_Key;
    //    //        spawnPos.x += roomWidth;

    //}


    void destroySpawnedObj()
    {
        //destroy all objects
        //GameObject.Destroy(rooms[0]);
        //GameObject.Destroy(furnitureSets[0]);
        GameObject.Destroy(triggers[0]);
        //rooms.RemoveAt(0);
        //furnitureSets.RemoveAt(0);
        triggers.RemoveAt(0);
        //if (stairs.Count > 2)
        //{
        //    GameObject.Destroy(stairs[0]);
        //    stairs.RemoveAt(0);
        //}

    }


}
