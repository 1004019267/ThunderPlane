using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    public GameObject effectPrefab;
    public int hp = 1500;
    public int lastScore = 3000;
    MusicAll au;
    GetThing gt;
    GiveEnemy giv;
    int nowhp = 1200;
    FlyUI ui;
    Vector3 getPosition;
    Vector3 rightOrLeft= Vector3.left;
    // Use this for initialization
    void Awake()
    {
        ui = FindObjectOfType<FlyUI>();
        giv = FindObjectOfType<GiveEnemy>();
        gt = FindObjectOfType<GetThing>();
        au = FindObjectOfType<MusicAll>(); 
    }
    void Start()
    {
        ui.Danger();
        au.Bgm(1);
    }
    // Update is called once per frame
    void Update()
    {
        LoseThing();
    }
    public void LoseThing()
    {
        if (hp <= nowhp)
        {
            getPosition = transform.position + rightOrLeft * 3;
            rightOrLeft = -rightOrLeft;
            gt.GetThings(getPosition, Random.Range(0, 3));
            nowhp -= 500;
        }
    }
    public void Hurt(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            if (FlyUI.scoreAdd != null)
                FlyUI.scoreAdd(damage * 4);
            if (hp <= 0)
            {
                PlayEffect();
                BossDie();                          
                giv.isNull = true;
                au.Bgm(3);        
               ui.winOrNext();    
            }
        }
    }
    void BossDie()
    {
        GetComponent<Collider2D>().enabled = false;
        if (FlyUI.scoreAdd != null)
            FlyUI.scoreAdd(lastScore);
        gt.GetThings(transform.position, Random.Range(0, 10));
        Destroy(this.gameObject);
    }
    void PlayEffect()
    {
        var go = Instantiate(effectPrefab, transform.position, transform.rotation);
        Destroy(go, 1f);
    }
}
