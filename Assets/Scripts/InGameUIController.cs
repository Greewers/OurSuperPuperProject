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
    public GameObject InGameMenuCanvas;

    private GlobalOptions _globalOptions;
    private Player _player;
    private int _finalScore;


    public void RestartButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenuButtonPresed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void InGameMenuButtonPresed()
    {
        _player.ChangeActive(false);
        InGameMenuCanvas.SetActive(true);
    }

    public void ÑontinueButtonPresed()
    {
        _player.ChangeActive(true);
        InGameMenuCanvas.SetActive(false);
    }
    public void GameEnd()
    {
        _finalScore = _globalOptions.Score;
        InGameCanvas.SetActive(false);
        EndGameCanvas.SetActive(true);
        gameScore.text = "Âàø ñ÷åò: " + _finalScore--;
    }
    public void Init(GlobalOptions globalOptions, Player player)
    {
        _globalOptions = globalOptions;
        _player = player;
    }
}
