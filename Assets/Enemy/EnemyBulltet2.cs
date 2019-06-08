using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulltet2 : MonoBehaviour
{ 
    public float deadTime = 1;
    public string bulletName = "EnemyBullet3";
    public string poolName = "EnemyBullet";
    public GameObject bullet;
    public float bulletSpeed;
    // Use this for initialization
    void OnEnable()
    {
        StartCoroutine(Go());
    }
    void Start()
    {
        PoolManager.Instance.CreatePool(poolName, bullet);
    }
    IEnumerator Go()
    {
        yield return new WaitForSeconds(deadTime);
        for (int i = 0; i < 9; i++)
        {
            var go = PoolManager.Instance.Get(poolName);
            go.transform.position = transform.position;
            go.transform.rotation = Quaternion.Euler(0, 0, 40 * i);
            go.GetComponent<Rigidbody2D>().velocity = go.transform.up * bulletSpeed;
        }
        yield return new WaitForSeconds(0.1f);
        PoolManager.Instance.Recover(bulletName, this.gameObject);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Move.Instance.Lose();
        }
    }
}
