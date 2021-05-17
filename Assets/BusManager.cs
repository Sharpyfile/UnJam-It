using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameController gameController;
    public GameObject meter;
    public PassengerManager passengerManager;
    public string destination;
    public float timeRemaining = 20.0f;
    public float maxTime = 20.0f;
    public float threshehold = 0.01f;

    private void Awake()
    {
        meter.transform.localScale = (new Vector3(meter.transform.localScale.x, 1.75f, meter.transform.localScale.z));
    }
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float tempTime = timeRemaining / maxTime;
            if (tempTime < threshehold)
            {
                gameObject.SetActive(false);                
            }
            meter.transform.localScale = (new Vector3(meter.transform.localScale.x, tempTime, meter.transform.localScale.z));
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Passenger")
        {
            if (collision.transform.GetComponent<Passenger>().destination == destination)
            {
                gameController.currentPasses++;
                passengerManager.passengers.Remove(collision.transform.GetComponent<Passenger>());
                Destroy(collision.transform.gameObject);
                //passengerManager.FillSpace();
            }
                
            else
            {
                gameController.currentFails++;
                collision.transform.GetComponent<MovePassenger>().isTouched = false;
                //collision.transform.position = collision.transform.GetComponent<Passenger>().startingPosition;
            }
                
        }
    }
}
