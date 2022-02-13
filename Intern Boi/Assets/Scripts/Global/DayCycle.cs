using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{

    //Gets color to gradient to
    [Header("Color Settings")]
    [SerializeField] private Color start;
    [SerializeField] private Color mid;
    [SerializeField] private Color end;

    float TimerInstancecurrentTime;
    float dayDuration;

    private void Start()
    {
        dayDuration = Timer.Instance.dayDuration;
    }

    private void Update()
    {
        ChangeBackground();
    }

    /// <summary>
    /// Slowly Change the color of the backgrounds
    /// </summary>
    public void ChangeBackground()
    {
        if (Timer.Instance.currentTime < dayDuration / 2)
        {
            Camera.main.backgroundColor = Color.Lerp(start, mid, Timer.Instance.currentTime / (dayDuration / 2));
        }
        else if (Timer.Instance.currentTime > Timer.Instance.dayDuration / 2)
        {
            Camera.main.backgroundColor = Color.Lerp(mid, end, (Timer.Instance.currentTime - dayDuration / 2) / dayDuration);
        }
    }
}
