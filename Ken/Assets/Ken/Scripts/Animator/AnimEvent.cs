using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    public delegate void Attack();
    public event Attack EventAttack;
    private Animator m_Anim;
    private float m_AnimSpd;

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

    public void AnimPauseTemporarily(float value)
    {
        m_AnimSpd = m_Anim.speed;
        m_Anim.speed = 0;
        StartCoroutine(Timer(value));
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        m_Anim.speed = m_AnimSpd;
    }

}
