using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerBase
{
    protected enum MovementState
    {
        Gound,
        Air
    }

    protected Character m_ContolleredPawn;
    protected MovementState m_eMovementState = MovementState.Gound;
    protected MovementState m_eLastMovementState;

    public ControllerBase()
    {
        m_ContolleredPawn = null;
    }

    public virtual void OnInit() { }
    public virtual void OnUpdate(float deltaTime)
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
            if(m_eLastMovementState == MovementState.Gound)
            {
                JumpIntoAir();
            }
            m_eMovementState = MovementState.Air;
        }

        m_eLastMovementState = m_eMovementState;
    }

    protected virtual void FallOnGround() { }

    protected virtual void JumpIntoAir() { }

    public void SetControlledPawn(Character pawn)
    {
        if(m_ContolleredPawn != null)
        {
            Debug.Log("Controlled pawn is already set");
            return;
        }
        m_ContolleredPawn = pawn;
    }

    public bool IsOwnedPlayerPawn()
    {
        if(null == m_ContolleredPawn)
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
        Vector3 _origion = m_ContolleredPawn.GetAvatarFootPosition() + Vector3.up * _offset;
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

    public Character GetPlayerPawn()
    {
        if(IsOwnedPlayerPawn())
        {
            return m_ContolleredPawn;
        }
        return null;
    }

}
