using UnityEngine;

abstract public class CharacterBuildParamBase
{
    public Character m_Character;
    public EWeapon m_eWeapon;
    public Vector3 m_vSpawnPos;

}

abstract public class CharacterBuilderBase
{
    //Set the construct parameter
    abstract public void SetBuildParam(CharacterBuildParamBase theParam);

    //Load model
    abstract public void LoadAsset();

    //Add Weapon
    abstract public void AddWeapon();

    //Set character attributes
    abstract public void SetCharacterAttr();

    //Add character to list
    abstract public void AddCharacterToList();
}
