using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public Transform spawn1;
    public GameObject gameScene;
    public GameObject goTo;

    private bool firstTime = true;
 
    private bool hasTele = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && hasTele)
        {
            hasTele = false;
            gameScene.SetActive(false);
            goTo.SetActive(true);
            player.transform.position = spawn1.position;
            GlobalVariable.Instance.room = goTo.name;

            if (firstTime)
            {
                if (gameObject.name == "Office Scene")
                {
                    this.GetComponent<DialogueTrigger>().TriggerDialogue();
                    firstTime = false;
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasTele = true;
    }
}
