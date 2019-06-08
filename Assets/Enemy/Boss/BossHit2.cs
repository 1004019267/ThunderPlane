using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit2 : MonoBehaviour {
    public int speed = 10;
    bool isZero = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isZero)
        {
            transform.Rotate(transform.forward, speed);
            if (transform.rotation == Quaternion.Euler(0, 0, 270))
            {
                isZero = false;
            }
        }
        if (isZero == false)
        {
            transform.Rotate(transform.forward, -speed);
            if (transform.rotation == Quaternion.Euler(0, 0, 90))
            {
                isZero = true;
            }
        }
    }
}
