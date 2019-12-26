using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem
{
    public delegate void OnSkillEnergyChange(float value);
    public event OnSkillEnergyChange EventSkillEnergyChange;
    public delegate void OnComboEnergyChange(float value);
    public event OnComboEnergyChange EventComboEnergyChange;

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
        ResetComboTimer();
    }

    public void AddComboEnergy(int value)
    {
        ResetComboTimer();

        m_iComboEnergy += value;

        if(m_iComboEnergy >= MaxComboEnergy)
        {
            AddSkillEnergy(m_iComboEnergy / MaxComboEnergy);

            m_iComboEnergy = m_iComboEnergy % MaxComboEnergy;
        }

        EventComboEnergyChange.Invoke(m_iComboEnergy);

        //Debug.Log("add combo energy :" + m_iComboEnergy);
    }

    public void AddSkillEnergy(int value)
    {
        m_iSkillEnergy += value;

        if(m_iSkillEnergy > MaxSkillEnergy)
        {
            m_iSkillEnergy = MaxSkillEnergy;
        }

        EventSkillEnergyChange.Invoke(m_iSkillEnergy);

        //Debug.Log("add skill energy :" + m_iSkillEnergy);
    }

    public bool ExaustSkillEnergy(int value)
    {
        m_iSkillEnergy -= value;
        if(m_iSkillEnergy < 0)
        {
            m_iSkillEnergy += value;
            Debug.Log("Skill Energy is not enough!");
            return false;
        }

        EventSkillEnergyChange.Invoke(m_iSkillEnergy);

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

    private void ResetComboTimer()
    {
        m_fCountInterval = CountInterval;
    }


}
