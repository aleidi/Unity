public class EnemyAttribute : CharacterAttrBase
{
    public EnemyAttribute() { }

    public float GuardRange { get; protected set; }

    public EnemyAttribute(
        int maxHp, int maxEndurance, 
        float moveSpeed, float moveSpeedAtten, float jumpForce, int jumpTimes,
        float attackRange, float guardRange,
        string name)
    {
        MaxHp = maxHp;
        m_iNowHp = MaxHp;
        MaxEndurance = maxEndurance;
        m_iNowEndurance = MaxEndurance;
        MoveSpeed = moveSpeed;
        MoveSpeedAtten = moveSpeedAtten;
        JumpForce = jumpForce;
        JumpTimes = jumpTimes;
        AttackRange = attackRange;
        GuardRange = guardRange;
        AttrName = name;
    }
}
