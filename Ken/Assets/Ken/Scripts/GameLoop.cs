﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.OnInit();
        LevelManager.Instance.OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager.Instance.Update(Time.deltaTime);
        LevelManager.Instance.Update(Time.deltaTime);
    }
}
