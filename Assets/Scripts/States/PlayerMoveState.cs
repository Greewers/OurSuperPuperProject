using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : BaseState
{
    private Player _player { get; }

    public PlayerMoveState(string name, StateMachine stateMachine, Player player) : base(name, stateMachine)
    {
        _player = player;
        _player.OnPlayerEndTurn += OnPlayerEndTurn;
    }

    private void OnPlayerEndTurn() 
        => _stateMachine.ChangeState(typeof(UpdateFieldState));

    public override void Enter()
    {
        _player.AllowMoving();
    }

    public override void Exit()
    {
        //Запретили персонажу двигаться
    }
}
