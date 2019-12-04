using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class LevelBase : MonoBehaviour
{
    protected string m_sName;

    abstract public void EnterLevel();
    abstract public void LeaveLevel();
    abstract public void Update();


    public LevelBase()
    {
        m_sName = "";
    }

    public string GetName()
    {
        return m_sName;
    }
}
