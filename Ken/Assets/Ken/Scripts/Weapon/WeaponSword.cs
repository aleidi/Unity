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
                        monster.UnderAttack();
                    }
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
