using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    AI ai = new AI();
    public float speed = 1.5f;
    public GameObject effectPrefab;
    public int hp = 1500;
    public int lastScore = 3000;
    int nowhp = 1200;
    Vector3 moveDirection = Vector3.right;
    GetThing gt;
    BossGun gun;
    MusicAll au;
    GiveEnemy giv;
    public AI AI { get { return ai; } }
    void Awake()
    {
        au = FindObjectOfType<MusicAll>();      
        gt = FindObjectOfType<GetThing>();
        gun = this.GetComponent<BossGun>();
        giv = FindObjectOfType<GiveEnemy>();
            
    }
    // Use this for initialization
    void Start()
    {
        ai.Init(this);
        au.Bgm(2);
    }
    // Update is called once per frame
    void Update()
    {
        ai.Update();
    }
    public void GetHelp()
    {
        if (hp <= nowhp)
        {
            ChangeDirection();
            gt.GetThings(transform.position + moveDirection * 3, Random.Range(0, 3));
            nowhp -= 500;
        }
    }
    public void ChangeDirection()
    {
        moveDirection = -moveDirection;
    }
    public void MoveToward()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);
    }
    public void MoveSide()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
    //普功
    public void Attack(bool ison)
    {
        gun.AttackRound(ison);
    }
    //狂暴
    public void CrazyAttack()
    {
        gun.CrazyAttack();
    }
    public void Hurt(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            GetHelp();
            if (FlyUI.scoreAdd != null)
                FlyUI.scoreAdd(damage * 2);
            if (hp <= 0)
            {
                PlayEffect();
                BossDie();
                giv.isNull = true;
                au.Bgm(0);
            }
        }
    }
    public bool IsDangerous()
    {
        return hp < 500;
    }
    void PlayEffect()
    {
        var go = Instantiate(effectPrefab, transform.position, transform.rotation);
        Destroy(go, 1f);
    }
    void BossDie()
    {
        GetComponent<Collider2D>().enabled = false;
        if (FlyUI.scoreAdd != null)
            FlyUI.scoreAdd(lastScore);
        gt.GetThings(transform.position, Random.Range(0, 10));
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            gameObject.tag = "Boss1";
        }
    }
}
