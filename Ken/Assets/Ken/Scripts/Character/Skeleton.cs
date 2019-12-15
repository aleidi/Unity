﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Character
{
    protected Vector3 m_vSpawnPos;

    public Skeleton() { SetAnimParaHash(); }

    public Skeleton(GameObject avatar) : base(avatar) { }

    public override void OnInit()
    {
        base.OnInit();

    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        CheckCharState();
    }

    public override void UnderAttack()
    {
        if(GetCharacterState() != ECharState.Hited)
        {
            SetAnimTrigger(GetAnimParamId().Hited);
            GetAnimator().Play("Hited",0,0);
        }
        AttackAnimPause();
        m_Avatar.Rigid.AddForce(m_vKnockBackDir * 200);
    }


    protected virtual void CheckCharState()
    {
        AnimatorStateInfo _sInfo = GetAnimator().GetCurrentAnimatorStateInfo(0);

        if (_sInfo.IsName("Idle"))
        {
            SetCharacterState(ECharState.Idle);
            return;
        }

        if(_sInfo.IsName("IdleInBattle"))
        {
            SetCharacterState(ECharState.IdleInBattle);
            return;
        }

        if (_sInfo.IsName("Locomotion"))
        {
            SetCharacterState(ECharState.Moving);
            return;
        }

        if (_sInfo.IsName("Hited"))
        {
            SetCharacterState(ECharState.Hited);
            return;
        }

        if (_sInfo.IsName("Attack"))
        {
            SetCharacterState(ECharState.Attacking);
            return;
        }

        if (_sInfo.IsName("Jump"))
        {
            SetCharacterState(ECharState.Jumping);
            return;
        }
    }

    public void SetSpawnPosition(Vector3 spawnPos)
    {
        m_vSpawnPos = spawnPos;
    }

    public Vector3 GetSpawnPosition()
    {
        return m_vSpawnPos;
    }

    public override void AttackAnimPause()
    {
        AnimPauseForSeconds(0.1f);
    }
}
