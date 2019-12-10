using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Pawn
{
    public enum ECharState
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

    protected struct AnimParamId
    {
        public int IsWeaponArmed;
        public int Attack;
        public int Jump;
        public int Speed;
    }

    protected Avatar m_Avatar;
    protected AnimParamId m_AnimParamId;
    protected ECharState m_eCharState;
    protected CharacterAttrBase m_Attribute;
    protected WeaponBase m_Weapon;

    protected bool m_bIsWeaponArmed;


    public Character() {}

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
    }

    public override void Move(float value)
    {
        float _tmpSpeed;
        if (ECharState.Attacking == GetCharacterState())
        {
            _tmpSpeed = m_Attribute.GetMoveSpeed() * m_Attribute.GetMoveSpeedAtten();
        }
        else
        {
            _tmpSpeed = m_Attribute.GetMoveSpeed();
        }
        Vector3 _moveVal = Vector3.right * value * _tmpSpeed;
        m_Avatar.Rigid.velocity = new Vector3(_moveVal.x, m_Avatar.Rigid.velocity.y, m_Avatar.Rigid.velocity.z);
        SetAnimFloat(GetAnimParamId().Speed, Mathf.Abs(value));
    }

    public bool Jump()
    {
        if(GetCharacterState() == ECharState.Attacking)
        {
            return false;
        }

        SetAnimTrigger(GetAnimParamId().Jump);

        ResetVelocity();
        m_Avatar.Rigid.AddForce(Vector3.up * m_Attribute.GetJumoForce());

        return true;
    }

    public void Attack()
    {
        SetAnimTrigger(GetAnimParamId().Attack);
        m_Weapon.WeaponAttack(this);
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

    public Animator GetAnimator()
    {
        return m_Avatar.Anim;
    }

    public int GetAnimParaHash(string name)
    {
        return Animator.StringToHash(name);
    }

    protected void SetAnimParaHash()
    {
        m_AnimParamId.IsWeaponArmed = GetAnimParaHash("IsWeaponArmed");
        m_AnimParamId.Attack = GetAnimParaHash("Attack");
        m_AnimParamId.Jump = GetAnimParaHash("Jump");
        m_AnimParamId.Speed = GetAnimParaHash("Speed");
    }

    protected AnimParamId GetAnimParamId()
    {
        return m_AnimParamId;
    }

    public void ShiftIdleMode()
    {
        if (true == m_bIsWeaponArmed)
        {
            RetriveWeapon();
        }
        else
        {
            PullOutWeapon();
        }
        SetAnimBool(GetAnimParamId().IsWeaponArmed, m_bIsWeaponArmed);
    }

    public void ResetAttackTrigger()
    {
        ResetAnimTrigger(GetAnimParamId().Attack);
    }

    public void ResetJumpTrigger()
    {
        ResetAnimTrigger(GetAnimParamId().Jump);
    }

    public void SetForward(Vector3 value)
    {
        m_Avatar.Trans.forward = value;
    }

    public Vector3 GetPlayerPawnPosition()
    {
        return m_Avatar.Trans.position;
    }

    public void SetCharacterState(ECharState ECharState)
    {
        m_eCharState = ECharState;
    }

    public ECharState GetCharacterState()
    {
        return m_eCharState;
    }

    public void SetAttribute(CharacterAttrBase attribute)
    {
        m_Attribute = attribute;
    }

    public void SetAvatar(GameObject avatar)
    {
        m_Avatar.Trans = avatar.transform;
        m_Avatar.Rigid = avatar.transform.GetComponent<Rigidbody>();
        m_Avatar.Col = avatar.transform.GetComponent<Collider>();
        m_Avatar.Anim = avatar.transform.GetComponent<Animator>();
    }

    public void SetWeapon(WeaponBase weapon)
    {
        m_Weapon = weapon;
    }
}
