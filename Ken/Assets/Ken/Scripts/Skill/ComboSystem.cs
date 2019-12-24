using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem
{
    private int m_iSkillEnergy;
    private int m_iComboEnergy;
    private int m_iNowCount;
    private float m_fCountInterval;

    private int MaxSkillEnergy = 10;
    private int MaxComboEnergy = 100;
    private float CountInterval = 5;

    public ComboSystem()
    {
        m_iSkillEnergy = 0;
        m_iComboEnergy = 0;
        m_iNowCount = 0;
        m_fCountInterval = CountInterval;
    }
    
    public void OnUpdate(float deltaTime)
    {
        if(m_fCountInterval > 0)
        {
            m_fCountInterval -= deltaTime;
            return;
        }
        else
        {
            m_iNowCount = 0;
            m_iComboEnergy = 0;
        }

    }

    public void AddComboCount(int value)
    {
        m_iNowCount += value;
        m_fCountInterval = CountInterval;
    }

    public void AddComboEnergy(int value)
    {
        m_iComboEnergy += value;

        if(m_iComboEnergy >= MaxComboEnergy)
        {
            m_iSkillEnergy += (m_iComboEnergy / MaxComboEnergy);
            m_iComboEnergy = m_iComboEnergy % MaxComboEnergy;
        }
    }

    public bool ExaustSkillEnergy(int value)
    {
        m_iSkillEnergy -= value;
        if(m_iSkillEnergy < 0)
        {
            Debug.Log("Skill Energy is not enough!");
            return false;
        }

        return true;
    }

    public int GetComboCount()
    {
        return m_iNowCount;
    }

    public int GetComboEnergy()
    {
        return m_iComboEnergy;
    }


}
