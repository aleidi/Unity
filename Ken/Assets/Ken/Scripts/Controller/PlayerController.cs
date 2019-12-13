using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ControllerBase
{
    protected ButtonBase[] m_Buttons;
    protected int m_iJumpTimes;
    protected int m_iCurrentJumpTimes;
    protected bool m_bInputEnabled;

    public override void OnInit()
    {
        base.OnInit();

        SetInputment();
        ActivateInput();
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
    }

    //Index starts from 0 to max button numbers
    //for example: Button0 - Button9, then Index is from 0 - 9
    protected void BindButtonAction(int index, ButtonBase.ButtonState State,ButtonBase.Button ButtonFun)
    {
        if (index > InputMng.Instance.GetButtonAmount() - 1)
        {
            Debug.LogError("You can't get button with over ranged index!");
            return;
        }
        switch(State)
        {
            case ButtonBase.ButtonState.ButtonUp:
                InputMng.Instance.GetButtons()[index].EventButtonUp += ButtonFun;
                break;
            case ButtonBase.ButtonState.ButtonDown:
                InputMng.Instance.GetButtons()[index].EventButtonDown += ButtonFun;
                break;
            default:
                Debug.LogError("Button Function haven't been binded to event!");
                break;
        }
    }

    protected void BindAxis(int index,AxisBase.Axis AxisFun)
    {
        InputMng.Instance.GetAxis()[index].EventAxis += AxisFun;

    }

    protected void SetInputment()
    {
        //0 delegate Button0
        BindButtonAction(0, ButtonBase.ButtonState.ButtonDown, DoAttack);
        BindButtonAction(1, ButtonBase.ButtonState.ButtonDown, DoJump);
        BindButtonAction(2, ButtonBase.ButtonState.ButtonDown, DoShiftIdleMode);
        //0 delegate Joystick0
        BindAxis(0, DoMove);
    }


    protected void DoAttack()
    {
        if (!IsInputEnable())
        {
            Debug.Log("input disabled!");
            return;
        }

        DeactivateInput();
        m_PlayerPawn.PlayAttackAnim();
        ActivateInput();

    }

    protected void DoJump()
    {
        if(!IsInputEnable())
        {
            Debug.Log("input disabled!");
            return;
        }

        DeactivateInput();
        if(CanJump())
        {
            m_PlayerPawn.Jump();
        }
        ActivateInput();
    }

    protected void DoMove(float value)
    {
        if(value > 0)
        {
            SetPlayerPawnForward(GameInstance.Instance.GetCameraForward());
        }
        if(value < 0)
        {
            SetPlayerPawnForward(GameInstance.Instance.GetCameraForward() * -1);
        }
        m_PlayerPawn.Move(value);
    }

    protected bool CanJump()
    {
        if (m_PlayerPawn.GetCurrentJumpTimes() >= m_PlayerPawn.GetJumpTimes() && 
            m_PlayerPawn.GetCharacterState() != Character.ECharState.Attacking)
        {
            return false;
        }

        return true;
    }

    protected void ActivateInput()
    {
        m_bInputEnabled = true;
    }

    protected void DeactivateInput()
    {
        m_bInputEnabled = false;
    }

    protected bool IsInputEnable()
    {
        return m_bInputEnabled;
    }

     protected override void FallOnGround()
    {
        base.FallOnGround();
        m_PlayerPawn.FallOnGround();
    }

    protected override void JumpIntoAir()
    {
        base.JumpIntoAir();
        m_PlayerPawn.JumpIntoAir();
    }

    protected void DoShiftIdleMode()
    {
        m_PlayerPawn.ShiftIdleMode();
    }

    protected void SetPlayerPawnForward(Vector3 value)
    {
        m_PlayerPawn.SetForward(value);
    }
}
