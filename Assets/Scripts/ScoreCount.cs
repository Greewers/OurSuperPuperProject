using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI gameScore;

    private GlobalOptions _globalOptions;

    private int _currentScore;

    public void Start()
    {
        _globalOptions.OnScoreChanged += OnScoreChange;
    }

    private void OnScoreChange(int value)
    {
        _currentScore++;

        gameScore.text = gameScore.text + _currentScore++;
        Debug.Log(gameScore.text);

    }
}
