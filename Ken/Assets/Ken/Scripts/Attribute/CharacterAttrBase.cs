using UnityEngine;

public abstract class CharacterAttrBase
{
    public delegate void OnDeath();
    public event OnDeath EventOnDeath;
    public delegate void OnHpChange(float value);
    public event OnHpChange EventHpChange;

    public int MaxHp { get; protected set; }
    protected int m_iNowHp;

    //Attack Attribute
    public int MaxEndurance { get; protected set; }
    protected int m_iNowEndurance;
    public float AttackRange { get; protected set; }
    public int Atk { get; protected set; }

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

    public virtual int CalEndurance(Character attacker)
    {
        m_iNowEndurance -= attacker.GetAttribute().Atk;
        if(m_iNowEndurance <= 0)
        {
            m_iNowEndurance = 0;
        }
        //Debug.Log("endurance:" + m_iNowEndurance);
        return m_iNowEndurance;
    }

    public virtual void CalDamage(Character attacker)
    {
        m_iNowHp -= attacker.GetAttribute().Atk;
        if(m_iNowHp <= 0)
        {
            m_iNowHp = 0;

            if(EventOnDeath != null)
            {
                EventOnDeath.Invoke();
            }
        }
        //Debug.Log("hp after damage:" + m_iNowHp);

        if(EventHpChange != null)
        {
            EventHpChange.Invoke((float)m_iNowHp / (float)MaxHp);
        }
    }

    public virtual void CalDamage(int damage)
    {
        m_iNowHp -= damage;
        if (m_iNowHp <= 0)
        {
            m_iNowHp = 0;

            if (EventOnDeath != null)
            {
                EventOnDeath.Invoke();
            }
        }
        //Debug.Log("hp after damage:" + m_iNowHp);

        if (EventHpChange != null)
        {
            EventHpChange.Invoke((float)m_iNowHp / (float)MaxHp);
        }
    }

    public void SetJumpTimes(int value)
    {
        JumpTimes = value;
    }

    public void SetHp(int value)
    {
        m_iNowHp = value;
        EventHpChange.Invoke(m_iNowHp);
    }

}
