using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public float deadTime=2f; 
    public string bulletName = "EnemyBullet1";
     void OnEnable()
    {
        StartCoroutine(Go());
    } 
    IEnumerator Go()
    {
        yield return new WaitForSeconds(deadTime);    
        PoolManager.Instance.Recover(bulletName, this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))                  
                Move.Instance.Lose();                         
    }
}
