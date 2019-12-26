using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICombo : MonoBehaviour
{
    private Image m_Image;
    private float m_fAmount;

    private void Awake()
    {
        m_Image = GetComponent<Image>();

        GameInstance.Instance.GetComboSys().EventComboEnergyChange += UpdateAmount;
    }

    private void UpdateAmount(float value)
    {
        m_fAmount = value / 100;
    }

    private void Update()
    {
        float _tmp = Mathf.Abs(m_fAmount - m_Image.fillAmount);
        if(_tmp < Mathf.Epsilon)
        {
            return;
        }

        m_Image.fillAmount = Mathf.Lerp(m_Image.fillAmount, m_fAmount, Time.deltaTime * 5);
    }
}
