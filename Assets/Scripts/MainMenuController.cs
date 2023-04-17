using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void NewGameButtonPresed()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitButtonPresed()
    {
        Application.Quit();
    }

}
