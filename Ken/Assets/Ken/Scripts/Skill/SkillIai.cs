using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillIai : SkillBase
{
    public SkillIai()
    {
        m_sName = "Iai";
        m_bCanUse = true;
        m_Owner = GameInstance.Instance.GetPlayerPawn() as Player;
        m_iCost = 0;
    }

    public SkillIai(string name, int cost, Player owner):base(name,cost,owner)
    {
        m_bCanUse = true;
    }
}
