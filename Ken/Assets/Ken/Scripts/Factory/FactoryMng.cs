using System.Collections.Generic;
using UnityEngine;

public class FactoryMng
{
    private static FactoryMng _Instance;
    public static FactoryMng Instance
    {
        get
        {
            if(null == _Instance)
            {
                _Instance = new FactoryMng();
            }
            return _Instance;
        }
    }

    public FactoryMng()
    {
        m_CharacterFactory = new CharacterFactory();
        m_AssetFactory = new AssetFactory();
        m_EnemyList = new List<Character>();
    }

    public void OnInit()
    {
        //foreach (Character enemy in m_EnemyList)
        //{
        //    enemy.GetController().OnInit();
        //    enemy.OnInit();
        //}
    }

    public void OnUpdate(float deltaTime)
    {
        foreach(Character enemy in m_EnemyList)
        {
            enemy.GetController().OnUpdate(deltaTime);
            enemy.OnUpdate(deltaTime);
        }
    }

    private List<Character> m_EnemyList;
    private CharacterFactory m_CharacterFactory;
    public CharacterFactory GetCharacterFactory()
    {
        return m_CharacterFactory;
    }

    public void AddEnemyToList(Character character)
    {
        m_EnemyList.Add(character);
    }

    public List<Character> GetEnemyList()
    {
        return m_EnemyList;
    }

    private AssetFactory m_AssetFactory;
    public AssetFactory GetAssetFactory()
    {
        return m_AssetFactory;
    }

    public void ClearEnemyList()
    {
        m_EnemyList.Clear();
    }

    public Character CreateEnemy(EEnemy eEnemy, EWeapon eWeapon, Vector3 spawnPosition)
    {
        Character _char = m_CharacterFactory.CreateEnemy(eEnemy, eWeapon, spawnPosition);
        _char.GetController().OnInit();
        _char.OnInit();
        return _char;
    }

    public Character CreatePlayer(EPlayer eChar, EWeapon eWeapon,Vector3 spawnPosition)
    {
        return m_CharacterFactory.CreatePlayer(eChar, eWeapon, spawnPosition);
    }
}
