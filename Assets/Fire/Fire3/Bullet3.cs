using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet3 : MonoBehaviour
{
    public GameObject effectPrefab;
    public int damage = 1;
    public float attackRange = 3;
    Transform target;
    public int speed = 3;
    Rigidbody2D rb;
    public string name= "PlayerBullet2";
    // Use this for initialization
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1); PoolManager.Instance.Recover(name, this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            rb.GetComponent<Rigidbody2D>().velocity= transform.up * speed;
            Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, attackRange, 1 << 8);
            if (colls.Length > 0)
            {
                target = colls[0].transform;
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (target.CompareTag("Enemy") || target.CompareTag("Boss")||target.CompareTag("Boss1"))
            {               
                if (distance > attackRange)
                {
                    target = null;                   
                }
                else
                {
                    rb.GetComponent<Rigidbody2D>().Sleep();
                    transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);                
                }            
            }          
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss") || other.CompareTag("Floor") || other.CompareTag("Boss1"))
        {
            if (other.CompareTag("Enemy"))
            {
                Effect();
                other.GetComponent<Enemy>().Hurt(damage);
            }
            if (other.CompareTag("Boss"))
            {
                Effect();
                other.GetComponent<BossHp>().Hurt(damage);
            }
            if (other.CompareTag("Boss1"))
            {
                Effect();
                other.GetComponent<BossAI>().Hurt(damage);
            }
            PoolManager.Instance.Recover(name, this.gameObject);
        }                        
    }
    void Effect()
    {
        var go = Instantiate(effectPrefab, transform.position, transform.rotation);
        Destroy(go, 1f);
    }
}
