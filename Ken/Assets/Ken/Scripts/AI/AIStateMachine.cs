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

    public AIStateBase Transition(int t)
    {
        AIStateBase s;
        m_States.TryGetValue(t, out s);
        return s;
    }

    public void SetDefualtState(int t)
    {
        if(m_States.TryGetValue(t, out m_CurrentState))
        {
            m_CurrentState.Enter();
        }
    }

    public void OnUpdate(float deltaTime)
    {
        if(null == m_CurrentState)
        {
            return;
        }
        AIStateBase _nextState = m_CurrentState.Execute();
        if(_nextState != m_CurrentState)
        {
            m_CurrentState.Exit();
            m_CurrentState = _nextState;
            if(m_CurrentState != null)
            {
                m_CurrentState.Enter();
            }
        }
    }
}
