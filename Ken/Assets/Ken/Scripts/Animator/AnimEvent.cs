using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    public delegate void Attack();
    public event Attack EventAttack;
    public delegate void Counter();
    public event Counter EventCounter;
    public delegate void PerfectGuard();
    public event PerfectGuard EventPerfectGuard;
    public delegate void Skill(string name);
    public event Skill EventSkill;
    private Animator m_Anim;

    void Awake()
    {
        m_Anim = transform.GetComponent<Animator>();
    } 

    public void SetAnimtorSpeed(float value)
    {
        m_Anim.speed = value;
    }

    public void OnAttack()
    {
        EventAttack.Invoke();
    }

    void OnCounter()
    {
        EventCounter.Invoke();
    }

    void SetPerfectGuard()
    {
        EventPerfectGuard.Invoke();
    }

    void OnSkill(string name)
    {
        EventSkill.Invoke(name);
    }
}
