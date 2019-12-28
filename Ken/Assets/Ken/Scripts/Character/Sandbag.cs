using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbag : Skeleton
{
    public override void OnInit()
    {
        base.OnInit();

        m_Avatar.Rigid.useGravity = false;
        Debug.Log("sandbag init");
    }
}
