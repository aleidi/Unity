using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CameraBase
{
    protected Camera m_MainCamera;
    protected Vector3 m_vTarget;


    public CameraBase() { }

    public CameraBase(Camera camera)
    {
        m_MainCamera = camera;
    }

    virtual public void OnInit() { }

    virtual public void OnUpdate(float deltaTime) { }

    public void SetTarget(Vector3 target)
    {
        m_vTarget = target;
    }

    virtual protected void FollowTarget()
    {
        m_MainCamera.transform.position = Vector3.Lerp(m_MainCamera.transform.position, m_vTarget, 0.5f);
    }


}
