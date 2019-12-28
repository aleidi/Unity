using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameInstance.Instance.GetPlayerPawn().OnDeath();
        }

        if(other.tag == "Monster")
        {
            other.GetComponent<CharacterEvent>().GetCharacter().OnDeath();
        }
    }
}
