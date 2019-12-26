using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02 : LevelBase
{
    public Level02()
    {
        m_sName = "Level02";
    }

    public override void EnterLevel()
    {
        Debug.Log(m_sName + ": init");
    }
    public override void LeaveLevel() { }

    public override void OnUpdate(float deltaTime)
    {
        Debug.Log(m_sName + ": Update");
    }
}
