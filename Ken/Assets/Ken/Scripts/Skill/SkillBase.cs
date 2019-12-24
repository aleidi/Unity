using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase
{
    protected string m_sName;
    protected int m_iCost;
    protected Player m_Owner;
    protected bool m_bCanUse;

    public SkillBase()
    {
        m_sName = "";
        m_iCost = 0;
        m_Owner = GameInstance.Instance.GetPlayerPawn() as Player;
        m_bCanUse = false;
    }

    public SkillBase(string name, int cost, Player owner)
    {
        m_sName = name;
        m_iCost = cost;
        m_Owner = owner;
        m_bCanUse = false;
    }

    public virtual void UseSkill()
    {
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
}
