using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    public int dayDuration;

    public float currentTime;
    public int currentDay = 0;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        currentDay++;
    }

    private void Start()
    {
        GameEvents.Instance.DayStart();

    }

    // Update is called once per frame
    void Update()
    {
        TimeSpent();
    }

    void TimeSpent()
    {
        currentTime += Time.deltaTime;

        //Reset Timer
        if (currentTime >= dayDuration)
        {
            currentTime = 0;

            currentDay++;
            GameEvents.Instance.DayStart();
        }
    }

    public int CurrentPeriod()
    {
        float section = dayDuration / 4;

        if (currentTime > section * 3)
        {
            return 3;
        }
        else if (currentTime > section * 2)
        {
            return 2;
        }
        else if (currentTime > section)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
