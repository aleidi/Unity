using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Pawn
{
    public enum CharState
    {
        Idle,
        IdleArmedWeapon,
        Attacking,
        Moving,
        Jumping
    }

    protected struct Avatar
    {
        public Transform Trans;
        public Rigidbody Rigid;
        public Collider Col;
        public Animator Anim;
    }

    protected struct AnimParaId
    {
        public int IsWeaponArmed;
        public int Attack;
        public int Jump;
        public int Speed;
    }

    protected Avatar m_Avatar;
    protected AnimParaId m_AnimParaId;
    protected CharState m_CharState;
    protected bool m_bIsWeaponArmed;

    //Move Attributes
    protected float m_fJumpForce;
    protected float m_fMoveSpeed;
    protected float m_fMoveSpeedAtten;

    public Character() { }

    public Character(GameObject avatar)
    {
        m_Avatar.Trans = avatar.transform;
        m_Avatar.Rigid = avatar.transform.GetComponent<Rigidbody>();
        m_Avatar.Col = avatar.transform.GetComponent<Collider>();
        m_Avatar.Anim = avatar.transform.GetComponent<Animator>();
    }

    public override void OnInit()
    {
        base.OnInit();

        //Set animator parameters string to hash
        SetAnimParaHash();

        //Set move attributes
        InitMoveAttributes();
    }

    protected void InitMoveAttributes()
    {
        m_fJumpForce = 250;
        m_fMoveSpeed = 8;
        m_fMoveSpeedAtten = 0.2f;
    }

    override public void Move(float value)
    {
        float _tmpSpeed;
        if(CharState.Attacking == GetCharacterState())
        {
            _tmpSpeed = m_fMoveSpeed * m_fMoveSpeedAtten;
        }
        else
        {
            _tmpSpeed = m_fMoveSpeed;
        }
        Vector3 _moveVal = Vector3.right * value * _tmpSpeed;
        m_Avatar.Rigid.velocity = new Vector3(_moveVal.x, m_Avatar.Rigid.velocity.y, m_Avatar.Rigid.velocity.z);
        SetAnimFloat(GetAnimParaId().Speed, Mathf.Abs(value));
    }

    override public void Jump()
    {
        SetAnimTrigger(GetAnimParaId().Jump);
        GetAnimator().Play("Defence02", 0, 0);
        ResetVelocity();
        m_Avatar.Rigid.AddForce(Vector3.up * m_fJumpForce);
    }

    public void Attack()
    {
        SetAnimTrigger(GetAnimParaId().Attack);
    }

    public Vector3 GetAvatarFootPosition()
    {
        return m_Avatar.Col.bounds.min;
    }

    protected void ResetVelocity()
    {
        m_Avatar.Rigid.velocity = Vector3.zero;
    }

    public void RetriveWeapon()
    {
        m_bIsWeaponArmed = false;
    }

    public void PullOutWeapon()
    {
        m_bIsWeaponArmed = true;
    }

    protected void SetAnimInt(int id, int value)
    {
        GetAnimator().SetInteger(id, value);
    }

    protected void SetAnimInt(string name, int value)
    {
        GetAnimator().SetInteger(name, value);
    }

    protected void SetAnimTrigger(int id)
    {
        GetAnimator().SetTrigger(id);
    }

    protected void SetAnimTrigger(string name)
    {
        GetAnimator().SetTrigger(name);
    }

    protected void ResetAnimTrigger(int id)
    {
        GetAnimator().ResetTrigger(id);
    }

    protected void ResetAnimTrigger(string name)
    {
        GetAnimator().ResetTrigger(name);
    }

    protected void SetAnimBool(int id, bool value)
    {
        GetAnimator().SetBool(id, value);
    }

    protected void SetAnimBool(string name, bool value)
    {
        GetAnimator().SetBool(name, value);
    }

    protected void SetAnimFloat(int id, float value)
    {
        GetAnimator().SetFloat(id, value);
    }

    protected void SetAnimFloat(string name, float value)
    {
        GetAnimator().SetFloat(name, value);
    }

    protected Animator GetAnimator()
    {
        return m_Avatar.Anim;
    }

    protected int GetAnimParaHash(string name)
    {
        return Animator.StringToHash(name);
    }

    protected void SetAnimParaHash()
    {
        m_AnimParaId.IsWeaponArmed = GetAnimParaHash("IsWeaponArmed");
        m_AnimParaId.Attack = GetAnimParaHash("Attack");
        m_AnimParaId.Jump = GetAnimParaHash("Jump");
        m_AnimParaId.Speed = GetAnimParaHash("Speed");
    }

    protected AnimParaId GetAnimParaId()
    {
        return m_AnimParaId;
    }

    public void ShiftIdleMode()
    {
        if(true == m_bIsWeaponArmed)
        {
            RetriveWeapon();
        }
        else
        {
            PullOutWeapon();
        }
        SetAnimBool(GetAnimParaId().IsWeaponArmed, m_bIsWeaponArmed);
    }

    public void ResetAttackTrigger()
    {
        ResetAnimTrigger(GetAnimParaId().Attack);
    }

    public void ResetJumpTrigger()
    {
        ResetAnimTrigger(GetAnimParaId().Jump);
    }

    public void SetForward(Vector3 value)
    {
        m_Avatar.Trans.forward = value;
    }

    public Vector3 GetPlayerPawnPosition()
    {
        return m_Avatar.Trans.position;
    }

    public void SetCharacterState(CharState charState)
    {
        m_CharState = charState;
    }

    protected CharState GetCharacterState()
    {
        return m_CharState;
    }
}
