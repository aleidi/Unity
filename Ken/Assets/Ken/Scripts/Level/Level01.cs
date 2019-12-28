using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01 : LevelBase
{
    public Level01()
    {
        m_sName = "Level01";
    }

    public override void EnterLevel()
    {
        base.EnterLevel();

        EnemySpawn[] tmp = GameObject.FindObjectsOfType<EnemySpawn>();
        foreach(EnemySpawn es in tmp)
        {
            es.SpawnEnemy();
        }

        Character _player = FactoryMng.Instance.CreatePlayer(EPlayer.Player, EWeapon.Sword, new Vector3(0, 5, 0f));

        //Create Gamemode
        GameInstance.Instance.CreateGameMdoe(_player.GetController() as PlayerController, _player);

        m_TNextLevel.EventToNextLevel += ChangeNextLevel;
    }

    public override void LeaveLevel()
    {
        FactoryMng.Instance.ClearEnemyList();
    }

    public override void OnUpdate(float deltaTime)
    {

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeNextLevel();
        }

    }

    protected override void ChangeNextLevel()
    {
        GameInstance.Instance.OpenLevel("Level02");

        GameTools.Instance.TimerForSeconds(0.1f, () =>
         {
             LevelMng.Instance.ChangeLevel(new Level02());
         });
    }
}
