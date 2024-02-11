using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueSystemText, characterNameText;
    [SerializeField]
    private GameObject triangleImage, continueDialogueButton, DialogueCanva;
    [SerializeField]
    [TextArea(5, 15)]
    private string currentDialogueText;
    private bool continueDialogueBool = false;
    Dialogue currentDialogueObject;
    void Start()
    {
        
    }

    public void LoadDialogue(Dialogue DialogueObject)
    {
        DialogueCanva.SetActive(true);
        currentDialogueObject = DialogueObject;
        setActiveTriangle(false);
        currentDialogueText = currentDialogueObject.DialogueText;
        characterNameText.SetText(currentDialogueObject.CharacterName);
        StartCoroutine(DialogueTyper(currentDialogueText, currentDialogueObject.waitTime));
    }

    IEnumerator DialogueTyper(string currentDialogueText,float timeToWait)
    {
        string constructedDialogue = "";
        for (int i = 0; i < currentDialogueText.Length; i++) // Iterate for every character of the Dialogue.
        {
            if (currentDialogueText[i] != char.Parse(" ")) // Only wait time if theres a symbol different from a whitespaces.
            {
                yield return new WaitForSeconds(timeToWait);
            }
            constructedDialogue += currentDialogueText[i];
            // Progressively replaces the text inside the dialogue system everytime.
            dialogueSystemText.SetText(constructedDialogue);
        }
        continueDialogueBool = true;
        setActiveTriangle(true);
    }

    public void dialogueButton()
    {
        continueSkipDialogue();
    }

    void continueSkipDialogue()
    {
        if (continueDialogueBool)
        {
            setActiveTriangle(false);
            dialogueSystemText.SetText("");
            continueDialogueBool = false;
            // Load next dialogue
            if(currentDialogueObject.nextDialogue != null)
            {
                LoadDialogue(currentDialogueObject.nextDialogue);
            }
            else
            {
                DialogueCanva.SetActive(false);
            }
        }
        else
        {
            StopAllCoroutines();
            dialogueSystemText.SetText(currentDialogueText);
            setActiveTriangle(true);
            continueDialogueBool = true;
        }
    }
    void setActiveTriangle(bool Active)
    {
        triangleImage.SetActive(Active);
    }

}
