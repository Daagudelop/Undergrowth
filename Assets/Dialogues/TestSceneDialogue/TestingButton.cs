using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingButton : MonoBehaviour
{
    public Dialogue startingDialogue;
    public DialogueManager dialogueManager;
    public void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>(); // Gets reference of Dialogue Manager.
    }
    public void StartTestingDialogue()
    {
        dialogueManager.LoadDialogue(startingDialogue); // Loads starting dialogue.
        gameObject.SetActive(false); // Turns off Button.
    }
}
