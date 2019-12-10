using UnityEngine;

public class CharacterFactory : CharacterFactoryBase
{
    private CharacterBuilderSystem m_BuilderDirector;

    public CharacterFactory()
    {
        m_BuilderDirector = new CharacterBuilderSystem();
    }

    public override Character CreatePlayer(EPlayer eChar,EWeapon eWeapon,Vector3 spawnPosition)
    {
        //Set player parameter
        PlayerBuildParam _playerParam = new PlayerBuildParam();

        switch(eChar)
        {
            case EPlayer.Player:
                _playerParam.m_Character = new Character();
                break;
            default:
                Debug.LogError("CreatePlayer can't create player!");
                break;
        }

        //Set player parameter
        _playerParam.m_eWeapon = eWeapon;
        _playerParam.m_vSpawnPos = spawnPosition;

        //Create the player builder and set the parameter
        PlayerBuilder _playerBuilder = new PlayerBuilder();
        _playerBuilder.SetBuildParam(_playerParam);

        //Produce
        m_BuilderDirector.Construct(_playerBuilder);


        return _playerParam.m_Character; 
    }

    public override Character CreateMonster(EMonster eMonster, EWeapon eWeapon, Vector3 spawnPosition)
    {
        //Set monster parameter
        MonsterBuildParam _monsterParam = new MonsterBuildParam();

        switch(eMonster)
        {
            case EMonster.Skeleton:
                _monsterParam.m_Character = new Skeleton();
                break;
            default:
                Debug.LogError("CreateMonster can't create monster");
                break;
        }

        //Set monster parameter
        _monsterParam.m_eWeapon = eWeapon;
        _monsterParam.m_vSpawnPos = spawnPosition;

        //Create the monster builder and set the parameter
        MonsterBuilder _monsterBuilder = new MonsterBuilder();
        _monsterBuilder.SetBuildParam(_monsterParam);

        //Produce
        m_BuilderDirector.Construct(_monsterBuilder);

        return _monsterParam.m_Character;
    }
}
