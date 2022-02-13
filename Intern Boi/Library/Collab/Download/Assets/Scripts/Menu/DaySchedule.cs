using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DaySchedule : MonoBehaviour, IHasChanged
{
    [SerializeField] private Transform selectSlots; //Used to get all the timeblock data by accessing thier slots
    [SerializeField] private Transform errorText;

    private bool firstTime = true;
    private Animator anim;

    [SerializeField] int _currentPeriod = 0;

    private void Awake()
    {
        selectSlots = selectSlots.GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        GameEvents.Instance.onDayStart += OpenActivityMenu;
        _currentPeriod = Timer.Instance.CurrentPeriod();

    }

    private void Update()
    {
        if (_currentPeriod != Timer.Instance.CurrentPeriod())
        {
            _currentPeriod = Timer.Instance.CurrentPeriod();

            GameObject item = selectSlots.GetChild(_currentPeriod).GetChild(0).gameObject;
            GlobalVariable.Instance.selectedItem = item;

            GameObject nextitem;
            if (_currentPeriod + 1 > 3)
            {
                _currentPeriod = 3;
                nextitem = null;
            }
            else
            {
                nextitem = selectSlots.GetChild(_currentPeriod + 1).GetChild(0).gameObject;
            }
            GlobalVariable.Instance.nextItem = nextitem;

            TimeBlockData data = item.GetComponent<TimeBlockData>();
            GlobalVariable.Instance.totalStress = data.stressValue;
            GlobalVariable.Instance.totalWork = data.workValue;
        }
    }

    /// <summary>
    /// Will be call when there is a change in the selected part of the slot
    /// example: adding new block in to the slot
    /// </summary>
    public void HasChanged()
    {
        //Resets values so that block data would not increment
        GameObject item = selectSlots.GetChild(_currentPeriod).GetChild(0).gameObject;
        GlobalVariable.Instance.selectedItem = item;

        GameObject nextitem;
        if (_currentPeriod + 1 > 3)
        {
            _currentPeriod = 3;
            nextitem = null;
        }
        else
        {
            nextitem = selectSlots.GetChild(_currentPeriod + 1).GetChild(0).gameObject;
        }
        GlobalVariable.Instance.nextItem = nextitem;

        TimeBlockData data = item.GetComponent<TimeBlockData>();
        GlobalVariable.Instance.totalStress = data.stressValue;
        GlobalVariable.Instance.totalWork = data.workValue;

        RestSelected();
        //Used to access all the slot to get the data needed to find the amount of work and stress to recive
        foreach (Transform slotTransform in selectSlots)
        {
            GameObject _item = slotTransform.GetComponent<Slots>().item;
            if (_item)
            {
                GlobalVariable.Instance.currentItemSelected++;
            }
        }
    }   

    /// <summary>
    /// Rest all selected field in the activity bar
    /// </summary>
    public void RestSelected()
    {
        GlobalVariable.Instance.totalStress = 0;
        GlobalVariable.Instance.totalWork = 0;
        GlobalVariable.Instance.stressGainRate = 1;
        GlobalVariable.Instance.currentItemSelected = 0;
    }

    /// <summary>
    /// Turns the Activity on
    /// </summary>
    public void OpenActivityMenu()
    {
        //GlobalVariable.Instance.canMove = false;
        //Time.timeScale = 0f;

        anim.SetBool("isSchedule", true);
    }

    /// <summary>
    /// Turns the Activity off
    /// </summary>
    public void CloseActivityMenu()
    {
        if(GlobalVariable.Instance.currentItemSelected == 4)
        {
            anim.SetBool("isSchedule", false);
            //GlobalVariable.Instance.canMove = true;
            if (firstTime)
            {
                //this.GetComponent<DialogueTrigger>().TriggerDialogue();
                firstTime = false;
                //errorText.gameObject.SetActive(false);
            }
        }
        else
        {
            //errorText.gameObject.SetActive(true);
            //errorText.GetChild(0).GetComponent<Text>().text = "Please fill up all the slots!";
        }
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}
