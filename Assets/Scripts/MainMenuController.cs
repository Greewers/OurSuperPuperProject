using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void NewGameButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HowToPlayButtonPressed() 
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void ExitButtonPressed()
    {
        Application.Quit();
    }

}
