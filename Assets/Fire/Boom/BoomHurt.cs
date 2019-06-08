using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomHurt : MonoBehaviour
{
    public int damage = 30;
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss") || other.CompareTag("Floor") || other.CompareTag("EnemyBull")|| other.CompareTag("Boss1"))
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().Hurt(damage);
            }
            if (other.CompareTag("Boss"))
            {
                other.GetComponent<BossHp>().Hurt(damage);
            }
            if (other.CompareTag("Boss1"))
            {
                other.GetComponent<BossAI>().Hurt(damage);
            }
            if (other.CompareTag("EnemyBull"))
            {
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
