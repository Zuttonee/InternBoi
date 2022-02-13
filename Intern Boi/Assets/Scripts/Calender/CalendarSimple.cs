using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarSimple : MonoBehaviour
{
    public Image calendarBlock;
    public Text calendarDate;

    public bool onSpawn = false;
    public int numberOfDays = 29;

    private bool isCreated;

    void Start()
    {
        if (onSpawn)
        {
            CreateCalendar();
        }
    }

    private void Update()
    {
        calendarDate.text = "Day " + Timer.Instance.currentDay.ToString();
    }

    public void ToggleCalendar()
    {
        if (isCreated)
        {
            DestroyCalendar();
            isCreated = false;
        }
        else if (!isCreated)
        {
            CreateCalendar();
            isCreated = true;
        }
    }

    public void CreateCalendar()
    {
        int date = 0;
        float numberOfWeeks = ((int)(numberOfDays / 7)) + Mathf.Sign(numberOfDays / 7); //round the number up

        for (int weeks = 0; weeks < numberOfWeeks; weeks++)
        {
            for (int days = 0; days < 7; days++)
            {
                date++;

                //can make first block be a prefab instead
                if (weeks == 0 && days == 0)
                {
                    transform.GetChild(0).gameObject.SetActive(true); //set bg active
                    transform.GetChild(0).GetChild(0).gameObject.SetActive(true); //set first block active
                    continue;// skips first block
                }

                if (date > numberOfDays) continue; //skip if blocks is more then the date

                Vector2 pos = new Vector2(calendarBlock.transform.position.x + calendarBlock.rectTransform.sizeDelta.x * days, calendarBlock.transform.position.y - calendarBlock.rectTransform.sizeDelta.y * weeks);
                Image blocks = Instantiate(calendarBlock, pos, Quaternion.identity);

                blocks.GetComponentInChildren<Text>().text = date.ToString(); //set text in the block

                blocks.transform.SetParent(gameObject.transform.GetChild(0));
            }
        }
    }

    public void DestroyCalendar()
    {
        for (int i = transform.GetChild(0).childCount - 1 ; i > 0; i--)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }
        transform.GetChild(0).gameObject.SetActive(false); //set first block false
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false); //set first block false
    }
}
