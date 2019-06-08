using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState{
    void OnStart();//状态进入
    void OnEnd();//状态退出

    void OnUpdate(BossAI boss);//循环
}
