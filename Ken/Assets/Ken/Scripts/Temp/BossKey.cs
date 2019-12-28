using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKey : MonoBehaviour
{
    public delegate void OnTrigger();
    public event OnTrigger EventTrigger;

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 _dir = other.GetComponent<CharacterEvent>().GetCharacter().GetModelForward();
            if(Vector3.Dot(_dir,Vector3.right) > 0)
            {
                EventTrigger.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
