using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ControllerBase
{
    protected ButtonBase[] m_Buttons;
    protected int m_iJumpTimes;
    protected int m_iCurrentJumpTimes;
    protected bool m_bInputEnabled;

    override public void OnInit()
    {
        base.OnInit();

        SetInputment();
        ActivateInput();
        SetJumpTimes(2);
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);
    }

    //Index starts from 0 to max button numbers
    //for example: Button0 - Button9, then Index is from 0 - 9
    protected void BindButtonAction(int index, ButtonBase.ButtonState State,ButtonBase.Button ButtonFun)
    {
        if (index > InputManager.Instance.GetButtonAmount() - 1)
        {
            Debug.LogError("You can't get button with over ranged index!");
            return;
        }
        switch(State)
        {
            case ButtonBase.ButtonState.ButtonUp:
                InputManager.Instance.GetButtons()[index].EventButtonUp += ButtonFun;
                break;
            case ButtonBase.ButtonState.ButtonDown:
                InputManager.Instance.GetButtons()[index].EventButtonDown += ButtonFun;
                break;
            default:
                Debug.LogError("Button Function haven't been binded to event!");
                break;
        }
    }

    protected void BindAxis(int index,AxisBase.Axis AxisFun)
    {
        InputManager.Instance.GetAxis()[index].EventAxis += AxisFun;

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
        GetPlayerPawn().Attack();
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
            AddCurrentJumpTimes();
            m_PlayerPawn.Jump();
        }
        ActivateInput();
    }

    protected void DoMove(float value)
    {
        if(value > 0)
        {
            SetPlayerPawnForward(Vector3.forward);
        }
        if(value < 0)
        {
            SetPlayerPawnForward(Vector3.back);
        }
        m_PlayerPawn.Move(value);
    }

    public bool CanJump()
    {
        if (m_iCurrentJumpTimes >= m_iJumpTimes)
        {
            return false;
        }

        return true;
    }

    protected void ResetCurrentJumpTimes()
    {
        m_iCurrentJumpTimes = 0;
    }

    protected void AddCurrentJumpTimes()
    {
        m_iCurrentJumpTimes++;
    }

    protected void SetJumpTimes(int val)
    {
        m_iJumpTimes = val;
        m_iCurrentJumpTimes = 0;
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

    override protected void FallOnGround()
    {
        base.FallOnGround();
        ResetCurrentJumpTimes();
    }

    protected void DoShiftIdleMode()
    {
        GetPlayerPawn().ShiftIdleMode();
    }

    protected void SetPlayerPawnForward(Vector3 value)
    {
        GetPlayerPawn().SetForward(value);
    }
}
