using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("To play animation of departure to the right, check box, for left uncheck")]
    public bool departRight = true;
    public bool justActivated = false;
    private bool departed = false;
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
        departed = false;
        justActivated = true;
        meter.transform.localScale = (new Vector3(meter.transform.localScale.x, 1.75f, meter.transform.localScale.z));
    }
    // Update is called once per frame
    void Update()
    {
        justActivated = false;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            float tempTime = timeRemaining / maxTime;
            if (tempTime < threshehold)
            {
                departed = true;
                GetComponent<Collider>().enabled = false;
                if (departRight)
                    GetComponent<Animator>().Play("BusDepartureRight");
                else
                    GetComponent<Animator>().Play("BusDepartureLeft");
                
            }
            meter.transform.localScale = (new Vector3(meter.transform.localScale.x, tempTime, meter.transform.localScale.z));
        }            
    }

    private void OnCollisionEnter(Collision collision)
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
        for(;;)
        {
            if (gameController.destinationsForGeneration.Count <= 1)
                gameController.CopyDestination();
            var number = Random.Range(0, gameController.destinationsForGeneration.Count);
            destination = gameController.destinationsForGeneration[number].destinationName;
            if (destination == "")
                continue;
            Color temp = gameController.destinationsForGeneration[number].destinationColor;
            maxTime = gameController.destinationsForGeneration[number].destinationMaxtime;
            timeRemaining = gameController.destinationsForGeneration[number].destinationMaxtime;
            GetComponent<Renderer>().material.color = new Color(temp.r, temp.g, temp.b, 1.0f);
            gameController.destinationsForGeneration.RemoveAt(number);
            Random.InitState(System.Environment.TickCount + i);
            i++;
            break;
        }
    }

    public void DisableBus()
    {
        if (!justActivated)
            gameObject.SetActive(false); 

        GetComponent<Collider>().enabled = true;
            
    }

    public void ActivateGeneration()
    {
        if (departed)
        {
            departed = false;
            GenerateNewDestination();
        }
            
    }
}
