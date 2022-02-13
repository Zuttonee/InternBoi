using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public ProgressBar HpBar;
    public int maxStress = 0;

    [SerializeField] float currentHP; //The amount of stress now
    [SerializeField] Text stressValue; //Call out the value which the value decreased by
    

    //Used to indicate the stress level of the character
    [Header("Image Settings")]
    [SerializeField] Image faceIndicator; //Change the face expression for the stress bar
    [SerializeField] Sprite[] images = new Sprite[4]; //Change the face expression for the stress bar

    private void Awake()
    {
        HpBar = HpBar.GetComponent<ProgressBar>();

        stressValue = stressValue.GetComponent<Text>();
        //faceIndicator = faceIndicator.GetComponent<Image>();
    }

    private void Start()
    {
        HpBar.maximumFill = maxStress;
        HpBar.inverse = true;
    }

    private void Update()
    {
        Drain(GlobalVariable.Instance.currentStress);
    }

    /// <summary>
    /// Slowly increase the amount of stress level by barIncrement
    /// </summary>
    /// <param name="stress"></param>
    public void Drain(float stress)
    {
        currentHP += stress * Time.deltaTime;

        if (currentHP > maxStress)
        {
            currentHP = maxStress;
        }
        else if (currentHP < 0)
        {
            currentHP = 0;
        }

        HpBar.currentFill = currentHP;

        //update stress indicator
        //stressValue.text = OperatorSign(barIncrement) + ((barIncrement));
    }

    /// <summary>
    /// When place a positive number or 0, it will return "+"
    /// When place a negetive number, it will return "-"
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <returns></returns>
    string OperatorSign(float value)
    {
        string sign;

        if (value == 0)
        {
            sign = "";
        }
        else if (Mathf.Sign(value) == 1)
        {
            sign = "+";
        }
        else if (Mathf.Sign(value) == -1)
        {
            sign = "";
        }
        else
        {
            sign = "+";
        }

        return sign;
    }
}
