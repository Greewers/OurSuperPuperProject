using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    //void Start()
    //{
    //    currentState = GetInitialState(); возможно это нам надо, Костя, посмотри, пожалуйста
    //    if (currentState != null)
    //        currentState.Enter();
    //}

    public void Initialize(BaseState startingState)
    {
        currentState = startingState;
        startingState.Enter();
    }


    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    //protected virtual BaseState GetInitialState()  возможно это ТОЖЕ нам надо, Костя, посмотри, пожалуйста
    //{
    //    return null;
    //}
}
