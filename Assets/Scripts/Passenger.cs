using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    //[HideInInspector]
    public Vector2 startingPosition = Vector2.zero;
    private PassengerManager passengerManager;
    private GameController gameController;
    public float levelOfAnnoyance = 10;
    public float maxAnnoyance = 10;
    public float threshehold = 0.01f;
    public float annoyanceMultiplier = 0.1f;
    public float repealMultiplier = 3f;
    public string destination;
    [HideInInspector]
    public int placeInArray;
    public GameObject meter;
    public bool canBeTouched = false;

    private void Start()
    {
        passengerManager = FindObjectOfType<PassengerManager>();
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {

        if (levelOfAnnoyance > 0)
        {
            if (destination == "")
            {
                if (GetComponent<MovePassenger>().isTouched && GetComponent<MovePassenger>().isShaked)
                    levelOfAnnoyance -= Time.deltaTime * repealMultiplier;
                else if (canBeTouched)
                    levelOfAnnoyance -= Time.deltaTime;
            }
            else
            {
                if (GetComponent<MovePassenger>().isTouched && GetComponent<MovePassenger>().isShaked)
                    levelOfAnnoyance -= Time.deltaTime * annoyanceMultiplier;
                else if (canBeTouched)
                    levelOfAnnoyance -= Time.deltaTime;
            }
            
                
            float tempTime = levelOfAnnoyance / maxAnnoyance;
            if (tempTime < threshehold)
            {
                if (destination != "")
                {
                    Handheld.Vibrate();
                    gameController.currentFails++;
                    passengerManager.ResetPassengers();
                    Destroy(gameObject);
                }
                else
                {
                    gameController.currentPasses++;
                    passengerManager.ResetPassengers();
                    Destroy(gameObject);
                }                
            }
            meter.transform.localScale = (new Vector3(meter.transform.localScale.x, tempTime, meter.transform.localScale.z));
        }
    }
}
