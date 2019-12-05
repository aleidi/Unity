using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ControllerBase
{
    protected Character m_PlayerPawn;

    public ControllerBase()
    {
        m_PlayerPawn = null;
    }

    virtual public void OnInit() { }
    virtual public void OnUpdate(float deltaTime) { }

    public bool GetPlayer(out Character playerPawn)
    {
        playerPawn = m_PlayerPawn;
        if(IsOwnedPlayerPawn())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetPlayerPawn(Character player) { m_PlayerPawn = player; }

    public bool IsOwnedPlayerPawn()
    {
        if(null == m_PlayerPawn)
        {
            Debug.LogError("PlayerPawn is not existed!");
            return false;
        }
        else
        {
            return true;
        }
    }
}
