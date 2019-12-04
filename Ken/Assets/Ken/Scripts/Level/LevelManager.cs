using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    static private LevelManager m_Instance;
    static public LevelManager Instance
    {
        get
        {
            if(null == m_Instance)
            {
                m_Instance = new LevelManager();
            }
            return m_Instance;
        }
    }

    private LevelBase m_CurrentLevel;
    private Dictionary<string, LevelBase> m_Levels;

    public void OnInit()
    {
        Debug.Log("LevelManager is initiating!");
    }

    public void Update(float deltaTime)
    {
      //  Debug.Log("LevelManager is updating!" + "DeltaTime:" + deltaTime);
    }

    public void OpenLevel(string levelName)
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



}
