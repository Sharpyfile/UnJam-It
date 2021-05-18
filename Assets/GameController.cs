using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int maxFails = 3;
    public int currentFails = 0;
    public int requiredPasses = 10;
    public int currentPasses = 0;
    public Text fails;
    public string failsString = "Current fails: ";
    public Text passes;
    public string passesString = "Current passes: ";
    public GameObject gameplayObjects;
    public GameObject winMessage;
    public GameObject failMessage;
    public GameObject pauseMessage;

    private void Update()
    {
        fails.text = failsString + currentFails + '/' + maxFails;
        passes.text = passesString + currentPasses + '/' + requiredPasses;
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
}
