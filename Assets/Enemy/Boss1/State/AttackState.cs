using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    float t = 5;

    public void OnEnd()
    {
       
    }

    public void OnStart()
    {
        
    }

    public void OnUpdate(BossAI boss)
    {
        t -= Time.deltaTime;
        if (t <= 0)
        {
            boss.Attack(false);
            boss.AI.SetState(new MoveState());
        }
        else
            boss.Attack(true);
        if (boss.IsDangerous())
        {
            boss.Attack(false);
            boss.AI.SetState(new CrazyState());
        }
    }
}
