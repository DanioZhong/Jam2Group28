using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWithNotes : MonoBehaviour
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    [SerializeField] private string text;
    public string paragraphText => text;

    public bool Interact(Interactor interactor)
    {
        Debug.Log(message: "Opening Box with Notes!");
        return true;
    }
}
