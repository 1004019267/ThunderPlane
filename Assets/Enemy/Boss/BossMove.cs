using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{   
    public float speed = 1.5f;
    bool isMove = true;
    
    Vector3 rightOrLeft = Vector3.left;
    // Use this for initialization
    void Start()
    {                    
    }
   
    // Update is called once per frame
    void Update()
    {
        MoveForward();
        if (transform.position.x < -2 || transform.position.x > 2.5)
        {
            rightOrLeft = -rightOrLeft;
        }
        transform.position += rightOrLeft * Time.deltaTime * speed;
    }
    void MoveForward()
    {
        if (transform.position.y > 3.11)
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}
