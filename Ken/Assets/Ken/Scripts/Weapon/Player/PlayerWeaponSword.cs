using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponSword : PlayerWeaponMelee
{

    public PlayerWeaponSword()
    {
        m_fRange = 1.2f;
    }

    public override void WeaponAttack()
    {
        List<Character> _mList;
        if (GetAttackee(out _mList))
        {
            foreach (Character enemy in _mList)
            {
                enemy.SetKnockBackDir((enemy.GetCharacterPosition() - m_Owner.GetCharacterPosition()) * m_Owner.GetVelocity().magnitude * 0.35f
                    + m_Owner.GetModelForward() * 0.2f);
                enemy.UnderAttack();
            }

            m_Owner.AttackAnimPause();
        }
    }

}
