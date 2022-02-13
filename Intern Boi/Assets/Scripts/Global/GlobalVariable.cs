using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public static GlobalVariable Instance { get; private set; }

    //Activity Bar
    [Header("Activity Bar")]
    public GameObject selectedItem;
    public GameObject nextItem;
    public int currentItemSelected = 0;
    //Stress Bar
    [Header("Stress Bar")]
    public float currentStress;
    public float totalStress = 0;
    public float stressGainRate;

    //Work Bar
    [Header("Work Bar")]
    public float maxWork = 100;
    public float currentWork;
    public float totalWork;
    public float workGainRate = 0;

    //Timer
    [Header("Timer")]
    public float timeLimit = 10;
    public float currentTime;

    public int currentday = 0;

    //Win condition
    [Header("Win/Lose Condition")]
    public bool Won = false;
    public bool Lose = false;

    //Player
    [Header("Player Condition")]
    public bool canMove = true;
    public bool canMoveArea = false;

    //Check which room
    [Header("Current room")]
    public string room;

    private GameObject office;
    private GameObject pantry;

    private void Update() 
    { 
        //FindObjectOfType<DayCycle>().ChangeBackground();
        //RoomEffects();
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        office = GameObject.Find("Office Scene");
        pantry = GameObject.Find("Pantry Scene");
    }

    /// <summary>
    /// Call to update the day
    /// </summary>
    public void UpdateDay()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        pantry.SetActive(false);
        office.SetActive(true);

        FindObjectOfType<WorkBar>().Gain(GlobalVariable.Instance.totalWork); //Add work value

        if (!Won)
        {
            FindObjectOfType<DaySchedule>().OpenActivityMenu(); //needs to be active
            foreach (Slots slots in FindObjectsOfType<Slots>()) slots.SpawnItem(); //Spawn blocks
        }

        FindObjectOfType<DaySchedule>().RestSelected();
    }

    /// <summary>
    /// Grants the player the effect of the room
    /// </summary>
    /// <example>Player reduce stress in the pantry and gain stress in the office</example>
    public void RoomEffects()
    {
        if (room == "Pantry Scene")
        {
            stressGainRate = -1;
        }
        if (room == "Office Scene")
        {
            stressGainRate = 1;
        }
    }
}