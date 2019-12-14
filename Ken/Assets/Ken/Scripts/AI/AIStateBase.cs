using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIStateBase
{
    public enum EStateType
    {
        Idle,
        Chase,
        Attack,
        Death
    }

    protected AIStateMachine m_Machine;
    public Character Agent { get; set; }
    public int StateType { get; protected set; }

    public void SetStateMachine(AIStateMachine machine)
    {
        m_Machine = machine;
    }

    public abstract void Enter();
    public abstract AIStateBase Execute();
    public abstract void Exit();

}
