public class CharacterBuilderSystem
{
    public void Construct(CharacterBuilderBase theBuilder)
    {
        theBuilder.LoadAsset();
        theBuilder.AddWeapon();
        theBuilder.SetCharacterAttr();
        theBuilder.SetController();
        theBuilder.AddCharacterToList();
    }
}
