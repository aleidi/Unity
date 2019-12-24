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
                _playerParam.Character = new Player();
                break;
            default:
                Debug.LogError("CreatePlayer can't create player!");
                break;
        }

        //Set player parameter
        _playerParam.EWeapon = eWeapon;
        _playerParam.SpawnPos = spawnPosition;

        //Create the player builder and set the parameter
        PlayerBuilder _playerBuilder = new PlayerBuilder();
        _playerBuilder.SetBuildParam(_playerParam);

        //Produce
        m_BuilderDirector.Construct(_playerBuilder);


        return _playerParam.Character; 
    }

    public override Character CreateMonster(EMonster eMonster, EWeapon eWeapon, Vector3 spawnPosition)
    {
        //Set monster parameter
        EnemyBuildParam _monsterParam = new EnemyBuildParam();

        switch(eMonster)
        {
            case EMonster.Skeleton:
                _monsterParam.Character = new Skeleton();
                break;
            default:
                Debug.LogError("CreateMonster can't create monster");
                break;
        }

        //Set monster parameter
        _monsterParam.EWeapon = eWeapon;
        _monsterParam.SpawnPos = spawnPosition;

        //Create the monster builder and set the parameter
        EnemyBuilder _monsterBuilder = new EnemyBuilder();
        _monsterBuilder.SetBuildParam(_monsterParam);

        //Produce
        m_BuilderDirector.Construct(_monsterBuilder);

        return _monsterParam.Character;
    }
}
