using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(CameraMng.Instance.IsTraceInHorizontal())
        {
            CameraMng.Instance.ActivateHorizontalTrace(false);
        }
        else
        {
            CameraMng.Instance.ActivateHorizontalTrace(true);
        }
    }
}
