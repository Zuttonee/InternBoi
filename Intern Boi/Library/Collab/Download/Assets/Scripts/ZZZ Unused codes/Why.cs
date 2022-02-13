using UnityEngine;
using System.Collections;

public class Why : MonoBehaviour
{

    bool isActive;

    private void Update()
    {
        blink();
    }

    void blink()
    {
        if (isActive)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            isActive = false;
        }else if (!isActive)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            isActive = true;
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}