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

    public override Character CreateEnemy(EEnemy eEnemy, EWeapon eWeapon, Vector3 spawnPosition)
    {
        //Set monster parameter
        EnemyBuildParam _enemyParam = new EnemyBuildParam();

        switch(eEnemy)
        {
            case EEnemy.Skeleton:
                _enemyParam.Character = new Skeleton();
                _enemyParam.EnemyType = EEnemy.Skeleton;
                break;
            case EEnemy.SkeletonHighHp:
                _enemyParam.Character = new Skeleton();
                _enemyParam.EnemyType = EEnemy.SkeletonHighHp;
                break;
            case EEnemy.Sangbag:
                _enemyParam.Character = new Sandbag();
                _enemyParam.EnemyType = EEnemy.Sangbag;
                break;
            case EEnemy.Boss:
                _enemyParam.Character = new Skeleton();
                _enemyParam.EnemyType = EEnemy.Boss;
                break;
            default:
                Debug.LogError("CreateEnemy can't create monster");
                break;
        }

        //Set monster parameter
        _enemyParam.EWeapon = eWeapon;
        _enemyParam.SpawnPos = spawnPosition;

        //Create the monster builder and set the parameter
        EnemyBuilder _monsterBuilder = new EnemyBuilder();
        _monsterBuilder.SetBuildParam(_enemyParam);

        //Produce
        m_BuilderDirector.Construct(_monsterBuilder);

        return _enemyParam.Character;
    }
}
