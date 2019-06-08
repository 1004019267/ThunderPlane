using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieHit : MonoBehaviour
{
    public GameObject bullet;
    public string poolName = "EnemyBullet1";
    public float bulletSpeed = 1;
    // Use this for initialization
    void Start()
    {       
        PoolManager.Instance.CreatePool(poolName, bullet);
    }
    void OnDestroy()
    {
        for (int i = 0; i < 18; i++)
        {
            var go = PoolManager.Instance.Get(poolName);
            go.transform.position = transform.position;
            go.transform.rotation = Quaternion.Euler(0, 0, 20 * i);
            go.GetComponent<Rigidbody2D>().velocity = go.transform.up * bulletSpeed;
        }
    }
}
