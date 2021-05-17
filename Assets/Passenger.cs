using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    //[HideInInspector]
    public Vector2 startingPosition;
    private PassengerManager passengerManager;
    private GameController gameController;
    public float levelOfAnnoyance = 10;
    public float maxAnnoyance = 10;
    public float threshehold = 0.01f;
    public string destination;
    [HideInInspector]
    public int placeInArray;
    public GameObject meter;

    private void Start()
    {
        passengerManager = FindObjectOfType<PassengerManager>();
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (GetComponent<MovePassenger>().isTouched && destination == "")
        {
            gameController.currentFails++;
            passengerManager.passengers.Remove(this);
            Destroy(gameObject);
        }

        if (levelOfAnnoyance > 0)
        {
            levelOfAnnoyance -= Time.deltaTime;
            float tempTime = levelOfAnnoyance / maxAnnoyance;
            if (tempTime < threshehold)
            {
                if (destination != "")
                {
                    gameController.currentFails++;
                    passengerManager.passengers.Remove(this);
                    Destroy(gameObject);
                }
                else
                {
                    gameController.currentPasses++;
                    passengerManager.passengers.Remove(this);
                    Destroy(gameObject);
                }                
            }
            meter.transform.localScale = (new Vector3(meter.transform.localScale.x, tempTime, meter.transform.localScale.z));
        }
    }
}
