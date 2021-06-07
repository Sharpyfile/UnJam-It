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

    private void Start()
    {
        Random.InitState(System.Environment.TickCount);
        GenerateNewDestination();
    }
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
                GenerateNewDestination();
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
                passengerManager.ResetPassengers();
                Destroy(collision.transform.gameObject);
            }                
            else
            {
                Handheld.Vibrate();
                gameController.currentFails++;
                collision.transform.GetComponent<MovePassenger>().isTouched = false;
            }
                
        }
    }

    private void GenerateNewDestination()
    {
        int i = 0;
        do
        {
            var number = Random.Range(0, gameController.destinations.Count);
            Debug.Log(number);
            destination = gameController.destinations[number].destinationName;
            Color temp = gameController.destinations[number].destinationColor;
            maxTime = gameController.destinations[number].destinationMaxtime;
            timeRemaining = gameController.destinations[number].destinationMaxtime;
            GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, 1.0f);
            Random.InitState(System.Environment.TickCount + i);
            i++;
        }
        while(destination == "");

    }
}
