using System;
using UnityEngine;

public class GlobalOptions
{
    public event Action<int> OnScoreChanged;
    
    public int Score { get; private set; } = 0;

    public void ScoreIncriment()
    {
        Score++;
        Debug.Log(Score);
        OnScoreChanged?.Invoke(Score);
    }

    public void ScoreIncriment(int score)
    {
        Score += score;
        OnScoreChanged?.Invoke(Score);
    }

}

