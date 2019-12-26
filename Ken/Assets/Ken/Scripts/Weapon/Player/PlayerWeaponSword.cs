using UnityEngine;
using System.Collections.Generic;

public class PlayerWeaponSword : PlayerWeaponMelee
{

    public PlayerWeaponSword()
    {

    }

    public override void WeaponAttack()
    {
        List<Character> _mList;
        if (GetAttackee(out _mList))
        {
            foreach (Character enemy in _mList)
            {
                if(Character.ECharState.Dead == enemy.GetCharacterState())
                {
                    return;
                }

                enemy.SetKnockBackDir((enemy.GetCharacterPosition() - m_Owner.GetCharacterPosition()) * m_Owner.GetVelocity().magnitude * 0.35f
                    + m_Owner.GetModelForward() * 0.2f);
                enemy.UnderAttack(m_Owner);
                (m_Owner as Player).AddComboCount(1);
                (m_Owner as Player).AddComboEnergy((m_Owner as Player).GetComboCount() * 5);
                enemy.CharacterShake();
            }

            m_Owner.AnimPauseForSeconds(0.06f);
        }
    }

}
