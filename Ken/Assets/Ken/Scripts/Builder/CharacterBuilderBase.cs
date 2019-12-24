using UnityEngine;

public abstract class CharacterBuildParamBase
{
    public Character Character { get; set; }
    public EWeapon EWeapon { get; set; }
    public Vector3 SpawnPos { get; set; }
    public AIController Controller { get; set; }

}

public abstract class CharacterBuilderBase
{
    //Set the construct parameter
    public abstract void SetBuildParam(CharacterBuildParamBase theParam);

    //Load model
    public abstract void LoadAsset();

    //Add Weapon
    public abstract void AddWeapon();

    //Set character attributes
    public abstract void SetCharacterAttr();

    //Set controller
    public abstract void SetController();

    //Add character to list
    public abstract void AddCharacterToList();

}
