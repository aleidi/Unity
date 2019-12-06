using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Pawn
{

    protected struct Avatar
    {
        public Transform Trans;
        public Rigidbody Rigid;
        public Collider Col;
    }

    protected Avatar m_Avatar;

    protected float m_fHp;
    protected float m_fAtk;
    protected float m_fDef;

    //Move Abilities
    protected float m_fJumpForce = 250;
    protected float m_fMoveSpeed = 8;

    public Character() { }

    public Character(GameObject avatar)
    {
        m_Avatar.Trans = avatar.transform;
        m_Avatar.Rigid = avatar.transform.GetComponent<Rigidbody>();
        Debug.Log("Character rigidbody: " + m_Avatar.Rigid.name);
        m_Avatar.Col = avatar.transform.GetComponent<Collider>();
        Debug.Log("Character collider: " + m_Avatar.Col.name);
    }

    override public void Move(float value)
    {
        Vector3 _moveVal = Vector3.right * value * m_fMoveSpeed;
        m_Avatar.Rigid.velocity = new Vector3(_moveVal.x, m_Avatar.Rigid.velocity.y, m_Avatar.Rigid.velocity.z);
    }

    override public void Jump()
    {
        Debug.Log("jump!");
        ResetVelocity();
        m_Avatar.Rigid.AddForce(Vector3.up * m_fJumpForce);
    }

    public void Attack() {}

    public Vector3 GetAvatarFootPosition()
    {
        return m_Avatar.Col.bounds.min;
    }

    protected void ResetVelocity()
    {
        m_Avatar.Rigid.velocity = Vector3.zero;
    }

}
