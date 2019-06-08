using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosHit1 : MonoBehaviour {
    public int speed = 10;
    // Use this for initialization
    void Start () {
		
	}	
	// Update is called once per frame
	void Update () {
        if (transform.rotation.eulerAngles.z <= 90 || transform.rotation.eulerAngles.z >= 270)
        {
            speed = -speed;
        }
        transform.Rotate(transform.forward, speed);
    }
    
}
