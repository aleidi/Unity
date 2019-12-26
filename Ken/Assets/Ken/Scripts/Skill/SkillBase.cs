using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase
{
    protected string m_sName;
    protected int m_iCost;
    protected Player m_Owner;
    protected bool m_bIsUnlocked;
    protected bool m_bCanUse;
    protected float m_fInterval;

    public SkillBase()
    {
        m_sName = "";
        m_iCost = 0;
        m_Owner = GameInstance.Instance.GetPlayerPawn() as Player;
        m_bIsUnlocked = false;
        m_bCanUse = false;
    }

    public SkillBase(string name, int cost, Player owner)
    {
        m_sName = name;
        m_iCost = cost;
        m_Owner = owner;
        m_bIsUnlocked = false;
        m_bCanUse = false;
    }

    public virtual void UseSkill()
    {
        if(false == m_bIsUnlocked)
        {
            Debug.Log("skill is locked!");
            return; 
        }

        if(false == m_bCanUse)
        {
            Debug.Log("Skill is not activated!");
            return;
        }

        if(m_Owner.ExaustSkillEnergy(m_iCost))
        {
            m_Owner.GetAnimator().Play(m_sName);
        }

    }

    public string GetName()
    {
        return m_sName;
    }

    public virtual void SkillAttack() { }

    protected virtual bool GetAttackee(out List<Character> mList)
    {
        mList = new List<Character>();

        List<Character> _list = GameInstance.Instance.GetEnemyList();

        foreach (Character enemy in _list)
        {
            Vector3 _oPos = m_Owner.GetCharacterPosition();
            Vector3 _mPos = enemy.GetCharacterPosition();
            Vector3 _dir = m_Owner.GetModelForward();
            if (AttackRoll(_oPos, _mPos, _dir, 0.8f, m_Owner.GetAttribute().AttackRange))
            {
                mList.Add(enemy);
            }
        }

        if (mList.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    protected bool AttackRoll(Vector3 v1, Vector3 v2, float range)
    {
        return Mathf.Abs(Vector3.Distance(v1, v2)) < range;
    }

    //If distance from v1 to v2 is smaller than maxRange and direction from v1 to v2 is parallel to dir, return true
    protected bool AttackRoll(Vector3 v1, Vector3 v2, Vector3 dir, float maxRange)
    {
        return Vector3.Dot(v2 - v1, dir) > 0 && Vector3.Distance(v1, v2) < maxRange;
    }

    protected bool AttackRoll(Vector3 v1, Vector3 v2, Vector3 dir, float minRange, float maxRange)
    {
        if (Vector3.Distance(v1, v2) < minRange)
        {
            return true;
        }

        return AttackRoll(v1, v2, dir, maxRange);
    }
}
