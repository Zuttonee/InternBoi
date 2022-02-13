using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivityList : MonoBehaviour
{
    public Image currentActivity;
    public Image nextActivity;
    public Sprite norm;


    // Update is called once per frame
    void Update()
    {
        if(GlobalVariable.Instance.selectedItem != null)
        {
            currentActivity.sprite = GlobalVariable.Instance.selectedItem.GetComponent<Image>().sprite;
        }
        else
        {
            currentActivity.sprite = norm;
        }

        if (GlobalVariable.Instance.nextItem != null)
        {
            nextActivity.sprite = GlobalVariable.Instance.nextItem.GetComponent<Image>().sprite;
        }
        else
        {
            nextActivity.sprite = norm;
        }
        
    }
}
