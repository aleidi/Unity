using UnityEngine;

public class MonsterBuildParam : CharacterBuildParamBase
{
    public MonsterBuildParam() { }
}

public class MonsterBuilder : CharacterBuilderBase
{
    private MonsterBuildParam m_BuildParam;

    public override void SetBuildParam(CharacterBuildParamBase theParam)
    {
        m_BuildParam = theParam as MonsterBuildParam;
    }

    public override void LoadAsset()
    {
        GameObject _model = FactoryMng.Instance.GetAssetFactory().LoadModel("Skeleton");
        
        //Set the spawn position
        _model.transform.position = m_BuildParam.m_vSpawnPos;
        
        m_BuildParam.m_Character.SetAvatar(GameTools.CreateGameObject(_model, _model.transform.position, Quaternion.identity));
    }

    public override void AddWeapon()
    {
        m_BuildParam.m_Character.SetWeapon(new WeaponSword());
    }

    public override void SetCharacterAttr()
    {
        CharacterAttrBase _attribtue = new MonsterAttribute(100, 100, 10,
            8f, 0.2f, 250,
            "Monster");
        m_BuildParam.m_Character.SetAttribute(_attribtue);

    }

    public override void AddCharacterToList()
    {
        FactoryMng.Instance.AddMonsterToList(m_BuildParam.m_Character);
    }

}
