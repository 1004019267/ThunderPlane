using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterState : IState
{
    public void OnEnd()
    {
        
    }

    public void OnStart()
    {
        
    }

    public void OnUpdate(BossAI boss)
    {
        boss.MoveToward();
        if (boss.transform.position.y <= 3.11)
        {
            //把状态交出去
            boss.AI.SetState(new AttackState());
        }
    }
   
}
