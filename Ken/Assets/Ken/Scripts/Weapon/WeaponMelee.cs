using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : WeaponBase
{           

    public override void WeaponAttack()
    {
    }



    protected virtual bool GetAttackee(out List<Character> mList)
    {
        mList = new List<Character>();

        List<Character> _list = GameInstance.Instance.GetMonsterList();

        foreach (Character monster in _list)
        {
            Vector3 _oPos = m_Owner.GetPlayerPawnPosition();
            Vector3 _mPos = monster.GetPlayerPawnPosition();
            Vector3 _dir = m_Owner.GetPlayerForward();
            if (AttackRoll(_oPos,_mPos,_dir,m_fRange))
            {
                mList.Add(monster);
            }
        }

        if(mList.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual bool GetAttackee()
    {
        Vector3 _pPos = GameInstance.Instance.GetPlayerPawn().GetPlayerPawnPosition();
        Vector3 _oPos = m_Owner.GetPlayerPawnPosition();

        if (Mathf.Abs(Vector3.Distance(_pPos, _oPos)) < m_fRange)
        {
            return true;
        }

        return false;
    }

    protected bool AttackRoll(Vector3 v1, Vector3 v2, float range)
    {
        return Mathf.Abs(Vector3.Distance(v1, v2)) < range;
    }

    //If distance from v1 to v2 is smaller than maxRange and direction from v1 to v2 is parallel to dir, return true
    protected bool AttackRoll(Vector3 v1, Vector3 v2, Vector3 dir, float maxRange)
    {
        return Vector3.Dot(v2 - v1, dir) > 0 && Vector3.Distance(v1, v2) < maxRange;
    }

    protected bool AttackRoll(Vector3 v1, Vector3 v2, Vector3 dir, float minRange, float maxRange)
    {
        if (Vector3.Distance(v1, v2) < minRange)
        {
            return true;
        }

        return AttackRoll(v1, v2, dir, maxRange);
    }

}
