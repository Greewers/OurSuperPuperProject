using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIController : MonoBehaviour
{
    public void RestartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenuButtonPresed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
