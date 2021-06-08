using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePassenger : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 touchPosition;
    private Touch touch;
    [HideInInspector]
    public bool isTouched = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.tag == "Passenger" && GetComponent<Passenger>().canBeTouched)
                    isTouched = true;
            }
        }
        else
            isTouched = false;
        
        Move();

    }

    private void Move()
    {
        if (isTouched)
        {
            touchPosition = Input.GetTouch(0).position;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, -Camera.main.transform.position.z));
        }
        else
        {
            transform.position = GetComponent<Passenger>().startingPosition;
        }
            
    }
}
