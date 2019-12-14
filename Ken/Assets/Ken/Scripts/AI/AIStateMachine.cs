using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine 
{
    private Character m_Agent;
    private Dictionary<int, AIStateBase> m_States = new Dictionary<int, AIStateBase>();
    private AIStateBase m_CurrentState;

    public AIStateMachine(Character agent)
    {
        m_Agent = agent;
    }

    public void AddState(AIStateBase state)
    {
        state.Agent = m_Agent;
        state.SetStateMachine(this);
        m_States[state.StateType] = state;
    }
}
