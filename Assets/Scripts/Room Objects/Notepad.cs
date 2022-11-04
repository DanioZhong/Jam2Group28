using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notepad : MonoBehaviour, IInteractable
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

        instance = FMODUnity.RuntimeManager.CreateInstance("event:/sfx_scene3_keyExit");
    }


    public bool Interact(Interactor interactor)
    {

        global_init.keyList.Find(x => x.name == "Notepad").isInteracted = true;

        if (!hasPlayed){
            instance.start();
            hasPlayed = true;
        }
        Debug.Log(message: "Opening Notepad!");
        return true;
    }
}
