using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMng
{
    private static CameraMng _Instance;
    public static CameraMng Instance
    {
        get
        {
            if(null == _Instance)
            {
                _Instance = new CameraMng();
            }
            return _Instance;
        }
    }

    private CameraBase m_Camera;

    public void OnInit()
    {
        //Cerate camera and allocate the main camera to camera class
        if(!CreateCamera2D())
        {
            Debug.LogError("Create camera failed!");
        }

        m_Camera.OnInit();
    }

    public void OnUpdate(float deltaTime)
    {
        m_Camera.OnUpdate(deltaTime);
    }

    public bool CreateCamera2D()
    {
        if (null == m_Camera)
        {
            m_Camera = new Camera2D();
            return true;
        }
        return false;
    }

    public Vector3 GetCameraRight()
    {
        return m_Camera.GetRight();
    }

    public Vector3 GetCameraForward()
    {
        return m_Camera.GetForward();
    }

    public void DoCameraShake(Vector3 target, float range, float stress)
    {
        m_Camera.DoShake(target, range, stress);
    }

    public void SetPlayerHitedShakeParam()
    {
        m_Camera.SetPlayerHitedShakeParam();
    }

    public void ActivateHorizontalTrace(bool value)
    {
        (m_Camera as Camera2D).ActivateHorizontalTrace(value);
    }

    public void ActivateVerticalTrace(bool value)
    {
        (m_Camera as Camera2D).ActivateVerticalTrace(value);
    }

    public bool IsTraceInHorizontal()
    {
        return (m_Camera as Camera2D).IsTraceInHorizontal();
    }

    public bool IsTraceInVertical()
    {
        return (m_Camera as Camera2D).IsTraceInVertical();
    }

}
