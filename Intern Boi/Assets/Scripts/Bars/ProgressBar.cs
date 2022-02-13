using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar: MonoBehaviour
{
    public int minimumFill { get; set; }
    public int maximumFill { get; set; }
    public float currentFill { get; set; }

    public Image mask;
    public Image fill;
    public Color Color;

    public bool inverse;

    private void Update()
    {
        GetCurrentFill();
    }

    public void GetCurrentFill()
    {
        float currentOffset = currentFill - minimumFill;
        float maximunOffset = maximumFill - minimumFill;
        float fillAmount = currentOffset / maximunOffset;
        if (inverse)
        {
            mask.fillAmount = 1 - fillAmount;
        }
        else
        {
            mask.fillAmount = fillAmount;
        }
    }
}
