using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    bool isRotate = false;
    float t = 3;
    Collider2D co;
    void Start()
    {
        co = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && isRotate == false && t >= 3)
        {
            co.enabled = true;
            Move.Instance.tag = "Player1";
            t = 0;
            isRotate = true;
        }
        if (isRotate == true)
        {           
            transform.rotation *= Quaternion.Euler(0, 0, speed);
            if (transform.eulerAngles.z < 0)
            {
                isRotate = false;
                co.enabled = false;
                Move.Instance.tag = "Player";
            }
        }
    }
}
