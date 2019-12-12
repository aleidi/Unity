public class MonsterAttribute : CharacterAttrBase
{
    public MonsterAttribute() { }

    public MonsterAttribute(
        int maxHp, int maxEndurance, float range,
        float moveSpeed, float moveSpeedAtten, float jumpForce, int jumpTimes,
        string name)
    {
        m_iMaxHp = maxHp;
        m_iNowHp = m_iMaxHp;
        m_iMaxEndurance = maxEndurance;
        m_iNowEndurance = m_iMaxEndurance;
        m_fRange = range;
        m_fMoveSpeed = moveSpeed;
        m_fMoveSpeedAtten = moveSpeedAtten;
        m_fJumpForce = jumpForce;
        m_iJumpTimes = jumpTimes;
        m_AttrName = name;
    }
}
