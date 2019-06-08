using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour
{   
     public  int damage = 1;
     float t;
    void OnTriggerStay2D(Collider2D other)
    {
        t += Time.deltaTime;
        if (t >= 0.1f)
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
    }
}
