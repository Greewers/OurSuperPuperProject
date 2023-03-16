using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected string _name;
    protected StateMachine _stateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        _name = name;
        _stateMachine = stateMachine;
    }

    public abstract void Enter();

    public abstract void Exit();
}