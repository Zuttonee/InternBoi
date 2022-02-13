using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayOverview : MonoBehaviour
{
    public Animator animator;
    public GameObject canvas;

    public Text dayStats;
    public Text currentDay;


    public void EndOfDay()
    {
        int currentStress = (int)GlobalVariable.Instance.currentStress;
        animator.SetTrigger("Fade_In");
        dayStats.text = "Curret Stress: " + currentStress + " / " + GlobalVariable.Instance.maxStress + "\n" +
                        "Work Done: " + GlobalVariable.Instance.currentWork + " / " + GlobalVariable.Instance.maxWork;
        currentDay.text = "Day\n" + GlobalVariable.Instance.currentday;
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartDay()
    {
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
        animator.SetTrigger("Fade_Out");
    }
}
