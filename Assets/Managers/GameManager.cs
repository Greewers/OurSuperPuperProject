using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GenerateGrid = 0,
    SpawnHero = 1,
    SpawnBombs = 2,
    HeroesTurn = 3,
    BombsTurn = 4
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState GameState;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.instance.GenerateGrid();    
                break;
            case GameState.SpawnHero:
                break;
            case GameState.SpawnBombs:
                break;
            case GameState.HeroesTurn:
                break;
            case GameState.BombsTurn:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

}
