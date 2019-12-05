using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : ControllerBase
{
    protected ButtonBase[] m_Buttons;

    override public void OnInit()
    {
        base.OnInit();
        SetInputment();
    }

    //Index starts from 0 to max button numbers
    //for example: Button0 - Button9, then Index is from 0 - 9
    private void BindButtonAction(int index, ButtonBase.ButtonState State,ButtonBase.Button ButtonFun)
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

    private void BindAxis(int index,AxisBase.Axis AxisFun)
    {
        InputManager.Instance.GetAxis()[index].EventAxis += AxisFun;

    }

    private void SetInputment()
    {
        BindButtonAction(0, ButtonBase.ButtonState.ButtonDown, DoJump);
        BindAxis(0, DoMove);
    }


    private void DoAttack()
    {
        Debug.Log("Controller Attack Function!");
    }

    private void DoJump()
    {
        m_PlayerPawn.Jump();
    }

    private void DoMove(float value)
    {
        m_PlayerPawn.Move(value);
    }

}
