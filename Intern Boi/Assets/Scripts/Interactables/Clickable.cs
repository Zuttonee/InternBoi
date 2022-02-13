using UnityEngine;

public class Clickable : MonoBehaviour
{
    /// <summary>
    /// Used to call the menu to be opened up then the player interact with the object
    /// </summary>
    public GameObject menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the object collider
        if (collision.gameObject.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true); // Display the highlighted sprited
            menu.SetActive(true); // Open up the menu in which the player can interact with
            GlobalVariable.Instance.canMove = false; // Prevent teh player from moving
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(false); // Disable the highlighted sprite
            menu.SetActive(false); // Close the menu in which the player can interact with
        }
    }
}
