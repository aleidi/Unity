using UnityEngine;

abstract public class CharacterBuildParamBase
{
    public Character Character { get; set; }
    public EWeapon EWeapon { get; set; }
    public Vector3 SpawnPos { get; set; }
    public AIController Controller { get; set; }

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

    //Set controller
    abstract public void SetController();

    //Add character to list
    abstract public void AddCharacterToList();
}
