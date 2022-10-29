using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidBuildingBlox : MonoBehaviour, IInteractable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    [SerializeField] private string text;
    public string paragraphText => text;

    public bool Interact(Interactor interactor)
    {
        Debug.Log(message: "Opening Kid Building Blox!");
        return true;
    }
}
