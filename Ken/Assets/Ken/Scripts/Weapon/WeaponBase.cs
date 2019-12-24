using UnityEngine;
using System.Collections.Generic;

public abstract class WeaponBase
{
    protected Character m_Owner;

    public abstract void WeaponAttack();

   public void SetOwner(Character theOwner)
    {
        m_Owner = theOwner;
    }
}
