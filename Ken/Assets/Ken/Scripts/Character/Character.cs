using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Pawn
{
    public enum ECharState
    {
        Idle,
        IdleInBattle,
        Attacking,
        Moving,
        Jumping,
        Hited
    }

    protected struct Avatar
    {
        public Transform Trans;
        public Rigidbody Rigid;
        public Collider Col;
        public Animator Anim;
        public AnimEvent AnimEvent;
    }

    protected struct AnimParamId
    {
        public int IsInBattle;
        public int Attack;
        public int Jump;
        public int Hited;
        public int Speed;
    }

    protected Avatar m_Avatar;
    protected AnimParamId m_AnimParamId;
    protected ECharState m_eCharState;
    protected CharacterAttrBase m_Attribute;
    protected WeaponBase m_Weapon;

    protected bool m_bIsInBattle;
    protected int m_iCurrentJumpTimes = 0;


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

        m_Avatar.AnimEvent.EventAttack += Attack;
    }

    #region Move mode interface which the derived class probably need to overrdie

    public override void Move(float value)
    {
        Vector3 _moveVal = Vector3.right * value * m_Attribute.GetMoveSpeed() * m_Attribute.GetMoveSpeedAtten();
        m_Avatar.Rigid.velocity = new Vector3(_moveVal.x, m_Avatar.Rigid.velocity.y, m_Avatar.Rigid.velocity.z);
        SetAnimFloat(GetAnimParamId().Speed, Mathf.Abs(value));
    }

    public virtual bool Jump()
    {
        m_iCurrentJumpTimes++;

        SetAnimTrigger(GetAnimParamId().Jump);
        GetAnimator().Play("Jump", 0, 0);
        ResetVelocity();
        m_Avatar.Rigid.AddForce(Vector3.up * m_Attribute.GetJumoForce());

        return true;
    }

    public virtual void PlayAttackAnim()
    {
        SetAnimTrigger(GetAnimParamId().Attack);
    }

    protected virtual void Attack()
    {
        m_Weapon.WeaponAttack();
    }

    public void ShiftIdleMode()
    {
        m_bIsInBattle = !m_bIsInBattle;

        SetAnimBool(GetAnimParamId().IsInBattle, m_bIsInBattle);
    }

    public virtual void UnderAttack()
    {
        Debug.Log(m_Avatar.Trans.name + "is under attack!");
    }

    #endregion

    public Vector3 GetAvatarFootPosition()
    {
        return m_Avatar.Col.bounds.min;
    }

    protected void ResetVelocity()
    {
        m_Avatar.Rigid.velocity = Vector3.zero;
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
        m_AnimParamId.IsInBattle = GetAnimParaHash("IsInBattle");
        m_AnimParamId.Attack = GetAnimParaHash("Attack");
        m_AnimParamId.Jump = GetAnimParaHash("Jump");
        m_AnimParamId.Hited = GetAnimParaHash("Hited");
        m_AnimParamId.Speed = GetAnimParaHash("Speed");
    }

    protected AnimParamId GetAnimParamId()
    {
        return m_AnimParamId;
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

    public Vector3 GetPlayerForward()
    {
        if(m_Avatar.Trans.rotation.y == 0)
        {
            return Vector3.right;
        }
        else
        {
            return Vector3.left;
        }
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
        m_Avatar.AnimEvent = avatar.transform.GetComponent<AnimEvent>();
    }

    public void SetWeapon(WeaponBase weapon)
    {
        m_Weapon = weapon;
    }

    public WeaponBase GetWeapon()
    {
        return m_Weapon;
    }

    public void SetMoveSpeedAtten(float value)
    {
        m_Attribute.SetMoveSpeedAtten(value);
    }

    public int GetJumpTimes()
    {
        return m_Attribute.GetJumpTimes();
    }

    public int GetCurrentJumpTimes()
    {
        return m_iCurrentJumpTimes;
    }

    public void ResetJumpTimes()
    {
        m_iCurrentJumpTimes = 0;
    }

    public void FallOnGround()
    {
        ResetJumpTimes();
        m_Attribute.SetMoveSpeedAtten(1);
    }

    public void JumpIntoAir()
    {

    }

    public void AttackAnimPause()
    {
        AnimPauseForSeconds(0.07f);
    }
    
    protected void AnimPauseForSeconds(float time)
    {
        float _spd = GetAnimator().speed;
        GetAnimator().speed = 0;
        GameTools.Instance.TimerForSeconds(time, ResetAnimSpeed,_spd);
    }

    protected void ResetAnimSpeed(float theSpeed)
    {
        GetAnimator().speed = theSpeed;
    }

}
