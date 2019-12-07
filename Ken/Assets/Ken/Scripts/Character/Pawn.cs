using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Pawn : Actor
{
    protected enum PawnState
    {
        Alive,
        Death
    };

    protected PawnState m_ePawnState;

    virtual public void Move(float value) { }
    virtual public void Jump() { }

}
