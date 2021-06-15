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
    public bool isShaked = false;
    private Vector3 ealierPosition = Vector3.zero;

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
        {
            isTouched = false;
            isShaked = false;
        }
            
        
        Move();

    }

    private void Move()
    {
        if (isTouched)
        {
            ealierPosition = transform.position;
            touchPosition = Input.GetTouch(0).position;
            Vector3 nextPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, -Camera.main.transform.position.z));
            if (Vector3.Distance(transform.position, nextPosition) > Vector3.Distance(transform.position, ealierPosition))
                isShaked = true;
            else
                isShaked = false;
            transform.position = nextPosition;
            
        }
        else
        {
            transform.position = GetComponent<Passenger>().startingPosition;
        }
            
    }
}
