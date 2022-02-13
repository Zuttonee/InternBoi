using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

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
    }

    public event Action onDayStart;
    public event Action onDayEnd;
    public event Action onGameWin;
    public event Action onGameLose;

    public void DayStart()
    {
        if(onDayStart != null)
        {
            onDayStart();
        }
    }

    public void DayEnd()
    {
        if (onDayEnd != null)
        {
            onDayEnd();
        }
    }

    public void GameWin()
    {
        if (onGameWin != null)
        {
            onGameWin();
        }
    }

    public void GameLose()
    {
        if (onGameLose != null)
        {
            onGameLose();
        }
    }

    void Update()
    {
        
    }
}
