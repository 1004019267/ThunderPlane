using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour {
    bool isLeft;
    public float speed = 5;
    public float pos = 3;
    float t;
    int isTrue=3;
    // Use this for initialization        
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        if (isTrue==3)
        {
            isTrue = Random.Range(0, 2);
            if (isTrue == 0)
            {
                isLeft = true;
            }
            if (isTrue == 1)
            {
                isLeft = false;
            }          
        }   
        t += Time.deltaTime;    
        if (t>0&&isLeft==true)
        {                               
            transform.position += new Vector3(pos*1, pos*-1, 0)*Time.deltaTime;
            if (t > 2)
            {
                isLeft = false;
                t = 0;
            }
        }      
        if (t>0&&isLeft == false)
        {                                  
            transform.position += new Vector3(pos*-1, pos*-1, 0)*Time.deltaTime;
            if (t>2)
            {
                isLeft = true;
                t = 0;
            }
        }
	}
}
