public class PlayerAttribute : CharacterAttrBase
{
    public PlayerAttribute() { }

    public PlayerAttribute(
        int maxHp, int maxEndurance, float attackRange,
        float moveSpeed, float moveSpeedAtten, float jumpForce, int jumpTimes,
        string name)
    {
        MaxHp = maxHp;
        m_iNowHp = MaxHp;
        MaxEndurance = maxEndurance;
        m_iNowEndurance = MaxEndurance;
        AttackRange = attackRange;
        MoveSpeed = moveSpeed;
        MoveSpeedAtten = moveSpeedAtten;
        JumpForce = jumpForce;
        JumpTimes = jumpTimes;
        AttrName = name;
    }
}
