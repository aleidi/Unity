
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
        _model.transform.position = m_BuildParam.SpawnPos;  
        m_BuildParam.Character.SetAvatar(GameTools.CreateGameObject(_model, _model.transform.position, Quaternion.identity));
    }

    public override void AddWeapon()
    {
        m_BuildParam.Character.SetWeapon(new PlayerWeaponSword());
        m_BuildParam.Character.GetWeapon().SetOwner(m_BuildParam.Character);

        AddSkills();
;    }

    public override void SetCharacterAttr()
    {
        CharacterAttrBase _attribtue = new PlayerAttribute(50, 100, 1.5f, 20,
          8f, 0.2f, 5, 2,
          "Player");
        m_BuildParam.Character.SetAttribute(_attribtue);
    }

    public override void SetController()
    {
        m_BuildParam.Character.SetController(new PlayerController(m_BuildParam.Character));
    }

    public override void AddCharacterToList()
    {
        
    }

    protected virtual void AddSkills()
    {
        SkillMng.Instance.AddSkill(new SkillIai("Iai",1, m_BuildParam.Character as Player));
    }
}
