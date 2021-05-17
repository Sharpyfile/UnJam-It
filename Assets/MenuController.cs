using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject credits;
    public GameObject buttons;

    public void CloseCredits()
    {
        buttons.SetActive(true);
        credits.SetActive(false);
    }

    public void OpenCredits()
    {
        buttons.SetActive(false);
        credits.SetActive(true);
    }
}
