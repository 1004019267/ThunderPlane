using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BossState
{
    Attack1, Attack2, Attack3, Attack4, Attack5, Attack6
}
public class BossHit : MonoBehaviour
{
    BossState state;
    public GameObject[] fires; 
    float t;
    public GameObject fire; 
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        BoosAttack();
    }   
    void BoosAttack()
    {
        switch (state)
        {
            case BossState.Attack1:
                t += Time.deltaTime;
                fires[0].SetActive(true);
                if (t > 10)
                {
                    t = 0;
                    fires[0].GetComponent<BoosHit1>().speed = 30;
                    state = BossState.Attack2;
                }
                break;
            case BossState.Attack2:
                t += Time.deltaTime;
                if (t > 10)
                {
                    fires[0].SetActive(false);
                    t = 0;
                    state = BossState.Attack3;
                }
                break;
            case BossState.Attack3:
                t += Time.deltaTime;
                fires[1].SetActive(true);
                if (t > 10)
                {
                    t = 0;
                    fires[1].SetActive(false);
                    state = BossState.Attack4;
                }
                break;
            case BossState.Attack4:
                t += Time.deltaTime;
                fires[2].SetActive(true);
                if (t > 10)
                {
                    fires[2].SetActive(false);
                    t = 0;
                    state = BossState.Attack5;
                }
                break;
            case BossState.Attack5:
                t += Time.deltaTime;
                fires[3].SetActive(true);
                if (t > 10)
                {
                    fires[3].SetActive(false);
                    t = 0;
                    state = BossState.Attack1;
                }
                break;
            case BossState.Attack6:
                t += Time.deltaTime;
                if (t > 10)
                {
                    t = 0;
                    state = BossState.Attack3;
                }
                break;
            default:
                break;
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
            gameObject.tag = "Boss";
        }
    }
}
