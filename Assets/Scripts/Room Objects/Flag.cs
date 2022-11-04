using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    [SerializeField] private string text;
    public string paragraphText => text;


    private GameObject global;
    private Initialization global_init;
    
    private bool hasPlayed = false;
    private FMOD.Studio.EventInstance instance;

    private void Start()
    {
        global = GameObject.Find("Global");
        global_init = global.GetComponent<Initialization>();

        instance = FMODUnity.RuntimeManager.CreateInstance("event:/sfx_scene2_keyExit");
    }


    public bool Interact(Interactor interactor)
    {

        global_init.keyList.Find(x => x.name == "Flag").isInteracted = true;

        if (!hasPlayed){
            instance.start();
            hasPlayed = true;
        }
        Debug.Log(message: "Opening Flag!");
        return true;
    }
}
