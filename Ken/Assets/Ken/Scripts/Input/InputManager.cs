using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private static InputManager m_Instance;
    public static InputManager Instance
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = new InputManager();
            }
            return m_Instance;
        }
        
    }

    private string m_sBtnName;
    private float m_fVertical;
    private float m_fHorizontal;
    private int m_iButtonNumbers = 1;
    private Dictionary<int, ButtonBase> m_Buttons;
    private AxisBase[] m_Axis;

    public void OnInit()
    {
        Debug.Log("InputManager is initiating!");
      
        ButtonInit(m_iButtonNumbers);

        AxisInit();
    }

    

    public void OnUpdate(float deltaTime)
    {
        // Debug.Log("InputManager is updating!" + "DeltaTime:" + deltaTime);
        CheckInput(deltaTime);
    }

    public void InputProcess()
    {
        m_fVertical = Input.GetAxis("Horizontal");
        m_fHorizontal = Input.GetAxis("Vertical");

    }

    private void ButtonInit(int num)
    {
        m_sBtnName = "Button";

       m_Buttons = new Dictionary<int, ButtonBase>();
        for (int i = 0; i < num; i++)
        {
            m_Buttons[i] = new ButtonBase(m_sBtnName + i.ToString());
            Debug.Log(m_Buttons[i].GetName());
        }
    }

    private void AxisInit()
    {
        m_Axis = new AxisBase[2];
        m_Axis[0] = new AxisBase("Joystick0");
        m_Axis[1] = new AxisBase("Joystick1");
    }

    //Get button instance by index for example Button0's index is 0
    public ButtonBase GetButtonByIndex(int num)
    {
        if(null == m_Buttons || num > m_Buttons.Count - 1)
        {
            Debug.LogError("Button Index exceeds the buttons' index!");
            return null;
        }

        return m_Buttons[num];
    }

    //If the button is pressed
    private bool CheckButtonDown(int btnIndex)
    {
        if (Input.GetButtonDown(m_sBtnName + btnIndex.ToString()))
        {
            m_Buttons[btnIndex].OnPress(true);
            m_Buttons[btnIndex].OnReleased(false);
            return true;
        }
        else
        {
            return false;
        }
    }

    //If the button is released
    private bool CheckButtonUp(int btnIndex)
    {
        if (Input.GetButtonUp(m_sBtnName + btnIndex.ToString()))
        {
            m_Buttons[btnIndex].OnReleased(true);
            m_Buttons[btnIndex].OnPress(false);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateButtonPressTime(int btnIndex,float deltaTime)
    {
        if (false == m_Buttons[btnIndex].IsPressed())
        {
            m_Buttons[btnIndex].ResetPressDuration(); 
        }
        else
        {
            m_Buttons[btnIndex].UpdatePressDuration(deltaTime);
        }
    }

    private void CheckInput(float deltaTime)
    {
        foreach(int key in m_Buttons.Keys)
        {
            if (CheckButtonUp(key))
            {
                m_Buttons[key].OnButtonUp();
            }
            if(CheckButtonDown(key))
            {
                m_Buttons[key].OnButtonDown();
            }
            UpdateButtonPressTime(key, deltaTime);

            for (int i = 0; i < m_Axis.Length; i++) 
            {
                m_Axis[i].OnAxisInvoke(Input.GetAxis("Joystick" + i.ToString()));
            }
        }
    }

    public Dictionary<int,ButtonBase> GetButtons()
    {
        return m_Buttons;
    }

    public int GetButtonAmount()
    {
        return m_Buttons.Count;
    }

    public AxisBase[] GetAxis()
    {
        return m_Axis;
    }

    public void SetButtonAmount(int numbers)
    {
        m_iButtonNumbers = numbers;
    }
}
