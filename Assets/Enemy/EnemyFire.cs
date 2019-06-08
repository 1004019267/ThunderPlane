using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public string butterName;

    public float fireRate = 1f;
    public int bulletSpeed = 7;
    protected float fireInterval;
    protected float lastFireTime;
    // Use this for initialization
    //不重复执行的
    void Start()
    {
        PoolManager.Instance.CreatePool(butterName, bulletPrefab);
    }
    //每次重生就执行
    void OnEnable()
    {
        fireInterval = 1f / fireRate;
        lastFireTime = -fireInterval;
    }
    void Update()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            lastFireTime = Time.time;
            FlyFire();
        }
    }
    void FlyFire()
    {
        var go = PoolManager.Instance.Get(butterName);
        go.transform.position = firePoint.transform.position;
        go.transform.rotation = firePoint.transform.rotation;
        go.GetComponent<Rigidbody2D>().velocity = go.transform.up * bulletSpeed;
    }
}

