using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHit : MonoBehaviour {
    public int damage = 10;
    float t=1;
    // Use this for initialization
    void Start () {
		
	}
    void  OnTriggerStay2D(Collider2D other)
    {
        t += Time.deltaTime;
        if (t >= 1f)
        {
            t = 0;
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
        }
        if (other.CompareTag("EnemyBull"))
        {
            Destroy(other.gameObject);
        }
    }
}
