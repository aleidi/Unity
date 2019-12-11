
using UnityEngine;

public class PlayerBuildParam: CharacterBuildParamBase
{
    public PlayerBuildParam() { }
}

public class PlayerBuilder : CharacterBuilderBase
{
    private PlayerBuildParam m_BuildParam;

    public override void SetBuildParam(CharacterBuildParamBase theParam)
    {
        m_BuildParam = theParam as PlayerBuildParam;
    }

    public override void LoadAsset()
    {
        GameObject _model = FactoryMng.Instance.GetAssetFactory().LoadModel("PlayerPawn");

        //Set the spawn position
        _model.transform.position = m_BuildParam.m_vSpawnPos;  
        m_BuildParam.m_Character.SetAvatar(GameTools.CreateGameObject(_model, _model.transform.position, Quaternion.identity));
    }

    public override void AddWeapon()
    {
        m_BuildParam.m_Character.SetWeapon(new WeaponSword());
        m_BuildParam.m_Character.GetWeapon().SetOwner(m_BuildParam.m_Character);
;    }

    public override void SetCharacterAttr()
    {
        CharacterAttrBase _attribtue = new PlayerAttribute(100, 100, 10,
          8f,0.2f, 250, 2,
          "Player");
        m_BuildParam.m_Character.SetAttribute(_attribtue);
    }

    public override void AddCharacterToList()
    {
        
    }
}
