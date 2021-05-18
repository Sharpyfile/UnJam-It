using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour
{
    public List<Passenger> passengers = new List<Passenger>();
    public Passenger passengerPrefab;
    public Vector2 passenger1;
    public Vector2 passenger2;
    public Vector2 passenger3;
    public List<string> destinations;
    void Start()
    {
        FillSpace();
    }

    // Update is called once per frame
    void Update()
    {
        if (passengers.Count == 0)
            FillSpace();
    }

    public void FillSpace()
    {
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    passengers.Add(Instantiate(passengerPrefab, new Vector3(-5, -5), Quaternion.identity));
                    passengers[i].GetComponent<Passenger>().startingPosition = passenger1;
                    Random.InitState(System.Environment.TickCount + i);
                    var number1 = Random.Range(0, destinations.Count);
                    passengers[i].GetComponent<Passenger>().destination = destinations[number1];
                    passengers[i].placeInArray = i;
                    passengers[i].transform.parent = GameObject.Find("Gameplay").transform;
                    break;

                case 1:
                    passengers.Add(Instantiate(passengerPrefab, new Vector3(-5, -5), Quaternion.identity));
                    passengers[i].GetComponent<Passenger>().startingPosition = passenger2;
                    Random.InitState(System.Environment.TickCount + i);
                    var number2 = Random.Range(0, destinations.Count);
                    passengers[i].GetComponent<Passenger>().destination = destinations[number2];
                    passengers[i].placeInArray = i;
                    passengers[i].transform.parent = GameObject.Find("Gameplay").transform;
                    break;

                case 2:
                    passengers.Add(Instantiate(passengerPrefab, new Vector3(-5, -5), Quaternion.identity));
                    passengers[i].GetComponent<Passenger>().startingPosition = passenger3;
                    var number3 = Random.Range(0, destinations.Count);
                    passengers[i].GetComponent<Passenger>().destination = destinations[number3];
                    passengers[i].placeInArray = i;
                    passengers[i].transform.parent = GameObject.Find("Gameplay").transform;
                    break;
            }

            switch (passengers[i].GetComponent<Passenger>().destination)
            {
                case "Ba³uty":
                    passengers[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
                    break;
                case "Politechniki":
                    passengers[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.blue;
                    break;
                case "Pabianice":
                    passengers[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;
                case "":
                    passengers[i].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
                    passengers[i].GetComponent<Passenger>().maxAnnoyance = 2.5f;
                    passengers[i].GetComponent<Passenger>().levelOfAnnoyance = 2.5f;
                    break;
            }

        
        }
    }
}
