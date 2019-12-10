using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMng
{
    static private LevelMng m_Instance;
    static public LevelMng Instance
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

    }

    public void OnUpdate(float deltaTime)
    {
      //  Debug.Log("LevelMng is updating!" + "DeltaTime:" + deltaTime);
    }

    public void ChangeLevel(string levelName)
    {
        if(levelName == m_CurrentLevel.GetName())
        {
            Debug.Log("Level is already opened!");
            return;
        }

        m_CurrentLevel.LeaveLevel();

        m_CurrentLevel = m_Levels[levelName];

        m_CurrentLevel.EnterLevel();
    }

    private void LevelInit()
    {
        m_CurrentLevel = new LevelTest();
    }



}
