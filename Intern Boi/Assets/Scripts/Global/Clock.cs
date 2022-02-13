using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimePlayed : MonoBehaviour {

    public Text timerText; //Call out to update the timer
    public Text currentDay; //Call out to update the day

    public bool countdown; //Check to count up or count down

	void Awake() 
	{
        GlobalVariable.Instance.UpdateDay();

        //Increment day for calendar
        GlobalVariable.Instance.currentday++;
        currentDay.text = "Day " + GlobalVariable.Instance.currentday.ToString();
    }

    private void FixedUpdate()
    {
        TimeSpent();
        UpdateTimer();
    }

    /// <summary>
    /// Increment the ingame timer
    /// </summary>
    void TimeSpent()
    {
        GlobalVariable.Instance.currentTime += Time.deltaTime;

        //Reset Timer
        if (GlobalVariable.Instance.currentTime >= GlobalVariable.Instance.timeLimit)
        {
            GlobalVariable.Instance.currentTime = 0;

            GlobalVariable.Instance.UpdateDay();
            FindObjectOfType<DayOverview>().EndOfDay();

            //Increment day for calendar
            GlobalVariable.Instance.currentday++;
            currentDay.text = "Day " + GlobalVariable.Instance.currentday.ToString();
        }
    }

    /// <summary>
    /// Update the timer
    /// </summary>
    void UpdateTimer()
    {
        //Check to see if the timer is needed to count up or countdown
        if (countdown)
        {
            timerText.GetComponent<Text>().text = string.Format("{0}", Mathf.Floor(GlobalVariable.Instance.currentTime));
        }
        else
        {
            timerText.GetComponent<Text>().text = string.Format("{0}", GlobalVariable.Instance.timeLimit - Mathf.Floor(GlobalVariable.Instance.currentTime)); //Countdown
        }
    }
}