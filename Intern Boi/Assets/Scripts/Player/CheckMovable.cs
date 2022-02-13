using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMovable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        GlobalVariable.Instance.canMoveArea = true;
    }

    private void OnMouseUp()
    {
        GlobalVariable.Instance.canMoveArea = false;
    }
}
