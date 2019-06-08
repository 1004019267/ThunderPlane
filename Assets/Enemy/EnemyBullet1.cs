using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour
{
    public GameObject fire;
    public float deadTime = 1;
    public string bulletName = "EnemyBullet2";

    void OnEnable()
    {
        StartCoroutine(Go());
    }
    
    IEnumerator Go()
    {
        yield return new WaitForSeconds(deadTime);
        fire.SetActive(true);
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
