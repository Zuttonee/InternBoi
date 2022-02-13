using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achivement : MonoBehaviour
{
    /// <summary>
    /// Used to turn the achivement bar on and off
    /// </summary>
    public Transform achivementBar;

    /// <summary>
    /// Turns the Menu on if off and off if on
    /// </summary>
    public void ToggleMenu()
    {
        if (achivementBar.gameObject.activeInHierarchy)
        {
            CloseActivityMenu();
        }
        else if (!achivementBar.gameObject.activeInHierarchy)
        {
            OpenActivityMenu();
        }
    }

    /// <summary>
    /// Turns the achivement bar on
    /// </summary>
    public void OpenActivityMenu()
    {
        achivementBar.gameObject.SetActive(true);
        GlobalVariable.Instance.canMove = false;
        //Time.timeScale = 0f;
    }

    /// <summary>
    /// Turns the achivement bar off
    /// </summary>
    public void CloseActivityMenu()
    {
        achivementBar.gameObject.SetActive(false);
        GlobalVariable.Instance.canMove = true;
        //Time.timeScale = 1f;
    }
}
