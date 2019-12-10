using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTools : MonoBehaviour
{
    public static GameObject CreateGameObject(Object obj, Vector3 position, Quaternion rotation)
    {
        return GameObject.Instantiate(obj, position, rotation) as GameObject;
    }
}
