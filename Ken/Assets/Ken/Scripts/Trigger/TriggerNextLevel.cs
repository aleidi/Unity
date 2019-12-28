using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextLevel : MonoBehaviour
{
    public delegate void ToNextLevel();
    public event ToNextLevel EventToNextLevel;

    private void OnTriggerEnter(Collider other)
    {
       if(EventToNextLevel != null)
        {
            EventToNextLevel.Invoke();
        }
    }
}
