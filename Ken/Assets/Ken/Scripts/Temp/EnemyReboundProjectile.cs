using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReboundProjectile : MonoBehaviour
{
    [SerializeField]
    private float m_fSpeed = 1;

    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * m_fSpeed, Space.World);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment")
        {
            Destroy(gameObject);
            return;
        }

        if(other.tag == "Monster")
        {
            other.GetComponent<CharacterEvent>().GetCharacter().GetAttribute().CalDamage(50);
            Destroy(gameObject);
            return;
        }

        Character _player = GameInstance.Instance.GetPlayerPawn();

        if (_player.GetCharacterState() == Character.ECharState.Attacking)
        {

            transform.forward = Vector3.up;
            return;
        }

        //Guard Process
        if (_player.IsInDefense())
        {
            (_player as Player).AddComboEnergy(5);
            if (_player.GetController().IsOnAir())
            {
                _player.SetKnockBackDir(Vector3.up * 0.5f);
            }
            else
            {
                _player.SetKnockBackDir(transform.forward * 2);
            }

            transform.forward = Vector3.down;

            GameTools.Instance.TimerForSeconds(1, () =>
            {
                Destroy(gameObject);
            });
            return;
        }

        if(true == _player.IsInvincible())
        {
            Destroy(gameObject);
            return;
        }

        //Hited Process
        _player.GetAttribute().CalDamage(5);
        _player.UnderAttack();
        if (_player.GetController().IsOnAir())
        {
            _player.SetKnockBackDir(Vector3.up);
        }
        else
        {
            _player.SetKnockBackDir(transform.forward);
        }
        CameraMng.Instance.SetPlayerHitedShakeParam();
        CameraMng.Instance.DoCameraShake(_player.GetCharacterPosition(), 9, 0.6f);
        Destroy(gameObject);

    }
}
