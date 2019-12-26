using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : ControllerBase
{
    protected AIStateMachine m_AIMachine;

    public AIController() { }

    public AIController(Character pawn)
    {
        m_ContolleredPawn = pawn;
    }

    public override void OnInit()
    {
        base.OnInit();

    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        m_AIMachine.OnUpdate(deltaTime);

    }

    public virtual void MoveTo(Vector3 tPos)
    {
        Vector3 _dir = tPos - m_ContolleredPawn.GetCharacterPosition();
        bool _isRight = Vector3.Dot(_dir, Vector3.right) > 0 ? true : false;
        if(true == _isRight)
        {
            m_ContolleredPawn.Move(1);
            m_ContolleredPawn.SetForward(Vector3.forward);
            return;
        }
        if(false ==_isRight)
        {
            m_ContolleredPawn.Move(-1);
            m_ContolleredPawn.SetForward(Vector3.forward * -1);
            return;
        }
    }

    public virtual void DoAttack()
    {
        if(m_ContolleredPawn.GetCharacterState() == Character.ECharState.Idle)
        {
            m_ContolleredPawn.SetBattleMode();
        }
        m_ContolleredPawn.PlayAttackAnim();
    }

    public void SetAIMachine(AIStateMachine machine)
    {
        m_AIMachine = machine;
    }

    public AIStateMachine GetAIMachine()
    {
        return m_AIMachine;
    }
}
