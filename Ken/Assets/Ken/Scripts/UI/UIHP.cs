using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHP : MonoBehaviour
{
    private Image m_Image;
    private float m_fAmount = 1;

    private void Start()
    {
        m_Image = GetComponent<Image>();
        GameInstance.Instance.BindEventPlayerHpCHnage(UpdateAmount);
        
    }

    private void UpdateAmount(float value)
    {
        m_fAmount = value;
    }

    private void Update()
    {
        float _tmp = Mathf.Abs(m_fAmount - m_Image.fillAmount);
        if (_tmp < Mathf.Epsilon)
        {
            return;
        }

        m_Image.fillAmount = Mathf.Lerp(m_Image.fillAmount, m_fAmount, Time.deltaTime * 5);
    }
}
