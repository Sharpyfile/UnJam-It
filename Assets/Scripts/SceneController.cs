using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene("SecondLevel");
    }

    public void LoadThirdLevel()
    {
        SceneManager.LoadScene("ThirdLevel");
    }

    public void LoadFourthLevel()
    {
        SceneManager.LoadScene("FourthLevel");
    }

    public void LoadFifthLevel()
    {
        SceneManager.LoadScene("FifthLevel");
    }

    public void LoadEndlessMode()
    {
        SceneManager.LoadScene("EndlessMode");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
