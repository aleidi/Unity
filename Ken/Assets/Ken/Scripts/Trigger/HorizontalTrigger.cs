using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CameraMng.Instance.ActivateHorizontalTrace(false);
            CameraMng.Instance.SetTarget(other.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            CameraMng.Instance.ActivateHorizontalTrace(true);
        }
    }
}
