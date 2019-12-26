using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01 : LevelBase
{
    private float timer = 8;

    public Level01()
    {
        m_sName = "Level01";
    }

    public override void EnterLevel()
    {
        Debug.Log(m_sName + ": init");
    }

    public override void LeaveLevel() { }

    public override void OnUpdate(float deltaTime)
    {
        Debug.Log(m_sName + ": Update");


        timer -= deltaTime;
        if(timer < 0)
        {
            LevelMng.Instance.ChangeLevel(new Level02());
            GameInstance.Instance.OpenLevel("Level02");
        }
    }
}
