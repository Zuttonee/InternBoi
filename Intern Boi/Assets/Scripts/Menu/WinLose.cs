using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    GameObject win, lose;
    bool end = true;

    // Start is called before the first frame update
    void Start()
    {
        win = transform.GetChild(0).gameObject;
        lose = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVariable.Instance.Won == true)
        {
            if (end)
            {
                end = false;
                win.SetActive(true);
                lose.SetActive(false);
                Time.timeScale = 0f;
                Debug.Log("Won");
            }
        }

        if (GlobalVariable.Instance.Lose == true)
        {
            if (end)
            {
                end = false;
                win.SetActive(false);
                lose.SetActive(true);
                Time.timeScale = 0f;
                Debug.Log("Lost");
            }
        }
    }
}
