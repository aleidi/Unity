using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level03 : LevelBase
{
    private GameObject m_BossBattery;
    private GameObject m_BossReBattery;
    private BossKey m_BossKey;
    private GameObject m_BossGate;
    private EnemySpawn[] m_EnemySpawnPoints;
    private List<Character> m_Enemys = new List<Character>();
    private int m_fDeadEnemy;
    private int EnemyCount { set; get; }
    private bool m_bBossTrigger = false;
    private float m_fInterval = 10;
    private float m_Timer =10;


    public Level03()
    {
        m_sName = "Level03";
    }

    public override void EnterLevel()
    {
        //boss set
        m_BossBattery = GameObject.Find("BossBattery");
        m_BossReBattery = GameObject.Find("BossReBattery");
        m_BossKey = GameObject.Find("BossKey").GetComponent<BossKey>();
        m_BossGate = GameObject.Find("BossGate");

        m_EnemySpawnPoints = GameObject.FindObjectsOfType<EnemySpawn>();


        m_BossBattery.SetActive(false);
        m_BossReBattery.SetActive(false);
        m_BossGate.SetActive(false);
        m_BossKey.EventTrigger += ActiveBoss;

        //get next level object
        base.EnterLevel();
        m_TNextLevel.gameObject.SetActive(false);
        m_TNextLevel.EventToNextLevel += ChangeNextLevel;

        m_fDeadEnemy = 0;
        EnemyCount = 0;

        GameInstance.Instance.GetPlayerPawn().SetCharacterPosition(new Vector3(12, 5, 0));

        CameraMng.Instance.ActivateHorizontalTrace(true);
        CameraMng.Instance.ActivateVerticalTrace(true);




    }
    public override void LeaveLevel() { }

    public override void OnUpdate(float deltaTime)
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameInstance.Instance.GetPlayerController().SetJumpTimes(2);
        }

        if(m_bBossTrigger == false)
        {
            return;
        }

        m_Timer -= deltaTime;
        if (m_Timer < 0.1)
        {
            m_Timer = m_fInterval;
            SetBattery();
        }

        if (m_fDeadEnemy == EnemyCount)
        {
            m_TNextLevel.gameObject.SetActive(true);
            m_fDeadEnemy = 0;
        }
    }

    private void SetBattery()
    {
        if(m_BossBattery.activeInHierarchy == true)
        {
            m_BossBattery.SetActive(false);
            m_BossReBattery.SetActive(true);
        }
        else
        {
            m_BossBattery.SetActive(true);
            m_BossReBattery.SetActive(false);
        }
    }

    private void ActiveBoss()
    {
        m_BossGate.SetActive(true);
        m_bBossTrigger = true;

        for(int i =0; i < m_EnemySpawnPoints.Length;i++)
        {
            m_Enemys.Add(m_EnemySpawnPoints[i].SpawnEnemy());
            m_Enemys[i].EventOnDeath += OnEnemyDeath;
        }

        EnemyCount = m_Enemys.Count;

        //foreach (EnemySpawn es in m_EnemySpawnPoints)
        //{
        //    es.SpawnEnemy();
        //}
    }

    private void OnEnemyDeath()
    {
        m_fDeadEnemy += 1;
    }

    protected override void ChangeNextLevel()
    {
        GameInstance.Instance.OpenLevel("MenuScene");

    }
}
