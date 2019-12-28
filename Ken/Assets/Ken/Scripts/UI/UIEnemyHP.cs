using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHP : MonoBehaviour
{
    private Character m_Character;
    private Slider m_Slier;

    private void Start()
    {
        m_Slier = GetComponent<Slider>();
        m_Character = transform.parent.parent.GetComponent<CharacterEvent>().GetCharacter();
        m_Character.BindHpChangeEvent(UpdateValue);
    }

    private void UpdateValue(float value)
    {
        m_Slier.value = value;
    }
}
