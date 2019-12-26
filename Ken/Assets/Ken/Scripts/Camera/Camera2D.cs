using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : CameraBase
{
    protected float m_fLongitudinalDisToTarget;
    protected float m_fVerticalDisToTarget;
    protected float m_fTraceSpdH = 0.1f;
    protected float m_fTraceSpdV = 0.08f;
    protected bool m_bIsTraceDirV;
    protected bool m_bIsTraceDirH;


    public float TraceSpeedH { get; } = 0.1f;
    public float TraceSpeedV { get; } = 0.08f;

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

        m_CameraShake = m_MainCamera.GetComponent<CameraShake>();

        //set trace in h,v direction
        ActivateHorizontalTrace(true);
        ActivateVerticalTrace(true);

        //set follow distance
        SetLongitudinalDistanceToTarget(5.5f);
        SetVerticalDistanceToTarget(2);

        SetFollowTarget2D();
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        SetTarget(GameInstance.Instance.GetPlayerPawn().GetCharacterPosition());

        SetFollowTarget2D();
        FollowTarget();
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


    //protected override void FollowTarget()
    //{
    //    m_MainCamera.transform.position = Vector3.Lerp(m_MainCamera.transform.position, m_vTarget, 0.1f);
    //}

    protected override  void FollowTarget()
    {
        Vector3 _tmp = m_MainCamera.transform.position;
        _tmp.z = m_vTarget.z;
        
        //Update horizontal value of camera position
        _tmp.x = Mathf.Lerp(_tmp.x, m_vTarget.x, m_fTraceSpdH);
        m_MainCamera.transform.position = _tmp;

        //Update vertical value of camera position
        _tmp.y = Mathf.Lerp(_tmp.y, m_vTarget.y, m_fTraceSpdV);
        m_MainCamera.transform.position = _tmp;
    }

    public void SetHorizontalTraceSpd(float value)
    {
        m_fTraceSpdH = value;
    }

    public void SetVerticalTraceSpd(float value)
    {
        m_fTraceSpdV = value;
    }

    public void ActivateHorizontalTrace(bool value)
    {
        if(true == value)
        {
            m_bIsTraceDirH = true;
            m_fTraceSpdH = TraceSpeedH;
        }
        else
        {
            m_bIsTraceDirH = false;
            m_fTraceSpdH = 0;
        }
    }

    public void ActivateVerticalTrace(bool value)
    {
        if(true == value)
        {
            m_bIsTraceDirV = true;
            m_fTraceSpdV = TraceSpeedV;
        }
        else
        {
            m_bIsTraceDirV = false;
            m_fTraceSpdV = 0;
        }
    }

    public bool IsTraceInHorizontal()
    {
        return m_bIsTraceDirH;
    }

    public bool IsTraceInVertical()
    {
        return m_bIsTraceDirV;
    }

}
