using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI {
    IState curState;
    BossAI boss;
	// Use this for initialization
    public void Init(BossAI boss)
    {
        this.boss = boss;
       SetState(new EnterState());
    }	
	// Update is called once per frame
	public void Update () {
        if (curState!=null)        
        curState.OnUpdate(boss);
	}
    public void SetState(IState newState)
    {
        newState.OnStart();
        if (curState != null)
            curState.OnEnd();
        curState = newState;      
    }  
}
