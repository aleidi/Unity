abstract public class CharacterAttrBase
{
    protected int m_iMaxHp;
    protected int m_iNowHp;

    //Attack Attribute
    protected int m_iMaxEndurance;
    protected int m_iNowEndurance;
    protected float m_fRange;

    //Move Attributes
    protected float m_fMoveSpeed;
    protected float m_fMoveSpeedAtten;
    protected float m_fJumpForce;
    protected int m_iJumpTimes;


    protected string m_AttrName;

    public CharacterAttrBase() { }

    public CharacterAttrBase(
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

    public int GetMaxHp()
    {
        return m_iMaxHp;
    }

    public int GetNowHp()
    {
        return m_iNowHp;
    }

    public float GetMoveSpeed()
    {
        return m_fMoveSpeed;
    }

    public float GetMoveSpeedAtten()
    {
        return m_fMoveSpeedAtten;
    }

    public void SetMoveSpeedAtten(float value)
    {
        m_fMoveSpeedAtten = value;
    }

    public float GetJumoForce()
    {
        return m_fJumpForce;
    }

    public int GetJumpTimes()
    {
        return m_iJumpTimes;
    }

    public float GetRange()
    {
        return m_fRange;
    }

}
