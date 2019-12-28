using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelBase
{
    protected string m_sName;
    protected TriggerNextLevel m_TNextLevel;

    public virtual void EnterLevel()
    {
        m_TNextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<TriggerNextLevel>();
    }

    public abstract void LeaveLevel();
    public virtual void OnUpdate(float deltaTime) { }


    public LevelBase() { }

    public string GetName()
    {
        return m_sName;
    }

    protected virtual void ChangeNextLevel() { }
}
