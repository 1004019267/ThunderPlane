using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject prefab;
    public string butterName;

    public float fireRate = 1f;
    public int bulletSpeed = 10;
    protected float fireInterval;
    protected float lastFireTime;
    public AudioSource au;
    // Use this for initialization
    void Awake()
    {
        //抢在初始化时，先初始化子弹的对象池
        PoolManager.Instance.CreatePool(butterName, prefab);
    }
    void Start()
    {
        fireInterval = 1f / fireRate;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            lastFireTime = Time.time;
            FlyFire();
            if (au != null)
            {
                au.Play();
            }
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
