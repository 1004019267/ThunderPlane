using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour {
    public GameObject bulletBoss;
    public string poolName = "EnemyBoss";
    public float bulletSpeed = 1;

    public int fireRate = 5;
    float fireInterval = 5;
    float lastFireTime;
	// Use this for initialization
	void Start () {
        fireInterval = 1f / fireRate;
        PoolManager.Instance.CreatePool(poolName, bulletBoss);
	}
    public void Attack()
    {
        if (Time.time-lastFireTime>fireInterval)
        {
            lastFireTime = Time.time;
            for (int i = 0; i < 18; i++)
            {
                var go = PoolManager.Instance.Get(poolName);
                go.transform.position = transform.position;
                go.transform.rotation = Quaternion.Euler(0, 0, 20 * i);
                go.GetComponent<Rigidbody2D>().velocity = go.transform.up * bulletSpeed;
            }
        }
    }
    bool attackRound;
    public void AttackRound(bool ison)
    {
        if (ison)
        {
            if (Time.time-lastFireTime>5)
            {
                lastFireTime = Time.time;
                StartCoroutine("Round");          
            }
        }
        else
        {
            StopCoroutine("Round");
        }
    }
    IEnumerator Round()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.1f);
            var go = PoolManager.Instance.Get(poolName);
            go.transform.position = transform.position;
            go.transform.rotation = Quaternion.Euler(0, 0, 20 * i);
            go.GetComponent<Rigidbody2D>().velocity = go.transform.up * bulletSpeed;
        }
    }
    internal void CrazyAttack()
    {
        fireInterval = 0.5f / fireRate;
        Attack();
    }
}
