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
        Hited,
        Defence,
        Counter,
        Skill,
        Dead
    }

    protected struct Avatar
    {
        public Transform Trans;
        public Rigidbody Rigid;
        public Collider Col;
        public Animator Anim;
        public AnimEvent AnimEvent;
        public Transform ModelTrans;
        public CharacterShake CharShake;
    }

    protected struct AnimParamId
    {
        public int IsInBattle;
        public int IsInDefence;
        public int IsDead;
        public int Attack;
        public int Jump;
        public int Hited;
        public int Speed;
        public int PlaySpeed;
    }

    protected Avatar m_Avatar;
    protected AnimParamId m_AnimParamId;
    protected ECharState m_eCharState;
    protected CharacterAttrBase m_Attribute;
    protected WeaponBase m_Weapon;
    protected ControllerBase m_Controller;

    protected float m_fMoveValue;
    protected bool m_bIsInBattle;
    protected int m_iCurrentJumpTimes = 0;
    protected float m_fMoveInertia = 0.4f;
    protected float m_fPGDifficulity = 0.1f;
    protected Vector3 m_vKnockBackDir;
    protected bool m_bIsPerfectGuard;
    protected bool m_bIsCounter;


    public Character() {}

    public Character(GameObject avatar)
    {
        m_Avatar.Trans = avatar.transform;
        m_Avatar.Rigid = avatar.transform.GetComponent<Rigidbody>();
        m_Avatar.Col = avatar.transform.GetComponent<Collider>();
        m_Avatar.Anim = avatar.transform.GetComponent<Animator>();
        m_Avatar.ModelTrans = avatar.transform.GetChild(0);
    }

    public override void OnInit()
    {
        //Set animator parameters string to hash
        SetAnimParaHash();

        m_Avatar.AnimEvent.EventAttack += OnAttack;
        m_Avatar.AnimEvent.EventCounter += OnCounter;
        m_Avatar.AnimEvent.EventPerfectGuard += SetPerfectGuard;
        m_Avatar.AnimEvent.EventSkill += OnSkill;
        m_Attribute.EventOnDeath += OnDeath;
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
;    }

    #region Move mode interface which the derived class probably need to overrdie

    public override void Move(float value)
    {
        Vector3 _moveVal = Vector3.right * MoveCalculate(value) * m_Attribute.MoveSpeed * m_Attribute.MoveSpeedAtten;
        m_Avatar.Rigid.velocity =  new Vector3(_moveVal.x, m_Avatar.Rigid.velocity.y, _moveVal.z);
        PlayMoveAnim(value);
    }

    protected float MoveCalculate(float value)
    {
        m_fMoveValue += value * 0.1f;
        m_fMoveValue = Mathf.Clamp(m_fMoveValue, -1, 1);
        float _tmp = m_fMoveValue > 0 ? Mathf.Pow(m_fMoveValue, m_fMoveInertia) : Mathf.Pow(m_fMoveValue * -1, m_fMoveInertia) * -1;
        m_fMoveValue = Mathf.Lerp(m_fMoveValue, 0, 5f * Time.deltaTime);
        return _tmp;

    }

    public virtual bool Jump()
    {
        m_iCurrentJumpTimes++;

        SetAnimTrigger(GetAnimParamId().Jump);
        GetAnimator().Play("Jump", 0, 0);

        ////Reset the up velocity
        //m_Avatar.Rigid.velocity = new Vector3(m_Avatar.Rigid.velocity.x, 0, m_Avatar.Rigid.velocity.z);
        //m_Avatar.Rigid.AddForce(Vector3.up * m_Attribute.JumpForce);

        m_Avatar.Rigid.velocity = new Vector3(m_Avatar.Rigid.velocity.x, (Vector3.up * m_Attribute.JumpForce).y, m_Avatar.Rigid.velocity.z);


        return true;
    }

    protected virtual void OnAttack()
    {
        m_Weapon.WeaponAttack();
    }

    protected virtual void OnSkill(string name)
    {
        SkillMng.Instance.GetSkill(name).SkillAttack();
    }

    protected virtual void OnDeath()
    {

        SetAnimBool(GetAnimParamId().IsDead, true);
        GetAnimator().Play("Death");

        GameTools.Instance.TimerForSeconds(5, () =>
         {
             m_Avatar.Trans.gameObject.SetActive(false);
         });
    }

    public void ShiftIdleMode()
    {
        m_bIsInBattle = !m_bIsInBattle;

        SetAnimBool(GetAnimParamId().IsInBattle, m_bIsInBattle);
    }

    public void SetBattleMode()
    {
        SetAnimBool(GetAnimParamId().IsInBattle, true);
    }

    public virtual void UnderAttack(Character attacker)
    {
        m_Attribute.CalDamage(attacker);
        SetAnimTrigger(GetAnimParamId().Hited);
        m_Avatar.Rigid.AddForce(m_vKnockBackDir * 200);
    }

    public virtual void Defense()
    {
        m_Avatar.Rigid.AddForce(m_vKnockBackDir * 100);
    }

    public virtual void OnCounter()
    {
        m_bIsCounter = true;
        GameTools.Instance.TimerForSeconds(m_fPGDifficulity, () =>
         {
             m_bIsCounter = false;
         });
    }

    #endregion

    //Action Anim--------------------------------------

    public void PlayMoveAnim(float value)
    {
        SetAnimFloat(GetAnimParamId().Speed, Mathf.Abs(value));
    }

    public virtual void PlayAttackAnim()
    {
        SetAnimTrigger(GetAnimParamId().Attack);
    }

    public void PlayDefenceAnim(bool value)
    {
        SetAnimBool(GetAnimParamId().IsInDefence, value);
    }

    public void PlayPerfectGuardAnim()
    {
        GetAnimator().Play("PerfectGuard", 0, 0);
    }

    //Action Anim--------------------------------------

    public void SetPerfectGuard()
    {
        m_bIsPerfectGuard = true;
        GameTools.Instance.TimerForSeconds(m_fPGDifficulity, () =>
        {
            m_bIsPerfectGuard = false;
        });
    }

    public Vector3 GetAvatarFootPosition()
    {
        return m_Avatar.Col.bounds.min;
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
        m_AnimParamId.IsInDefence = GetAnimParaHash("IsInDefence");
        m_AnimParamId.IsDead = GetAnimParaHash("IsDead");
        m_AnimParamId.Attack = GetAnimParaHash("Attack");
        m_AnimParamId.Jump = GetAnimParaHash("Jump");
        m_AnimParamId.Hited = GetAnimParaHash("Hited");
        m_AnimParamId.Speed = GetAnimParaHash("Speed");
        m_AnimParamId.PlaySpeed = GetAnimParaHash("PlaySpeed");
    }

    protected AnimParamId GetAnimParamId()
    {
        return m_AnimParamId;
    }

    public void SetForward(Vector3 value)
    {
        m_Avatar.Trans.forward = value;
    }

    
    public Vector3 GetCharacterPosition()
    {
        return m_Avatar.Trans.position;
    }

    public Vector3 GetCharacterForward()
    {
        return m_Avatar.Trans.forward;
    }

    public Vector3 GetModelForward()
    {
        return m_Avatar.ModelTrans.forward;
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
        m_Avatar.ModelTrans = avatar.transform.GetChild(0);
        m_Avatar.CharShake = m_Avatar.ModelTrans.GetComponent<CharacterShake>();
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
        return m_Attribute.JumpTimes;
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

    public void AnimPauseForSeconds(float time)
    {
        //float _spd = GetAnimator().speed;
        //GetAnimator().speed = 0;
        //GameTools.Instance.TimerForSeconds(time, ResetAnimSpeed,_spd);
        GetAnimator().speed = 0;
        GameTools.Instance.TimerForSeconds(time, () =>
         {
             GetAnimator().speed = 1;
         });
    }

    protected void ResetAnimSpeed(float theSpeed)
    {
        GetAnimator().speed = theSpeed;
    }

    public virtual void SetKnockBackDir(Vector3 dir)
    {
        m_vKnockBackDir = dir;
    }

    public Vector3 GetVelocity()
    {
        return m_Avatar.Rigid.velocity;
    }

    public void ResetVelocity()
    {
        m_Avatar.Rigid.velocity = Vector3.zero;
    }

    public Vector3 GetAxis()
    {
        return m_Avatar.Trans.position;
    }

    public void SetController(ControllerBase controller)
    {
        if(m_Controller != null)
        {
            Debug.Log("Controller is already set");
            return;
        }
        m_Controller = controller;
    }

    public ControllerBase GetController()
    {
        return m_Controller;
    }

    public CharacterAttrBase GetAttribute()
    {
        return m_Attribute;
    }

    public bool IsPerfectGuard()
    {
        return m_bIsPerfectGuard;
    }

    public bool IsInDefense()
    {
        return m_eCharState == ECharState.Defence;
    }

    public void SetAnimPlaySpeed(float value)
    {
        SetAnimFloat("PlaySpeed", value);
    }

    public bool IsCounter()
    {
        return m_bIsCounter;
    }

    public void Dash(float value)
    {
        m_Avatar.Trans.Translate(GetModelForward() * value,Space.World);
    }

    public void CharacterShake()
    {
        m_Avatar.CharShake.DoShake(0.6f);
    }
}
