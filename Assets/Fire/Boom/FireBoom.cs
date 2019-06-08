using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoom : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletSpeed = 10;
    int num = 3;   
    FlyUI ui;
   
    // Use this for initialization
    void Start()
    {    
        ui = FindObjectOfType<FlyUI>();
        ui.BigBoomNum(num);       
    }   
    // Update is called once per frame
    void Update()
    {
              
        if (ui.fireBoom)
        {
            ui.fireBoom = false;  
            if (num > 0)
            {
                ui.WoMan();        
                num--;
                Fire();
                ui.BigBoomNum(num);
            }          
        }    
    }
    void Fire()
    {
        var go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        go.GetComponent<Rigidbody2D>().AddForce(go.transform.up * bulletSpeed, ForceMode2D.Impulse);
        go.GetComponent<Rigidbody2D>().velocity = go.transform.up * bulletSpeed;
    }
    public void getNum()
    {
        num++;
        ui.BigBoomNum(num);
    }
}
