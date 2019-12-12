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

    protected AttributeStrategyBase m_AttrStrategy;

    public CharacterAttrBase() { }

    public void SetAttrStrategy(AttributeStrategyBase theAttrStrategy)
    {
        m_AttrStrategy = theAttrStrategy;
    }

    public virtual void InitAttr()
    {
        m_AttrStrategy.InitAttr(this);
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
