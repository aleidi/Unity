public class MonsterAttribute : CharacterAttrBase
{
    public MonsterAttribute() { }

    public MonsterAttribute(
        int maxHp, int maxEndurance, float range,
        float moveSpeed, float moveSpeedAtten, float jumpForce, int jumpTimes,
        string name) : base(maxHp, maxEndurance, range,
        moveSpeed, moveSpeedAtten, jumpForce, jumpTimes,
        name)
    { }
}
