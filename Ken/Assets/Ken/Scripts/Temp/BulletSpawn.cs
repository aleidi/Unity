using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    private GameObject m_Bullet;
    [SerializeField]
    private float m_fInterval = 1;
    [SerializeField]
    private string m_sType;

    private float m_fTimer;

    // Start is called before the first frame update
    void Start()
    {
        m_fTimer = m_fInterval;
        m_Bullet = Resources.Load("Prefabs/"+ m_sType) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        m_fTimer -= Time.deltaTime;
        if(m_fTimer < 0)
        {
            Instantiate(m_Bullet, transform.position, Quaternion.Euler(new Vector3(0, -90, 0)));
            m_fTimer = m_fInterval;
        }

    }
}
