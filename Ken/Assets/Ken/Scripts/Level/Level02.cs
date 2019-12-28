using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02 : LevelBase
{
    private List<Character> m_Enemys = new List<Character>();
    private int m_fDeadEnemy;
    private int EnemyCount { set; get; }

    public Level02()
    {
        m_sName = "Level02";
    }

    public override void EnterLevel()
    {
        base.EnterLevel();
        m_TNextLevel.gameObject.SetActive(false);
        m_TNextLevel.EventToNextLevel += ChangeNextLevel;

        CameraMng.Instance.ActivateHorizontalTrace(true);
        CameraMng.Instance.ActivateVerticalTrace(true);

        m_fDeadEnemy = 0;
        EnemyCount = 0;

        GameInstance.Instance.GetPlayerPawn().SetCharacterPosition(new Vector3(12, 5, 0));

        EnemySpawn[] _tmp = GameObject.FindObjectsOfType<EnemySpawn>();

        for(int i =0; i<_tmp.Length;i++)
        {
            m_Enemys.Add(_tmp[i].SpawnEnemy());
            m_Enemys[i].EventOnDeath += OnEnemyDeath;
        }

        EnemyCount = m_Enemys.Count;

    }
    public override void LeaveLevel()
    {
        FactoryMng.Instance.ClearEnemyList();
    }

    public override void OnUpdate(float deltaTime)
    {
        if(m_fDeadEnemy == EnemyCount)
        {
            m_TNextLevel.gameObject.SetActive(true);
            m_fDeadEnemy = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeNextLevel();
            Debug.Log("button3");
        }
    }

    private void OnEnemyDeath()
    {
        m_fDeadEnemy += 1;
    }

    protected override void ChangeNextLevel()
    {
        GameInstance.Instance.OpenLevel("Level03");

        GameTools.Instance.TimerForSeconds(0.1f, () =>
        {
            LevelMng.Instance.ChangeLevel(new Level03());
        });
    }

}
