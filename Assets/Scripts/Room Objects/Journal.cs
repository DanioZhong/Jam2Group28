using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    [SerializeField] private string text;
    public string paragraphText => text;


    private GameObject global;
    private Initialization global_init;

    private void Start()
    {
        global = GameObject.Find("Global");
        global_init = global.GetComponent<Initialization>();

    }


    public bool Interact(Interactor interactor)
    {
        global_init.playEnding();

        global_init.keyList.Find(x => x.name == "Journal").isInteracted = true;


        Debug.Log(message: "Opening Journal!");
        return true;
    }
}
