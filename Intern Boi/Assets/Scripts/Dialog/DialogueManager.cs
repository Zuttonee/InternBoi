using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    /// <summary>
    /// The name indicating who is talking
    /// </summary>
	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;

    public bool loadScene = false;

    bool sentanceCleared = false;

	// Use this for initialization
	void Start () 
	{
 		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
            if (loadScene)
            {
                EndDialogue();
                return;
            }
            animator.SetBool("IsOpen", false);
            return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);

		SceneManager.LoadScene(2); //load into main game scene
	}

}
