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
}
