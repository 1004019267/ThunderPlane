using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    public void OnEnd()
    {
       
    }

    public void OnStart()
    {
        
    }

    public void OnUpdate(BossAI boss)
    {
        boss.MoveSide();
        if (boss.transform.position.x<=-3||boss.transform.position.x>=3)
        {
            boss.ChangeDirection();
            boss.AI.SetState(new AttackState());
        }
        if (boss.IsDangerous())
        {
            boss.AI.SetState(new CrazyState());
        }
    }
}
