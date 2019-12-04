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
    private Dictionary<int, ButtonBase> m_Buttons;

    public void OnInit()
    {
        Debug.Log("InputManager is initiating!");
      
        ButtonInit(1);
    }

    

    public void Update(float deltaTime)
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

    public ButtonBase GetButtonByIndex(int num)
    {
        if(null == m_Buttons || num > m_Buttons.Count - 1)
        {
            Debug.LogError("Button Index exceeds the buttons' index!");
        }

        return m_Buttons[num];
    }

    private void CheckButtonDown(int btnIndex)
    {
        if (Input.GetButtonDown(m_sBtnName + btnIndex.ToString()))
        {
            m_Buttons[btnIndex].OnPress(true);
            m_Buttons[btnIndex].OnReleased(false);
        }
    }

    private void CheckButtonUp(int btnIndex)
    {
        if (Input.GetButtonUp(m_sBtnName + btnIndex.ToString()))
        {
            m_Buttons[btnIndex].OnReleased(true);
            m_Buttons[btnIndex].OnPress(false);
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
            CheckButtonUp(key);
            CheckButtonDown(key);
            UpdateButtonPressTime(key, deltaTime);
            Debug.Log("PressDuration: " +m_Buttons[key].GetPressDuration());
        }
    }
}
