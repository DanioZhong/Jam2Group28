using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogControl : MonoBehaviour
{
    private const float FOG_MAX = 30.0f;
    private const float FOG_MIN = 5.0f;

    private Spawner spawner;
    private GameObject player;
    
    private float roomWidth = 10.64f;
    private float stairLength = 34.0f; // I can also make another trigger but that is kinda cringe. 
    

    private bool isFogOn = false;


    private float currPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<Spawner>();
        player = GameObject.Find("Player");
    }

    //https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
    float mod(float x, float m) { 
        return (x%m + m)%m;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is in a room or stair and enable/disable fog appropriately
        currPos = mod(player.transform.position.x+ roomWidth/2, roomWidth + stairLength);
        
        if (currPos < roomWidth && isFogOn){
            Debug.Log("DFog");
            DisableFog();
        }
        if (currPos > roomWidth && !isFogOn){
            Debug.Log("EFog");
            EnableFog();
        }
    }


    // Fogs have transitions
    void EnableFog(){
        isFogOn = true;
        StartCoroutine(LerpEnableFog());
    }

    void DisableFog(){
        isFogOn = false;
        StartCoroutine(LerpDisableFog());
    }

    IEnumerator LerpEnableFog(){
        while (RenderSettings.fogEndDistance > FOG_MIN){
            RenderSettings.fogEndDistance -= 0.5f;
            yield return null;//new WaitForSeconds(.0001f);
        }
    }

    IEnumerator LerpDisableFog(){
        while (RenderSettings.fogEndDistance < FOG_MAX){
            RenderSettings.fogEndDistance += 0.5f;
            yield return null;//ew WaitForSeconds(.0001f);
        }
    }
}
