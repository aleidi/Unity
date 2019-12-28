using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FactoryMng.Instance.CreateEnemy(EEnemy.SkeletonHighHp, EWeapon.Sword, transform.position);
    }

}
