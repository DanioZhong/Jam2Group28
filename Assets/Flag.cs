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

    private void Start()
    {
        global = GameObject.Find("Global");
        global_init = global.GetComponent<Initialization>();

    }


    public bool Interact(Interactor interactor)
    {

        global_init.keyList.Find(x => x.name == "Flag").isInteracted = true;


        Debug.Log(message: "Opening Flag!");
        return true;
    }
}
