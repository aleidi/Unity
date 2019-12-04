using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Actor : MonoBehaviour
{
    protected float m_fHp;
    protected float m_fAtk;
    protected float m_fDef;

    abstract public void Move();
    abstract public void Jump();

}
