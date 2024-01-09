using BaseGame.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private PoolBase pool;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject curBullet = pool.GetObject().gameObject;
            curBullet.transform.position = attackPoint.position;
        }
    }
}
