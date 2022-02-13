using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    /// <summary>
    /// Prompt to confirm to exit the game
    /// </summary>
	public GameObject quitMenu;
    /// <summary>
    /// The button used to start the game
    /// </summary>
	public Button startButton;
    /// <summary>
    /// The button used to exit the game
    /// </summary>
	public Button exitButton;

	void Awake() 
	{
		startButton = startButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
        quitMenu.SetActive(false);
	}

    /// <summary>
    /// Prompt a message for the player to confirm if they wanted to exit the game
    /// </summary>
	public void ExitPress()
	{
        quitMenu.SetActive(true);
        startButton.enabled = false;
		exitButton.enabled = false;
	}

    /// <summary>
    /// If player changes their mind to exit the game
    /// </summary>
	public void NoPress()
	{
        quitMenu.SetActive(false);
        startButton.enabled = true;
		exitButton.enabled = true;
	}

    /// <summary>
    /// Start the first level of the game
    /// </summary>
	public void StartLevel()
	{
		SceneManager.LoadScene (1); //add in name of first level
	}

    /// <summary>
    /// When player wants to exit the game
    /// </summary>
	public void ExitGame()
	{
		Application.Quit ();

	}
}
