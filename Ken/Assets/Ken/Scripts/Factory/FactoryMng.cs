using System.Collections.Generic;
using UnityEngine;

public class FactoryMng
{
    static private FactoryMng _Instance;
    static public FactoryMng Instance
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

    public void OnInit()
    {
        m_CharacterFactory = new CharacterFactory();
        m_AssetFactory = new AssetFactory();

        m_MonsterList = new List<Character>();
    }

    public void OnUpdate(float deltaTime)
    {
        foreach(Character monster in m_MonsterList)
        {
            monster.OnUpdate(deltaTime);
        }
    }

    private List<Character> m_MonsterList;
    private CharacterFactory m_CharacterFactory;
    public CharacterFactory GetCharacterFactory()
    {
        return m_CharacterFactory;
    }

    public void AddMonsterToList(Character character)
    {
        m_MonsterList.Add(character);
    }

    public List<Character> GetMonsterList()
    {
        return m_MonsterList;
    }

    private AssetFactory m_AssetFactory;
    public AssetFactory GetAssetFactory()
    {
        return m_AssetFactory;
    }
}
