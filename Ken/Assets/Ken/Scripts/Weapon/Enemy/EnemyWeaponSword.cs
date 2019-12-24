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

            //Counter Process
            if(_player.IsCounter())
            {
                //_player.SetAnimPlaySpeed(0);
                m_Owner.AnimPauseForSeconds(0.3f);
                return;
            }

            //Perfect Guard Process
            if(_player.IsPerfectGuard())
            {
                _player.PlayPerfectGuardAnim();
                m_Owner.SetAnimPlaySpeed(-1);
                GameTools.Instance.TimerForSeconds(0.3f, () =>
                 {
                     m_Owner.GetAnimator().Play("IdleInBattle");
                     m_Owner.SetAnimPlaySpeed(1);
                 });

                return;
            }

            //Guard Process
            if (_player.IsInDefense())
            {
                _player.SetKnockBackDir((_player.GetCharacterPosition() - m_Owner.GetCharacterPosition()) * 1.5f);
                _player.Defense();
                m_Owner.AnimPauseForSeconds(0.1f);

                return;
            }

            //Hited Process
            _player.SetKnockBackDir((_player.GetCharacterPosition() - m_Owner.GetCharacterPosition()) * 4.5f);
            _player.UnderAttack();
            m_Owner.AnimPauseForSeconds(0.1f);
            Debug.Log("Hited!");
        }
    }
}
