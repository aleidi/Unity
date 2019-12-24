using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : Actor
{
    protected enum PawnState
    {
        Alive,
        Death
    };

    protected PawnState m_ePawnState;

    public virtual void Move(float value) { }

}
