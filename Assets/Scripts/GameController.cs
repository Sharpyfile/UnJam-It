using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Destination> destinations = new List<Destination>();

    public List<Destination> destinationsForGeneration = new List<Destination>();
    public int maxFails = 3;
    public int currentFails = 0;
    public int requiredPasses = 10;
    public int currentPasses = 0;
    public Text fails;
    public string failsString = "Current fails: \n";
    public Text passes;
    public string passesString = "Current passes: \n";
    public GameObject gameplayObjects;
    public GameObject winMessage;
    public GameObject failMessage;
    public GameObject pauseMessage;
    public GameObject tutorialMessage;

    private void Start()
    {
        CopyDestination();
    }

    private void Update()
    {
        fails.text = failsString + '\n' + currentFails + '/' + maxFails;
        passes.text = passesString + '\n' + currentPasses + '/' + requiredPasses;
        if (maxFails <= currentFails)
        {
            failMessage.SetActive(true);
            gameplayObjects.SetActive(false);
        }

        if (requiredPasses <= currentPasses && requiredPasses > 0)
        {
            winMessage.SetActive(true);
            gameplayObjects.SetActive(false);
        }
        if (destinationsForGeneration.Count <= 1)
           CopyDestination();
    }

    public void ActivatePause()
    {
        gameplayObjects.SetActive(false);
        pauseMessage.SetActive(true);
    }

    public void DisablePause()
    {
        gameplayObjects.SetActive(true);
        pauseMessage.SetActive(false);
    }

    public void DisableTutorial()
    {
        gameplayObjects.SetActive(true);
        tutorialMessage.SetActive(false);
    }
    

    public void CopyDestination()
    {
        destinationsForGeneration = new List<Destination>(destinations);
    }
}
