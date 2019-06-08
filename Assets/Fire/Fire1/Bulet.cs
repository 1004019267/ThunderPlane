using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    public GameObject effectPrefab;
    public int damage = 1;
    public string name = "PlayerBullet1";
    // Use this for initialization
    void OnEnable()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1); PoolManager.Instance.Recover(name, this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss") || other.CompareTag("Floor")||other.CompareTag("Boss1"))
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
        Destroy(go, 0.5f);
    }
}
