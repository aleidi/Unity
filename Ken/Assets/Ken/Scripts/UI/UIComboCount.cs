using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComboCount : MonoBehaviour
{
    private Text m_Txt;

    private void Start()
    {
        m_Txt = GetComponent<Text>();

        GameInstance.Instance.GetComboSys().EventComboCountChange += UpdateAmount;
    }

    private void UpdateAmount(int value)
    {
        if(value == 0)
        {
            m_Txt.text = "";
        }

        m_Txt.text = "连击 " + value;
    }
}
