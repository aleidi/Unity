using UnityEngine;
using System.Collections.Generic;

public abstract class WeaponBase
{
    protected Character m_Owner;
    protected float m_fRange;

    public abstract void WeaponAttack();

   public void SetOwner(Character theOwner)
    {
        m_Owner = theOwner;
    }
}
