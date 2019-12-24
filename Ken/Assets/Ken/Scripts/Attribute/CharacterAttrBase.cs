public abstract class CharacterAttrBase
{
    public int MaxHp { get; protected set; }
    protected int m_iNowHp;

    //Attack Attribute
    public int MaxEndurance { get; protected set; }
    protected int m_iNowEndurance;
    public float AttackRange { get; protected set; }

    //Move Attributes
    public float MoveSpeed { get; protected set; }
    public float MoveSpeedAtten { get; protected set; }
    public float JumpForce { get; protected set; }
    public int JumpTimes { get; protected set; }

    public string AttrName { get; protected set; }

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

    public int GetNowHp()
    {
        return m_iNowHp;
    }

    public void SetMoveSpeedAtten(float value)
    {
        MoveSpeedAtten = value;
    }

}
