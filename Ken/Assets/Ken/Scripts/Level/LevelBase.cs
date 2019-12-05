using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LevelBase : MonoBehaviour
{
    protected string m_sName;


    abstract public void EnterLevel();
    abstract public void LeaveLevel();
    virtual public void OnUpdate(float deltaTime) { }


    public LevelBase()
    {
    }

    public string GetName()
    {
        return m_sName;
    }
}
