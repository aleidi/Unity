﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraBase
{
    protected Camera m_MainCamera;
    protected Vector3 m_vTarget;
    protected CameraShake m_CameraShake;

    public CameraBase() { }

    public CameraBase(Camera camera)
    {
        m_MainCamera = camera;
    }

    public virtual void OnInit() { }

    public virtual void OnUpdate(float deltaTime) { }

    public void SetTarget(Vector3 target)
    {
        m_vTarget = target;
    }

    virtual protected void FollowTarget()
    {
        m_MainCamera.transform.position = Vector3.Lerp(m_MainCamera.transform.position, m_vTarget, 0.5f);
    }

    public Vector3 GetRight()
    {
        return Quaternion.AngleAxis(m_MainCamera.transform.rotation.y,Vector3.up) * m_MainCamera.transform.right;
    }

    public Vector3 GetForward()
    {
        return Quaternion.AngleAxis(m_MainCamera.transform.rotation.y, Vector3.up) * m_MainCamera.transform.forward;
    }

    public void DoShake(Vector3 target, float range, float stress)
    {
        m_CameraShake.DoShake(target, range, stress);
    }

    public void SetPlayerHitedShakeParam()
    {
        m_CameraShake.SetPlayerHitedShakeParam();
    }

    public void SetPosition(Vector3 pos)
    {
        m_MainCamera.transform.position = pos;
    }

}
