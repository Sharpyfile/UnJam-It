using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePassenger : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 touchPosition;
    private BoxCollider2D passengerCollider;
    [HideInInspector]
    public bool isTouched = false;
    void Start()
    {
        passengerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if (passengerCollider == Physics2D.OverlapPoint(touchPosition) && GetComponent<Passenger>().canBeTouched)
            {
                isTouched = true;
            }
        }
        else
        {
            isTouched = false;
        }
        Move();

    }

    private void Move()
    {
        if (isTouched)
        {
            transform.position = touchPosition;
        }
        else
        {
            transform.position = GetComponent<Passenger>().startingPosition;
        }
            
    }
}
