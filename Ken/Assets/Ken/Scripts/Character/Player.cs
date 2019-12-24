﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private ComboSystem m_ComboSys;

    public override void OnInit()
    {
        base.OnInit();
        m_ComboSys = new ComboSystem();
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        m_ComboSys.OnUpdate(deltaTime);

    }

    public void AddComboEnergy(int value)
    {
        m_ComboSys.AddComboEnergy(value);
    }

    public void AddComboCount(int value)
    {
        m_ComboSys.AddComboCount(value);
    }

    public int GetComboCount()
    {
        return m_ComboSys.GetComboCount();
    }

    public int GetComboEnergy()
    {
        return m_ComboSys.GetComboEnergy();
    }

    public bool ExaustSkillEnergy(int value)
    {
        return m_ComboSys.ExaustSkillEnergy(value);
    }

    public void UseSkill()
    {
        SkillMng.Instance.UseSkill("Iai");
    }
}
