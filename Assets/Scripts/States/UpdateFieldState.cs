using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateFieldState : BaseState
{
    public override void Enter()
    {
        base.Enter();
        //обновляется счетчик бомб и объектов, проверка на нанесение урона
    }

    public override void Exit()
    {
        //обновление счетчика ходов
        base.Exit();
        
    }
}
