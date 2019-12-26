using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTools : MonoBehaviour
{
    private static GameTools m_Instance;
    public static GameTools Instance
    {
        get
        {
            return m_Instance;
        }
    }

    private void Awake()
    {
        m_Instance = this;
    }

    public static GameObject CreateGameObject(UnityEngine.Object obj, Vector3 position, Quaternion rotation)
    {
        return Instantiate(obj, position, rotation) as GameObject;
    }

    public delegate void Action();
    public void TimerForSeconds(float time, Action fun)
    {
        StartCoroutine(Timer(time, fun));
    }

    public delegate void Action<T>(T t);
    public void TimerForSeconds<T>(float time, Action<T> fun, T t)
    {
        StartCoroutine(Timer(time, fun, t));
    }

    IEnumerator Timer(float time, Action fun)
    {
        yield return new WaitForSeconds(time);
        fun.Invoke();
    }

    IEnumerator Timer<T>(float time, Action<T> fun, T t)
    {
        yield return new WaitForSeconds(time);
        fun.Invoke(t);
    }

}
