﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSword : EnemyWeaponMelee
{
    public override void WeaponAttack()
    {
        if (GetAttackee())
        {
            Character _player = GameInstance.Instance.GetPlayerPawn();

            if(Character.ECharState.Dead == _player.GetCharacterState())
            {
                return;
            }

            //Counter Process
            if(_player.IsCounter())
            {
                //_player.SetAnimPlaySpeed(0);
                m_Owner.AnimPauseForSeconds(0.3f);

                (_player as Player).AddSkillEnergy(1);
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

                (_player as Player).AddComboEnergy(35);

                return;
            }

            //Guard Process
            if (_player.IsInDefense())
            {
                _player.SetKnockBackDir((_player.GetCharacterPosition() - m_Owner.GetCharacterPosition()) * 1.5f);
                _player.Defense();
                m_Owner.AnimPauseForSeconds(0.1f);

                (_player as Player).AddComboEnergy(5);

                return;
            }

            //Hited Process
            _player.SetKnockBackDir((_player.GetCharacterPosition() - m_Owner.GetCharacterPosition()) * 4.5f);
            _player.UnderAttack(m_Owner);
            m_Owner.AnimPauseForSeconds(0.1f);
            CameraMng.Instance.SetPlayerHitedShakeParam();
            CameraMng.Instance.DoCameraShake(_player.GetCharacterPosition(), 9, 0.6f);
        }
    }
}
