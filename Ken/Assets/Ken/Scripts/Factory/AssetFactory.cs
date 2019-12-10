using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetFactory
{
    public GameObject LoadModel(string name)
    {
        return Resources.Load("Model/" + name) as GameObject;   
    }
}
