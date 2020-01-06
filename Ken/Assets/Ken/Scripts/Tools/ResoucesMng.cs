using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResoucesMng : MonoBehaviour
{
    string m_sFilePath = Application.streamingAssetsPath + "/Configuration/";
    string m_sFileName = "Attributes.csv";

    string[] m_sFileData;

    // Start is called before the first frame update
    void Start()
    {
        m_sFileData = File.ReadAllLines(m_sFilePath + m_sFileName);

        string[] _keys = m_sFileData[0].Split(',');

        for(int i = 1;i<m_sFileData.Length;i++)
        {
            string[] lineData = m_sFileData[i].Split(',');

            for(int j=0;j<lineData.Length;j++)
            {
                Debug.Log("key:" + _keys[j] + ",value:" + lineData[j] + "\n");
            }
        }

    }

}
