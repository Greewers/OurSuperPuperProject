using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayUIController : MonoBehaviour
{
    public void NewGameButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CancelButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
