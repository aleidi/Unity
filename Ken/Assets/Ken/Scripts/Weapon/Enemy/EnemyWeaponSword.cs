using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSword : EnemyWeaponMelee
{
    public override void WeaponAttack()
    {
        if (GetAttackee())
        {
            Character _player = GameInstance.Instance.GetPlayerPawn();
            _player.SetKnockBackDir((_player.GetCharacterPosition() - m_Owner.GetCharacterPosition()) * 4.5f);
            _player.UnderAttack();
            m_Owner.AttackAnimPause();
        }
    }
}
