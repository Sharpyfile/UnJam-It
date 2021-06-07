using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour
{
    public Passenger passenger1Object;
    public Passenger passenger2Object;
    public Passenger passengerPrefab;
    public Vector2 passenger1;
    public Vector2 passenger2;
    public List<Destination> destinations;
    public float maxAnnoyance = 2.5f;
    void Start()
    {
        FillSpace();
    }

    // Update is called once per frame
    void Update()
    {
        FillSpace();
    }

    public void FillSpace()
    {
        if (passenger1Object == null)
        {
            passenger1Object = Instantiate(passengerPrefab, new Vector3(-5, -5), Quaternion.identity);
            passenger1Object.GetComponent<Passenger>().startingPosition = passenger1;
            Random.InitState(System.Environment.TickCount);
            var number = Random.Range(0, destinations.Count);
            passenger1Object.GetComponent<Passenger>().destination = destinations[number].destinationName;
            Color temp = destinations[number].destinationColor;
            passenger1Object.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, 1.0f);
            passenger1Object.transform.parent = GameObject.Find("Gameplay").transform;
            if (passenger1Object.GetComponent<Passenger>().destination == "")
            {
                passenger1Object.GetComponent<Passenger>().maxAnnoyance = maxAnnoyance;
                passenger1Object.GetComponent<Passenger>().levelOfAnnoyance = maxAnnoyance;
            }
            passenger1Object.canBeTouched = true;
        }

        if (passenger2Object == null)
        {            
            passenger2Object = Instantiate(passengerPrefab, new Vector3(-5, -5), Quaternion.identity);
            passenger2Object.GetComponent<Passenger>().startingPosition = passenger2;
            Random.InitState(System.Environment.TickCount + 1);
            var number = Random.Range(0, destinations.Count);
            passenger2Object.GetComponent<Passenger>().destination = destinations[number].destinationName;
            Color temp = destinations[number].destinationColor;
            passenger2Object.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, 1.0f);
            passenger2Object.transform.parent = GameObject.Find("Gameplay").transform;
            if (passenger2Object.GetComponent<Passenger>().destination == "")
            {
                passenger2Object.GetComponent<Passenger>().maxAnnoyance = maxAnnoyance;
                passenger2Object.GetComponent<Passenger>().levelOfAnnoyance = maxAnnoyance;
            }
            passenger2Object.canBeTouched = false;
        }
    }
    public void ResetPassengers()
    {
        passenger1Object = null;
        passenger1Object = passenger2Object;
        passenger2Object = null;
        passenger1Object.canBeTouched = true;
        passenger1Object.startingPosition = passenger1;
        passenger1Object.transform.position = passenger1;
    }
    
}
