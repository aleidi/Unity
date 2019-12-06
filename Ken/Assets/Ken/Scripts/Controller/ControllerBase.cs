using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ControllerBase
{
    protected enum MovementState
    {
        Gound,
        Air
    }

    protected Character m_PlayerPawn;
    protected MovementState m_eMovementState = MovementState.Gound;
    protected MovementState m_eLastMovementState;

    public ControllerBase()
    {
        m_PlayerPawn = null;
    }

    virtual public void OnInit() { }
    virtual public void OnUpdate(float deltaTime)
    {
        CheckMovementState();
    }

    protected void CheckMovementState()
    {
        if(IsOnGround())
        {
            if(m_eLastMovementState == MovementState.Air)
            {
                FallOnGround();
            }
            m_eMovementState = MovementState.Gound;
        }
        if(IsOnAir())
        {
            m_eMovementState = MovementState.Air;
        }

        m_eLastMovementState = m_eMovementState;
    }

    virtual protected void FallOnGround() { }

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

    public void SetPlayerPawn(Character player)
    {
        m_PlayerPawn = player;
    }

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

    public bool IsOnGround()
    {
        float _offset = 1;
        Vector3 _origion = m_PlayerPawn.GetAvatarFootPosition() + Vector3.up * _offset;
        Ray _ray = new Ray(_origion, Vector3.down);
        RaycastHit _hit;
        LayerMask _layerMask = LayerMask.NameToLayer("Ground");
        if (Physics.Raycast(_ray, out _hit, _offset + 0.1f, ~_layerMask)) 
        {
            return true;
        }

        return false;
    }

    public bool IsOnAir()
    {
        return !IsOnGround();
    }

    protected MovementState GetCurrentMovementState()
    {
        return m_eMovementState;
    }

}
