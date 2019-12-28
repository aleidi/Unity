using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIai : SkillBase
{
    public SkillIai()
    {
        m_sName = "Iai";
        m_Owner = GameInstance.Instance.GetPlayerPawn() as Player;
        m_iCost = 1;
        m_bCanUse = true;
        m_fInterval = 1;
    }

    public SkillIai(string name, int cost, Player owner):base(name,cost,owner)
    {
        m_bIsUnlocked = true;
        m_bCanUse = true;
        m_fInterval = 1;
    }

    public override void UseSkill()
    {
        if (false == m_bIsUnlocked)
        {
            Debug.Log("skill is locked!");
            return;
        }

        if (false == m_bCanUse)
        {
            Debug.Log("Skill is not activated!");
            return;
        }

        m_bCanUse = false;

        if (m_Owner.ExaustSkillEnergy(m_iCost) == false)
        {
            m_bCanUse = true;
            return;
        }

        m_Owner.GetAnimator().Play(m_sName);
        m_Owner.Dash(4);

        GameTools.Instance.TimerForSeconds(m_fInterval, () =>
         {
             m_bCanUse = true;
         });


    }

    public override void SkillAttack()
    {

        List<Character> _mList;
        if (GetAttackee(out _mList))
        {
            foreach (Character enemy in _mList)
            {
                if (Character.ECharState.Dead == enemy.GetCharacterState())
                {
                    return;
                }

                enemy.UnderAttack(m_Owner);
                (m_Owner as Player).AddComboCount(1);
                (m_Owner as Player).AddComboEnergy((m_Owner as Player).GetComboCount());
                for (int i = 1; i < 3; i++)
                {
                    GameTools.Instance.TimerForSeconds(0.1f*i, ()=>
                    {
                        enemy.UnderAttack(m_Owner);
                        enemy.CharacterShake();
                        CameraMng.Instance.DoCameraShake(enemy.GetCharacterPosition(), 9, 0.2f * i);
                        (m_Owner as Player).AddComboCount(1);
                        (m_Owner as Player).AddComboEnergy(5);
                    });
                }
            }
        }
    }

    protected override bool GetAttackee(out List<Character> mList)
    {
        mList = new List<Character>();

        List<Character> _list = GameInstance.Instance.GetEnemyList();

        foreach (Character enemy in _list)
        {
            Vector3 _oPos = m_Owner.GetCharacterPosition();
            Vector3 _mPos = enemy.GetCharacterPosition();
            Vector3 _dir = m_Owner.GetModelForward();
            if (AttackRoll(_oPos, _mPos,-_dir, 4)) 
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
}
