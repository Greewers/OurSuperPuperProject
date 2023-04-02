using System;
using UnityEngine;

public class GlobalOptions
{
    public event Action<int> OnScoreChaned;
    public int Score { get; private set; } = 0;

    public void ScoreIncriment()
    {
        Score++;
        Debug.Log(Score);
        OnScoreChaned?.Invoke(Score);
    }

    public void ScoreIncriment(int score)
    {
        Score += score;
        OnScoreChaned?.Invoke(Score);
    }
}

