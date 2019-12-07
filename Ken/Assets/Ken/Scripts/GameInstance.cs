using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance
{
    static private GameInstance m_Instance;
    static public GameInstance Instance
    {
        get
        {
            if(null == m_Instance)
            {
                m_Instance = new GameInstance();
            }
            return m_Instance;
        }
    }

    private GameModeBase m_GameMode;

    public void OnInit()
    {

        InputManager.Instance.OnInit();
        LevelManager.Instance.OnInit();

        CheckGameMode();
        m_GameMode.OnInit();

        CameraManager.Instance.OnInit();
    }

    public void OnUpdate(float deltaTime)
    {
        InputManager.Instance.OnUpdate(deltaTime);
        LevelManager.Instance.OnUpdate(deltaTime);
        m_GameMode.OnUpdate(deltaTime);

    }

    public void OnFixedUpdate(float deltaTime)
    {
        CameraManager.Instance.OnUpdate(deltaTime);
    }

    public void CreateGameMdoe(PlayerController controller, Character playerPawn)
    {
        if(null == m_GameMode)
        {
            m_GameMode = new GameModeBase(controller, playerPawn);
            Debug.Log("GameMode is created successfully!");
        }
        else
        {
            Debug.LogError("GameMode is already existed!");
        }
    }

    private bool CheckGameMode()
    {
        if(null == m_GameMode)
        {
            Debug.LogError("GameMode is not existed!");
            return false;
        }
        else
        {
            return true;
        }
    }

    public Character GetPlayerPawn()
    {
        return m_GameMode.GetPlayerPawn();
    }

    public PlayerController GetPlayerController()
    {
        return m_GameMode.GetController();
    }

}
