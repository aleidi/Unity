using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMng
{
    private static LevelMng m_Instance;
    public static LevelMng Instance
    {
        get
        {
            if(null == m_Instance)
            {
                m_Instance = new LevelMng();
            }
            return m_Instance;
        }
    }

    private LevelBase m_CurrentLevel;
    private Dictionary<string, LevelBase> m_Levels;

    public void OnInit()
    {
        m_CurrentLevel = new Level01();
        m_CurrentLevel.EnterLevel();
    }

    public void OnUpdate(float deltaTime)
    {
        m_CurrentLevel.OnUpdate(deltaTime);
    }

    public void ChangeLevel(LevelBase level)
    {
        if(level == m_CurrentLevel)
        {
            Debug.Log("Level is already opened!");
            return;
        }

        m_CurrentLevel.LeaveLevel();

        m_CurrentLevel = level;

        m_CurrentLevel.EnterLevel();
    }

}
