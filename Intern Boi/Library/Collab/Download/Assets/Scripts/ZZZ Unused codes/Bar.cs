using UnityEngine;

//Not implemented Yet
public struct Bar
{
    //Call out the stress bar to be decrease
    private Transform _bar { get { return _bar; } set { _bar = value; } }

    //Check if need text indicating the value of drain/gain
    private bool _hasValueText { get { return _hasValueText; } set { _hasValueText = value; } }

    //The amount of constant drain/gain being added to the bar to be decreased
    private float _currentValue { get { return _currentValue; } set { _currentValue = value; } }

    private const float _maxBarValue = 100;

    public Bar(Transform bar, float currentValue)
    {
        _bar = bar;
        _currentValue = currentValue;
    }

    /// <summary>
    /// Slow increase value by _barIncrement
    /// </summary>
    /// <param name="_barIncrement"></param>
    /// <param name="_faceIndicator"></param>
    /// <param name="_faces"></param>
    public void GainOverTime(float _barIncrement)
    {
        _currentValue += _barIncrement * Time.deltaTime;

        //Prevent bar underflow
        if (_currentValue < 0)
        {
            _currentValue = 0;
        }

        if (_currentValue > _maxBarValue)
        {
            //lose condition
            GlobalVariable.Instance.Lose = true;
            //Prevent bar overflow
            _currentValue = _maxBarValue;
        }

        //Update Charge UI
        UpdateBar();
    }

    /// <summary>
    /// Adds value instantly to show a sudden increase
    /// </summary>
    /// <param name="gainValue"></param>
    public void InstantGain(float gainValue)
    {
        _currentValue += gainValue;

        if (_currentValue < 0)
        {
            //Prevent bar underflow
            _currentValue = 0;
        }

        if (_currentValue >= _maxBarValue)
        {
            //Win condition
            GlobalVariable.Instance.Won = true;
            //Prevent bar overflow
            _currentValue = _maxBarValue;
        }

        //Update work UI
        UpdateBar();
    }

    /// <summary>
    /// Sets the "+" at the start if the number
    /// </summary>
    /// <param name="_barIncrement"></param>
    /// <returns></returns>
    string CurrentIncrement(float _barIncrement)
    {
        return OperatorSign(_barIncrement) + _barIncrement;
    }

    /// <summary>
    /// Update the length of the bar based on the ratio of the current value an the max value;
    /// </summary>
    void UpdateBar()
    {
        float ratio = _currentValue / _maxBarValue;
        _bar.transform.localScale = new Vector3(ratio, 1);
    }

    //Get the operator sign can be improved upon
    string OperatorSign(float value)
    {
        string sign;

        if (value == 0)
        {
            sign = "+";
        }
        else if (Mathf.Sign(value) == 1)
        {
            sign = "";
        }
        else if (Mathf.Sign(value) == -1)
        {
            sign = "+";
        }
        else
        {
            sign = "";
        }

        return sign;
    }

}
