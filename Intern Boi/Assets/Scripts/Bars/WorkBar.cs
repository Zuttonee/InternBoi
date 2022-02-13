using UnityEngine;

public class WorkBar : MonoBehaviour
{
    public ProgressBar workBar;
    public int maxWork = 0;

    [SerializeField] float currentGain = 0; //The amount of work to be set when updating the UI

    private void Awake()
    {
        //Initiate work bar
        workBar = workBar.GetComponent<ProgressBar>();
    }

    private void Start()
    {
        //Set max fil to work fill
        workBar.maximumFill = maxWork;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Gain(1);
        }
    }

    /// <summary>
    /// Adds value instantly to show a sudden increase
    /// </summary>
    /// <param name="work"></param>
    public void Gain(float work)
    {
        currentGain += work;
        
        if(currentGain > maxWork)
        {
            //Win condition

            currentGain = maxWork;
        }
        else if(currentGain < 0)
        {
            currentGain = 0;
        }

        workBar.currentFill = currentGain;
    }
}