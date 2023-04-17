using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI gameScore;

    public GameObject InGameCanvas;
    public GameObject EndGameCanvas;

    private GlobalOptions _globalOptions;
    private int _finalScore;

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenuButtonPresed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GameEnd()
    {
        _finalScore = _globalOptions.Score;
        InGameCanvas.SetActive(false);
        EndGameCanvas.SetActive(true);
        gameScore.text = "¬аш счет: " + _finalScore--;
    }
    public void Init(GlobalOptions globalOptions)
    {
        _globalOptions = globalOptions;
    }
}
