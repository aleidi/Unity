using UnityEngine;

public class EnemyBuildParam : CharacterBuildParamBase
{
    public EnemyBuildParam() { }

    public EEnemy EnemyType { get; set; }
}

public class EnemyBuilder : CharacterBuilderBase
{
    private EnemyBuildParam m_BuildParam;

    public override void SetBuildParam(CharacterBuildParamBase theParam)
    {
        m_BuildParam = theParam as EnemyBuildParam;
    }

    public override void LoadAsset()
    {
        GameObject _model = FactoryMng.Instance.GetAssetFactory().LoadModel("Skeleton");
        
        //Set the spawn position
        _model.transform.position = m_BuildParam.SpawnPos;
        
        m_BuildParam.Character.SetAvatar(GameTools.CreateGameObject(_model, _model.transform.position, Quaternion.identity));
    }

    public override void AddWeapon()
    {
        m_BuildParam.Character.SetWeapon(new EnemyWeaponSword());
        m_BuildParam.Character.GetWeapon().SetOwner(m_BuildParam.Character);
    }

    public override void SetCharacterAttr()
    {
        EnemyAttribute _attribtue = new EnemyAttribute();
        switch(m_BuildParam.EnemyType)
        {
            case EEnemy.Skeleton:
                _attribtue.SetAttribute(100, 10, 10,
                    500, 0.2f, 250, 1,
                    1.6f, 5,
                    "Skeleton");
                m_BuildParam.Character.SetAttribute(_attribtue);
                break;
            case EEnemy.SkeletonHighHp:
                _attribtue.SetAttribute(1000, 10, 10,
                    500, 0.2f, 250, 1,
                    1.6f, 5,
                    "SkeletonHighHp");
                m_BuildParam.Character.SetAttribute(_attribtue);
                break;
            case EEnemy.Sangbag:
                _attribtue.SetAttribute(100, 0, 10,
                    500, 0.2f, 250, 1,
                    0, 0,
                    "Sandbag");
                m_BuildParam.Character.SetAttribute(_attribtue);
                break;
            case EEnemy.Boss:
                _attribtue.SetAttribute(2500, 2500, 30,
                    500, 0.2f, 250, 1,
                    1.6f, 8,
                    "Boss");
                m_BuildParam.Character.SetAttribute(_attribtue);
                break;
            default:
                Debug.Log("Enemy attribute can not constructed!");
                break;

        }

        (m_BuildParam.Character as Skeleton).SetSpawnPosition(m_BuildParam.SpawnPos);
    }

    public override void SetController()
    {
        switch (m_BuildParam.EnemyType)
        {
            case EEnemy.Skeleton:
            case EEnemy.SkeletonHighHp:
            case EEnemy.Boss:
                m_BuildParam.Character.SetController(new AIController(m_BuildParam.Character));
                (m_BuildParam.Character.GetController() as AIController).SetAIMachine(new AIStateMachine(m_BuildParam.Character));
                (m_BuildParam.Character.GetController() as AIController).GetAIMachine().AddState(new AISkeleton.Idle());
                (m_BuildParam.Character.GetController() as AIController).GetAIMachine().AddState(new AISkeleton.Chase());
                (m_BuildParam.Character.GetController() as AIController).GetAIMachine().AddState(new AISkeleton.Attack());
                (m_BuildParam.Character.GetController() as AIController).GetAIMachine().AddState(new AISkeleton.Death());

                (m_BuildParam.Character.GetController() as AIController).GetAIMachine().SetDefualtState((int)AIStateBase.EStateType.Idle);
                break;
            case EEnemy.Sangbag:
                m_BuildParam.Character.SetController(new AIController(m_BuildParam.Character));
                (m_BuildParam.Character.GetController() as AIController).SetAIMachine(new AIStateMachine(m_BuildParam.Character));
                (m_BuildParam.Character.GetController() as AIController).GetAIMachine().AddState(new AISkeleton.Idle());
                (m_BuildParam.Character.GetController() as AIController).GetAIMachine().SetDefualtState((int)AIStateBase.EStateType.Idle);
                break;
            default:
                break;
        }
    }

    public override void AddCharacterToList()
    {
        FactoryMng.Instance.AddEnemyToList(m_BuildParam.Character);

        //Set spawn position
        //(m_BuildParam.Character as Skeleton).SetSpawnPosition(m_BuildParam.SpawnPos);
    }

}
