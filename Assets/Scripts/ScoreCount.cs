using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI gameScore;
    private int _currentScore;

    private void OnScoreChange(int value)
    {
        Debug.Log(gameScore.text);
        _currentScore = value;
        gameScore.text = "Текущий счет: " + _currentScore;
    }
    
    public void Init(GlobalOptions globalOptions)
    {
        globalOptions.OnScoreChanged += OnScoreChange;
    }
}
