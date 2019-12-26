using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelBase
{
    protected string m_sName;


    public abstract void EnterLevel();
    public abstract void LeaveLevel();
    public virtual void OnUpdate(float deltaTime) { }


    public LevelBase() { }

    public string GetName()
    {
        return m_sName;
    }
}
