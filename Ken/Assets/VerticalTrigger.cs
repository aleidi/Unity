using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (CameraMng.Instance.IsTraceInVertical())
        {
            CameraMng.Instance.ActivateVerticalTrace(false);
        }
        else
        {
            CameraMng.Instance.ActivateVerticalTrace(true);
        }
    }
}
