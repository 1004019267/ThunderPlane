using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effectPrefab;
    public GameObject fire;
    public int hp = 10;
    public int enemyScore = 100;

    GetThing gt;
    // Use this for initialization
    void Start()
    {
        gt = FindObjectOfType<GetThing>();
    }
    public void Hurt(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Die();
                PlayEffect();
            }
        }
    }
    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        if (FlyUI.scoreAdd != null)
            FlyUI.scoreAdd(enemyScore);       
        GetEnemy.Instance.enemys.Remove(this);
        gt.GetThings(transform.position, Random.Range(0, 10));
        Destroy(this.gameObject);
    }
    void PlayEffect()
    {
        var go = Instantiate(effectPrefab, transform.position, transform.rotation);
        Destroy(go, 1f);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Look"))
        {
            Destroy(this.gameObject);
            GetEnemy.Instance.enemys.Remove(this);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            if (fire != null)
            {
                fire.SetActive(true);
            }
            gameObject.tag = "Enemy";
        }
    }
}
