using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomNum : MonoBehaviour
{
    GetThing gt;
    Move move;
    Rigidbody2D rb;
    bool isCome = true;
    FireBoom fb;
    // Use this for initialization
    void Start()
    {
        fb = FindObjectOfType<FireBoom>();
        rb = GetComponent<Rigidbody2D>();
        move = FindObjectOfType<Move>();
        gt = FindObjectOfType<GetThing>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isCome)
        {
            isCome = false;
            Vector3 dir = Vector3.Normalize(move.transform.position - transform.position);
            dir.z = 0;
            rb.velocity = -dir*10;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player1"))
        {
            fb.getNum();
            gt.GetAc(0);
            Destroy(this.gameObject);
        }
    }
}
