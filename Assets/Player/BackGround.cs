using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {
    public static int scalespeed = 1;
    public float speed;
    public bool recycle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y<-10.12f)
        {
            if (recycle)
            {
                transform.position = new Vector3(transform.position.x,9.97f,transform.position.z);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        transform.position += Vector3.down * Time.deltaTime * speed * scalespeed;
	}
}
