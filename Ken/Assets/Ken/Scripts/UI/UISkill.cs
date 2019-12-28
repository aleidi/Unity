using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : MonoBehaviour
{
    private Image m_Image;

    private void Start()
    {
        m_Image = GetComponent<Image>();

        GameInstance.Instance.GetComboSys().EventSkillEnergyChange += UpdateAmount;
    }

    private void UpdateAmount(float value)
    {
        m_Image.fillAmount = value / 10;
    }
}
