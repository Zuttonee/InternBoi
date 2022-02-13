using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f; // The player travel speed

    private Rigidbody2D rb;
    private Vector3 startPosition, endPosition;
    private bool isMoving = false;

    private float preDistancePos, curDistancePos;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MovementCheck();
        }
        if (isMoving)
        {
            curDistancePos = (startPosition - transform.position).magnitude;
        }

        if (Input.GetMouseButtonDown(0) && GlobalVariable.Instance.canMove && GlobalVariable.Instance.canMoveArea)
        {
            preDistancePos = 0;
            curDistancePos = 0;
            isMoving = true;

            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition.z = 0;
            endPosition = (startPosition - transform.position).normalized;

            rb.velocity = new Vector2(endPosition.x * moveSpeed, endPosition.y * moveSpeed);
        }

        //Check if player is at its destination
        if(curDistancePos > preDistancePos)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if (isMoving)
        {
            preDistancePos = (startPosition - transform.position).magnitude;
        }
    }


    //Unused for now
    /// <summary>
    /// Check in which area the player is in
    /// </summary>
    void MovementCheck()
    {
        //GlobalVariable.Instance.room = GameObject.Find("")
    }  
}
