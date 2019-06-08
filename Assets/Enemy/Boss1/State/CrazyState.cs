using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyState : IState {
    public void OnEnd()
    {

    }

    public void OnStart()
    {
        
    }

    public void OnUpdate(BossAI boss)
    {
        boss.CrazyAttack();
    }   
}
