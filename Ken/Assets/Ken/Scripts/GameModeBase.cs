using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeBase
{
    protected PlayerController m_Controller;
    protected Character m_PlayerPawn;

    public GameModeBase() { }

    public GameModeBase(PlayerController controller, Character playerPawn)
    {
        m_PlayerPawn = playerPawn;
        m_Controller = controller;
        m_Controller.SetPlayerPawn(m_PlayerPawn);
    }

    public virtual void OnInit()
    {
        m_Controller.OnInit();
        m_PlayerPawn.OnInit();
    }

    public virtual void OnUpdate(float deltaTime)
    {
        m_Controller.OnUpdate(deltaTime);
        m_PlayerPawn.OnUpdate(deltaTime);
    }

    public PlayerController GetController()
    {
        if(CheckController())
        {
            return m_Controller;
        }
        else
        {
            Debug.LogError("Controller is not existed!");
            return null;
        }
    }

    private bool CheckController()
    {
        if(null == m_Controller)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public Character GetPlayerPawn()
    {
        if(CheckPlayerPawn())
        {
            return m_PlayerPawn;
        }
        else
        {
            Debug.LogError("PlayerPawn is not exited!");
            return null;
        }
    }

    private bool CheckPlayerPawn()
    {
        if(null == m_PlayerPawn)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
