using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour 
{
	public Dialogue dialogue;
    public bool runAtStart = false; // Made it so it works with the actual game view

    //Scene currentScene = SceneManager.GetActiveScene();

    public void Start()
	{
        //TriggerDialogue(); NOTE: Cannot be place at start as some dialog needs to be triggered and this script is used for triggering the dialog and not just for the intro screen
        if (runAtStart)
        {
            TriggerDialogue();
        }
	}

    public void TriggerDialogue()
	{
         FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
