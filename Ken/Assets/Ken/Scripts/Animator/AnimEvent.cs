using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    public delegate void Attack();
    public event Attack EventAttack;
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
}
