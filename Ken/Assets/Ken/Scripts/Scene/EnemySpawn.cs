using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private EEnemy m_eEnemy = EEnemy.Skeleton;
    [SerializeField]
    private EWeapon m_eWeapon = EWeapon.Sword;

    public Character SpawnEnemy()
    {
        return FactoryMng.Instance.CreateEnemy(m_eEnemy, m_eWeapon, transform.position);
    }
}
