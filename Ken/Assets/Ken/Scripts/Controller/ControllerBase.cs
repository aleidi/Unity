using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ControllerBase : MonoBehaviour
{
    protected Actor m_PlayerPawn;

    public Actor GetPlayer() { return m_PlayerPawn; }

    public void SetPlayerPawn(Actor player) { m_PlayerPawn = player; }
}
