using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : CameraBase
{
    protected float m_fLongitudinalDisToTarget;
    protected float m_fVerticalDisToTarget;

    public Camera2D()
    {
        if(null == m_MainCamera)
        {
            m_MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
    }

    public Camera2D(Camera camera):base(camera) {}


    public override void OnInit()
    {
       base.OnInit();

        SetLongitudinalDistanceToTarget(5);
        SetVerticalDistanceToTarget(2);

        SetFollowTarget2D();
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        SetTarget(GameInstance.Instance.GetPlayerPawn().GetCharacterPosition());

        SetFollowTarget2D();
        FollowTarget(0.1f,0.08f);
    }

    protected void SetLongitudinalDistanceToTarget(float value)
    {
        m_fLongitudinalDisToTarget = value;
    }

    protected void SetVerticalDistanceToTarget(float value)
    {
        m_fVerticalDisToTarget = value;
    }

    protected void SetFollowTarget2D()
    {
        m_vTarget = m_vTarget + Vector3.back * m_fLongitudinalDisToTarget + Vector3.up * m_fVerticalDisToTarget;
    }


    protected override void FollowTarget()
    {
        m_MainCamera.transform.position = Vector3.Lerp(m_MainCamera.transform.position, m_vTarget, 0.1f);
    }

    //hValue is used for coefficient of lerp in horizontal direction
    //vValue is used for coefficient of lerp in vertical direction
    protected  void FollowTarget(float hValue, float vValue)
    {
        Vector3 _tmp = m_MainCamera.transform.position;
        _tmp.z = m_vTarget.z;
        
        //Update horizontal value of camera position
        _tmp.x = Mathf.Lerp(_tmp.x, m_vTarget.x, hValue);
        m_MainCamera.transform.position = _tmp;

        //Update vertical value of camera position
        _tmp.y = Mathf.Lerp(_tmp.y, m_vTarget.y, vValue);
        m_MainCamera.transform.position = _tmp;

    }

}
