using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoubleJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameInstance.Instance.GetPlayerController().SetJumpTimes(2);
            Destroy(gameObject);
        }

    }
}
