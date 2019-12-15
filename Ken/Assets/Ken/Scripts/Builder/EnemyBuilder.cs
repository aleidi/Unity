using UnityEngine;

public class EnemyBuildParam : CharacterBuildParamBase
{
    public EnemyBuildParam() { }
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
        CharacterAttrBase _attribtue = new EnemyAttribute(100, 100, 
            8f, 0.2f, 250, 1,
            1.6f, 5,
            "Skeleton");
        m_BuildParam.Character.SetAttribute(_attribtue);
        (m_BuildParam.Character as Skeleton).SetSpawnPosition(m_BuildParam.SpawnPos);
    }

    public override void SetController()
    {
        m_BuildParam.Character.SetController(new AIController(m_BuildParam.Character));
        (m_BuildParam.Character.GetController() as AIController).SetAIMachine(new AIStateMachine(m_BuildParam.Character));
        (m_BuildParam.Character.GetController() as AIController).GetAIMachine().AddState(new AISkeleton.Idle());
        (m_BuildParam.Character.GetController() as AIController).GetAIMachine().AddState(new AISkeleton.Chase());
        (m_BuildParam.Character.GetController() as AIController).GetAIMachine().AddState(new AISkeleton.Attack());
        (m_BuildParam.Character.GetController() as AIController).GetAIMachine().SetDefualtState((int)AIStateBase.EStateType.Idle);
    }

    public override void AddCharacterToList()
    {
        FactoryMng.Instance.AddEnemyToList(m_BuildParam.Character);
    }

}
