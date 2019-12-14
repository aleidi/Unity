using UnityEngine;
using System.Collections.Generic;

public class WeaponSword : WeaponMelee
{

    public WeaponSword()
    {
        m_fRange = 1.2f;
    }

    public override void WeaponAttack()
    {
        switch(m_Owner.GetType().Name)
        {
            case "Character":
                List<Character> _mList;
                if(GetAttackee(out _mList))
                {
                    foreach(Character monster in _mList)
                    {
                        monster.SetKnockBackDir(m_Owner.GetModelForward() * m_Owner.GetVelocity().magnitude * 0.5f);
                        monster.UnderAttack();
                    }
                    
                    m_Owner.AttackAnimPause();
                }
                break;

            case "Skeleton":
                if(GetAttackee())
                {
                    GameInstance.Instance.GetPlayerPawn().UnderAttack();
                }
                break;

            default:
                Debug.LogError("WeaponAttack: Not existed owner type!");
                break;
        }
    }

}
