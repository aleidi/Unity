public class PlayerAttribute : CharacterAttrBase
{
    public PlayerAttribute() { }

    public PlayerAttribute(
        int maxHp, int maxEndurance, float range,
        float moveSpeed, float moveSpeedAtten, float jumpForce, int jumpTimes,
        string name) : base(maxHp, maxEndurance, range,
        moveSpeed, moveSpeedAtten, jumpForce, jumpTimes,
        name)
    { }
}
